using System.ComponentModel;

namespace Tulpep.PayULibrary.Cross
{
    public static class PayU_Constants
    {
        #region Infraestructure Strings
        public const string DefaultTestQueriesConnectionUrl = "https://stg.api.payulatam.com/reports-api/4.0/service.cgi";
        public const string DefaultProductionQueriesConnectionUrl = "https://api.payulatam.com/reports-api/4.0/service.cgi";
        public const string DefaultProductionPaymentsConnectionUrl = "https://api.payulatam.com/payments-api/4.0/service.cgi";
        public const string DefaultTestPaymentsConnectionUrl = "https://stg.api.payulatam.com/payments-api/4.0/service.cgi";
        public const string DefaultProductionRecurringPaymentsConnectionUrl = "https://api.payulatam.com/payments-api/rest/v4.3";
        public const string DefaultTestRecurringPaymentsConnectionUrl = "https://stg.api.payulatam.com/payments-api/rest/v4.3";
        /// <summary>
        /// POST use DefaultTestRecurringPaymentsConnectionUrl OR DefaultProductionRecurringPaymentsConnectionUrl + DefaultPlanRecurringPaymentsUrl
        /// GET, PUT, DELETE  use DefaultTestRecurringPaymentsConnectionUrl OR DefaultProductionRecurringPaymentsConnectionUrl + DefaultPlanRecurringPaymentsUrl + {planCode}
        /// </summary>
        public const string DefaultPlanRecurringPaymentsUrl = "/plans/";
        /// <summary>
        /// POST use DefaultTestRecurringPaymentsConnectionUrl OR DefaultProductionRecurringPaymentsConnectionUrl + DefaultCustomerRecurringPaymentsUrl
        /// GET, PUT, DELETE  use DefaultTestRecurringPaymentsConnectionUrl OR DefaultProductionRecurringPaymentsConnectionUrl + DefaultCustomerRecurringPaymentsUrl + {customerId}
        /// </summary>
        public const string DefaultCustomerRecurringPaymentsUrl = "/customers/";
        /// <summary>
        /// POST use DefaultTestRecurringPaymentsConnectionUrl OR DefaultProductionRecurringPaymentsConnectionUrl + DefaultCustomerRecurringPaymentsUrl + {customerID} + DefaultCreditCardRecurringPaymentsUrl
        /// GET, PUT use DefaultTestRecurringPaymentsConnectionUrl OR DefaultProductionRecurringPaymentsConnectionUrl + DefaultCustomerRecurringPaymentsUrl
        /// DELETE  use DefaultTestRecurringPaymentsConnectionUrl OR DefaultProductionRecurringPaymentsConnectionUrl + DefaultCustomerRecurringPaymentsUrl + {customerID} + DefaultCreditCardRecurringPaymentsUrl + {creditCardId}
        /// </summary>
        public const string DefaultCreditCardRecurringPaymentsUrl = "/creditCards/";
        /// <summary>
        /// POST use DefaultTestRecurringPaymentsConnectionUrl OR DefaultProductionRecurringPaymentsConnectionUrl + DefaultSubscriptionRecurringPaymentsUrl
        /// GET, PUT, DELETE  use DefaultTestRecurringPaymentsConnectionUrl OR DefaultProductionRecurringPaymentsConnectionUrl + DefaultSubscriptionRecurringPaymentsUrl + {subscriptionId}
        /// </summary>
        public const string DefaultSubscriptionRecurringPaymentsUrl = "/subscriptions/";
        /// <summary>
        /// POST use DefaultTestRecurringPaymentsConnectionUrl OR DefaultProductionRecurringPaymentsConnectionUrl + DefaultSubscriptionRecurringPaymentsUrl + {subscriptionId} + DefaultAdditionalChargesRecurringPaymentsUrl
        /// GET, PUT, DELETE  use DefaultTestRecurringPaymentsConnectionUrl OR DefaultProductionRecurringPaymentsConnectionUrl + DefaultAdditionalChargesRecurringPaymentsUrl + {recurringBillItemId}
        /// GET  use DefaultTestRecurringPaymentsConnectionUrl OR DefaultProductionRecurringPaymentsConnectionUrl + DefaultAdditionalChargesRecurringPaymentsUrl
        /// </summary>
        public const string DefaultAdditionalChargesRecurringPaymentsUrl = "/recurringBillItems/";
        public const string DefaultAdditionalChargesRecurringPaymentsDescriptionParam = "?description=";
        public const string DefaultAdditionalChargesRecurringPaymentsSubscriptionParam = "?subscriptionId=";
        public const string TestAPILogin = "11959c415b33d0c";
        public const string TestAPIKey = "6u39nqhq8ftd0hlvnjfs66eh8c";
        public const string TestMerchantId = "500238";
        public const string MerchantId = "509269";
        public const string APIKey = "5ck1kmok44ko09lqnni384ev58";
        public const string APILogin = "6bf6d64e593f136";
        public const string TestAccountId = "500538";
        public const string AccountId = "510410";
        #endregion

