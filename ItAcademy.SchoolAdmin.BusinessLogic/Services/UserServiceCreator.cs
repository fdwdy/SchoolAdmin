using Autofac;
using ItAcademy.SchoolAdmin.BusinessLogic.Autofac;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess;
using ItAcademy.SchoolAdmin.DataAccess.Services;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Services
{
    public class UserServiceCreator : IUserServiceCreator
    {
        public IUserService CreateUserService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new IdentityServiceModule());
            var container = builder.Build();
            var iuow = container.Resolve<SchoolContext>();
            return new UserService(new IdentityUnitOfWork(iuow));
        }
    }
}
