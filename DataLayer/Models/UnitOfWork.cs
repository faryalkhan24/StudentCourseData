using DataLayer.Interfaces;
using System;

namespace DataLayer.Models
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly StudentCourseContext _context;

        public UnitOfWork(StudentCourseContext context)
        {
            _context = context;
        }

        private IStudentRepository _studentRepository;
        public IStudentRepository StudentRepository{
            get
            {
                if(_studentRepository == null)
                {
                    _studentRepository = new StudentRepository(_context);
                }
                return _studentRepository;
            }
        }

        private ICourseRepository _courseRepository;
        public ICourseRepository CourseRepository
        {
            get
            {
                if(_courseRepository == null)
                {
                   _courseRepository = new CourseRepository(_context);
                }
                return _courseRepository;
            }
        } 

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
