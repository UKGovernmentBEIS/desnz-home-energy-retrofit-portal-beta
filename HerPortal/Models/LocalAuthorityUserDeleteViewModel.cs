using HerPortal.BusinessLogic.Models;

namespace HerPortal.Models;

public class LocalAuthorityUserDeleteViewModel
{
    public User User;
    
    public LocalAuthorityUserDeleteViewModel(User user)
    {
        User = user;
    }
}
