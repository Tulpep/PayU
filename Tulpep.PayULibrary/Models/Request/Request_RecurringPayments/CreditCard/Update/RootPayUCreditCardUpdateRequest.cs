
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Cross;

namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.CreditCard.Update
{
    /// <summary>
    /// Url	/rest/v4.3/creditCards/{creditCardId} Method PUT 
    /// Description Update a token’s information. {creditCardId} : Identifier of the token to be updated.
    /// </summary>
    public class RootPayUCreditCardUpdateRequest
    {
        public string expMonth { get; set; }
        public string expYear { get; set; }
        public string name { get; set; }
        public string document { get; set; }
        public Request_Recurring_Address address { get; set; }
    }
}
