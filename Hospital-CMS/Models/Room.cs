using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hospital_CMS.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
        public string RoomType { get; set; }
    }

    public class RoomDto
    {
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
        public string RoomType { get; set; }
    }
}