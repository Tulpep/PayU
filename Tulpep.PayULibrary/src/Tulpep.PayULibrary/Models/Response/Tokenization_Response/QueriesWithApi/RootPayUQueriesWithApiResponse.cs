using System.Collections.Generic;

namespace Tulpep.PayULibrary.Models.Response.Tokenization_Response.QueriesWithApi
{
    public class RootPayUQueriesWithApiResponse
    {
        public string code { get; set; }
        public object error { get; set; }
        public List<CreditCardTokenList> creditCardTokenList { get; set; }

    }
}
