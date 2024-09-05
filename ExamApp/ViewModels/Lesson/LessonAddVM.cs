using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamApp.ViewModels.Lesson
{
    public class LessonAddVM
    {
        [Required(ErrorMessage = "Code is required.")]
        [StringLength(3, ErrorMessage = "Code must be 3 characters long.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(30, ErrorMessage = "Name cannot exceed 30 characters.")]
        public string Name { get; set; }

        [Range(1, 99, ErrorMessage = "Classroom must be between 1 and 99.")]
        public decimal Classroom { get; set; }

        [Required(ErrorMessage = "Teacher name is required.")]
        [StringLength(20, ErrorMessage = "Teacher name cannot exceed 20 characters.")]
        public string TeacherName { get; set; }

        [Required(ErrorMessage = "Teacher surname is required.")]
        [StringLength(20, ErrorMessage = "Teacher surname cannot exceed 20 characters.")]
        public string TeacherSurname { get; set; }
    }
}
