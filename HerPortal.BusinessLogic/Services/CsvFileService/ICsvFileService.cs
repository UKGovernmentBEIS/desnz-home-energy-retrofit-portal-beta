namespace HerPortal.BusinessLogic.Services.CsvFileService;

public interface ICsvFileService
{
    public Task<IEnumerable<CsvFileData>> GetFileDataForUserAsync(string userEmailAddress);

    public Task<PaginatedFileData> GetPaginatedFileDataForUserAsync(
        string userEmailAddress,
        List<string> custodianCodes,
        int pageNumber,
        int pageSize);
    
    public Task<Stream> GetFileForDownloadAsync(string custodianCode, int year, int month, string userEmailAddress);

    public Task<IEnumerable<CsvFileService.ReferralRecord>> GetAllRecordsForUserAsync(string userEmailAddress);

    public Task<Stream> GetFileDownloadForRecordsAsync(IEnumerable<CsvFileService.ReferralRecord> referralRecords);
}