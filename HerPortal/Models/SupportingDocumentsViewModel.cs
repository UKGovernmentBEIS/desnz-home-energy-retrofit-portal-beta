using HerPortal.BusinessLogic.Models.Enums;

namespace HerPortal.Models;

public class SupportingDocumentsViewModel
{
    public UserRole UserRole { get; }
    
    public SupportingDocumentsViewModel(UserRole userRole)
    {
        UserRole = userRole;
    }
}
