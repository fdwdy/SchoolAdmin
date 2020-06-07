using AutoMapper;
using Ninject.Modules;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Mapping
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<AutoMapperProfile>();
            });

            var mapper = config.CreateMapper();
            Bind<MapperConfiguration>().ToConstant(config).InSingletonScope();
            Bind<IMapper>().ToConstant(mapper).InSingletonScope();
        }
    }
}
