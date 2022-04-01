using System;
using System.Collections.Generic;

namespace Com.MrIT.DBEntities
{
    public partial class Tag : GenericEntity
    {
        public Tag()
        {
            CourseTag = new HashSet<CourseTag>();
        }
         
        public string Name { get; set; }

        public virtual ICollection<CourseTag> CourseTag { get; set; }
    }
}
