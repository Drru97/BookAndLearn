using BookAndLearn.DataAccess.Repositories;
using Ninject.Modules;

namespace BookAndLearn.Web.Infrastructure
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            this.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
        }
    }
}