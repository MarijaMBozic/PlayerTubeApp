using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.DTO
{
    public class UserDTO
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}