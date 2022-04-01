using System;
using System.Collections.Generic;

namespace Com.MrIT.DBEntities
{
    public partial class CourseTag : GenericEntity
    { 
        public long CourseId { get; set; }
        public long TagId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
