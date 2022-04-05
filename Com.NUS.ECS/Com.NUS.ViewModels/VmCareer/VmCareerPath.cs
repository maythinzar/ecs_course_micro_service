using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.MrIT.ViewModels
{
    public class VmCareerPath : ViewModelItemBase
    {
        public long CourseCategoryId { get; set; }
        public long CareerId { get; set; }
        public bool IsMandatory { get; set; }
        public string OtherRemarks { get; set; }
        public int PathGroupNo { get; set; }
        public VmCareer Career { get; set; }
        public VmCourseCategory CourseCategory { get; set; }


    }
}
