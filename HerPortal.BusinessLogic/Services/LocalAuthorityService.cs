using HerPortal.BusinessLogic.Models;
using HerPortal.BusinessLogic.Models.Enums;

namespace HerPortal.BusinessLogic.Services;

public class LocalAuthorityService
{
    private readonly IDataAccessProvider dataAccessProvider;

    public LocalAuthorityService(IDataAccessProvider dataAccessProvider)
    {
        this.dataAccessProvider = dataAccessProvider;
    }

    public async Task<IEnumerable<LocalAuthority>> GetAllLocalAuthoritiesAsync()
    {
        return await dataAccessProvider.GetAllLocalAuthoritiesAsync();
    }

    public async Task<LocalAuthority> GetLocalAuthorityByIdAsync(int id)
    {
        return await dataAccessProvider.GetLocalAuthorityByIdAsync(id);
    }

    public async Task SetLocalAuthorityStatusById(int id, LocalAuthorityStatus status)
    {
        await dataAccessProvider.SetLocalAuthorityStatusById(id, status);
    }
}
