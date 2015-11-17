using System.Collections.Generic;

namespace Tulpep.PayULibrary.Models.Response.Response_Tokenization.QueriesWithApi
{
    public class RootPayUQueriesWithApiResponse
    {
        public string code { get; set; }
        public object error { get; set; }
        public List<Response_QueriesWithApi_CreditCardTokenList> creditCardTokenList { get; set; }

    }
}
