using Autofac;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Services;
using ItAcademy.SchoolAdmin.DataAccess;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Services;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Autofac
{
    public class PhoneServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SchoolContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<PhoneDbService>().As<IPhoneDbService>().InstancePerLifetimeScope();
            builder.RegisterType<PhoneService>().As<IPhoneService>().InstancePerLifetimeScope();
        }
    }
}
