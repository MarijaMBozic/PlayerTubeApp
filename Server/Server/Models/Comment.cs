using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Content { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.Date;
        [Required]
        public int UserId { get; set; }
        [Required]
        public int VideoId { get; set; }
        public bool IsDeleted { get; set; }
        public int ParentComment { get; set; }
    }
}