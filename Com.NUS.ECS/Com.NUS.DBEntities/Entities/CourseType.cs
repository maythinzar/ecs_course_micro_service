using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("course_type")]
    public  class CourseType : GenericEntity
    {
        public CourseType()
        {
            Course = new HashSet<Course>();
        }
         
        public string Name { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}
