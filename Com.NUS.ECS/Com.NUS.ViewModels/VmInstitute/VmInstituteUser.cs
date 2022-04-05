using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.MrIT.ViewModels
{
    public class VmInstituteUser : ViewModelItemBase
    {
        public long InstituteId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        public VmInstitute Institute { get; set; }
    }
}
