using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Server.Helper.Exeptions.UserExeption
{
    public class LoginExeption : Exception
    {
        public LoginExeption() : base()
        {
        }

        public LoginExeption(string message) : base(message)
        {
        }
        public LoginExeption(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
