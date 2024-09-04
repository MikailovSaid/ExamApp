using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamApp.Models
{
    public class Lesson
    {
        [Key]
        [Column(TypeName = "char(3)")]
        public string Code { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(2,0)")]
        public decimal Classroom { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string TeacherName { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string TeacherSurname { get; set; }

        public List<Exam> Exams { get; set; }
    }
}
