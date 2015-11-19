using System.Collections.Generic;

namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.Creation.AllExistingElements
{
    public class Response_Subscription_Creation_AllExistingElements_Customer
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public List<Response_Subscription_Creation_AllExistingElements_CreditCard> creditCards { get; set; }
    }
}
