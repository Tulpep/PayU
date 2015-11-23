using System.Collections.Generic;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Cross;

namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.AdditionalCharges.Query.ByIdOfExtraCharge
{
    public class RootPayUAdditionalChargesQueryByIdResponse
    {
        public string id { get; set; }
        public string description { get; set; }
        public List<Response_Recurring_AdditionalValue> additionalValues { get; set; }
        public string subscriptionId { get; set; }
    }
}
