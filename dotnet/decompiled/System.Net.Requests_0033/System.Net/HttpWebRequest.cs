using System.IO;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net;

public class HttpWebRequest : WebRequest, ISerializable
{
	[Flags]
	private enum Booleans : uint
	{
		AllowAutoRedirect = 1u,
		AllowWriteStreamBuffering = 2u,
		ExpectContinue = 4u,
		ProxySet = 0x10u,
		UnsafeAuthenticatedConnectionSharing = 0x40u,
		IsVersionHttp10 = 0x80u,
		SendChunked = 0x100u,
		EnableDecompression = 0x200u,
		IsTunnelRequest = 0x400u,
		IsWebSocketRequest = 0x800u,
		Default = 7u
	}

	private sealed class HttpClientParameters
	{
		public readonly bool Async;

		public readonly DecompressionMethods AutomaticDecompression;

		public readonly bool AllowAutoRedirect;

		public readonly int MaximumAutomaticRedirections;

		public readonly int MaximumResponseHeadersLength;

		public readonly bool PreAuthenticate;

		public readonly int ReadWriteTimeout;

		public readonly TimeSpan Timeout;

		public readonly SecurityProtocolType SslProtocols;

		public readonly bool CheckCertificateRevocationList;

		public readonly ICredentials Credentials;

		public readonly IWebProxy Proxy;

		public readonly RemoteCertificateValidationCallback ServerCertificateValidationCallback;

		public readonly X509CertificateCollection ClientCertificates;

		public readonly CookieContainer CookieContainer;

		public readonly ServicePoint ServicePoint;

		public readonly TimeSpan ContinueTimeout;

		public readonly TokenImpersonationLevel ImpersonationLevel;

		public HttpClientParameters(HttpWebRequest webRequest, bool async)
		{
			Async = async;
			AutomaticDecompression = webRequest.AutomaticDecompression;
			AllowAutoRedirect = webRequest.AllowAutoRedirect;
			MaximumAutomaticRedirections = webRequest.MaximumAutomaticRedirections;
			MaximumResponseHeadersLength = webRequest.MaximumResponseHeadersLength;
			PreAuthenticate = webRequest.PreAuthenticate;
			ReadWriteTimeout = webRequest.ReadWriteTimeout;
			Timeout = ((webRequest.Timeout == -1) ? System.Threading.Timeout.InfiniteTimeSpan : TimeSpan.FromMilliseconds(webRequest.Timeout));
			SslProtocols = ServicePointManager.SecurityProtocol;
			CheckCertificateRevocationList = ServicePointManager.CheckCertificateRevocationList;
			Credentials = webRequest._credentials;
			Proxy = webRequest._proxy;
			ServerCertificateValidationCallback = webRequest.ServerCertificateValidationCallback ?? ServicePointManager.ServerCertificateValidationCallback;
			ClientCertificates = webRequest._clientCertificates;
			CookieContainer = webRequest._cookieContainer;
			ServicePoint = webRequest._servicePoint;
			ContinueTimeout = TimeSpan.FromMilliseconds(webRequest.ContinueTimeout);
			ImpersonationLevel = webRequest.ImpersonationLevel;
		}

		public bool Matches(HttpClientParameters requestParameters)
		{
			if (Async == requestParameters.Async && AutomaticDecompression == requestParameters.AutomaticDecompression && AllowAutoRedirect == requestParameters.AllowAutoRedirect && MaximumAutomaticRedirections == requestParameters.MaximumAutomaticRedirections && MaximumResponseHeadersLength == requestParameters.MaximumResponseHeadersLength && PreAuthenticate == requestParameters.PreAuthenticate && ReadWriteTimeout == requestParameters.ReadWriteTimeout && Timeout == requestParameters.Timeout && SslProtocols == requestParameters.SslProtocols && CheckCertificateRevocationList == requestParameters.CheckCertificateRevocationList && ContinueTimeout == requestParameters.ContinueTimeout && Credentials == requestParameters.Credentials && Proxy == requestParameters.Proxy && (object)ServerCertificateValidationCallback == requestParameters.ServerCertificateValidationCallback && ClientCertificates == requestParameters.ClientCertificates && CookieContainer == requestParameters.CookieContainer && ServicePoint == requestParameters.ServicePoint)
			{
				return ImpersonationLevel == requestParameters.ImpersonationLevel;
			}
			return false;
		}

