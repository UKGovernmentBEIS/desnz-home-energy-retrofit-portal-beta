using System.Collections.Generic;
using System.Linq;
using HerPortal.BusinessLogic.Models.Enums;

namespace HerPortal.Models;

public class AlphabetFilterViewModel
{
    public enum Tab
    {
        LocalAuthorities,
        Consortiums,
        ReferralFiles,
        SupportingDocuments
    }
    
    public IEnumerable<IEnumerable<char>> AlphabetHalves { get; }

    public AlphabetFilterViewModel()
    {
        var alphabetFirstHalf = Enumerable.Range(0, 13).Select(i => (char)('A' + i));
        var alphabetSecondHalf = Enumerable.Range(0, 13).Select(i => (char)('N' + i));

        AlphabetHalves = new[] { alphabetFirstHalf, alphabetSecondHalf };
    }
}
