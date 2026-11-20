using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Threading;

namespace System.IO.Enumeration;

public abstract class FileSystemEnumerator<TResult> : CriticalFinalizerObject, IEnumerator<TResult>, IDisposable, IEnumerator
{
	private int _remainingRecursionDepth;

	private readonly string _originalRootDirectory;

	private readonly string _rootDirectory;

	private readonly EnumerationOptions _options;

	private readonly object _lock = new object();

	private string _currentPath;

	private nint _directoryHandle;

	private bool _lastEntryFound;

	private Queue<(string Path, int RemainingDepth)> _pending;

	private Interop.Sys.DirectoryEntry _entry;

	private TResult _current;

	private char[] _pathBuffer;

	public TResult Current => _current;

	object? IEnumerator.Current => Current;

	public FileSystemEnumerator(string directory, EnumerationOptions? options = null)
		: this(directory, isNormalized: false, options)
	{
	}

	internal FileSystemEnumerator(string directory, bool isNormalized, EnumerationOptions options = null)
	{
		ArgumentNullException.ThrowIfNull(directory, "directory");
		_originalRootDirectory = directory;
		_rootDirectory = Path.TrimEndingDirectorySeparator(isNormalized ? directory : Path.GetFullPath(directory));
		_options = options ?? EnumerationOptions.Default;
		_remainingRecursionDepth = _options.MaxRecursionDepth;
		Init();
	}

	protected virtual bool ShouldIncludeEntry(ref FileSystemEntry entry)
	{
		return true;
	}

	protected virtual bool ShouldRecurseIntoEntry(ref FileSystemEntry entry)
	{
		return true;
	}

	protected abstract TResult TransformEntry(ref FileSystemEntry entry);

	protected virtual void OnDirectoryFinished(ReadOnlySpan<char> directory)
	{
	}

	protected virtual bool ContinueOnError(int error)
	{
		return false;
	}

	private void DirectoryFinished()
	{
		_entry = default(Interop.Sys.DirectoryEntry);
		CloseDirectoryHandle();
		OnDirectoryFinished(_currentPath.AsSpan());
		if (!DequeueNextDirectory())
		{
			_lastEntryFound = true;
		}
		else
		{
			FindNextEntry();
		}
	}

	public void Reset()
	{
		throw new NotSupportedException();
	}

