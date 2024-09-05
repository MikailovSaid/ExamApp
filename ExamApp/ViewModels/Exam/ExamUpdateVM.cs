using System.ComponentModel.DataAnnotations;

namespace ExamApp.ViewModels.Exam
{
    public class ExamUpdateVM
    {
        [Required(ErrorMessage = "Lesson code is required.")]
        [StringLength(3, ErrorMessage = "Lesson code must be 3 characters long.")]
        public string LessonCode { get; set; }

        [Required(ErrorMessage = "Student number is required.")]
        [Range(0, 99999, ErrorMessage = "Student number must be between 0 and 99999.")]
        public decimal StudentNumber { get; set; }

        [Required(ErrorMessage = "Exam date is required.")]
        public DateTime Date { get; set; }

        [Range(0, 9, ErrorMessage = "Price must be a decimal between 0 and 9.")]
        public decimal Price { get; set; }
    }
}
