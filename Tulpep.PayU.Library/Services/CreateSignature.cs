using PCLCrypto;
using System.Text;

namespace Tulpep.PayU.Library.Services
{
    public static class CreateSignature
    {
        public static string GenerateHash(string input, string key)
        {
            var key = WinRTCrypto.Ke
            var md5 = WinRTCrypto.CryptographicEngine.CreateEncryptor(CryptographicPublicKeyBlobType.BCryptPublicKey, new byte[1000])
            var mac = WinRTCrypto.MacAlgorithmProvider.OpenAlgorithm(MacAlgorithm.HmacSha1);
            var keyMaterial = WinRTCrypto.CryptographicBuffer.ConvertStringToBinary(key, Encoding.UTF8);
            var cryptoKey = mac.CreateKey(keyMaterial);
            var hash = WinRTCrypto.CryptographicEngine.Sign(cryptoKey, WinRTCrypto.CryptographicBuffer.ConvertStringToBinary(input, Encoding.UTF8));
            return WinRTCrypto.CryptographicBuffer.EncodeToBase64String(hash);
        }
    }
}
