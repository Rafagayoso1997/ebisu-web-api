using System.Security.Cryptography;
using System.Text;

namespace EbisuWebApi.Crosscutting.Security
{
    public static class Encoding
    {
        static string EncryptStringToBytes_Aes(string stringToEncrypt, byte[] Key, byte[] IV)
        {
            if (stringToEncrypt == null || stringToEncrypt.Length <= 0)
                throw new ArgumentNullException();
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException();
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException();

            byte[] encrypted;

            using (Aes aesAlgorithm = Aes.Create())
            {
                aesAlgorithm.Key = Key;
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