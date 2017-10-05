using LearningManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Data
{
    public class LMSContext : DbContext
    {
        public LMSContext()
            : base("name=DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Cource> Cources { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<GradeParallel> GradeParallels { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<StaffType> StaffTypes { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectGrade> SubjectGrades { get; set; }

        //public static LMSContext Create()
        //{
        //    return new LMSContext();
        //}

    }
}