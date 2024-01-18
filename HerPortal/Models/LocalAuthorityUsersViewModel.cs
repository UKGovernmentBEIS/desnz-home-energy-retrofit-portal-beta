using System;
using System.Collections.Generic;
using System.Linq;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using HerPortal.BusinessLogic.Models;
using HerPortal.BusinessLogic.Services.CsvFileService;

namespace HerPortal.Models;

public class LocalAuthorityUsersViewModel
{
    public List<User> Users { get; }
    public string Name;
    public string Email;
    public string LocalAuthorityName;
    
    public LocalAuthorityUsersViewModel(List<User> users, LocalAuthority localAuthority)
    {
        Users = users;
        LocalAuthorityName = localAuthority.Name;
    }
}
