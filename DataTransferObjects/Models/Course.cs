namespace DataTransferObjects.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }

        public string CourseName { get; set; }

        public string TeacherName { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public int MaxCapacity { get; set; }

        public int CurrentCapacity { get; set; }
    }
}
