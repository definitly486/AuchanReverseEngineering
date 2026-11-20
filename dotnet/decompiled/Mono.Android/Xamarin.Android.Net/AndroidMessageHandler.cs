using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.OS;
using Android.Runtime;
using Java.IO;
using Java.Lang;
using Java.Net;
using Java.Security;
using Java.Security.Cert;
using Java.Security.Spec;
using Javax.Net.Ssl;

namespace Xamarin.Android.Net;

public class AndroidMessageHandler : HttpMessageHandler
{
	private sealed class RequestRedirectionState
	{
		public Uri? NewUrl;

		public int RedirectCounter;

		public HttpMethod? Method;

		public bool MethodChanged;
	}

	private sealed class ContentState
	{
		public bool? RemoveContentLengthHeader;

		public bool? RemoveContentEncodingHeader;

		public List<string>? NewContentEncodingHeaderValue;

		public void Reset()
		{
			RemoveContentEncodingHeader = null;
			RemoveContentLengthHeader = null;
			NewContentEncodingHeaderValue = null;
		}
	}

	private static readonly IDictionary<string, string> headerSeparators = new Dictionary<string, string> { ["User-Agent"] = " " };

	private static readonly HashSet<string> known_content_headers = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		"Allow", "Content-Disposition", "Content-Encoding", "Content-Language", "Content-Length", "Content-Location", "Content-MD5", "Content-Range", "Content-Type", "Expires",
		"Last-Modified"
	};

	private static readonly List<IAndroidAuthenticationModule> authModules = new List<IAndroidAuthenticationModule>
	{
		new AuthModuleBasic(),
		new AuthModuleDigest()
	};

	private CookieContainer? _cookieContainer;

	private DecompressionMethods _decompressionMethods;

	private bool disposed;

	private bool started;

	private string? _acceptEncoding;

	private X509CertificateCollection? _clientCertificates;

	private ServerCertificateCustomValidator? _serverCertificateCustomValidator;

	private int maxAutomaticRedirections = 50;

	private bool decompress_here
	{
		get
		{
			if (_acceptEncoding != null)
			{
				return _acceptEncoding != "identity";
			}
			return false;
		}
	}

	public bool SupportsAutomaticDecompression => true;

	public bool SupportsProxy => true;

	public bool SupportsRedirectConfiguration => true;

	public DecompressionMethods AutomaticDecompression
	{
		get
		{
			return _decompressionMethods;
		}
		set
		{
			CheckDisposedOrStarted();
			_decompressionMethods = value;
			_acceptEncoding = null;
			if (value == DecompressionMethods.None)
			{
				_acceptEncoding = "identity";
				return;
			}
			if ((value & DecompressionMethods.GZip) != DecompressionMethods.None)
			{
				_acceptEncoding = "gzip";
			}
			if ((value & DecompressionMethods.Deflate) != DecompressionMethods.None)
			{
				_acceptEncoding = ((_acceptEncoding == null) ? "deflate" : (_acceptEncoding + ", deflate"));
			}
			if ((value & DecompressionMethods.Brotli) != DecompressionMethods.None)
			{
				_acceptEncoding = ((_acceptEncoding == null) ? "br" : (_acceptEncoding + ", br"));
			}
		}
	}

	public CookieContainer CookieContainer
	{
		get
		{
			return _cookieContainer ?? (_cookieContainer = new CookieContainer());
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			_cookieContainer = value;
		}
	}

	public bool UseCookies { get; set; } = true;

	public bool PreAuthenticate { get; set; }

	public bool UseProxy { get; set; } = true;

	public IWebProxy? Proxy { get; set; }

	public ICredentials? Credentials { get; set; }

	public bool AllowAutoRedirect { get; set; } = true;

	public ClientCertificateOption ClientCertificateOptions { get; set; }

	public X509CertificateCollection? ClientCertificates
	{
		get
		{
			if (ClientCertificateOptions != ClientCertificateOption.Manual)
			{
				throw new InvalidOperationException("Enable manual options first on ClientCertificateOptions");
			}
			return _clientCertificates ?? (_clientCertificates = new X509CertificateCollection());
		}
	}

	public ICredentials? DefaultProxyCredentials { get; set; }

	public int MaxConnectionsPerServer { get; set; } = int.MaxValue;

	public int MaxResponseHeadersLength { get; set; } = 64;

	public bool CheckCertificateRevocationList { get; set; }

	public Func<HttpRequestMessage, X509Certificate2?, X509Chain?, SslPolicyErrors, bool>? ServerCertificateCustomValidationCallback
	{
		get
		{
			return _serverCertificateCustomValidator?.Callback;
		}
		set
		{
			if (value == null)
			{
				_serverCertificateCustomValidator = null;
			}
			else if (_serverCertificateCustomValidator == null)
			{
				_serverCertificateCustomValidator = new ServerCertificateCustomValidator(value);
			}
			else
			{
				_serverCertificateCustomValidator.Callback = value;
			}
		}
	}

	public SslProtocols SslProtocols { get; set; } = (Build.VERSION.SdkInt >= BuildVersionCodes.Q) ? (SslProtocols.Tls12 | SslProtocols.Tls13) : SslProtocols.Tls12;

	public IDictionary<string, object?>? Properties { get; }

	public int MaxAutomaticRedirections
	{
		get
		{
			return maxAutomaticRedirections;
		}
		set
		{
			if (value <= 0)
			{
				throw new ArgumentOutOfRangeException("value", value, "The specified value must be greater than 0");
			}
			maxAutomaticRedirections = value;
		}
	}

	public AuthenticationData? PreAuthenticationData { get; }

	public IList<AuthenticationData>? RequestedAuthentication { get; private set; }

	public bool ProxyAuthenticationRequested { get; private set; }

	public IList<Certificate>? TrustedCerts { get; }

	public TimeSpan ReadTimeout { get; } = TimeSpan.FromHours(24);

	public TimeSpan ConnectTimeout { get; } = TimeSpan.FromHours(24);

	[MemberNotNullWhen(true, "TrustedCerts")]
	private bool HasTrustedCerts
	{
		[MemberNotNullWhen(true, "TrustedCerts")]
		get
		{
			IList<Certificate>? trustedCerts = TrustedCerts;
			if (trustedCerts == null)
			{
				return false;
			}
			return trustedCerts.Count > 0;
		}
	}

	[MemberNotNullWhen(true, "_serverCertificateCustomValidator")]
	private bool HasServerCertificateCustomValidationCallback
	{
		[MemberNotNullWhen(true, "_serverCertificateCustomValidator")]
		get
		{
			return _serverCertificateCustomValidator != null;
		}
	}

	[MemberNotNullWhen(true, "_clientCertificates")]
	private bool HasClientCertificates
	{
		[MemberNotNullWhen(true, "_clientCertificates")]
		get
		{
			X509CertificateCollection? clientCertificates = _clientCertificates;
			if (clientCertificates == null)
			{
				return false;
			}
			return clientCertificates.Count > 0;
		}
	}

	protected override void Dispose(bool disposing)
	{
		disposed = true;
		base.Dispose(disposing);
	}

	protected void AssertSelf()
	{
		if (!disposed)
		{
			return;
		}
		throw new ObjectDisposedException("AndroidMessageHandler");
	}

	private void CheckDisposedOrStarted()
	{
		AssertSelf();
		if (started)
		{
			throw new InvalidOperationException("The handler has already started sending requests");
		}
	}

	private string EncodeUrl(Uri url)
	{
		if (url == null)
		{
			return string.Empty;
		}
		UriBuilder uriBuilder = new UriBuilder(url);
		if (url.IsDefaultPort)
		{
			uriBuilder.Port = -1;
		}
		return uriBuilder.ToString();
	}

	protected virtual IHostnameVerifier? GetSSLHostnameVerifier(HttpsURLConnection connection)
	{
		return _serverCertificateCustomValidator?.HostnameVerifier;
	}

	protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		if (false)
		{
		}
		return DoSendAsync(request, cancellationToken);
	}

	internal async Task<HttpResponseMessage> DoSendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		started = true;
		AssertSelf();
		if (request == null)
		{
			throw new ArgumentNullException("request");
		}
		if ((object)request.RequestUri == null || !request.RequestUri.IsAbsoluteUri)
		{
			throw new ArgumentException("Must represent an absolute URI", "request");
		}
		RequestRedirectionState redirectState = new RequestRedirectionState
		{
			NewUrl = request.RequestUri,
			RedirectCounter = 0,
			Method = request.Method
		};
		checked
		{
			while (true)
			{
				URL java_url = new URL(EncodeUrl(redirectState.NewUrl));
				URLConnection uRLConnection;
				if (UseProxy)
				{
					Proxy proxy = await GetJavaProxy(redirectState.NewUrl, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					uRLConnection = ((proxy == Java.Net.Proxy.NoProxy) ? java_url.OpenConnection() : java_url.OpenConnection(proxy));
				}
				else
				{
					uRLConnection = java_url.OpenConnection(Java.Net.Proxy.NoProxy);
				}
				if (uRLConnection is HttpsURLConnection httpsURLConnection)
				{
					IHostnameVerifier sSLHostnameVerifier = GetSSLHostnameVerifier(httpsURLConnection);
					if (sSLHostnameVerifier != null)
					{
						httpsURLConnection.HostnameVerifier = sSLHostnameVerifier;
					}
				}
				if (ConnectTimeout != TimeSpan.Zero)
				{
					uRLConnection.ConnectTimeout = (int)ConnectTimeout.TotalMilliseconds;
				}
				if (ReadTimeout != TimeSpan.Zero)
				{
					uRLConnection.ReadTimeout = (int)ReadTimeout.TotalMilliseconds;
				}
				try
				{
					HttpResponseMessage httpResponseMessage = await ProcessRequest(request, java_url, await SetupRequestInternal(request, uRLConnection).ConfigureAwait(continueOnCapturedContext: false), cancellationToken, redirectState).ConfigureAwait(continueOnCapturedContext: false);
					if (httpResponseMessage != null)
					{
						return httpResponseMessage;
					}
					if (redirectState.NewUrl == null)
					{
						throw new InvalidOperationException("Request redirected but no new URI specified");
					}
					request.Method = redirectState.Method;
					request.RequestUri = redirectState.NewUrl;
				}
				catch (SocketTimeoutException ex) when (JNIEnv.ShouldWrapJavaException(ex, "DoSendAsync"))
				{
					throw new WebException(ex.Message, ex, WebExceptionStatus.Timeout, null);
				}
				catch (UnknownServiceException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "DoSendAsync"))
				{
					throw new WebException(ex2.Message, ex2, WebExceptionStatus.ProtocolError, null);
				}
				catch (SecurityException ex3) when (JNIEnv.ShouldWrapJavaException(ex3, "DoSendAsync"))
				{
					throw new WebException(ex3.Message, ex3, WebExceptionStatus.SecureChannelFailure, null);
				}
				catch (Java.IO.IOException ex4) when (JNIEnv.ShouldWrapJavaException(ex4, "DoSendAsync"))
				{
					throw new WebException(ex4.Message, ex4, WebExceptionStatus.UnknownError, null);
				}
			}
		}
	}

	protected virtual async Task<Proxy?> GetJavaProxy(Uri destination, CancellationToken cancellationToken)
	{
		Proxy noProxy = Java.Net.Proxy.NoProxy;
		if (destination == null || Proxy == null)
		{
			return noProxy;
		}
		Uri puri = Proxy.GetProxy(destination);
		if (puri == null)
		{
			return noProxy;
		}
		return await Task.Run(delegate
		{
			InetSocketAddress sa = new InetSocketAddress(puri.Host, puri.Port);
			return new Proxy(Java.Net.Proxy.Type.Http, sa);
		}, cancellationToken);
	}

	private Task<HttpResponseMessage?> ProcessRequest(HttpRequestMessage request, URL javaUrl, HttpURLConnection httpConnection, CancellationToken cancellationToken, RequestRedirectionState redirectState)
	{
		cancellationToken.ThrowIfCancellationRequested();
		httpConnection.InstanceFollowRedirects = false;
		RequestedAuthentication = null;
		ProxyAuthenticationRequested = false;
		return DoProcessRequest(request, javaUrl, httpConnection, cancellationToken, redirectState);
	}

	private Task DisconnectAsync(HttpURLConnection httpConnection)
	{
		return Task.Run(delegate
		{
			httpConnection?.Disconnect();
		});
	}

	private Task ConnectAsync(HttpURLConnection httpConnection, CancellationToken ct)
	{
		return Task.Run(delegate
		{
			try
			{
				using (ct.Register(delegate
				{
					DisconnectAsync(httpConnection).ContinueWith(delegate(Task t)
					{
						if (t.Exception != null)
						{
							Logger.Log(LogLevel.Info, "monodroid-net", $"Disconnection exception: {t.Exception}");
						}
					}, TaskScheduler.Default);
				}))
				{
					httpConnection?.Connect();
				}
			}
			catch (System.Exception ex)
			{
				if (ct.IsCancellationRequested)
				{
					Logger.Log(LogLevel.Info, "monodroid-net", $"Exception caught while cancelling connection: {ex}");
					ct.ThrowIfCancellationRequested();
				}
				throw new HttpRequestException("Connection failure", ex);
			}
		}, ct);
	}

	protected virtual async Task WriteRequestContentToOutput(HttpRequestMessage request, HttpURLConnection httpConnection, CancellationToken cancellationToken)
	{
		if (request.Content == null)
		{
			return;
		}
		Stream stream = await request.Content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false);
		try
		{
			await stream.CopyToAsync(httpConnection.OutputStream, 4096, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		finally
		{
			if (stream.CanSeek)
			{
				stream.Seek(0L, SeekOrigin.Begin);
			}
		}
	}

	private async Task<HttpResponseMessage?> DoProcessRequest(HttpRequestMessage request, URL javaUrl, HttpURLConnection httpConnection, CancellationToken cancellationToken, RequestRedirectionState redirectState)
	{
		if (Logger.LogNet)
		{
			Logger.Log(LogLevel.Info, "monodroid-net", $"{this}.DoProcessRequest ()");
		}
		if (cancellationToken.IsCancellationRequested)
		{
			if (Logger.LogNet)
			{
				Logger.Log(LogLevel.Info, "monodroid-net", " cancelled");
			}
			cancellationToken.ThrowIfCancellationRequested();
		}
		try
		{
			if (Logger.LogNet)
			{
				Logger.Log(LogLevel.Info, "monodroid-net", "  connecting");
			}
			await ConnectAsync(httpConnection, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (Logger.LogNet)
			{
				Logger.Log(LogLevel.Info, "monodroid-net", "  connected");
			}
		}
		catch (ConnectException ex)
		{
			if (Logger.LogNet)
			{
				Logger.Log(LogLevel.Info, "monodroid-net", $"Connection exception {ex}");
			}
			throw new WebException(ex.Message, ex, WebExceptionStatus.ConnectFailure, null);
		}
		if (cancellationToken.IsCancellationRequested)
		{
			if (Logger.LogNet)
			{
				Logger.Log(LogLevel.Info, "monodroid-net", " cancelled");
			}
			await DisconnectAsync(httpConnection).ConfigureAwait(continueOnCapturedContext: false);
			cancellationToken.ThrowIfCancellationRequested();
		}
		CancellationTokenRegistration cancelRegistration = default(CancellationTokenRegistration);
		HttpStatusCode statusCode = HttpStatusCode.OK;
		Uri connectionUri = null;
		ContentState contentState = new ContentState();
		try
		{
			cancelRegistration = cancellationToken.Register(delegate
			{
				DisconnectAsync(httpConnection).ContinueWith(delegate(Task t)
				{
					if (t.Exception != null)
					{
						Logger.Log(LogLevel.Info, "monodroid-net", $"Disconnection exception: {t.Exception}");
					}
				}, TaskScheduler.Default);
			}, useSynchronizationContext: false);
			if (httpConnection.DoOutput)
			{
				await WriteRequestContentToOutput(request, httpConnection, cancellationToken);
			}
			statusCode = await Task.Run(() => (HttpStatusCode)httpConnection.ResponseCode, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			connectionUri = new Uri(httpConnection.URL?.ToString());
		}
		finally
		{
			cancelRegistration.Dispose();
		}
		if (cancellationToken.IsCancellationRequested)
		{
			await DisconnectAsync(httpConnection).ConfigureAwait(continueOnCapturedContext: false);
			cancellationToken.ThrowIfCancellationRequested();
		}
		request.RequestUri = connectionUri;
		AndroidHttpResponseMessage androidHttpResponseMessage = new AndroidHttpResponseMessage(javaUrl, httpConnection)
		{
			RequestMessage = request,
			ReasonPhrase = httpConnection.ResponseMessage,
			StatusCode = statusCode
		};
		if (Logger.LogNet)
		{
			Logger.Log(LogLevel.Info, "monodroid-net", $"Status code: {statusCode}");
		}
		if (!IsErrorStatusCode(statusCode))
		{
			if (Logger.LogNet)
			{
				Logger.Log(LogLevel.Info, "monodroid-net", "Reading...");
			}
			androidHttpResponseMessage.Content = GetContent(httpConnection, httpConnection.InputStream, contentState);
		}
		else
		{
			if (Logger.LogNet)
			{
				Logger.Log(LogLevel.Info, "monodroid-net", $"Status code is {statusCode}, reading...");
			}
			androidHttpResponseMessage.Content = GetErrorContent(httpConnection, new StringContent(string.Empty, Encoding.ASCII), contentState);
		}
		if (HandleRedirect(statusCode, httpConnection, redirectState, out var disposeRet))
		{
			if (redirectState.MethodChanged && redirectState.Method == HttpMethod.Get)
			{
				if (Logger.LogNet)
				{
					Logger.Log(LogLevel.Info, "monodroid-net", "Discarding content on redirect");
				}
				request.Content = null;
			}
			CopyHeaders(httpConnection, androidHttpResponseMessage, contentState);
			ParseCookies(androidHttpResponseMessage, connectionUri);
			if (disposeRet)
			{
				androidHttpResponseMessage.Dispose();
				androidHttpResponseMessage = null;
			}
			request.Headers.Authorization = null;
			return androidHttpResponseMessage;
		}
		HttpStatusCode httpStatusCode = statusCode;
		if (httpStatusCode == HttpStatusCode.Unauthorized || httpStatusCode == HttpStatusCode.ProxyAuthenticationRequired)
		{
			androidHttpResponseMessage.Content = GetErrorContent(httpConnection, new StringContent("Unauthorized", Encoding.ASCII), contentState);
			CopyHeaders(httpConnection, androidHttpResponseMessage, contentState);
			if (androidHttpResponseMessage.Headers.WwwAuthenticate != null)
			{
				ProxyAuthenticationRequested = false;
				CollectAuthInfo(androidHttpResponseMessage.Headers.WwwAuthenticate);
			}
			else if (androidHttpResponseMessage.Headers.ProxyAuthenticate != null)
			{
				ProxyAuthenticationRequested = true;
				CollectAuthInfo(androidHttpResponseMessage.Headers.ProxyAuthenticate);
			}
			androidHttpResponseMessage.RequestedAuthentication = RequestedAuthentication;
			return androidHttpResponseMessage;
		}
		CopyHeaders(httpConnection, androidHttpResponseMessage, contentState);
		ParseCookies(androidHttpResponseMessage, connectionUri);
		if (Logger.LogNet)
		{
			Logger.Log(LogLevel.Info, "monodroid-net", "Returning");
		}
		return androidHttpResponseMessage;
	}

	private HttpContent GetErrorContent(HttpURLConnection httpConnection, HttpContent fallbackContent, ContentState contentState)
	{
		Stream errorStream = httpConnection.ErrorStream;
		if (errorStream != null)
		{
			return GetContent(httpConnection, errorStream, contentState);
		}
		return fallbackContent;
	}

	private Stream GetDecompressionWrapper(URLConnection httpConnection, Stream inputStream, ContentState contentState)
	{
		contentState.Reset();
		if (!decompress_here || string.IsNullOrEmpty(httpConnection.ContentEncoding))
		{
			return inputStream;
		}
		HashSet<string> hashSet = new HashSet<string>(httpConnection.ContentEncoding.Split(','), StringComparer.OrdinalIgnoreCase);
		Stream stream = null;
		string text = null;
		if (hashSet.Contains("gzip"))
		{
			text = "gzip";
			stream = new GZipStream(inputStream, CompressionMode.Decompress);
		}
		else if (hashSet.Contains("deflate"))
		{
			text = "deflate";
			stream = new DeflateStream(inputStream, CompressionMode.Decompress);
		}
		else if (hashSet.Contains("br"))
		{
			text = "br";
			stream = new BrotliStream(inputStream, CompressionMode.Decompress);
		}
		if (!string.IsNullOrEmpty(text))
		{
			contentState.RemoveContentLengthHeader = true;
			hashSet.Remove(text);
			if (hashSet.Count == 0)
			{
				contentState.RemoveContentEncodingHeader = true;
			}
			else
			{
				contentState.NewContentEncodingHeaderValue = new List<string>(hashSet);
			}
		}
		return stream ?? inputStream;
	}

	private HttpContent GetContent(URLConnection httpConnection, Stream contentStream, ContentState contentState)
	{
		return new StreamContent(GetDecompressionWrapper(httpConnection, new BufferedStream(contentStream), contentState));
	}

	private bool HandleRedirect(HttpStatusCode redirectCode, HttpURLConnection httpConnection, RequestRedirectionState redirectState, out bool disposeRet)
	{
		if (!AllowAutoRedirect)
		{
			disposeRet = false;
			return true;
		}
		disposeRet = true;
		redirectState.NewUrl = null;
		redirectState.MethodChanged = false;
		switch (redirectCode)
		{
		case HttpStatusCode.MovedPermanently:
		case HttpStatusCode.Found:
		case HttpStatusCode.SeeOther:
			redirectState.MethodChanged = redirectState.Method != HttpMethod.Get;
			redirectState.Method = HttpMethod.Get;
			break;
		case HttpStatusCode.NotModified:
			disposeRet = false;
			return true;
		case HttpStatusCode.UseProxy:
		case HttpStatusCode.Unused:
		case (HttpStatusCode)309:
		case (HttpStatusCode)310:
		case (HttpStatusCode)311:
		case (HttpStatusCode)312:
		case (HttpStatusCode)313:
		case (HttpStatusCode)314:
		case (HttpStatusCode)315:
		case (HttpStatusCode)316:
		case (HttpStatusCode)317:
		case (HttpStatusCode)318:
		case (HttpStatusCode)319:
		case (HttpStatusCode)320:
		case (HttpStatusCode)321:
		case (HttpStatusCode)322:
		case (HttpStatusCode)323:
		case (HttpStatusCode)324:
		case (HttpStatusCode)325:
		case (HttpStatusCode)326:
		case (HttpStatusCode)327:
		case (HttpStatusCode)328:
		case (HttpStatusCode)329:
		case (HttpStatusCode)330:
		case (HttpStatusCode)331:
		case (HttpStatusCode)332:
		case (HttpStatusCode)333:
		case (HttpStatusCode)334:
		case (HttpStatusCode)335:
		case (HttpStatusCode)336:
		case (HttpStatusCode)337:
		case (HttpStatusCode)338:
		case (HttpStatusCode)339:
		case (HttpStatusCode)340:
		case (HttpStatusCode)341:
		case (HttpStatusCode)342:
		case (HttpStatusCode)343:
		case (HttpStatusCode)344:
		case (HttpStatusCode)345:
		case (HttpStatusCode)346:
		case (HttpStatusCode)347:
		case (HttpStatusCode)348:
		case (HttpStatusCode)349:
		case (HttpStatusCode)350:
		case (HttpStatusCode)351:
		case (HttpStatusCode)352:
		case (HttpStatusCode)353:
		case (HttpStatusCode)354:
		case (HttpStatusCode)355:
		case (HttpStatusCode)356:
		case (HttpStatusCode)357:
		case (HttpStatusCode)358:
		case (HttpStatusCode)359:
		case (HttpStatusCode)360:
		case (HttpStatusCode)361:
		case (HttpStatusCode)362:
		case (HttpStatusCode)363:
		case (HttpStatusCode)364:
		case (HttpStatusCode)365:
		case (HttpStatusCode)366:
		case (HttpStatusCode)367:
		case (HttpStatusCode)368:
		case (HttpStatusCode)369:
		case (HttpStatusCode)370:
		case (HttpStatusCode)371:
		case (HttpStatusCode)372:
		case (HttpStatusCode)373:
		case (HttpStatusCode)374:
		case (HttpStatusCode)375:
		case (HttpStatusCode)376:
		case (HttpStatusCode)377:
		case (HttpStatusCode)378:
		case (HttpStatusCode)379:
		case (HttpStatusCode)380:
		case (HttpStatusCode)381:
		case (HttpStatusCode)382:
		case (HttpStatusCode)383:
		case (HttpStatusCode)384:
		case (HttpStatusCode)385:
		case (HttpStatusCode)386:
		case (HttpStatusCode)387:
		case (HttpStatusCode)388:
		case (HttpStatusCode)389:
		case (HttpStatusCode)390:
		case (HttpStatusCode)391:
		case (HttpStatusCode)392:
		case (HttpStatusCode)393:
		case (HttpStatusCode)394:
		case (HttpStatusCode)395:
		case (HttpStatusCode)396:
		case (HttpStatusCode)397:
		case (HttpStatusCode)398:
		case (HttpStatusCode)399:
			throw new InvalidOperationException($"HTTP Redirection status code {redirectCode} ({redirectCode}) not supported");
		default:
			return false;
		case HttpStatusCode.MultipleChoices:
		case HttpStatusCode.TemporaryRedirect:
		case HttpStatusCode.PermanentRedirect:
			break;
		}
		IDictionary<string, IList<string>>? headerFields = httpConnection.HeaderFields;
		IList<string> value = null;
		string text = null;
		if (headerFields != null && headerFields.TryGetValue("Location", out value) && value != null && value.Count > 0)
		{
			if (value.Count == 1)
			{
				text = value[0]?.Trim();
			}
			else
			{
				if (Logger.LogNet)
				{
					Logger.Log(LogLevel.Info, "monodroid-net", $"More than one location header for HTTP {redirectCode} redirect. Will use the first non-empty one.");
				}
				foreach (string item in value)
				{
					text = item?.Trim();
					if (!string.IsNullOrEmpty(text))
					{
						break;
					}
				}
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			disposeRet = false;
			return true;
		}
		redirectState.RedirectCounter++;
		if (redirectState.RedirectCounter >= MaxAutomaticRedirections)
		{
			throw new WebException($"Maximum automatic redirections exceeded (allowed {MaxAutomaticRedirections}, redirected {redirectState.RedirectCounter} times)");
		}
		Uri uri;
		try
		{
			if (Logger.LogNet)
			{
				Logger.Log(LogLevel.Debug, "monodroid-net", "Raw redirect location: " + text);
			}
			Uri baseUri = new Uri(httpConnection.URL?.ToString());
			if (text?[0] == '/')
			{
				uri = new Uri(baseUri, text);
			}
			else
			{
				uri = new Uri(text, UriKind.RelativeOrAbsolute);
				if (!uri.IsAbsoluteUri)
				{
					uri = new Uri(baseUri, text);
				}
			}
			if (Logger.LogNet)
			{
				Logger.Log(LogLevel.Debug, "monodroid-net", $"Cooked redirect location: {uri}");
			}
		}
		catch (System.Exception innerException)
		{
			throw new WebException("Invalid redirect URI received: " + text, innerException);
		}
		UriBuilder uriBuilder = null;
		if (!string.IsNullOrEmpty(httpConnection.URL?.Ref) && string.IsNullOrEmpty(uri.Fragment))
		{
			if (Logger.LogNet)
			{
				Logger.Log(LogLevel.Debug, "monodroid-net", $"Appending fragment '{httpConnection.URL?.Ref}' to redirect URL '{uri}'");
			}
			uriBuilder = new UriBuilder(uri)
			{
				Fragment = httpConnection.URL?.Ref
			};
		}
		redirectState.NewUrl = ((uriBuilder == null) ? uri : uriBuilder.Uri);
		if (Logger.LogNet)
		{
			Logger.Log(LogLevel.Debug, "monodroid-net", $"Request redirected to {redirectState.NewUrl}");
		}
		return true;
	}

	private bool IsErrorStatusCode(HttpStatusCode statusCode)
	{
		if (statusCode >= HttpStatusCode.BadRequest)
		{
			return statusCode <= (HttpStatusCode)599;
		}
		return false;
	}

	private void CollectAuthInfo(HttpHeaderValueCollection<AuthenticationHeaderValue> headers)
	{
		List<AuthenticationData> list = new List<AuthenticationData>(headers.Count);
		foreach (AuthenticationHeaderValue header in headers)
		{
			AuthenticationData item = new AuthenticationData
			{
				Scheme = GetAuthScheme(header.Scheme),
				Challenge = header.Scheme + " " + header.Parameter,
				UseProxyAuthentication = ProxyAuthenticationRequested
			};
			list.Add(item);
		}
		RequestedAuthentication = list.AsReadOnly();
	}

	private AuthenticationScheme GetAuthScheme(string scheme)
	{
		if (string.Compare("basic", scheme, StringComparison.OrdinalIgnoreCase) == 0)
		{
			return AuthenticationScheme.Basic;
		}
		if (string.Compare("digest", scheme, StringComparison.OrdinalIgnoreCase) == 0)
		{
			return AuthenticationScheme.Digest;
		}
		return AuthenticationScheme.Unsupported;
	}

	private void ParseCookies(AndroidHttpResponseMessage ret, Uri connectionUri)
	{
		if (!UseCookies || CookieContainer == null || !ret.Headers.TryGetValues("Set-Cookie", out IEnumerable<string> values) || values == null)
		{
			if (Logger.LogNet)
			{
				Logger.Log(LogLevel.Info, "monodroid-net", "No cookies");
			}
			return;
		}
		try
		{
			if (Logger.LogNet)
			{
				Logger.Log(LogLevel.Info, "monodroid-net", "Parsing cookies");
			}
			CookieContainer.SetCookies(connectionUri, string.Join(",", values));
		}
		catch (System.Exception ex)
		{
			if (Logger.LogNet)
			{
				Logger.Log(LogLevel.Info, "monodroid-net", $"Failed to parse cookies in the server response. {ex.GetType()}: {ex.Message}");
			}
		}
	}

	private void CopyHeaders(HttpURLConnection httpConnection, HttpResponseMessage response, ContentState contentState)
	{
		IDictionary<string, IList<string>> headerFields = httpConnection.HeaderFields;
		bool flag = contentState.RemoveContentLengthHeader == true;
		bool flag2 = contentState.RemoveContentEncodingHeader == true;
		bool flag3 = !flag2 && contentState.NewContentEncodingHeaderValue != null && contentState.NewContentEncodingHeaderValue.Count > 0;
		foreach (string key in headerFields.Keys)
		{
			if (key == null)
			{
				continue;
			}
			HttpHeaders httpHeaders = ((!known_content_headers.Contains(key)) ? ((HttpHeaders)response.Headers) : ((HttpHeaders)response.Content.Headers));
			IEnumerable<string> values = headerFields[key];
			if (flag && string.Compare("Content-Length", key, StringComparison.OrdinalIgnoreCase) == 0)
			{
				flag = false;
				continue;
			}
			if ((flag2 || flag3) && string.Compare("Content-Encoding", key, StringComparison.OrdinalIgnoreCase) == 0)
			{
				if (flag2)
				{
					flag2 = false;
					continue;
				}
				flag3 = false;
				values = contentState.NewContentEncodingHeaderValue;
			}
			httpHeaders.TryAddWithoutValidation(key, values);
		}
		contentState.Reset();
	}

	protected virtual Task SetupRequest(HttpRequestMessage request, HttpURLConnection conn)
	{
		AssertSelf();
		return Task.CompletedTask;
	}

	protected virtual KeyStore? ConfigureKeyStore(KeyStore? keyStore)
	{
		AssertSelf();
		return keyStore;
	}

	protected virtual KeyManagerFactory? ConfigureKeyManagerFactory(KeyStore? keyStore)
	{
		AssertSelf();
		return null;
	}

	protected virtual TrustManagerFactory? ConfigureTrustManagerFactory(KeyStore? keyStore)
	{
		AssertSelf();
		return null;
	}

	private async Task<HttpURLConnection> SetupRequestInternal(HttpRequestMessage request, URLConnection conn)
	{
		if (conn == null)
		{
			throw new ArgumentNullException("conn");
		}
		HttpURLConnection httpConnection = conn.JavaCast<HttpURLConnection>();
		if (httpConnection == null)
		{
			throw new InvalidOperationException("Unsupported URL scheme " + conn.URL?.Protocol);
		}
		try
		{
			httpConnection.RequestMethod = request.Method.ToString();
		}
		catch (ProtocolException ex) when (JNIEnv.ShouldWrapJavaException(ex, "SetupRequestInternal"))
		{
			throw new WebException(ex.Message, ex, WebExceptionStatus.ProtocolError, null);
		}
		SetupSSL(httpConnection as HttpsURLConnection, request);
		if (request.Content != null)
		{
			AddHeaders(httpConnection, request.Content.Headers);
		}
		AddHeaders(httpConnection, request.Headers);
		if (_acceptEncoding != null)
		{
			httpConnection.SetRequestProperty("Accept-Encoding", _acceptEncoding);
		}
		if (UseCookies && CookieContainer != null && (object)request.RequestUri != null)
		{
			string cookieHeader = CookieContainer.GetCookieHeader(request.RequestUri);
			if (!string.IsNullOrEmpty(cookieHeader))
			{
				httpConnection.SetRequestProperty("Cookie", cookieHeader);
			}
		}
		HandlePreAuthentication(httpConnection);
		await SetupRequest(request, httpConnection).ConfigureAwait(continueOnCapturedContext: false);
		SetupRequestBody(httpConnection, request);
		return httpConnection;
	}

	protected virtual SSLSocketFactory? ConfigureCustomSSLSocketFactory(HttpsURLConnection connection)
	{
		return null;
	}

	private void SetupSSL(HttpsURLConnection? httpsConnection, HttpRequestMessage requestMessage)
	{
		if (httpsConnection == null)
		{
			return;
		}
		SSLSocketFactory sSLSocketFactory = ConfigureCustomSSLSocketFactory(httpsConnection);
		if (sSLSocketFactory != null)
		{
			httpsConnection.SSLSocketFactory = sSLSocketFactory;
			return;
		}
		KeyStore configuredKeyStoreInstance = GetConfiguredKeyStoreInstance();
		KeyManagerFactory configuredKeyManagerFactory = GetConfiguredKeyManagerFactory(configuredKeyStoreInstance);
		TrustManagerFactory trustManagerFactory = ConfigureTrustManagerFactory(configuredKeyStoreInstance);
		if (trustManagerFactory != null || configuredKeyManagerFactory != null || HasTrustedCerts || HasServerCertificateCustomValidationCallback || HasClientCertificates)
		{
			SSLContext sSLContext = SSLContext.GetInstance("TLS") ?? throw new InvalidOperationException("Failed to get the SSLContext instance for TLS");
			ITrustManager[] trustManagers = GetTrustManagers(trustManagerFactory, configuredKeyStoreInstance, requestMessage);
			sSLContext.Init(configuredKeyManagerFactory?.GetKeyManagers(), trustManagers, null);
			httpsConnection.SSLSocketFactory = sSLContext.SocketFactory;
		}
	}

	private KeyManagerFactory? GetConfiguredKeyManagerFactory(KeyStore keyStore)
	{
		KeyManagerFactory keyManagerFactory = ConfigureKeyManagerFactory(keyStore);
		if (keyManagerFactory == null && HasClientCertificates)
		{
			keyManagerFactory = KeyManagerFactory.GetInstance("PKIX") ?? throw new InvalidOperationException("Failed to get the KeyManagerFactory instance for PKIX");
			keyManagerFactory.Init(keyStore, null);
		}
		return keyManagerFactory;
	}

	private KeyStore GetConfiguredKeyStoreInstance()
	{
		KeyStore keyStore = KeyStore.GetInstance(KeyStore.DefaultType) ?? throw new InvalidOperationException("Failed to get the default KeyStore instance");
		keyStore.Load(null, null);
		if (HasTrustedCerts)
		{
			for (int i = 0; i < TrustedCerts.Count; i++)
			{
				Certificate certificate = TrustedCerts[i];
				if (certificate != null)
				{
					keyStore.SetCertificateEntry($"ca{i}", certificate);
				}
			}
		}
		if (HasClientCertificates)
		{
			if (ClientCertificateOptions != ClientCertificateOption.Manual)
			{
				throw new InvalidOperationException("Use of ClientCertificates requires that ClientCertificateOptions be set to ClientCertificateOption.Manual");
			}
			for (int j = 0; j < _clientCertificates.Count; j++)
			{
				(IPrivateKey, Certificate[])? keyEntry = GetKeyEntry(new X509Certificate2(_clientCertificates[j]));
				if (keyEntry.HasValue)
				{
					var (key, chain) = keyEntry.GetValueOrDefault();
					keyStore.SetKeyEntry($"key{j}", key, null, chain);
				}
			}
		}
		return ConfigureKeyStore(keyStore) ?? throw new InvalidOperationException("ConfigureKeyStore unexpectedly returned null");
	}

	private ITrustManager[]? GetTrustManagers(TrustManagerFactory? tmf, KeyStore keyStore, HttpRequestMessage requestMessage)
	{
		if (tmf == null)
		{
			tmf = TrustManagerFactory.GetInstance(TrustManagerFactory.DefaultAlgorithm) ?? throw new InvalidOperationException("Failed to get the default TrustManagerFactory instance");
			tmf.Init(HasTrustedCerts ? keyStore : null);
		}
		ITrustManager[] array = tmf.GetTrustManagers();
		if (HasServerCertificateCustomValidationCallback)
		{
			array = _serverCertificateCustomValidator.ReplaceX509TrustManager(array, requestMessage);
		}
		return array;
	}

	private static (IPrivateKey, Certificate[])? GetKeyEntry(X509Certificate2 clientCertificate)
	{
		if (!clientCertificate.HasPrivateKey)
		{
			return null;
		}
		AsymmetricAlgorithm asymmetricAlgorithm = null;
		string text = null;
		RSA rSAPrivateKey = clientCertificate.GetRSAPrivateKey();
		if (rSAPrivateKey != null)
		{
			text = "RSA";
			asymmetricAlgorithm = rSAPrivateKey;
		}
		else
		{
			ECDsa eCDsaPrivateKey = clientCertificate.GetECDsaPrivateKey();
			if (eCDsaPrivateKey != null)
			{
				text = "EC";
				asymmetricAlgorithm = eCDsaPrivateKey;
			}
			else
			{
				DSA dSAPrivateKey = clientCertificate.GetDSAPrivateKey();
				if (dSAPrivateKey == null)
				{
					return null;
				}
				text = "DSA";
				asymmetricAlgorithm = dSAPrivateKey;
			}
		}
		IPrivateKey privateKey = (KeyFactory.GetInstance(text) ?? throw new InvalidOperationException("Failed to get the KeyFactory instance for algorithm " + text)).GeneratePrivate(new PKCS8EncodedKeySpec(asymmetricAlgorithm.ExportPkcs8PrivateKey()));
		Certificate certificate = Java.Lang.Object.GetObject<Certificate>(clientCertificate.Handle, JniHandleOwnership.DoNotTransfer);
		if (privateKey == null || certificate == null)
		{
			return null;
		}
		return (privateKey, new Certificate[1] { certificate });
	}

	private void HandlePreAuthentication(HttpURLConnection httpConnection)
	{
		AuthenticationData data = PreAuthenticationData;
		if (!PreAuthenticate || data == null)
		{
			return;
		}
		ICredentials credentials = ((!data.UseProxyAuthentication) ? Credentials : Proxy?.Credentials);
		if (credentials == null)
		{
			if (Logger.LogNet)
			{
				Logger.Log(LogLevel.Info, "monodroid-net", $"Authentication using scheme {data.Scheme} requested but no credentials found. No authentication will be performed");
			}
			return;
		}
		IAndroidAuthenticationModule androidAuthenticationModule = ((data.Scheme == AuthenticationScheme.Unsupported) ? data.AuthModule : authModules.Find((IAndroidAuthenticationModule m) => m?.Scheme == data.Scheme));
		if (androidAuthenticationModule == null)
		{
			if (Logger.LogNet)
			{
				Logger.Log(LogLevel.Info, "monodroid-net", $"Authentication module for scheme '{data.Scheme}' not found. No authentication will be performed");
			}
			return;
		}
		Authorization authorization = androidAuthenticationModule.Authenticate(data.Challenge, httpConnection, credentials);
		if (authorization == null)
		{
			if (Logger.LogNet)
			{
				Logger.Log(LogLevel.Info, "monodroid-net", $"Authorization module {androidAuthenticationModule.GetType()} for scheme {data.Scheme} returned no authorization");
			}
			return;
		}
		if (Logger.LogNet)
		{
			string value = (data.UseProxyAuthentication ? "Proxy-Authorization" : "Authorization");
			Logger.Log(LogLevel.Info, "monodroid-net", $"Authentication header '{value}' will be set to '{authorization.Message}'");
		}
		httpConnection.SetRequestProperty(data.UseProxyAuthentication ? "Proxy-Authorization" : "Authorization", authorization.Message);
	}

	private static string GetHeaderSeparator(string name)
	{
		if (!headerSeparators.TryGetValue(name, out string value))
		{
			return ",";
		}
		return value;
	}

	private void AddHeaders(HttpURLConnection conn, HttpHeaders headers)
	{
		if (headers == null)
		{
			return;
		}
		foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
		{
			conn.SetRequestProperty(header.Key, (header.Value != null) ? string.Join(GetHeaderSeparator(header.Key), header.Value) : string.Empty);
		}
	}

	private void SetupRequestBody(HttpURLConnection httpConnection, HttpRequestMessage request)
	{
		if (request.Content == null)
		{
			if (HttpMethod.Post.Equals(request.Method) || HttpMethod.Put.Equals(request.Method) || HttpMethod.Delete.Equals(request.Method))
			{
				httpConnection.SetRequestProperty("Content-Length", "0");
			}
			return;
		}
		httpConnection.DoOutput = true;
		long? contentLength = request.Content.Headers.ContentLength;
		if (contentLength.HasValue)
		{
			httpConnection.SetFixedLengthStreamingMode((int)contentLength.Value);
		}
		else
		{
			httpConnection.SetChunkedStreamingMode(0);
		}
	}
}
