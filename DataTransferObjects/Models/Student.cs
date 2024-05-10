namespace DataTransferObjects.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Gender { get; set; }

        public DateOnly Dob { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public int RegisteredCourse { get; set; }  


    }
}
