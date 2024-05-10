using DataLayer.Interfaces;
using DataTransferObjects.Models;
using System.Xml.Serialization;

namespace ServiceLayer.Services
{
    public class CourseService
    {
        private IUnitOfWork _unitOfWork;
        private ICourseRepository _courseRepository;
        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _courseRepository = _unitOfWork.CourseRepository;
        }

        public List<Course> GetAllCourse()
        {
            List<Course> courses = _courseRepository.GetAllCourses();
            return courses;
        }

        public Course GetCourseByCode(string code)
        {
            return _courseRepository.GetCourseByCode(code);
        }

        public void AddStudentInCourse(Course course)
        {
            _courseRepository.AddStudent(course);
        }

        public void RemoveStudentFromCourse(Course course)
        {
            _courseRepository.RemoveStudent(course);
        }

        public bool CreateCourse(Course course)
        {
            try
            {
                bool isCreated = _courseRepository.AddCourse(course);
                _unitOfWork.Save();
                return isCreated;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
