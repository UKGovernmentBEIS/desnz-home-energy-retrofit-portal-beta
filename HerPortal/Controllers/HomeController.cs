using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerPortal.BusinessLogic.Models.Enums;
using HerPortal.BusinessLogic.Services;
using HerPortal.BusinessLogic.Services.CsvFileService;
using HerPortal.Helpers;
using HerPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace HerPortal.Controllers;

public class HomeController : Controller
{
    private readonly UserService userService;
    private readonly ICsvFileService csvFileService;
    private readonly LocalAuthorityService localAuthorityService;
    private const int PageSize = 20;

    public HomeController
    (
        UserService userService,
        ICsvFileService csvFileService,
        LocalAuthorityService localAuthorityService
    ) {
        this.userService = userService;
        this.csvFileService = csvFileService;
        this.localAuthorityService = localAuthorityService;
    }
    
    [HttpGet("/")]
    public async Task<IActionResult> Index([FromQuery] List<string> custodianCodes, [FromQuery] char? filterChar, int page = 1)
    {
        var userEmailAddress = HttpContext.User.GetEmailAddress();
        var userData = await userService.GetUserByEmailAsync(userEmailAddress);

        if (!userData.HasLoggedIn)
        {
            await userService.MarkUserAsHavingLoggedInAsync(userData.Id);
        }

        switch (userData.Role)
        {
            case UserRole.DesnzStaff:
                var localAuthorities = (await localAuthorityService.GetAllLocalAuthoritiesAsync()).ToList();
                
                var firstCharFilteredLocalAuthorities = (filterChar.HasValue
                    ? localAuthorities.Where(la => la.Name.StartsWith(filterChar.Value))
                    : localAuthorities).ToList();

                var selectedLocalAuthorities = (custodianCodes.Count > 0
                    ? firstCharFilteredLocalAuthorities
                        .Where(localAuthority => custodianCodes.Contains(localAuthority.CustodianCode))
                    : firstCharFilteredLocalAuthorities).ToList();
                
                var localAuthoritiesViewModel = new LocalAuthoritiesViewModel(selectedLocalAuthorities, firstCharFilteredLocalAuthorities, localAuthorities, filterChar);
                
                return View("LocalAuthorities", localAuthoritiesViewModel);
            
            case UserRole.LocalAuthorityStaff: default:
                var csvFilePage = await csvFileService.GetPaginatedFileDataForUserAsync(userEmailAddress, custodianCodes, page, PageSize);

                string GetPageLink(int pageNumber) => Url.Action(nameof(Index), "Home", new RouteValueDictionary() { { "custodianCodes", custodianCodes }, { "page", pageNumber } });
                
                var homepageViewModel = new HomepageViewModel
                (
                    userData,
                    csvFilePage,
                    GetPageLink
                );
                
                return View("ReferralFiles", homepageViewModel);
        }
        
    }

    [HttpGet("/supporting-documents")]
    public IActionResult SupportingDocuments()
    {
        return View("SupportingDocuments");
    }

    [HttpGet("/export-all")]
    [TypeFilter(typeof(RequiresDesnzStaffFilterAttribute))]
    public IActionResult ExportAll()
    {
        var exportAllViewModel = new ExportAllViewModel();
        return View("ExportAll", exportAllViewModel);
    }

    [HttpGet("/local-authority/{id}/status")]
    [TypeFilter(typeof(RequiresDesnzStaffFilterAttribute))]
    public async Task<IActionResult> LocalAuthorityStatusGet(string id)
    {
        var localAuthority = await localAuthorityService.GetLocalAuthorityByIdAsync(int.Parse(id));
        var localAuthorityViewModel = new LocalAuthorityStatusViewModel(localAuthority);
        return View("LocalAuthorityStatus", localAuthorityViewModel);
    }

    [HttpPost("/local-authority/{id}/status")]
    [TypeFilter(typeof(RequiresDesnzStaffFilterAttribute))]
    public async Task<IActionResult> LocalAuthorityStatusPost(LocalAuthorityStatusViewModel localAuthorityStatusViewModel, string id)
    {
        await localAuthorityService.SetLocalAuthorityStatusById(int.Parse(id), localAuthorityStatusViewModel.Status ?? LocalAuthorityStatus.NotTakingPart);
        return RedirectToAction("Index");
    }

    [HttpGet("/local-authority/{id}/users")]
    [TypeFilter(typeof(RequiresDesnzStaffFilterAttribute))]
    public async Task<IActionResult> LocalAuthorityUsersGet(string id)
    {
        var localAuthorityId = int.Parse(id);
        var users = await userService.GetUsersByLocalAuthorityAsync(localAuthorityId);
        var localAuthority = await localAuthorityService.GetLocalAuthorityByIdAsync(localAuthorityId);
        var localAuthorityUsersViewModel = new LocalAuthorityUsersViewModel(users.ToList(), localAuthority);
        return View("LocalAuthorityUsers", localAuthorityUsersViewModel);
    }

    [HttpPost("/local-authority/{id}/users")]
    [TypeFilter(typeof(RequiresDesnzStaffFilterAttribute))]
    public async Task<IActionResult> UsersPost([FromForm] string email, string id)
    {
        var user = await userService.GetOrCreateUserByEmail(email);
        await userService.AddUserToLocalAuthorityByIdAsync(user.Id, int.Parse(id));
        return RedirectToAction(nameof(LocalAuthorityUsersGet), new RouteValueDictionary(new { id }));
    }
}
