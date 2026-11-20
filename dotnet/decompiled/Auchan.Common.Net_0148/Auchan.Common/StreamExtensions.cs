using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Auchan.Common;

public static class StreamExtensions
{
	private const int COPY_BUFFER_SIZE = 4096;

	public static async Task CopyWithCancellationToAsync(this Stream source, Stream destination, CancellationToken cancellationToken)
	{
		byte[] buffer = new byte[4096];
		while (true)
		{
			cancellationToken.ThrowIfCancellationRequested();
			int num = await source.ReadAsync(buffer, 0, buffer.Length, cancellationToken);
			cancellationToken.ThrowIfCancellationRequested();
			if (num == 0)
			{
				break;
			}
			await destination.WriteAsync(buffer, 0, num, cancellationToken);
		}
	}
}
