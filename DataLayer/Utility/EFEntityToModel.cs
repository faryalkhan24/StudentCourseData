using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Utility
{
    public static class EFEntityToModel
    {
        public static DataTransferObjects.Models.Student StudentToDTO(DataLayer.Models.Student student)
        {
            DataTransferObjects.Models.Student dto = new DataTransferObjects.Models.Student();
            dto.Id = student.StudentId;
            dto.FirstName = student.FirstName;
            dto.Surname = student.Surname;
            dto.Gender = student.Gender;
            dto.Dob = student.Dob;
            dto.Address1 = student.Address1;
            dto.Address2 = student.Address2 != null ? student.Address2 : string.Empty;
            dto.Address3 = student.Address3 != null ? student.Address3 : string.Empty;
            dto.RegisteredCourse = student.Courses.Count;
            return dto;
        }

        public static DataTransferObjects.Models.Course CourseToDTO(DataLayer.Models.Course course)
        {
            DataTransferObjects.Models.Course dto = new DataTransferObjects.Models.Course();
            dto.Id = course.CourseId;
            dto.CourseCode = course.CourseCode;
            dto.CourseName = course.CourseName;
            dto.TeacherName = course.TeacherName;
            dto.StartDate = course.StartDate;
            dto.EndDate = course.EndDate;
            dto.MaxCapacity = course.MaxCapacity;
            dto.CurrentCapacity = course.CurrentCapacity;
            return dto;
        }
    }
}
