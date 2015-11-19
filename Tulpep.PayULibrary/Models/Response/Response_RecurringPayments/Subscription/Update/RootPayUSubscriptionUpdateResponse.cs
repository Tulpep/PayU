namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.Update
{
    public class RootPayUSubscriptionUpdateResponse
    {
        public string id { get; set; }
        public Response_Subscription_Update_Plan plan { get; set; }
        public Response_Subscription_Update_Customer customer { get; set; }
        public string trialDays { get; set; }
        public string quantity { get; set; }
        public string installments { get; set; }
        public long currentPeriodStart { get; set; }
        public long currentPeriodEnd { get; set; }
        public string creditCardToken { get; set; }
    }
}
