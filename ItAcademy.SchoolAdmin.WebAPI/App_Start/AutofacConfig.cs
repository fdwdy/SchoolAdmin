using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using ItAcademy.SchoolAdmin.BusinessLogic.Autofac;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Mapping;
using ItAcademy.SchoolAdmin.BusinessLogic.Services;
using ItAcademy.SchoolAdmin.BusinessLogic.SignalR;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Services;
using System.Reflection;

namespace ItAcademy.SchoolAdmin.WebAPI.App_Start
{
    public class AutofacConfig
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SchoolHub>().As<ISchoolHub>().InstancePerRequest();
            builder.RegisterModule(new DatabaseServicesModule());
            builder.RegisterDecorator<EmployeeContextModificationNotifyingServiceDecorator, IEmployeeService>();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new AutoMapperBusinessModule());

            var container = builder.Build();
            container.Resolve<MapperConfiguration>();
            return container;
        }
    }
}