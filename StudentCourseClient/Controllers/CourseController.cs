using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;
using StudentCourseClient.Models;
using DataTransferObjects.Models;

namespace StudentCourseClient.Controllers
{
    public class CourseController : Controller
    {
        private CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }
        
        public IActionResult Index()
        {
            List<Course> courses = _courseService.GetAllCourse();
            return View(courses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                bool isCreated = _courseService.CreateCourse(course);
                if (isCreated)
                {
                    return RedirectToAction("Index", "Course");
                }
            }
            return View(course);
        }

        //[Faryal] Similar steps need to followed in the service and repo layer to add these flows
        //Links and View are added at front end for the following actions.

        //public IActionResult Edit(string courseID) {
        //    return View(new Course());
        //}

        //[HttpPost]
        //public IActionResult Edit(Course course)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return RedirectToAction("Index", "Course");
        //    }
        //    return View(course);
        //}

        //public IActionResult Delete(int courseID) {
        //    return RedirectToAction("Index", "Course");
        //}
    }
}
