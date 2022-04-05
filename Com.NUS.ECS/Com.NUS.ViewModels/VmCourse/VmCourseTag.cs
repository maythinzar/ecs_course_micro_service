using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.MrIT.ViewModels
{
    public class VmCourseTag : ViewModelItemBase
    {
        public long CourseId { get; set; }
        public long TagId { get; set; }

        public VmCourse Course { get; set; }
        public VmTag Tag { get; set; }
    }
}
