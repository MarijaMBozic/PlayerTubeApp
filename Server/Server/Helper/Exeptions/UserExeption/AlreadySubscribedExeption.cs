using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Helper.Exeptions.UserExeption
{
    public class AlreadySubscribedExeption:Exception
    {
        public AlreadySubscribedExeption() : base()
        {
        }

        public AlreadySubscribedExeption(string message) : base(message)
        {
        }
        public AlreadySubscribedExeption(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}