using ExamApp.Data;
using ExamApp.Interfaces;
using ExamApp.Models;
using ExamApp.ViewModels.Lesson;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Services
{
    public class LessonService : ILessonService
    {
        private readonly AppDbContext _context;
        public LessonService(AppDbContext context) { _context = context; }

        public async Task CreateLesson(LessonAddVM model)
        {
            Lesson lesson = new()
            {
                Classroom = model.Classroom,
                Code = model.Code,
                Name = model.Name,
                TeacherName = model.TeacherName,
                TeacherSurname = model.TeacherSurname,
            };
            await _context.AddAsync(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Lesson>> GetLessons()
        {
            var datas = await _context.Lessons.ToListAsync();
            return datas;
        }

        public async Task<Lesson> GetLessonByCode(string code)
        {
            return await _context.Lessons.AsNoTracking().Include(x => x.Exams).FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<Lesson> GetLessonByName(string name)
        {
            return _context.Lessons.FirstOrDefault(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public async Task DeleteLesson(Lesson lesson)
        {
            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLesson(Lesson existing, LessonUpdateVM model)
        {
            _context.Entry(existing).State = EntityState.Detached;
            Lesson lesson = new()
            {
                Classroom = model.Classroom,
                Code = existing.Code,
                Name = model.Name,
                TeacherName = model.TeacherName,
                TeacherSurname = model.TeacherSurname,
            };
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
        }
    }
}
