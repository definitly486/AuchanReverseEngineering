using System;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Networking;
using Xamarin.Android.Net;

namespace Auchan.Android.Common.Network;

internal sealed class AuchanMessageHandler : AndroidMessageHandler, IHttpMessageHandler, IDisposable
{
	public AuchanMessageHandler(CookieContainer cookieContainer)
	{
		base.UseProxy = false;
		base.UseCookies = true;
		base.CookieContainer = cookieContainer;
		base.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
	}

	private bool OnValidationCallback(HttpRequestMessage message, X509Certificate2 certificate, X509Chain chain, SslPolicyErrors errors)
	{
		return true;
	}

	Task<HttpResponseMessage> IHttpMessageHandler.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		return SendAsync(request, cancellationToken);
	}
}