        #region common Status
        ///<summary>
        ///Each query has proccessed successful.
        ///</summary>
        public const string STATUS_SUCCESS = "SUCCESS";
        ///<summary>
        ///Used to ping all services.
        ///</summary>
        public const string METHOD_PING = "PING";
        ///<summary>
        ///Each transaction was approved.
        ///</summary>
        public const string STATUS_APPROVED = "APPROVED";
        ///<summary>
        ///There was a general error.
        ///</summary>
        public const string STATUS_ERROR = "ERROR";
        ///<summary>
        /// Rejected transaction OR The last transaction of the order was declined.
        ///</summary>
        public const string STATUS_DECLINED = "DECLINED";
        #endregion

        #region Response code transaction
        ///<summary>
        ///The transaction was rejected by the anti-fraud system.
        ///</summary>
        public const string RRESPONSE_CODE_ANTIFRAUD_REJECTED = "ANTIFRAUD_REJECTED";
        ///<summary>
        ///The financial network rejected the transaction.
        ///</summary>
        public const string RRESPONSE_CODE_PAYMENT_NETWORK_REJECTED = "PAYMENT_NETWORK_REJECTED";
        ///<summary>
        ///The transaction was declined by the bank or financial network because of an error.
        ///</summary>
        public const string RRESPONSE_CODE_ENTITY_DECLINED = "ENTITY_DECLINED";
        ///<summary>
        ///An error occurred in the system trying to process the payment.
        ///</summary>
        public const string RRESPONSE_CODE_INTERNAL_PAYMENT_PROVIDER_ERROR = "INTERNAL_PAYMENT_PROVIDER_ERROR";
        ///<summary>
        ///The payment provider was not active.
        ///</summary>
        public const string RRESPONSE_CODE_INACTIVE_PAYMENT_PROVIDER = "INACTIVE_PAYMENT_PROVIDER";
        ///<summary>
        ///The financial network reported an authentication error.
        ///</summary>
        public const string RRESPONSE_CODE_DIGITAL_CERTIFICATE_NOT_FOUND = "DIGITAL_CERTIFICATE_NOT_FOUND";
        ///<summary>
        ///The security code or expiration date was invalid.
        ///</summary>
        public const string RRESPONSE_CODE_INVALID_EXPIRATION_DATE_OR_SECURITY_CODE = "INVALID_EXPIRATION_DATE_OR_SECURITY_CODE";
        ///<summary>
        ///The account had insufficient funds.
        ///</summary>
        public const string RRESPONSE_CODE_INSUFFICIENT_FUNDS = "INSUFFICIENT_FUNDS";
        ///<summary>
        ///The credit card was not authorized for internet transactions.
        ///</summary>
        public const string RRESPONSE_CODE_CREDIT_CARD_NOT_AUTHORIZED_FOR_INTERNET_TRANSACTIONS = "CREDIT_CARD_NOT_AUTHORIZED_FOR_INTERNET_TRANSACTIONS";
        ///<summary>
        ///The financial network reported that the transaction was invalid.
        ///</summary>
        public const string RRESPONSE_CODE_INVALID_TRANSACTION = "INVALID_TRANSACTION";
        ///<summary>
        ///The card is invalid.
        ///</summary>
        public const string RRESPONSE_CODE_INVALID_CARD = "INVALID_CARD";
        ///<summary>
        ///The card has expired.
        ///</summary>
        public const string RRESPONSE_CODE_EXPIRED_CARD = "EXPIRED_CARD";
        ///<summary>
        ///The card has a restriction.
        ///</summary>
        public const string RRESPONSE_CODE_RESTRICTED_CARD = "RESTRICTED_CARD";
        ///<summary>
        ///You should contact the bank.
        ///</summary>
        public const string RRESPONSE_CODE_REPEAT_TRANSACTION = "REPEAT_TRANSACTION";
        ///<summary>
        ///The financial network reported a communication error with the bank.
        ///</summary>
        public const string RRESPONSE_CODE_ENTITY_MESSAGING_ERROR = "ENTITY_MESSAGING_ERROR";
        ///<summary>
        ///The bank was not available.
        ///</summary>
        public const string RRESPONSE_CODE_BANK_UNREACHABLE = "BANK_UNREACHABLE";
        ///<summary>
        ///The transaction exceeds the amount set by the bank.
        ///</summary>
        public const string RRESPONSE_CODE_EXCEEDED_AMOUNT = "EXCEEDED_AMOUNT";
        ///<summary>
        ///The transaction was not accepted by the bank for some reason.
        ///</summary>
        public const string RRESPONSE_CODE_NOT_ACCEPTED_TRANSACTION = "NOT_ACCEPTED_TRANSACTION";
        ///<summary>
        ///An error occurred converting the amounts to the payment currency.
        ///</summary>
        public const string RRESPONSE_CODE_ERROR_CONVERTING_TRANSACTION_AMOUNTS = "ERROR_CONVERTING_TRANSACTION_AMOUNTS";
        ///<summary>
        ///The transaction expired.
        ///</summary>
        public const string RRESPONSE_CODE_EXPIRED_TRANSACTION = "EXPIRED_TRANSACTION";
        ///<summary>
        ///The transaction was stopped and must be revised, this can occur because of security filters.
        ///</summary>
        public const string RRESPONSE_CODE_PENDING_TRANSACTION_REVIEW = "PENDING_TRANSACTION_REVIEW";
        ///<summary>
        ///The transaction is subject to confirmation.
        ///</summary>
        public const string RRESPONSE_CODE_PENDING_TRANSACTION_CONFIRMATION = "PENDING_TRANSACTION_CONFIRMATION";
        ///<summary>
        ///The transaction is subject to be transmitted to the financial network. 
        ///This usually applies to transactions with cash payment means.
        ///</summary>
        public const string RRESPONSE_CODE_PENDING_TRANSACTION_TRANSMISSION = "PENDING_TRANSACTION_TRANSMISSION";
        ///<summary>
        ///The message returned by the financial network is inconsistent.
        ///</summary>
        public const string RRESPONSE_CODE_PAYMENT_NETWORK_BAD_RESPONSE = "PAYMENT_NETWORK_BAD_RESPONSE";
        ///<summary>
        ///Could not connect to the financial network.
        ///</summary>
        public const string RRESPONSE_CODE_PAYMENT_NETWORK_NO_CONNECTION = "PAYMENT_NETWORK_NO_CONNECTION";
        ///<summary>
        ///Financial Network did not respond.
        ///</summary>
        public const string RRESPONSE_CODE_PAYMENT_NETWORK_NO_RESPONSE = "PAYMENT_NETWORK_NO_RESPONSE";
        ///<summary>
        ///Transactions clinic: internal handling code.
        ///</summary>
        public const string RRESPONSE_CODE_FIX_NOT_REQUIRED = "FIX_NOT_REQUIRED";
        ///<summary>
        ///Transactions clinic: internal handling code. Only applies to Query API.
        ///</summary>
        public const string RRESPONSE_CODE_AUTOMATICALLY_FIXED_AND_SUCCESS_REVERSAL = "AUTOMATICALLY_FIXED_AND_SUCCESS_REVERSAL";
        ///<summary>
        ///Transactions clinic: internal handling code. Only applies to Query API.
        ///</summary>
        public const string RRESPONSE_CODE_AUTOMATICALLY_FIXED_AND_UNSUCCESS_REVERSAL = "AUTOMATICALLY_FIXED_AND_UNSUCCESS_REVERSAL";
        ///<summary>
        ///Transactions clinic: internal handling code. Only applies to Query API.
        ///</summary>
        public const string RRESPONSE_CODE_AUTOMATIC_FIXED_NOT_SUPPORTED = "AUTOMATIC_FIXED_NOT_SUPPORTED";
        ///<summary>
        ///Transactions clinic: internal handling code. Only applies to Query API.
        ///</summary>
        public const string RRESPONSE_CODE_NOT_FIXED_FOR_ERROR_STATE = "NOT_FIXED_FOR_ERROR_STATE";
        ///<summary>
        ///Transactions clinic: internal handling code. Only applies to Query API.
        ///</summary>
        public const string RRESPONSE_CODE_ERROR_FIXING_AND_REVERSING = "ERROR_FIXING_AND_REVERSING";
        ///<summary>
        ///Transactions clinic: internal handling code. Only applies to Query API.
        ///</summary>
        public const string RRESPONSE_CODE_ERROR_FIXING_INCOMPLETE_DATA = "ERROR_FIXING_INCOMPLETE_DATA";
        #endregion

