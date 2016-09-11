using Octopus.Standlone.Swagger;
using Owin;
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
            config.MessageHandlers.Add(new StreamReadingDelegatingHandler());

            SwaggerConfig.Register(config);

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            //ConfigureWindsor(config);

            //ConfigureOAuth(app);

            //WebApiConfig.Register(config, _container);


            appBuilder.UseWebApi(config);
        }
    }
}
