namespace Tulpep.PayULibrary.Models.Response.Tokenization_Response.IndividualCreditCardRegistration
{
    public class CreditCardToken
    {
        public string creditCardTokenId { get; set; }
        public string name { get; set; }
        public string payerId { get; set; }
        public string identificationNumber { get; set; }
        public string paymentMethod { get; set; }
        public string number { get; set; }
        public string expirationDate { get; set; }
        public string creationDate { get; set; }
        public string maskedNumber { get; set; }
        public string errorDescription { get; set; }
    }
}
