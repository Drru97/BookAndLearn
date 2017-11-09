using Microsoft.AspNet.Identity.EntityFramework;

namespace BookAndLearn.DataAccess
{
    public class IdentityContext : IdentityDbContext<IdentityUser>
    {
        public IdentityContext() : base("name=BookAndLearn", throwIfV1Schema:false)
        {
        }
    }
}
