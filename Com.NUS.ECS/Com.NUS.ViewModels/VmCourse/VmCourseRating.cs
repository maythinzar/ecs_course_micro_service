using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.MrIT.ViewModels
{
    public class VmCourseRating : ViewModelItemBase
    {
        public long CourseId { get; set; }
        public int Rating { get; set; }
        public string Username { get; set; }
        public string Review { get; set; }

        public VmCourse Course { get; set; }


    }
}
