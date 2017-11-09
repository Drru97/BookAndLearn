using System.Threading.Tasks;
using System.Web.Http;
using BookAndLearn.Common.Entities.Identity;
using BookAndLearn.DataAccess.Repositories;
using Microsoft.AspNet.Identity;

namespace BookAndLearn.API.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        // POST /api/user
        [HttpPost]
        public async Task<IHttpActionResult> Register(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identityResult = await _userRepository.RegisterUser(user);
            var errorResult = GetErrorResult(identityResult);

            return errorResult ?? Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult identityResult)
        {
            if (identityResult == null)
            {
                return InternalServerError();
            }

            if (!identityResult.Succeeded)
            {
                if (identityResult.Errors != null)
                {
                    foreach (var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
