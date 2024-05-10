using DataLayer.Models;
using System;

namespace DataLayer.Interfaces
{
    public interface IStudentRepository
    {
        public List<DataTransferObjects.Models.Student> GetAllStudents();
        public DataTransferObjects.Models.Student GetStudentById(int id);
        public void AddStudent(DataTransferObjects.Models.Student student);
        public void UpdateStudent(DataTransferObjects.Models.Student student);
        public void DeleteStudent(int id);
        public bool RegisterCourse(int studentid, int courseId);
        public bool UnRegisterCourse(int studentid, int courseId);
        public List<DataTransferObjects.Models.Course> GetCoursesForStudent(int studentId);
    }
}
