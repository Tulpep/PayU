namespace Tulpep.PayU.Library.Models.Request.PayUPayments.CreditCard
{
    //Additional parameters or data associated with a transaction.
    //These parameters may vary according to the payment means or shop’s preferences.
    public class ExtraParameters
    {
        //The parameter’s name.Example: ”INSTALLMENTS_NUMBER”, “RESPONSE_URL”, “PSE_REFERENCE1", etc.
        //See the use of this variable in the examples by country.
        public int INSTALLMENTS_NUMBER { get; set; }
    }
}
