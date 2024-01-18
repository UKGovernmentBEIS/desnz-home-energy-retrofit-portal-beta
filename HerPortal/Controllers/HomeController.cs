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
                return RedirectToAction(nameof(LocalAuthorities));
            
            case UserRole.LocalAuthorityStaff: default:
                return RedirectToAction(nameof(ReferralFiles));
        }
        
    }

    [HttpGet("/referral-files")]
    public async Task<IActionResult> ReferralFiles([FromQuery] List<string> custodianCodes, int page = 1)
    {
        var userEmailAddress = HttpContext.User.GetEmailAddress();
        var user = await userService.GetUserByEmailAsync(userEmailAddress);

        switch (user.Role)
        {
            case UserRole.DesnzStaff:
                var exportAllViewModel = new ExportAllViewModel();
                return View("ExportAll", exportAllViewModel);
                
            case UserRole.LocalAuthorityStaff: default:
                var csvFilePage = await csvFileService.GetPaginatedFileDataForUserAsync(userEmailAddress, custodianCodes, page, PageSize);

                string GetPageLink(int pageNumber) => Url.Action(nameof(Index), "Home", new RouteValueDictionary() { { "custodianCodes", custodianCodes }, { "page", pageNumber } });
                
                var homepageViewModel = new HomepageViewModel
                (
                    user,
                    csvFilePage,
                    GetPageLink
                );
                
                return View("ReferralFiles", homepageViewModel);
        }
    }

    [HttpGet("/local-authorities")]
    [TypeFilter(typeof(RequiresDesnzStaffFilterAttribute))]
    public async Task<IActionResult> LocalAuthorities([FromQuery] List<string> custodianCodes, [FromQuery] char? filterChar)
    {
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
    }

    [HttpGet("/supporting-documents")]
    public IActionResult SupportingDocuments()
    {
        return View("SupportingDocuments");
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

    [HttpGet("/local-authority/{localAuthorityId}/user/{userId}/delete")]
    [TypeFilter(typeof(RequiresDesnzStaffFilterAttribute))]
    public async Task<IActionResult> LocalAuthorityUserDeleteGet(string localAuthorityId, string userId)
    {
        var user = await userService.GetUserByIdAsync(int.Parse(userId));
        var localAuthorityUserDeleteViewModel = new LocalAuthorityUserDeleteViewModel(user);
        return View("LocalAuthorityUserDelete", localAuthorityUserDeleteViewModel);
    }

    [HttpPost("/local-authority/{localAuthorityId}/user/{userId}/delete")]
    [TypeFilter(typeof(RequiresDesnzStaffFilterAttribute))]
    public async Task<IActionResult> LocalAuthorityUserDeletePost(string localAuthorityId, string userId)
    {
        await userService.RemoveUserFromLocalAuthorityByIdAsync(int.Parse(userId), int.Parse(localAuthorityId));
        return RedirectToAction(nameof(LocalAuthorityUsersGet), new RouteValueDictionary(new { id = localAuthorityId }));
    }
}
