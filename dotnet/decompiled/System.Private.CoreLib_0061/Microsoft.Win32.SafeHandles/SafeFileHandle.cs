using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Strategies;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Microsoft.Win32.SafeHandles;

public sealed class SafeFileHandle : SafeHandleZeroOrMinusOneIsInvalid
{
	internal sealed class ThreadPoolValueTaskSource : IThreadPoolWorkItem, IValueTaskSource<int>, IValueTaskSource<long>, IValueTaskSource
	{
		private enum Operation : byte
		{
			None,
			Read,
			Write,
			ReadScatter,
			WriteGather
		}

		private readonly SafeFileHandle _fileHandle;

		private ManualResetValueTaskSourceCore<long> _source;

		private Operation _operation;

		private ExecutionContext _context;

		private OSFileStreamStrategy _strategy;

		private long _fileOffset;

		private CancellationToken _cancellationToken;

		private ReadOnlyMemory<byte> _singleSegment;

		private IReadOnlyList<Memory<byte>> _readScatterBuffers;

		private IReadOnlyList<ReadOnlyMemory<byte>> _writeGatherBuffers;

		internal ThreadPoolValueTaskSource(SafeFileHandle fileHandle)
		{
			_fileHandle = fileHandle;
		}

		public ValueTaskSourceStatus GetStatus(short token)
		{
			return _source.GetStatus(token);
		}

		public void OnCompleted(Action<object> continuation, object state, short token, ValueTaskSourceOnCompletedFlags flags)
		{
			_source.OnCompleted(continuation, state, token, flags);
		}

		void IValueTaskSource.GetResult(short token)
		{
			GetResult(token);
		}

		int IValueTaskSource<int>.GetResult(short token)
		{
			return (int)GetResult(token);
		}

		public long GetResult(short token)
		{
			try
			{
				return _source.GetResult(token);
			}
			finally
			{
				_source.Reset();
				Volatile.Write(ref _fileHandle._reusableThreadPoolValueTaskSource, this);
			}
		}

		private void ExecuteInternal()
		{
			long num = 0L;
			Exception ex = null;
			try
			{
				if (_cancellationToken.IsCancellationRequested)
				{
					ex = new OperationCanceledException(_cancellationToken);
				}
				else
				{
					switch (_operation)
					{
					case Operation.Read:
					{
						Memory<byte> memory = MemoryMarshal.AsMemory(_singleSegment);
						num = RandomAccess.ReadAtOffset(_fileHandle, memory.Span, _fileOffset);
						break;
					}
					case Operation.Write:
						RandomAccess.WriteAtOffset(_fileHandle, _singleSegment.Span, _fileOffset);
						break;
					case Operation.ReadScatter:
						num = RandomAccess.ReadScatterAtOffset(_fileHandle, _readScatterBuffers, _fileOffset);
						break;
					case Operation.WriteGather:
						RandomAccess.WriteGatherAtOffset(_fileHandle, _writeGatherBuffers, _fileOffset);
						break;
					}
				}
			}
			catch (Exception ex2)
			{
				ex = ex2;
			}
			finally
			{
				if (_strategy != null)
				{
					if (ex != null)
					{
						_strategy.OnIncompleteOperation(_singleSegment.Length, 0);
					}
					else if (_operation == Operation.Read && num != _singleSegment.Length)
					{
						_strategy.OnIncompleteOperation(_singleSegment.Length, (int)num);
					}
				}
				_operation = Operation.None;
				_context = null;
				_strategy = null;
				_cancellationToken = default(CancellationToken);
				_singleSegment = default(ReadOnlyMemory<byte>);
				_readScatterBuffers = null;
				_writeGatherBuffers = null;
			}
			if (ex == null)
			{
				_source.SetResult(num);
			}
			else
			{
				_source.SetException(ex);
			}
		}

		void IThreadPoolWorkItem.Execute()
		{
			if (_context == null || _context.IsDefault)
			{
				ExecuteInternal();
				return;
			}
			ExecutionContext.RunForThreadPoolUnsafe(_context, delegate(ThreadPoolValueTaskSource x)
			{
				x.ExecuteInternal();
			}, in this);
		}

