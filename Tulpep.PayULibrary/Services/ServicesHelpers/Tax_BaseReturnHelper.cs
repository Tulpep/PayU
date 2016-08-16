using System;
using System.Configuration;
using System.Globalization;

namespace Tulpep.PayULibrary.Services.ServicesHelpers
{
    public static class Tax_BaseReturnHelper
    {
        private static double taxPercentage;
        public static double TaxPercentage
        {
            get
            {
                if (!double.TryParse(ConfigurationManager.AppSettings["PAYU_API_TAX_PERCENTAGE"], NumberStyles.Number, CultureInfo.InvariantCulture, out taxPercentage))
                {
                    throw new InvalidOperationException("Invalid PAYU_API_TAX_PERCENTAGE in web.config");
                }
                return taxPercentage;
            }
            private set
            {
                if (!double.TryParse(ConfigurationManager.AppSettings["PAYU_API_TAX_PERCENTAGE"], NumberStyles.Number, CultureInfo.InvariantCulture, out taxPercentage))
                {
                    throw new InvalidOperationException("Invalid PAYU_API_TAX_PERCENTAGE in web.config");
                }
            }
        }
        private static double taxBaseReturnPercentage;
        public static double TaxBaseReturnPercentage
        {
            get
            {
                if (!double.TryParse(ConfigurationManager.AppSettings["PAYU_API_RETURNBASE_PERCENTAGE"], NumberStyles.Number, CultureInfo.InvariantCulture, out taxBaseReturnPercentage))
                {
                    throw new InvalidOperationException("Invalid PAYU_API_RETURNBASE_PERCENTAGE in web.config");
                }
                return taxBaseReturnPercentage;
            }
            private set
            {
                if (!double.TryParse(ConfigurationManager.AppSettings["PAYU_API_RETURNBASE_PERCENTAGE"], NumberStyles.Number, CultureInfo.InvariantCulture, out taxBaseReturnPercentage))
                {
                    throw new InvalidOperationException("Invalid PAYU_API_RETURNBASE_PERCENTAGE in web.config");
                }
            }
        }

        public static double CalculateTaxValue(double price)
        {
            double result = Math.Round(CalculateBaseReturnValue(price) * TaxPercentage, 2);
            return result;
        }

        public static double CalculateBaseReturnValue(double price)
        {
            double result = Math.Round(price / TaxBaseReturnPercentage, 2);
            return result;
        }
    }
}
