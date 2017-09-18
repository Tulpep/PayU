using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Tulpep.PayULibrary.Services.ServicesHelpers
{
    public static class CryptoHelper
    {
        public static string RequestSignature(RequestSignatureModel model)
        {
            string source = $"{model.ApiKey}~{model.MerchantId}~{model.ReferenceCode}~{model.Value.ToString(CultureInfo.InvariantCulture)}~{model.Currency}";

            return GetMd5Hash(MD5.Create(), source);
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static string GetBase64Hash(string input)
        {
            // Convert the input string to a byte array and compute the hash.
            var plainTextBytes = Encoding.UTF8.GetBytes(input);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }

    public class RequestSignatureModel
    {
        public string ApiKey { get; set; }
        public string MerchantId { get; set; }
        public string ReferenceCode { get; set; }
        public decimal Value { get; set; }
        public string Currency { get; set; }
    }
}
