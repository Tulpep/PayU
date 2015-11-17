using Newtonsoft.Json;

namespace Tulpep.PayULibrary.Models.Request.Request_Cross
{
    //Type:  Size: 
    //Description: Values or amounts associated with the order. In this field one amount per entry is sent.
    public class Request_AdditionalValues
    {
        //Contains a particular amount.

        // Format: Alphanumeric	Size: 64	
        // Description: The type of amount: TX_VALUE, TX_TAX, TX_TAX_RETURN_BASE.
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TXVALUE TX_VALUE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TXTAX TX_TAX { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TXTAXRETURNBASE TX_TAX_RETURN_BASE { get; set; }
    }
}
