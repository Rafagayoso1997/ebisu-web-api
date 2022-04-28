using System.Security.Cryptography;
using System.Text;

namespace EbisuWebApi.Crosscutting.Security
{
    public static class Encoding
    {
        public static string EncryptStringToBytes_Aes(string stringToEncrypt)
        {
            byte[] encrypted;

            using (Aes aesAlgorithm = Aes.Create())
            {
                byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
                byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
                aesAlgorithm.Key = key;
                aesAlgorithm.IV = IV;

                //TODO:
                ///////////////
                //aesAlgorithm.Key = ResorcesManagement.ObtainKeyAES();
                //aesAlgorithm.IV = ResorcesManagement.ObtainIVAES();
                ////////////

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