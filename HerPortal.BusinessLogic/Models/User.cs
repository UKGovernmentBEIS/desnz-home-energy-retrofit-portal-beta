using HerPortal.BusinessLogic.Models.Enums;

namespace HerPortal.BusinessLogic.Models;

public class User
{
    public int Id { get; set; }
    public string EmailAddress { get; set; }
    public bool HasLoggedIn { get; set; }
    
    public bool Enabled { get; set; }
    
    public UserRole Role { get; set; }
    
    public List<LocalAuthority> LocalAuthorities { get; set; }
}
