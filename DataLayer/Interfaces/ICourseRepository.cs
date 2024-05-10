using DataLayer.Models;

namespace DataLayer.Interfaces
{
    public interface ICourseRepository
    {
        public List<DataTransferObjects.Models.Course> GetAllCourses();
        public DataTransferObjects.Models.Course GetCourseById(int id);

        public DataTransferObjects.Models.Course GetCourseByCode(string courseCode);

        public bool AddCourse(DataTransferObjects.Models.Course course);

        public void UpdateCourse(DataTransferObjects.Models.Course course);

        public void DeleteCourse(int id);

        public void AddStudent(DataTransferObjects.Models.Course course);

        public void RemoveStudent(DataTransferObjects.Models.Course course);
    }
}
