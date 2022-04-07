using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("course_instructor")]
    public  class CourseInstructor : GenericEntity
    { 
        public long CourseId { get; set; }
        public long InstructorId { get; set; }
        public string Role { get; set; }

        public virtual Course Course { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
