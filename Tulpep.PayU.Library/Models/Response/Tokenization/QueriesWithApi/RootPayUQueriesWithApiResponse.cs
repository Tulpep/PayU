using System.Collections.Generic;

namespace Tulpep.PayU.Library.Models.Response.Tokenization.QueriesWithApi
{
    public class RootPayUQueriesWithApiResponse
    {
        public string code { get; set; }
        public object error { get; set; }
        public List<CreditCardTokenList> creditCardTokenList { get; set; }

    }
}
