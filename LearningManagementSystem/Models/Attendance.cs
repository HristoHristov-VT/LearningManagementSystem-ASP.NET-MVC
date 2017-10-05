using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Models
{
    public class Attendance
    {
        [ForeignKey("Student")]
        public int ID { get; set; }
        public DateTime Date { get; set; }        
        public bool Attended { get; set; }
        public string Remark { get; set; }

        //public Student IDStudent { get; set; }

        public virtual Student Student { get; set; }


    }
}