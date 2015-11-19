using System.Collections.Generic;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Cross;

namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Subscription.Creation.AllNewItems
{
    public class Request_Subscription_Creation_AllNewItems_Plan
    {
        public string planCode { get; set; }
        public string description { get; set; }
        public string accountId { get; set; }
        public string intervalCount { get; set; }
        public string interval { get; set; }
        public string maxPaymentsAllowed { get; set; }
        public string maxPaymentAttempts { get; set; }
        public string paymentAttemptsDelay { get; set; }
        public string maxPendingPayments { get; set; }
        public string trialDays { get; set; }
        public List<Request_Recurring_AdditionalValue> additionalValues { get; set; }
    }
}
