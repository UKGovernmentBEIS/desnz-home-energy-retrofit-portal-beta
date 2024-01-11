namespace HerPortal.BusinessLogic.Models;

public enum LocalAuthorityStatus
{
    NotTakingPart = 0,
    Pending = 1,
    Live = 2
}

public class LocalAuthority
{
    public int Id { get; set; }
    public string CustodianCode { get; set; }
    
    public LocalAuthorityStatus Status { get; set; }
    
    public List<User> Users { get; set; }
}
