using System.Diagnostics.CodeAnalysis;
using System.Net.Http.HPack;
using System.Net.Http.QPack;
using System.Text;

namespace System.Net.Http;

public class HttpMethod : IEquatable<HttpMethod>
{
	private readonly string _method;

	private int _hashcode;

	private byte[] _http1EncodedBytes;

	private byte[] _http2EncodedBytes;

	private byte[] _http3EncodedBytes;

	private int _http3Index;

	public static HttpMethod Get { get; } = new HttpMethod("GET", 17);

	public static HttpMethod Put { get; } = new HttpMethod("PUT", 21);

	public static HttpMethod Post { get; } = new HttpMethod("POST", 20);

	public static HttpMethod Delete { get; } = new HttpMethod("DELETE", 16);

	public static HttpMethod Head { get; } = new HttpMethod("HEAD", 18);

	public static HttpMethod Options { get; } = new HttpMethod("OPTIONS", 19);

	public static HttpMethod Trace { get; } = new HttpMethod("TRACE", -1);

	public static HttpMethod Patch { get; } = new HttpMethod("PATCH", -1);

	public static HttpMethod Query { get; } = new HttpMethod("QUERY", -1);

	public static HttpMethod Connect { get; } = new HttpMethod("CONNECT", 15);

	public string Method => _method;

	internal bool MustHaveRequestBody { get; private set; }

	internal bool IsConnect { get; private set; }

	internal bool IsHead { get; private set; }

	internal byte[] Http1EncodedBytes => _http1EncodedBytes ?? CreateHttp1EncodedBytes();

	internal byte[] Http2EncodedBytes => _http2EncodedBytes ?? CreateHttp2EncodedBytes();

	internal byte[] Http3EncodedBytes => _http3EncodedBytes ?? CreateHttp3EncodedBytes();

	public HttpMethod(string method)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(method, "method");
		if (!HttpRuleParser.IsToken(method.AsSpan()))
		{
			throw new FormatException("net_http_httpmethod_format_error");
		}
		_method = method;
		Initialize(method);
	}

	private HttpMethod(string method, int http3StaticTableIndex)
	{
		_method = method;
		Initialize(http3StaticTableIndex);
	}

	private void Initialize(int http3Index)
	{
		_http3Index = http3Index;
		bool flag;
		switch (http3Index)
		{
		case 15:
			IsConnect = true;
			return;
		case 18:
			IsHead = true;
			return;
		case 16:
		case 17:
		case 19:
			flag = true;
			break;
		default:
			flag = false;
			break;
		}
		MustHaveRequestBody = !flag;
	}

	private void Initialize(string method)
	{
		Initialize(GetKnownMethod(method.AsSpan())?._http3Index ?? 0);
	}

	public bool Equals([NotNullWhen(true)] HttpMethod? other)
	{
		if ((object)other != null)
		{
			return string.Equals(_method, other._method, StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is HttpMethod other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (_hashcode == 0)
		{
			_hashcode = StringComparer.OrdinalIgnoreCase.GetHashCode(_method);
		}
		return _hashcode;
	}

	public override string ToString()
	{
		return _method;
	}

	public static bool operator ==(HttpMethod? left, HttpMethod? right)
	{
		if ((object)left != null && (object)right != null)
		{
			return left.Equals(right);
		}
		return (object)left == right;
	}

	public static bool operator !=(HttpMethod? left, HttpMethod? right)
	{
		return !(left == right);
	}

	public static HttpMethod Parse(ReadOnlySpan<char> method)
	{
		return GetKnownMethod(method) ?? new HttpMethod(method.ToString());
	}

	internal static HttpMethod GetKnownMethod(ReadOnlySpan<char> method)
	{
		if (method.Length >= 3)
		{
			HttpMethod httpMethod = (method[0] | 0x20) switch
			{
				99 => Connect, 
				100 => Delete, 
				103 => Get, 
				104 => Head, 
				111 => Options, 
				112 => method.Length switch
				{
					3 => Put, 
					4 => Post, 
					_ => Patch, 
				}, 
				113 => Query, 
				116 => Trace, 
				_ => null, 
			};
			if ((object)httpMethod != null && MemoryExtensions.Equals(method, httpMethod._method.AsSpan(), StringComparison.OrdinalIgnoreCase))
			{
				return httpMethod;
			}
		}
		return null;
	}

	private byte[] CreateHttp1EncodedBytes()
	{
		HttpMethod knownMethod = GetKnownMethod(Method.AsSpan());
		byte[] array = knownMethod?._http1EncodedBytes;
		if (array == null)
		{
			string obj = knownMethod?.Method ?? Method;
			array = new byte[obj.Length + 1];
			Ascii.FromUtf16(obj.AsSpan(), array, out var _);
			array[^1] = 32;
			if ((object)knownMethod != null)
			{
				knownMethod._http1EncodedBytes = array;
			}
		}
		_http1EncodedBytes = array;
		return array;
	}

	private byte[] CreateHttp2EncodedBytes()
	{
		HttpMethod knownMethod = GetKnownMethod(Method.AsSpan());
		byte[] array = knownMethod?._http2EncodedBytes;
		if (array == null)
		{
			array = _http3Index switch
			{
				17 => new byte[1] { 130 }, 
				20 => new byte[1] { 131 }, 
				_ => HPackEncoder.EncodeLiteralHeaderFieldWithoutIndexingToAllocatedArray(2, knownMethod?.Method ?? Method), 
			};
			if ((object)knownMethod != null)
			{
				knownMethod._http2EncodedBytes = array;
			}
		}
		_http2EncodedBytes = array;
		return array;
	}

	private byte[] CreateHttp3EncodedBytes()
	{
		HttpMethod knownMethod = GetKnownMethod(Method.AsSpan());
		byte[] array = knownMethod?._http3EncodedBytes;
		if (array == null)
		{
			array = ((_http3Index > 0) ? QPackEncoder.EncodeStaticIndexedHeaderFieldToArray(_http3Index) : QPackEncoder.EncodeLiteralHeaderFieldWithStaticNameReferenceToArray(17, knownMethod?.Method ?? Method));
			if ((object)knownMethod != null)
			{
				knownMethod._http3EncodedBytes = array;
			}
		}
		_http3EncodedBytes = array;
		return array;
	}
}
