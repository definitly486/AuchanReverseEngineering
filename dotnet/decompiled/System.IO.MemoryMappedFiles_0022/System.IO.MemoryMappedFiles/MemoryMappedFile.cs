using Microsoft.Win32.SafeHandles;

namespace System.IO.MemoryMappedFiles;

public class MemoryMappedFile : IDisposable
{
	private readonly SafeMemoryMappedFileHandle _handle;

	private readonly bool _leaveOpen;

	private readonly SafeFileHandle _fileHandle;

	private MemoryMappedFile(SafeMemoryMappedFileHandle handle, SafeFileHandle fileHandle, bool leaveOpen)
	{
		_handle = handle;
		_fileHandle = fileHandle;
		_leaveOpen = leaveOpen;
	}

	public static MemoryMappedFile CreateFromFile(FileStream fileStream, string? mapName, long capacity, MemoryMappedFileAccess access, HandleInheritability inheritability, bool leaveOpen)
	{
		ArgumentNullException.ThrowIfNull(fileStream, "fileStream");
		ValidateCreateFile(mapName, capacity, access);
		long length = fileStream.Length;
		if (capacity == 0L && length == 0L)
		{
			throw new ArgumentException("Argument_EmptyFile");
		}
		if (inheritability < HandleInheritability.None || inheritability > HandleInheritability.Inheritable)
		{
			throw new ArgumentOutOfRangeException("inheritability");
		}
		fileStream.Flush();
		if (capacity == 0L)
		{
			capacity = length;
		}
		SafeFileHandle safeFileHandle = fileStream.SafeFileHandle;
		return new MemoryMappedFile(CreateCore(safeFileHandle, mapName, inheritability, access, MemoryMappedFileOptions.None, capacity, length), safeFileHandle, leaveOpen);
	}

