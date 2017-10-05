using System;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models
{
    public class Staff
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime Created { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public string Category { get; set; }
        public DateTime DateOfHiring { get; set; }
        public decimal Salary { get; set; }

        public StaffType IDStaffType { get; set; }

        public Staff()
        {
            Created = DateTime.Now;
            DateOfHiring = DateTime.Now;

        }


    }
}