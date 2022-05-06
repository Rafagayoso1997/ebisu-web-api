using EbisuWebApi.Crosscutting.ResourcesManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Crosscutting.Exceptions
{
    public class IncorrectCredentials : EbisuException
    {
        public IncorrectCredentials() : base(MessagesResource.UsernameAndPasswordIncorrect)
        {
        }

    }
}
