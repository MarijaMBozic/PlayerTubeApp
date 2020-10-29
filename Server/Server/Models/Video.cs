using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class Video
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int Views { get; set; }
        [Required]
        public string Path { get; set; }
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}