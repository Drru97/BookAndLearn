using System.Web;
using BookAndLearn.DataAccess.Repositories;
using BookAndLearn.Services.Abstract;
using BookAndLearn.Services.Concrete;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject.Modules;
using Microsoft.AspNet.Identity.Owin;

namespace BookAndLearn.Web.Infrastructure
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));

            Bind<ILessonsService>().To<LessonsService>();
            Bind<IStudentService>().To<StudentService>();
            Bind<IGroupService>().To<GroupService>();

            Bind<IUserStore<IdentityUser>>().To<UserStore<IdentityUser>>();
             //   .WithConstructorArgument("context", new IdentityContext());
            Bind<UserManager<IdentityUser>>().ToSelf();

            Bind<HttpContextBase>().ToMethod(ctx => new HttpContextWrapper(HttpContext.Current)).InTransientScope();
            Bind<ApplicationSignInManager>().ToMethod(context =>
            {
                var cbase = new HttpContextWrapper(HttpContext.Current);
                return cbase.GetOwinContext().Get<ApplicationSignInManager>();
            });

            Bind<ApplicationUserManager>().ToSelf();
        }
    }
}
