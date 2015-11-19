using System.Collections.Generic;

namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Customer.Query
{
    public class RootPayUCustomerQueryResponse
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public List<Request_Customer_Query_CreditCard> creditCards { get; set; }
        public List<Request_Customer_Query_Subscription> subscriptions { get; set; }
    }
}
