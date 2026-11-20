using Microsoft.Win32.SafeHandles;

namespace System.IO;

internal struct FileStatus
{
	private int _state;

	private Interop.Sys.FileStatus _fileCache;

	private int _isReadOnlyCache;

	private bool EntryExists => _state <= -3;

	private bool IsDir => _state == -4;

	private bool IsBrokenLink => _state == -5;

	private bool HasHiddenFlag
	{
		get
		{
			if (EntryExists)
			{
				return (_fileCache.UserFlags & 0x8000) == 32768;
			}
			return false;
		}
	}

	private bool HasReadOnlyFlag
	{
		get
		{
			if (!EntryExists || IsBrokenLink)
			{
				return false;
			}
			if (_isReadOnlyCache == 0)
			{
				return false;
			}
			if (_isReadOnlyCache == 1)
			{
				return true;
			}
			bool flag = IsModeReadOnlyCore();
			_isReadOnlyCache = (flag ? 1 : 0);
			return flag;
		}
	}

	private bool HasSymbolicLinkFlag
	{
		get
		{
			if (EntryExists)
			{
				return (_fileCache.Mode & 0xF000) == 40960;
			}
			return false;
		}
	}

	private bool IsModeReadOnlyCore()
	{
		UnixFileMode unixFileMode = (UnixFileMode)(_fileCache.Mode & 0xFFF);
		bool flag = (unixFileMode & UnixFileMode.UserRead) != UnixFileMode.None && (unixFileMode & UnixFileMode.UserWrite) == 0;
		bool flag2 = (unixFileMode & UnixFileMode.GroupRead) != UnixFileMode.None && (unixFileMode & UnixFileMode.GroupWrite) == 0;
		bool flag3 = (unixFileMode & UnixFileMode.OtherRead) != UnixFileMode.None && (unixFileMode & UnixFileMode.OtherWrite) == 0;
		if (flag == flag2 && flag2 == flag3)
		{
			return flag;
		}
		if (_fileCache.Uid == Interop.Sys.GetEUid())
		{
			return flag;
		}
		if (flag2 == flag)
		{
			return flag2;
		}
		if (Interop.Sys.IsMemberOfGroup(_fileCache.Gid))
		{
			return flag2;
		}
		return flag3;
	}

	internal void InvalidateCaches()
	{
		_state = 0;
	}

	internal bool IsReadOnly(ReadOnlySpan<char> path, bool continueOnError = false)
	{
		EnsureCachesInitialized(path, continueOnError);
		return HasReadOnlyFlag;
	}

	internal bool IsFileSystemEntryHidden(ReadOnlySpan<char> path, ReadOnlySpan<char> fileName)
	{
		if (IsNameHidden(fileName))
		{
			return true;
		}
		if (!Interop.Sys.SupportsHiddenFlag)
		{
			return false;
		}
		EnsureCachesInitialized(path, continueOnError: true);
		return HasHiddenFlag;
	}

	internal static bool IsNameHidden(ReadOnlySpan<char> fileName)
	{
		return fileName.StartsWith('.');
	}

	internal bool IsDirectory(ReadOnlySpan<char> path, bool continueOnError = false)
	{
		EnsureCachesInitialized(path, continueOnError);
		return IsDir;
	}

	internal bool IsSymbolicLink(ReadOnlySpan<char> path, bool continueOnError = false)
	{
		EnsureCachesInitialized(path, continueOnError);
		return HasSymbolicLinkFlag;
	}

	internal FileAttributes GetAttributes(ReadOnlySpan<char> path, ReadOnlySpan<char> fileName, bool continueOnError = false)
	{
		return GetAttributes(null, path, fileName, continueOnError);
	}

	internal FileAttributes GetAttributes(SafeFileHandle handle, bool continueOnError = false)
	{
		return GetAttributes(handle, handle.Path.AsSpan(), Path.GetFileName(handle.Path).AsSpan(), continueOnError);
	}

