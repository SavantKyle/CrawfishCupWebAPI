using System.Configuration;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using DataProvider;
using DataProvider.Contracts;

namespace CrawfishCupWebAPI
{
    public class AutofacWebApiConfig
    {
        public static IContainer Container;  
  
        public static void Initialize(HttpConfiguration config)  
        {  
            Initialize(config, RegisterServices(new ContainerBuilder()));  
        }  
  
        public static void Initialize(HttpConfiguration config, IContainer container)  
        {  
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);  
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterApiControllers(assembly);  
  
            builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Facade")).AsImplementedInterfaces();

            builder.RegisterType<Database>().As<IDatabase>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.Register(
                    x => new UnitOfWork(ConfigurationManager.ConnectionStrings["crawfishcup"].ConnectionString)).InstancePerDependency()
                    .As<IUnitOfWork>();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();  
  
            return Container;  
        }
    }
}