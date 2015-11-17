namespace Tulpep.PayULibrary.Cross
{
    public static class Constants
    {
        #region Infraestructure Strings
        public const string DefaultTestQueriesConnectionUrl = "https://stg.api.payulatam.com/reports-api/4.0/service.cgi";
        public const string DefaultProductionQueriesConnectionUrl = "https://api.payulatam.com/reports-api/4.0/service.cgi";
        public const string TestAPILogin = "11959c415b33d0c";
        public const string TestAPIKey = "6u39nqhq8ftd0hlvnjfs66eh8c";
        public const string TestMerchantId = "500238";
        public const string MerchantId = "509269";
        public const string APIKey = "5ck1kmok44ko09lqnni384ev58";
        public const string APILogin = "6bf6d64e593f136";
        public const string TestAccountId = "500538";
        public const string DefaultProductionPaymentsConnectionUrl = "https://api.payulatam.com/payments-api/4.0/service.cgi";
        public const string DefaultTestPaymentsConnectionUrl = "https://stg.api.payulatam.com/payments-api/4.0/service.cgi";
        public const string AccountId = "510410";
        #endregion

        #region common Status
        //Used to ping all services.
        public const string PING = "PING";
        //Each transaction was approved.
        public const string APPROVED = "APPROVED";
        //There was a general error.
        public const string ERROR = "ERROR";
        // Rejected transaction OR The last transaction of the order was declined.
        public const string DECLINED = "DECLINED";
        #endregion

        #region Response code transaction
        //The transaction was rejected by the anti-fraud system.
        public const string ANTIFRAUD_REJECTED = "ANTIFRAUD_REJECTED";
        //The financial network rejected the transaction.
        public const string PAYMENT_NETWORK_REJECTED = "PAYMENT_NETWORK_REJECTED";
        //The transaction was declined by the bank or financial network because of an error.
        public const string ENTITY_DECLINED = "ENTITY_DECLINED";
        //An error occurred in the system trying to process the payment.
        public const string INTERNAL_PAYMENT_PROVIDER_ERROR = "INTERNAL_PAYMENT_PROVIDER_ERROR";
        //The payment provider was not active.
        public const string INACTIVE_PAYMENT_PROVIDER = "INACTIVE_PAYMENT_PROVIDER";
        //The financial network reported an authentication error.
        public const string DIGITAL_CERTIFICATE_NOT_FOUND = "DIGITAL_CERTIFICATE_NOT_FOUND";
        //The security code or expiration date was invalid.
        public const string INVALID_EXPIRATION_DATE_OR_SECURITY_CODE = "INVALID_EXPIRATION_DATE_OR_SECURITY_CODE";
        //The account had insufficient funds.
        public const string INSUFFICIENT_FUNDS = "INSUFFICIENT_FUNDS";
        //The credit card was not authorized for internet transactions.
        public const string CREDIT_CARD_NOT_AUTHORIZED_FOR_INTERNET_TRANSACTIONS = "CREDIT_CARD_NOT_AUTHORIZED_FOR_INTERNET_TRANSACTIONS";
        //The financial network reported that the transaction was invalid.
        public const string INVALID_TRANSACTION = "INVALID_TRANSACTION";
        //The card is invalid.
        public const string INVALID_CARD = "INVALID_CARD";
        //The card has expired.
        public const string EXPIRED_CARD = "EXPIRED_CARD";
        //The card has a restriction.
        public const string RESTRICTED_CARD = "RESTRICTED_CARD";
        //You should contact the bank.
        public const string REPEAT_TRANSACTION = "REPEAT_TRANSACTION";
        //The financial network reported a communication error with the bank.
        public const string ENTITY_MESSAGING_ERROR = "ENTITY_MESSAGING_ERROR";
        //The bank was not available.
        public const string BANK_UNREACHABLE = "BANK_UNREACHABLE";
        //The transaction exceeds the amount set by the bank.
        public const string EXCEEDED_AMOUNT = "EXCEEDED_AMOUNT";
        //The transaction was not accepted by the bank for some reason.
        public const string NOT_ACCEPTED_TRANSACTION = "NOT_ACCEPTED_TRANSACTION";
        //An error occurred converting the amounts to the payment currency.
        public const string ERROR_CONVERTING_TRANSACTION_AMOUNTS = "ERROR_CONVERTING_TRANSACTION_AMOUNTS";
        //The transaction expired.
        public const string EXPIRED_TRANSACTION = "EXPIRED_TRANSACTION";
        //The transaction was stopped and must be revised, this can occur because of security filters.
        public const string PENDING_TRANSACTION_REVIEW = "PENDING_TRANSACTION_REVIEW";
        //The transaction is subject to confirmation.
        public const string PENDING_TRANSACTION_CONFIRMATION = "PENDING_TRANSACTION_CONFIRMATION";
        //The transaction is subject to be transmitted to the financial network. 
        //This usually applies to transactions with cash payment means.
        public const string PENDING_TRANSACTION_TRANSMISSION = "PENDING_TRANSACTION_TRANSMISSION";
        //The message returned by the financial network is inconsistent.
        public const string PAYMENT_NETWORK_BAD_RESPONSE = "PAYMENT_NETWORK_BAD_RESPONSE";
        //Could not connect to the financial network.
        public const string PAYMENT_NETWORK_NO_CONNECTION = "PAYMENT_NETWORK_NO_CONNECTION";
        //Financial Network did not respond.
        public const string PAYMENT_NETWORK_NO_RESPONSE = "PAYMENT_NETWORK_NO_RESPONSE";
        //Transactions clinic: internal handling code.
        public const string FIX_NOT_REQUIRED = "FIX_NOT_REQUIRED";
        //Transactions clinic: internal handling code. Only applies to Query API.
        public const string AUTOMATICALLY_FIXED_AND_SUCCESS_REVERSAL = "AUTOMATICALLY_FIXED_AND_SUCCESS_REVERSAL";
        //Transactions clinic: internal handling code. Only applies to Query API.
        public const string AUTOMATICALLY_FIXED_AND_UNSUCCESS_REVERSAL = "AUTOMATICALLY_FIXED_AND_UNSUCCESS_REVERSAL";
        //Transactions clinic: internal handling code. Only applies to Query API.
        public const string AUTOMATIC_FIXED_NOT_SUPPORTED = "AUTOMATIC_FIXED_NOT_SUPPORTED";
        //Transactions clinic: internal handling code. Only applies to Query API.
        public const string NOT_FIXED_FOR_ERROR_STATE = "NOT_FIXED_FOR_ERROR_STATE";
        //Transactions clinic: internal handling code. Only applies to Query API.
        public const string ERROR_FIXING_AND_REVERSING = "ERROR_FIXING_AND_REVERSING";
        //Transactions clinic: internal handling code. Only applies to Query API.
        public const string ERROR_FIXING_INCOMPLETE_DATA = "ERROR_FIXING_INCOMPLETE_DATA";
        #endregion

        #region  Command accepted for query api
        //Used to query an order using its identifier.
        public const string ORDER_DETAIL = "ORDER_DETAIL";
        //Used to query an order using its reference code.
        public const string ORDER_DETAIL_BY_REFERENCE_CODE = "ORDER_DETAIL_BY_REFERENCE_CODE";
        //Used to check the response of a transaction.
        public const string TRANSACTION_RESPONSE_DETAIL = "TRANSACTION_RESPONSE_DETAIL";
        #endregion

        #region  Commands accepted by the payment api
        //Used to send transactions of any kind.
        public const string SUBMIT_TRANSACTION = "SUBMIT_TRANSACTION";
        //Used to query the shop’s available payment methods.
        public const string GET_PAYMENT_METHODS = "GET_PAYMENT_METHODS";
        //It is used to obtain the bank list for PSE transactions.
        public const string GET_BANKS_LIST = "GET_BANKS_LIST";
        #endregion

        #region Accepted currencies
        // Argentine Peso
        public const string ARS = "ARS";
        // Brazilian Real
        public const string BRL = "BRL";
        // Chilean Peso
        public const string CLP = "CLP";
        // Colombian Peso
        public const string COP = "COP";
        // Mexican Peso
        public const string MXN = "MXN";
        // US Dollar
        public const string USD = "USD";
        // Peruvian Nuevo Sol
        public const string PEN = "PEN";
        #endregion

        #region Transaction state
        // Expired transaction
        public const string EXPIRED = "EXPIRED";
        // Pending transaction or in validation
        public const string PENDING = "PENDING";
        //   Transaction sent to the financial institution and for some reason processing did not finish.Only applies to query API.
        public const string SUBMITTED = "SUBMITTED";
        #endregion

        #region Order status
        //The order was just created in the system
        public const string NEW = "NEW";
        //The order is being processed.
        public const string IN_PROGRESS = "IN_PROGRESS";
        //  The last transaction of the order was an approved authorization.
        public const string AUTHORIZED = "AUTHORIZED";
        // The last transaction of the order was an approved capture.
        public const string CAPTURED = "CAPTURED";
        // The last transaction of the order was an approved cancellation.
        public const string CANCELLED = "CANCELLED";
        //The last transaction of the order was an approved refund.
        public const string REFUNDED = "REFUNDED";
        #endregion

        #region  Supported languages
        //        Iso code 639	
        //English
        public const string en = "en";
        //Spanish
        public const string es = "es";
        //Portuguese
        public const string pt = "pt";
        #endregion

        #region  Payment method
        //Common
        public const string VISA = "VISA";
        public const string MASTERCARD = "MASTERCARD";
        public const string AMEX = "AMEX";
        public const string DINERS = "DINERS";
        //Argentina
        public const string PAGOFACIL = "PAGOFACIL";
        public const string CABAL = "CABAL";
        public const string NARANJA = "NARANJA";
        public const string SHOPPING = "SHOPPING";
        public const string COBRO_EXPRESS = "COBRO_EXPRESS";
        public const string RAPIPAGO = "RAPIPAGO";
        public const string CENCOSUD = "CENCOSUD";
        public const string ARGENCARD = "ARGENCARD";
        public const string BAPRO = "BAPRO";
        public const string RIPSA = "RIPSA";
        // Brazil
        public const string BOLETO_BANCARIO = "BOLETO_BANCARIO";
        public const string ELO = "ELO";
        public const string HIPERCARD = "HIPERCARD";
        //Chile
        public const string TRANSBANK = "TRANSBANK";
        // Colombia
        public const string BALOTO = "BALOTO";
        public const string BANK_REFERENCED = "BANK_REFERENCED";
        public const string PSE = "PSE";
        public const string EFECTY = "EFECTY";
        // México
        public const string SANTANDER = "SANTANDER";
        public const string BANCOMER = "BANCOMER";
        public const string IXE = "IXE";
        public const string SCOTIABANK = "SCOTIABANK";
        public const string BANAMEX = "BANAMEX";
        public const string OXXO = "OXXO";
        public const string SEVEN_ELEVEN = "SEVEN_ELEVEN";
        // Panama VISA MASTERCARD
        // Peru
        public const string BCP = "BCP";
        #endregion

        #region Countries of payment
        // Brazil
        public const string BR = "BR";
        // Argentina
        public const string AR = "AR";
        //Colombia
        public const string CO = "CO";
        // Mexico
        public const string MX = "BR";
        // Panama
        public const string PA = "PA";
        // Peru
        public const string PE = "PE";
        #endregion

        #region Transaction types
        // Authorization transaction
        public const string AUTHORIZATION = "AUTHORIZATION";
        // Authorization and capture transaction
        public const string AUTHORIZATION_AND_CAPTURE = "AUTHORIZATION_AND_CAPTURE";
        // Capture Transaction
        public const string CAPTURE = "CAPTURE";
        // Cancellation transaction of an authorization
        public const string VOID = "VOID";
        // Refund transaction or cancellation of a capture
        public const string REFUND = "REFUND";
        #endregion
    }
}
