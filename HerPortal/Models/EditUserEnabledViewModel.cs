using System.Collections.Generic;
using System.Linq;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using HerPortal.BusinessLogic.Models;
using HerPortal.BusinessLogic.Models.Enums;

namespace HerPortal.Models;

public class EditUserEnabledViewModel
{
    public bool Enabled;

    public UserRole? Role;

    public EditUserEnabledViewModel(User user)
    {
        Enabled = user.Enabled;
        Role = user.Role;
    }
}
