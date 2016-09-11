using Microsoft.Owin.Hosting;
using System;

namespace Octopus.Standlone.Webapp
{
    public class OwinService
    {
        private IDisposable _webApp;

        public void Start()
        {
            _webApp = WebApp.Start<Startup>("http://localhost:9000");
        }

        public void Stop()
        {
            _webApp.Dispose();
        }
    }
}
