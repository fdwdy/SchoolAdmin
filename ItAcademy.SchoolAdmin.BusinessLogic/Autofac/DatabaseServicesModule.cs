using Autofac;
using ItAcademy.SchoolAdmin.BusinessLogic.Messaging;
using ItAcademy.SchoolAdmin.DataAccess;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.DataAccess.Services;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Autofac
{
    public class DatabaseServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SchoolContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<MessageManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<MessageSaver>().AsSelf().InstancePerRequest();
            builder.RegisterType<MessageDbService>().As<IMessageDbService>().InstancePerRequest();
            builder.RegisterType<EmployeeDbRepository>().As<IRepository<EmployeeDb>>().InstancePerRequest();
            builder.RegisterType<EmployeeDbRepository>().As<IEmployeeDbService>().InstancePerRequest();
            builder.RegisterType<SubjectDbRepository>().As<IRepository<SubjectDb>>().InstancePerRequest();
            builder.RegisterType<SubjectDbRepository>().As<ISubjectDbService>().InstancePerRequest();
            builder.RegisterType<PositionDbRepository>().As<IRepository<PositionDb>>().InstancePerRequest();
            builder.RegisterType<PositionDbRepository>().As<IPositionDbService>().InstancePerRequest();
            builder.RegisterType<MessageSenderService>().As<IMessageService>().InstancePerRequest();
        }
    }
}
