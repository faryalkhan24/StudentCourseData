namespace DataLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentRepository { get; }
        ICourseRepository CourseRepository { get; }
        void Save();
    }
}
