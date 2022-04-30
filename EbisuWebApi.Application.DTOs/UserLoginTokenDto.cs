using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Application.Dtos
{
    public class UserLoginTokenDto
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
