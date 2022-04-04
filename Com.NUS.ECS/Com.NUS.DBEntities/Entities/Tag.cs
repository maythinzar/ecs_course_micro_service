using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("tag")]
    public  class Tag : GenericEntity
    {
        public Tag()
        {
            CourseTag = new HashSet<CourseTag>();
        }
         
        public string Name { get; set; }

        public virtual ICollection<CourseTag> CourseTag { get; set; }
    }
}
