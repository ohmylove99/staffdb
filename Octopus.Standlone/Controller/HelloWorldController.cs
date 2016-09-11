using System.Web.Http;

namespace Octopus.Standlone.Controller
{
    public class HelloWorldController : ApiController
    {
        public string Get()
        {
            return "Hello, World!";
        }
    }
}
