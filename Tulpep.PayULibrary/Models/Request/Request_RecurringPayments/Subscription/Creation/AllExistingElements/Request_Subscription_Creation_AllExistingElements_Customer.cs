using System.Collections.Generic;

namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Subscription.Creation.AllExistingElements
{
    public class Request_Subscription_Creation_AllExistingElements_Customer
    {
        public string id { get; set; }
        public List<Request_Subscription_Creation_AllExistingElements_CreditCard> creditCards { get; set; }
    }
}
