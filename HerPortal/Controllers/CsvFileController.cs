﻿using System;
using System.IO;
using System.Security;
using System.Threading.Tasks;
using HerPortal.BusinessLogic.Models;
using HerPortal.BusinessLogic.Services;
using HerPortal.BusinessLogic.Services.CsvFileService;
using HerPortal.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HerPortal.Controllers;

[Route("/download")]
public class CsvFileController : Controller
{
    private readonly ICsvFileService csvFileService;
    private readonly ILogger<CsvFileController> logger;

    public CsvFileController
    (
        ICsvFileService csvFileService,
        ILogger<CsvFileController> logger
    ) {
        this.csvFileService = csvFileService;
        this.logger = logger;
    }
    
    [HttpGet("/la/{custodianCode}/{year:int}/{month:int}")]
    public async Task<IActionResult> GetLaCsvFile(string custodianCode, int year, int month)
    {
        Stream file;
        try
        {
            file = await csvFileService.GetLocalAuthorityFileForDownloadAsync(custodianCode, year, month, HttpContext.User.GetEmailAddress());
        }
        catch (SecurityException ex)
        {
            // If this is happening, someone is trying to get around the access controls or there's a bug
            logger.LogWarning(ex.Message);
            return Unauthorized("The logged-in user is not permitted to access this resource.");
        }
        catch (ArgumentOutOfRangeException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            logger.LogError
            (
                ex,
                "Error encountered when attempting to get CSV file with custodian code {CustodianCode}, year {Year}, month {Month}",
                custodianCode,
                year,
                month
            );
            return Problem($"An error occured while trying to access the CSV file with custodian code {custodianCode}, year {year}, month {month}.");
        }

        return File(file, "text/csv", $"{custodianCode}_{year}-{month:D2}.csv");
    }
    
    [HttpGet("/consortium/{consortiumCode}/{year:int}/{month:int}")]
    public async Task<IActionResult> GetConsortiumCsvFile(string consortiumCode, int year, int month)
    {
        Stream file;
        try
        {
            // TODO: share code with above?
            file = await csvFileService.GetConsortiumFileForDownloadAsync(consortiumCode, year, month, HttpContext.User.GetEmailAddress());
        }
        catch (SecurityException ex)
        {
            // If this is happening, someone is trying to get around the access controls or there's a bug
            logger.LogWarning(ex.Message);
            return Unauthorized("The logged-in user is not permitted to access this resource.");
        }
        catch (ArgumentOutOfRangeException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            logger.LogError
            (
                ex,
                "Error encountered when attempting to get CSV file with consortium code {ConsortiumCode}, year {Year}, month {Month}",
                consortiumCode,
                year,
                month
            );
            return Problem($"An error occured while trying to access the CSV file with custodian code {consortiumCode}, year {year}, month {month}.");
        }

        return File(file, "text/csv", $"{consortiumCode}_{year}-{month:D2}.csv");
    }
}