	private FileAttributes GetAttributes(SafeFileHandle handle, ReadOnlySpan<char> path, ReadOnlySpan<char> fileName, bool continueOnError = false)
	{
		EnsureCachesInitialized(handle, path, continueOnError);
		if (!EntryExists)
		{
			return (FileAttributes)(-1);
		}
		FileAttributes fileAttributes = FileAttributes.None;
		if (HasReadOnlyFlag)
		{
			fileAttributes |= FileAttributes.ReadOnly;
		}
		if (HasSymbolicLinkFlag)
		{
			fileAttributes |= FileAttributes.ReparsePoint;
		}
		if (IsDir)
		{
			fileAttributes |= FileAttributes.Directory;
		}
		if (IsNameHidden(fileName) || HasHiddenFlag)
		{
			fileAttributes |= FileAttributes.Hidden;
		}
		if (fileAttributes == FileAttributes.None)
		{
			return FileAttributes.Normal;
		}
		return fileAttributes;
	}

	internal void SetAttributes(string path, FileAttributes attributes, bool asDirectory)
	{
		SetAttributes(null, path, attributes, asDirectory);
	}

	internal void SetAttributes(SafeFileHandle handle, FileAttributes attributes, bool asDirectory)
	{
		SetAttributes(handle, handle.Path, attributes, asDirectory);
	}

	private void SetAttributes(SafeFileHandle handle, string path, FileAttributes attributes, bool asDirectory)
	{
		if ((attributes & ~(FileAttributes.ReadOnly | FileAttributes.Hidden | FileAttributes.System | FileAttributes.Directory | FileAttributes.Archive | FileAttributes.Device | FileAttributes.Normal | FileAttributes.Temporary | FileAttributes.SparseFile | FileAttributes.ReparsePoint | FileAttributes.Compressed | FileAttributes.Offline | FileAttributes.NotContentIndexed | FileAttributes.Encrypted | FileAttributes.IntegrityStream | FileAttributes.NoScrubData)) != FileAttributes.None)
		{
			throw new ArgumentException("Arg_InvalidFileAttrs", "Attributes");
		}
		EnsureCachesInitialized(handle, path.AsSpan());
		if (!EntryExists)
		{
			ThrowNotFound(path);
		}
		if (Interop.Sys.CanSetHiddenFlag)
		{
			bool flag = (attributes & FileAttributes.Hidden) != 0;
			if (flag ^ HasHiddenFlag)
			{
				uint flags = (flag ? (_fileCache.UserFlags | 0x8000) : (_fileCache.UserFlags & 0xFFFF7FFFu));
				Interop.CheckIo((handle != null) ? Interop.Sys.FChflags(handle, flags) : Interop.Sys.LChflags(path, flags), path, asDirectory);
			}
		}
		int num = _fileCache.Mode & 0xFFF;
		int num2 = num;
		if ((attributes & FileAttributes.ReadOnly) != FileAttributes.None)
		{
			num2 &= -147;
		}
		else if ((num2 & 0x100) != 0)
		{
			num2 |= 0x80;
		}
		if (num2 != num)
		{
			Interop.CheckIo((handle != null) ? Interop.Sys.FChMod(handle, num2) : Interop.Sys.ChMod(path, num2), path, asDirectory);
		}
		InvalidateCaches();
	}

	internal bool GetExists(ReadOnlySpan<char> path, bool asDirectory)
	{
		EnsureCachesInitialized(path, continueOnError: true);
		if (EntryExists)
		{
			return asDirectory == IsDir;
		}
		return false;
	}

	internal DateTimeOffset GetCreationTime(ReadOnlySpan<char> path, bool continueOnError = false)
	{
		return GetCreationTime(null, path, continueOnError);
	}

	internal DateTimeOffset GetCreationTime(SafeFileHandle handle, bool continueOnError = false)
	{
		return GetCreationTime(handle, handle.Path.AsSpan(), continueOnError);
	}

