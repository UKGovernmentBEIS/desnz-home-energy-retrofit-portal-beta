﻿namespace HerPortal.BusinessLogic.Models;

/// <summary>
///     LA-Consortium mapping data can be found both in <see cref="LocalAuthorityData"/>, and in the HUG2 Public Website codebase's LocalAuthorityData.cs.
///     <seealso href="https://github.com/UKGovernmentBEIS/desnz-home-energy-retrofit-beta/blob/develop/HerPublicWebsite.BusinessLogic/Models/LocalAuthorityData.cs">Link to HUG2 Public Website codebase's LocalAuthorityData.cs</seealso>
///     Note: Mappings in the above files are expected to be consistent between both repos
/// </summary>
public static class ConsortiumData
{
    /// Ensure that the code mapping in <see cref="LocalAuthorityData"/> is updated if any custodian codes change
    /// If a Consortium Code changes, we will need to perform a migration to map old users of the code to
    /// use the new code, and begin using the new code.
    public static readonly Dictionary<string, string> ConsortiumNamesByConsortiumCode = new()
    {
        { "C_0002", "Blackpool" },
        { "C_0003", "Bristol" },
        { "C_0004", "Broadland" },
        { "C_0006", "Cambridge" },
        { "C_0007", "Cambridgeshire & Peterborough Combined Authority" },
        { "C_0008", "Cheshire East" },
        { "C_0010", "Cornwall" },
        { "C_0012", "Darlington Borough Council" },
        { "C_0013", "Dartford" },
        { "C_0014", "Devon" },
        { "C_0015", "Dorset" },
        { "C_0016", "Eden District Council" },
        { "C_0017", "Greater London Authority" },
        { "C_0021", "Lewes" },
        { "C_0022", "Liverpool City Region" },
        { "C_0024", "Midlands Net Zero Hub" },
        { "C_0027", "North Yorkshire County Council" },
        { "C_0029", "Oxfordshire County Council" },
        { "C_0031", "Portsmouth" },
        { "C_0033", "Sedgemoor" },
        { "C_0037", "Stroud" },
        { "C_0038", "Suffolk County Council" },
        { "C_0039", "Surrey County Council" },
        { "C_0044", "West Devon" }
    };
    
    public static readonly Dictionary<string, List<string>> ConsortiumCustodianCodesIdsByConsortiumCode = 
        BuildConsortiumCustodianCodesIdsByConsortiumCode();

    public static Dictionary<string, List<string>> BuildConsortiumCustodianCodesIdsByConsortiumCode()
    {
        return LocalAuthorityData.LocalAuthorityConsortiumCodeByCustodianCode
            .GroupBy(laToConsortiumPair => laToConsortiumPair.Value)
            .ToDictionary(group => group.Key, group => group.Select(laToConsortiumPair => laToConsortiumPair.Key).ToList());
    }
}
