using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int CommentLikes { get; set; }
        public int Unlikes { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
    }
}