	private DateTimeOffset GetCreationTime(SafeFileHandle handle, ReadOnlySpan<char> path, bool continueOnError = false)
	{
		EnsureCachesInitialized(handle, path, continueOnError);
		if (!EntryExists)
		{
			return new DateTimeOffset(DateTime.FromFileTimeUtc(0L));
		}
		if ((_fileCache.Flags & Interop.Sys.FileStatusFlags.HasBirthTime) != Interop.Sys.FileStatusFlags.None)
		{
			return UnixTimeToDateTimeOffset(_fileCache.BirthTime, _fileCache.BirthTimeNsec);
		}
		if (_fileCache.MTime < _fileCache.CTime || (_fileCache.MTime == _fileCache.CTime && _fileCache.MTimeNsec < _fileCache.CTimeNsec))
		{
			return UnixTimeToDateTimeOffset(_fileCache.MTime, _fileCache.MTimeNsec);
		}
		return UnixTimeToDateTimeOffset(_fileCache.CTime, _fileCache.CTimeNsec);
	}

	internal DateTimeOffset GetLastAccessTime(ReadOnlySpan<char> path, bool continueOnError = false)
	{
		return GetLastAccessTime(null, path, continueOnError);
	}

	internal DateTimeOffset GetLastAccessTime(SafeFileHandle handle, bool continueOnError = false)
	{
		return GetLastAccessTime(handle, handle.Path.AsSpan(), continueOnError);
	}

	private DateTimeOffset GetLastAccessTime(SafeFileHandle handle, ReadOnlySpan<char> path, bool continueOnError = false)
	{
		EnsureCachesInitialized(handle, path, continueOnError);
		if (!EntryExists)
		{
			return new DateTimeOffset(DateTime.FromFileTimeUtc(0L));
		}
		return UnixTimeToDateTimeOffset(_fileCache.ATime, _fileCache.ATimeNsec);
	}

	internal void SetLastAccessTime(string path, DateTimeOffset time, bool asDirectory)
	{
		SetLastAccessTime(null, path, time, asDirectory);
	}

	internal void SetLastAccessTime(SafeFileHandle handle, DateTimeOffset time, bool asDirectory)
	{
		SetLastAccessTime(handle, handle.Path, time, asDirectory);
	}

	private void SetLastAccessTime(SafeFileHandle handle, string path, DateTimeOffset time, bool asDirectory)
	{
		SetAccessOrWriteTime(handle, path, time, isAccessTime: true, asDirectory);
	}

	internal DateTimeOffset GetLastWriteTime(ReadOnlySpan<char> path, bool continueOnError = false)
	{
		return GetLastWriteTime(null, path, continueOnError);
	}

	internal DateTimeOffset GetLastWriteTime(SafeFileHandle handle, bool continueOnError = false)
	{
		return GetLastWriteTime(handle, handle.Path.AsSpan(), continueOnError);
	}

	private DateTimeOffset GetLastWriteTime(SafeFileHandle handle, ReadOnlySpan<char> path, bool continueOnError = false)
	{
		EnsureCachesInitialized(handle, path, continueOnError);
		if (!EntryExists)
		{
			return new DateTimeOffset(DateTime.FromFileTimeUtc(0L));
		}
		return UnixTimeToDateTimeOffset(_fileCache.MTime, _fileCache.MTimeNsec);
	}

	internal void SetLastWriteTime(string path, DateTimeOffset time, bool asDirectory)
	{
		SetLastWriteTime(null, path, time, asDirectory);
	}

	internal void SetLastWriteTime(SafeFileHandle handle, DateTimeOffset time, bool asDirectory)
	{
		SetLastWriteTime(handle, handle.Path, time, asDirectory);
	}

	internal void SetLastWriteTime(SafeFileHandle handle, string path, DateTimeOffset time, bool asDirectory)
	{
		SetAccessOrWriteTime(handle, path, time, isAccessTime: false, asDirectory);
	}

