using ExamApp.Models;

namespace ExamApp.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        Task CreateStudent(Student student);
        Task DeleteStudent(Student student);
        Task<Student> GetStudentByNumber(decimal number);
        Task UpdateStudent(Student student);
    }
}
