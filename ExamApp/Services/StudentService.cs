using ExamApp.Data;
using ExamApp.Interfaces;
using ExamApp.Models;
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

        public async Task CreateStudent(Student student)
        {
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
            return await _context.Students.FirstOrDefaultAsync(s => s.Number == number);
        }

        public async Task UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
