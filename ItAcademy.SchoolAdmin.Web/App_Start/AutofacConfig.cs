using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Mapping;
using ItAcademy.SchoolAdmin.BusinessLogic.Services;
using ItAcademy.SchoolAdmin.BusinessLogic.SignalR;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.DataAccess.Services;
using ItAcademy.SchoolAdmin.Web.Mapping;

namespace ItAcademy.SchoolAdmin.Web.App_Start
{
    public class AutofacConfig
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EmployeeHub>().AsSelf().InstancePerRequest();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerHttpRequest();
            builder.RegisterType<SubjectService>().As<ISubjectService>().InstancePerHttpRequest();
            builder.RegisterDecorator<EmployeeServiceDecorator, IEmployeeService>();
            builder.RegisterType<EmployeeDbRepository>().As<IRepository<EmployeeDb>>().InstancePerHttpRequest();
            builder.RegisterType<SubjectDbRepository>().As<IRepository<SubjectDb>>().InstancePerHttpRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
            builder.AddAutoMapper(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new AutoMapperBusinessModule());
            builder.RegisterModule(new AutoMapperWebModule());

            var container = builder.Build();
            container.Resolve<MapperConfiguration>();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }
    }
}