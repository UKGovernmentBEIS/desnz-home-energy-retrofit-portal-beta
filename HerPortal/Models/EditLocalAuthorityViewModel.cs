using HerPortal.BusinessLogic.Models;

namespace HerPortal.Models;

public class EditLocalAuthorityViewModel
{
    public LocalAuthority LocalAuthority { get; }
    
    public EditLocalAuthorityViewModel(LocalAuthority localAuthority)
    {
        LocalAuthority = localAuthority;
    }
}
