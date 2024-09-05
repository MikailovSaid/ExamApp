using ExamApp.Models;
using ExamApp.ViewModels.Student;

namespace ExamApp.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        Task CreateStudent(StudentAddVM student);
        Task DeleteStudent(Student student);
        Task<Student> GetStudentByNumber(decimal number);
        Task UpdateStudent(Student existing, StudentUpdateVM student);
    }
}
