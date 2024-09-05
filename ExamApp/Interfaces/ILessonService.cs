using ExamApp.Models;
using ExamApp.ViewModels.Lesson;

namespace ExamApp.Interfaces
{
    public interface ILessonService
    {
        Task<List<Lesson>> GetLessons();
        Task CreateLesson(LessonAddVM lesson);
        Task<Lesson> GetLessonByCode(string code);
        Task<Lesson> GetLessonByName(string name);
        Task DeleteLesson(Lesson lesson);
        Task UpdateLesson(Lesson existing, LessonUpdateVM lesson);
    }
}
