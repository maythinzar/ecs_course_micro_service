using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("institute_user")]
    public  class InstituteUser : GenericEntity
    { 
        public long InstituteId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        public virtual Institute Institute { get; set; }
    }
}
