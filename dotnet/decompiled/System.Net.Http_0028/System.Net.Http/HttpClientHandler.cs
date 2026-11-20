using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

public class HttpClientHandler : HttpMessageHandler
{
	private readonly HttpMessageHandler _nativeUnderlyingHandler;

	private IMeterFactory _nativeMeterFactory;

	private HttpMessageHandler _nativeFirstHandler;

	private readonly SocketsHttpHandler _socketHandler;

	private ClientCertificateOption _clientCertificateOptions;

	private volatile bool _disposed;

	[CompilerGenerated]
	private static Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> _003CDangerousAcceptAnyServerCertificateValidator_003Ek__BackingField;

	private HttpMessageHandler Handler
	{
		get
		{
			_ = 1;
			if (_nativeFirstHandler == null)
			{
				HttpMessageHandler nativeUnderlyingHandler = _nativeUnderlyingHandler;
				if (false)
				{
				}
				if (false)
				{
				}
				Interlocked.CompareExchange(ref _nativeFirstHandler, nativeUnderlyingHandler, null);
			}
			return _nativeFirstHandler;
		}
	}

	[CLSCompliant(false)]
	public IMeterFactory? MeterFactory
	{
		get
		{
			_ = 1;
			return _nativeMeterFactory;
		}
		set
		{
			ObjectDisposedException.ThrowIf(_disposed, this);
			_ = 1;
			if (_nativeFirstHandler != null)
			{
				throw new InvalidOperationException("net_http_operation_started");
			}
			_nativeMeterFactory = value;
		}
	}

	[UnsupportedOSPlatform("browser")]
	public bool UseCookies
	{
		get
		{
			_ = 1;
			return GetUseCookies();
		}
		set
		{
			_ = 1;
			SetUseCookies(value);
		}
	}

	[UnsupportedOSPlatform("browser")]
	public CookieContainer CookieContainer
	{
		get
		{
			_ = 1;
			return GetCookieContainer();
		}
		set
		{
			ArgumentNullException.ThrowIfNull(value, "value");
			_ = 1;
			SetCookieContainer(value);
		}
	}

	[UnsupportedOSPlatform("browser")]
	public ICredentials? DefaultProxyCredentials
	{
		get
		{
			_ = 1;
			return GetDefaultProxyCredentials();
		}
		set
		{
			_ = 1;
			SetDefaultProxyCredentials(value);
		}
	}

	[UnsupportedOSPlatform("browser")]
	public bool UseDefaultCredentials
	{
		get
		{
			_ = 1;
			ICredentials credentials = GetCredentials();
			return credentials == CredentialCache.DefaultCredentials;
		}
		set
		{
			if (value)
			{
				_ = 1;
				SetCredentials(CredentialCache.DefaultCredentials);
				return;
			}
			_ = 1;
			if (GetCredentials() == CredentialCache.DefaultCredentials)
			{
				SetCredentials(null);
			}
		}
	}

	[UnsupportedOSPlatform("browser")]
	public ICredentials? Credentials
	{
		get
		{
			_ = 1;
			return GetCredentials();
		}
		set
		{
			_ = 1;
			SetCredentials(value);
		}
	}

	public bool AllowAutoRedirect
	{
		get
		{
			_ = 1;
			return GetAllowAutoRedirect();
		}
		set
		{
			_ = 1;
			SetAllowAutoRedirect(value);
		}
	}

	[UnsupportedOSPlatform("browser")]
	public int MaxConnectionsPerServer
	{
		get
		{
			_ = 1;
			return GetMaxConnectionsPerServer();
		}
		set
		{
			_ = 1;
			SetMaxConnectionsPerServer(value);
		}
	}

	public long MaxRequestContentBufferSize
	{
		get
		{
			return 0L;
		}
		set
		{
			ArgumentOutOfRangeException.ThrowIfNegative(value, "value");
			if (value > int.MaxValue)
			{
				throw new ArgumentOutOfRangeException("value", value, System.SR.Format(CultureInfo.InvariantCulture, "net_http_content_buffersize_limit", int.MaxValue));
			}
			ObjectDisposedException.ThrowIf(_disposed, this);
		}
	}

	[UnsupportedOSPlatform("browser")]
	public int MaxResponseHeadersLength
	{
		get
		{
			_ = 1;
			return GetMaxResponseHeadersLength();
		}
		set
		{
			_ = 1;
			SetMaxResponseHeadersLength(value);
		}
	}

	public ClientCertificateOption ClientCertificateOptions
	{
		get
		{
			_ = 1;
			return GetClientCertificateOptions();
		}
		set
		{
			_ = 1;
			SetClientCertificateOptions(value);
		}
	}

	[UnsupportedOSPlatform("browser")]
	public X509CertificateCollection ClientCertificates
	{
		get
		{
			_ = 1;
			return GetClientCertificates();
		}
	}

	[UnsupportedOSPlatform("browser")]
	public Func<HttpRequestMessage, X509Certificate2?, X509Chain?, SslPolicyErrors, bool>? ServerCertificateCustomValidationCallback
	{
		get
		{
			_ = 1;
			return GetServerCertificateCustomValidationCallback();
		}
		set
		{
			_ = 1;
			SetServerCertificateCustomValidationCallback(value);
		}
	}

