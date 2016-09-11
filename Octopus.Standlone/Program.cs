using Microsoft.Owin.Hosting;
using Octopus.Standlone.Webapp;
using System;
using System.Net.Http;
using Topshelf;

namespace Octopus.Standlone
{
    class Program
    {
        static void Main(string[] args)
        {
            //return (int)HostFactory.Run(x =>
            //{
            //    x.Service<OwinService>(s =>
            //    {
            //        s.ConstructUsing(() => new OwinService());
            //        s.WhenStarted(service => service.Start());
            //        s.WhenStopped(service => service.Stop());
            //    });
            //});

            //string baseAddress = "http://localhost:9000/";

            //// Start OWIN host 
            //using (WebApp.Start<Startup>(url: baseAddress))
            //{
            //    // Create HttpCient and make a request to api/values 
            //    HttpClient client = new HttpClient();

            //    var response = client.GetAsync(baseAddress + "api/helloworld").Result;

            //    Console.WriteLine(response);
            //    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            //}

            //Console.ReadLine();
            using (Microsoft.Owin.Hosting.WebApp.Start<Startup>("http://*:6060"))
            {
                Console.WriteLine("Press [enter] to quit...");
                Console.ReadLine();
            }
        }
    }
}
