using HerPortal.BusinessLogic.Models.Enums;

namespace HerPortal.Models.Components;

public class NavTabsViewModel
{
    public enum Tab
    {
        LocalAuthorities,
        Consortiums,
        ReferralFiles,
        SupportingDocuments
    }

    public Tab SelectedTab { get; }
    
    public UserRole Role { get; }

    public string GetClass(Tab compareTab) => SelectedTab == compareTab
        ? "app-primary-navigation__item app-primary-navigation__item--current"
        : "app-primary-navigation__item";

    public string GetAriaCurrent(Tab compareTab) => SelectedTab == compareTab
        ? "page"
        : "false";

    public NavTabsViewModel(Tab selectedTab, UserRole viewRole)
    {
        SelectedTab = selectedTab;
        Role = viewRole;
    }
}
