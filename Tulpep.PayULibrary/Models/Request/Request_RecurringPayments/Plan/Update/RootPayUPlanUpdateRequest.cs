using System.Collections.Generic;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Cross;

namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Plan.Update
{
    /// <summary>
    /// Url	/rest/v4.3/plans/{planCode} Method PUT Description 
    /// Update information about a plan for subscriptions.{planCode} : 
    /// Plan’s identification code for the merchant.
    /// </summary>
    public class RootPayUPlanUpdateRequest
    {
        public string planCode { get; set; }
        public string description { get; set; }
        public string paymentAttemptsDelay { get; set; }
        public string maxPendingPayments { get; set; }
        public string maxPaymentAttempts { get; set; }
        public List<Request_Recurring_AdditionalValue> additionalValues { get; set; }
    }
}
