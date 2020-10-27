using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.Date;
        public int CommentLikes { get; set; }
        public int Unlikes { get; set; }
        public int UserId { get; set; }
        public int VideoId { get; set; }
        public bool IsDeleted { get; set; }
    }
}