using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.MrIT.ViewModels
{
    public class VmCourseCareer : ViewModelItemBase
    {
        public long CourseId { get; set; }
        public long CareerId { get; set; }

        public VmCareer Career { get; set; }
        public VmCourse Course { get; set; }

    }
}
