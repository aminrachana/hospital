using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_CMS.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string PFName { get; set; }
        public string PLName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string HealthcardNo { get; set; }
        public string ContactNo { get; set; }


        //A patient belongs to one room
        //A room can have many patients
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

    }

    public class PatientDto
    {
        public int PatientId { get; set; }
        public string PFName { get; set; }
        public string PLName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string HealthcardNo { get; set; }
        public string ContactNo { get; set; }
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
        public string RoomType { get; set; }
    }
}