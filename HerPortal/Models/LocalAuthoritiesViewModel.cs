﻿using System;
using System.Collections.Generic;
using System.Linq;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using HerPortal.BusinessLogic.Models;
using HerPortal.BusinessLogic.Services.CsvFileService;

namespace HerPortal.Models;

public class LocalAuthoritiesViewModel
{
    public List<LocalAuthority> LocalAuthorities { get; }
    
    public LocalAuthoritiesViewModel(List<LocalAuthority> localAuthorities)
    {
        LocalAuthorities = localAuthorities;
    }
}