	[UnsupportedOSPlatform("browser")]
	public bool CheckCertificateRevocationList
	{
		get
		{
			_ = 1;
			return GetCheckCertificateRevocationList();
		}
		set
		{
			_ = 1;
			SetCheckCertificateRevocationList(value);
		}
	}

	[UnsupportedOSPlatform("browser")]
	public SslProtocols SslProtocols
	{
		get
		{
			_ = 1;
			return GetSslProtocols();
		}
		set
		{
			_ = 1;
			SetSslProtocols(value);
		}
	}

	public IDictionary<string, object?> Properties
	{
		get
		{
			_ = 1;
			return GetProperties();
		}
	}

	public virtual bool SupportsAutomaticDecompression
	{
		get
		{
			_ = 1;
			return GetSupportsAutomaticDecompression();
		}
	}

	public virtual bool SupportsProxy
	{
		get
		{
			_ = 1;
			return GetSupportsProxy();
		}
	}

	public virtual bool SupportsRedirectConfiguration
	{
		get
		{
			_ = 1;
			return GetSupportsRedirectConfiguration();
		}
	}

	[UnsupportedOSPlatform("browser")]
	public DecompressionMethods AutomaticDecompression
	{
		get
		{
			_ = 1;
			return GetAutomaticDecompression();
		}
		set
		{
			_ = 1;
			SetAutomaticDecompression(value);
		}
	}

	[UnsupportedOSPlatform("browser")]
	public bool UseProxy
	{
		get
		{
			_ = 1;
			return GetUseProxy();
		}
		set
		{
			_ = 1;
			SetUseProxy(value);
		}
	}

	[UnsupportedOSPlatform("browser")]
	[UnsupportedOSPlatform("ios")]
	[UnsupportedOSPlatform("tvos")]
	public IWebProxy? Proxy
	{
		get
		{
			_ = 1;
			return GetProxy();
		}
		set
		{
			_ = 1;
			SetProxy(value);
		}
	}

	[UnsupportedOSPlatform("browser")]
	public bool PreAuthenticate
	{
		get
		{
			_ = 1;
			return GetPreAuthenticate();
		}
		set
		{
			_ = 1;
			SetPreAuthenticate(value);
		}
	}

	[UnsupportedOSPlatform("browser")]
	public int MaxAutomaticRedirections
	{
		get
		{
			_ = 1;
			return GetMaxAutomaticRedirections();
		}
		set
		{
			_ = 1;
			SetMaxAutomaticRedirections(value);
		}
	}

	[UnsupportedOSPlatform("browser")]
	public static Func<HttpRequestMessage, X509Certificate2?, X509Chain?, SslPolicyErrors, bool> DangerousAcceptAnyServerCertificateValidator => _003CDangerousAcceptAnyServerCertificateValidator_003Ek__BackingField ?? Interlocked.CompareExchange(ref _003CDangerousAcceptAnyServerCertificateValidator_003Ek__BackingField, (HttpRequestMessage _003Cp0_003E, X509Certificate2 _003Cp1_003E, X509Chain _003Cp2_003E, SslPolicyErrors _003Cp3_003E) => true, null) ?? _003CDangerousAcceptAnyServerCertificateValidator_003Ek__BackingField;

	[FeatureSwitchDefinition("System.Net.Http.UseNativeHttpHandler")]
	private static bool IsNativeHandlerEnabled => true;

