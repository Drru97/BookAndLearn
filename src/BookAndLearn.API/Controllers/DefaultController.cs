using System.Collections.Generic;
using System.Web.Http;

namespace BookAndLearn.API.Controllers
{
    public class DefaultController : ApiController
    {
        // GET /api/dafault
        public IEnumerable<string> GetAll()
        {
            return new[] { "Хуяк, ", "хуяк ", "і ", "51", "!!!" };
        }
    }
}
