﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using HerPortal.BusinessLogic.Models;
using HerPortal.ExternalServices.CsvFiles;
using HerPortal.Models;
using NUnit.Framework;

namespace Tests.Website.Models;

[TestFixture]
public class HomepageViewModelTests
{
    private const string ValidCustodianCode = "505";
    private const string InvalidCustodianCode = "a";
    
    [TestCase(true, false)]
    [TestCase(false, true)]
    public void HomepageViewModel_OnlyWhenCreatedForUserThatHasntLoggedInBefore_ShouldShowBanner
    (
        bool hasUserLoggedIn,
        bool shouldShowBanner
    ) {
        // Arrange
        var user = new User
        {
            HasLoggedIn = hasUserLoggedIn,
        };
        
        // Act
        var viewModel = new HomepageViewModel(user, new List<CsvFileData>());
        
        // Assert
        viewModel.ShouldShowBanner.Should().Be(shouldShowBanner);
    }

    [TestCase(1, 2023, "January 2023")]
    [TestCase(4, 2020, "April 2020")]
    [TestCase(12, 2025, "December 2025")]
    public void HomepageViewModelCsvFile_WhenMonthAndYearAreGiven_ConvertsThemToAStringWithFullMonthAndYear
    (
        int month,
        int year,
        string expectedDateString
    ) {
        // Arrange
        var csvFileData = new CsvFileData
        (
            ValidCustodianCode,
            month,
            year,
            new DateTime(2023, 1, 1),
            null,
            true
        );
        
        // Act
        var viewModelCsvFile = new HomepageViewModel.CsvFile(csvFileData);
        
        // Assert
        viewModelCsvFile.MonthAndYear.Should().Be(expectedDateString);
    }
    
    [TestCase(26, 1, 2023, "26/01/23")]
    [TestCase(22, 5, 2020, "22/05/20")]
    [TestCase(19, 12, 2025, "19/12/25")]
    public void HomepageViewModelCsvFile_WhenLastUpdatedIsGiven_ConvertsItToAStringWith2DigitsAndSlashes
    (
        int day,
        int month,
        int year,
        string expectedLastUpdatedString
    ) {
        // Arrange
        var csvFileData = new CsvFileData
        (
            ValidCustodianCode,
            1,
            2024,
            new DateTime(year, month, day),
            null,
            true
        );
        
        // Act
        var viewModelCsvFile = new HomepageViewModel.CsvFile(csvFileData);
        
        // Assert
        viewModelCsvFile.LastUpdated.Should().Be(expectedLastUpdatedString);
    }
    
    [TestCase("5210", "Camden")]
    [TestCase("505", "Cambridge")]
    [TestCase("4215", "Manchester")]
    public void HomepageViewModelCsvFile_WhenValidCustodianCodeIsGiven_GetsTheLocalAuthorityName
    (
        string custodianCode,
        string expectedLocalAuthorityName
    ) {
        // Arrange
        var csvFileData = new CsvFileData
        (
            custodianCode,
            1,
            2024,
            new DateTime(2023, 1, 1),
            null,
            true
        );
        
        // Act
        var viewModelCsvFile = new HomepageViewModel.CsvFile(csvFileData);
        
        // Assert
        viewModelCsvFile.LocalAuthorityName.Should().Be(expectedLocalAuthorityName);
    }
    
    [Test]
    public void HomepageViewModelCsvFile_WhenInvalidCustodianCodeIsGiven_ThrowsException()
    {
        // Arrange
        var csvFileData = new CsvFileData
        (
            InvalidCustodianCode,
            1,
            2024,
            new DateTime(2023, 1, 1),
            null,
            true
        );
        
        // Act
        var act = () => new HomepageViewModel.CsvFile(csvFileData);
        
        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}
