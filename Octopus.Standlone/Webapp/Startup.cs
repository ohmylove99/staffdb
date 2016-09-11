using Autofac;
using Autofac.Integration.WebApi;
using Octopus.Standlone.Service;
using Octopus.Standlone.Swagger;
using Owin;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Octopus.Standlone.Webapp
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
            ConfigHandles(config);
            //Json
            ConfigJson(config);
            //Swagger
            ConfigSwagger(config);
            //Cors
            ConfigCors(config, appBuilder);
            //Autofac
            ConfigAutofac(config);

            appBuilder.UseWebApi(config);
        }
        public void ConfigHandles(HttpConfiguration config)
        {
            config.MessageHandlers.Add(new StreamReadingDelegatingHandler());
        }
        public void ConfigJson(HttpConfiguration config)
        {
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
        public void ConfigSwagger(HttpConfiguration config)
        {
            SwaggerConfig.Register(config);
        }

        public void ConfigCors(HttpConfiguration config, IAppBuilder appBuilder)
        {
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }

        public IContainer ConfigAutofac(HttpConfiguration config)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //var services = Assembly.Load("Octopus.Standlone");
            //builder.RegisterAssemblyTypes(services);
            builder.Register(c => (new HttpContextWrapper(HttpContext.Current) as HttpContextBase))
            .As<HttpContextBase>()
            .InstancePerRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerRequest();

            builder.RegisterType<HelloWorldService>().As<IHelloWorldService>().Named<IHelloWorldService>("HelloWorldService").SingleInstance();


            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;
            return container;
        }
    }
}
