using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.MrIT.ViewModels
{
    public class VmInstituteRating : ViewModelItemBase
    {
        public long InstituteId { get; set; }
        public string Username { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }

        public VmInstitute Institute { get; set; }
    }
}
