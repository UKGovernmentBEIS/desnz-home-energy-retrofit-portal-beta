using HerPortal.BusinessLogic.Models;
using HerPortal.BusinessLogic.Models.Enums;

namespace HerPortal.Models;

public class LocalAuthorityStatusViewModel
{
    public string? Name { get; set; }
    public LocalAuthorityStatus? Status { get; set; }

    public LocalAuthorityStatusViewModel(LocalAuthority localAuthority)
    {
        Name = localAuthority.Name;
        Status = localAuthority.Status;
    }

    public LocalAuthorityStatusViewModel()
    {
    }
}
