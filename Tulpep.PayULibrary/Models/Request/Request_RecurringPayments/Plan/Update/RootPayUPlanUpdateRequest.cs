using System.Collections.Generic;

namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Plan.Update
{
    public class RootPayUPlanUpdateRequest
    {
        public string planCode { get; set; }
        public string description { get; set; }
        public string paymentAttemptsDelay { get; set; }
        public string maxPendingPayments { get; set; }
        public string maxPaymentAttempts { get; set; }
        public List<Request_Plan_Update_AdditionalValue> additionalValues { get; set; }
    }
}
