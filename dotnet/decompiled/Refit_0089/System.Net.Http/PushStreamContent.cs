using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace System.Net.Http;

[ExcludeFromCodeCoverage]
internal class PushStreamContent : HttpContent
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct AsyncVoid
	{
	}

	internal class CompleteTaskOnCloseStream : DelegatingStream
	{
		private readonly TaskCompletionSource<bool> serializeToStreamTask;

		public CompleteTaskOnCloseStream(Stream innerStream, TaskCompletionSource<bool> serializeToStreamTask)
			: base(innerStream)
		{
			this.serializeToStreamTask = serializeToStreamTask ?? throw new ArgumentNullException("serializeToStreamTask");
		}

		protected override void Dispose(bool disposing)
		{
			serializeToStreamTask.TrySetResult(result: true);
		}
	}

	private readonly Func<Stream, HttpContent, TransportContext?, Task> onStreamAvailable;

	public PushStreamContent(Action<Stream, HttpContent, TransportContext?> onStreamAvailable)
		: this(Taskify(onStreamAvailable), (MediaTypeHeaderValue?)null)
	{
	}

	public PushStreamContent(Func<Stream, HttpContent, TransportContext?, Task> onStreamAvailable)
		: this(onStreamAvailable, (MediaTypeHeaderValue?)null)
	{
	}

	public PushStreamContent(Action<Stream, HttpContent, TransportContext?> onStreamAvailable, string mediaType)
		: this(Taskify(onStreamAvailable), new MediaTypeHeaderValue(mediaType))
	{
	}

	public PushStreamContent(Func<Stream, HttpContent, TransportContext?, Task> onStreamAvailable, string mediaType)
		: this(onStreamAvailable, new MediaTypeHeaderValue(mediaType))
	{
	}

	public PushStreamContent(Action<Stream, HttpContent, TransportContext?> onStreamAvailable, MediaTypeHeaderValue? mediaType)
		: this(Taskify(onStreamAvailable), mediaType)
	{
	}

	public PushStreamContent(Func<Stream, HttpContent, TransportContext?, Task> onStreamAvailable, MediaTypeHeaderValue? mediaType)
	{
		this.onStreamAvailable = onStreamAvailable ?? throw new ArgumentNullException("onStreamAvailable");
		base.Headers.ContentType = mediaType ?? new MediaTypeHeaderValue("application/octet-stream");
	}

	private static Func<Stream, HttpContent, TransportContext?, Task> Taskify(Action<Stream, HttpContent, TransportContext?> onStreamAvailable)
	{
		if (onStreamAvailable == null)
		{
			throw new ArgumentNullException("onStreamAvailable");
		}
		return delegate(Stream stream, HttpContent content, TransportContext? transportContext)
		{
			onStreamAvailable(stream, content, transportContext);
			return Task.FromResult(default(AsyncVoid));
		};
	}

	protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
	{
		TaskCompletionSource<bool> serializeToStreamTask = new TaskCompletionSource<bool>();
		using Stream wrappedStream = new CompleteTaskOnCloseStream(stream, serializeToStreamTask);
		await onStreamAvailable(wrappedStream, this, context).ConfigureAwait(continueOnCapturedContext: false);
		await serializeToStreamTask.Task.ConfigureAwait(continueOnCapturedContext: false);
	}

	protected override bool TryComputeLength(out long length)
	{
		length = -1L;
		return false;
	}
}
