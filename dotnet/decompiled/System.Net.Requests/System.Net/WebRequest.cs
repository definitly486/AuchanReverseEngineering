using System.Collections.Generic;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net;

public abstract class WebRequest : MarshalByRefObject, ISerializable
{
	internal sealed class WebRequestPrefixElement
	{
		public readonly string Prefix;

		public readonly IWebRequestCreate Creator;

		public WebRequestPrefixElement(string prefix, IWebRequestCreate creator)
		{
			Prefix = prefix;
			Creator = creator;
		}
	}

	internal sealed class HttpRequestCreator : IWebRequestCreate
	{
		public WebRequest Create(Uri Uri)
		{
			return new HttpWebRequest(Uri);
		}
	}

	private static List<WebRequestPrefixElement> s_prefixList;

	private static object s_internalSyncObject = new object();

	[CompilerGenerated]
	private AuthenticationLevel _003CAuthenticationLevel_003Ek__BackingField = AuthenticationLevel.MutualAuthRequested;

	private static IWebProxy s_DefaultWebProxy;

	private static bool s_DefaultWebProxyInitialized;

	internal static List<WebRequestPrefixElement> PrefixList => LazyInitializer.EnsureInitialized(ref s_prefixList, ref s_internalSyncObject, delegate
	{
		HttpRequestCreator creator = new HttpRequestCreator();
		FtpWebRequestCreator creator2 = new FtpWebRequestCreator();
		FileWebRequestCreator creator3 = new FileWebRequestCreator();
		return new List<WebRequestPrefixElement>(4)
		{
			new WebRequestPrefixElement("http:", creator),
			new WebRequestPrefixElement("https:", creator),
			new WebRequestPrefixElement("ftp:", creator2),
			new WebRequestPrefixElement("file:", creator3)
		};
	});

	public static RequestCachePolicy? DefaultCachePolicy { get; } = new RequestCachePolicy(RequestCacheLevel.BypassCache);

	public virtual RequestCachePolicy? CachePolicy { get; }

	public TokenImpersonationLevel ImpersonationLevel { get; }

	public virtual string Method
	{
		get
		{
			throw System.NotImplemented.ByDesignWithMessage("net_PropertyNotImplementedException");
		}
		set
		{
			throw System.NotImplemented.ByDesignWithMessage("net_PropertyNotImplementedException");
		}
	}

	public virtual Uri RequestUri
	{
		get
		{
			throw System.NotImplemented.ByDesignWithMessage("net_PropertyNotImplementedException");
		}
	}

	public virtual ICredentials? Credentials
	{
		get
		{
			throw System.NotImplemented.ByDesignWithMessage("net_PropertyNotImplementedException");
		}
	}

	public virtual int Timeout
	{
		get
		{
			throw System.NotImplemented.ByDesignWithMessage("net_PropertyNotImplementedException");
		}
		set
		{
			throw System.NotImplemented.ByDesignWithMessage("net_PropertyNotImplementedException");
		}
	}

	public static IWebProxy? DefaultWebProxy => LazyInitializer.EnsureInitialized(ref s_DefaultWebProxy, ref s_DefaultWebProxyInitialized, ref s_internalSyncObject, GetSystemWebProxy);

	public virtual bool PreAuthenticate
	{
		get
		{
			throw System.NotImplemented.ByDesignWithMessage("net_PropertyNotImplementedException");
		}
	}

	[Obsolete("WebRequest, HttpWebRequest, ServicePoint, and WebClient are obsolete. Use HttpClient instead.", DiagnosticId = "SYSLIB0014", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	protected WebRequest()
	{
	}

	[Obsolete("Serialization has been deprecated for WebRequest.")]
	void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{
		throw new PlatformNotSupportedException();
	}

	[Obsolete("Serialization has been deprecated for WebRequest.")]
	protected virtual void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{
		throw new PlatformNotSupportedException();
	}

	private static WebRequest Create(Uri requestUri, bool useUriBase)
	{
		WebRequestPrefixElement webRequestPrefixElement = null;
		bool flag = false;
		string text = (useUriBase ? (requestUri.Scheme + ":") : requestUri.AbsoluteUri);
		int length = text.Length;
		List<WebRequestPrefixElement> prefixList = PrefixList;
		for (int i = 0; i < prefixList.Count; i++)
		{
			webRequestPrefixElement = prefixList[i];
			if (length >= webRequestPrefixElement.Prefix.Length && string.Compare(webRequestPrefixElement.Prefix, 0, text, 0, webRequestPrefixElement.Prefix.Length, StringComparison.OrdinalIgnoreCase) == 0)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			return webRequestPrefixElement.Creator.Create(requestUri);
		}
		throw new NotSupportedException("net_unknown_prefix");
	}

	[Obsolete("WebRequest, HttpWebRequest, ServicePoint, and WebClient are obsolete. Use HttpClient instead.", DiagnosticId = "SYSLIB0014", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public static WebRequest CreateDefault(Uri requestUri)
	{
		ArgumentNullException.ThrowIfNull(requestUri, "requestUri");
		return Create(requestUri, useUriBase: true);
	}

	[Obsolete("WebRequest, HttpWebRequest, ServicePoint, and WebClient are obsolete. Use HttpClient instead.", DiagnosticId = "SYSLIB0014", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public static HttpWebRequest CreateHttp(Uri requestUri)
	{
		ArgumentNullException.ThrowIfNull(requestUri, "requestUri");
		if (requestUri.Scheme != "http" && requestUri.Scheme != "https")
		{
			throw new NotSupportedException("net_unknown_prefix");
		}
		return (HttpWebRequest)CreateDefault(requestUri);
	}

	public virtual IAsyncResult BeginGetResponse(AsyncCallback? callback, object? state)
	{
		throw System.NotImplemented.ByDesignWithMessage("net_MethodNotImplementedException");
	}

	public virtual WebResponse EndGetResponse(IAsyncResult asyncResult)
	{
		throw System.NotImplemented.ByDesignWithMessage("net_MethodNotImplementedException");
	}

	public virtual async Task<WebResponse> GetResponseAsync()
	{
		await Task.CompletedTask.ConfigureAwait(ConfigureAwaitOptions.ForceYielding);
		return await Task<WebResponse>.Factory.FromAsync((AsyncCallback callback, object state) => ((WebRequest)state).BeginGetResponse(callback, state), (IAsyncResult iar) => ((WebRequest)iar.AsyncState).EndGetResponse(iar), this).ConfigureAwait(continueOnCapturedContext: false);
	}

	public static IWebProxy GetSystemWebProxy()
	{
		return HttpClient.DefaultProxy;
	}
}
