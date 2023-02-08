namespace StudentDb.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? CourseCode { get; set; }
        public string? CourseName { get; set; }
        public int CourseCredit { get;set; }
        public decimal ? CourseAmount { get; set;}
    }
}
