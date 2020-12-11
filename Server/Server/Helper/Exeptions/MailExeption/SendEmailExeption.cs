using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Helper.Exeptions.MailExeption
{
    public class SendEmailExeption:Exception
    {
        public SendEmailExeption() : base()
        {
        }

        public SendEmailExeption(string message) : base(message)
        {
        }
        public SendEmailExeption(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}