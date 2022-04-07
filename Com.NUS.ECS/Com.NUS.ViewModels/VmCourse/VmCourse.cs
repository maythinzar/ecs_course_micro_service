using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.MrIT.ViewModels
{
    public class VmCourse : ViewModelItemBase
    {
        public string Guid { get; set; }
        public long InstituteId { get; set; }
        public long CourseTypeId { get; set; }
        public long CourseCategoryId { get; set; }
        public string SelectedCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal AverageRating { get; set; }
        public int DurationInDay { get; set; }

        public VmCourseCategory CourseCategory { get; set; }
        public VmCourseType CourseType { get; set; }
        public VmInstitute Institute { get; set; }
        public List<VmCourseCareer> CourseCareers { get; set; }
        public List<VmCourseInstructor> CourseInstructors { get; set; }
        public List<VmCoursePrerequisite> CoursePrerequisites { get; set; }
        public List<VmCourseRating> CourseRatings { get; set; }
        public List<VmCourseTag> CourseTags { get; set; }

        public List<string> SelectedTag { get; set; }

        public List<string> SelectedCareer { get; set; }


    }
}
