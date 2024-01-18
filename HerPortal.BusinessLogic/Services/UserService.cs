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

    public async Task RemoveUserFromLocalAuthorityByIdAsync(int userId, int localAuthorityId)
    {
        await dataAccessProvider.RemoveUserFromLocalAuthorityByIdAsync(userId, localAuthorityId);
    }

    public async Task AddUserToLocalAuthorityByIdAsync(int userId, int localAuthorityId)
    {
        await dataAccessProvider.AddUserToLocalAuthorityByIdAsync(userId, localAuthorityId);
    }

    public async Task<User> GetOrCreateUserByEmail(string emailAddress)
    {
        try
        {
            // throws if not found
            return await GetUserByEmailAsync(emailAddress);
        }
        catch (InvalidOperationException invalidOperationException)
        {
            await AddUserByEmailAsync(emailAddress);
            return await GetUserByEmailAsync(emailAddress);
        }
    }
}
