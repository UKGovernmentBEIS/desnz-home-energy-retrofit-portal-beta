using System.Collections.Generic;
using System.Linq;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using HerPortal.BusinessLogic.Models;

namespace HerPortal.Models;

public class EditUserDisabledViewModel
{
    public bool Disabled;

    public EditUserDisabledViewModel(User user)
    {
        Disabled = user.Disabled;
    }

    public EditUserDisabledViewModel()
    {
        
    }
}
