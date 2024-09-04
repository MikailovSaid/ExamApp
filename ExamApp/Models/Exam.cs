using System.ComponentModel.DataAnnotations.Schema;

namespace ExamApp.Models
{
    public class Exam
    {
        public int Id { get; set; } // Primary Key

        [Column(TypeName = "char(3)")]
        public string LessonCode { get; set; }

        [ForeignKey("LessonCode")]
        public Lesson Lesson { get; set; }

        [Column(TypeName = "decimal(5,0)")]
        public decimal StudentNumber { get; set; }

        [ForeignKey("StudentNumber")]
        public Student Student { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(1,0)")]
        public decimal Price { get; set; }
    }
}
