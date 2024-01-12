using System.Collections.Generic;
using System.Linq;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using HerPortal.BusinessLogic.Models;

namespace HerPortal.Models;

public class EditUserViewModel
{
    public string? Email { get; set; }
    public List<string> SelectedLocalAuthorities { get; set; }
    
    public List<string> LocalAuthorityIds { get; set; }
    
    public Dictionary<string, LabelViewModel> LocalAuthorityCheckboxLabels { get; }

    public EditUserViewModel(User user, IReadOnlyCollection<LocalAuthority> allLocalAuthorities)
    {
        Email = user.EmailAddress;
        SelectedLocalAuthorities = user.LocalAuthorities.Select(la => la.Id.ToString()).ToList();
        LocalAuthorityIds = allLocalAuthorities.Select(la => la.Id.ToString()).ToList();
        LocalAuthorityCheckboxLabels = new Dictionary<string, LabelViewModel>(
            allLocalAuthorities.Select(la => new KeyValuePair<string, LabelViewModel>(
                la.Id.ToString(),
                new LabelViewModel
                {
                    Text = la.Name
                })
            )
        );
    }

    public EditUserViewModel()
    {
        
    }
}
