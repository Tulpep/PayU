namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.Creation.AllExistingElements
{
    public class RootPayUSubscriptionCreationAllExistingElementsResponse
    {
        public string id { get; set; }
        public Response_Subscription_Creation_AllExistingElements_Plan plan { get; set; }
        public Response_Subscription_Creation_AllExistingElements_Customer customer { get; set; }
        public string quantity { get; set; }
        public string installments { get; set; }
        public double currentPeriodStart { get; set; }
        public double currentPeriodEnd { get; set; }
    }
}
