using DataLayer.Interfaces;
using DataTransferObjects.Models;

namespace ServiceLayer.Services
{
    public class StudentService
    {
        private IUnitOfWork _unitOfWork;
        IStudentRepository _studentRepository;
        public StudentService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
            _studentRepository = _unitOfWork.StudentRepository;
        }

        public IEnumerable<DataTransferObjects.Models.Student> GetAllStudents()
        {
            IEnumerable<Student> studentList = _studentRepository.GetAllStudents();
            return studentList;
        }

        public DataTransferObjects.Models.Student GetStudent(int id)
        {
            Student student = _studentRepository.GetStudentById(id);
            return student;
        }

        public bool RegisterCourse(int studentID, string courseCode)
        {
            //Registering course logic
            var student = _studentRepository.GetStudentById(studentID);

            CourseService courseService = new CourseService(_unitOfWork);
            Course course = courseService.GetCourseByCode(courseCode);

            if (student != null && course != null)
            {
                if (!IsStudentEnrolled(studentID, course.Id) && course.CurrentCapacity < course.MaxCapacity && student.RegisteredCourse < 5)
                {
                    bool courseAdded =_studentRepository.RegisterCourse(studentID, course.Id);
                    if(courseAdded)
                    {
                        courseService.AddStudentInCourse(course);
                        _unitOfWork.Save();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public bool UnRegisterCourse(int studentID, string courseCode)
        {
            var student = _studentRepository.GetStudentById(studentID);

            CourseService courseService = new CourseService(_unitOfWork);
            Course course = courseService.GetCourseByCode(courseCode);

            if (student != null && course != null)
            {
                if (IsStudentEnrolled(studentID, course.Id))
                {
                    bool courseRemoved = _studentRepository.UnRegisterCourse(studentID, course.Id);
                    if (courseRemoved)
                    {
                        courseService.RemoveStudentFromCourse(course);
                        _unitOfWork.Save();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool IsStudentEnrolled(int studentId, int courseId)
        {
            List<Course> courses = GetCoursesForStudent(studentId);
            if (courses.Count > 0)
                return courses.Any(x => x.Id == courseId);
            return false;
        }

        public List<Course> GetCoursesForStudent(int studentID)
        {
            List<Course> courses = _studentRepository.GetCoursesForStudent(studentID);
            return courses;
        }

    }
}
