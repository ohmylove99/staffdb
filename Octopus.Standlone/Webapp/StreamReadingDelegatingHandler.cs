using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Octopus.Standlone.Webapp
{
    public class StreamReadingDelegatingHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var stream = request.Content.ReadAsStreamAsync().Result;
            var content = new StreamReader(stream).ReadToEnd();
            stream.Seek(0, SeekOrigin.Begin);
            Console.WriteLine("Content is " + content);

            return base.SendAsync(request, cancellationToken);
        }
    }
}
