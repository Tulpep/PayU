using System;
using System.Configuration;
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
            double val = 0;
            if (double.TryParse(model.value, out val))
            {
                string subVal = model.value;
                if (IsDecimalZeros(val))
                {
                    subVal = subVal.Substring(0, model.value.Length - 1);
                }
                string source = ConfigurationManager.AppSettings["PAYU_API_KEY"] + "~" + model.merchant_id + "~" + model.reference_sale + "~" + subVal + "~" +
                                        model.currency + "~" + model.state_pol;
                MD5 md5Hash = MD5.Create();
                string pSignature = CryptoHelper.GetMd5Hash(md5Hash, source);

                if (pSignature.Equals(model.sign))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        private static bool IsDecimalZeros(double dec)
        {
            double result = ((dec - (int)dec) * 10);
            return result == Math.Floor(result);
        }
    }
}
