﻿using System.Collections.Generic;
using System.Threading.Tasks;
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
    private const int PageSize = 20;

    public HomeController
    (
        UserService userService,
        ICsvFileService csvFileService
    ) {
        this.userService = userService;
        this.csvFileService = csvFileService;
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
                var localAuthoritiesViewModel = new LocalAuthoritiesViewModel();
                
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
    public IActionResult Users()
    {
        var usersViewModel = new UsersViewModel();
        return View("Users", usersViewModel);
    }

    [HttpGet("/export-all")]
    public IActionResult ExportAll()
    {
        var exportAllViewModel = new ExportAllViewModel();
        return View("ExportAll", exportAllViewModel);
    }
}
