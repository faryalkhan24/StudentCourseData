using Microsoft.AspNetCore.Mvc;
using StudentCourseClient.Models;
using DataTransferObjects.Models;
using ServiceLayer.Services;

namespace StudentCourseClient.Controllers
{
    public class StudentController : Controller
    {
        private StudentService _studentService;
        private CourseService _courseService;

       public StudentController(StudentService studentService, CourseService courseService) {
            _studentService = studentService;
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            var StudentList = _studentService.GetAllStudents().ToList();
            return View(StudentList);
        }

        //[Faryal] Similar steps (See CourseController Create)need to followed in the service and repo layer to add these flows.
        //Links and View are added add front end for the following actions. They just need to be commented out

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return RedirectToAction("Index", "Student");
        //    }
        //    return View(student);
        //}

        //public IActionResult Edit(int StudentID)
        //{
        //    return View(new Student());
        //}

        //[HttpPost]
        //public IActionResult Edit(Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return RedirectToAction("Index", "Student");
        //    }
        //    return View(student);
        //}

        //public IActionResult Delete(int StudentID) {

        //    return RedirectToAction("Index", "Student");
        //}

        public IActionResult RegisterCourse(int studentId)
        {
            var student = _studentService.GetStudent(studentId);
            if (student == null)
            {
                return NotFound();
            }

            // Get all courses
            var allCourses = _courseService.GetAllCourse();

            // Construct view model
            var viewModel = new RegisterCourseModel
            {
                StudentID = studentId,
                StudentName = $"{student.FirstName} {student.Surname}",
                courses = allCourses
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult RegisterCourse(int studentId, string courseCode)
        { 
            try
            {
                bool isRegistered = _studentService.RegisterCourse(studentId, courseCode);
                if (isRegistered)
                    return Ok("Course registered successfully! Please refresh to see changes");
                else
                    return StatusCode(500);
            }
            catch (Exception ex)
            {
                return BadRequest("Error occurred while registering course.");
            }
        }

        public IActionResult UnregisterCourse(int studentId)
        {
            var student = _studentService.GetStudent(studentId);
            var courses = _studentService.GetCoursesForStudent(studentId);

            var viewModel = new RegisterCourseModel
            {
                StudentID = studentId,
                StudentName = $"{student.FirstName} {student.Surname}",
                courses = courses
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UnregisterCourse(int studentId, string courseCode)
        {
            try
            {
                bool isUnRegistered = _studentService.UnRegisterCourse(studentId, courseCode);
                if(isUnRegistered)
                    return Ok("Course unregistered successfully! Please refresh to see changes");
                else
                    return StatusCode(500);
            }
            catch (Exception ex)
            {
                return BadRequest("Error occurred while registering course.");
            }
        }

    }
}
