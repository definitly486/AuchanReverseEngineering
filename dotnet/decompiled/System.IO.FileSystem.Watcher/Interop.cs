using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.Win32.SafeHandles;

internal static class Interop
{
	internal static class Sys
	{
		[Flags]
		internal enum NotifyEvents
		{
			IN_ACCESS = 1,
			IN_MODIFY = 2,
			IN_ATTRIB = 4,
			IN_MOVED_FROM = 0x40,
			IN_MOVED_TO = 0x80,
			IN_CREATE = 0x100,
			IN_DELETE = 0x200,
			IN_Q_OVERFLOW = 0x4000,
			IN_IGNORED = 0x8000,
			IN_ONLYDIR = 0x1000000,
			IN_DONT_FOLLOW = 0x2000000,
			IN_EXCL_UNLINK = 0x4000000,
			IN_ISDIR = 0x40000000
		}

		internal struct FileStatus
		{
			internal FileStatusFlags Flags;

			internal int Mode;

			internal uint Uid;

			internal uint Gid;

			internal long Size;

			internal long ATime;

			internal long ATimeNsec;

			internal long MTime;

			internal long MTimeNsec;

			internal long CTime;

			internal long CTimeNsec;

			internal long BirthTime;

			internal long BirthTimeNsec;

			internal long Dev;

			internal long RDev;

			internal long Ino;

			internal uint UserFlags;
		}

		[Flags]
		internal enum FileStatusFlags
		{
			None = 0,
			HasBirthTime = 1
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Read", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int Read(SafeHandle fd, byte* buffer, int count)
		{
			int result = 0;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, buffer, count);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Read", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __fd_native, byte* __buffer_native, int __count_native);
		}

		internal static Error GetLastError()
		{
			return ConvertErrorPlatformToPal(Marshal.GetLastPInvokeError());
		}

		internal static ErrorInfo GetLastErrorInfo()
		{
			return new ErrorInfo(Marshal.GetLastPInvokeError());
		}

