using HerPortal.BusinessLogic.Models.Enums;

namespace HerPortal.BusinessLogic.Models;
public class LocalAuthority
{
    public int Id { get; set; }
    public string CustodianCode { get; set; }
    
    public string Name { get; set; }
    
    public LocalAuthorityStatus Status { get; set; }
    
    public List<User> Users { get; set; }
}