		private void QueueToThreadPool()
		{
			_context = ExecutionContext.Capture();
			ThreadPool.UnsafeQueueUserWorkItem(this, preferLocal: true);
		}

		public ValueTask<int> QueueRead(Memory<byte> buffer, long fileOffset, CancellationToken cancellationToken, OSFileStreamStrategy strategy)
		{
			_operation = Operation.Read;
			_singleSegment = buffer;
			_fileOffset = fileOffset;
			_cancellationToken = cancellationToken;
			_strategy = strategy;
			QueueToThreadPool();
			return new ValueTask<int>(this, _source.Version);
		}

		public ValueTask QueueWrite(ReadOnlyMemory<byte> buffer, long fileOffset, CancellationToken cancellationToken, OSFileStreamStrategy strategy)
		{
			_operation = Operation.Write;
			_singleSegment = buffer;
			_fileOffset = fileOffset;
			_cancellationToken = cancellationToken;
			_strategy = strategy;
			QueueToThreadPool();
			return new ValueTask(this, _source.Version);
		}

		public ValueTask<long> QueueReadScatter(IReadOnlyList<Memory<byte>> buffers, long fileOffset, CancellationToken cancellationToken)
		{
			_operation = Operation.ReadScatter;
			_readScatterBuffers = buffers;
			_fileOffset = fileOffset;
			_cancellationToken = cancellationToken;
			QueueToThreadPool();
			return new ValueTask<long>(this, _source.Version);
		}

		public ValueTask QueueWriteGather(IReadOnlyList<ReadOnlyMemory<byte>> buffers, long fileOffset, CancellationToken cancellationToken)
		{
			_operation = Operation.WriteGather;
			_writeGatherBuffers = buffers;
			_fileOffset = fileOffset;
			_cancellationToken = cancellationToken;
			QueueToThreadPool();
			return new ValueTask(this, _source.Version);
		}
	}

	private enum NullableBool
	{
		Undefined = 0,
		False = -1,
		True = 1
	}

	private string _path;

	private ThreadPoolValueTaskSource _reusableThreadPoolValueTaskSource;

	private volatile NullableBool _canSeek;

	private volatile NullableBool _supportsRandomAccess;

	private bool _deleteOnClose;

	private bool _isLocked;

	internal string? Path => _path;

	internal static bool DisableFileLocking { get; }

	public bool IsAsync { get; private set; }

	internal bool CanSeek
	{
		get
		{
			if (!base.IsClosed)
			{
				return GetCanSeek();
			}
			return false;
		}
	}

	internal bool SupportsRandomAccess
	{
		get
		{
			NullableBool nullableBool = _supportsRandomAccess;
			if (nullableBool == NullableBool.Undefined)
			{
				nullableBool = (_supportsRandomAccess = (GetCanSeek() ? NullableBool.True : NullableBool.False));
			}
			return nullableBool == NullableBool.True;
		}
		set
		{
			_supportsRandomAccess = (value ? NullableBool.True : NullableBool.False);
		}
	}

	internal ThreadPoolBoundHandle? ThreadPoolBinding => null;

	public override bool IsInvalid
	{
		get
		{
			long num = handle;
			if (num >= 0)
			{
				return num > int.MaxValue;
			}
			return true;
		}
	}

	public SafeFileHandle(nint preexistingHandle, bool ownsHandle)
		: base(ownsHandle)
	{
		SetHandle(preexistingHandle);
	}

	internal ThreadPoolValueTaskSource GetThreadPoolValueTaskSource()
	{
		return Interlocked.Exchange(ref _reusableThreadPoolValueTaskSource, null) ?? new ThreadPoolValueTaskSource(this);
	}

	public SafeFileHandle()
		: this(ownsHandle: true)
	{
	}

	private SafeFileHandle(bool ownsHandle)
		: base(ownsHandle)
	{
		SetHandle(new IntPtr(-1));
	}

	internal void EnsureThreadPoolBindingInitialized()
	{
	}

	internal bool TryGetCachedLength(out long cachedLength)
	{
		cachedLength = -1L;
		return false;
	}

