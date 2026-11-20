using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auchan.Common.Networking;

public interface IHttpMessageHandler : IDisposable
{
	Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
}
