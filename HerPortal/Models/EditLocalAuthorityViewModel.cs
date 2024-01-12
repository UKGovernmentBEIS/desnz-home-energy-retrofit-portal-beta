using HerPortal.BusinessLogic.Models;
using HerPortal.BusinessLogic.Models.Enums;

namespace HerPortal.Models;

public class EditLocalAuthorityViewModel
{
    public string? Name { get; set; }
    public LocalAuthorityStatus? Status { get; set; }

    public EditLocalAuthorityViewModel(LocalAuthority localAuthority)
    {
        Name = localAuthority.Name;
        Status = localAuthority.Status;
    }

    public EditLocalAuthorityViewModel()
    {
    }
}
