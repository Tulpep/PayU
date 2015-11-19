using System.Collections.Generic;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Cross;

namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.AdditionalCharges.Creation
{
    /// <summary>
    /// Url	rest/v4.3/subscriptions/{subscriptionId}/recurringBillItems Method POST 
    /// Description Adds extra charges to the respective invoice for the current period.{subscriptionId} : 
    /// Identification of the subscription
    /// </summary>
    class RootPayUAdditionalChargesCreationRequest
    {
        public string description { get; set; }
        public List<Request_Recurring_AdditionalValue> additionalValues { get; set; }
    }
}
