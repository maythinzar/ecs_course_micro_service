using System;
using System.Collections.Generic;

namespace Com.MrIT.DBEntities
{
    public partial class Instructor : GenericEntity
    {
        public Instructor()
        {
            CourseInstructor = new HashSet<CourseInstructor>();
        }
         
        public long InstituteId { get; set; }
        public string Name { get; set; }
        public string Education { get; set; }
        public string WorkExperience { get; set; }
        public byte[] Image { get; set; }

        public virtual Institute Institute { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructor { get; set; }
    }
}
