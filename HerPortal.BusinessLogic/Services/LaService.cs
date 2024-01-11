using HerPortal.BusinessLogic.Models;

namespace HerPortal.BusinessLogic.Services;

public class LaService
{
    private readonly IDataAccessProvider dataAccessProvider;

    public LaService(IDataAccessProvider dataAccessProvider)
    {
        this.dataAccessProvider = dataAccessProvider;
    }

    public async Task<IEnumerable<LocalAuthority>> GetAllLocalAuthoritiesAsync()
    {
        return await dataAccessProvider.GetAllLocalAuthoritiesAsync();
    }
}
