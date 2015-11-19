namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Subscription.Creation.AllNewItems
{
    public class RootPayUSubscriptionCreationAllNewRequest
    {
        public string quantity { get; set; }
        public string installments { get; set; }
        public string trialDays { get; set; }
        public Request_Subscription_Creation_AllNewItems_Customer customer { get; set; }
        public Request_Subscription_Creation_AllNewItems_Plan plan { get; set; }
    }
}