	private static DateTimeOffset UnixTimeToDateTimeOffset(long seconds, long nanoseconds)
	{
		return DateTimeOffset.FromUnixTimeSeconds(seconds).AddTicks(nanoseconds / 100);
	}

	private unsafe void SetAccessOrWriteTimeCore(SafeFileHandle handle, string path, DateTimeOffset time, bool isAccessTime, bool checkCreationTime, bool asDirectory)
	{
		InvalidateCaches();
		EnsureCachesInitialized(handle, path.AsSpan());
		if (!EntryExists)
		{
			ThrowNotFound(path);
		}
		Interop.Sys.TimeSpec* ptr = stackalloc Interop.Sys.TimeSpec[2];
		long num = time.ToUnixTimeSeconds();
		long tvNsec = UnixTimeSecondsToNanoseconds(time, num);
		if (isAccessTime)
		{
			ptr->TvSec = num;
			ptr->TvNsec = tvNsec;
			ptr[1].TvSec = _fileCache.MTime;
			ptr[1].TvNsec = _fileCache.MTimeNsec;
		}
		else
		{
			ptr->TvSec = _fileCache.ATime;
			ptr->TvNsec = _fileCache.ATimeNsec;
			ptr[1].TvSec = num;
			ptr[1].TvNsec = tvNsec;
		}
		Interop.CheckIo((handle != null) ? Interop.Sys.FUTimens(handle, ptr) : Interop.Sys.UTimensat(path, ptr), path, asDirectory);
		bool num2 = checkCreationTime && (_fileCache.Flags & Interop.Sys.FileStatusFlags.HasBirthTime) != Interop.Sys.FileStatusFlags.None && (ptr[1].TvSec < _fileCache.BirthTime || (ptr[1].TvSec == _fileCache.BirthTime && ptr[1].TvNsec < _fileCache.BirthTimeNsec));
		InvalidateCaches();
		if (num2)
		{
			Interop.Error error = SetCreationTimeCore(handle, path, _fileCache.BirthTime, _fileCache.BirthTimeNsec);
			if (error != Interop.Error.SUCCESS && error != Interop.Error.ENOTSUP)
			{
				Interop.CheckIo(error, path, asDirectory);
			}
		}
	}

	internal long GetLength(ReadOnlySpan<char> path, bool continueOnError = false)
	{
		EnsureCachesInitialized(path, continueOnError);
		if (!EntryExists)
		{
			return 0L;
		}
		return _fileCache.Size;
	}

	internal UnixFileMode GetUnixFileMode(ReadOnlySpan<char> path, bool continueOnError = false)
	{
		return GetUnixFileMode(null, path, continueOnError);
	}

	internal UnixFileMode GetUnixFileMode(SafeFileHandle handle, bool continueOnError = false)
	{
		return GetUnixFileMode(handle, handle.Path.AsSpan(), continueOnError);
	}

	private UnixFileMode GetUnixFileMode(SafeFileHandle handle, ReadOnlySpan<char> path, bool continueOnError = false)
	{
		EnsureCachesInitialized(handle, path, continueOnError);
		if (!EntryExists || IsBrokenLink)
		{
			return (UnixFileMode)(-1);
		}
		return (UnixFileMode)(_fileCache.Mode & 0xFFF);
	}

	internal void SetUnixFileMode(string path, UnixFileMode mode)
	{
		SetUnixFileMode(null, path, mode);
	}

	internal void SetUnixFileMode(SafeFileHandle handle, UnixFileMode mode)
	{
		SetUnixFileMode(handle, handle.Path, mode);
	}

