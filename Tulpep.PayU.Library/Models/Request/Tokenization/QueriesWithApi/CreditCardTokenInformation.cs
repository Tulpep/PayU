namespace Tulpep.PayU.Library.Models.Request.Tokenization.QueriesWithApi
{
    class CreditCardTokenInformation
    {
        public string payerId { get; set; }
        public string creditCardTokenId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}
