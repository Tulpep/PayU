namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Subscription.Creation.NewCard
{
    public class RootPayUSubscriptionCreationNewCardRequest
    {
        public string quantity { get; set; }
        public string installments { get; set; }
        public string trialDays { get; set; }
        public Request_Subscription_Creation_NewCard_Customer customer { get; set; }
        public Request_Subscription_Creation_NewCard_Plan plan { get; set; }
    }
}
