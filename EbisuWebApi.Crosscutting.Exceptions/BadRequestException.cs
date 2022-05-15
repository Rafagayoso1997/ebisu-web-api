using EbisuWebApi.Crosscutting.ResourcesManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Crosscutting.Exceptions
{
    public class BadRequestException : Exception
    {

        public BadRequestException() : base(MessagesResource.XssAttackDetected)
        {
        }

        public BadRequestException(string? message, Exception? innerException) : base(MessagesResource.XssAttackDetected, innerException)
        {
        }
    }
}
