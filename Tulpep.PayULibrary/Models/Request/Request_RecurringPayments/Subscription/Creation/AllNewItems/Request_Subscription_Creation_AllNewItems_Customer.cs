using System.Collections.Generic;

namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Subscription.Creation.AllNewItems
{
    public class Request_Subscription_Creation_AllNewItems_Customer
    {
        public string fullName { get; set; }
        public string email { get; set; }
        public List<Request_Subscription_Creation_AllNewItems_CreditCard> creditCards { get; set; }
    }
}
