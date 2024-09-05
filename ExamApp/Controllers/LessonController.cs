using ExamApp.Interfaces;
using ExamApp.Services;
using ExamApp.ViewModels.Lesson;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService) { _lessonService = lessonService; }

        public async Task<IActionResult> Index()
        {
            return View(await _lessonService.GetLessons());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LessonAddVM lesson)
        {
            if (!ModelState.IsValid)
            {
                return View(lesson);
            }
            bool isExist = await _lessonService.GetLessonByName(lesson.Name) != null ? true : false;
            if (isExist)
            {
                ModelState.AddModelError("Name", "Lesson with this name is exist");
                return View(lesson);
            }
            await _lessonService.CreateLesson(lesson);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string code)
        {
            var data = await _lessonService.GetLessonByCode(code);
            if (data == null) return NotFound();
            await _lessonService.DeleteLesson(data);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(string code)
        {
            var data = await _lessonService.GetLessonByCode(code); 
            if (data == null) return NotFound();
            LessonUpdateVM model = new() { Code = code, Name = data.Name, Classroom = data.Classroom, TeacherName = data.TeacherName, TeacherSurname = data.TeacherSurname };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string code, LessonUpdateVM lesson)
        {
            if (!ModelState.IsValid)
            {
                return View(lesson);
            }
            var data = await _lessonService.GetLessonByCode(code);
            if (data == null) return NotFound();

            await _lessonService.UpdateLesson(data, lesson);
            return RedirectToAction("Index");
        }
    }
}
