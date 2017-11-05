using BookAndLearn.Services.Abstract;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BookAndLearn.Web.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonsService _lessonsService;

        public LessonController(ILessonsService lessonsService)
        {
            _lessonsService = lessonsService;
        }
        // GET: Lesson
        public async Task<ActionResult> Index()
        {
            //useless, because noone actualy wanna attend university at monday.
            var mondayLessons = await _lessonsService.GetLessonsByDayAsync(DayOfWeek.Monday);
            return View(mondayLessons);
        }
    }
}