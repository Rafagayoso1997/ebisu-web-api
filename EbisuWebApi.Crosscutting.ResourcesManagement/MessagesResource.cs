using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Crosscutting.ResourcesManagement
{
    public class MessagesResource
    {
        public static string UserNameAlreadyExist
        {
            get { return Messages.UsernameAlreadyExist; }
        }

        public static string UsernameAndPasswordIncorrect
        {
            get { return Messages.UsernameAndPasswordIncorrect; }
        }

        public static string XssAttackDetected
        {
            get { return Messages.XssAttackDetected; }
        }
        


    }
}
