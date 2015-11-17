namespace Tulpep.PayULibrary.Models.Response.Response_PayUQueries.Ping
{
    public class RootPayUQueriesPingResponse
    {
        public string code { get; set; }
        public string error { get; set; }
        public object transactionResponse { get; set; }
    }
}
