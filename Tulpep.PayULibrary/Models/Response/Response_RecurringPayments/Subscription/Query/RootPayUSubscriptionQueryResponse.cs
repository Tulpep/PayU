namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.Query
{
    public class RootPayUSubscriptionQueryResponse
    {
        public string id { get; set; }
        public Response_Subscription_Query_Plan plan { get; set; }
        public Response_Subscription_Query_Customer customer { get; set; }
        public string trialDays { get; set; }
        public string quantity { get; set; }
        public string installments { get; set; }
        public long currentPeriodStart { get; set; }
        public long currentPeriodEnd { get; set; }
        public string creditCardToken { get; set; }
    }
}
