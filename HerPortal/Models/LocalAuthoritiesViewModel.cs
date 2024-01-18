using System;
using System.Collections.Generic;
using System.Linq;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using HerPortal.BusinessLogic.Models;
using HerPortal.BusinessLogic.Services.CsvFileService;

namespace HerPortal.Models;

public class LocalAuthoritiesViewModel
{
    public List<LocalAuthority> LocalAuthorities { get; }
    
    public List<LocalAuthority> PossibleLocalAuthorities { get; }
    
    public char? FilterChar { get; }

    public Predicate<char> CharCanFilterPredicate;
    
    public LocalAuthoritiesViewModel(List<LocalAuthority> localAuthorities, List<LocalAuthority> possibleLocalAuthorities, List<LocalAuthority> allLocalAuthorities, char? filterChar)
    {
        LocalAuthorities = localAuthorities;
        PossibleLocalAuthorities = possibleLocalAuthorities;
        FilterChar = filterChar;
        CharCanFilterPredicate = c => allLocalAuthorities.Any(la => la.Name.ToUpper().StartsWith(c));
    }
}
