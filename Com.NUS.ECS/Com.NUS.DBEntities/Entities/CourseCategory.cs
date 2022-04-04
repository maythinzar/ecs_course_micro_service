using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("course_category")]
    public  class CourseCategory : GenericEntity
    {
        public CourseCategory()
        {
            CareerPath = new HashSet<CareerPath>();
            Course = new HashSet<Course>();
            CoursePrerequisite = new HashSet<CoursePrerequisite>();
        }
         
        public string Name { get; set; }
        public string CourseCategorycol { get; set; }

        public virtual ICollection<CareerPath> CareerPath { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<CoursePrerequisite> CoursePrerequisite { get; set; }
    }
}
