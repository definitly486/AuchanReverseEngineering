using System.Runtime.Serialization;
using Microsoft.Win32.SafeHandles;

namespace System.IO.Strategies;

internal static class FileStreamHelpers
{
	private static int s_cachedSerializationSwitch;

	internal static FileStreamStrategy ChooseStrategy(FileStream fileStream, SafeFileHandle handle, FileAccess access, int bufferSize, bool isAsync)
	{
		FileStreamStrategy strategy = EnableBufferingIfNeeded(ChooseStrategyCore(handle, access, isAsync), bufferSize);
		return WrapIfDerivedType(fileStream, strategy);
	}

	internal static FileStreamStrategy ChooseStrategy(FileStream fileStream, string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, FileOptions options, long preallocationSize, UnixFileMode? unixCreateMode)
	{
		FileStreamStrategy strategy = EnableBufferingIfNeeded(ChooseStrategyCore(path, mode, access, share, options, preallocationSize, unixCreateMode), bufferSize);
		return WrapIfDerivedType(fileStream, strategy);
	}

	private static FileStreamStrategy EnableBufferingIfNeeded(FileStreamStrategy strategy, int bufferSize)
	{
		if (bufferSize <= 1)
		{
			return strategy;
		}
		return new BufferedFileStreamStrategy(strategy, bufferSize);
	}

	private static FileStreamStrategy WrapIfDerivedType(FileStream fileStream, FileStreamStrategy strategy)
	{
		if (!(fileStream.GetType() == typeof(FileStream)))
		{
			return new DerivedFileStreamStrategy(fileStream, strategy);
		}
		return strategy;
	}

	internal static bool IsIoRelatedException(Exception e)
	{
		if (!(e is IOException) && !(e is UnauthorizedAccessException) && !(e is NotSupportedException))
		{
			if (e is ArgumentException)
			{
				return !(e is ArgumentNullException);
			}
			return false;
		}
		return true;
	}

	internal static void ValidateArguments(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, FileOptions options, long preallocationSize)
	{
		ArgumentException.ThrowIfNullOrEmpty(path, "path");
		FileShare fileShare = share & ~FileShare.Inheritable;
		string text = null;
		if (mode < FileMode.CreateNew || mode > FileMode.Append)
		{
			text = "mode";
		}
		else if (access < FileAccess.Read || access > FileAccess.ReadWrite)
		{
			text = "access";
		}
		else if ((fileShare < FileShare.None) || fileShare > (FileShare.ReadWrite | FileShare.Delete))
		{
			text = "share";
		}
		if (text != null)
		{
			throw new ArgumentOutOfRangeException(text, "ArgumentOutOfRange_Enum");
		}
		if (AreInvalid(options))
		{
			throw new ArgumentOutOfRangeException("options", "ArgumentOutOfRange_Enum");
		}
		if (bufferSize < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException_NeedNonNegNum("bufferSize");
		}
		else if (preallocationSize < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException_NeedNonNegNum("preallocationSize");
		}
		if ((access & FileAccess.Write) == 0 && (mode == FileMode.Truncate || mode == FileMode.CreateNew || mode == FileMode.Create || mode == FileMode.Append))
		{
			throw new ArgumentException(SR.Format("Argument_InvalidFileModeAndAccessCombo", mode, access), "access");
		}
		if ((access & FileAccess.Read) != 0 && mode == FileMode.Append)
		{
			throw new ArgumentException("Argument_InvalidAppendMode", "access");
		}
		if (preallocationSize > 0)
		{
			ValidateArgumentsForPreallocation(mode, access);
		}
		SerializationGuard(access);
	}

	internal static void ValidateArgumentsForPreallocation(FileMode mode, FileAccess access)
	{
		if ((access & FileAccess.Write) == 0)
		{
			throw new ArgumentException("Argument_InvalidPreallocateAccess", "access");
		}
		if (mode != FileMode.Create && mode != FileMode.CreateNew)
		{
			throw new ArgumentException("Argument_InvalidPreallocateMode", "mode");
		}
	}

	internal static void SerializationGuard(FileAccess access)
	{
		if ((access & FileAccess.Write) == FileAccess.Write)
		{
			SerializationInfo.ThrowIfDeserializationInProgress("AllowFileWrites", ref s_cachedSerializationSwitch);
		}
	}

	internal static bool AreInvalid(FileOptions options)
	{
		if (options != FileOptions.None)
		{
			return (options & (FileOptions)33538047) != 0;
		}
		return false;
	}

	private static UnixFileStreamStrategy ChooseStrategyCore(SafeFileHandle handle, FileAccess access, bool isAsync)
	{
		return new UnixFileStreamStrategy(handle, access);
	}

	private static UnixFileStreamStrategy ChooseStrategyCore(string path, FileMode mode, FileAccess access, FileShare share, FileOptions options, long preallocationSize, UnixFileMode? unixCreateMode)
	{
		return new UnixFileStreamStrategy(path, mode, access, share, options, preallocationSize, unixCreateMode);
	}

	internal static long CheckFileCall(long result, string path, bool ignoreNotSupported = false)
	{
		if (result < 0)
		{
			Interop.ErrorInfo lastErrorInfo = Interop.Sys.GetLastErrorInfo();
			if (!ignoreNotSupported || lastErrorInfo.Error != Interop.Error.ENOTSUP)
			{
				throw Interop.GetExceptionForIoErrno(lastErrorInfo, path);
			}
		}
		return result;
	}

	internal static long Seek(SafeFileHandle handle, long offset, SeekOrigin origin)
	{
		return CheckFileCall(Interop.Sys.LSeek(handle, offset, (Interop.Sys.SeekWhence)origin), handle.Path);
	}

	internal static void ThrowInvalidArgument(SafeFileHandle handle)
	{
		throw Interop.GetExceptionForIoErrno(new Interop.ErrorInfo(Interop.Error.EINVAL), handle.Path);
	}

	internal static void FlushToDisk(SafeFileHandle handle)
	{
		if (Interop.Sys.FSync(handle) < 0)
		{
			Interop.ErrorInfo lastErrorInfo = Interop.Sys.GetLastErrorInfo();
			Interop.Error error = lastErrorInfo.Error;
			if (error != Interop.Error.EINVAL && error != Interop.Error.ENOTSUP && error != Interop.Error.EROFS)
			{
				throw Interop.GetExceptionForIoErrno(lastErrorInfo, handle.Path);
			}
		}
	}

	internal static void Lock(SafeFileHandle handle, bool canWrite, long position, long length)
	{
		_ = 0;
		if (false)
		{
		}
		CheckFileCall(Interop.Sys.LockFileRegion(handle, position, length, canWrite ? Interop.Sys.LockType.F_WRLCK : Interop.Sys.LockType.F_RDLCK), handle.Path);
	}

	internal static void Unlock(SafeFileHandle handle, long position, long length)
	{
		_ = 0;
		if (false)
		{
		}
		CheckFileCall(Interop.Sys.LockFileRegion(handle, position, length, Interop.Sys.LockType.F_UNLCK), handle.Path);
	}
}
