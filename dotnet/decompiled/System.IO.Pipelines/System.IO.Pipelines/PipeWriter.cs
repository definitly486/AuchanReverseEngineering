using System.Buffers;
using System.Threading;
using System.Threading.Tasks;

namespace System.IO.Pipelines;

public abstract class PipeWriter : IBufferWriter<byte>
{
	public virtual bool CanGetUnflushedBytes => false;

	public virtual long UnflushedBytes
	{
		get
		{
			throw ThrowHelper.CreateNotSupportedException_UnflushedBytes();
		}
	}

	public abstract ValueTask<FlushResult> FlushAsync(CancellationToken cancellationToken = default(CancellationToken));

	public abstract void Advance(int bytes);

	public abstract Memory<byte> GetMemory(int sizeHint = 0);

	public abstract Span<byte> GetSpan(int sizeHint = 0);
}
