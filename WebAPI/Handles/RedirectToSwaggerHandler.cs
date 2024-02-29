using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Web;

namespace WebAPI.Handles
{
    public class RedirectToSwaggerHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            if (request.RequestUri.PathAndQuery == "/") {
                var response = request.CreateResponse(HttpStatusCode.Found);
                response.Headers.Location = new Uri("/swagger", UriKind.Relative);
                return Task.FromResult(response);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}