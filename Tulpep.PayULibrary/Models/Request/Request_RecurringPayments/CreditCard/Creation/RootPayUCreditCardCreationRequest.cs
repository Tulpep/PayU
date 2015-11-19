
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Cross;

namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.CreditCard.Creation
{
    /// <summary>
    /// Url	/rest/v4.3/customers/{customerID}/creditCards Method POST 
    /// Description 	Creating a credit card (Token) and assigning it to a user. 
    /// {customerId} : Identifier of the client with whom you are going to associate the token with.
    /// </summary>
    public class RootPayUCreditCardCreationRequest
    {
        public string name { get; set; }
        public string document { get; set; }
        public string number { get; set; }
        public string expMonth { get; set; }
        public string expYear { get; set; }
        public string type { get; set; }
        public Request_Recurring_Address address { get; set; }
    }
}