	private static SafeFileHandle Open(string path, Interop.Sys.OpenFlags flags, int mode, bool failForSymlink, out bool wasSymlink, Func<Interop.ErrorInfo, Interop.Sys.OpenFlags, string, Exception> createOpenException)
	{
		wasSymlink = false;
		SafeFileHandle safeFileHandle = Interop.Sys.Open(path, flags, mode);
		safeFileHandle._path = path;
		if (safeFileHandle.IsInvalid)
		{
			Interop.ErrorInfo arg = Interop.Sys.GetLastErrorInfo();
			safeFileHandle.Dispose();
			if (failForSymlink && arg.Error == Interop.Error.ELOOP)
			{
				wasSymlink = true;
				return safeFileHandle;
			}
			Exception ex = createOpenException?.Invoke(arg, flags, path);
			if (ex != null)
			{
				throw ex;
			}
			if (arg.Error == Interop.Error.EISDIR)
			{
				arg = Interop.Error.EACCES.Info();
			}
			Interop.CheckIo(arg.Error, path);
		}
		return safeFileHandle;
	}

	protected override bool ReleaseHandle()
	{
		if (_deleteOnClose)
		{
			Interop.Sys.Unlink(_path);
		}
		if (_isLocked)
		{
			Interop.Sys.FLock(handle, Interop.Sys.LockOperations.LOCK_UN);
			_isLocked = false;
		}
		return Interop.Sys.Close(handle) == 0;
	}

	internal static SafeFileHandle OpenReadOnly(string fullPath, FileOptions options, out long fileLength, out UnixFileMode filePermissions)
	{
		bool wasSymlink;
		return Open(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read, options, 0L, UnixFileMode.OtherWrite | UnixFileMode.OtherRead | UnixFileMode.GroupWrite | UnixFileMode.GroupRead | UnixFileMode.UserWrite | UnixFileMode.UserRead, out fileLength, out filePermissions, failForSymlink: false, out wasSymlink);
	}

	internal static SafeFileHandle Open(string fullPath, FileMode mode, FileAccess access, FileShare share, FileOptions options, long preallocationSize, UnixFileMode? unixCreateMode = null, Func<Interop.ErrorInfo, Interop.Sys.OpenFlags, string, Exception> createOpenException = null)
	{
		long fileLength;
		UnixFileMode filePermissions;
		bool wasSymlink;
		return Open(fullPath, mode, access, share, options, preallocationSize, unixCreateMode ?? (UnixFileMode.OtherWrite | UnixFileMode.OtherRead | UnixFileMode.GroupWrite | UnixFileMode.GroupRead | UnixFileMode.UserWrite | UnixFileMode.UserRead), out fileLength, out filePermissions, failForSymlink: false, out wasSymlink, createOpenException);
	}

	private static SafeFileHandle Open(string fullPath, FileMode mode, FileAccess access, FileShare share, FileOptions options, long preallocationSize, UnixFileMode openPermissions, out long fileLength, out UnixFileMode filePermissions, bool failForSymlink, out bool wasSymlink, Func<Interop.ErrorInfo, Interop.Sys.OpenFlags, string, Exception> createOpenException = null)
	{
		Interop.Sys.OpenFlags flags = PreOpenConfigurationFromOptions(mode, access, share, options, failForSymlink);
		SafeFileHandle safeFileHandle = null;
		try
		{
			while (true)
			{
				safeFileHandle = Open(fullPath, flags, (int)openPermissions, failForSymlink, out wasSymlink, createOpenException);
				if (failForSymlink & wasSymlink)
				{
					fileLength = 0L;
					filePermissions = UnixFileMode.None;
					return safeFileHandle;
				}
				if (safeFileHandle.Init(fullPath, mode, access, share, options, preallocationSize, out fileLength, out filePermissions))
				{
					break;
				}
				safeFileHandle.Dispose();
			}
			return safeFileHandle;
		}
		catch (Exception)
		{
			safeFileHandle?.Dispose();
			throw;
		}
	}

