using DataLayer.Interfaces;
using DataTransferObjects.Models;
using System.Data.Entity;

namespace DataLayer.Models
{
    public class StudentRepository : IStudentRepository
    {
        StudentCourseContext context;
        public StudentRepository(StudentCourseContext _context) { 
           context = _context;
        }

        public List<DataTransferObjects.Models.Course> GetCoursesForStudent(int studentId)
        {
            List<DataTransferObjects.Models.Course> courses = new List<DataTransferObjects.Models.Course>();
            Student? s = context.Students.FirstOrDefault(x => x.StudentId == studentId);
            if (s != null)
            {
                foreach(var course in s.Courses)
                {
                    courses.Add(Utility.EFEntityToModel.CourseToDTO(course));
                }
            }

            return courses;
        }

        public bool RegisterCourse(int studentid, int courseId)
        {
            try
            {
                Student? s = context.Students.FirstOrDefault(x => x.StudentId == studentid);
                if (s != null)
                {
                    Course course = context.Courses.FirstOrDefault(x => x.CourseId == courseId);
                    if (course != null)
                    {
                        s.Courses.Add(course);
                        return true;
                    }
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return false;
        }

        public bool UnRegisterCourse(int studentid, int courseId)
        {
            try
            {
                Student? s = context.Students.FirstOrDefault(x => x.StudentId == studentid);
                if (s != null)
                {
                    Course course = s.Courses.FirstOrDefault(x => x.CourseId == courseId);
                    if (course != null)
                    {
                        s.Courses.Remove(course);
                        return true;
                    }
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return false;

        }

        void IStudentRepository.AddStudent(DataTransferObjects.Models.Student student)
        {
            throw new NotImplementedException();
        }

        void IStudentRepository.DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        List<DataTransferObjects.Models.Student> IStudentRepository.GetAllStudents()
        {
            List<DataTransferObjects.Models.Student> students = new List<DataTransferObjects.Models.Student>();
            foreach(var student in context.Students.ToList())
            {
                students.Add(Utility.EFEntityToModel.StudentToDTO(student));
            }
            return students;
        }

        DataTransferObjects.Models.Student IStudentRepository.GetStudentById(int id)
        {
            Student? s = context.Students.FirstOrDefault(s => s.StudentId == id);
            DataTransferObjects.Models.Student student = null;
            if (s != null)
            {
                student = Utility.EFEntityToModel.StudentToDTO(s);
            }
            return student;

        }

        void IStudentRepository.UpdateStudent(DataTransferObjects.Models.Student student)
        {
            throw new NotImplementedException();
        }
    }
}
