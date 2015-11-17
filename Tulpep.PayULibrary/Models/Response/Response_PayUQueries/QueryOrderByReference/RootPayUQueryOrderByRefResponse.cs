namespace Tulpep.PayULibrary.Models.Response.Response_PayUQueries.QueryOrderByReference
{
    public class RootPayUQueryOrderByRefResponse
    {
        public string code { get; set; }
        public string error { get; set; }
        public Response_QueryOrderByReference_Result result { get; set; }
    }
}
