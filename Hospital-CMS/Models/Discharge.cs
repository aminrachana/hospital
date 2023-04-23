using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hospital_CMS.Models
{
    public class Discharge
    {

        [Key]
        public int DischargeId { get; set; }

        public DateTime CheckOut { get; set; }


        //Importing foreign key i.e one discharge belongs to one patient
       // [ForeignKey("Patient")]
       // public int PatientId { get; set; }
    }
}