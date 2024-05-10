namespace StudentCourseClient.Models
{
    public class RegisterCourseModel
    {
        public int StudentID {  get; set; }
        public string StudentName { get; set; }
        public List<DataTransferObjects.Models.Course> courses { get; set; }
    }
}
