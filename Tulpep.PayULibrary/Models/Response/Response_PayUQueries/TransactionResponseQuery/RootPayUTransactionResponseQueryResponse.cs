namespace Tulpep.PayULibrary.Models.Response.Response_PayUQueries.TransactionResponseQuery
{
    public class RootPayUTransactionResponseQueryResponse
    {
        public string code { get; set; }
        public object error { get; set; }
        public Response_TransactionResponseQuery_Result result { get; set; }
    }
}
