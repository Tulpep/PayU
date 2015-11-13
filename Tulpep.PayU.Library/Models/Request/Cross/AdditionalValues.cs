namespace Tulpep.PayU.Library.Models.Request.Cross
{
    //Type:  Size: 
    //Description: Values or amounts associated with the order. In this field one amount per entry is sent.
    public class AdditionalValues
    {
        //Contains a particular amount.

        // Format: Alphanumeric	Size: 64	
        // Description: The type of amount: TX_VALUE, TX_TAX, TX_TAX_RETURN_BASE.
        public TXVALUE TX_VALUE { get; set; }
        public TXTAX TX_TAX { get; set; }
        public TXTAXRETURNBASE TX_TAX_RETURN_BASE { get; set; }
    }
}
