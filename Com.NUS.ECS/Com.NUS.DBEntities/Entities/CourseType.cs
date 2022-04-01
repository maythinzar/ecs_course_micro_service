using System;
using System.Collections.Generic;

namespace Com.MrIT.DBEntities
{
    public partial class CourseType : GenericEntity
    {
        public CourseType()
        {
            Course = new HashSet<Course>();
        }
         
        public string Name { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}