		public bool AreParametersAcceptableForCaching()
		{
			if (Credentials == null && Proxy == WebRequest.DefaultWebProxy && ServerCertificateValidationCallback == null && ClientCertificates == null && CookieContainer == null)
			{
				return ServicePoint == null;
			}
			return false;
		}
	}

	private WebHeaderCollection _webHeaderCollection = new WebHeaderCollection();

	private readonly Uri _requestUri;

	private string _originVerb = HttpMethod.Get.Method;

	private int _continueTimeout = 350;

	private bool _allowReadStreamBuffering;

	private CookieContainer _cookieContainer;

	private ICredentials _credentials;

	private IWebProxy _proxy = WebRequest.DefaultWebProxy;

	private Task<HttpResponseMessage> _sendRequestTask;

	private HttpRequestMessage _sendRequestMessage;

	private static int _defaultMaxResponseHeadersLength = 64;

	private static int _defaultMaximumErrorResponseLength = -1;

	private bool _beginGetResponseCalled;

	private bool _endGetResponseCalled;

	private int _maximumAllowedRedirections = 50;

	private int _maximumResponseHeadersLen = _defaultMaxResponseHeadersLength;

	private ServicePoint _servicePoint;

	private int _timeout = 100000;

	private int _readWriteTimeout = 300000;

	private bool _hostHasPort;

	private Uri _hostUri;

	private Stream _requestStream;

	private TaskCompletionSource<WebResponse> _responseOperation;

	private AsyncCallback _responseCallback;

	private volatile bool _abortCalled;

	private CancellationTokenSource _sendRequestCts;

	private X509CertificateCollection _clientCertificates;

	private Booleans _booleans = Booleans.Default;

	private bool _pipelined = true;

	private bool _preAuthenticate;

	private DecompressionMethods _automaticDecompression;

	private static readonly object s_syncRoot = new object();

	private static volatile HttpClient s_cachedHttpClient;

	private static HttpClientParameters s_cachedHttpClientParameters;

	private bool _disposeRequired;

	private HttpClient _httpClient;

