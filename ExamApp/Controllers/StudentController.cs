using ExamApp.Interfaces;
using ExamApp.ViewModels.Student;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _studentService.GetStudents());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentAddVM student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            await _studentService.CreateStudent(student);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(decimal number)
        {
            var data = await _studentService.GetStudentByNumber(number);
            if (data == null) return NotFound();
            await _studentService.DeleteStudent(data);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(decimal number)
        {
            var data = await _studentService.GetStudentByNumber(number);
            if (data == null) return NotFound();
            StudentUpdateVM model = new() { Number = number, Name = data.Name, Surname = data.Surname, Classroom = data.Classroom };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(decimal number, StudentUpdateVM student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            var data = await _studentService.GetStudentByNumber(number);
            if (data == null) return NotFound();

            await _studentService.UpdateStudent(data, student);
            return RedirectToAction("Index");
        }
    }
}
