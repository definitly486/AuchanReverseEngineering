using System.Buffers;
using System.Collections.Generic;
using System.IO.Strategies;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace System.IO;

public static class RandomAccess
{
	public static long GetLength(SafeFileHandle handle)
	{
		ValidateInput(handle, 0L);
		return handle.GetFileLength();
	}

	public static void SetLength(SafeFileHandle handle, long length)
	{
		ValidateInput(handle, 0L);
		if (length < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException_NeedNonNegNum("length");
		}
		SetFileLength(handle, length);
	}

	public static int Read(SafeFileHandle handle, Span<byte> buffer, long fileOffset)
	{
		ValidateInput(handle, fileOffset);
		return ReadAtOffset(handle, buffer, fileOffset);
	}

	public static long Read(SafeFileHandle handle, IReadOnlyList<Memory<byte>> buffers, long fileOffset)
	{
		ValidateInput(handle, fileOffset);
		ValidateBuffers(buffers);
		return ReadScatterAtOffset(handle, buffers, fileOffset);
	}

	public static ValueTask<int> ReadAsync(SafeFileHandle handle, Memory<byte> buffer, long fileOffset, CancellationToken cancellationToken = default(CancellationToken))
	{
		ValidateInput(handle, fileOffset);
		if (cancellationToken.IsCancellationRequested)
		{
			return ValueTask.FromCanceled<int>(cancellationToken);
		}
		return ReadAtOffsetAsync(handle, buffer, fileOffset, cancellationToken);
	}

	public static ValueTask<long> ReadAsync(SafeFileHandle handle, IReadOnlyList<Memory<byte>> buffers, long fileOffset, CancellationToken cancellationToken = default(CancellationToken))
	{
		ValidateInput(handle, fileOffset);
		ValidateBuffers(buffers);
		if (cancellationToken.IsCancellationRequested)
		{
			return ValueTask.FromCanceled<long>(cancellationToken);
		}
		return ReadScatterAtOffsetAsync(handle, buffers, fileOffset, cancellationToken);
	}

	public static void Write(SafeFileHandle handle, ReadOnlySpan<byte> buffer, long fileOffset)
	{
		ValidateInput(handle, fileOffset);
		WriteAtOffset(handle, buffer, fileOffset);
	}

	public static void Write(SafeFileHandle handle, IReadOnlyList<ReadOnlyMemory<byte>> buffers, long fileOffset)
	{
		ValidateInput(handle, fileOffset);
		ValidateBuffers(buffers);
		WriteGatherAtOffset(handle, buffers, fileOffset);
	}

	public static ValueTask WriteAsync(SafeFileHandle handle, ReadOnlyMemory<byte> buffer, long fileOffset, CancellationToken cancellationToken = default(CancellationToken))
	{
		ValidateInput(handle, fileOffset);
		if (cancellationToken.IsCancellationRequested)
		{
			return ValueTask.FromCanceled(cancellationToken);
		}
		return WriteAtOffsetAsync(handle, buffer, fileOffset, cancellationToken);
	}

	public static ValueTask WriteAsync(SafeFileHandle handle, IReadOnlyList<ReadOnlyMemory<byte>> buffers, long fileOffset, CancellationToken cancellationToken = default(CancellationToken))
	{
		ValidateInput(handle, fileOffset);
		ValidateBuffers(buffers);
		if (cancellationToken.IsCancellationRequested)
		{
			return ValueTask.FromCanceled(cancellationToken);
		}
		return WriteGatherAtOffsetAsync(handle, buffers, fileOffset, cancellationToken);
	}

	public static void FlushToDisk(SafeFileHandle handle)
	{
		ValidateInput(handle, 0L, allowUnseekableHandles: true);
		FileStreamHelpers.FlushToDisk(handle);
	}