	public MemoryMappedViewAccessor CreateViewAccessor(long offset, long size, MemoryMappedFileAccess access)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(offset, "offset");
		if (size < 0)
		{
			throw new ArgumentOutOfRangeException("size", "ArgumentOutOfRange_PositiveOrDefaultSizeRequired");
		}
		if (access < MemoryMappedFileAccess.ReadWrite || access > MemoryMappedFileAccess.ReadWriteExecute)
		{
			throw new ArgumentOutOfRangeException("access");
		}
		_ = 4;
		if (size > uint.MaxValue)
		{
			throw new ArgumentOutOfRangeException("size", "ArgumentOutOfRange_CapacityLargerThanLogicalAddressSpaceNotAllowed");
		}
		return new MemoryMappedViewAccessor(MemoryMappedView.CreateView(_handle, access, offset, size));
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		try
		{
			if (!_handle.IsClosed)
			{
				_handle.Dispose();
			}
		}
		finally
		{
			if (!_leaveOpen)
			{
				_fileHandle?.Dispose();
			}
		}
	}

	internal static FileAccess GetFileAccess(MemoryMappedFileAccess access)
	{
		switch (access)
		{
		case MemoryMappedFileAccess.Read:
		case MemoryMappedFileAccess.ReadExecute:
			return FileAccess.Read;
		case MemoryMappedFileAccess.ReadWrite:
		case MemoryMappedFileAccess.CopyOnWrite:
		case MemoryMappedFileAccess.ReadWriteExecute:
			return FileAccess.ReadWrite;
		default:
			return FileAccess.Write;
		}
	}

	private static void ValidateCreateFile(string mapName, long capacity, MemoryMappedFileAccess access)
	{
		if (mapName != null && mapName.Length == 0)
		{
			throw new ArgumentException("Argument_MapNameEmptyString");
		}
		if (capacity < 0)
		{
			throw new ArgumentOutOfRangeException("capacity", "ArgumentOutOfRange_PositiveOrDefaultCapacityRequired");
		}
		switch (access)
		{
		default:
			throw new ArgumentOutOfRangeException("access");
		case MemoryMappedFileAccess.Write:
			throw new ArgumentException("Argument_NewMMFWriteAccessNotAllowed", "access");
		case MemoryMappedFileAccess.ReadWrite:
		case MemoryMappedFileAccess.Read:
		case MemoryMappedFileAccess.CopyOnWrite:
		case MemoryMappedFileAccess.ReadExecute:
		case MemoryMappedFileAccess.ReadWriteExecute:
			break;
		}
	}

	private static void VerifyMemoryMappedFileAccess(MemoryMappedFileAccess access, long capacity, SafeFileHandle fileHandle, long fileSize, out bool isRegularFile)
	{
		isRegularFile = fileHandle != null && (fileSize > 0 || IsRegularFile(fileHandle));
		if (isRegularFile)
		{
			if (access == MemoryMappedFileAccess.Read && capacity > fileSize)
			{
				throw new ArgumentException("Argument_ReadAccessWithLargeCapacity");
			}
			if (fileSize > capacity)
			{
				throw new ArgumentOutOfRangeException("capacity", "ArgumentOutOfRange_CapacityGEFileSizeRequired");
			}
			if (access == MemoryMappedFileAccess.Write)
			{
				throw new ArgumentException("Argument_NewMMFWriteAccessNotAllowed", "access");
			}
		}
		static bool IsRegularFile(SafeFileHandle fd)
		{
			global::Interop.CheckIo(global::Interop.Sys.FStat(fd, out var output));
			return (output.Mode & 0x8000) != 0;
		}
	}

	private static SafeMemoryMappedFileHandle CreateCore(SafeFileHandle fileHandle, string mapName, HandleInheritability inheritability, MemoryMappedFileAccess access, MemoryMappedFileOptions options, long capacity, long fileSize)
	{
		VerifyMemoryMappedFileAccess(access, capacity, fileHandle, fileSize, out var isRegularFile);
		if (mapName != null)
		{
			throw CreateNamedMapsNotSupportedException();
		}
		bool ownsFileHandle = false;
		if (fileHandle != null)
		{
			if (isRegularFile && fileSize >= 0 && capacity > fileSize)
			{
				try
				{
					global::Interop.CheckIo(global::Interop.Sys.FTruncate(fileHandle, capacity));
				}
				catch (ArgumentException ex)
				{
					throw new IOException(ex.Message, ex);
				}
			}
		}
		else
		{
			global::Interop.Sys.MemoryMappedProtections protections = MemoryMappedView.GetProtections(access, forVerification: false);
			if ((protections & global::Interop.Sys.MemoryMappedProtections.PROT_WRITE) != global::Interop.Sys.MemoryMappedProtections.PROT_NONE && capacity > 0)
			{
				ownsFileHandle = true;
				fileHandle = CreateSharedBackingObject(protections, capacity, inheritability);
			}
		}
		return new SafeMemoryMappedFileHandle(fileHandle, ownsFileHandle, inheritability, access, options, capacity);
	}

	private static PlatformNotSupportedException CreateNamedMapsNotSupportedException()
	{
		return new PlatformNotSupportedException("PlatformNotSupported_NamedMaps");
	}

	private static FileAccess TranslateProtectionsToFileAccess(global::Interop.Sys.MemoryMappedProtections protections)
	{
		if ((protections & (global::Interop.Sys.MemoryMappedProtections.PROT_READ | global::Interop.Sys.MemoryMappedProtections.PROT_WRITE)) == 0)
		{
			if ((protections & global::Interop.Sys.MemoryMappedProtections.PROT_WRITE) == 0)
			{
				return FileAccess.Read;
			}
			return FileAccess.Write;
		}
		return FileAccess.ReadWrite;
	}

	private static SafeFileHandle CreateSharedBackingObject(global::Interop.Sys.MemoryMappedProtections protections, long capacity, HandleInheritability inheritability)
	{
		SafeFileHandle safeFileHandle;
		if (!global::Interop.Sys.IsMemfdSupported)
		{
			safeFileHandle = CreateSharedBackingObjectUsingMemoryShmOpen(protections, capacity, inheritability);
			if (safeFileHandle == null)
			{
				return CreateSharedBackingObjectUsingFile(protections, capacity, inheritability);
			}
		}
		else
		{
			safeFileHandle = CreateSharedBackingObjectUsingMemoryMemfdCreate(protections, capacity, inheritability);
		}
		return safeFileHandle;
	}

	private static SafeFileHandle CreateSharedBackingObjectUsingMemoryShmOpen(global::Interop.Sys.MemoryMappedProtections protections, long capacity, HandleInheritability inheritability)
	{
		global::Interop.Sys.OpenFlags openFlags = (((protections & global::Interop.Sys.MemoryMappedProtections.PROT_WRITE) != global::Interop.Sys.MemoryMappedProtections.PROT_NONE) ? global::Interop.Sys.OpenFlags.O_RDWR : global::Interop.Sys.OpenFlags.O_RDONLY);
		openFlags |= global::Interop.Sys.OpenFlags.O_CREAT | global::Interop.Sys.OpenFlags.O_EXCL;
		UnixFileMode unixFileMode = UnixFileMode.None;
		if ((protections & global::Interop.Sys.MemoryMappedProtections.PROT_READ) != global::Interop.Sys.MemoryMappedProtections.PROT_NONE)
		{
			unixFileMode |= UnixFileMode.UserRead;
		}
		if ((protections & global::Interop.Sys.MemoryMappedProtections.PROT_WRITE) != global::Interop.Sys.MemoryMappedProtections.PROT_NONE)
		{
			unixFileMode |= UnixFileMode.UserWrite;
		}
		if ((protections & global::Interop.Sys.MemoryMappedProtections.PROT_EXEC) != global::Interop.Sys.MemoryMappedProtections.PROT_NONE)
		{
			unixFileMode |= UnixFileMode.UserExecute;
		}
		string name;
		SafeFileHandle safeFileHandle;
		do
		{
			name = GenerateMapName();
			safeFileHandle = global::Interop.Sys.ShmOpen(name, openFlags, (int)unixFileMode);
			if (safeFileHandle.IsInvalid)
			{
				global::Interop.ErrorInfo lastErrorInfo = global::Interop.Sys.GetLastErrorInfo();
				safeFileHandle.Dispose();
				if (lastErrorInfo.Error == global::Interop.Error.ENOTSUP)
				{
					return null;
				}
				if (lastErrorInfo.Error == global::Interop.Error.ENAMETOOLONG)
				{
					return null;
				}
				if (lastErrorInfo.Error != global::Interop.Error.EEXIST)
				{
					throw global::Interop.GetExceptionForIoErrno(lastErrorInfo);
				}
			}
		}
		while (safeFileHandle.IsInvalid);
		try
		{
			global::Interop.CheckIo(global::Interop.Sys.ShmUnlink(name));
			global::Interop.CheckIo(global::Interop.Sys.FTruncate(safeFileHandle, capacity));
			if (inheritability == HandleInheritability.Inheritable && global::Interop.Sys.Fcntl.SetFD(safeFileHandle, 0) == -1)
			{
				throw global::Interop.GetExceptionForIoErrno(global::Interop.Sys.GetLastErrorInfo());
			}
			return safeFileHandle;
		}
		catch
		{
			safeFileHandle.Dispose();
			throw;
		}
	}

	private static string GenerateMapName()
	{
		return string.Create(30, 0, delegate(Span<char> span, int state)
		{
			Span<char> destination = stackalloc char[32];
			Guid.NewGuid().TryFormat(destination, out var _, "N".AsSpan());
			"/dotnet_".CopyTo(span);
			destination.Slice(0, 30 - "/dotnet_".Length).CopyTo(span.Slice("/dotnet_".Length));
		});
	}

	private static SafeFileHandle CreateSharedBackingObjectUsingMemoryMemfdCreate(global::Interop.Sys.MemoryMappedProtections protections, long capacity, HandleInheritability inheritability)
	{
		int isReadonly = (((protections & global::Interop.Sys.MemoryMappedProtections.PROT_READ) != global::Interop.Sys.MemoryMappedProtections.PROT_NONE && (protections & global::Interop.Sys.MemoryMappedProtections.PROT_WRITE) == 0) ? 1 : 0);
		SafeFileHandle safeFileHandle = global::Interop.Sys.MemfdCreate(GenerateMapName(), isReadonly);
		if (safeFileHandle.IsInvalid)
		{
			global::Interop.ErrorInfo lastErrorInfo = global::Interop.Sys.GetLastErrorInfo();
			safeFileHandle.Dispose();
			throw global::Interop.GetExceptionForIoErrno(lastErrorInfo);
		}
		try
		{
			global::Interop.CheckIo(global::Interop.Sys.FTruncate(safeFileHandle, capacity));
			if (inheritability == HandleInheritability.Inheritable && global::Interop.Sys.Fcntl.SetFD(safeFileHandle, 0) == -1)
			{
				throw global::Interop.GetExceptionForIoErrno(global::Interop.Sys.GetLastErrorInfo());
			}
			return safeFileHandle;
		}
		catch
		{
			safeFileHandle.Dispose();
			throw;
		}
	}

	private static SafeFileHandle CreateSharedBackingObjectUsingFile(global::Interop.Sys.MemoryMappedProtections protections, long capacity, HandleInheritability inheritability)
	{
		string text = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
		FileShare share = ((inheritability == HandleInheritability.None) ? FileShare.ReadWrite : (FileShare.ReadWrite | FileShare.Inheritable));
		SafeFileHandle safeFileHandle = File.OpenHandle(text, FileMode.CreateNew, TranslateProtectionsToFileAccess(protections), share, FileOptions.None, 0L);
		try
		{
			global::Interop.CheckIo(global::Interop.Sys.Unlink(text));
			global::Interop.CheckIo(global::Interop.Sys.FTruncate(safeFileHandle, capacity), text);
			return safeFileHandle;
		}
		catch
		{
			safeFileHandle.Dispose();
			throw;
		}
	}
}
