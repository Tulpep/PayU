using System.Collections.Generic;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Cross;

namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Customer.Query
{
    public class Request_Customer_Query_Plan
    {
        public string id { get; set; }
        public string planCode { get; set; }
        public string description { get; set; }
        public string accountId { get; set; }
        public string intervalCount { get; set; }
        public string interval { get; set; }
        public List<Response_Recurring_AdditionalValue> additionalValues { get; set; }
    }
}
