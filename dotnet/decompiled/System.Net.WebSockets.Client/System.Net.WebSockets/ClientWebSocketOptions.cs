using System.Collections.Generic;
using System.Net.Http;
using System.Net.Security;
using System.Runtime.Versioning;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace System.Net.WebSockets;

public sealed class ClientWebSocketOptions
{
	private bool _isReadOnly;

	private TimeSpan _keepAliveInterval = System.Net.WebSockets.WebSocketDefaults.DefaultClientKeepAliveInterval;

	private TimeSpan _keepAliveTimeout = System.Net.WebSockets.WebSocketDefaults.DefaultKeepAliveTimeout;

	private bool _useDefaultCredentials;

	private ICredentials _credentials;

	private IWebProxy _proxy;

	private CookieContainer _cookies;

	private int _receiveBufferSize = 4096;

	private RemoteCertificateValidationCallback _remoteCertificateValidationCallback;

	internal X509CertificateCollection _clientCertificates;

	internal WebHeaderCollection _requestHeaders;

	internal List<string> _requestedSubProtocols;

	private Version _version = System.Net.HttpVersion.Version11;

	private HttpVersionPolicy _versionPolicy;

	private bool _collectHttpResponseDetails;

	public Version HttpVersion => _version;

	public HttpVersionPolicy HttpVersionPolicy => _versionPolicy;

	internal WebHeaderCollection RequestHeaders => _requestHeaders ?? (_requestHeaders = new WebHeaderCollection());

	internal List<string> RequestedSubProtocols => _requestedSubProtocols ?? (_requestedSubProtocols = new List<string>());

	[UnsupportedOSPlatform("browser")]
	public bool UseDefaultCredentials => _useDefaultCredentials;

	[UnsupportedOSPlatform("browser")]
	public ICredentials? Credentials => _credentials;

	[UnsupportedOSPlatform("browser")]
	public IWebProxy? Proxy
	{
		get
		{
			return _proxy;
		}
		set
		{
			ThrowIfReadOnly();
			_proxy = value;
		}
	}

	[UnsupportedOSPlatform("browser")]
	public X509CertificateCollection ClientCertificates => _clientCertificates ?? (_clientCertificates = new X509CertificateCollection());

	[UnsupportedOSPlatform("browser")]
	public RemoteCertificateValidationCallback? RemoteCertificateValidationCallback => _remoteCertificateValidationCallback;

	[UnsupportedOSPlatform("browser")]
	public CookieContainer? Cookies => _cookies;

	[UnsupportedOSPlatform("browser")]
	public TimeSpan KeepAliveInterval
	{
		get
		{
			return _keepAliveInterval;
		}
		set
		{
			ThrowIfReadOnly();
			if (value != Timeout.InfiniteTimeSpan && value < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("value", value, System.SR.Format("net_WebSockets_ArgumentOutOfRange_TooSmall", Timeout.InfiniteTimeSpan.ToString()));
			}
			_keepAliveInterval = value;
		}
	}

	[UnsupportedOSPlatform("browser")]
	public TimeSpan KeepAliveTimeout => _keepAliveTimeout;

	[UnsupportedOSPlatform("browser")]
	public WebSocketDeflateOptions? DangerousDeflateOptions { get; }

	[UnsupportedOSPlatform("browser")]
	public bool CollectHttpResponseDetails
	{
		get
		{
			return _collectHttpResponseDetails;
		}
		set
		{
			ThrowIfReadOnly();
			_collectHttpResponseDetails = value;
		}
	}

	internal bool AreCompatibleWithCustomInvoker()
	{
		if (!UseDefaultCredentials && Credentials == null)
		{
			X509CertificateCollection clientCertificates = _clientCertificates;
			if ((clientCertificates == null || clientCertificates.Count == 0) && RemoteCertificateValidationCallback == null && Cookies == null)
			{
				if (Proxy != null)
				{
					return Proxy == WebSocketHandle.DefaultWebProxy.Instance;
				}
				return true;
			}
		}
		return false;
	}

	internal ClientWebSocketOptions()
	{
	}

	[UnsupportedOSPlatform("browser")]
	public void SetRequestHeader(string headerName, string? headerValue)
	{
		ThrowIfReadOnly();
		RequestHeaders.Set(headerName, headerValue);
	}

	internal void SetToReadOnly()
	{
		_isReadOnly = true;
	}

	private void ThrowIfReadOnly()
	{
		if (_isReadOnly)
		{
			throw new InvalidOperationException("net_WebSockets_AlreadyStarted");
		}
	}
}