        #region  Command accepted for query api
        ///<summary>
        ///Used to query an order using its identifier.
        ///</summary>
        public const string COMMAND_ORDER_DETAIL = "ORDER_DETAIL";
        ///<summary>
        ///Used to query an order using its reference code.
        ///</summary>
        public const string COMMAND_ORDER_DETAIL_BY_REFERENCE_CODE = "ORDER_DETAIL_BY_REFERENCE_CODE";
        ///<summary>
        ///Used to check the response of a transaction.
        ///</summary>
        public const string COMMAND_TRANSACTION_RESPONSE_DETAIL = "TRANSACTION_RESPONSE_DETAIL";
        #endregion

        #region  Commands accepted by the payment api
        ///<summary>
        ///Used to send transactions of any kind.
        ///</summary>
        public const string COMMAND_SUBMIT_TRANSACTION = "SUBMIT_TRANSACTION";
        ///<summary>
        ///Used to query the shop’s available payment methods.
        ///</summary>
        public const string COMMAND_GET_PAYMENT_METHODS = "GET_PAYMENT_METHODS";
        ///<summary>
        ///It is used to obtain the bank list for PSE transactions.
        ///</summary>
        public const string COMMAND_GET_BANKS_LIST = "GET_BANKS_LIST";
        #endregion

