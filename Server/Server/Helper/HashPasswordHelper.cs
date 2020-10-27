using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Server.Helper
{
    public class HashPasswordHelper
    {
        public static string HashPassword(string password)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] password_byte = Encoding.ASCII.GetBytes(password);
            byte[] encripted_byte = sha1.ComputeHash(password_byte);
            return Convert.ToBase64String(encripted_byte);
        }
    }
}