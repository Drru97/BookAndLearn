using BookAndLearn.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookAndLearn.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentServices;

        public StudentController(IStudentService studentService)
        {
            _studentServices = studentService;
        }
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Search(string searchString)
        {
            var searchResults = await _studentServices.SearchStudents(searchString);
            return View(searchResults);
        }
    }
}