	private static void ValidateInput(SafeFileHandle handle, long fileOffset, bool allowUnseekableHandles = false)
	{
		if (handle == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.handle);
		}
		else if (handle.IsInvalid)
		{
			ThrowHelper.ThrowArgumentException_InvalidHandle("handle");
		}
		else if (!handle.CanSeek)
		{
			if (handle.IsClosed)
			{
				ThrowHelper.ThrowObjectDisposedException_FileClosed();
			}
			if (!allowUnseekableHandles)
			{
				ThrowHelper.ThrowNotSupportedException_UnseekableStream();
			}
		}
		else if (fileOffset < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException_NeedNonNegNum("fileOffset");
		}
	}

	private static void ValidateBuffers<T>(IReadOnlyList<T> buffers)
	{
		if (buffers == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.buffers);
		}
	}

	internal static void SetFileLength(SafeFileHandle handle, long length)
	{
		FileStreamHelpers.CheckFileCall(Interop.Sys.FTruncate(handle, length), handle.Path);
	}

	internal unsafe static int ReadAtOffset(SafeFileHandle handle, Span<byte> buffer, long fileOffset)
	{
		fixed (byte* reference = &MemoryMarshal.GetReference(buffer))
		{
			int num;
			if (handle.SupportsRandomAccess)
			{
				num = Interop.Sys.PRead(handle, reference, buffer.Length, fileOffset);
				if (num == -1)
				{
					Interop.ErrorInfo lastErrorInfo = Interop.Sys.GetLastErrorInfo();
					if (lastErrorInfo.Error == Interop.Error.ENXIO || lastErrorInfo.Error == Interop.Error.ESPIPE)
					{
						handle.SupportsRandomAccess = false;
						num = Interop.Sys.Read(handle, reference, buffer.Length);
					}
				}
			}
			else
			{
				num = Interop.Sys.Read(handle, reference, buffer.Length);
			}
			FileStreamHelpers.CheckFileCall(num, handle.Path);
			return num;
		}
	}

	internal unsafe static long ReadScatterAtOffset(SafeFileHandle handle, IReadOnlyList<Memory<byte>> buffers, long fileOffset)
	{
		MemoryHandle[] array = new MemoryHandle[buffers.Count];
		Span<Interop.Sys.IOVector> span = ((buffers.Count > 8) ? ((Span<Interop.Sys.IOVector>)new Interop.Sys.IOVector[buffers.Count]) : stackalloc Interop.Sys.IOVector[8]);
		Span<Interop.Sys.IOVector> span2 = span;
		long result;
		try
		{
			int count = buffers.Count;
			for (int i = 0; i < count; i++)
			{
				Memory<byte> memory = buffers[i];
				MemoryHandle memoryHandle = memory.Pin();
				span2[i] = new Interop.Sys.IOVector
				{
					Base = (byte*)memoryHandle.Pointer,
					Count = (nuint)memory.Length
				};
				array[i] = memoryHandle;
			}
			fixed (Interop.Sys.IOVector* reference = &MemoryMarshal.GetReference(span2))
			{
				result = Interop.Sys.PReadV(handle, reference, buffers.Count, fileOffset);
			}
		}
		finally
		{
			MemoryHandle[] array2 = array;
			foreach (MemoryHandle memoryHandle2 in array2)
			{
				memoryHandle2.Dispose();
			}
		}
		return FileStreamHelpers.CheckFileCall(result, handle.Path);
	}

	internal static ValueTask<int> ReadAtOffsetAsync(SafeFileHandle handle, Memory<byte> buffer, long fileOffset, CancellationToken cancellationToken, OSFileStreamStrategy strategy = null)
	{
		return handle.GetThreadPoolValueTaskSource().QueueRead(buffer, fileOffset, cancellationToken, strategy);
	}

	private static ValueTask<long> ReadScatterAtOffsetAsync(SafeFileHandle handle, IReadOnlyList<Memory<byte>> buffers, long fileOffset, CancellationToken cancellationToken)
	{
		return handle.GetThreadPoolValueTaskSource().QueueReadScatter(buffers, fileOffset, cancellationToken);
	}

	internal unsafe static void WriteAtOffset(SafeFileHandle handle, ReadOnlySpan<byte> buffer, long fileOffset)
	{
		while (!buffer.IsEmpty)
		{
			fixed (byte* reference = &MemoryMarshal.GetReference(buffer))
			{
				int numberOfBytesToWrite = GetNumberOfBytesToWrite(buffer.Length);
				int num;
				if (handle.SupportsRandomAccess)
				{
					num = Interop.Sys.PWrite(handle, reference, numberOfBytesToWrite, fileOffset);
					if (num == -1)
					{
						Interop.ErrorInfo lastErrorInfo = Interop.Sys.GetLastErrorInfo();
						if (lastErrorInfo.Error == Interop.Error.ENXIO || lastErrorInfo.Error == Interop.Error.ESPIPE)
						{
							handle.SupportsRandomAccess = false;
							num = Interop.Sys.Write(handle, reference, numberOfBytesToWrite);
						}
					}
				}
				else
				{
					num = Interop.Sys.Write(handle, reference, numberOfBytesToWrite);
				}
				FileStreamHelpers.CheckFileCall(num, handle.Path);
				if (num == buffer.Length)
				{
					break;
				}
				buffer = buffer.Slice(num);
				fileOffset += num;
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int GetNumberOfBytesToWrite(int byteCount)
	{
		return byteCount;
	}

	internal unsafe static void WriteGatherAtOffset(SafeFileHandle handle, IReadOnlyList<ReadOnlyMemory<byte>> buffers, long fileOffset)
	{
		int count = buffers.Count;
		if (count == 0)
		{
			return;
		}
		MemoryHandle[] array = new MemoryHandle[count];
		Span<Interop.Sys.IOVector> span = ((count > 8) ? ((Span<Interop.Sys.IOVector>)new Interop.Sys.IOVector[count]) : stackalloc Interop.Sys.IOVector[8].Slice(0, count));
		Span<Interop.Sys.IOVector> span2 = span;
		try
		{
			long num = 0L;
			for (int i = 0; i < count; i++)
			{
				ReadOnlyMemory<byte> readOnlyMemory = buffers[i];
				num += readOnlyMemory.Length;
				MemoryHandle memoryHandle = readOnlyMemory.Pin();
				span2[i] = new Interop.Sys.IOVector
				{
					Base = (byte*)memoryHandle.Pointer,
					Count = (nuint)readOnlyMemory.Length
				};
				array[i] = memoryHandle;
			}
			int j = 0;
			while (num > 0)
			{
				Span<Interop.Sys.IOVector> span3 = span2.Slice(j);
				long num2;
				fixed (Interop.Sys.IOVector* reference = &MemoryMarshal.GetReference(span3))
				{
					num2 = Interop.Sys.PWriteV(handle, reference, span3.Length, fileOffset);
				}
				FileStreamHelpers.CheckFileCall(num2, handle.Path);
				if (num2 == num)
				{
					break;
				}
				fileOffset += num2;
				num -= num2;
				for (; j < count; j++)
				{
					if (num2 <= 0)
					{
						break;
					}
					int num3 = (int)span2[j].Count;
					if (num3 <= num2)
					{
						num2 -= num3;
						continue;
					}
					Interop.Sys.IOVector iOVector = span2[j];
					span2[j] = new Interop.Sys.IOVector
					{
						Base = iOVector.Base + (int)num2,
						Count = iOVector.Count - (nuint)(nint)num2
					};
					break;
				}
			}
		}
		finally
		{
			MemoryHandle[] array2 = array;
			foreach (MemoryHandle memoryHandle2 in array2)
			{
				memoryHandle2.Dispose();
			}
		}
	}

	internal static ValueTask WriteAtOffsetAsync(SafeFileHandle handle, ReadOnlyMemory<byte> buffer, long fileOffset, CancellationToken cancellationToken, OSFileStreamStrategy strategy = null)
	{
		return handle.GetThreadPoolValueTaskSource().QueueWrite(buffer, fileOffset, cancellationToken, strategy);
	}

	private static ValueTask WriteGatherAtOffsetAsync(SafeFileHandle handle, IReadOnlyList<ReadOnlyMemory<byte>> buffers, long fileOffset, CancellationToken cancellationToken)
	{
		return handle.GetThreadPoolValueTaskSource().QueueWriteGather(buffers, fileOffset, cancellationToken);
	}
}