	private static Interop.Sys.OpenFlags PreOpenConfigurationFromOptions(FileMode mode, FileAccess access, FileShare share, FileOptions options, bool failForSymlink)
	{
		Interop.Sys.OpenFlags openFlags = Interop.Sys.OpenFlags.O_RDONLY;
		if (failForSymlink)
		{
			openFlags |= Interop.Sys.OpenFlags.O_NOFOLLOW;
		}
		switch (mode)
		{
		case FileMode.Truncate:
			if (DisableFileLocking)
			{
				openFlags |= Interop.Sys.OpenFlags.O_TRUNC;
			}
			break;
		case FileMode.OpenOrCreate:
		case FileMode.Append:
			openFlags |= Interop.Sys.OpenFlags.O_CREAT;
			break;
		case FileMode.Create:
			openFlags |= Interop.Sys.OpenFlags.O_CREAT;
			if (DisableFileLocking)
			{
				openFlags |= Interop.Sys.OpenFlags.O_TRUNC;
			}
			break;
		case FileMode.CreateNew:
			openFlags |= Interop.Sys.OpenFlags.O_CREAT | Interop.Sys.OpenFlags.O_EXCL;
			break;
		}
		switch (access)
		{
		case FileAccess.Read:
			openFlags |= Interop.Sys.OpenFlags.O_RDONLY;
			break;
		case FileAccess.ReadWrite:
			openFlags |= Interop.Sys.OpenFlags.O_RDWR;
			break;
		case FileAccess.Write:
			openFlags |= Interop.Sys.OpenFlags.O_WRONLY;
			break;
		}
		if ((share & FileShare.Inheritable) == 0)
		{
			openFlags |= Interop.Sys.OpenFlags.O_CLOEXEC;
		}
		if ((options & FileOptions.WriteThrough) != FileOptions.None)
		{
			openFlags |= Interop.Sys.OpenFlags.O_SYNC;
		}
		return openFlags;
	}

	private bool Init(string path, FileMode mode, FileAccess access, FileShare share, FileOptions options, long preallocationSize, out long fileLength, out UnixFileMode filePermissions)
	{
		Interop.Sys.FileStatus status = default(Interop.Sys.FileStatus);
		bool statusHasValue = false;
		fileLength = -1L;
		filePermissions = UnixFileMode.None;
		if ((access & FileAccess.Write) == 0)
		{
			FStatCheckIO(path, ref status, ref statusHasValue);
			if ((status.Mode & 0xF000) == 16384)
			{
				throw Interop.GetExceptionForIoErrno(Interop.Error.EACCES.Info(), path);
			}
			if ((status.Mode & 0xF000) == 32768)
			{
				_canSeek = NullableBool.True;
			}
			fileLength = status.Size;
			filePermissions = (UnixFileMode)(status.Mode & 0x1FF);
		}
		IsAsync = (options & FileOptions.Asynchronous) != 0;
		Interop.Sys.LockOperations lockOperations = ((share != FileShare.None) ? Interop.Sys.LockOperations.LOCK_SH : Interop.Sys.LockOperations.LOCK_EX);
		if (CanLockTheFile(lockOperations, access) && !(_isLocked = Interop.Sys.FLock(this, lockOperations | Interop.Sys.LockOperations.LOCK_NB) >= 0))
		{
			Interop.ErrorInfo lastErrorInfo = Interop.Sys.GetLastErrorInfo();
			if (lastErrorInfo.Error == Interop.Error.EAGAIN)
			{
				throw Interop.GetExceptionForIoErrno(lastErrorInfo, path);
			}
		}
		if (_isLocked && (options & FileOptions.DeleteOnClose) != FileOptions.None && share == FileShare.None && mode == FileMode.OpenOrCreate)
		{
			FStatCheckIO(path, ref status, ref statusHasValue);
			if (Interop.Sys.Stat(path, out var output) < 0)
			{
				Interop.ErrorInfo lastErrorInfo2 = Interop.Sys.GetLastErrorInfo();
				if (lastErrorInfo2.Error == Interop.Error.ENOENT)
				{
					return false;
				}
				throw Interop.GetExceptionForIoErrno(lastErrorInfo2, path);
			}
			if (output.Ino != status.Ino || output.Dev != status.Dev)
			{
				return false;
			}
		}
		_deleteOnClose = (options & FileOptions.DeleteOnClose) != 0;
		Interop.Sys.FileAdvice fileAdvice = (((options & FileOptions.RandomAccess) != FileOptions.None) ? Interop.Sys.FileAdvice.POSIX_FADV_RANDOM : (((options & FileOptions.SequentialScan) != FileOptions.None) ? Interop.Sys.FileAdvice.POSIX_FADV_SEQUENTIAL : Interop.Sys.FileAdvice.POSIX_FADV_NORMAL));
		if (fileAdvice != Interop.Sys.FileAdvice.POSIX_FADV_NORMAL)
		{
			FileStreamHelpers.CheckFileCall(Interop.Sys.PosixFAdvise(this, 0L, 0L, fileAdvice), path, ignoreNotSupported: true);
		}
		if ((mode == FileMode.Create || mode == FileMode.Truncate) && !DisableFileLocking && Interop.Sys.FTruncate(this, 0L) < 0)
		{
			Interop.ErrorInfo lastErrorInfo3 = Interop.Sys.GetLastErrorInfo();
			if (lastErrorInfo3.Error != Interop.Error.EBADF && lastErrorInfo3.Error != Interop.Error.EINVAL)
			{
				throw Interop.GetExceptionForIoErrno(lastErrorInfo3, path);
			}
		}
		if (preallocationSize > 0 && Interop.Sys.FAllocate(this, 0L, preallocationSize) < 0)
		{
			Interop.ErrorInfo lastErrorInfo4 = Interop.Sys.GetLastErrorInfo();
			if (lastErrorInfo4.Error == Interop.Error.EFBIG || lastErrorInfo4.Error == Interop.Error.ENOSPC)
			{
				Dispose();
				Interop.Sys.Unlink(path);
				throw new IOException(SR.Format((lastErrorInfo4.Error == Interop.Error.EFBIG) ? "IO_FileTooLarge_Path_AllocationSize" : "IO_DiskFull_Path_AllocationSize", path, preallocationSize));
			}
		}
		return true;
	}

