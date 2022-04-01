using System;
using System.Collections.Generic;

namespace Com.MrIT.DBEntities
{
    public partial class Course : GenericEntity
    {
        public Course()
        {
            CourseCareer = new HashSet<CourseCareer>();
            CourseInstructor = new HashSet<CourseInstructor>();
            CoursePrerequisite = new HashSet<CoursePrerequisite>();
            CourseRating = new HashSet<CourseRating>();
            CourseTag = new HashSet<CourseTag>();
        }
         
        public string Guid { get; set; }
        public long InstituteId { get; set; }
        public long CourseTypeId { get; set; }
        public long CourseCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? AverageRating { get; set; }
        public int? DurationInDay { get; set; }

        public virtual CourseCategory CourseCategory { get; set; }
        public virtual CourseType CourseType { get; set; }
        public virtual Institute Institute { get; set; }
        public virtual ICollection<CourseCareer> CourseCareer { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructor { get; set; }
        public virtual ICollection<CoursePrerequisite> CoursePrerequisite { get; set; }
        public virtual ICollection<CourseRating> CourseRating { get; set; }
        public virtual ICollection<CourseTag> CourseTag { get; set; }
    }
}
