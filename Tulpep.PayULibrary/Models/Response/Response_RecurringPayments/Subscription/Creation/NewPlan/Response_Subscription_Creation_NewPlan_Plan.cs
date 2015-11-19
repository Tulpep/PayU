using System.Collections.Generic;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Cross;

namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.Creation.NewPlan
{
    public class Response_Subscription_Creation_NewPlan_Plan
    {
        public string id { get; set; }
        public string planCode { get; set; }
        public string description { get; set; }
        public string accountId { get; set; }
        public int intervalCount { get; set; }
        public string interval { get; set; }
        public List<Response_Recurring_AdditionalValue> additionalValues { get; set; }
    }
}
