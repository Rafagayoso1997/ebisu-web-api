using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Crosscutting.ResourcesManagement
{
    public class EncryptResources
    {
        public static string ObtainKeyAES()
        {
            return Environment.GetEnvironmentVariable("AESKey");
        }

        public static string ObtainIVAES()
        {
            return Environment.GetEnvironmentVariable("AESIV");
        }
    }
}
