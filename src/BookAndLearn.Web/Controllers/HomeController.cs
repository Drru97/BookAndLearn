using System.Threading.Tasks;
using System.Web.Mvc;
using BookAndLearn.Common.Entities;
using BookAndLearn.DataAccess.Repositories;

namespace BookAndLearn.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Student> _studentRepository;

        public HomeController(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var students = await _studentRepository.GetAllAsync();

            return View();
        }
    }
}
