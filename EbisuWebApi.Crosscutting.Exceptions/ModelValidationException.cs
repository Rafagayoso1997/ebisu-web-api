using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Crosscutting.Exceptions
{
    public class ModelValidationException : Exception
    {
        public ModelValidationException(string validationErrorMessage) : base(validationErrorMessage)
        {
        }

    }
}
