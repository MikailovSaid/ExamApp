using ExamApp.Interfaces;
using ExamApp.ViewModels.Exam;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamService _examService;
        private readonly ILessonService _lessonService;
        private readonly IStudentService _studentService;
        public ExamController(IExamService examService, ILessonService lessonService, IStudentService studentService) 
        { _examService = examService; _lessonService = lessonService; _studentService = studentService; }

        public async Task<IActionResult> Index()
        {
            return View(await _examService.GetExams());
        }

        public async Task<IActionResult> Create()
        {
            ViewData["LessonCode"] = new SelectList(await _lessonService.GetLessons(), "Code", "Code");
            ViewData["StudentNumber"] = new SelectList(await _studentService.GetStudents(), "Number", "Number");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExamAddVM exam)
        {
            ViewData["LessonCode"] = new SelectList(await _lessonService.GetLessons(), "Code", "Code");
            ViewData["StudentNumber"] = new SelectList(await _studentService.GetStudents(), "Number", "Number");
            if (!ModelState.IsValid) return View(exam);
            if (await _examService.ExistExam(exam.LessonCode, exam.StudentNumber))
            {
                ModelState.AddModelError("","Exam with this Lesson code and Student number exists");
                return View(exam);
            }
            await _examService.CreateExam(exam);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _examService.GetExamById(id);
            if (data == null) { return NotFound(); }

            await _examService.DeleteExam(data);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewData["LessonCode"] = new SelectList(await _lessonService.GetLessons(), "Code", "Code");
            ViewData["StudentNumber"] = new SelectList(await _studentService.GetStudents(), "Number", "Number");
            var data = await _examService.GetExamById(id);
            if (data == null) { return NotFound(); }

            ExamUpdateVM exam = new() { LessonCode = data.LessonCode, StudentNumber = data.StudentNumber, Price = data.Price, Date = data.Date };
            return View(exam);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, ExamUpdateVM exam)
        {
            ViewData["LessonCode"] = new SelectList(await _lessonService.GetLessons(), "Code", "Code");
            ViewData["StudentNumber"] = new SelectList(await _studentService.GetStudents(), "Number", "Number");
            if (!ModelState.IsValid) return View(exam);

            var data = await _examService.GetExamById(id);
            if (data == null) { return NotFound(); }

            await _examService.UpdateExam(data, exam);
            return RedirectToAction("Index");
        }
    }
}
