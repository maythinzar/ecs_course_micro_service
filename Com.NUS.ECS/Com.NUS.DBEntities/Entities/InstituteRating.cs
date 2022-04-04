using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("institute_rating")]
    public  class InstituteRating : GenericEntity
    { 
        public long InstituteId { get; set; }
        public string Username { get; set; }
        public int? Rating { get; set; }
        public string Review { get; set; }

        public virtual Institute Institute { get; set; }
    }
}
