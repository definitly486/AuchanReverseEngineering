using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Threading;
using Microsoft.Win32.SafeHandles;

internal static class Interop
{
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

		internal string GetErrorMessage()
		{
			return Sys.StrError(RawErrno);
		}

		public override string ToString()
		{
			return $"RawErrno: {RawErrno} Error: {Error} GetErrorMessage: {GetErrorMessage()}";
		}
	}

	internal static class Sys
	{
		internal static class Fcntl
		{
			[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FcntlSetFD", SetLastError = true)]
			[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
			internal static int SetFD(SafeHandle fd, int flags)
			{
				int result = 0;
				SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
				int lastSystemError;
				try
				{
					managedToUnmanagedIn.FromManaged(fd);
					nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
					Marshal.SetLastSystemError(0);
					result = __PInvoke(_fd_native, flags);
					lastSystemError = Marshal.GetLastSystemError();
				}
				finally
				{
					managedToUnmanagedIn.Free();
				}
				Marshal.SetLastPInvokeError(lastSystemError);
				return result;
				[DllImport("libSystem.Native", EntryPoint = "SystemNative_FcntlSetFD", ExactSpelling = true)]
				static extern int __PInvoke(nint __fd_native, int __flags_native);
			}
		}

		[Flags]
		internal enum MemoryMappedProtections
		{
			PROT_NONE = 0,
			PROT_READ = 1,
			PROT_WRITE = 2,
			PROT_EXEC = 4
		}

		[Flags]
		internal enum MemoryMappedFlags
		{
			MAP_SHARED = 1,
			MAP_PRIVATE = 2,
			MAP_ANONYMOUS = 0x10
		}

		[Flags]
		internal enum MemoryMappedSyncFlags
		{
			MS_ASYNC = 1,
			MS_SYNC = 2,
			MS_INVALIDATE = 0x10
		}

		[Flags]
		internal enum OpenFlags
		{
			O_RDONLY = 0,
			O_WRONLY = 1,
			O_RDWR = 2,
			O_CLOEXEC = 0x10,
			O_CREAT = 0x20,
			O_EXCL = 0x40,
			O_TRUNC = 0x80,
			O_SYNC = 0x100,
			O_NOFOLLOW = 0x200
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

		internal enum SysConfName
		{
			_SC_CLK_TCK = 1,
			_SC_PAGESIZE
		}

		internal enum MemoryAdvice
		{
			MADV_DONTFORK = 1
		}

		private static volatile sbyte s_memfdSupported;

		internal static bool IsMemfdSupported
		{
			get
			{
				sbyte b = s_memfdSupported;
				if (b == 0)
				{
					Interlocked.CompareExchange(ref s_memfdSupported, (sbyte)((MemfdSupportedImpl() == 1) ? 1 : (-1)), 0);
					b = s_memfdSupported;
				}
				return b > 0;
			}
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

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_MMap", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static nint MMap(nint addr, ulong len, MemoryMappedProtections prot, MemoryMappedFlags flags, SafeFileHandle fd, long offset)
		{
			nint num = 0;
			nint result = 0;
			SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				num = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(addr, len, prot, flags, num, offset);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_MMap", ExactSpelling = true)]
			static extern nint __PInvoke(nint __addr_native, ulong __len_native, MemoryMappedProtections __prot_native, MemoryMappedFlags __flags_native, nint __fd_native, long __offset_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_MUnmap", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int MUnmap(nint addr, ulong len)
		{
			Marshal.SetLastSystemError(0);
			int result = __PInvoke(addr, len);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_MUnmap", ExactSpelling = true)]
			static extern int __PInvoke(nint __addr_native, ulong __len_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_MSync", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int MSync(nint addr, ulong len, MemoryMappedSyncFlags flags)
		{
			Marshal.SetLastSystemError(0);
			int result = __PInvoke(addr, len, flags);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_MSync", ExactSpelling = true)]
			static extern int __PInvoke(nint __addr_native, ulong __len_native, MemoryMappedSyncFlags __flags_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FStat", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int FStat(SafeHandle fd, out FileStatus output)
		{
			output = default(FileStatus);
			int result = 0;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				fixed (FileStatus* _output_native = &output)
				{
					nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
					Marshal.SetLastSystemError(0);
					result = __PInvoke(_fd_native, _output_native);
					lastSystemError = Marshal.GetLastSystemError();
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_FStat", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __fd_native, FileStatus* __output_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SysConf", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static long SysConf(SysConfName name)
		{
			Marshal.SetLastSystemError(0);
			long result = __PInvoke(name);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_SysConf", ExactSpelling = true)]
			static extern long __PInvoke(SysConfName __name_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FTruncate", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int FTruncate(SafeFileHandle fd, long length)
		{
			int result = 0;
			SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, length);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_FTruncate", ExactSpelling = true)]
			static extern int __PInvoke(nint __fd_native, long __length_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_MAdvise", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int MAdvise(nint addr, ulong length, MemoryAdvice advice)
		{
			Marshal.SetLastSystemError(0);
			int result = __PInvoke(addr, length, advice);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_MAdvise", ExactSpelling = true)]
			static extern int __PInvoke(nint __addr_native, ulong __length_native, MemoryAdvice __advice_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_ShmOpen", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static SafeFileHandle ShmOpen(string name, OpenFlags flags, int mode)
		{
			bool flag = false;
			SafeFileHandle result = null;
			nint num = 0;
			SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedOut();
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(name, buffer);
				byte* _name_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				num = __PInvoke(_name_native, flags, mode);
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
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_ShmOpen", ExactSpelling = true)]
			static extern unsafe nint __PInvoke(byte* __name_native, OpenFlags __flags_native, int __mode_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_ShmUnlink", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int ShmUnlink(string name)
		{
			int result = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(name, buffer);
				byte* _name_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_name_native);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_ShmUnlink", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __name_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_MemfdCreate", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static SafeFileHandle MemfdCreate(string name, int isReadonly)
		{
			bool flag = false;
			SafeFileHandle result = null;
			nint num = 0;
			SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedOut();
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(name, buffer);
				byte* _name_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				num = __PInvoke(_name_native, isReadonly);
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
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_MemfdCreate", ExactSpelling = true)]
			static extern unsafe nint __PInvoke(byte* __name_native, int __isReadonly_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_IsMemfdSupported", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private static int MemfdSupportedImpl()
		{
			Marshal.SetLastSystemError(0);
			int result = __PInvoke();
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_IsMemfdSupported", ExactSpelling = true)]
			static extern int __PInvoke();
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Unlink", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int Unlink(string pathname)
		{
			int result = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(pathname, buffer);
				byte* _pathname_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_pathname_native);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Unlink", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __pathname_native);
		}
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
