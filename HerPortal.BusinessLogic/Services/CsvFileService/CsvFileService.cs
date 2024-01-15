using System.Globalization;
using System.Security;
using CsvHelper;
using HerPortal.BusinessLogic.ExternalServices.S3FileReader;
using HerPortal.BusinessLogic.Models;
using HerPortal.BusinessLogic.Models.Enums;
using HerPublicWebsite.BusinessLogic.Services.S3ReferralFileKeyGenerator;

namespace HerPortal.BusinessLogic.Services.CsvFileService;

public class CsvFileService : ICsvFileService
{
    private readonly IDataAccessProvider dataAccessProvider;
    private readonly S3ReferralFileKeyService keyService;
    private readonly IS3FileReader s3FileReader;
    
    public class ReferralRecord
    {
        public int ReferralDate { get; set; }
        public string ReferralCode { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Uprn { get; set; }
        public string EpcBand { get; set; }
        public bool EpcConfirmedByHomeowner { get; set; }
        public int EpcLodgementDate { get; set; }
        public bool IfOffGasGrid { get; set; }
        public string HouseholdIncomeBand { get; set; }
        public bool IsEligible { get; set; }
        public string Tenure { get; set; }
    }

    public CsvFileService
    (
        IDataAccessProvider dataAccessProvider,
        S3ReferralFileKeyService keyService,
        IS3FileReader s3FileReader
    ) {
        this.dataAccessProvider = dataAccessProvider;
        this.keyService = keyService;
        this.s3FileReader = s3FileReader;
    }

    public async Task<IEnumerable<CsvFileData>> GetFileDataForUserAsync(string userEmailAddress)
    {
        // Make sure that we only return file data for files that the user currently has access to
        var user = await dataAccessProvider.GetUserByEmailAsync(userEmailAddress);
        var currentCustodianCodes = user.LocalAuthorities.Select(la => la.CustodianCode);
        
        var downloads = await dataAccessProvider.GetCsvFileDownloadDataForUserAsync(user.Id);
        var files = new List<CsvFileData>();

        foreach (var custodianCode in currentCustodianCodes)
        {
            var s3Objects = await s3FileReader.GetS3ObjectsByCustodianCodeAsync(custodianCode);
            files.AddRange(s3Objects.Select(s3O =>
                {
                    var data = keyService.GetDataFromS3Key(s3O.Key);
                    var downloadData = downloads.SingleOrDefault(d =>
                        d.CustodianCode == data.CustodianCode
                        && d.Year == data.Year
                        && d.Month == data.Month
                    );
                    return new CsvFileData
                    (
                        data.CustodianCode,
                        data.Month,
                        data.Year,
                        s3O.LastModified,
                        downloadData?.LastDownloaded
                    );
                }
            ));
        }

        return files
            .OrderByDescending(f => new DateOnly(f.Year, f.Month, 1))
            .ThenBy(f => LocalAuthorityData.LocalAuthorityNamesByCustodianCode[f.CustodianCode]);
    }

    // Page number starts at 1
    public async Task<PaginatedFileData> GetPaginatedFileDataForUserAsync(
        string userEmailAddress,
        List<string> custodianCodes,
        int pageNumber,
        int pageSize)
    {
        var allFileData = (await GetFileDataForUserAsync(userEmailAddress)).ToList();
        var filteredFileData = allFileData
            .Where(cfd => custodianCodes.Count == 0 || custodianCodes.Contains(cfd.CustodianCode))
            .ToList();

        var maxPage = ((filteredFileData.Count - 1) / pageSize) + 1;
        var currentPage = Math.Min(pageNumber, maxPage);

        return new PaginatedFileData
        {
            FileData = filteredFileData.Skip((currentPage - 1) * pageSize).Take(pageSize),
            CurrentPage = currentPage,
            MaximumPage = maxPage,
            UserHasUndownloadedFiles = allFileData.Any(cf => cf.HasUpdatedSinceLastDownload)
        };
    }

    public async Task<Stream> GetFileForDownloadAsync(string custodianCode, int year, int month, string userEmailAddress)
    {
        // Important! First ensure the logged-in user is allowed to access this data
        var userData = await dataAccessProvider.GetUserByEmailAsync(userEmailAddress);
        if (!userData.LocalAuthorities.Any(la => la.CustodianCode == custodianCode))
        {
            // We don't want to log the User's email address for GDPR reasons, but the ID is fine.
            throw new SecurityException(
                $"User {userData.Id} is not permitted to access file for custodian code: {custodianCode} year: {year} month: {month}.");
        }
        
        if (!LocalAuthorityData.LocalAuthorityNamesByCustodianCode.ContainsKey(custodianCode))
        {
            throw new ArgumentOutOfRangeException(nameof(custodianCode), custodianCode,
                "Given custodian code is not valid");
        }

        var fileStream = await s3FileReader.ReadFileAsync(custodianCode, year, month);
        
        // Notably, we can't confirm a download, so it's possible that we mark a file as downloaded
        //   but the user has some sort of issue and doesn't get it
        // We put this line as late as possible in the method for this reason
        await dataAccessProvider.MarkCsvFileAsDownloadedAsync(custodianCode, year, month, userData.Id);

        return fileStream;
    }

    public async Task<IEnumerable<ReferralRecord>> GetAllRecordsForUserAsync(string userEmailAddress)
    {
        // Important! First ensure the logged-in user is allowed to access this data
        var userData = await dataAccessProvider.GetUserByEmailAsync(userEmailAddress);
        
        if (userData.Role != UserRole.ServiceManager)
        {
            // We don't want to log the User's email address for GDPR reasons, but the ID is fine.
            throw new SecurityException(
                $"User {userData.Id} is not permitted to access all files");
        }

        var record1 = new ReferralRecord
        {
            ReferralDate = 1,
            ReferralCode = "HUG20000001",
            Name = "Name 1",
            Email = "samuel@example.com",
            Telephone = "1",
            Address1 = "6 Denton Close",
            Address2 = "",
            Town = "Ipswich",
            County = "Suffolk",
            Postcode = "IP2 9PN",
            Uprn = "1",
            EpcBand = "A",
            EpcConfirmedByHomeowner = true,
            EpcLodgementDate = 1,
            IfOffGasGrid = false,
            HouseholdIncomeBand = "Below £34k",
            IsEligible = true,
            Tenure = "Owner"
        };
        
        var record2 = new ReferralRecord
        {
            ReferralDate = 2,
            ReferralCode = "HUG20000002",
            Name = "Name 1",
            Email = "samuel2@example.com",
            Telephone = "1",
            Address1 = "8 Elgars Row",
            Address2 = "",
            Town = "Wells",
            County = "Norfolk",
            Postcode = "NR23 1AW",
            Uprn = "1",
            EpcBand = "D",
            EpcConfirmedByHomeowner = false,
            EpcLodgementDate = 2,
            IfOffGasGrid = true,
            HouseholdIncomeBand = "Below £34k",
            IsEligible = false,
            Tenure = "Owner"
        };

        return new[] { record1, record2 };
    }

    public async Task<Stream> GetFileDownloadForRecordsAsync(IEnumerable<ReferralRecord> referralRecords)
    {
        var tempFileName = Path.GetTempFileName();
        await using var writeStream = File.OpenWrite(tempFileName);
        await using var streamWriter = new StreamWriter(writeStream);
        await using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
        {
            await csvWriter.WriteRecordsAsync(referralRecords);
        }

        var readStream = File.OpenRead(tempFileName);
        return readStream;
    }
}