using log4net;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Octopus.Standlone.Webapp
{
    public class StreamReadingDelegatingHandler : DelegatingHandler
    {
        private static ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            Stream strea = new MemoryStream();
            await request.Content.CopyToAsync(strea);
            strea.Position = 0;
            StreamReader reader = new StreamReader(strea);
            String res = reader.ReadToEnd();
            Log.Info("request content: " + res);

            return response;
        }
    }
}
