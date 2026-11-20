using Microsoft.Win32.SafeHandles;

namespace System.IO.Strategies;

internal sealed class UnixFileStreamStrategy : OSFileStreamStrategy
{
	internal UnixFileStreamStrategy(SafeFileHandle handle, FileAccess access)
		: base(handle, access)
	{
	}

	internal UnixFileStreamStrategy(string path, FileMode mode, FileAccess access, FileShare share, FileOptions options, long preallocationSize, UnixFileMode? unixCreateMode)
		: base(path, mode, access, share, options, preallocationSize, unixCreateMode)
	{
	}
}
