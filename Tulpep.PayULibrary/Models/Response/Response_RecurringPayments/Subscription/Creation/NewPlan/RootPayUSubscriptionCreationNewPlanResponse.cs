namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.Creation.NewPlan
{
    public class RootPayUSubscriptionCreationNewPlanResponse
    {
        public string id { get; set; }
        public Response_Subscription_Creation_NewPlan_Plan plan { get; set; }
        public Response_Subscription_Creation_NewPlan_Customer customer { get; set; }
        public string quantity { get; set; }
        public string installments { get; set; }
        public double currentPeriodStart { get; set; }
        public double currentPeriodEnd { get; set; }
    }
}
