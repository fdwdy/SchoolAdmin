using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using ItAcademy.SchoolAdmin.BusinessLogic.Autofac;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Mapping;
using ItAcademy.SchoolAdmin.BusinessLogic.Services;
using ItAcademy.SchoolAdmin.BusinessLogic.SignalR;
using ItAcademy.SchoolAdmin.DataAccess;
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
            builder.RegisterType<SchoolContext>().AsSelf().InstancePerRequest();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SchoolHub>().As<ISchoolHub>().InstancePerRequest();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerRequest();
            builder.RegisterType<SubjectService>().As<ISubjectService>().InstancePerRequest();
            builder.RegisterType<TeacherService>().As<ITeacherService>().InstancePerRequest();
            builder.RegisterType<PositionService>().As<IPositionService>().InstancePerRequest();
            builder.RegisterType<WorkerService>().As<IWorkerService>().InstancePerRequest();
            builder.RegisterType<TeacherDbService>().As<ITeacherDbService>().InstancePerRequest();
            builder.RegisterType<WorkerDbService>().As<IWorkerDbService>().InstancePerRequest();
            builder.RegisterDecorator<EmployeeContextModificationNotifyingServiceDecorator, IEmployeeService>();
            builder.RegisterDecorator<SubjectContextModificationNotifyingServiceDecorator, ISubjectService>();
            builder.RegisterDecorator<PositionContextModificationNotifyingServiceDecorator, IPositionService>();
            builder.RegisterType<EmployeeDbRepository>().As<IRepository<EmployeeDb>>().InstancePerRequest();
            builder.RegisterType<SubjectDbRepository>().As<IRepository<SubjectDb>>().InstancePerRequest();
            builder.RegisterType<PositionDbRepository>().As<IRepository<PositionDb>>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.AddAutoMapper(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new DatabaseServicesModule());
            builder.RegisterModule(new AutoMapperBusinessModule());
            builder.RegisterModule(new AutoMapperWebModule());

            var container = builder.Build();
            container.Resolve<MapperConfiguration>();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }
    }
}