	private bool CanLockTheFile(Interop.Sys.LockOperations lockOperation, FileAccess access)
	{
		if (DisableFileLocking)
		{
			return false;
		}
		if (lockOperation == Interop.Sys.LockOperations.LOCK_EX)
		{
			return true;
		}
		if ((access & FileAccess.Write) == 0)
		{
			return true;
		}
		if (!Interop.Sys.TryGetFileSystemType(this, out var fileSystemType))
		{
			return false;
		}
		switch (fileSystemType)
		{
		case Interop.Sys.UnixFileSystemTypes.smb2:
		case Interop.Sys.UnixFileSystemTypes.cifs:
		case Interop.Sys.UnixFileSystemTypes.smb:
		case Interop.Sys.UnixFileSystemTypes.nfs:
			return false;
		default:
			return true;
		}
	}

	private void FStatCheckIO(string path, ref Interop.Sys.FileStatus status, ref bool statusHasValue)
	{
		if (!statusHasValue)
		{
			if (Interop.Sys.FStat(this, out status) != 0)
			{
				throw Interop.GetExceptionForIoErrno(Interop.Sys.GetLastErrorInfo(), path);
			}
			statusHasValue = true;
		}
	}

	private bool GetCanSeek()
	{
		NullableBool nullableBool = _canSeek;
		if (nullableBool == NullableBool.Undefined)
		{
			nullableBool = (_canSeek = ((Interop.Sys.LSeek(this, 0L, Interop.Sys.SeekWhence.SEEK_CUR) >= 0) ? NullableBool.True : NullableBool.False));
		}
		return nullableBool == NullableBool.True;
	}

	internal long GetFileLength()
	{
		FileStreamHelpers.CheckFileCall(Interop.Sys.FStat(this, out var output), Path);
		return output.Size;
	}

	static SafeFileHandle()
	{
		_ = 0;
		_ = 0;
		DisableFileLocking = AppContextConfigHelper.GetBooleanConfig("System.IO.DisableFileLocking", "DOTNET_SYSTEM_IO_DISABLEFILELOCKING");
	}
}
