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

    [HttpGet("/local-authority/{id}/users")]
    [TypeFilter(typeof(RequiresDesnzStaffFilterAttribute))]
    public async Task<IActionResult> Users(string id)
    {
        var users = await userService.GetUsersByLocalAuthorityAsync(int.Parse(id));
        var usersViewModel = new UsersViewModel(users.ToList());
        return View("Users", usersViewModel);
    }

    [HttpGet("/export-all")]
    [TypeFilter(typeof(RequiresDesnzStaffFilterAttribute))]
    public IActionResult ExportAll()
    {
        var exportAllViewModel = new ExportAllViewModel();
        return View("ExportAll", exportAllViewModel);
    }

    [HttpGet("/local-authority/{id}/")]
    [TypeFilter(typeof(RequiresDesnzStaffFilterAttribute))]
    public async Task<IActionResult> LocalAuthorityGet(string id)
    {
        var localAuthority = await localAuthorityService.GetLocalAuthorityByIdAsync(int.Parse(id));
        var editLocalAuthorityViewModel = new EditLocalAuthorityViewModel(localAuthority);
        return View("EditLocalAuthority", editLocalAuthorityViewModel);
    }

    [HttpPost("/local-authority/{id}/")]
    [TypeFilter(typeof(RequiresDesnzStaffFilterAttribute))]
    public async Task<IActionResult> LocalAuthorityPost(EditLocalAuthorityViewModel editLocalAuthorityViewModel, string id)
    {
        await localAuthorityService.SetLocalAuthorityStatusById(int.Parse(id), editLocalAuthorityViewModel.Status ?? LocalAuthorityStatus.NotTakingPart);
        return RedirectToAction("Index");
    }

    [HttpGet("/user-la/{id}/")]
    [TypeFilter(typeof(RequiresDesnzStaffFilterAttribute))]
    public async Task<IActionResult> UserLaGet(string id)
    {
        var user = await userService.GetUserByIdAsync(int.Parse(id));
        var localAuthorities = await localAuthorityService.GetAllLocalAuthoritiesAsync();
        var editUserLasViewModel = new EditUserLasViewModel(user, localAuthorities.ToList());
        return View("EditUserLas", editUserLasViewModel);
    }

    [HttpPost("/user-la/{id}/")]
    [TypeFilter(typeof(RequiresDesnzStaffFilterAttribute))]
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
    [TypeFilter(typeof(RequiresDesnzStaffFilterAttribute))]
    public IActionResult AddUserGet()
    {
        var addUserViewModel = new AddUserViewModel();
        
        return View("AddUser", addUserViewModel);
    }

    [HttpPost("/adduser")]
    [TypeFilter(typeof(RequiresDesnzStaffFilterAttribute))]
    public async Task<IActionResult> AddUserPost(AddUserViewModel addUserViewModel)
    {
        await userService.AddUserByEmailAsync(addUserViewModel.Email);
        
        return RedirectToAction("Users");
    }

    [HttpGet("/user-disable/{id}/")]
    [TypeFilter(typeof(RequiresDesnzStaffFilterAttribute))]
    public async Task<IActionResult> UserEnabledGet(string id)
    {
        var user = await userService.GetUserByIdAsync(int.Parse(id));
        var editUserDisabledViewModel = new EditUserEnabledViewModel(user);
        return View("EditUserEnabled", editUserDisabledViewModel);
    }

    [HttpPost("/user-disable/{id}/")]
    [TypeFilter(typeof(RequiresDesnzStaffFilterAttribute))]
    public async Task<IActionResult> UserEnabledPost([FromForm] bool enabled, [FromForm] UserRole role, string id)
    {
        await userService.SetUserEnabledByIdAsync(int.Parse(id), enabled);
        await userService.SetUserRoleByIdAsync(int.Parse(id), role);
        
        return RedirectToAction("Users");
    }
}