        #region Accepted currencies
        ///<summary>
        /// Argentine Peso
        ///</summary>
        public const string CURRENCY_ARS = "ARS";
        ///<summary>
        /// Brazilian Real
        ///</summary>
        public const string CURRENCY_BRL = "BRL";
        ///<summary>
        /// Chilean Peso
        ///</summary>
        public const string CURRENCY_CLP = "CLP";
        ///<summary>
        /// Colombian Peso
        ///</summary>
        public const string CURRENCY_COP = "COP";
        ///<summary>
        /// Mexican Peso
        ///</summary>
        public const string CURRENCY_MXN = "MXN";
        ///<summary>
        /// US Dollar
        ///</summary>
        public const string CURRENCY_USD = "USD";
        ///<summary>
        /// Peruvian Nuevo Sol
        ///</summary>
        public const string CURRENCY_PEN = "PEN";
        #endregion

        #region Transaction state
        ///<summary>
        /// Expired transaction
        ///</summary>
        public const string TRANSACTION_STATUS_EXPIRED = "EXPIRED";
        ///<summary>
        /// Pending transaction or in validation
        ///</summary>
        public const string TRANSACTION_STATUS_PENDING = "PENDING";
        ///<summary>
        ///   Transaction sent to the financial institution and for some reason processing did not finish.Only applies to query API.
        ///</summary>
        public const string TRANSACTION_STATUS_SUBMITTED = "SUBMITTED";
        #endregion

        #region Order status
        ///<summary>
        ///The order was just created in the system
        ///</summary>
        public const string ORDER_STATUS_NEW = "NEW";
        ///<summary>
        ///The order is being processed.
        ///</summary>
        public const string ORDER_STATUS_IN_PROGRESS = "IN_PROGRESS";
        ///<summary>
        ///  The last transaction of the order was an approved authorization.
        ///</summary>
        public const string ORDER_STATUS_AUTHORIZED = "AUTHORIZED";
        ///<summary>
        /// The last transaction of the order was an approved capture.
        ///</summary>
        public const string ORDER_STATUS_CAPTURED = "CAPTURED";
        ///<summary>
        /// The last transaction of the order was an approved cancellation.
        ///</summary>
        public const string ORDER_STATUS_CANCELLED = "CANCELLED";
        ///<summary>
        ///The last transaction of the order was an approved refund.
        ///</summary>
        public const string ORDER_STATUS_REFUNDED = "REFUNDED";
        #endregion

