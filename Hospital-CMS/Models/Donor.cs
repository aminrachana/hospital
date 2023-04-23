using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_CMS.Models
{
    public class Donor
    {
        [Key]
        public int DonorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Contact { get; set; }
        public string Address { get; set; }
        public int Value { get; set; }
    }
    public class DonorDto
    {
        public int DonorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Contact { get; set; }
        public string Address { get; set; }
        public int Value { get; set; }
    }
}