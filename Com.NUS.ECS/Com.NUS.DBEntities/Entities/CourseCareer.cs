using System;
using System.Collections.Generic;

namespace Com.MrIT.DBEntities
{
    public partial class CourseCareer : GenericEntity
    { 
        public long CourseId { get; set; }
        public long CareerId { get; set; }

        public virtual Career Career { get; set; }
        public virtual Course Course { get; set; }
    }
}