        #region  Supported languages
        ///        Iso code 639	
        ///<summary>
        ///English
        ///</summary>
        public const string LANGUAGE_EN = "en";
        ///<summary>
        ///Spanish
        ///</summary>
        public const string LANGUAGE_ES = "es";
        ///<summary>
        ///Portuguese
        ///</summary>
        public const string LANGUAGE_PT = "pt";
        #endregion

        #region  Payment method
        ///<summary>
        ///Common for all countries
        ///. Panama
        ///Only VISA MASTERCARD
        ///</summary>
        public const string PAYMENT_METHOD_VISA = "VISA";
        ///<summary>
        ///Common for all countries
        ///. Panama
        ///Only VISA MASTERCARD
        ///</summary>
        public const string PAYMENT_METHOD_MASTERCARD = "MASTERCARD";
        ///<summary>
        ///Common
        ///</summary>
        public const string PAYMENT_METHOD_AMEX = "AMEX";
        ///<summary>
        ///Common 
        ///</summary>
        public const string PAYMENT_METHOD_DINERS = "DINERS";
        ///<summary>
        ///Argentina
        ///</summary>
        public const string PAYMENT_METHOD_PAGOFACIL = "PAGOFACIL";
        ///<summary>
        ///Argentina
        ///</summary>
        public const string PAYMENT_METHOD_CABAL = "CABAL";
        ///<summary>
        ///Argentina
        ///</summary>
        public const string PAYMENT_METHOD_NARANJA = "NARANJA";
        ///<summary>
        ///Argentina
        ///</summary>
        public const string PAYMENT_METHOD_SHOPPING = "SHOPPING";
        ///<summary>
        ///Argentina
        ///</summary>
        public const string PAYMENT_METHOD_COBRO_EXPRESS = "COBRO_EXPRESS";
        ///<summary>
        ///Argentina
        ///</summary>
        public const string PAYMENT_METHOD_RAPIPAGO = "RAPIPAGO";
        ///<summary>
        ///Argentina
        ///</summary>
        public const string PAYMENT_METHOD_CENCOSUD = "CENCOSUD";
        ///<summary>
        ///Argentina
        ///</summary>
        public const string PAYMENT_METHOD_ARGENCARD = "ARGENCARD";
        ///<summary>
        ///Argentina
        ///</summary>
        public const string PAYMENT_METHOD_BAPRO = "BAPRO";
        ///<summary>
        ///Argentina
        ///</summary>
        public const string PAYMENT_METHOD_RIPSA = "RIPSA";
        ///<summary>
        /// Brazil
        ///</summary>
        public const string PAYMENT_METHOD_BOLETO_BANCARIO = "BOLETO_BANCARIO";
        ///<summary>
        /// Brazil
        ///</summary>
        public const string PAYMENT_METHOD_ELO = "ELO";
        ///<summary>
        /// Brazil
        ///</summary>
        public const string PAYMENT_METHOD_HIPERCARD = "HIPERCARD";
        ///<summary>
        ///Chile
        ///</summary>
        public const string PAYMENT_METHOD_TRANSBANK = "TRANSBANK";
        ///<summary>
        /// Colombia
        ///</summary>
        public const string PAYMENT_METHOD_BALOTO = "BALOTO";
        ///<summary>
        /// Colombia
        ///</summary>
        public const string PAYMENT_METHOD_BANK_REFERENCED = "BANK_REFERENCED";
        ///<summary>
        /// Colombia
        ///</summary>
        public const string PAYMENT_METHOD_PSE = "PSE";
        ///<summary>
        /// Colombia
        ///</summary>
        public const string PAYMENT_METHOD_EFECTY = "EFECTY";
        ///<summary>
        /// México
        ///</summary>
        public const string PAYMENT_METHOD_SANTANDER = "SANTANDER";
        ///<summary>
        /// México
        ///</summary>
        public const string PAYMENT_METHOD_BANCOMER = "BANCOMER";
        ///<summary>
        /// México
        ///</summary>
        public const string PAYMENT_METHOD_IXE = "IXE";
        ///<summary>
        /// México
        ///</summary>
        public const string PAYMENT_METHOD_SCOTIABANK = "SCOTIABANK";
        ///<summary>
        /// México
        ///</summary>
        public const string PAYMENT_METHOD_BANAMEX = "BANAMEX";
        ///<summary>
        /// México
        ///</summary>
        public const string PAYMENT_METHOD_OXXO = "OXXO";
        ///<summary>
        /// México
        ///</summary>
        public const string PAYMENT_METHOD_SEVEN_ELEVEN = "SEVEN_ELEVEN";
        ///<summary>
        /// Peru
        ///</summary>
        public const string PAYMENT_METHOD_BCP = "BCP";
        #endregion

