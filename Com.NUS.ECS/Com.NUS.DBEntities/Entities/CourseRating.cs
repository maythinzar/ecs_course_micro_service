using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("course_rating")]
    public  class CourseRating : GenericEntity
    { 
        public long CourseId { get; set; }
        public int? Rating { get; set; }
        public string Username { get; set; }
        public string Review { get; set; }

        public virtual Course Course { get; set; }
    }
}
