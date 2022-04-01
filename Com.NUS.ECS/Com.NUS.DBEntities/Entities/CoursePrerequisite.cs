using System;
using System.Collections.Generic;

namespace Com.MrIT.DBEntities
{
    public partial class CoursePrerequisite:GenericEntity
    { 
        public long CourseCategoryId { get; set; }
        public long CourseId { get; set; }
        public bool IsMandatory { get; set; }
        public string OtherRemarks { get; set; }

        public virtual Course Course { get; set; }
        public virtual CourseCategory CourseCategory { get; set; }
    }
}
