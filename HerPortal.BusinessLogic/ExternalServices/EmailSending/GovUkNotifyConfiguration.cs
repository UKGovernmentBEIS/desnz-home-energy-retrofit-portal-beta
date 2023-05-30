﻿namespace HerPortal.ExternalServices.EmailSending
{
    public class GovUkNotifyConfiguration
    {
        public const string ConfigSection = "GovUkNotify";
        
        public string ApiKey { get; set; }
        public string BaseUrl { get; set; }
        public ApplicationReferenceNumberConfiguration ApplicationReferenceNumberTemplate { get; set; }
        public RequestDocumentConfiguration RequestDocumentTemplate { get; set; }
        public ReferralReminderConfiguration ReferralReminderTemplate { get; set; }
    }
    
    public class ApplicationReferenceNumberConfiguration
    {
        public string Id { get; set; }
        public string ReferencePlaceholder { get; set; }
        public string MagicLinkPlaceholder { get; set; }
        public string ReturningUserLinkPlaceholder { get; set; }
        public string FeedbackLinkPlaceholder { get; set; }
    }

    public class RequestDocumentConfiguration
    {
        public string Id { get; set; }
        public string DocumentContentsPlaceholder { get; set; }
    }

    public class ReferralReminderConfiguration
    {
        public string Id { get; set; }
        public string LocalAuthoritiesPlaceholder { get; set; }
    }
}
