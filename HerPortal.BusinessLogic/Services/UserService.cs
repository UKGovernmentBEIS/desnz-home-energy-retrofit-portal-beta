using HerPortal.BusinessLogic.Models;
using HerPortal.BusinessLogic.Models.Enums;

namespace HerPortal.BusinessLogic.Services;

public class UserService
{
    private readonly IDataAccessProvider dataAccessProvider;

    public UserService(IDataAccessProvider dataAccessProvider)
    {
        this.dataAccessProvider = dataAccessProvider;
    }

    public async Task<User> GetUserByEmailAsync(string emailAddress)
    {
        var user = await dataAccessProvider.GetUserByEmailAsync(emailAddress);

        return user;
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        var user = await dataAccessProvider.GetUserByIdAsync(id);

        return user;
    }

    public async Task<IEnumerable<User>> GetUsersByLocalAuthorityAsync(int id)
    {
        return await dataAccessProvider.GetUsersByLocalAuthorityAsync(id);
    }

    public async Task AddUserByEmailAsync(string emailAddress)
    {
        await dataAccessProvider.AddUserByEmailAsync(emailAddress);
    }

    public async Task MarkUserAsHavingLoggedInAsync(int userId)
    {
        await dataAccessProvider.MarkUserAsHavingLoggedInAsync(userId);
    }

    public async Task SetUserLocalAuthoritiesByIdAsync(int userId, List<int> localAuthorityIds)
    {
        await dataAccessProvider.SetUserLocalAuthoritiesByIdAsync(userId, localAuthorityIds);
    }

    public async Task SetUserEnabledByIdAsync(int userId, bool enabled)
    {
        await dataAccessProvider.SetUserEnabledByIdAsync(userId, enabled);
    }

    public async Task SetUserRoleByIdAsync(int userId, UserRole role)
    {
        await dataAccessProvider.SetUserRoleByIdAsync(userId, role);
    }
}
