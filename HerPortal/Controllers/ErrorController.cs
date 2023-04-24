﻿using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HerPortal.Controllers;

[Authorize]
[Route("error")]
public class ErrorController: Controller
{
    [HttpGet]
    [HttpPost]
    public IActionResult HandleException()
    {
        return View("ServiceIssue");
    }
    
    [HttpGet("{code:int}")]
    public IActionResult HandleErrorsWithStatusCode(int code)
    {
        return code switch
        {
            404 => View("PageNotFound"),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}