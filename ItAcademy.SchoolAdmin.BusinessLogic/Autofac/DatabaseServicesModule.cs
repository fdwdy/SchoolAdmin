using Autofac;
using ItAcademy.SchoolAdmin.DataAccess;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.DataAccess.Services;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Autofac
{
    public class DatabaseServicesModule : Module
    {
        public bool ObeySpeedLimit { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SchoolContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<EmployeeDbRepository>().As<IRepository<EmployeeDb>>().InstancePerRequest();
            builder.RegisterType<EmployeeDbRepository>().As<IEmployeeDbService>().InstancePerRequest();
        }
    }
}
