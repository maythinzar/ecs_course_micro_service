using System;
using System.Collections.Generic;

namespace Com.MrIT.DBEntities
{
    public partial class CourseInstructor : GenericEntity
    { 
        public long CourseId { get; set; }
        public long InstituteId { get; set; }
        public string Role { get; set; }

        public virtual Course Course { get; set; }
        public virtual Instructor Institute { get; set; }
    }
}