		internal unsafe static string StrError(int platformErrno)
		{
			byte* ptr = stackalloc byte[1024];
			byte* ptr2 = StrErrorR(platformErrno, ptr, 1024);
			if (ptr2 == null)
			{
				ptr2 = ptr;
			}
			return Marshal.PtrToStringUTF8((nint)ptr2);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_ConvertErrorPlatformToPal", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_ConvertErrorPlatformToPal")]
		[SuppressGCTransition]
		internal static extern Error ConvertErrorPlatformToPal(int platformErrno);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_ConvertErrorPalToPlatform", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_ConvertErrorPalToPlatform")]
		[SuppressGCTransition]
		internal static extern int ConvertErrorPalToPlatform(Error error);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_StrErrorR", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_StrErrorR")]
		private unsafe static extern byte* StrErrorR(int platformErrno, byte* buffer, int bufferSize);

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_INotifyInit", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static SafeFileHandle INotifyInit()
		{
			bool flag = false;
			SafeFileHandle result = null;
			nint num = 0;
			SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedOut();
			int lastSystemError;
			try
			{
				Marshal.SetLastSystemError(0);
				num = __PInvoke();
				lastSystemError = Marshal.GetLastSystemError();
				flag = true;
				managedToUnmanagedOut.FromUnmanaged(num);
				result = managedToUnmanagedOut.ToManaged();
			}
			finally
			{
				if (flag)
				{
					managedToUnmanagedOut.Free();
				}
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_INotifyInit", ExactSpelling = true)]
			static extern nint __PInvoke();
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_INotifyAddWatch", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int INotifyAddWatch(SafeFileHandle fd, string pathName, uint mask)
		{
			byte* ptr = default(byte*);
			int result = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn managedToUnmanagedIn2 = default(SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(pathName, buffer);
				managedToUnmanagedIn2.FromManaged(fd);
				ptr = managedToUnmanagedIn.ToUnmanaged();
				nint _fd_native = managedToUnmanagedIn2.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, ptr, mask);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
				managedToUnmanagedIn2.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_INotifyAddWatch", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __fd_native, byte* __pathName_native, uint __mask_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_INotifyRemoveWatch", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private static int INotifyRemoveWatch_private(SafeFileHandle fd, int wd)
		{
			int result = 0;
			SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, wd);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_INotifyRemoveWatch", ExactSpelling = true)]
			static extern int __PInvoke(nint __fd_native, int __wd_native);
		}

		internal static int INotifyRemoveWatch(SafeFileHandle fd, int wd)
		{
			int num = INotifyRemoveWatch_private(fd, wd);
			if (num < 0 && GetLastError() == Error.EINVAL)
			{
				num = 0;
			}
			return num;
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_Poll", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Poll")]
		internal unsafe static extern Error Poll(PollEvent* pollEvents, uint eventCount, int timeout, uint* triggered);

		internal unsafe static Error Poll(SafeHandle fd, PollEvents events, int timeout, out PollEvents triggered)
		{
			bool success = false;
			try
			{
				fd.DangerousAddRef(ref success);
				PollEvent pollEvent = new PollEvent
				{
					FileDescriptor = ((IntPtr)fd.DangerousGetHandle()).ToInt32(),
					Events = events
				};
				Unsafe.SkipInit(out uint num);
				Error result = Poll(&pollEvent, 1u, timeout, &num);
				triggered = pollEvent.TriggeredEvents;
				return result;
			}
			finally
			{
				if (success)
				{
					fd.DangerousRelease();
				}
			}
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_LStat", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int LStat(string path, out FileStatus output)
		{
			output = default(FileStatus);
			int result = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(path, buffer);
				fixed (FileStatus* _output_native = &output)
				{
					byte* _path_native = managedToUnmanagedIn.ToUnmanaged();
					Marshal.SetLastSystemError(0);
					result = __PInvoke(_path_native, _output_native);
					lastSystemError = Marshal.GetLastSystemError();
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_LStat", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __path_native, FileStatus* __output_native);
		}
	}

	internal enum Error
	{
		SUCCESS = 0,
		E2BIG = 65537,
		EACCES = 65538,
		EADDRINUSE = 65539,
		EADDRNOTAVAIL = 65540,
		EAFNOSUPPORT = 65541,
		EAGAIN = 65542,
		EALREADY = 65543,
		EBADF = 65544,
		EBADMSG = 65545,
		EBUSY = 65546,
		ECANCELED = 65547,
		ECHILD = 65548,
		ECONNABORTED = 65549,
		ECONNREFUSED = 65550,
		ECONNRESET = 65551,
		EDEADLK = 65552,
		EDESTADDRREQ = 65553,
		EDOM = 65554,
		EDQUOT = 65555,
		EEXIST = 65556,
		EFAULT = 65557,
		EFBIG = 65558,
		EHOSTUNREACH = 65559,
		EIDRM = 65560,
		EILSEQ = 65561,
		EINPROGRESS = 65562,
		EINTR = 65563,
		EINVAL = 65564,
		EIO = 65565,
		EISCONN = 65566,
		EISDIR = 65567,
		ELOOP = 65568,
		EMFILE = 65569,
		EMLINK = 65570,
		EMSGSIZE = 65571,
		EMULTIHOP = 65572,
		ENAMETOOLONG = 65573,
		ENETDOWN = 65574,
		ENETRESET = 65575,
		ENETUNREACH = 65576,
		ENFILE = 65577,
		ENOBUFS = 65578,
		ENODEV = 65580,
		ENOENT = 65581,
		ENOEXEC = 65582,
		ENOLCK = 65583,
		ENOLINK = 65584,
		ENOMEM = 65585,
		ENOMSG = 65586,
		ENOPROTOOPT = 65587,
		ENOSPC = 65588,
		ENOSYS = 65591,
		ENOTCONN = 65592,
		ENOTDIR = 65593,
		ENOTEMPTY = 65594,
		ENOTRECOVERABLE = 65595,
		ENOTSOCK = 65596,
		ENOTSUP = 65597,
		ENOTTY = 65598,
		ENXIO = 65599,
		EOVERFLOW = 65600,
		EOWNERDEAD = 65601,
		EPERM = 65602,
		EPIPE = 65603,
		EPROTO = 65604,
		EPROTONOSUPPORT = 65605,
		EPROTOTYPE = 65606,
		ERANGE = 65607,
		EROFS = 65608,
		ESPIPE = 65609,
		ESRCH = 65610,
		ESTALE = 65611,
		ETIMEDOUT = 65613,
		ETXTBSY = 65614,
		EXDEV = 65615,
		ESOCKTNOSUPPORT = 65630,
		EPFNOSUPPORT = 65632,
		ESHUTDOWN = 65644,
		EHOSTDOWN = 65648,
		ENODATA = 65649,
		EHOSTNOTFOUND = 131073,
		ESOCKETERROR = 131074,
		EOPNOTSUPP = 65597,
		EWOULDBLOCK = 65542
	}

	internal struct ErrorInfo
	{
		private readonly Error _error;

		private int _rawErrno;

		internal Error Error => _error;

		internal int RawErrno
		{
			get
			{
				if (_rawErrno != -1)
				{
					return _rawErrno;
				}
				return _rawErrno = Sys.ConvertErrorPalToPlatform(_error);
			}
		}

		internal ErrorInfo(int errno)
		{
			_error = Sys.ConvertErrorPlatformToPal(errno);
			_rawErrno = errno;
		}

		internal ErrorInfo(Error error)
		{
			_error = error;
			_rawErrno = -1;
		}

		internal string GetErrorMessage()
		{
			return Sys.StrError(RawErrno);
		}

		public override string ToString()
		{
			return $"RawErrno: {RawErrno} Error: {Error} GetErrorMessage: {GetErrorMessage()}";
		}
	}

	[Flags]
	internal enum PollEvents : short
	{
		POLLNONE = 0,
		POLLIN = 1,
		POLLPRI = 2,
		POLLOUT = 4,
		POLLERR = 8,
		POLLHUP = 0x10,
		POLLNVAL = 0x20
	}

	internal struct PollEvent
	{
		internal int FileDescriptor;

		internal PollEvents Events;

		internal PollEvents TriggeredEvents;
	}

	private static void ThrowExceptionForIoErrno(ErrorInfo errorInfo, string path, bool isDirError)
	{
		throw GetExceptionForIoErrno(errorInfo, path, isDirError);
	}

	internal static long CheckIo(long result, string path = null, bool isDirError = false)
	{
		if (result < 0)
		{
			ThrowExceptionForIoErrno(Sys.GetLastErrorInfo(), path, isDirError);
		}
		return result;
	}

	internal static int CheckIo(int result, string path = null, bool isDirError = false)
	{
		CheckIo((long)result, path, isDirError);
		return result;
	}

	internal static Exception GetExceptionForIoErrno(ErrorInfo errorInfo, string path = null, bool isDirError = false)
	{
		Error error = errorInfo.Error;
		if (error <= Error.EEXIST)
		{
			if (error <= Error.EAGAIN)
			{
				if (error == Error.EACCES)
				{
					goto IL_00f0;
				}
				if (error == Error.EAGAIN)
				{
					if (string.IsNullOrEmpty(path))
					{
						return new IOException("IO_SharingViolation_NoFileName", errorInfo.RawErrno);
					}
					return new IOException(System.SR.Format("IO_SharingViolation_File", path), errorInfo.RawErrno);
				}
			}
			else
			{
				if (error == Error.EBADF)
				{
					goto IL_00f0;
				}
				switch (error)
				{
				case Error.ECANCELED:
					return new OperationCanceledException();
				case Error.EEXIST:
					if (!string.IsNullOrEmpty(path))
					{
						return new IOException(System.SR.Format("IO_FileExists_Name", path), errorInfo.RawErrno);
					}
					break;
				}
			}
		}
		else
		{
			if (error > Error.ENAMETOOLONG)
			{
				if (error != Error.ENOENT)
				{
					if (error != Error.ENOTDIR)
					{
						if (error == Error.EPERM)
						{
							goto IL_00f0;
						}
						goto IL_01aa;
					}
				}
				else if (!isDirError && (path == null || ParentDirectoryExists(path)))
				{
					if (string.IsNullOrEmpty(path))
					{
						return new FileNotFoundException("IO_FileNotFound");
					}
					return new FileNotFoundException(System.SR.Format("IO_FileNotFound_FileName", path), path);
				}
				if (string.IsNullOrEmpty(path))
				{
					return new DirectoryNotFoundException("IO_PathNotFound_NoPathName");
				}
				return new DirectoryNotFoundException(System.SR.Format("IO_PathNotFound_Path", path));
			}
			switch (error)
			{
			case Error.ENAMETOOLONG:
				if (string.IsNullOrEmpty(path))
				{
					return new PathTooLongException("IO_PathTooLong");
				}
				return new PathTooLongException(System.SR.Format("IO_PathTooLong_Path", path));
			case Error.EFBIG:
				return new ArgumentOutOfRangeException("value", "ArgumentOutOfRange_FileLengthTooBig");
			}
		}
		goto IL_01aa;
		IL_00f0:
		Exception iOException = GetIOException(errorInfo);
		if (string.IsNullOrEmpty(path))
		{
			return new UnauthorizedAccessException("UnauthorizedAccess_IODenied_NoPathName", iOException);
		}
		return new UnauthorizedAccessException(System.SR.Format("UnauthorizedAccess_IODenied_Path", path), iOException);
		IL_01aa:
		return GetIOException(errorInfo, path);
		static bool ParentDirectoryExists(string fullPath)
		{
			return Directory.Exists(Path.GetDirectoryName(Path.TrimEndingDirectorySeparator(fullPath)));
		}
	}

	internal static Exception GetIOException(ErrorInfo errorInfo, string path = null)
	{
		string errorMessage = errorInfo.GetErrorMessage();
		return new IOException(string.IsNullOrEmpty(path) ? errorMessage : (errorMessage + " : '" + path + "'"), errorInfo.RawErrno);
	}
}
