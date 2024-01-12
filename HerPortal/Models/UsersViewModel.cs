﻿using System;
using System.Collections.Generic;
using System.Linq;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using HerPortal.BusinessLogic.Models;
using HerPortal.BusinessLogic.Services.CsvFileService;

namespace HerPortal.Models;

public class UsersViewModel
{
    public List<User> Users { get; }
    
    public UsersViewModel(List<User> users)
    {
        Users = users;
    }
}