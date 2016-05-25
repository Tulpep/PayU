using System.Collections.Generic;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Cross;

namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Plan.Creation
{
    /// <summary>
    /// Url	/rest/v4.3/plans Method	POST Description Creating a new plan for subscriptions associated with the merchant.
    /// </summary>
    public class RootPayUPlanCreationRequest
    {
        public string accountId { get; set; }
        public string planCode { get; set; }
        public string description { get; set; }
        public string interval { get; set; }
        public string intervalCount { get; set; }
        public string maxPaymentsAllowed { get; set; }
        public string paymentAttemptsDelay { get; set; }
        public List<Request_Recurring_AdditionalValue> additionalValues { get; set; }
    }
}
