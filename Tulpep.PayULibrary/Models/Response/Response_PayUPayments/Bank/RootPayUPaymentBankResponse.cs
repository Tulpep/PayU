namespace Tulpep.PayULibrary.Models.Response.Response_PayUPayments.Bank
{
    class RootPayUPaymentBankResponse
    {
        //Format: Alphanumeric Size:
        //Description: The overall response code. ERROR, SUCCESS.
        public string code { get; set; }
        //The response’s data.
        public Response_Bank_TransactionResponse transactionResponse { get; set; }
    }
}
