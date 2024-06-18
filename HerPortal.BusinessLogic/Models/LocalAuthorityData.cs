﻿namespace HerPortal.BusinessLogic.Models;

/// <summary>
///     This class does not contain all data for Local Authorities.
///     Full data (including an LAs relationship to a Consortium) can be found in the HUG2 Public Website codebase
///     <see href="https://github.com/UKGovernmentBEIS/desnz-home-energy-retrofit-beta/blob/develop/HerPublicWebsite.BusinessLogic/Models/LocalAuthorityData.cs"> HUG2 Public Website codebase </see>
///     The LA-Consortium mapping contained here must be the same as the LocalAuthorityData.cs file in the
///     public website repository.
/// </summary>
public static class LocalAuthorityData
{
    /// If Custodian Codes change (through LAs merging etc.) we need to ensure
    /// consistency with the HUG2 Public Website data, and consider any remapping that may be required.
    /// <see
    ///     href="https://github.com/UKGovernmentBEIS/desnz-home-energy-retrofit-beta/blob/develop/HerPublicWebsite.BusinessLogic/Models/LocalAuthorityData.cs">
    ///     HUG2 Public Website codebase
    /// </see>
    /// The mapping from custodian code to name comes from the publicly available "Local custodian codes" download link
    /// on https://www.ordnancesurvey.co.uk/business-government/tools-support/addressbase-support
    /// <see href=" https://www.ordnancesurvey.co.uk/business-government/tools-support/addressbase-support" />
    public static readonly Dictionary<string, string> LocalAuthorityNamesByCustodianCode = new()
    {
        { "9052", "Aberdeenshire Council" },
        { "3805", "Adur District Council" },
        { "1005", "Amber Valley Borough Council" },
        { "9053", "Angus Council" },
        { "9054", "Argyll and Bute Council" },
        { "3810", "Arun District Council" },
        { "3005", "Ashfield District Council" },
        { "2205", "Ashford Borough Council" },
        { "3505", "Babergh District Council" },
        { "5060", "London Borough of Barking and Dagenham" },
        { "5090", "Barnet Council" },
        { "4405", "Barnsley Metropolitan Borough Council" },
        { "1505", "Basildon Borough Council" },
        { "1705", "Basingstoke and Deane Borough Council" },
        { "3010", "Bassetlaw District Council" },
        { "114", "Bath and North East Somerset Council" },
        { "235", "Bedford Borough Council" },
        { "5120", "London Borough of Bexley" },
        { "4605", "Birmingham City Council" },
        { "2405", "Blaby District Council" },
        { "2372", "Blackburn with Darwen Borough Council" },
        { "2373", "Blackpool Council" },
        { "6910", "Blaenau Gwent County Borough Council" },
        { "1010", "Bolsover District Council" },
        { "4205", "Bolton Metropolitan Borough Council" },
        { "2505", "Boston Borough Council" },
        { "1260", "Bournemouth, Christchurch and Poole Council" },
        { "335", "Bracknell Forest Borough Council" },
        { "4705", "City of Bradford Metropolitan District Council" },
        { "1510", "Braintree District Council" },
        { "2605", "Breckland District Council" },
        { "5150", "Brent Council" },
        { "1515", "Brentwood Borough Council" },
        { "6915", "Bridgend County Borough Council" },
        { "1445", "Brighton and Hove City Council" },
        { "116", "Bristol City Council" },
        { "2610", "Broadland District Council" },
        { "1805", "Bromsgrove District Council" },
        { "1905", "Broxbourne Borough Council" },
        { "3015", "Broxtowe Borough Council" },
        { "440", "Buckinghamshire Council" },
        { "2315", "Burnley Borough Council" },
        { "4210", "Bury Metropolitan Borough Council" },
        { "6920", "Caerphilly County Borough Council" },
        { "4710", "Calderdale Council" },
        { "505", "Cambridge City Council" },
        { "5210", "Camden Council" },
        { "3405", "Cannock Chase District Council" },
        { "2210", "Canterbury City Council" },
        { "6815", "City of Cardiff Council" },
        { "6825", "Carmarthenshire County Council" },
        { "1520", "Castle Point District Council" },
        { "240", "Central Bedfordshire Council" },
        { "6820", "Ceredigion County Council" },
        { "2410", "Charnwood Borough Council" },
        { "1525", "Chelmsford City Council" },
        { "1605", "Cheltenham Borough Council" },
        { "3105", "Cherwell District Council" },
        { "660", "Cheshire East Council" },
        { "665", "Cheshire West and Chester Council" },
        { "1015", "Chesterfield Borough Council" },
        { "3815", "Chichester District Council" },
        { "2320", "Chorley Borough Council" },
        { "9051", "Aberdeen City Council" },
        { "9059", "Dundee City Council" },
        { "9064", "City of Edinburgh Council" },
        { "9067", "Glasgow City Council" },
        { "5030", "City of London Corporation" },
        { "3455", "Stoke-on-Trent City Council" },
        { "5990", "Westminster City Council" },
        { "9056", "Clackmannanshire Council" },
        { "1530", "Colchester Borough Council" },
        { "6905", "Conwy County Borough Council" },
        { "840", "Cornwall Council" },
        { "1610", "Cotswold District Council" },
        { "4610", "Coventry City Council" },
        { "3820", "Crawley Borough Council" },
        { "5240", "Croydon Council" },
        { "940", "Cumberland Council" },
        { "1910", "Dacorum Borough Council" },
        { "1350", "Darlington Borough Council" },
        { "2215", "Dartford Borough Council" },
        { "6830", "Denbighshire County Council" },
        { "1055", "Derby City Council" },
        { "1045", "Derbyshire Dales District Council" },
        { "4410", "Doncaster Metropolitan Borough Council" },
        { "1265", "Dorset Council" },
        { "2220", "Dover District Council" },
        { "4615", "Dudley Borough Council" },
        { "9058", "Dumfries and Galloway Council" },
        { "1355", "Durham County Council" },
        { "5270", "Ealing Council" },
        { "9060", "East Ayrshire Council" },
        { "510", "East Cambridgeshire District Council" },
        { "1105", "East Devon District Council" },
        { "9061", "East Dunbartonshire Council" },
        { "1710", "East Hampshire District Council" },
        { "1915", "East Hertfordshire District Council" },
        { "2510", "East Lindsey District Council" },
        { "9062", "East Lothian Council" },
        { "9063", "East Renfrewshire Council" },
        { "2001", "East Riding of Yorkshire Council" },
        { "3410", "East Staffordshire Borough Council" },
        { "3540", "East Suffolk Council" },
        { "1410", "Eastbourne Borough Council" },
        { "1715", "Eastleigh Borough Council" },
        { "3605", "Elmbridge Borough Council" },
        { "5300", "Enfield Council" },
        { "1535", "Epping Forest District Council" },
        { "3610", "Epsom and Ewell Borough Council" },
        { "1025", "Erewash Borough Council" },
        { "1110", "Exeter City Council" },
        { "9065", "Falkirk Council" },
        { "1720", "Fareham Borough Council" },
        { "515", "Fenland District Council" },
        { "9066", "Fife Council" },
        { "6835", "Flintshire County Council" },
        { "2250", "Folkestone and Hythe District Council" },
        { "1615", "Forest of Dean District Council" },
        { "2325", "Fylde Borough Council" },
        { "4505", "Gateshead Metropolitan Borough Council" },
        { "3020", "Gedling Borough Council" },
        { "1620", "Gloucester City Council" },
        { "1725", "Gosport Borough Council" },
        { "2230", "Gravesham Borough Council" },
        { "2615", "Great Yarmouth Borough Council" },
        { "5330", "Royal Borough of Greenwich" },
        { "3615", "Guildford Borough Council" },
        { "6810", "Gwynedd Council" },
        { "5360", "Hackney Council" },
        { "650", "Halton Borough Council" },
        { "5390", "London Borough of Hammersmith and Fulham" },
        { "2415", "Harborough District Council" },
        { "1540", "Harlow District Council" },
        { "5450", "London Borough of Harrow" },
        { "1730", "Hart District Council" },
        { "724", "Hartlepool Borough Council" },
        { "1415", "Hastings Borough Council" },
        { "1735", "Havant Borough Council" },
        { "5480", "London Borough of Havering" },
        { "1850", "Herefordshire County Council" },
        { "1920", "Hertsmere Borough Council" },
        { "1030", "High Peak Borough Council" },
        { "9068", "The Highland Council" },
        { "5510", "Hillingdon Council" },
        { "2420", "Hinckley & Bosworth Borough Council" },
        { "3825", "Horsham District Council" },
        { "520", "Huntingdonshire District Council" },
        { "2330", "Hyndburn Borough" },
        { "9069", "Inverclyde Council" },
        { "3515", "Ipswich Borough Council" },
        { "6805", "Isle of Anglesey County Council" },
        { "2114", "Isle of Wight Council" },
        { "835", "Council of the Isles of Scilly" },
        { "5570", "Islington Council" },
        { "5600", "Royal Borough of Kensington and Chelsea" },
        { "2635", "Kings Lynn & West Norfolk Borough" },
        { "2004", "Hull City Council" },
        { "5630", "Royal Borough of Kingston upon Thames" },
        { "4715", "Kirklees Council" },
        { "4305", "Knowsley Council" },
        { "5660", "Lambeth Council" },
        { "2335", "Lancaster City Council" },
        { "4720", "Leeds City Council" },
        { "2465", "Leicester City Council" },
        { "1425", "Lewes District Council" },
        { "5690", "Lewisham Council" },
        { "3415", "Lichfield City Council" },
        { "2515", "Lincoln City Council" },
        { "4310", "Liverpool City Council" },
        { "5180", "London Borough of Bromley" },
        { "5420", "Haringey Council" },
        { "5540", "London Borough of Hounslow" },
        { "230", "Luton Borough Council" },
        { "2235", "Maidstone Borough Council" },
        { "1545", "Maldon District Council" },
        { "1820", "Malvern Hills District Council" },
        { "4215", "Manchester City Council" },
        { "3025", "Mansfield District Council" },
        { "2280", "Medway Council" },
        { "2430", "Melton Borough Council" },
        { "6925", "Merthyr Tydfil County Borough Council" },
        { "5720", "London Borough of Merton" },
        { "1135", "Mid Devon District Council" },
        { "3520", "Mid Suffolk District Council" },
        { "3830", "Mid Sussex District Council" },
        { "734", "Middlesbrough Borough Council" },
        { "9070", "Midlothian Council" },
        { "435", "Milton Keynes Council" },
        { "3620", "Mole Valley District Council" },
        { "6840", "Monmouthshire County Council" },
        { "9071", "The Moray Council" },
        { "6930", "Neath Port Talbot County Borough Council" },
        { "1740", "New Forest District Council" },
        { "3030", "Newark & Sherwood District Council" },
        { "4510", "Newcastle City Council" },
        { "3420", "Newcastle-under-Lyme District Council" },
        { "5750", "Newham Council" },
        { "6935", "Newport City Council" },
        { "9072", "North Ayrshire Council" },
        { "1115", "North Devon District Council" },
        { "1035", "North East Derbyshire District Council" },
        { "2002", "North East Lincolnshire Council" },
        { "1925", "North Hertfordshire District Council" },
        { "2520", "North Kesteven District Council" },
        { "9073", "North Lanarkshire Council" },
        { "2003", "North Lincolnshire Council" },
        { "2620", "North Norfolk District Council" },
        { "2840", "North Northamptonshire Council" },
        { "121", "North Somerset Council" },
        { "4515", "North Tyneside Council" },
        { "3705", "North Warwickshire Borough Council" },
        { "2435", "North West Leicestershire District Council" },
        { "2745", "North Yorkshire Council" },
        { "2935", "Northumberland County Council" },
        { "2625", "Norwich City Council" },
        { "3060", "Nottingham City Council" },
        { "3710", "Nuneaton and Bedworth Borough Council" },
        { "2440", "Oadby and Wigston District Council" },
        { "4220", "Oldham Metropolitan Borough Council" },
        { "7655", "Ordnance Survey" },
        { "9000", "Orkney Islands Council" },
        { "3110", "Oxford City Council" },
        { "6845", "Pembrokeshire County Council" },
        { "2340", "Pendle Borough Council" },
        { "9074", "Perth and Kinross Council" },
        { "540", "Peterborough City Council" },
        { "1160", "Plymouth City Council" },
        { "1775", "Portsmouth City Council" },
        { "6850", "Powys County Council" },
        { "2345", "Preston City Council" },
        { "345", "Reading Borough Council" },
        { "5780", "London Borough of Redbridge" },
        { "728", "Redcar and Cleveland Borough" },
        { "1825", "Redditch Borough Council" },
        { "3625", "Reigate and Banstead Borough Council" },
        { "9075", "Renfrewshire Council" },
        { "6940", "Rhondda Cynon Taf County Borough Council" },
        { "2350", "Ribble Valley Borough Council" },
        { "5810", "London Borough of Richmond upon Thames" },
        { "4225", "Rochdale Metropolitan Borough Council" },
        { "1550", "Rochford District Council" },
        { "2355", "Rossendale Borough Council" },
        { "1430", "Rother District Council" },
        { "4415", "Rotherham Metropolitan Borough Council" },
        { "3715", "Rugby Borough Council" },
        { "3630", "Runnymede Borough Council" },
        { "3040", "Rushcliffe Borough Council" },
        { "1750", "Rushmoor Borough Council" },
        { "2470", "Rutland County Council" },
        { "4230", "Salford City Council" },
        { "4620", "Sandwell Borough Council" },
        { "9055", "Scottish Borders Council" },
        { "4320", "Sefton Council" },
        { "2245", "Sevenoaks District Council" },
        { "4420", "Sheffield City Council" },
        { "9010", "Shetland Islands Council" },
        { "3245", "Shropshire County Council" },
        { "350", "Slough Borough Council" },
        { "4625", "Solihull Borough Council" },
        { "3300", "Somerset Council" },
        { "9076", "South Ayrshire Council" },
        { "530", "South Cambridgeshire District Council" },
        { "1040", "South Derbyshire District Council" },
        { "119", "South Gloucestershire Council" },
        { "1125", "South Hams District Council" },
        { "2525", "South Holland District Council" },
        { "2530", "South Kesteven District Council" },
        { "9077", "South Lanarkshire Council" },
        { "2630", "South Norfolk District Council" },
        { "3115", "South Oxfordshire District Council" },
        { "2360", "South Ribble Borough Council" },
        { "3430", "South Staffordshire District Council" },
        { "4520", "South Tyneside Council" },
        { "1780", "Southampton City Council" },
        { "1590", "Southend-on-Sea Borough Council" },
        { "5840", "Southwark Council" },
        { "3635", "Spelthorne Borough Council" },
        { "1930", "St Albans City Council" },
        { "4315", "St Helens Borough Council" },
        { "3425", "Stafford Borough Council" },
        { "3435", "Staffordshire Moorlands District Council" },
        { "1935", "Stevenage Borough Council" },
        { "9078", "Stirling Council" },
        { "4235", "Stockport Metropolitan Borough Council" },
        { "738", "Stockton-on-Tees Borough Council" },
        { "3720", "Stratford-on-Avon District Council" },
        { "1625", "Stroud District Council" },
        { "4525", "Sunderland City Council" },
        { "3640", "Surrey Heath Borough Council" },
        { "5870", "London Borough of Sutton" },
        { "2255", "Swale Borough Council" },
        { "6855", "City and County of Swansea Council" },
        { "3935", "Swindon Borough Council" },
        { "4240", "Tameside Metropolitan Borough Council" },
        { "3445", "Tamworth Borough Council" },
        { "3645", "Tandridge District Council" },
        { "1130", "Teignbridge District Council" },
        { "3240", "Telford and Wrekin Borough Council" },
        { "1560", "Tendring District Council" },
        { "1760", "Test Valley Borough Council" },
        { "1630", "Tewkesbury Borough Council" },
        { "2260", "Thanet District Council" },
        { "1940", "Three Rivers District Council" },
        { "1595", "Thurrock Council" },
        { "2265", "Tonbridge and Malling Borough Council" },
        { "1165", "Torbay Council" },
        { "6945", "Torfaen County Borough Council" },
        { "1145", "Torridge District Council" },
        { "5900", "Tower Hamlets Council" },
        { "4245", "Trafford Metropolitan Borough Council" },
        { "2270", "Tunbridge Wells Borough Council" },
        { "1570", "Uttlesford District Council" },
        { "6950", "Vale of Glamorgan Council" },
        { "3120", "Vale of White Horse District Council" },
        { "4725", "Wakefield Council" },
        { "4630", "Walsall Metropolitan Borough Council" },
        { "5930", "London Borough of Waltham Forest" },
        { "5960", "Wandsworth London Borough Council" },
        { "655", "Warrington Borough Council" },
        { "3725", "Warwick District Council" },
        { "1945", "Watford Borough Council" },
        { "3650", "Waverley Borough Council" },
        { "1435", "Wealden District Council" },
        { "1950", "Welwyn Hatfield Borough Council" },
        { "340", "West Berkshire Council" },
        { "1150", "West Devon Council" },
        { "9057", "West Dunbartonshire Council" },
        { "2365", "West Lancashire District Council" },
        { "2535", "West Lindsey District Council" },
        { "9079", "West Lothian Council" },
        { "2845", "West Northamptonshire Council" },
        { "3125", "West Oxfordshire District Council" },
        { "3545", "West Suffolk District Council" },
        { "9020", "Comhairle nan Eilean Siar" },
        { "935", "Westmorland and Furness Council" },
        { "4250", "Wigan Metropolitan Borough Council" },
        { "3940", "Wiltshire Council" },
        { "1765", "Winchester City Council" },
        { "355", "Windsor and Maidenhead Borough Council" },
        { "4325", "Wirral Council" },
        { "3655", "Woking Borough Council" },
        { "360", "Wokingham Borough Council" },
        { "4635", "Wolverhampton City Council" },
        { "1835", "Worcester City Council" },
        { "1855", "Worcestershire County Council" },
        { "3835", "Worthing Borough Council" },
        { "6955", "Wrexham County Borough Council" },
        { "1840", "Wychavon District Council" },
        { "2370", "Wyre Council" },
        { "1845", "Wyre Forest District Council" },
        { "2741", "City of York Council" },
        { "905", "Allerdale" }, // Legacy LA
        { "910", "Barrow-In-Furness" }, // Legacy LA
        { "915", "Carlisle" }, // Legacy LA
        { "920", "Copeland" }, // Legacy LA
        { "2705", "Craven" }, // Legacy LA
        { "925", "Eden" }, // Legacy LA
        { "2710", "Hambleton" }, // Legacy LA
        { "2715", "Harrogate" }, // Legacy LA
        { "3305", "Mendip" }, // Legacy LA
        { "2720", "Richmondshire" }, // Legacy LA
        { "2725", "Ryedale" }, // Legacy LA
        { "2730", "Scarborough" }, // Legacy LA
        { "3310", "Sedgemoor" }, // Legacy LA
        { "2735", "Selby" }, // Legacy LA
        { "3330", "Somerset West and Taunton" }, // Legacy LA
        { "930", "South Lakeland" }, // Legacy LA
        { "3325", "South Somerset" } // Legacy LA
    };
    
