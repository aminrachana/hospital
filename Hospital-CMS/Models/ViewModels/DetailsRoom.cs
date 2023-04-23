using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_CMS.Models.ViewModels
{
    public class DetailsRoom
    {
        public RoomDto SelectedRoom { get; set; }

        public IEnumerable<PatientDto> RelatedPatients { get; set; }
    }
}