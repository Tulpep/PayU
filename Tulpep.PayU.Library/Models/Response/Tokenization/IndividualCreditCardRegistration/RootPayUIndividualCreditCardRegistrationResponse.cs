namespace Tulpep.PayU.Library.Models.Response.Tokenization.IndividualCreditCardRegistration
{
    public class RootPayUIndividualCreditCardRegistrationResponse
    {
        public string code { get; set; }
        public object error { get; set; }
        public CreditCardToken creditCardToken { get; set; }
    }
}
