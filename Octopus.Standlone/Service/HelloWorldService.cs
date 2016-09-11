using System.Collections.Generic;
namespace Octopus.Standlone.Service
{
    public interface IHelloWorldService
    {
        IEnumerable<string> FindAll();

        string Find(int id);
    }

    public class HelloWorldService : IHelloWorldService
    {
        public IEnumerable<string> FindAll()
        {
            return new[] { "value1", "value2" };
        }

        public string Find(int id)
        {
            return $"value{id}";
        }
    }
}
