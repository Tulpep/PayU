namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Subscription.Creation.AllExistingElements
{
    public class RootPayUSubscriptionCreationAllExistingElementsRequest
    {
        public string quantity { get; set; }
        public string installments { get; set; }
        public string trialDays { get; set; }
        public Request_Subscription_Creation_AllExistingElements_Customer customer { get; set; }
        public Request_Subscription_Creation_AllExistingElements_Plan plan { get; set; }
    }
}
