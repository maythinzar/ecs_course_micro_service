using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.MrIT.ViewModels
{
    public class VmInstitute : ViewModelItemBase
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string RegistrationNo { get; set; }
        public decimal AvgRating { get; set; }

        public   List<VmCourse> Course { get; set; }
        public List<VmInstituteRating> InstituteRating { get; set; }
        public List<VmInstituteUser> InstituteUser { get; set; }
        public List<VmInstructor> Instructor { get; set; }

    }
}
