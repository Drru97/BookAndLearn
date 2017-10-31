using System.Threading.Tasks;
using System.Web.Mvc;
using BookAndLearn.Common.Entities;
using BookAndLearn.DataAccess;
using BookAndLearn.DataAccess.Repositories;

namespace BookAndLearn.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var repo = new Repository<Student>(new BookAndLearnContext());
            var students = await repo.GetAllAsync();

            return View();
        }
    }
}