	public void Dispose()
	{
		InternalDispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	~FileSystemEnumerator()
	{
		InternalDispose(disposing: false);
	}

	internal FileSystemEnumerator(string directory, bool isNormalized, EnumerationOptions options, string expression)
		: this(directory, isNormalized, options)
	{
	}

	private void Init()
	{
		_directoryHandle = CreateDirectoryHandle(_rootDirectory);
		if (_directoryHandle == IntPtr.Zero)
		{
			_lastEntryFound = true;
		}
		_currentPath = _rootDirectory;
		try
		{
			_pathBuffer = ArrayPool<char>.Shared.Rent(4096);
		}
		catch
		{
			CloseDirectoryHandle();
			throw;
		}
	}

	private bool InternalContinueOnError(Interop.ErrorInfo info, bool ignoreNotFound = false)
	{
		if ((!ignoreNotFound || !IsDirectoryNotFound(info)) && (!_options.IgnoreInaccessible || !IsAccessError(info)))
		{
			return ContinueOnError(info.RawErrno);
		}
		return true;
	}

	private static bool IsDirectoryNotFound(Interop.ErrorInfo info)
	{
		if (info.Error != Interop.Error.ENOTDIR)
		{
			return info.Error == Interop.Error.ENOENT;
		}
		return true;
	}

	private static bool IsAccessError(Interop.ErrorInfo info)
	{
		if (info.Error != Interop.Error.EACCES && info.Error != Interop.Error.EBADF)
		{
			return info.Error == Interop.Error.EPERM;
		}
		return true;
	}

	private nint CreateDirectoryHandle(string path, bool ignoreNotFound = false)
	{
		nint num = Interop.Sys.OpenDir(path);
		if (num == IntPtr.Zero)
		{
			Interop.ErrorInfo lastErrorInfo = Interop.Sys.GetLastErrorInfo();
			if (InternalContinueOnError(lastErrorInfo, ignoreNotFound))
			{
				return IntPtr.Zero;
			}
			throw Interop.GetExceptionForIoErrno(lastErrorInfo, path, isDirError: true);
		}
		return num;
	}

	private void CloseDirectoryHandle()
	{
		nint num = Interlocked.Exchange(ref _directoryHandle, IntPtr.Zero);
		if (num != IntPtr.Zero)
		{
			Interop.Sys.CloseDir(num);
		}
	}

	public unsafe bool MoveNext()
	{
		if (_lastEntryFound)
		{
			return false;
		}
		FileSystemEntry entry = default(FileSystemEntry);
		lock (_lock)
		{
			if (_lastEntryFound)
			{
				return false;
			}
			while (true)
			{
				FindNextEntry();
				if (_lastEntryFound)
				{
					return false;
				}
				FileAttributes num = FileSystemEntry.Initialize(ref entry, _entry, _currentPath.AsSpan(), _rootDirectory.AsSpan(), _originalRootDirectory.AsSpan(), new Span<char>(_pathBuffer));
				bool flag = (num & FileAttributes.Directory) != 0;
				bool flag2 = (num & FileAttributes.ReparsePoint) != 0;
				bool flag3 = false;
				if (flag && *_entry.Name == 46 && (_entry.Name[1] == 0 || (_entry.Name[1] == 46 && _entry.Name[2] == 0)))
				{
					if (!_options.ReturnSpecialDirectories)
					{
						continue;
					}
					flag3 = true;
				}
				if (!flag3 && _options.AttributesToSkip != FileAttributes.None && ((ShouldSkip(FileAttributes.Directory) && flag) || (ShouldSkip(FileAttributes.ReparsePoint) && flag2) || (ShouldSkip(FileAttributes.Hidden) && entry.IsHidden) || (ShouldSkip(FileAttributes.ReadOnly) && entry.IsReadOnly)))
				{
					continue;
				}
				if (flag && !flag3 && _options.RecurseSubdirectories && _remainingRecursionDepth > 0 && ShouldRecurseIntoEntry(ref entry))
				{
					if (_pending == null)
					{
						_pending = new Queue<(string, int)>();
					}
					_pending.Enqueue((Path.Join(_currentPath.AsSpan(), entry.FileName), _remainingRecursionDepth - 1));
				}
				if (ShouldIncludeEntry(ref entry))
				{
					break;
				}
			}
			_current = TransformEntry(ref entry);
			return true;
		}
		bool ShouldSkip(FileAttributes attributeToSkip)
		{
			return (_options.AttributesToSkip & attributeToSkip) != 0;
		}
	}

	private unsafe void FindNextEntry()
	{
		int num;
		fixed (Interop.Sys.DirectoryEntry* entry = &_entry)
		{
			num = Interop.Sys.ReadDir(_directoryHandle, entry);
		}
		switch (num)
		{
		case -1:
			DirectoryFinished();
			return;
		case 0:
			return;
		}
		if (InternalContinueOnError(new Interop.ErrorInfo(num)))
		{
			DirectoryFinished();
			return;
		}
		throw Interop.GetExceptionForIoErrno(new Interop.ErrorInfo(num), _currentPath, isDirError: true);
	}

	private bool DequeueNextDirectory()
	{
		for (_directoryHandle = IntPtr.Zero; _directoryHandle == IntPtr.Zero; _directoryHandle = CreateDirectoryHandle(_currentPath, ignoreNotFound: true))
		{
			if (_pending == null || _pending.Count == 0)
			{
				return false;
			}
			(string, int) tuple = _pending.Dequeue();
			_currentPath = tuple.Item1;
			_remainingRecursionDepth = tuple.Item2;
		}
		return true;
	}

	private void InternalDispose(bool disposing)
	{
		if (_lock != null)
		{
			lock (_lock)
			{
				_lastEntryFound = true;
				_pending = null;
				CloseDirectoryHandle();
				char[] pathBuffer = _pathBuffer;
				if (pathBuffer != null)
				{
					_pathBuffer = null;
					ArrayPool<char>.Shared.Return(pathBuffer);
				}
			}
		}
		Dispose(disposing);
	}
}
