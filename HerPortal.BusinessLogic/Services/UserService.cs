using HerPortal.BusinessLogic.Models;

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

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await dataAccessProvider.GetAllUsersAsync();
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
}
