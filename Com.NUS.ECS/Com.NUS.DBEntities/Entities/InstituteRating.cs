using System;
using System.Collections.Generic;

namespace Com.MrIT.DBEntities
{
    public partial class InstituteRating : GenericEntity
    { 
        public long InstituteId { get; set; }
        public string Username { get; set; }
        public int? Rating { get; set; }
        public string Review { get; set; }

        public virtual Institute Institute { get; set; }
    }
}
