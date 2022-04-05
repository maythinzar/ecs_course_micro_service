using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.MrIT.ViewModels
{
    public class VmCoursePrerequisite : ViewModelItemBase
    {
        public long CourseCategoryId { get; set; }
        public long CourseId { get; set; }
        public bool IsMandatory { get; set; }
        public string OtherRemarks { get; set; }

        public VmCourse Course { get; set; }
        public VmCourseCategory CourseCategory { get; set; }
    }
}
