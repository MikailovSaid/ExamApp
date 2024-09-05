using System.ComponentModel.DataAnnotations;

namespace ExamApp.ViewModels.Student
{
    public class StudentAddVM
    {
        [Range(0, 99999, ErrorMessage = "Number must be between 0 and 99999.")]
        public decimal Number { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(30, ErrorMessage = "Name cannot exceed 30 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        [StringLength(30, ErrorMessage = "Surname cannot exceed 30 characters.")]
        public string Surname { get; set; }

        [Range(1, 99, ErrorMessage = "Classroom must be between 1 and 99.")]
        public decimal Classroom { get; set; }
    }
}
