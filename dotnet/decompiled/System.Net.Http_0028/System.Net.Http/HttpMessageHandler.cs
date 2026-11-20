using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

public abstract class HttpMessageHandler : IDisposable
{
	protected HttpMessageHandler()
	{
		if (!System.Net.NetEventSource.Log.IsEnabled())
		{
		}
	}

	protected internal virtual HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		throw new NotSupportedException(System.SR.Format("net_http_missing_sync_implementation", GetType(), "HttpMessageHandler", "Send"));
	}

	protected internal abstract Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);

	protected virtual void Dispose(bool disposing)
	{
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
