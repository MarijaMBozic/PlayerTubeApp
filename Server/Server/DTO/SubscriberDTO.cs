using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.DTO
{
    public class SubscriberDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SubscriberId { get; set; }
        public string SubscriberEmail { get; set; }
    }
}