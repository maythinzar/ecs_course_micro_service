using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("career_path")]
    public  class CareerPath : GenericEntity
    { 
        public long CourseCategoryId { get; set; }
        public long CareerId { get; set; }
        public bool IsMandatory { get; set; }
        public string OtherRemarks { get; set; }

        public virtual Career Career { get; set; }
        public virtual CourseCategory CourseCategory { get; set; }
    }
}
