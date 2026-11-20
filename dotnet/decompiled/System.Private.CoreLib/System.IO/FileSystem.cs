using System.Collections.Generic;
using System.IO.Enumeration;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace System.IO;

internal static class FileSystem
{
	internal static void VerifyValidPath(string path, string argName)
	{
		ArgumentException.ThrowIfNullOrEmpty(path, argName);
		if (path.Contains('\0'))
		{
			throw new ArgumentException("Argument_NullCharInPath", argName);
		}
	}

	internal static void MoveDirectory(string sourceFullPath, string destFullPath)
	{
		ReadOnlySpan<char> span = Path.TrimEndingDirectorySeparator(sourceFullPath.AsSpan());
		ReadOnlySpan<char> other = Path.TrimEndingDirectorySeparator(destFullPath.AsSpan());
		bool isCaseSensitiveRename = false;
		if (MemoryExtensions.Equals(span, other, StringComparison.Ordinal))
		{
			if (1 == 0)
			{
			}
			throw new IOException("IO_SourceDestMustBeDifferent");
		}
		MoveDirectory(sourceFullPath, destFullPath, isCaseSensitiveRename);
	}

	public static void CopyFile(string sourceFullPath, string destFullPath, bool overwrite)
	{
		long fileLength;
		UnixFileMode filePermissions;
		using SafeFileHandle source = SafeFileHandle.OpenReadOnly(sourceFullPath, FileOptions.None, out fileLength, out filePermissions);
		if (false)
		{
			return;
		}
		using SafeFileHandle destination = SafeFileHandle.Open(destFullPath, (!overwrite) ? FileMode.CreateNew : FileMode.Create, FileAccess.ReadWrite, FileShare.None, FileOptions.None, 0L, filePermissions, CreateOpenExceptionForCopyFile);
		Interop.CheckIo(Interop.Sys.CopyFile(source, destination, fileLength));
	}

	private static Exception CreateOpenExceptionForCopyFile(Interop.ErrorInfo error, Interop.Sys.OpenFlags flags, string path)
	{
		if (error.Error == Interop.Error.EEXIST && DirectoryExists(path.AsSpan()))
		{
			return new IOException(SR.Format("Arg_FileIsDirectory_Name", path));
		}
		return null;
	}

