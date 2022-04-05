using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.MrIT.ViewModels
{
    public class VmCareer : ViewModelItemBase
    { 
        public string Name { get; set; }

        public List<VmCareerPath> CareerPath { get; set; }
        public List<VmCourseCareer> CourseCareer { get; set; }
    }
}
