using System;
using System.Collections.Generic;
using System.Linq;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using HerPortal.BusinessLogic.Models;
using HerPortal.BusinessLogic.Services.CsvFileService;

namespace HerPortal.Models;

public class MultiRegionFilterViewModel
{
    public List<string> CustodianCodes { get; }
    public Dictionary<string, LabelViewModel> LocalAuthorityCheckboxLabels { get; }

    public char? FilterChar { get; }

    public MultiRegionFilterViewModel(IReadOnlyCollection<LocalAuthority> localAuthorities, char? filterChar)
    {
        CustodianCodes = localAuthorities.Select(la => la.CustodianCode).ToList();
        LocalAuthorityCheckboxLabels = new Dictionary<string, LabelViewModel>(localAuthorities
            .Select(la => new KeyValuePair<string, LabelViewModel>
                (
                    la.CustodianCode,
                    new LabelViewModel
                    {
                        Text = LocalAuthorityData.LocalAuthorityNamesByCustodianCode[la.CustodianCode],
                    }
                )
            )
            .OrderBy(kvp => kvp.Value.Text)
        );
        FilterChar = filterChar;
    }
}