    /// If Custodian Codes change (through LAs merging etc.) we need to ensure consistency with the
    /// HUG2 Public Website data, and we may need to map old codes to new ones for existing users.
    /// <see href="https://github.com/UKGovernmentBEIS/desnz-home-energy-retrofit-beta/blob/develop/HerPublicWebsite.BusinessLogic/Models/LocalAuthorityData.cs"> HUG2 Public Website codebase </see>
    /// The mappings contained here should be consistent with the mapping in the HUG2 Public Website Repo's LocalAuthorityData.cs
    /// <see href="https://github.com/UKGovernmentBEIS/desnz-home-energy-retrofit-beta/blob/develop/HerPublicWebsite.BusinessLogic/Models/LocalAuthorityData.cs"> HUG2 Public Website codebase </see>
    public static readonly Dictionary<string, string> LocalAuthorityConsortiumCodeByCustodianCode = new()
    {
        { "3805", "C_0031" },
        { "1005", "C_0024" },
        { "3810", "C_0031" },
        { "3005", "C_0024" },
        { "2205", "C_0007" },
        { "3505", "C_0038" },
        { "5060", "C_0017" },
        { "5090", "C_0017" },
        { "1705", "C_0031" },
        { "3010", "C_0024" },
        { "114", "C_0003" },
        { "235", "C_0007" },
        { "5120", "C_0017" },
        { "4605", "C_0024" },
        { "2405", "C_0024" },
        { "2372", "C_0002" },
        { "2373", "C_0002" },
        { "2505", "C_0024" },
        { "1260", "C_0015" },
        { "335", "C_0007" },
        { "1510", "C_0007" },
        { "2605", "C_0004" },
        { "5150", "C_0017" },
        { "1515", "C_0007" },
        { "1445", "C_0031" },
        { "116", "C_0003" },
        { "2610", "C_0004" },
        { "1805", "C_0024" },
        { "1905", "C_0007" },
        { "3015", "C_0024" },
        { "440", "C_0007" },
        { "2315", "C_0002" },
        { "505", "C_0006" },
        { "5210", "C_0017" },
        { "3405", "C_0024" },
        { "2210", "C_0007" },
        { "1520", "C_0007" },
        { "2410", "C_0024" },
        { "1525", "C_0007" },
        { "1605", "C_0037" },
        { "3105", "C_0029" },
        { "660", "C_0008" },
        { "665", "C_0008" },
        { "1015", "C_0024" },
        { "3815", "C_0031" },
        { "2320", "C_0002" },
        { "5030", "C_0017" },
        { "5990", "C_0017" },
        { "1530", "C_0007" },
        { "840", "C_0010" },
        { "1610", "C_0037" },
        { "4610", "C_0024" },
        { "3820", "C_0031" },
        { "5240", "C_0031" },
        { "940", "C_0016" },
        { "1910", "C_0007" },
        { "1350", "C_0012" },
        { "2215", "C_0013" },
        { "1055", "C_0024" },
        { "1045", "C_0024" },
        { "1265", "C_0015" },
        { "2220", "C_0013" },
        { "4615", "C_0024" },
        { "5270", "C_0017" },
        { "510", "C_0006" },
        { "1105", "C_0014" },
        { "1710", "C_0031" },
        { "1915", "C_0007" },
        { "2510", "C_0024" },
        { "3410", "C_0024" },
        { "3540", "C_0038" },
        { "1410", "C_0021" },
        { "1715", "C_0031" },
        { "3605", "C_0039" },
        { "5300", "C_0017" },
        { "1535", "C_0007" },
        { "3610", "C_0039" },
        { "1025", "C_0024" },
        { "1110", "C_0014" },
        { "1720", "C_0031" },
        { "515", "C_0006" },
        { "2250", "C_0007" },
        { "1615", "C_0037" },
        { "3020", "C_0024" },
        { "1620", "C_0037" },
        { "1725", "C_0031" },
        { "2230", "C_0007" },
        { "5330", "C_0017" },
        { "3615", "C_0039" },
        { "5360", "C_0017" },
        { "650", "C_0022" },
        { "5390", "C_0017" },
        { "2415", "C_0024" },
        { "1540", "C_0007" },
        { "5450", "C_0017" },
        { "1730", "C_0007" },
        { "724", "C_0012" },
        { "1415", "C_0021" },
        { "1735", "C_0031" },
        { "5480", "C_0007" },
        { "1850", "C_0024" },
        { "1920", "C_0007" },
        { "1030", "C_0024" },
        { "5510", "C_0017" },
        { "2420", "C_0024" },
        { "3825", "C_0031" },
        { "520", "C_0006" },
        { "2330", "C_0002" },
        { "3515", "C_0038" },
        { "2114", "C_0031" },
        { "835", "C_0010" },
        { "5570", "C_0017" },
        { "5600", "C_0017" },
        { "2635", "C_0004" },
        { "5630", "C_0017" },
        { "4305", "C_0022" },
        { "5660", "C_0017" },
        { "2335", "C_0002" },
        { "1425", "C_0021" },
        { "5690", "C_0017" },
        { "3415", "C_0024" },
        { "2515", "C_0024" },
        { "4310", "C_0022" },
        { "5180", "C_0017" },
        { "5420", "C_0017" },
        { "5540", "C_0017" },
        { "2235", "C_0007" },
        { "1545", "C_0007" },
        { "1820", "C_0024" },
        { "3025", "C_0024" },
        { "2280", "C_0007" },
        { "2430", "C_0024" },
        { "5720", "C_0017" },
        { "1135", "C_0014" },
        { "3520", "C_0038" },
        { "3830", "C_0031" },
        { "435", "C_0007" },
        { "3620", "C_0039" },
        { "1740", "C_0031" },
        { "3030", "C_0024" },
        { "3420", "C_0024" },
        { "5750", "C_0017" },
        { "1115", "C_0014" },
        { "2002", "C_0024" },
        { "1925", "C_0007" },
        { "2520", "C_0024" },
        { "2003", "C_0024" },
        { "2620", "C_0004" },
        { "2840", "C_0007" },
        { "121", "C_0003" },
        { "3705", "C_0024" },
        { "2435", "C_0024" },
        { "2745", "C_0027" },
        { "2625", "C_0004" },
        { "3060", "C_0024" },
        { "3710", "C_0024" },
        { "2440", "C_0024" },
        { "3110", "C_0007" },
        { "2340", "C_0002" },
        { "540", "C_0031" },
        { "1775", "C_0031" },
        { "2345", "C_0002" },
        { "345", "C_0007" },
        { "5780", "C_0017" },
        { "728", "C_0012" },
        { "1825", "C_0024" },
        { "3625", "C_0039" },
        { "2350", "C_0002" },
        { "5810", "C_0017" },
        { "1550", "C_0007" },
        { "2355", "C_0002" },
        { "1430", "C_0021" },
        { "3715", "C_0024" },
        { "3630", "C_0039" },
        { "3040", "C_0024" },
        { "1750", "C_0031" },
        { "2470", "C_0031" },
        { "4620", "C_0024" },
        { "4320", "C_0022" },
        { "3245", "C_0024" },
        { "350", "C_0007" },
        { "4625", "C_0024" },
        { "530", "C_0006" },
        { "1040", "C_0024" },
        { "119", "C_0037" },
        { "1125", "C_0044" },
        { "2525", "C_0024" },
        { "2530", "C_0024" },
        { "2630", "C_0004" },
        { "3115", "C_0029" },
        { "2360", "C_0002" },
        { "3430", "C_0024" },
        { "1780", "C_0031" },
        { "1590", "C_0007" },
        { "5840", "C_0017" },
        { "3635", "C_0039" },
        { "1930", "C_0007" },
        { "4315", "C_0022" },
        { "3425", "C_0024" },
        { "3435", "C_0024" },
        { "1935", "C_0007" },
        { "738", "C_0012" },
        { "3720", "C_0024" },
        { "1625", "C_0037" },
        { "3640", "C_0039" },
        { "5870", "C_0007" },
        { "2255", "C_0007" },
        { "3445", "C_0024" },
        { "3645", "C_0039" },
        { "1130", "C_0014" },
        { "3240", "C_0024" },
        { "1560", "C_0007" },
        { "1760", "C_0031" },
        { "1630", "C_0037" },
        { "2260", "C_0007" },
        { "1595", "C_0007" },
        { "2265", "C_0007" },
        { "1165", "C_0014" },
        { "1145", "C_0014" },
        { "5900", "C_0017" },
        { "2270", "C_0007" },
        { "1570", "C_0007" },
        { "3120", "C_0029" },
        { "4630", "C_0024" },
        { "5930", "C_0017" },
        { "5960", "C_0017" },
        { "3725", "C_0024" },
        { "3650", "C_0039" },
        { "1950", "C_0007" },
        { "340", "C_0007" },
        { "1150", "C_0044" },
        { "2365", "C_0002" },
        { "2535", "C_0024" },
        { "2845", "C_0007" },
        { "3125", "C_0029" },
        { "3545", "C_0038" },
        { "935", "C_0016" },
        { "1765", "C_0031" },
        { "355", "C_0007" },
        { "4325", "C_0022" },
        { "3655", "C_0039" },
        { "360", "C_0007" },
        { "4635", "C_0024" },
        { "1835", "C_0024" },
        { "1855", "C_0024" },
        { "3835", "C_0031" },
        { "1840", "C_0024" },
        { "2370", "C_0002" },
        { "1845", "C_0024" },
        { "2705", "C_0027" }, // Legacy LA
        { "2710", "C_0027" }, // Legacy LA
        { "2715", "C_0027" }, // Legacy LA
        { "3305", "C_0033" }, // Legacy LA
        { "2720", "C_0027" }, // Legacy LA
        { "2725", "C_0027" }, // Legacy LA
        { "2730", "C_0027" }, // Legacy LA
        { "3310", "C_0033" }, // Legacy LA
        { "2735", "C_0027" }, // Legacy LA 
        { "3330", "C_0033" }, // Legacy LA 
        { "3325", "C_0033" } // Legacy LA 
    };
}
