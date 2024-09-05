using ExamApp.Models;
using ExamApp.ViewModels.Exam;

namespace ExamApp.Interfaces
{
    public interface IExamService
    {
        Task<List<Exam>> GetExams();
        Task<Exam> GetExamById(int id);
        Task CreateExam(ExamAddVM exam);
        Task DeleteExam(Exam exam);
        Task UpdateExam(Exam existing, ExamUpdateVM exam);
        Task<bool> ExistExam(string lessonCode, decimal studentNumber);
        Task<List<Exam>> GetExamsByLesson(string lessonCode);
        Task<List<Exam>> GetExamsByStudent(decimal studentNumber);
    }
}
