using Microsoft.Win32.SafeHandles;

namespace System.IO.MemoryMappedFiles;

internal sealed class MemoryMappedView : IDisposable
{
	private readonly SafeMemoryMappedViewHandle _viewHandle;

	private readonly long _pointerOffset;

	private readonly long _size;

	private readonly MemoryMappedFileAccess _access;

	public SafeMemoryMappedViewHandle ViewHandle => _viewHandle;

	public long PointerOffset => _pointerOffset;

	public long Size => _size;

	public MemoryMappedFileAccess Access => _access;

	public bool IsClosed => _viewHandle.IsClosed;

	private MemoryMappedView(SafeMemoryMappedViewHandle viewHandle, long pointerOffset, long size, MemoryMappedFileAccess access)
	{
		_viewHandle = viewHandle;
		_pointerOffset = pointerOffset;
		_size = size;
		_access = access;
	}

	public void Dispose()
	{
		if (!_viewHandle.IsClosed)
		{
			_viewHandle.Dispose();
		}
		GC.SuppressFinalize(this);
	}

	private static void ValidateSizeAndOffset(long size, long offset, long allocationGranularity, out ulong newSize, out long extraMemNeeded, out long newOffset)
	{
		extraMemNeeded = offset % allocationGranularity;
		newOffset = offset - extraMemNeeded;
		newSize = (ulong)((size != 0L) ? (size + extraMemNeeded) : 0);
		if (8 != 4)
		{
		}
	}

	public static MemoryMappedView CreateView(SafeMemoryMappedFileHandle memMappedFileHandle, MemoryMappedFileAccess access, long requestedOffset, long requestedSize)
	{
		ArgumentOutOfRangeException.ThrowIfGreaterThan(requestedOffset, memMappedFileHandle._capacity, "offset");
		if (requestedSize > 8192000000000L)
		{
			throw new IOException("ArgumentOutOfRange_CapacityLargerThanLogicalAddressSpaceNotAllowed");
		}
		if (requestedOffset + requestedSize > memMappedFileHandle._capacity)
		{
			throw new UnauthorizedAccessException();
		}
		ObjectDisposedException.ThrowIf(memMappedFileHandle.IsClosed, memMappedFileHandle);
		if (requestedSize == 0L)
		{
			requestedSize = memMappedFileHandle._capacity - requestedOffset;
		}
		long allocationGranularity = global::Interop.Sys.SysConf(global::Interop.Sys.SysConfName._SC_PAGESIZE);
		ValidateSizeAndOffset(requestedSize, requestedOffset, allocationGranularity, out var newSize, out var extraMemNeeded, out var newOffset);
		global::Interop.Sys.MemoryMappedFlags memoryMappedFlags = ((memMappedFileHandle._access != MemoryMappedFileAccess.CopyOnWrite && access != MemoryMappedFileAccess.CopyOnWrite) ? global::Interop.Sys.MemoryMappedFlags.MAP_SHARED : global::Interop.Sys.MemoryMappedFlags.MAP_PRIVATE);
		SafeFileHandle fd;
		if (memMappedFileHandle._fileStreamHandle != null)
		{
			fd = memMappedFileHandle._fileStreamHandle;
		}
		else
		{
			fd = new SafeFileHandle(new IntPtr(-1), ownsHandle: false);
			memoryMappedFlags |= global::Interop.Sys.MemoryMappedFlags.MAP_ANONYMOUS;
		}
		global::Interop.Sys.MemoryMappedProtections protections = GetProtections(access, forVerification: true);
		global::Interop.Sys.MemoryMappedProtections protections2 = GetProtections(memMappedFileHandle._access, forVerification: true);
		if ((protections & protections2) != protections)
		{
			throw new UnauthorizedAccessException();
		}
		global::Interop.Sys.MemoryMappedProtections protections3 = GetProtections(access, forVerification: false);
		nint num;
		if (newSize != 0)
		{
			num = global::Interop.Sys.MMap(IntPtr.Zero, newSize, protections3, memoryMappedFlags, fd, newOffset);
		}
		else
		{
			num = global::Interop.Sys.MMap(IntPtr.Zero, 1uL, protections3, memoryMappedFlags | global::Interop.Sys.MemoryMappedFlags.MAP_ANONYMOUS, new SafeFileHandle(new IntPtr(-1), ownsHandle: false), 0L);
			requestedSize = 0L;
			extraMemNeeded = 0L;
		}
		if (num == IntPtr.Zero)
		{
			throw global::Interop.GetExceptionForIoErrno(global::Interop.Sys.GetLastErrorInfo());
		}
		if (memMappedFileHandle._inheritability == HandleInheritability.None)
		{
			DisableForkingIfPossible(num, newSize);
		}
		SafeMemoryMappedViewHandle safeMemoryMappedViewHandle = new SafeMemoryMappedViewHandle(num, ownsHandle: true);
		safeMemoryMappedViewHandle.Initialize(newSize);
		return new MemoryMappedView(safeMemoryMappedViewHandle, extraMemNeeded, requestedSize, access);
	}

	public unsafe void Flush(nuint capacity)
	{
		if (capacity == UIntPtr.Zero)
		{
			return;
		}
		byte* pointer = null;
		try
		{
			_viewHandle.AcquirePointer(ref pointer);
			if (global::Interop.Sys.MSync((nint)pointer, capacity, global::Interop.Sys.MemoryMappedSyncFlags.MS_SYNC | global::Interop.Sys.MemoryMappedSyncFlags.MS_INVALIDATE) < 0)
			{
				throw global::Interop.GetExceptionForIoErrno(global::Interop.Sys.GetLastErrorInfo());
			}
		}
		finally
		{
			if (pointer != null)
			{
				_viewHandle.ReleasePointer();
			}
		}
	}

	private static void DisableForkingIfPossible(nint addr, ulong length)
	{
		if (length != 0)
		{
			global::Interop.Sys.MAdvise(addr, length, global::Interop.Sys.MemoryAdvice.MADV_DONTFORK);
		}
	}

	internal static global::Interop.Sys.MemoryMappedProtections GetProtections(MemoryMappedFileAccess access, bool forVerification)
	{
		switch (access)
		{
		default:
			return global::Interop.Sys.MemoryMappedProtections.PROT_READ;
		case MemoryMappedFileAccess.Write:
			return global::Interop.Sys.MemoryMappedProtections.PROT_WRITE;
		case MemoryMappedFileAccess.ReadWrite:
			return global::Interop.Sys.MemoryMappedProtections.PROT_READ | global::Interop.Sys.MemoryMappedProtections.PROT_WRITE;
		case MemoryMappedFileAccess.ReadExecute:
			return global::Interop.Sys.MemoryMappedProtections.PROT_READ | global::Interop.Sys.MemoryMappedProtections.PROT_EXEC;
		case MemoryMappedFileAccess.ReadWriteExecute:
			return global::Interop.Sys.MemoryMappedProtections.PROT_READ | global::Interop.Sys.MemoryMappedProtections.PROT_WRITE | global::Interop.Sys.MemoryMappedProtections.PROT_EXEC;
		case MemoryMappedFileAccess.CopyOnWrite:
			if (!forVerification)
			{
				return global::Interop.Sys.MemoryMappedProtections.PROT_READ | global::Interop.Sys.MemoryMappedProtections.PROT_WRITE;
			}
			return global::Interop.Sys.MemoryMappedProtections.PROT_READ;
		}
	}
}
