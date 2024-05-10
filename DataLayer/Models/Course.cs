using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseCode { get; set; } = null!;

    public string CourseName { get; set; } = null!;

    public string TeacherName { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int MaxCapacity { get; set; }

    public int CurrentCapacity { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
