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
    public async Task<IActionResult> Index([FromQuery] List<string> custodianCodes, int page = 1)
    {
        var userEmailAddress = HttpContext.User.GetEmailAddress();
        var userData = await userService.GetUserByEmailAsync(userEmailAddress);

        if (!userData.HasLoggedIn)
        {
            await userService.MarkUserAsHavingLoggedInAsync(userData.Id);
        }

        var permission = "admin";

        switch (permission)
        {
            case "admin":
                var localAuthorities = await localAuthorityService.GetAllLocalAuthoritiesAsync();
                
                var localAuthoritiesViewModel = new LocalAuthoritiesViewModel(localAuthorities.ToList());
                
                return View("LocalAuthorities", localAuthoritiesViewModel);
            default:

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

    [HttpGet("/users")]
    public async Task<IActionResult> Users()
    {
        var users = await userService.GetAllUsersAsync();
        var usersViewModel = new UsersViewModel(users.ToList());
        return View("Users", usersViewModel);
    }

    [HttpGet("/export-all")]
    public IActionResult ExportAll()
    {
        var exportAllViewModel = new ExportAllViewModel();
        return View("ExportAll", exportAllViewModel);
    }

    [HttpGet("/local-authority/{id}/")]
    public async Task<IActionResult> LocalAuthorityGet(string id)
    {
        var localAuthority = await localAuthorityService.GetLocalAuthorityByIdAsync(int.Parse(id));
        var editLocalAuthorityViewModel = new EditLocalAuthorityViewModel(localAuthority);
        return View("EditLocalAuthority", editLocalAuthorityViewModel);
    }

    [HttpPost("/local-authority/{id}/")]
    public async Task<IActionResult> LocalAuthorityPost(EditLocalAuthorityViewModel editLocalAuthorityViewModel, string id)
    {
        await localAuthorityService.SetLocalAuthorityStatusById(int.Parse(id), editLocalAuthorityViewModel.Status ?? LocalAuthorityStatus.NotTakingPart);
        return RedirectToAction("Index");
    }

    [HttpGet("/user-la/{id}/")]
    public async Task<IActionResult> UserLaGet(string id)
    {
        var user = await userService.GetUserByIdAsync(int.Parse(id));
        var localAuthorities = await localAuthorityService.GetAllLocalAuthoritiesAsync();
        var editUserLasViewModel = new EditUserLasViewModel(user, localAuthorities.ToList());
        return View("EditUserLas", editUserLasViewModel);
    }

    [HttpPost("/user-la/{id}/")]
    public async Task<IActionResult> UserLaPost(EditUserLasViewModel editUserLasViewModel, string id)
    {
        // the checkboxes send an additional dummy value, must filter it out
        var selectedLocalAuthorityIds =
            editUserLasViewModel.SelectedLocalAuthorityIds
                .Where(localAuthorityId => int.TryParse(localAuthorityId, out _))
                .Select(int.Parse);

        await userService.SetUserLocalAuthoritiesByIdAsync(int.Parse(id), selectedLocalAuthorityIds.ToList());
        
        return RedirectToAction("Users");
    }

    [HttpGet("/adduser")]
    public IActionResult AddUserGet()
    {
        var addUserViewModel = new AddUserViewModel();
        
        return View("AddUser", addUserViewModel);
    }

    [HttpPost("/adduser")]
    public async Task<IActionResult> AddUserPost(AddUserViewModel addUserViewModel)
    {
        await userService.AddUserByEmailAsync(addUserViewModel.Email);
        
        return RedirectToAction("Users");
    }

    [HttpGet("/user-disable/{id}/")]
    public async Task<IActionResult> UserEnabledGet(string id)
    {
        var user = await userService.GetUserByIdAsync(int.Parse(id));
        var editUserDisabledViewModel = new EditUserEnabledViewModel(user);
        return View("EditUserEnabled", editUserDisabledViewModel);
    }

    [HttpPost("/user-disable/{id}/")]
    public async Task<IActionResult> UserEnabledPost([FromForm] bool enabled, string id)
    {
        await userService.SetUserEnabledByIdAsync(int.Parse(id), enabled);
        
        return RedirectToAction("Users");
    }
}
