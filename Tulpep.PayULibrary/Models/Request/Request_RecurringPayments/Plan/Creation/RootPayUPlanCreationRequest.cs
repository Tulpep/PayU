using System.Collections.Generic;

namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Plan.Creation
{
    public class RootPayUPlanCreationRequest
    {
        public string accountId { get; set; }
        public string planCode { get; set; }
        public string description { get; set; }
        public string interval { get; set; }
        public string intervalCount { get; set; }
        public string maxPaymentsAllowed { get; set; }
        public string paymentAttemptsDelay { get; set; }
        public List<Request_Plan_Creation_AdditionalValue> additionalValues { get; set; }
    }
}
