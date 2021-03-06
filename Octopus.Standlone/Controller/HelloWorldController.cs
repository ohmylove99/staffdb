﻿using Octopus.Standlone.Service;
using System.Collections.Generic;
using System.Web.Http;

namespace Octopus.Standlone.Controller
{
    public class HelloWorldController : ApiController
    {
        readonly IHelloWorldService _helloWorldService;
        public HelloWorldController(IHelloWorldService helloWorldService)
        {
            _helloWorldService = helloWorldService;
        }
        [HttpPost]
        public string SayHello(string s)
        {
            return "Hello, World!" + s;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _helloWorldService.FindAll();
        }
        [HttpGet]
        public string Get(int id)
        {
            return _helloWorldService.Find(id);
        }
    }
}
