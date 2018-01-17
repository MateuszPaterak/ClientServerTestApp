using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using WebService.Models;

namespace WebService.AutofacConf
{
    public class AutofacWebapiConfig
    {
        private static IContainer Container;
        public static List<Assembly> AssemblyToLoad { get; set; } = new List<Assembly>();
        
        public static void Run()
        {
            Initialize(GlobalConfiguration.Configuration,
                        RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<Repo>().As<IRepo>().InstancePerRequest(); ;
            builder.RegisterType<SaveToCollection>().As<IWriteUserData>().SingleInstance();

            //add plugin assembly
            foreach (var assembly in AssemblyToLoad)
            {
                builder.RegisterAssemblyTypes(assembly)
                    .AsImplementedInterfaces();
            }
            
            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }
    }
}