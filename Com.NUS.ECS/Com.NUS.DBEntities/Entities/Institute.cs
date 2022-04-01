using System;
using System.Collections.Generic;

namespace Com.MrIT.DBEntities
{
    public partial class Institute : GenericEntity
    {
        public Institute()
        {
            Course = new HashSet<Course>();
            InstituteRating = new HashSet<InstituteRating>();
            InstituteUser = new HashSet<InstituteUser>();
            Instructor = new HashSet<Instructor>();
        }
         
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string RegistrationNo { get; set; }
        public decimal? AvgRating { get; set; }

        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<InstituteRating> InstituteRating { get; set; }
        public virtual ICollection<InstituteUser> InstituteUser { get; set; }
        public virtual ICollection<Instructor> Instructor { get; set; }
    }
}
