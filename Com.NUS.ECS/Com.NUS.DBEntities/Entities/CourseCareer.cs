using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("course_career")]
    public  class CourseCareer : GenericEntity
    { 
        public long CourseId { get; set; }
        public long CareerId { get; set; }

        public virtual Career Career { get; set; }
        public virtual Course Course { get; set; }
    }
}
