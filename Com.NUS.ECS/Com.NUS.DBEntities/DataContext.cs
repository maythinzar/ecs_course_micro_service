using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.MrIT.DBEntities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }



        public virtual DbSet<Career> Career { get; set; }
        public virtual DbSet<CareerPath> CareerPath { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseCareer> CourseCareer { get; set; }
        public virtual DbSet<CourseCategory> CourseCategory { get; set; }
        public virtual DbSet<CourseInstructor> CourseInstructor { get; set; }
        public virtual DbSet<CoursePrerequisite> CoursePrerequisite { get; set; }
        public virtual DbSet<CourseRating> CourseRating { get; set; }
        public virtual DbSet<CourseTag> CourseTag { get; set; }
        public virtual DbSet<CourseType> CourseType { get; set; }
        public virtual DbSet<Institute> Institute { get; set; }
        public virtual DbSet<InstituteRating> InstituteRating { get; set; }
        public virtual DbSet<InstituteUser> InstituteUser { get; set; }
        public virtual DbSet<Instructor> Instructor { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }

    }
}
