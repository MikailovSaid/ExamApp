using ExamApp.Data;
using ExamApp.Interfaces;
using ExamApp.Models;
using ExamApp.ViewModels.Exam;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Services
{
    public class ExamService : IExamService
    {
        private readonly AppDbContext _context;
        public ExamService(AppDbContext context) { _context = context; }
        public async Task CreateExam(ExamAddVM model)
        {
            Exam exam = new() { LessonCode = model.LessonCode, StudentNumber = model.StudentNumber, Price = model.Price, Date = model.Date };
            await _context.AddAsync(exam);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExam(Exam exam)
        {
            _context.Remove(exam);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistExam(string lessonCode, decimal studentNumber)
        {
            var data = await _context.Exams
                .FirstOrDefaultAsync(x => x.LessonCode == lessonCode && x.StudentNumber == studentNumber);

            if (data != null) return true;

            return false;
        }

        public async Task<Exam> GetExamById(int id)
        {
            return await _context.Exams.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Exam>> GetExams()
        {
            return await _context.Exams.ToListAsync();
        }

        public async Task<List<Exam>> GetExamsByLesson(string lessonCode)
        {
            return await _context.Exams.AsNoTracking().Where(x => x.LessonCode == lessonCode).ToListAsync();
        }

        public async Task<List<Exam>> GetExamsByStudent(decimal studentNumber)
        {
            return await _context.Exams.AsNoTracking().Where(x => x.StudentNumber == studentNumber).ToListAsync();
        }

        public async Task UpdateExam(Exam existing, ExamUpdateVM model)
        {
            _context.Entry(existing).State = EntityState.Detached;
            Exam exam = new()
            {
                Id = existing.Id,
                Date = model.Date,
                StudentNumber = model.StudentNumber,
                Price = model.Price,
                LessonCode = model.LessonCode
            };
            _context.Exams.Update(exam);
            await _context.SaveChangesAsync();
        }
    }
}
