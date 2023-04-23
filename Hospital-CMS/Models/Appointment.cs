using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hospital_CMS.Models
{
    public class Appointment
    {

        [Key]
        public int AppointmentId { get; set; }

        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }

        public DateTime CheckIn { get; set; }


        //Importing foreign key i.e appointment belongs to patient
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        //One patient might have many appointment i.e one to many relationship to appointments
        public virtual Patient Patient { get; set; }



        //Patient might have ONE or  multiple appointment with multiple doctor
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }


        //patient might have one or multiple rooms

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }




    }


    public class AppointmentDto
    {
        public int AppointmentId { get; set; }

        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }

        public DateTime CheckIn { get; set; }


        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string RoomType { get; set; }

    }
}