namespace Tulpep.PayULibrary.Models.Response.PayUQueries_Response.Ping
{
    public class RootPayUQueriesPingResponse
    {
        public string code { get; set; }
        public string error { get; set; }
        public object transactionResponse { get; set; }
    }
}
