﻿using Owin;
using System.Web.Http;

namespace Octopus.Standlone.Webapp
{
    public class Startup
    {
        //public void Configuration(IAppBuilder appBuilder)
        //{
        //    var config = new HttpConfiguration();
        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //        );
        //    config.MessageHandlers.Add(new StreamReadingDelegatingHandler());
        //    appBuilder.UseWebApi(config);
        //}

        public void Configuration(IAppBuilder app)
        {
            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello, world.");
            });
        }
    }
}
