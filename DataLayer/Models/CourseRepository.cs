using DataLayer.Interfaces;

namespace DataLayer.Models
{
    public class CourseRepository : ICourseRepository
    {
        StudentCourseContext context;
        public CourseRepository(StudentCourseContext _context) { 
            context = _context;
        }

        public bool AddCourse(DataTransferObjects.Models.Course course)
        {
            Course entityModel = Utility.ModelToEFUtility.DTOToCourse(course);
            try
            {
                context.Courses.Add(entityModel);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public void DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public List<DataTransferObjects.Models.Course> GetAllCourses()
        {
            List<DataTransferObjects.Models.Course> courses = new List<DataTransferObjects.Models.Course>();
            foreach(var course in context.Courses.ToList())
            {
                courses.Add(Utility.EFEntityToModel.CourseToDTO(course));
            }
            return courses;
        }

        public DataTransferObjects.Models.Course GetCourseById(int id)
        {
            DataTransferObjects.Models.Course dtoCourse = null;
            Course? course = context.Courses.FirstOrDefault(x => x.CourseId == id);
            if(course!=null)
            {
                dtoCourse = Utility.EFEntityToModel.CourseToDTO(course);
            }
            return dtoCourse; 
        }

        public void UpdateCourse(DataTransferObjects.Models.Course course)
        {
            throw new NotImplementedException();
        }

        public void AddStudent(DataTransferObjects.Models.Course course)
        {
            try
            {
                Course c = context.Courses.FirstOrDefault(x => x.CourseId == course.Id);
                if(c!=null)
                {
                    c.CurrentCapacity++;
                }
                
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void RemoveStudent(DataTransferObjects.Models.Course course)
        {
            try
            {
                Course c = context.Courses.FirstOrDefault(x => x.CourseId == course.Id);
                if (c != null)
                {
                    c.CurrentCapacity--;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public DataTransferObjects.Models.Course GetCourseByCode(string courseCode)
        {
            DataTransferObjects.Models.Course dtoCourse = null;
            Course? course = context.Courses.FirstOrDefault(x => x.CourseCode == courseCode);
            if (course != null)
            {
                dtoCourse = Utility.EFEntityToModel.CourseToDTO(course);
            }
            return dtoCourse;

        }
    }
}
