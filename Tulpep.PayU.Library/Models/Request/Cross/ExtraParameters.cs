namespace Tulpep.PayU.Library.Models.Request.Cross
{
    //Additional parameters or data associated with a transaction.
    //These parameters may vary according to the payment means or shop’s preferences.
    public class ExtraParameters
    {
        //The parameter’s name.Example: ”INSTALLMENTS_NUMBER”, “RESPONSE_URL”, “PSE_REFERENCE1", etc.
        //See the use of this variable in the examples by country.
        public int INSTALLMENTS_NUMBER { get; set; }
        public string RESPONSE_URL { get; set; }
        public string PSE_REFERENCE1 { get; set; }
        public string FINANCIAL_INSTITUTION_CODE { get; set; }
        public string USER_TYPE { get; set; }
        public string PSE_REFERENCE2 { get; set; }
        public string PSE_REFERENCE3 { get; set; }
    }
}
