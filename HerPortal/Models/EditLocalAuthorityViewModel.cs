using HerPortal.BusinessLogic.Models;
using HerPortal.BusinessLogic.Models.Enums;

namespace HerPortal.Models;

public class EditLocalAuthorityViewModel
{
    public LocalAuthority LocalAuthority { get; }

    public LocalAuthorityStatus? LocalAuthorityStatus { get; set; }

    public EditLocalAuthorityViewModel(LocalAuthority localAuthority)
    {
        LocalAuthority = localAuthority;
        LocalAuthorityStatus = localAuthority.Status;
    }
}
