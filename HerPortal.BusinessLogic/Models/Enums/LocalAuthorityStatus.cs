using GovUkDesignSystem.Attributes;

namespace HerPortal.BusinessLogic.Models.Enums;

public enum LocalAuthorityStatus
{
    [GovUkRadioCheckboxLabelText(Text = "Not Taking Part")]
    NotTakingPart = 0,
    Pending = 1,
    Live = 2
}