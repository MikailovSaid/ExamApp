using ExamApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Exam> Exams { get; set; }
    }
}