	private void SetUnixFileMode(SafeFileHandle handle, string path, UnixFileMode mode)
	{
		if ((mode & ~(UnixFileMode.OtherExecute | UnixFileMode.OtherWrite | UnixFileMode.OtherRead | UnixFileMode.GroupExecute | UnixFileMode.GroupWrite | UnixFileMode.GroupRead | UnixFileMode.UserExecute | UnixFileMode.UserWrite | UnixFileMode.UserRead | UnixFileMode.StickyBit | UnixFileMode.SetGroup | UnixFileMode.SetUser)) != UnixFileMode.None)
		{
			throw new ArgumentException("Arg_InvalidUnixFileMode", "UnixFileMode");
		}
		Interop.CheckIo((handle != null) ? Interop.Sys.FChMod(handle, (int)mode) : Interop.Sys.ChMod(path, (int)mode), path);
		InvalidateCaches();
	}

	internal void RefreshCaches(ReadOnlySpan<char> path)
	{
		RefreshCaches(null, path);
	}

	internal void RefreshCaches(SafeFileHandle handle, ReadOnlySpan<char> path)
	{
		_isReadOnlyCache = -1;
		if (((handle != null) ? Interop.Sys.FStat(handle, out _fileCache) : Interop.Sys.LStat(Path.TrimEndingDirectorySeparator(path), out _fileCache)) < 0)
		{
			Interop.ErrorInfo lastErrorInfo = Interop.Sys.GetLastErrorInfo();
			switch (lastErrorInfo.Error)
			{
			case Interop.Error.ENOENT:
				_state = -1;
				break;
			case Interop.Error.ENOTDIR:
				_state = -2;
				break;
			default:
				_state = lastErrorInfo.RawErrno;
				break;
			}
			return;
		}
		int num = _fileCache.Mode & 0xF000;
		bool flag = num == 16384;
		if (num == 40960)
		{
			if (Interop.Sys.Stat(path, out var output) != 0)
			{
				_state = -5;
				return;
			}
			flag = (output.Mode & 0xF000) == 16384;
			_fileCache.Mode = 0xA000 | (output.Mode & 0xFFF);
		}
		_state = (flag ? (-4) : (-3));
	}

	internal void EnsureCachesInitialized(ReadOnlySpan<char> path, bool continueOnError = false)
	{
		EnsureCachesInitialized(null, path, continueOnError);
	}

	internal void EnsureCachesInitialized(SafeFileHandle handle, ReadOnlySpan<char> path, bool continueOnError = false)
	{
		if (_state == 0)
		{
			RefreshCaches(handle, path);
		}
		if (!continueOnError)
		{
			ThrowOnCacheInitializationError(path);
		}
	}

	private void ThrowOnCacheInitializationError(ReadOnlySpan<char> path)
	{
		int state = _state;
		if (state > 0)
		{
			InvalidateCaches();
			throw Interop.GetExceptionForIoErrno(new Interop.ErrorInfo(state), new string(path));
		}
	}

	private static long UnixTimeSecondsToNanoseconds(DateTimeOffset time, long seconds)
	{
		return (time.UtcDateTime.Ticks - DateTimeOffset.UnixEpoch.Ticks - seconds * 10000000) * 100;
	}

	private void ThrowNotFound(string path)
	{
		throw Interop.GetExceptionForIoErrno(new Interop.ErrorInfo((_state == -2) ? Interop.Error.ENOTDIR : Interop.Error.ENOENT), path);
	}

	internal void SetCreationTime(string path, DateTimeOffset time, bool asDirectory)
	{
		SetLastWriteTime(path, time, asDirectory);
	}

	internal void SetCreationTime(SafeFileHandle handle, DateTimeOffset time, bool asDirectory)
	{
		SetLastWriteTime(handle, time, asDirectory);
	}

	private void SetAccessOrWriteTime(SafeFileHandle handle, string path, DateTimeOffset time, bool isAccessTime, bool asDirectory)
	{
		SetAccessOrWriteTimeCore(handle, path, time, isAccessTime, checkCreationTime: false, asDirectory);
	}

	private static Interop.Error SetCreationTimeCore(SafeFileHandle handle, string path, long seconds, long nanoseconds)
	{
		throw new InvalidOperationException();
	}
}
