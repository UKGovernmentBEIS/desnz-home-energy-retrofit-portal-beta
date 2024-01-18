using System;
using System.Collections.Generic;
using System.Linq;

namespace HerPortal.Models.Components;

public class AlphabetFilterViewModel
{
    public enum Tab
    {
        LocalAuthorities,
        Consortiums,
        ReferralFiles,
        SupportingDocuments
    }
    
    public List<List<char>> AlphabetHalves { get; }

    public List<Boolean> CharHasLink;

    public AlphabetFilterViewModel(Predicate<char> charCanFilterPredicate)
    {
        var alphabetFirstHalf = Enumerable.Range(0, 13).Select(i => (char)('A' + i)).ToList();
        var alphabetSecondHalf = Enumerable.Range(0, 13).Select(i => (char)('N' + i)).ToList();

        AlphabetHalves = new List<List<char>> { alphabetFirstHalf, alphabetSecondHalf };

        CharHasLink = alphabetFirstHalf.Concat(alphabetSecondHalf).Select(charCanFilterPredicate.Invoke).ToList();
    }
}
