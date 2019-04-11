using Autofac;
using Autofac.Integration.WebApi;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VehicleDAL;

namespace VehicleAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        static readonly ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string jsonUserFile = ConfigurationManager.AppSettings["usersJsonFile"];
            string jsonVehicleFile = ConfigurationManager.AppSettings["vehiclesJsonFile"];

            var builder = new ContainerBuilder();
            builder.RegisterInstance<ILog>(_logger);
            builder.RegisterType<JsonPoweredDAL>().As<IVehicleDAL>()
                    .WithParameter(new NamedParameter("pathToUsersJsonFile", HostingEnvironment.MapPath(jsonUserFile)))
                    .WithParameter(new NamedParameter("pathToVehiclesJsonFile", HostingEnvironment.MapPath(jsonVehicleFile)));

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            _logger.Info("Autofac configuration finished...exiting Application_Start()...");
        }
    }
}
