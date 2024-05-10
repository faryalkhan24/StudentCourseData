using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Utility
{
    public  static class ModelToEFUtility
    {
        public static DataLayer.Models.Student DTOToStudent(DataTransferObjects.Models.Student student)
        {
            DataLayer.Models.Student entityModel = new DataLayer.Models.Student();
            entityModel.StudentId = student.Id;
            entityModel.FirstName = student.FirstName;
            entityModel.Surname = student.Surname;
            entityModel.Gender = student.Gender;
            entityModel.Dob = student.Dob;
            entityModel.Address1 = student.Address1;
            entityModel.Address2 = student.Address2 != null ? student.Address2 : string.Empty;
            entityModel.Address3 = student.Address3 != null ? student.Address3 : string.Empty;
            return entityModel;
        }

        public static DataLayer.Models.Course DTOToCourse(DataTransferObjects.Models.Course course)
        {
            DataLayer.Models.Course entityModel = new DataLayer.Models.Course();
            entityModel.CourseId = course.Id;
            entityModel.CourseCode = course.CourseCode;
            entityModel.CourseName = course.CourseName;
            entityModel.TeacherName = course.TeacherName;
            entityModel.StartDate = course.StartDate;
            entityModel.EndDate = course.EndDate;
            entityModel.MaxCapacity = course.MaxCapacity;
            entityModel.CurrentCapacity = course.CurrentCapacity;
            return entityModel;
        }

    }
}
