using BookAndLearn.DataAccess.Repositories;
using BookAndLearn.Services.Abstract;
using BookAndLearn.Services.Concrete;
using Ninject.Modules;

namespace BookAndLearn.Web.Infrastructure
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));

            Bind<ILessonsService>().To<LessonsService>();
            Bind<IStudentService>().To<StudentService>();
        }
    }
}