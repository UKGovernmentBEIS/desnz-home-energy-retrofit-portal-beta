using HerPortal.BusinessLogic.Models;
using HerPortal.BusinessLogic.Models.Enums;

namespace HerPortal.BusinessLogic;

public interface IDataAccessProvider
{
    public Task<User> GetUserByEmailAsync(string emailAddress);
    public Task<User> GetUserByIdAsync(int id);
    public Task MarkUserAsHavingLoggedInAsync(int userId);
    public Task<IEnumerable<User>> GetUsersByLocalAuthorityAsync(int id);
    public Task<IEnumerable<User>> GetAllActiveUsersAsync();
    public Task AddUserByEmailAsync(string emailAddress);
    public Task<List<CsvFileDownload>> GetCsvFileDownloadDataForUserAsync(int userId);
    public Task MarkCsvFileAsDownloadedAsync(string custodianCode, int year, int month, int userId);
    public Task<IEnumerable<LocalAuthority>> GetAllLocalAuthoritiesAsync();
    public Task<LocalAuthority> GetLocalAuthorityByIdAsync(int id);
    public Task SetLocalAuthorityStatusById(int id, LocalAuthorityStatus status);
    public Task AddUserToLocalAuthorityByIdAsync(int userId, int localAuthorityId);
    public Task RemoveUserFromLocalAuthorityByIdAsync(int userId, int localAuthorityId);
    public Task SetUserEnabledByIdAsync(int userId, bool enabled);
    public Task SetUserRoleByIdAsync(int userId, UserRole role);
}