	private static RequestCachePolicy _defaultCachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);

	private static bool _isDefaultCachePolicySet;

	private static readonly string[] s_wellKnownContentHeaders = new string[10] { "Content-Disposition", "Content-Encoding", "Content-Language", "Content-Length", "Content-Location", "Content-MD5", "Content-Range", "Content-Type", "Expires", "Last-Modified" };

	public int MaximumResponseHeadersLength => _maximumResponseHeadersLen;

	public int MaximumAutomaticRedirections => _maximumAllowedRedirections;

	public int ContinueTimeout => _continueTimeout;

	public override int Timeout
	{
		get
		{
			return _timeout;
		}
		set
		{
			if (value < 0 && value != -1)
			{
				throw new ArgumentOutOfRangeException("value", "net_io_timeout_use_ge_zero");
			}
			_timeout = value;
		}
	}

	public Uri Address => _requestUri;

	public string Host
	{
		get
		{
			Uri uri = _hostUri ?? Address;
			if ((!(_hostUri == null) && _hostHasPort) || !Address.IsDefaultPort)
			{
				return $"{uri.Host}:{uri.Port}";
			}
			return uri.Host;
		}
	}

	public bool KeepAlive { get; } = true;

	public DecompressionMethods AutomaticDecompression => _automaticDecompression;

	public virtual bool AllowWriteStreamBuffering => (_booleans & Booleans.AllowWriteStreamBuffering) != 0;

	public virtual bool AllowAutoRedirect
	{
		get
		{
			return (_booleans & Booleans.AllowAutoRedirect) != 0;
		}
		set
		{
			if (value)
			{
				_booleans |= Booleans.AllowAutoRedirect;
			}
			else
			{
				_booleans &= ~Booleans.AllowAutoRedirect;
			}
		}
	}

	public override bool PreAuthenticate => _preAuthenticate;

	public static int DefaultMaximumErrorResponseLength => _defaultMaximumErrorResponseLength;

	public new static RequestCachePolicy? DefaultCachePolicy => _defaultCachePolicy;

	public bool SendChunked => (_booleans & Booleans.SendChunked) != 0;

	public RemoteCertificateValidationCallback? ServerCertificateValidationCallback { get; }

	public Version ProtocolVersion
	{
		get
		{
			if (!IsVersionHttp10)
			{
				return HttpVersion.Version11;
			}
			return HttpVersion.Version10;
		}
	}

	public int ReadWriteTimeout => _readWriteTimeout;

	public override ICredentials? Credentials => _credentials;

	public override string Method
	{
		get
		{
			return _originVerb;
		}
		set
		{
			ArgumentException.ThrowIfNullOrEmpty(value, "value");
			if (System.Net.HttpValidationHelpers.IsInvalidMethodOrHeaderString(value))
			{
				throw new ArgumentException("net_badmethod", "value");
			}
			_originVerb = value;
		}
	}

	public override Uri RequestUri => _requestUri;

	private bool IsVersionHttp10 => (_booleans & Booleans.IsVersionHttp10) != 0;

	private bool RequestSubmitted => _sendRequestTask != null;

	[Obsolete("Serialization has been deprecated for HttpWebRequest.")]
	void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{
		throw new PlatformNotSupportedException();
	}

	[Obsolete("Serialization has been deprecated for HttpWebRequest.")]
	protected override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{
		throw new PlatformNotSupportedException();
	}

	internal HttpWebRequest(Uri uri)
	{
		_requestUri = uri;
	}

	private Task<HttpResponseMessage> SendRequest(bool async, HttpContent content = null)
	{
		if (RequestSubmitted)
		{
			throw new InvalidOperationException("net_reqsubmitted");
		}
		_sendRequestMessage = new HttpRequestMessage(HttpMethod.Parse(_originVerb.AsSpan()), _requestUri);
		_sendRequestCts = new CancellationTokenSource();
		_httpClient = GetCachedOrCreateHttpClient(async, out _disposeRequired);
		if (content != null)
		{
			_sendRequestMessage.Content = content;
		}
		if ((object)_hostUri != null)
		{
			_sendRequestMessage.Headers.Host = Host;
		}
		AddCacheControlHeaders(_sendRequestMessage);
		foreach (string item in _webHeaderCollection)
		{
			if (IsWellKnownContentHeader(item))
			{
				HttpRequestMessage sendRequestMessage = _sendRequestMessage;
				if (sendRequestMessage.Content == null)
				{
					HttpContent httpContent = (sendRequestMessage.Content = new ByteArrayContent(Array.Empty<byte>()));
				}
				_sendRequestMessage.Content.Headers.TryAddWithoutValidation(item, _webHeaderCollection[item]);
			}
			else
			{
				_sendRequestMessage.Headers.TryAddWithoutValidation(item, _webHeaderCollection[item]);
			}
		}
		ServicePoint servicePoint = _servicePoint;
		if (servicePoint != null && servicePoint.Expect100Continue)
		{
			_sendRequestMessage.Headers.ExpectContinue = true;
		}
		_sendRequestMessage.Headers.TransferEncodingChunked = SendChunked;
		if (KeepAlive)
		{
			_sendRequestMessage.Headers.Connection.Add("Keep-Alive");
		}
		else
		{
			_sendRequestMessage.Headers.ConnectionClose = true;
		}
		_sendRequestMessage.Version = ProtocolVersion;
		HttpCompletionOption completionOption = ((!_allowReadStreamBuffering) ? HttpCompletionOption.ResponseHeadersRead : HttpCompletionOption.ResponseContentRead);
		_sendRequestTask = (Task<HttpResponseMessage>)((async || !AllowWriteStreamBuffering) ? ((Task)_httpClient.SendAsync(_sendRequestMessage, completionOption, _sendRequestCts.Token)) : ((Task)Task.FromResult(_httpClient.Send(_sendRequestMessage, completionOption, _sendRequestCts.Token))));
		return _sendRequestTask;
	}

	private async Task<WebResponse> HandleResponse(bool async)
	{
		if (_requestStream is RequestStream requestStream)
		{
			requestStream.Complete();
		}
		if (_sendRequestTask == null && _requestStream is RequestBufferingStream requestBufferingStream)
		{
			ArraySegment<byte> buffer = requestBufferingStream.GetBuffer();
			_sendRequestTask = SendRequest(async, new ByteArrayContent(buffer.Array, buffer.Offset, buffer.Count));
		}
		if (_sendRequestTask == null)
		{
			_sendRequestTask = SendRequest(async);
		}
		try
		{
			HttpWebResponse httpWebResponse = new HttpWebResponse(await _sendRequestTask.ConfigureAwait(continueOnCapturedContext: false), _requestUri, _cookieContainer);
			int num = (AllowAutoRedirect ? 299 : 399);
			if ((int)httpWebResponse.StatusCode > num || httpWebResponse.StatusCode < HttpStatusCode.OK)
			{
				throw new WebException(System.SR.Format("net_servererror", (int)httpWebResponse.StatusCode, httpWebResponse.StatusDescription), null, WebExceptionStatus.ProtocolError, httpWebResponse);
			}
			return httpWebResponse;
		}
		finally
		{
			_sendRequestMessage?.Dispose();
			if (_requestStream is RequestBufferingStream requestBufferingStream2)
			{
				requestBufferingStream2.GetMemoryStream().Dispose();
			}
			if (_disposeRequired)
			{
				_httpClient?.Dispose();
			}
		}
	}

	private void AddCacheControlHeaders(HttpRequestMessage request)
	{
		RequestCachePolicy applicableCachePolicy = GetApplicableCachePolicy();
		if (applicableCachePolicy == null || applicableCachePolicy.Level == RequestCacheLevel.BypassCache)
		{
			return;
		}
		CacheControlHeaderValue cacheControlHeaderValue = null;
		HttpHeaderValueCollection<NameValueHeaderValue> pragma = request.Headers.Pragma;
		if (applicableCachePolicy is HttpRequestCachePolicy httpRequestCachePolicy)
		{
			switch (httpRequestCachePolicy.Level)
			{
			case HttpRequestCacheLevel.NoCacheNoStore:
				cacheControlHeaderValue = new CacheControlHeaderValue
				{
					NoCache = true,
					NoStore = true
				};
				pragma.Add(new NameValueHeaderValue("no-cache"));
				break;
			case HttpRequestCacheLevel.Reload:
				cacheControlHeaderValue = new CacheControlHeaderValue
				{
					NoCache = true
				};
				pragma.Add(new NameValueHeaderValue("no-cache"));
				break;
			case HttpRequestCacheLevel.CacheOnly:
				throw new WebException("CacheEntryNotFound", WebExceptionStatus.CacheEntryNotFound);
			case HttpRequestCacheLevel.CacheOrNextCacheOnly:
				cacheControlHeaderValue = new CacheControlHeaderValue
				{
					OnlyIfCached = true
				};
				break;
			case HttpRequestCacheLevel.Default:
				cacheControlHeaderValue = new CacheControlHeaderValue();
				if (httpRequestCachePolicy.MinFresh > TimeSpan.Zero)
				{
					cacheControlHeaderValue.MinFresh = httpRequestCachePolicy.MinFresh;
				}
				if (httpRequestCachePolicy.MaxAge != TimeSpan.MaxValue)
				{
					cacheControlHeaderValue.MaxAge = httpRequestCachePolicy.MaxAge;
				}
				if (httpRequestCachePolicy.MaxStale > TimeSpan.Zero)
				{
					cacheControlHeaderValue.MaxStale = true;
					cacheControlHeaderValue.MaxStaleLimit = httpRequestCachePolicy.MaxStale;
				}
				break;
			case HttpRequestCacheLevel.Refresh:
				cacheControlHeaderValue = new CacheControlHeaderValue
				{
					MaxAge = TimeSpan.Zero
				};
				pragma.Add(new NameValueHeaderValue("no-cache"));
				break;
			}
		}
		else
		{
			switch (applicableCachePolicy.Level)
			{
			case RequestCacheLevel.NoCacheNoStore:
				cacheControlHeaderValue = new CacheControlHeaderValue
				{
					NoCache = true,
					NoStore = true
				};
				pragma.Add(new NameValueHeaderValue("no-cache"));
				break;
			case RequestCacheLevel.Reload:
				cacheControlHeaderValue = new CacheControlHeaderValue
				{
					NoCache = true
				};
				pragma.Add(new NameValueHeaderValue("no-cache"));
				break;
			case RequestCacheLevel.CacheOnly:
				throw new WebException("CacheEntryNotFound", WebExceptionStatus.CacheEntryNotFound);
			}
		}
		if (cacheControlHeaderValue != null)
		{
			request.Headers.CacheControl = cacheControlHeaderValue;
		}
	}

	private RequestCachePolicy GetApplicableCachePolicy()
	{
		if (CachePolicy != null)
		{
			return CachePolicy;
		}
		if (_isDefaultCachePolicySet && DefaultCachePolicy != null)
		{
			return DefaultCachePolicy;
		}
		return WebRequest.DefaultCachePolicy;
	}

	public override IAsyncResult BeginGetResponse(AsyncCallback? callback, object? state)
	{
		CheckAbort();
		if (Interlocked.Exchange(ref _beginGetResponseCalled, value: true))
		{
			throw new InvalidOperationException("net_repcall");
		}
		_responseCallback = callback;
		_responseOperation = HandleResponse(async: true).ToApm(callback, state);
		return _responseOperation.Task;
	}

	public override WebResponse EndGetResponse(IAsyncResult asyncResult)
	{
		CheckAbort();
		if (asyncResult == null || !(asyncResult is Task<WebResponse>))
		{
			throw new ArgumentException("net_io_invalidasyncresult", "asyncResult");
		}
		if (Interlocked.Exchange(ref _endGetResponseCalled, value: true))
		{
			throw new InvalidOperationException(System.SR.Format("net_io_invalidendcall", "EndGetResponse"));
		}
		try
		{
			return ((Task<WebResponse>)asyncResult).GetAwaiter().GetResult();
		}
		catch (Exception exception)
		{
			throw WebException.CreateCompatibleException(exception);
		}
	}

	private void CheckAbort()
	{
		if (_abortCalled)
		{
			throw new WebException("net_reqaborted", WebExceptionStatus.RequestCanceled);
		}
	}

	private static bool IsWellKnownContentHeader(string header)
	{
		string[] array = s_wellKnownContentHeaders;
		foreach (string b in array)
		{
			if (string.Equals(header, b, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	private HttpClient GetCachedOrCreateHttpClient(bool async, out bool disposeRequired)
	{
		HttpClientParameters httpClientParameters = new HttpClientParameters(this, async);
		if (httpClientParameters.AreParametersAcceptableForCaching())
		{
			disposeRequired = false;
			if (s_cachedHttpClient == null)
			{
				lock (s_syncRoot)
				{
					if (s_cachedHttpClient == null)
					{
						s_cachedHttpClientParameters = httpClientParameters;
						s_cachedHttpClient = CreateHttpClient(httpClientParameters, null);
						return s_cachedHttpClient;
					}
				}
			}
			if (s_cachedHttpClientParameters.Matches(httpClientParameters))
			{
				return s_cachedHttpClient;
			}
		}
		disposeRequired = true;
		return CreateHttpClient(httpClientParameters, this);
	}

	private static HttpClient CreateHttpClient(HttpClientParameters parameters, HttpWebRequest request)
	{
		HttpClient httpClient = null;
		try
		{
			SocketsHttpHandler socketsHttpHandler = new SocketsHttpHandler();
			httpClient = new HttpClient(socketsHttpHandler);
			socketsHttpHandler.AutomaticDecompression = parameters.AutomaticDecompression;
			socketsHttpHandler.Credentials = parameters.Credentials;
			socketsHttpHandler.AllowAutoRedirect = parameters.AllowAutoRedirect;
			socketsHttpHandler.MaxAutomaticRedirections = parameters.MaximumAutomaticRedirections;
			socketsHttpHandler.MaxResponseHeadersLength = parameters.MaximumResponseHeadersLength;
			socketsHttpHandler.PreAuthenticate = parameters.PreAuthenticate;
			socketsHttpHandler.Expect100ContinueTimeout = parameters.ContinueTimeout;
			httpClient.Timeout = parameters.Timeout;
			if (request != null && request.ImpersonationLevel != TokenImpersonationLevel.None)
			{
				GetImpersonationLevel(GetSettings(socketsHttpHandler)) = request.ImpersonationLevel;
			}
			if (parameters.CookieContainer != null)
			{
				socketsHttpHandler.CookieContainer = parameters.CookieContainer;
			}
			else
			{
				socketsHttpHandler.UseCookies = false;
			}
			ServicePoint servicePoint = parameters.ServicePoint;
			if (servicePoint != null)
			{
				socketsHttpHandler.MaxConnectionsPerServer = servicePoint.ConnectionLimit;
				socketsHttpHandler.PooledConnectionIdleTimeout = TimeSpan.FromMilliseconds(servicePoint.MaxIdleTime);
				socketsHttpHandler.PooledConnectionLifetime = TimeSpan.FromMilliseconds(servicePoint.ConnectionLeaseTimeout);
			}
			if (parameters.Proxy == null)
			{
				socketsHttpHandler.UseProxy = false;
			}
			else if (parameters.Proxy != WebRequest.GetSystemWebProxy())
			{
				socketsHttpHandler.Proxy = parameters.Proxy;
			}
			else
			{
				socketsHttpHandler.DefaultProxyCredentials = parameters.Proxy.Credentials;
			}
			if (parameters.ClientCertificates != null)
			{
				socketsHttpHandler.SslOptions.ClientCertificates = new X509CertificateCollection(parameters.ClientCertificates);
			}
			socketsHttpHandler.SslOptions.EnabledSslProtocols = (SslProtocols)parameters.SslProtocols;
			socketsHttpHandler.SslOptions.CertificateRevocationCheckMode = (parameters.CheckCertificateRevocationList ? X509RevocationMode.Online : X509RevocationMode.NoCheck);
			RemoteCertificateValidationCallback rcvc = parameters.ServerCertificateValidationCallback;
			socketsHttpHandler.SslOptions.RemoteCertificateValidationCallback = delegate(object message, X509Certificate cert, X509Chain chain, SslPolicyErrors errors)
			{
				ServicePoint servicePoint2 = parameters.ServicePoint;
				if (servicePoint2 != null)
				{
					servicePoint2.Certificate = cert;
				}
				return (rcvc != null) ? rcvc(request, cert, chain, errors) : (errors == SslPolicyErrors.None);
			};
			socketsHttpHandler.ConnectCallback = async delegate(SocketsHttpConnectionContext context, CancellationToken cancellationToken)
			{
				Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
				try
				{
					IPAddress[] array = ((!parameters.Async) ? Dns.GetHostAddresses(context.DnsEndPoint.Host) : (await Dns.GetHostAddressesAsync(context.DnsEndPoint.Host, cancellationToken).ConfigureAwait(continueOnCapturedContext: false)));
					IPAddress[] addresses = array;
					ServicePoint servicePoint2 = parameters.ServicePoint;
					if (servicePoint2 != null)
					{
						if (servicePoint2.ReceiveBufferSize != -1)
						{
							socket.ReceiveBufferSize = servicePoint2.ReceiveBufferSize;
						}
						TcpKeepAlive keepAlive = servicePoint2.KeepAlive;
						if (keepAlive != null)
						{
							socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, optionValue: true);
							socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.TypeOfService, keepAlive.Time);
							socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.BlockSource, keepAlive.Interval);
						}
						BindHelper(servicePoint2, ref addresses, socket, context.DnsEndPoint.Port);
					}
					ServicePoint servicePoint3 = parameters.ServicePoint;
					socket.NoDelay = servicePoint3 == null || !servicePoint3.UseNagleAlgorithm;
					if (parameters.Async)
					{
						await socket.ConnectAsync(addresses, context.DnsEndPoint.Port, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					}
					else
					{
						using (cancellationToken.UnsafeRegister(delegate(object s)
						{
							((Socket)s).Dispose();
						}, socket))
						{
							socket.Connect(addresses, context.DnsEndPoint.Port);
						}
						cancellationToken.ThrowIfCancellationRequested();
					}
					if (parameters.ReadWriteTimeout > 0)
					{
						int sendTimeout = (socket.ReceiveTimeout = parameters.ReadWriteTimeout);
						socket.SendTimeout = sendTimeout;
					}
				}
				catch
				{
					socket.Dispose();
					throw;
				}
				return new NetworkStream(socket, ownsSocket: true);
			};
			return httpClient;
		}
		catch
		{
			httpClient?.Dispose();
			throw;
		}
		static void BindHelper(ServicePoint servicePoint2, ref IPAddress[] addresses, Socket socket, int port)
		{
			if (servicePoint2.BindIPEndPointDelegate != null)
			{
				IPAddress[] array = addresses;
				foreach (IPAddress iPAddress in array)
				{
					int j;
					for (j = 0; j < 100; j++)
					{
						IPEndPoint iPEndPoint = servicePoint2.BindIPEndPointDelegate(servicePoint2, new IPEndPoint(iPAddress, port), j);
						if (iPEndPoint == null)
						{
							break;
						}
						try
						{
							socket.Bind(iPEndPoint);
							addresses = new IPAddress[1] { iPAddress };
							return;
						}
						catch
						{
						}
					}
					if (j >= 100)
					{
						throw new OverflowException("net_maximumbindretries");
					}
				}
			}
		}
		[UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_impersonationLevel")]
		static extern ref TokenImpersonationLevel GetImpersonationLevel([UnsafeAccessorType("System.Net.Http.HttpConnectionSettings, System.Net.Http")] object settings);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_Settings")]
		[return: UnsafeAccessorType("System.Net.Http.HttpConnectionSettings, System.Net.Http")]
		static extern object GetSettings(SocketsHttpHandler handler);
	}
}
