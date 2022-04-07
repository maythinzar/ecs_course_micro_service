using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.MrIT.ViewModels
{
    public class VmCourseInstructor : ViewModelItemBase
    {
        public long CourseId { get; set; }
        public long InstructorId { get; set; }
        public string Role { get; set; }


    }
}
