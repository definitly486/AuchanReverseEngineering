using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net;

public class HttpWebResponse : WebResponse, ISerializable
{
	internal sealed class TruncatedReadStream(Stream innerStream, long maxSize) : Stream()
	{
		private long _maxRemainingLength = maxSize;

		public override bool CanRead => true;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public override long Position
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public override void Flush()
		{
			throw new NotSupportedException();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return Read(new Span<byte>(buffer, offset, count));
		}

		public override int Read(Span<byte> buffer)
		{
			int num = innerStream.Read(buffer.Slice(0, (int)Math.Min(buffer.Length, maxSize)));
			maxSize -= num;
			return num;
		}

		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return ReadAsync(new Memory<byte>(buffer, offset, count), cancellationToken).AsTask();
		}

		public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default(CancellationToken))
		{
			int num = await innerStream.ReadAsync(buffer.Slice(0, (int)Math.Min(buffer.Length, maxSize)), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			maxSize -= num;
			return num;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		public override ValueTask DisposeAsync()
		{
			return innerStream.DisposeAsync();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				innerStream.Dispose();
			}
		}
	}

	private HttpResponseMessage _httpResponseMessage;

	private readonly Uri _requestUri;

	private CookieCollection _cookies;

	private WebHeaderCollection _webHeaderCollection;

	private readonly bool _isVersionHttp11 = true;

	public override WebHeaderCollection Headers
	{
		get
		{
			CheckDisposed();
			if (_webHeaderCollection == null)
			{
				_webHeaderCollection = new WebHeaderCollection();
				foreach (KeyValuePair<string, IEnumerable<string>> header in _httpResponseMessage.Headers)
				{
					_webHeaderCollection[header.Key] = GetHeaderValueAsString(header.Value);
				}
				if (_httpResponseMessage.Content != null)
				{
					foreach (KeyValuePair<string, IEnumerable<string>> header2 in _httpResponseMessage.Content.Headers)
					{
						_webHeaderCollection[header2.Key] = GetHeaderValueAsString(header2.Value);
					}
				}
			}
			return _webHeaderCollection;
		}
	}

	public virtual HttpStatusCode StatusCode
	{
		get
		{
			CheckDisposed();
			return _httpResponseMessage.StatusCode;
		}
	}

	public virtual string StatusDescription
	{
		get
		{
			CheckDisposed();
			return _httpResponseMessage.ReasonPhrase ?? string.Empty;
		}
	}

	[Obsolete("Serialization has been deprecated for HttpWebResponse.")]
	void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{
		throw new PlatformNotSupportedException();
	}

	[Obsolete("Serialization has been deprecated for HttpWebResponse.")]
	protected override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{
		throw new PlatformNotSupportedException();
	}

	internal HttpWebResponse(HttpResponseMessage _message, Uri requestUri, CookieContainer cookieContainer)
	{
		_httpResponseMessage = _message;
		_requestUri = requestUri;
		if (cookieContainer != null)
		{
			_cookies = cookieContainer.GetCookies(requestUri);
		}
		else
		{
			_cookies = new CookieCollection();
		}
	}

	public override Stream GetResponseStream()
	{
		CheckDisposed();
		if (_httpResponseMessage.Content != null)
		{
			Stream stream = _httpResponseMessage.Content.ReadAsStream();
			int defaultMaximumErrorResponseLength = HttpWebRequest.DefaultMaximumErrorResponseLength;
			if (defaultMaximumErrorResponseLength < 0 || StatusCode < HttpStatusCode.BadRequest)
			{
				return stream;
			}
			return new TruncatedReadStream(stream, (long)defaultMaximumErrorResponseLength * 1024L);
		}
		return Stream.Null;
	}

	public override void Close()
	{
		Dispose(disposing: true);
	}

	protected override void Dispose(bool disposing)
	{
		HttpResponseMessage httpResponseMessage = _httpResponseMessage;
		if (httpResponseMessage != null)
		{
			httpResponseMessage.Dispose();
			_httpResponseMessage = null;
		}
	}

	private void CheckDisposed()
	{
		ObjectDisposedException.ThrowIf(_httpResponseMessage == null, this);
	}

	private static string GetHeaderValueAsString(IEnumerable<string> values)
	{
		return string.Join(", ", values);
	}
}
