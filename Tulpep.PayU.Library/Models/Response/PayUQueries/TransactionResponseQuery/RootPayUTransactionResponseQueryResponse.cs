namespace Tulpep.PayU.Library.Models.Response.PayUQueries.TransactionResponseQuery
{
    public class RootPayUTransactionResponseQueryResponse
    {
        public string code { get; set; }
        public object error { get; set; }
        public Result result { get; set; }
    }
}
