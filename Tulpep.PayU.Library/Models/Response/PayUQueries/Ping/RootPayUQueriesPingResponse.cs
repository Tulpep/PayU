namespace Tulpep.PayU.Library.Models.Response.PayUQueries.Ping
{
    public class RootPayUQueriesPingResponse
    {
        public string code { get; set; }
        public string error { get; set; }
        public object transactionResponse { get; set; }
    }
}
