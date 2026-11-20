using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

namespace System.Net.Http;

public class HttpRequestMessage : IDisposable
{
	private int _sendStatus;

	private HttpMethod _method;

	private Uri _requestUri;

	private HttpRequestHeaders _headers;

	private Version _version;

	private HttpVersionPolicy _versionPolicy;

	private HttpContent _content;

	internal HttpRequestOptions _options;

	internal static Version DefaultRequestVersion => HttpVersion.Version11;

	public Version Version
	{
		get
		{
			return _version;
		}
		set
		{
			ArgumentNullException.ThrowIfNull(value, "value");
			CheckDisposed();
			_version = value;
		}
	}

	public HttpVersionPolicy VersionPolicy
	{
		get
		{
			return _versionPolicy;
		}
		set
		{
			CheckDisposed();
			_versionPolicy = value;
		}
	}

	public HttpContent? Content
	{
		get
		{
			return _content;
		}
		set
		{
			CheckDisposed();
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			_content = value;
		}
	}

	public HttpMethod Method
	{
		get
		{
			return _method;
		}
		set
		{
			ArgumentNullException.ThrowIfNull(value, "value");
			CheckDisposed();
			_method = value;
		}
	}

	public Uri? RequestUri
	{
		get
		{
			return _requestUri;
		}
		set
		{
			CheckDisposed();
			_requestUri = value;
		}
	}

	public HttpRequestHeaders Headers => _headers ?? (_headers = new HttpRequestHeaders());

	internal bool HasHeaders => _headers != null;

	[Obsolete("HttpRequestMessage.Properties has been deprecated. Use Options instead.")]
	public IDictionary<string, object?> Properties => Options;

	public HttpRequestOptions Options => _options ?? (_options = new HttpRequestOptions());

	private bool Disposed
	{
		get
		{
			return (_sendStatus & 4) != 0;
		}
		set
		{
			_sendStatus |= 4;
		}
	}

	internal bool IsExtendedConnectRequest
	{
		get
		{
			if (Method == HttpMethod.Connect)
			{
				return _headers?.Protocol != null;
			}
			return false;
		}
	}

	public HttpRequestMessage()
		: this(HttpMethod.Get, (Uri?)null)
	{
	}

	public HttpRequestMessage(HttpMethod method, Uri? requestUri)
	{
		ArgumentNullException.ThrowIfNull(method, "method");
		_method = method;
		_requestUri = requestUri;
		_version = DefaultRequestVersion;
		_versionPolicy = HttpVersionPolicy.RequestVersionOrLower;
	}

	public HttpRequestMessage(HttpMethod method, [StringSyntax("Uri")] string? requestUri)
		: this(method, string.IsNullOrEmpty(requestUri) ? null : new Uri(requestUri, UriKind.RelativeOrAbsolute))
	{
	}

	public override string ToString()
	{
		Span<char> initialBuffer = stackalloc char[512];
		System.Text.ValueStringBuilder sb = new System.Text.ValueStringBuilder(initialBuffer);
		sb.Append("Method: ");
		sb.Append(_method.ToString());
		sb.Append(", RequestUri: '");
		if ((object)_requestUri == null)
		{
			sb.Append("<null>");
		}
		else
		{
			sb.AppendSpanFormattable(_requestUri);
		}
		sb.Append("', Version: ");
		sb.AppendSpanFormattable(_version);
		sb.Append(", Content: ");
		sb.Append((_content == null) ? "<null>" : _content.GetType().ToString());
		sb.Append(", Headers:");
		sb.Append("\n");
		HeaderUtilities.DumpHeaders(ref sb, _headers, _content?.Headers);
		return sb.ToString();
	}

	internal bool MarkAsSent()
	{
		return Interlocked.CompareExchange(ref _sendStatus, 1, 0) == 0;
	}

	internal bool WasSentByHttpClient()
	{
		return (_sendStatus & 1) != 0;
	}

	internal void MarkPropagatorStateInjectedByDiagnosticsHandler()
	{
		_sendStatus |= 2;
	}

	internal bool WasPropagatorStateInjectedByDiagnosticsHandler()
	{
		return (_sendStatus & 2) != 0;
	}

	internal void DisableAuth()
	{
		_sendStatus |= 8;
	}

	internal bool IsAuthDisabled()
	{
		return (_sendStatus & 8) != 0;
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing && !Disposed)
		{
			Disposed = true;
			_content?.Dispose();
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	private void CheckDisposed()
	{
		ObjectDisposedException.ThrowIf(Disposed, this);
	}
}
