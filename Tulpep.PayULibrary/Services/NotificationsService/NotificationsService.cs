using System;
using System.Configuration;
using System.Globalization;
using System.Security.Cryptography;
using Tulpep.PayULibrary.Models.Notification;
using Tulpep.PayULibrary.Services.ServicesHelpers;

namespace Tulpep.PayULibrary.Services.NotificationsService
{
    public static class NotificationsService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool ModelIsTrustlySigned(RootPayUNotificationWebHookViewModel model)
        {
            decimal val = 0;
            if (decimal.TryParse(model.value, NumberStyles.Any, CultureInfo.InvariantCulture, out val))
            {
                string subVal = model.value;
                if (IsDecimalZeros(val))
                {
                    subVal = subVal.Substring(0, model.value.Length - 1);
                }

                return ValidateSign(new SignModel
                {
                    Currency = model.currency,
                    Reference = model.reference_sale,
                    MerchantId = model.merchant_id,
                    Sign = model.sign,
                    State = model.state_pol,
                    SubVal = subVal
                });
            }
            return false;
        }

        public static bool ModelResponsePageIsTrustlySigned(RootPayUResponsePageViewModel model)
        {
            decimal val = 0;
            if (decimal.TryParse(model.TX_VALUE, NumberStyles.Any, CultureInfo.InvariantCulture, out val))
            {
                string subVal = model.TX_VALUE;
                if (IsDecimalZeros(val))
                {
                    subVal = string.Format(CultureInfo.InvariantCulture, "{0:0.0}", Math.Round(val, 1));
                }

                return ValidateSign(new SignModel
                {
                    Currency = model.currency,
                    Reference = model.referenceCode,
                    MerchantId = model.merchantId,
                    Sign = model.signature,
                    State = model.transactionState,
                    SubVal = subVal
                });
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        private static bool IsDecimalZeros(decimal dec)
        {
            decimal result = ((dec - (int)dec) * 10);
            return result == Math.Floor(result);
        }

        private static bool ValidateSign(SignModel model)
        {
            string source = $"{ConfigurationManager.AppSettings["PAYU_API_KEY"]}~{model.MerchantId}~{model.Reference}~{model.SubVal}~{model.Currency}~{model.State}";
            string pSignature = CryptoHelper.GetMd5Hash(MD5.Create(), source);

            return pSignature.Equals(model.Sign);
        }

        private sealed class SignModel
        {
            public string MerchantId { get; set; }
            public string Reference { get; set; }
            public string SubVal { get; set; }
            public string Currency { get; set; }
            public string State { get; set; }
            public string Sign { get; set; }
        }
    }
}
