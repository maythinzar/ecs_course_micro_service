using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("course_tag")]
    public  class CourseTag : GenericEntity
    { 
        public long CourseId { get; set; }
        public long TagId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
