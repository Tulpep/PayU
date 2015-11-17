namespace Tulpep.PayULibrary.Models.Request.Request_Tokenization.QueriesWithApi
{
    public class Request_QueriesWithApi_CreditCardTokenInformation
    {
        public string payerId { get; set; }
        public string creditCardTokenId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}
