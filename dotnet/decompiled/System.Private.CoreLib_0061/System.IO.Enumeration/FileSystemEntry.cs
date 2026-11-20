using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.IO.Enumeration;

public ref struct FileSystemEntry
{
	[InlineArray(256)]
	private struct FileNameBuffer
	{
		internal char _char0;
	}

	private Interop.Sys.DirectoryEntry _directoryEntry;

	private bool _isDirectory;

	private FileStatus _status;

	private Span<char> _pathBuffer;

	private ReadOnlySpan<char> _fullPath;

	private ReadOnlySpan<char> _fileName;

	private FileNameBuffer _fileNameBuffer;

	private ReadOnlySpan<char> FullPath
	{
		get
		{
			if (_fullPath.Length == 0)
			{
				Path.TryJoin(Directory, FileName, _pathBuffer, out var charsWritten);
				_fullPath = _pathBuffer.Slice(0, charsWritten);
			}
			return _fullPath;
		}
	}

	public ReadOnlySpan<char> FileName
	{
		get
		{
			if (_directoryEntry.NameLength != 0 && _fileName.Length == 0)
			{
				Span<char> buffer = MemoryMarshal.CreateSpan(ref _fileNameBuffer._char0, 256);
				_fileName = _directoryEntry.GetName(buffer);
			}
			return _fileName;
		}
	}

	public ReadOnlySpan<char> Directory { get; private set; }

	public ReadOnlySpan<char> RootDirectory { get; private set; }

	public ReadOnlySpan<char> OriginalRootDirectory { get; private set; }

	public FileAttributes Attributes
	{
		get
		{
			FileAttributes attributes = _status.GetAttributes(FullPath, FileName, continueOnError: true);
			if (attributes != (FileAttributes)(-1))
			{
				return attributes;
			}
			attributes = FileAttributes.None;
			if (IsSymbolicLink)
			{
				attributes |= FileAttributes.ReparsePoint;
			}
			if (IsDirectory)
			{
				attributes |= FileAttributes.Directory;
			}
			if (FileStatus.IsNameHidden(FileName))
			{
				attributes |= FileAttributes.Hidden;
			}
			if (attributes == FileAttributes.None)
			{
				return FileAttributes.Normal;
			}
			return attributes;
		}
	}

	public long Length => _status.GetLength(FullPath, continueOnError: true);

	public DateTimeOffset CreationTimeUtc => _status.GetCreationTime(FullPath, continueOnError: true);

	public DateTimeOffset LastAccessTimeUtc => _status.GetLastAccessTime(FullPath, continueOnError: true);

	public DateTimeOffset LastWriteTimeUtc => _status.GetLastWriteTime(FullPath, continueOnError: true);

	public bool IsHidden => _status.IsFileSystemEntryHidden(FullPath, FileName);

	internal bool IsReadOnly => _status.IsReadOnly(FullPath, continueOnError: true);

	public bool IsDirectory => _isDirectory;

	internal bool IsSymbolicLink => _directoryEntry.InodeType == Interop.Sys.NodeType.DT_LNK;

	public string ToSpecifiedFullPath()
	{
		ReadOnlySpan<char> readOnlySpan = Directory.Slice(RootDirectory.Length);
		if (Path.EndsInDirectorySeparator(OriginalRootDirectory) && PathInternal.StartsWithDirectorySeparator(readOnlySpan))
		{
			readOnlySpan = readOnlySpan.Slice(1);
		}
		return Join(OriginalRootDirectory, readOnlySpan, FileName);
	}

	internal static FileAttributes Initialize(ref FileSystemEntry entry, Interop.Sys.DirectoryEntry directoryEntry, ReadOnlySpan<char> directory, ReadOnlySpan<char> rootDirectory, ReadOnlySpan<char> originalRootDirectory, Span<char> pathBuffer)
	{
		entry._directoryEntry = directoryEntry;
		entry.Directory = directory;
		entry.RootDirectory = rootDirectory;
		entry.OriginalRootDirectory = originalRootDirectory;
		entry._pathBuffer = pathBuffer;
		entry._fullPath = ReadOnlySpan<char>.Empty;
		entry._fileName = ReadOnlySpan<char>.Empty;
		entry._isDirectory = false;
		entry._status.InvalidateCaches();
		bool num = directoryEntry.InodeType == Interop.Sys.NodeType.DT_DIR;
		bool flag = directoryEntry.InodeType == Interop.Sys.NodeType.DT_LNK;
		bool flag2 = directoryEntry.InodeType == Interop.Sys.NodeType.DT_UNKNOWN;
		if (num)
		{
			entry._isDirectory = true;
		}
		else if (flag)
		{
			entry._isDirectory = entry._status.IsDirectory(entry.FullPath, continueOnError: true);
		}
		else if (flag2)
		{
			entry._isDirectory = entry._status.IsDirectory(entry.FullPath, continueOnError: true);
			if (entry._status.IsSymbolicLink(entry.FullPath, continueOnError: true))
			{
				entry._directoryEntry.InodeType = Interop.Sys.NodeType.DT_LNK;
			}
		}
		FileAttributes fileAttributes = FileAttributes.None;
		if (entry.IsSymbolicLink)
		{
			fileAttributes |= FileAttributes.ReparsePoint;
		}
		if (entry.IsDirectory)
		{
			fileAttributes |= FileAttributes.Directory;
		}
		return fileAttributes;
	}

	public FileSystemInfo ToFileSystemInfo()
	{
		return FileSystemInfo.Create(ToFullPath(), new string(FileName), _isDirectory, ref _status);
	}

	public string ToFullPath()
	{
		return new string(FullPath);
	}

	private static string Join(ReadOnlySpan<char> originalRootDirectory, ReadOnlySpan<char> relativePath, ReadOnlySpan<char> fileName)
	{
		return Path.Join(originalRootDirectory, relativePath, fileName);
	}
}
