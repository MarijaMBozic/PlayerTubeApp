using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Helper
{
    public static class RandomGenerateString
    {
        private static Random random = new Random();
        public static string RandomStringName()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string result = new string(Enumerable.Repeat(chars,5)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }
    }
}