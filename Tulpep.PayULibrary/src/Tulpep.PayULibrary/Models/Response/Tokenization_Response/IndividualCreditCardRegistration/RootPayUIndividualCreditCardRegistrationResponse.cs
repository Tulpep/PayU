namespace Tulpep.PayULibrary.Models.Response.Tokenization_Response.IndividualCreditCardRegistration
{
    public class RootPayUIndividualCreditCardRegistrationResponse
    {
        public string code { get; set; }
        public object error { get; set; }
        public CreditCardToken creditCardToken { get; set; }
    }
}
