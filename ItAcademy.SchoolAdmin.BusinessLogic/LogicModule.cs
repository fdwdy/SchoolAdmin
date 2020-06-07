namespace ItAcademy.SchoolAdmin.BusinessLogic
{
    using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
    using ItAcademy.SchoolAdmin.BusinessLogic.Services;
    using ItAcademy.SchoolAdmin.DataAccess;
    using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
    using ItAcademy.SchoolAdmin.DataAccess.Models;
    using ItAcademy.SchoolAdmin.DataAccess.Services;
    using Ninject.Modules;
    using Ninject.Web.Common;

    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<SchoolContext>().ToSelf().InRequestScope();
            Bind<IEmployeeService>().To<EmployeeService>().InRequestScope();
            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            Bind<IRepository<EmployeeDb>>().To<EmployeeDbRepository>().InRequestScope();
        }
    }
}
