using System;
using System.Collections.Generic;

namespace Com.MrIT.DBEntities
{
    public partial class CourseRating : GenericEntity
    { 
        public long CourseId { get; set; }
        public int? Rating { get; set; }
        public string Username { get; set; }
        public string Review { get; set; }

        public virtual Course Course { get; set; }
    }
}
