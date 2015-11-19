namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.Creation.NewCard
{
    public class RootPayUSubscriptionCreationNewCardResponse
    {
        public string id { get; set; }
        public Response_Subscription_Creation_NewCard_Plan plan { get; set; }
        public Response_Subscription_Creation_NewCard_Customer customer { get; set; }
        public string quantity { get; set; }
        public string installments { get; set; }
        public long currentPeriodStart { get; set; }
        public long currentPeriodEnd { get; set; }
    }
}