	public HttpClientHandler()
	{
		_ = 1;
		_nativeUnderlyingHandler = CreateNativeHandler();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && !_disposed)
		{
			_disposed = true;
			_ = 1;
			Handler.Dispose();
		}
		base.Dispose(disposing);
	}

	[UnsupportedOSPlatform("browser")]
	protected internal override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		throw new PlatformNotSupportedException();
	}

	protected internal override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		ArgumentNullException.ThrowIfNull(request, "request");
		return Handler.SendAsync(request, cancellationToken);
	}

	private void ThrowForModifiedManagedSslOptionsIfStarted()
	{
		_socketHandler.SslOptions = _socketHandler.SslOptions;
	}

	private ICredentials GetDefaultProxyCredentials()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_DefaultProxyCredentials")]
		static extern ICredentials CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private void SetDefaultProxyCredentials(ICredentials value)
	{
		CallNative(_nativeUnderlyingHandler, value);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_DefaultProxyCredentials")]
		static extern void CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler, ICredentials value);
	}

	private int GetMaxConnectionsPerServer()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_MaxConnectionsPerServer")]
		static extern int CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private void SetMaxConnectionsPerServer(int value)
	{
		CallNative(_nativeUnderlyingHandler, value);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_MaxConnectionsPerServer")]
		static extern void CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler, int value);
	}

	private int GetMaxResponseHeadersLength()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_MaxResponseHeadersLength")]
		static extern int CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private void SetMaxResponseHeadersLength(int value)
	{
		CallNative(_nativeUnderlyingHandler, value);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_MaxResponseHeadersLength")]
		static extern void CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler, int value);
	}

	private ClientCertificateOption GetClientCertificateOptions()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_ClientCertificateOptions")]
		static extern ClientCertificateOption CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private void SetClientCertificateOptions(ClientCertificateOption value)
	{
		CallNative(_nativeUnderlyingHandler, value);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_ClientCertificateOptions")]
		static extern void CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler, ClientCertificateOption value);
	}

	private X509CertificateCollection GetClientCertificates()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_ClientCertificates")]
		static extern X509CertificateCollection CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> GetServerCertificateCustomValidationCallback()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_ServerCertificateCustomValidationCallback")]
		static extern Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private void SetServerCertificateCustomValidationCallback(Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> value)
	{
		CallNative(_nativeUnderlyingHandler, value);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_ServerCertificateCustomValidationCallback")]
		static extern void CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler, Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> value);
	}

	private bool GetCheckCertificateRevocationList()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_CheckCertificateRevocationList")]
		static extern bool CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private void SetCheckCertificateRevocationList(bool value)
	{
		CallNative(_nativeUnderlyingHandler, value);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_CheckCertificateRevocationList")]
		static extern void CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler, bool value);
	}

	private SslProtocols GetSslProtocols()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_SslProtocols")]
		static extern SslProtocols CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private void SetSslProtocols(SslProtocols value)
	{
		CallNative(_nativeUnderlyingHandler, value);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_SslProtocols")]
		static extern void CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler, SslProtocols value);
	}

	private IDictionary<string, object> GetProperties()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_Properties")]
		static extern IDictionary<string, object> CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private bool GetSupportsAutomaticDecompression()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_SupportsAutomaticDecompression")]
		static extern bool CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private bool GetSupportsProxy()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_SupportsProxy")]
		static extern bool CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private bool GetSupportsRedirectConfiguration()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_SupportsRedirectConfiguration")]
		static extern bool CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private DecompressionMethods GetAutomaticDecompression()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_AutomaticDecompression")]
		static extern DecompressionMethods CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private void SetAutomaticDecompression(DecompressionMethods value)
	{
		CallNative(_nativeUnderlyingHandler, value);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_AutomaticDecompression")]
		static extern void CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler, DecompressionMethods value);
	}

	private bool GetUseProxy()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_UseProxy")]
		static extern bool CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private void SetUseProxy(bool value)
	{
		CallNative(_nativeUnderlyingHandler, value);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_UseProxy")]
		static extern void CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler, bool value);
	}

	private IWebProxy GetProxy()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_Proxy")]
		static extern IWebProxy CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private void SetProxy(IWebProxy value)
	{
		CallNative(_nativeUnderlyingHandler, value);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_Proxy")]
		static extern void CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler, IWebProxy value);
	}

	private bool GetPreAuthenticate()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_PreAuthenticate")]
		static extern bool CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private void SetPreAuthenticate(bool value)
	{
		CallNative(_nativeUnderlyingHandler, value);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_PreAuthenticate")]
		static extern void CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler, bool value);
	}

	private int GetMaxAutomaticRedirections()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_MaxAutomaticRedirections")]
		static extern int CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private void SetMaxAutomaticRedirections(int value)
	{
		CallNative(_nativeUnderlyingHandler, value);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_MaxAutomaticRedirections")]
		static extern void CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler, int value);
	}

	private bool GetUseCookies()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_UseCookies")]
		static extern bool CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private void SetUseCookies(bool value)
	{
		CallNative(_nativeUnderlyingHandler, value);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_UseCookies")]
		static extern void CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler, bool value);
	}

	private CookieContainer GetCookieContainer()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_CookieContainer")]
		static extern CookieContainer CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private void SetCookieContainer(CookieContainer value)
	{
		CallNative(_nativeUnderlyingHandler, value);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_CookieContainer")]
		static extern void CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler, CookieContainer value);
	}

	private bool GetAllowAutoRedirect()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_AllowAutoRedirect")]
		static extern bool CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private void SetAllowAutoRedirect(bool value)
	{
		CallNative(_nativeUnderlyingHandler, value);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_AllowAutoRedirect")]
		static extern void CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler, bool value);
	}

	private ICredentials GetCredentials()
	{
		return CallNative(_nativeUnderlyingHandler);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_Credentials")]
		static extern ICredentials CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler);
	}

	private void SetCredentials(ICredentials value)
	{
		CallNative(_nativeUnderlyingHandler, value);
		[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_Credentials")]
		static extern void CallNative([UnsafeAccessorType("Xamarin.Android.Net.AndroidMessageHandler, Mono.Android")] object handler, ICredentials value);
	}

	private static HttpMessageHandler CreateNativeHandler()
	{
		return CallNative(null);
		[UnsafeAccessor(UnsafeAccessorKind.StaticMethod, Name = "GetHttpMessageHandler")]
		static extern HttpMessageHandler CallNative([UnsafeAccessorType("Android.Runtime.AndroidEnvironment, Mono.Android")] object _);
	}
}
