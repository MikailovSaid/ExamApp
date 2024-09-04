using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamApp.Models
{
    public class Student
    {
        [Key]
        [Column(TypeName = "decimal(5,0)")]
        public decimal Number { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Surname { get; set; }

        [Column(TypeName = "decimal(2,0)")]
        public decimal Classroom { get; set; }

        public List<Exam>? Exams { get; set; }
    }
}
