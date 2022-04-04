using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("career")]
    public  class Career : GenericEntity
    {
        
        public Career()
        {
            CareerPath = new HashSet<CareerPath>();
            CourseCareer = new HashSet<CourseCareer>();
        }
         
        public string Name { get; set; }

        public virtual ICollection<CareerPath> CareerPath { get; set; }
        public virtual ICollection<CourseCareer> CourseCareer { get; set; }
    }
}