        #region Countries of payment
        ///<summary>
        /// Brazil
        ///</summary>
        public const string COUNTRY_BR = "BR";
        ///<summary>
        /// Argentina
        ///</summary>
        public const string COUNTRY_AR = "AR";
        ///<summary>
        ///Colombia
        ///</summary>
        public const string COUNTRY_CO = "CO";
        ///<summary>
        /// Mexico
        ///</summary>
        public const string COUNTRY_MX = "MX";
        ///<summary>
        /// Panama
        ///</summary>
        public const string COUNTRY_PA = "PA";
        ///<summary>
        /// Peru
        ///</summary>
        public const string COUNTRY_PE = "PE";
        #endregion

        #region Transaction types
        ///<summary>
        /// Authorization transaction
        ///</summary>
        public const string TRANSACTION_TYPE_AUTHORIZATION = "AUTHORIZATION";
        ///<summary>
        /// Authorization and capture transaction
        ///</summary>
        public const string TRANSACTION_TYPE_AUTHORIZATION_AND_CAPTURE = "AUTHORIZATION_AND_CAPTURE";
        ///<summary>
        /// Capture Transaction
        ///</summary>
        public const string TRANSACTION_TYPE_CAPTURE = "CAPTURE";
        ///<summary>
        /// Cancellation transaction of an authorization
        ///</summary>
        public const string TRANSACTION_TYPE_VOID = "VOID";
        ///<summary>
        /// Refund transaction or cancellation of a capture
        ///</summary>
        public const string TRANSACTION_TYPE_REFUND = "REFUND";
        #endregion

        #region PSE USER DOCUMENT TYPE
        /// <summary>
        /// Citizenship card.
        /// </summary>
        [Description("Cédula de ciudadanía.")]
        public const string DOCUMENT_TYPE_CC = "CC";
        /// <summary>
        /// Foreign citizenship card.
        /// </summary>
        [Description("Cédula de extranjería.")]
        public const string DOCUMENT_TYPE_CE = "CE";
        /// <summary>
        /// For a company.
        /// </summary>
        [Description("N.I.T.")]
        public const string DOCUMENT_TYPE_NIT = "NIT";
        /// <summary>
        /// Identity Card.
        /// </summary>
        [Description("Tarjeta de Identidad.")]
        public const string DOCUMENT_TYPE_TI = "TI";
        /// <summary>
        /// Passport.
        /// </summary>
        [Description("Pasaporte.")]
        public const string DOCUMENT_TYPE_PP = "PP";
        /// <summary>
        /// Client´s unique identifier, in the case of unique customer / utility consumer ID's.
        /// </summary>
        [Description("Identificador único de cliente.")]
        public const string DOCUMENT_TYPE_IDC = "IDC";
        /// <summary>
        /// When identified by the mobile line.
        /// </summary>
        [Description("Número móvil.")]
        public const string DOCUMENT_TYPE_CEL = "CEL";
        /// <summary>
        /// Birth certificate.
        /// </summary>
        [Description("Registro civil de nacimiento.")]
        public const string DOCUMENT_TYPE_RC = "RC";
        /// <summary>
        /// Foreign identification document.
        /// </summary>
        [Description("Documento de identificación extranjero.")]
        public const string DOCUMENT_TYPE_DE = "DE";
        #endregion

        #region PSE USER TYPE
        /// <summary>
        /// whether he is a "natural person" (N).
        /// </summary>
        [Description("Natural.")]
        public const string USER_TYPE_NARUTAL_PERSON = "N";
        /// <summary>
        /// whether he is a "legal person” (J).
        /// </summary>
        [Description("Legal.")]
        public const string USER_TYPE_LEGAL_PERSON = "J";
        #endregion
    }
}
