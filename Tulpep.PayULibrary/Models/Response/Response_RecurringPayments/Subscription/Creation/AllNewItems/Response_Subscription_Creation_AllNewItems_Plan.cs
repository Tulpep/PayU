using System.Collections.Generic;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Cross;

namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.Creation.AllNewItems
{
    public class Response_Subscription_Creation_AllNewItems_Plan
    {
        public string id { get; set; }
        public string planCode { get; set; }
        public string description { get; set; }
        public int accountId { get; set; }
        public int intervalCount { get; set; }
        public string interval { get; set; }
        public List<Response_Recurring_AdditionalValue> additionalValues { get; set; }
    }
}
