using ExamApp.Data;
using ExamApp.Interfaces;
using ExamApp.Models;
using ExamApp.ViewModels.Student;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        public StudentService(AppDbContext context) { _context = context; }

        public async Task<List<Student>> GetStudents()
        {
            var datas = await _context.Students.ToListAsync();
            return datas;
        }

        public async Task CreateStudent(StudentAddVM model)
        {
            Student student = new()
            {
                Number = model.Number,
                Name = model.Name,
                Surname = model.Surname,
                Classroom = model.Classroom,
            };
            await _context.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<Student> GetStudentByNumber(decimal number)
        {
            return await _context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Number == number);
        }

        public async Task UpdateStudent(Student existing, StudentUpdateVM model)
        {
            _context.Entry(existing).State = EntityState.Detached;
            Student student = new()
            {
                Number = existing.Number,
                Name = model.Name,
                Surname = model.Surname,
                Classroom = model.Classroom,
            };
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
