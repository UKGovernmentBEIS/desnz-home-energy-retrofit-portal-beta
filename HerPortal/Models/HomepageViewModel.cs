﻿using System;
using System.Collections.Generic;
using System.Linq;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using HerPortal.BusinessLogic.Models;
using HerPortal.BusinessLogic.Services.CsvFileService;

namespace HerPortal.Models;

public class HomepageViewModel
{
    public class CsvFile
    {
        public string CustodianCode { get; }
        public int Year { get; }
        public int Month { get; }
        public string MonthAndYearText => new DateOnly(Year, Month, 1).ToString("MMMM yyyy");
        public string LocalAuthorityName => LocalAuthorityData.LocalAuthorityNamesByCustodianCode[CustodianCode];
        public string LastUpdatedText { get; }
        public bool HasNewUpdates { get; }

        public CsvFile(CsvFileData csvFileData)
        {
            if (!LocalAuthorityData.LocalAuthorityNamesByCustodianCode.ContainsKey(csvFileData.CustodianCode))
            {
                throw new ArgumentOutOfRangeException(nameof(csvFileData.CustodianCode), csvFileData.CustodianCode,
                    "The given custodian code is not known.");
            }

            CustodianCode = csvFileData.CustodianCode;
            Year = csvFileData.Year;
            Month = csvFileData.Month;
            LastUpdatedText = csvFileData.LastUpdated.ToString("dd/MM/yy");
            HasNewUpdates = csvFileData.HasUpdatedSinceLastDownload;
        }
    }
    
    public bool ShouldShowBanner { get; }
    public bool ShouldShowFilters { get; }
    public bool UserHasNewUpdates { get; }
    public List<LocalAuthority> LocalAuthorities { get; }
    public IEnumerable<CsvFile> CsvFiles { get; }
    public int CurrentPage { get; }
    public string[] PageUrls { get; }

    public HomepageViewModel(User user, PaginatedFileData paginatedFileData, Func<int, string> pageLinkGenerator)
    {
        ShouldShowBanner = !user.HasLoggedIn;
        ShouldShowFilters = user.LocalAuthorities.Count >= 2;
        LocalAuthorities = user.LocalAuthorities;

        CsvFiles = paginatedFileData.FileData.Select(cf => new CsvFile(cf));

        UserHasNewUpdates = paginatedFileData.UserHasUndownloadedFiles;

        CurrentPage = paginatedFileData.CurrentPage;
        PageUrls = Enumerable.Range(1, paginatedFileData.MaximumPage).Select(pageLinkGenerator).ToArray();
    }
}
