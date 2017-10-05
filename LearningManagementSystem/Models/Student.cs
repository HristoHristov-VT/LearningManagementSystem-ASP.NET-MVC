

namespace LearningManagementSystem.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public string Rude { get; set; }
        public string Observation { get; set; }
        public virtual Attendance Attendance { get; set; }

        //public virtual ICollection<Subject> Subjects { get; set; }


        public GradeParallel IDGetGradeParallel { get; set; }

        public Student()
        {
            //this.Subjects = new HashSet<Subject>();
            Created = DateTime.Now;

        }
    }
}