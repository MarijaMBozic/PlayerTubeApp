using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.DTO
{
    public class LoginDataDTO
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Token { get; set; }
    }
}