using Autofac;
using ItAcademy.SchoolAdmin.DataAccess;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Autofac
{
    public class IdentityServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SchoolContext>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
