namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Subscription.Creation.NewPlan
{
    public class RootPayUSubscriptionCreationNewPlanRequest
    {
        public string installments { get; set; }
        public string trialDays { get; set; }
        public Request_Subscription_Creation_NewPlan_Customer customer { get; set; }
        public Request_Subscription_Creation_NewPlan_Plan plan { get; set; }
    }
}
