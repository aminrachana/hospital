using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_CMS.Models
{
    public class Specilization
    {
        [Key]
        public int SpecilizationId { get; set; }

        public string SpecilizationName { get; set; }
    }

    //dto

    public class SpecilizationDto
    {
        public int SpecilizationId { get; set; }

        public string SpecilizationName { get; set; }
    }
}