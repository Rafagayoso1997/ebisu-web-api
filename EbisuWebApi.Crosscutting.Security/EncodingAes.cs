using EbisuWebApi.Crosscutting.ResourcesManagement;
using System.Security.Cryptography;
using System.Text;

namespace EbisuWebApi.Crosscutting.Security
{
    public static class EncodingAes
    {

        private static byte[] ConvertStringIntoByteArray(string stringToConvert)
        {
            byte[] byteArray = ASCIIEncoding.ASCII.GetBytes(stringToConvert);
            return byteArray;

        }
        public static string EncryptStringToBytes_Aes(string stringToEncrypt)
        {
            byte[] encrypted;

            using (Aes aesAlgorithm = Aes.Create())
            {


                aesAlgorithm.Key = ConvertStringIntoByteArray(EncryptResources.ObtainKeyAES());
                aesAlgorithm.IV = ConvertStringIntoByteArray(EncryptResources.ObtainIVAES());

                ICryptoTransform encryptor = aesAlgorithm.CreateEncryptor(aesAlgorithm.Key, aesAlgorithm.IV);

                using MemoryStream msEncrypt = new();
                using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (StreamWriter swEncrypt = new(csEncrypt))
                {
                    swEncrypt.Write(stringToEncrypt);
                }
                encrypted = msEncrypt.ToArray();
            }
            string sncryptedString = System.Text.Encoding.UTF8.GetString(encrypted);
            return sncryptedString;
        }
    }
}