	public static void Encrypt(string path)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_FileEncryption");
	}

	public static void Decrypt(string path)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_FileEncryption");
	}

	private static void LinkOrCopyFile(string sourceFullPath, string destFullPath)
	{
		if (Interop.Sys.Link(sourceFullPath, destFullPath) >= 0)
		{
			return;
		}
		Interop.ErrorInfo lastErrorInfo = Interop.Sys.GetLastErrorInfo();
		if (lastErrorInfo.Error == Interop.Error.EXDEV || lastErrorInfo.Error == Interop.Error.EACCES || lastErrorInfo.Error == Interop.Error.EPERM || lastErrorInfo.Error == Interop.Error.ENOTSUP || lastErrorInfo.Error == Interop.Error.EMLINK || lastErrorInfo.Error == Interop.Error.ENOSYS)
		{
			CopyFile(sourceFullPath, destFullPath, overwrite: false);
			return;
		}
		if (lastErrorInfo.Error == Interop.Error.ENOENT)
		{
			if (!Directory.Exists(Path.GetDirectoryName(destFullPath)))
			{
				throw Interop.GetExceptionForIoErrno(lastErrorInfo, destFullPath, isDirError: true);
			}
			throw Interop.GetExceptionForIoErrno(lastErrorInfo, sourceFullPath);
		}
		if (lastErrorInfo.Error == Interop.Error.EEXIST)
		{
			throw Interop.GetExceptionForIoErrno(lastErrorInfo, destFullPath);
		}
		throw Interop.GetExceptionForIoErrno(lastErrorInfo);
	}

	public static void ReplaceFile(string sourceFullPath, string destFullPath, string destBackupFullPath, bool ignoreMetadataErrors)
	{
		Interop.CheckIo(Interop.Sys.LStat(sourceFullPath, out var output), sourceFullPath);
		if ((output.Mode & 0xF000) == 16384)
		{
			throw new UnauthorizedAccessException(SR.Format("IO_NotAFile", sourceFullPath));
		}
		if (Interop.Sys.LStat(destFullPath, out var output2) == 0)
		{
			if ((output2.Mode & 0xF000) == 16384)
			{
				throw new UnauthorizedAccessException(SR.Format("IO_NotAFile", destFullPath));
			}
			if (output.Dev == output2.Dev && output.Ino == output2.Ino)
			{
				throw new IOException(SR.Format("IO_CannotReplaceSameFile", sourceFullPath, destFullPath));
			}
		}
		Interop.Sys.FileStatus output3;
		if (destBackupFullPath != null)
		{
			if (Interop.Sys.Unlink(destBackupFullPath) != 0)
			{
				Interop.ErrorInfo lastErrorInfo = Interop.Sys.GetLastErrorInfo();
				if (lastErrorInfo.Error != Interop.Error.ENOENT)
				{
					throw Interop.GetExceptionForIoErrno(lastErrorInfo, destBackupFullPath);
				}
			}
			LinkOrCopyFile(destFullPath, destBackupFullPath);
		}
		else if (Interop.Sys.Stat(destFullPath, out output3) != 0)
		{
			Interop.ErrorInfo lastErrorInfo2 = Interop.Sys.GetLastErrorInfo();
			if (lastErrorInfo2.Error == Interop.Error.ENOENT)
			{
				throw Interop.GetExceptionForIoErrno(lastErrorInfo2, destBackupFullPath);
			}
		}
		Interop.CheckIo(Interop.Sys.Rename(sourceFullPath, destFullPath));
	}

	public static void MoveFile(string sourceFullPath, string destFullPath, bool overwrite)
	{
		Interop.Sys.FileStatus output;
		Interop.Sys.FileStatus output2;
		if (overwrite)
		{
			if (Interop.Sys.Rename(sourceFullPath, destFullPath) < 0)
			{
				Interop.ErrorInfo lastErrorInfo = Interop.Sys.GetLastErrorInfo();
				if (lastErrorInfo.Error != Interop.Error.EXDEV)
				{
					throw Interop.GetExceptionForIoErrno(lastErrorInfo, destFullPath);
				}
				CopyFile(sourceFullPath, destFullPath, overwrite);
				DeleteFile(sourceFullPath);
			}
		}
		else if (Interop.Sys.LStat(sourceFullPath, out output) != 0 || (Interop.Sys.LStat(destFullPath, out output2) == 0 && (output.Dev != output2.Dev || output.Ino != output2.Ino)) || Interop.Sys.Rename(sourceFullPath, destFullPath) != 0)
		{
			LinkOrCopyFile(sourceFullPath, destFullPath);
			DeleteFile(sourceFullPath);
		}
	}

	public static void DeleteFile(string fullPath)
	{
		if (Interop.Sys.Unlink(fullPath) >= 0)
		{
			return;
		}
		Interop.ErrorInfo errorInfo = Interop.Sys.GetLastErrorInfo();
		switch (errorInfo.Error)
		{
		case Interop.Error.ENOENT:
		{
			string directoryName = Path.GetDirectoryName(fullPath);
			if (directoryName.Length > 0 && !Directory.Exists(directoryName))
			{
				throw Interop.GetExceptionForIoErrno(errorInfo, fullPath, isDirError: true);
			}
			return;
		}
		case Interop.Error.EROFS:
		{
			if (!FileExists(fullPath.AsSpan(), out var errorInfo2) && errorInfo2.Error == Interop.Error.ENOENT)
			{
				return;
			}
			break;
		}
		case Interop.Error.EISDIR:
			errorInfo = Interop.Error.EACCES.Info();
			break;
		}
		throw Interop.GetExceptionForIoErrno(errorInfo, fullPath);
	}

	public static void CreateDirectory(string fullPath)
	{
		CreateDirectory(fullPath, UnixFileMode.OtherExecute | UnixFileMode.OtherWrite | UnixFileMode.OtherRead | UnixFileMode.GroupExecute | UnixFileMode.GroupWrite | UnixFileMode.GroupRead | UnixFileMode.UserExecute | UnixFileMode.UserWrite | UnixFileMode.UserRead);
	}

	public static void CreateDirectory(string fullPath, UnixFileMode unixCreateMode)
	{
		if (fullPath.Length == 1 || Interop.Sys.MkDir(PathInternal.TrimEndingDirectorySeparator(fullPath.AsSpan()), (int)unixCreateMode) == 0)
		{
			return;
		}
		Interop.ErrorInfo lastErrorInfo = Interop.Sys.GetLastErrorInfo();
		if (lastErrorInfo.Error != Interop.Error.EEXIST || !DirectoryExists(fullPath.AsSpan()))
		{
			if (lastErrorInfo.Error != Interop.Error.ENOENT)
			{
				throw Interop.GetExceptionForIoErrno(lastErrorInfo, fullPath);
			}
			CreateParentsAndDirectory(fullPath, unixCreateMode);
		}
	}

	private static void CreateParentsAndDirectory(string fullPath, UnixFileMode unixCreateMode)
	{
		Span<int> scratchBuffer = stackalloc int[32];
		ValueListBuilder<int> valueListBuilder = new ValueListBuilder<int>(scratchBuffer);
		try
		{
			valueListBuilder.Append(fullPath.Length);
			int num = fullPath.Length - 1;
			if (PathInternal.IsDirectorySeparator(fullPath[num]))
			{
				num--;
			}
			while (true)
			{
				if (!PathInternal.IsDirectorySeparator(fullPath[num]))
				{
					num--;
					continue;
				}
				ReadOnlySpan<char> path = fullPath.AsSpan(0, num);
				if (Interop.Sys.MkDir(path, 511) == 0)
				{
					break;
				}
				Interop.ErrorInfo lastErrorInfo = Interop.Sys.GetLastErrorInfo();
				if (lastErrorInfo.Error == Interop.Error.ENOENT)
				{
					valueListBuilder.Append(path.Length);
					num--;
					if (num <= 0)
					{
						break;
					}
					continue;
				}
				if (lastErrorInfo.Error == Interop.Error.EEXIST)
				{
					break;
				}
				throw Interop.GetExceptionForIoErrno(lastErrorInfo, path.ToString());
			}
			for (num = valueListBuilder.Length - 1; num >= 0; num--)
			{
				ReadOnlySpan<char> readOnlySpan = fullPath.AsSpan(0, valueListBuilder[num]);
				UnixFileMode mode = ((num == 0) ? unixCreateMode : (UnixFileMode.OtherExecute | UnixFileMode.OtherWrite | UnixFileMode.OtherRead | UnixFileMode.GroupExecute | UnixFileMode.GroupWrite | UnixFileMode.GroupRead | UnixFileMode.UserExecute | UnixFileMode.UserWrite | UnixFileMode.UserRead));
				if (Interop.Sys.MkDir(readOnlySpan, (int)mode) >= 0)
				{
					continue;
				}
				Interop.ErrorInfo lastErrorInfo2 = Interop.Sys.GetLastErrorInfo();
				if (lastErrorInfo2.Error == Interop.Error.EEXIST)
				{
					if (num != 0)
					{
						continue;
					}
					if (DirectoryExists(readOnlySpan))
					{
						break;
					}
				}
				throw Interop.GetExceptionForIoErrno(lastErrorInfo2, readOnlySpan.ToString());
			}
		}
		finally
		{
			valueListBuilder.Dispose();
		}
	}

	private static void MoveDirectory(string sourceFullPath, string destFullPath, bool isCaseSensitiveRename)
	{
		ReadOnlySpan<char> path = Path.TrimEndingDirectorySeparator(sourceFullPath.AsSpan());
		ReadOnlySpan<char> readOnlySpan = Path.TrimEndingDirectorySeparator(destFullPath.AsSpan());
		if (false)
		{
		}
		if (!isCaseSensitiveRename && Interop.Sys.LStat(readOnlySpan, out var output) >= 0)
		{
			if (Interop.Sys.LStat(path, out var output2) < 0)
			{
				throw new DirectoryNotFoundException(SR.Format("IO_PathNotFound_Path", sourceFullPath));
			}
			if (output2.Dev != output.Dev || output2.Ino != output.Ino)
			{
				if ((output2.Mode & 0xF000) != 16384 && Path.EndsInDirectorySeparator(sourceFullPath))
				{
					throw new IOException(SR.Format("IO_PathNotFound_Path", sourceFullPath));
				}
				throw new IOException(SR.Format("IO_AlreadyExists_Name", destFullPath));
			}
			if (1 == 0)
			{
			}
			if (Path.GetFileName(path).SequenceEqual(Path.GetFileName(readOnlySpan)))
			{
				throw new IOException("IO_SourceDestMustBeDifferent");
			}
		}
		if (Interop.Sys.Rename(sourceFullPath.AsSpan(), readOnlySpan) < 0)
		{
			Interop.ErrorInfo lastErrorInfo = Interop.Sys.GetLastErrorInfo();
			switch (lastErrorInfo.Error)
			{
			case Interop.Error.EACCES:
				throw new IOException(SR.Format("UnauthorizedAccess_IODenied_Path", sourceFullPath), lastErrorInfo.RawErrno);
			case Interop.Error.ENOENT:
				throw new DirectoryNotFoundException(SR.Format("IO_PathNotFound_Path", sourceFullPath));
			case Interop.Error.ENOTDIR:
				throw new IOException(SR.Format("IO_PathNotFound_Path", sourceFullPath));
			default:
				throw Interop.GetExceptionForIoErrno(lastErrorInfo);
			}
		}
	}

	public static void RemoveDirectory(string fullPath, bool recursive)
	{
		if (!RemoveEmptyDirectory(fullPath, topLevel: true, !recursive))
		{
			RemoveDirectoryRecursive(fullPath);
		}
	}

	private static void RemoveDirectoryRecursive(string fullPath)
	{
		Exception ex = null;
		try
		{
			foreach (var (fullPath2, flag) in new FileSystemEnumerable<(string, bool)>(fullPath, delegate(ref FileSystemEntry entry)
			{
				bool item = !entry.IsSymbolicLink && entry.IsDirectory;
				return (entry.ToFullPath(), item);
			}, EnumerationOptions.Compatible))
			{
				try
				{
					if (flag)
					{
						RemoveDirectoryRecursive(fullPath2);
					}
					else
					{
						DeleteFile(fullPath2);
					}
				}
				catch (Exception ex2)
				{
					if (ex == null)
					{
						ex = ex2;
					}
				}
			}
		}
		catch (Exception ex3)
		{
			if (ex == null)
			{
				ex = ex3;
			}
		}
		if (ex != null)
		{
			throw ex;
		}
		RemoveEmptyDirectory(fullPath);
	}

	private static bool RemoveEmptyDirectory(string fullPath, bool topLevel = false, bool throwWhenNotEmpty = true)
	{
		if (Interop.Sys.RmDir(fullPath) < 0)
		{
			Interop.ErrorInfo errorInfo = Interop.Sys.GetLastErrorInfo();
			Interop.ErrorInfo errorInfo2;
			if (errorInfo.Error == Interop.Error.ENOTEMPTY)
			{
				if (!throwWhenNotEmpty)
				{
					return false;
				}
			}
			else if (errorInfo.Error == Interop.Error.ENOENT)
			{
				if (!topLevel)
				{
					return true;
				}
			}
			else if (DirectoryExists(fullPath.AsSpan(), out errorInfo2))
			{
				if (topLevel && errorInfo.Error == Interop.Error.ENOTDIR)
				{
					DeleteFile(fullPath);
					return true;
				}
			}
			else if (errorInfo2.Error == Interop.Error.ENOENT)
			{
				errorInfo = errorInfo2;
			}
			if (errorInfo.Error == Interop.Error.EACCES || errorInfo.Error == Interop.Error.EPERM || errorInfo.Error == Interop.Error.EROFS)
			{
				throw new IOException(SR.Format("UnauthorizedAccess_IODenied_Path", fullPath));
			}
			throw Interop.GetExceptionForIoErrno(errorInfo, fullPath, isDirError: true);
		}
		return true;
	}

	public static FileAttributes GetAttributes(string fullPath)
	{
		FileAttributes attributes = new FileInfo(fullPath, null, null, isNormalized: false).Attributes;
		if (attributes == (FileAttributes)(-1))
		{
			throw Interop.GetExceptionForIoErrno(new Interop.ErrorInfo(Interop.Error.ENOENT), fullPath);
		}
		return attributes;
	}

	public static FileAttributes GetAttributes(SafeFileHandle fileHandle)
	{
		return default(FileStatus).GetAttributes(fileHandle);
	}

	public static void SetAttributes(string fullPath, FileAttributes attributes)
	{
		default(FileStatus).SetAttributes(fullPath, attributes, asDirectory: false);
	}

	public static void SetAttributes(SafeFileHandle fileHandle, FileAttributes attributes)
	{
		default(FileStatus).SetAttributes(fileHandle, attributes, asDirectory: false);
	}

	public static UnixFileMode GetUnixFileMode(string fullPath)
	{
		UnixFileMode unixFileMode = default(FileStatus).GetUnixFileMode(fullPath.AsSpan());
		if (unixFileMode == (UnixFileMode)(-1))
		{
			throw Interop.GetExceptionForIoErrno(new Interop.ErrorInfo(Interop.Error.ENOENT), fullPath);
		}
		return unixFileMode;
	}

	public static UnixFileMode GetUnixFileMode(SafeFileHandle fileHandle)
	{
		return default(FileStatus).GetUnixFileMode(fileHandle);
	}

	public static void SetUnixFileMode(string fullPath, UnixFileMode mode)
	{
		default(FileStatus).SetUnixFileMode(fullPath, mode);
	}

	public static void SetUnixFileMode(SafeFileHandle fileHandle, UnixFileMode mode)
	{
		default(FileStatus).SetUnixFileMode(fileHandle, mode);
	}

	public static DateTimeOffset GetCreationTime(string fullPath)
	{
		return default(FileStatus).GetCreationTime(fullPath.AsSpan()).UtcDateTime;
	}

	public static DateTimeOffset GetCreationTime(SafeFileHandle fileHandle)
	{
		return default(FileStatus).GetCreationTime(fileHandle).UtcDateTime;
	}

	public static void SetCreationTime(string fullPath, DateTimeOffset time, bool asDirectory)
	{
		default(FileStatus).SetCreationTime(fullPath, time, asDirectory);
	}

	public static void SetCreationTime(SafeFileHandle fileHandle, DateTimeOffset time)
	{
		default(FileStatus).SetCreationTime(fileHandle, time, asDirectory: false);
	}

	public static DateTimeOffset GetLastAccessTime(string fullPath)
	{
		return default(FileStatus).GetLastAccessTime(fullPath.AsSpan()).UtcDateTime;
	}

	public static DateTimeOffset GetLastAccessTime(SafeFileHandle fileHandle)
	{
		return default(FileStatus).GetLastAccessTime(fileHandle).UtcDateTime;
	}

	public static void SetLastAccessTime(string fullPath, DateTimeOffset time, bool asDirectory)
	{
		default(FileStatus).SetLastAccessTime(fullPath, time, asDirectory);
	}

	public static void SetLastAccessTime(SafeFileHandle fileHandle, DateTimeOffset time)
	{
		default(FileStatus).SetLastAccessTime(fileHandle, time, asDirectory: false);
	}

	public static DateTimeOffset GetLastWriteTime(string fullPath)
	{
		return default(FileStatus).GetLastWriteTime(fullPath.AsSpan()).UtcDateTime;
	}

	public static DateTimeOffset GetLastWriteTime(SafeFileHandle fileHandle)
	{
		return default(FileStatus).GetLastWriteTime(fileHandle).UtcDateTime;
	}

	public static void SetLastWriteTime(string fullPath, DateTimeOffset time, bool asDirectory)
	{
		default(FileStatus).SetLastWriteTime(fullPath, time, asDirectory);
	}

	public static void SetLastWriteTime(SafeFileHandle fileHandle, DateTimeOffset time)
	{
		default(FileStatus).SetLastWriteTime(fileHandle, time, asDirectory: false);
	}

	public static string[] GetLogicalDrives()
	{
		return DriveInfoInternal.GetLogicalDrives();
	}

	internal static string GetLinkTarget(ReadOnlySpan<char> linkPath, bool isDirectory)
	{
		return Interop.Sys.ReadLink(linkPath);
	}

	internal static void CreateSymbolicLink(string path, string pathToTarget, bool isDirectory)
	{
		Interop.CheckIo(Interop.Sys.SymLink(pathToTarget, path), path);
	}

	internal static FileSystemInfo ResolveLinkTarget(string linkPath, bool returnFinalTarget, bool isDirectory)
	{
		ValueStringBuilder sb = new ValueStringBuilder(256);
		sb.Append(linkPath);
		string text = Interop.Sys.ReadLink(linkPath.AsSpan());
		if (text == null)
		{
			sb.Dispose();
			Interop.Error lastError = Interop.Sys.GetLastError();
			if (lastError == Interop.Error.EINVAL)
			{
				return null;
			}
			throw Interop.GetExceptionForIoErrno(new Interop.ErrorInfo(lastError), linkPath, isDirectory);
		}
		if (!returnFinalTarget)
		{
			GetLinkTargetFullPath(ref sb, text.AsSpan());
		}
		else
		{
			string text2 = text;
			int num = 1;
			while (text2 != null)
			{
				if (num > 40)
				{
					sb.Dispose();
					throw new IOException(SR.Format("IO_TooManySymbolicLinkLevels", linkPath));
				}
				GetLinkTargetFullPath(ref sb, text2.AsSpan());
				text2 = Interop.Sys.ReadLink(sb.AsSpan());
				num++;
			}
		}
		text = sb.ToString();
		if (!isDirectory)
		{
			return new FileInfo(text);
		}
		return new DirectoryInfo(text);
		static void GetLinkTargetFullPath(ref ValueStringBuilder reference, ReadOnlySpan<char> linkTarget)
		{
			if (PathInternal.IsPartiallyQualified(linkTarget))
			{
				reference.Length = Path.GetDirectoryNameOffset(reference.AsSpan());
				reference.Append('/');
			}
			else
			{
				reference.Length = 0;
			}
			reference.Append(linkTarget);
		}
	}

	public static bool DirectoryExists(ReadOnlySpan<char> fullPath)
	{
		Interop.ErrorInfo errorInfo;
		return DirectoryExists(fullPath, out errorInfo);
	}

	private static bool DirectoryExists(ReadOnlySpan<char> fullPath, out Interop.ErrorInfo errorInfo)
	{
		errorInfo = default(Interop.ErrorInfo);
		if (Interop.Sys.Stat(fullPath, out var output) < 0)
		{
			errorInfo = Interop.Sys.GetLastErrorInfo();
			return false;
		}
		return (output.Mode & 0xF000) == 16384;
	}

	public static bool FileExists(ReadOnlySpan<char> fullPath)
	{
		Interop.ErrorInfo errorInfo;
		return FileExists(fullPath, out errorInfo);
	}

	private static bool FileExists(ReadOnlySpan<char> fullPath, out Interop.ErrorInfo errorInfo)
	{
		errorInfo = default(Interop.ErrorInfo);
		fullPath = Path.TrimEndingDirectorySeparator(fullPath);
		if (Interop.Sys.LStat(fullPath, out var output) < 0)
		{
			errorInfo = Interop.Sys.GetLastErrorInfo();
			return false;
		}
		if ((output.Mode & 0xF000) == 40960 && Interop.Sys.Stat(fullPath, out output) < 0)
		{
			return true;
		}
		return (output.Mode & 0xF000) != 16384;
	}
}
