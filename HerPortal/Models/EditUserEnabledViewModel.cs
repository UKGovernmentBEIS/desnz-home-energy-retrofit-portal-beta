using System.Collections.Generic;
using System.Linq;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using HerPortal.BusinessLogic.Models;

namespace HerPortal.Models;

public class EditUserEnabledViewModel
{
    public bool Enabled;

    public EditUserEnabledViewModel(User user)
    {
        Enabled = user.Enabled;
    }

    public EditUserEnabledViewModel()
    {
        
    }
}
