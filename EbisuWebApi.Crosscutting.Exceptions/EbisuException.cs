using EbisuWebApi.Crosscutting.ResourcesManagement;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Crosscutting.Exceptions
{
    public class EbisuException : Exception
    {
        public EbisuException() : base() { }

        public EbisuException(string message) : base(message) { }

        public EbisuException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
