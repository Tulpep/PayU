using System.Collections.Generic;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Cross;

namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Plan.Query
{
    public class RootPayUPlanQueryResponse
    {
        public string id { get; set; }
        public string planCode { get; set; }
        public string description { get; set; }
        public int accountId { get; set; }
        public int intervalCount { get; set; }
        public string interval { get; set; }
        public int maxPaymentsAllowed { get; set; }
        public int maxPaymentAttempts { get; set; }
        public int paymentAttemptsDelay { get; set; }
        public int maxPendingPayments { get; set; }
        public int trialDays { get; set; }
        public List<Response_Recurring_AdditionalValue> additionalValues { get; set; }
    }
}
