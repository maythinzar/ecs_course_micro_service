using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.MrIT.ViewModels
{
    public class VmInstructor : ViewModelItemBase
    {
        public long InstituteId { get; set; }
        public string Name { get; set; }
        public string Education { get; set; }
        public string WorkExperience { get; set; }
        public byte[] Image { get; set; }

        public VmInstitute Institute { get; set; }
        public  List<VmCourseInstructor> CourseInstructor { get; set; }
    }
}
