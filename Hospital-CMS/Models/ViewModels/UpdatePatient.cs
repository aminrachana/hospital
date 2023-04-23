using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_CMS.Models.ViewModels
{
    public class UpdatePatient
    {
        //This viewmodel is a class which stores information that we need to present to /Patient/Update/{}

        //the existing patient information

        public PatientDto SelectedPatient { get; set; }

        //all rooms to choose from when updating this patient

        public IEnumerable<RoomDto> RoomOptions { get; set; }
    }
}