using EbisuWebApi.Crosscutting.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Integration.UserServiceTest
{
    public class TokenFixtures
    {
        public static string GetToken() 
        {
            List<string> roles = new List<string>
            {
                "Admin"
            };

            return TokenGenerator.CreateToken(1, "Rafa", "gayoso0597@gmail.com", roles);
        }
    }
}
