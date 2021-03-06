﻿using Microsoft.Owin.Hosting;
using System;

namespace Octopus.Standlone.Webapp
{
    public class OwinService
    {
        public const string BaseUrl = "http://*:6060";

        private IDisposable _webApp;

        public void Start()
        {
            _webApp = WebApp.Start<Startup>(BaseUrl);
        }

        public void Stop()
        {
            _webApp.Dispose();
        }
    }
}
