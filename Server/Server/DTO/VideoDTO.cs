using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.DTO
{
    public class VideoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Views { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public int VideoLikes { get; set; }
        public int Unlikes { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
    }
}