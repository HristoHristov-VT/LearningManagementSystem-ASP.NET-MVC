namespace LearningManagementSystem.Models
{
    public class Subject
    {
        public int ID { get; set; }
        public string Name { get; set; }        
        public string Abbreviation { get; set; }

        public  virtual  Student IDStudent { get; set; }
        public virtual Area IDArea { get; set; }


    }
}   