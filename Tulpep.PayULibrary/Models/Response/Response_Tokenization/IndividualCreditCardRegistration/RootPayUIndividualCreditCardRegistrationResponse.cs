namespace Tulpep.PayULibrary.Models.Response.Response_Tokenization.IndividualCreditCardRegistration
{
    public class RootPayUIndividualCreditCardRegistrationResponse
    {
        public string code { get; set; }
        public object error { get; set; }
        public Response_IndividualCreditCardRegistration_CreditCardToken creditCardToken { get; set; }
    }
}
