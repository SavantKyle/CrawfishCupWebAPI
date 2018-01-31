using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using Autofac;
using Autofac.Integration.WebApi;
using DataProvider;
using DataProvider.Contracts;
using Facade;
using Facade.Contracts;
using Service.Contracts.Services;
using Services.Services;

namespace InversionOfControl
{
    public class DependencyInjection
    {
        public static ContainerBuilder BuildIocContainer(Assembly assembly)
        {
            var builder = new ContainerBuilder();

            //Register the Web API Controllers 
            builder.RegisterApiControllers(assembly).PropertiesAutowired();
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToArray();

            //Register Services
            //builder.RegisterAssemblyTypes(assemblies).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(assemblies).Where(x => x.Name.EndsWith("Facade")).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assemblies).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(assemblies).Where(t => t.Name.EndsWith("Facade")).AsImplementedInterfaces();

            builder.RegisterType<Database>().As<IDatabase>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            //builder.Register(
            //        x => new UnitOfWork(ConfigurationManager.ConnectionStrings["crawfishcup"].ConnectionString)).InstancePerDependency()
            //        .As<IUnitOfWork>();

            return builder;
        }

        public static IContainer RegisterServices(ContainerBuilder builder)
        {

        }
    }
}