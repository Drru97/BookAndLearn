using System;
using System.Threading.Tasks;
using BookAndLearn.Common.Entities.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookAndLearn.DataAccess.Repositories
{
    public class UserRepository : IDisposable
    {
        private readonly IdentityContext _identityContext;
        private readonly UserManager<IdentityUser> _userManager;

        public UserRepository()
        {
            _identityContext = new IdentityContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_identityContext));

        }

        public async Task<IdentityResult> RegisterUser(UserModel user)
        {
            var identityUser = new IdentityUser(user.UserName);
            var result = await _userManager.CreateAsync(identityUser, user.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string username, string password)
        {
            var identityUser = await _userManager.FindAsync(username, password);
            return identityUser;
        }

        public void Dispose()
        {
            _identityContext.Dispose();
            _userManager.Dispose();
        }
    }
}
