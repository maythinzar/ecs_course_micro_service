using System;
using System.Collections.Generic;

namespace Com.MrIT.DBEntities
{
    public partial class InstituteUser : GenericEntity
    { 
        public long InstituteId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        public virtual Institute Institute { get; set; }
    }
}
