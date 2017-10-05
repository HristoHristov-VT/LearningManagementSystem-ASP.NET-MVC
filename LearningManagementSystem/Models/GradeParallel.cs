namespace LearningManagementSystem.Models
{
    public class GradeParallel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Grade IDGrade { get; set; }
        public Staff IDStaff { get; set; }
    }
}