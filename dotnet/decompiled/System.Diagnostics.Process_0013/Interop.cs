using System;
using System.Buffers;
using System.Buffers.Text;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

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

	internal static class Sys
	{
		internal enum SysConfName
		{
			_SC_CLK_TCK = 1,
			_SC_PAGESIZE
		}

		internal enum PriorityWhich
		{
			PRIO_PROCESS,
			PRIO_PGRP,
			PRIO_USER
		}

		internal enum Signals
		{
			None = 0,
			SIGKILL = 9,
			SIGSTOP = 19
		}

		internal static Error GetLastError()
		{
			return ConvertErrorPlatformToPal(Marshal.GetLastPInvokeError());
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_ConvertErrorPlatformToPal", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_ConvertErrorPlatformToPal")]
		[SuppressGCTransition]
		internal static extern Error ConvertErrorPlatformToPal(int platformErrno);

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetHostName", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int GetHostName(byte* name, int nameLength)
		{
			Marshal.SetLastSystemError(0);
			int result = __PInvoke(name, nameLength);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetHostName", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __name_native, int __nameLength_native);
		}

		internal unsafe static string GetHostName()
		{
			if (false)
			{
			}
			byte* num = stackalloc byte[256];
			int hostName = GetHostName(num, 256);
			if (hostName != 0)
			{
				throw new InvalidOperationException($"{"GetHostName"}: {hostName}");
			}
			num[255] = 0;
			return Marshal.PtrToStringUTF8((nint)num);
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

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetPriority", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private static int GetPriority(PriorityWhich which, int who)
		{
			Marshal.SetLastSystemError(0);
			int result = __PInvoke(which, who);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetPriority", ExactSpelling = true)]
			static extern int __PInvoke(PriorityWhich __which_native, int __who_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SetPriority", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int SetPriority(PriorityWhich which, int who, int nice)
		{
			Marshal.SetLastSystemError(0);
			int result = __PInvoke(which, who, nice);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_SetPriority", ExactSpelling = true)]
			static extern int __PInvoke(PriorityWhich __which_native, int __who_native, int __nice_native);
		}

		internal static int GetPriority(PriorityWhich which, int who, out int priority)
		{
			priority = GetPriority(which, who);
			return Marshal.GetLastPInvokeError();
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Kill", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int Kill(int pid, Signals signal)
		{
			Marshal.SetLastSystemError(0);
			int result = __PInvoke(pid, signal);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Kill", ExactSpelling = true)]
			static extern int __PInvoke(int __pid_native, Signals __signal_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_ReadLink", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int ReadLink(ref byte path, ref byte buffer, int bufferSize)
		{
			int result;
			int lastSystemError;
			fixed (byte* _buffer_native = &buffer)
			{
				fixed (byte* _path_native = &path)
				{
					Marshal.SetLastSystemError(0);
					result = __PInvoke(_path_native, _buffer_native, bufferSize);
					lastSystemError = Marshal.GetLastSystemError();
				}
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_ReadLink", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __path_native, byte* __buffer_native, int __bufferSize_native);
		}

		internal static string ReadLink(ReadOnlySpan<char> path)
		{
			Span<byte> initialBuffer = stackalloc byte[256];
			using System.Text.ValueUtf8Converter valueUtf8Converter = new System.Text.ValueUtf8Converter(initialBuffer);
			Span<byte> span = stackalloc byte[256];
			byte[] array = null;
			ref byte reference = ref MemoryMarshal.GetReference(valueUtf8Converter.ConvertAndTerminateString(path));
			while (true)
			{
				int num = 0;
				try
				{
					int num2 = ReadLink(ref reference, ref MemoryMarshal.GetReference(span), span.Length);
					if (num2 < 0)
					{
						num = Marshal.GetLastPInvokeError();
						return null;
					}
					if (num2 < span.Length)
					{
						return Encoding.UTF8.GetString(span.Slice(0, num2));
					}
				}
				finally
				{
					if (array != null)
					{
						ArrayPool<byte>.Shared.Return(array);
					}
					if (num > 0)
					{
						Marshal.SetLastPInvokeError(num);
					}
				}
				array = ArrayPool<byte>.Shared.Rent(span.Length * 2);
				span = array;
			}
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetBootTimeTicks", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetBootTimeTicks")]
		[SuppressGCTransition]
		internal static extern long GetBootTimeTicks();

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SchedSetAffinity", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int SchedSetAffinity(int pid, ref nint mask)
		{
			int result;
			int lastSystemError;
			fixed (nint* _mask_native = &mask)
			{
				Marshal.SetLastSystemError(0);
				result = __PInvoke(pid, _mask_native);
				lastSystemError = Marshal.GetLastSystemError();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_SchedSetAffinity", ExactSpelling = true)]
			static extern unsafe int __PInvoke(int __pid_native, nint* __mask_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SchedGetAffinity", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int SchedGetAffinity(int pid, out nint mask)
		{
			mask = 0;
			int result;
			int lastSystemError;
			fixed (nint* _mask_native = &mask)
			{
				Marshal.SetLastSystemError(0);
				result = __PInvoke(pid, _mask_native);
				lastSystemError = Marshal.GetLastSystemError();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_SchedGetAffinity", ExactSpelling = true)]
			static extern unsafe int __PInvoke(int __pid_native, nint* __mask_native);
		}
	}

	internal static class cgroups
	{
		internal enum CGroupVersion
		{
			None,
			CGroup1,
			CGroup2
		}

		internal static readonly CGroupVersion s_cgroupVersion = FindCGroupVersion();

		internal static readonly string s_cgroupMemoryHierarchyMountPath = FindCGroupMemoryHierarchyMountPath(s_cgroupVersion);

		internal static readonly string s_cgroupMemoryPath = FindCGroupMemoryPath(s_cgroupVersion);

		public static bool TryGetMemoryLimit(out ulong limit)
		{
			if (s_cgroupVersion == CGroupVersion.CGroup1)
			{
				return TryGetMemoryLimitV1(out limit);
			}
			if (s_cgroupVersion == CGroupVersion.CGroup2)
			{
				return TryGetMemoryLimitV2(out limit);
			}
			limit = 0uL;
			return false;
		}

		internal static bool TryGetMemoryStatField(string fieldName, out ulong val)
		{
			string text = s_cgroupMemoryPath;
			if (text != null)
			{
				try
				{
					fieldName += " ";
					foreach (string item in File.ReadLines(text + "/memory.stat"))
					{
						if (item.StartsWith(fieldName))
						{
							return ulong.TryParse(item.AsSpan(fieldName.Length), out val);
						}
					}
				}
				catch (Exception)
				{
				}
			}
			val = 0uL;
			return false;
		}

		internal static bool TryGetMemoryLimitV1(out ulong limit)
		{
			string text = s_cgroupMemoryPath;
			if (text != null)
			{
				if (TryReadMemoryValueFromFile(text + "/memory.use_hierarchy", out var result) && result != 0L)
				{
					return TryGetMemoryStatField("hierarchical_memory_limit", out limit);
				}
				if (text != null && TryReadMemoryValueFromFile(text + "/memory.limit_in_bytes", out limit))
				{
					return true;
				}
			}
			limit = 0uL;
			return false;
		}

		internal static bool TryGetMemoryLimitV2(out ulong limit)
		{
			bool result = false;
			ulong num = ulong.MaxValue;
			string directoryName = s_cgroupMemoryPath;
			string text = s_cgroupMemoryHierarchyMountPath;
			if (directoryName != null && text != null)
			{
				do
				{
					if (TryReadMemoryValueFromFile(directoryName + "/memory.max", out var result2))
					{
						result = true;
						if (result2 < num)
						{
							num = result2;
						}
					}
					directoryName = Path.GetDirectoryName(directoryName);
				}
				while (directoryName.Length != text.Length);
			}
			limit = num;
			return result;
		}

		internal static bool TryReadMemoryValueFromFile(string path, out ulong result)
		{
			if (File.Exists(path))
			{
				try
				{
					byte[] array = File.ReadAllBytes(path);
					if (Utf8Parser.TryParse((ReadOnlySpan<byte>)array, out ulong value, out int bytesConsumed, '\0'))
					{
						ulong num = 1uL;
						if (bytesConsumed < array.Length)
						{
							switch (array[bytesConsumed])
							{
							case 75:
							case 107:
								num = 1024uL;
								break;
							case 77:
							case 109:
								num = 1048576uL;
								break;
							case 71:
							case 103:
								num = 1073741824uL;
								break;
							}
						}
						result = checked(value * num);
						return true;
					}
				}
				catch (Exception)
				{
				}
			}
			result = 0uL;
			return false;
		}

		private static CGroupVersion FindCGroupVersion()
		{
			CGroupVersion result = CGroupVersion.None;
			if (procfs.GetFileSystemTypeForRealPath("/sys/fs/cgroup", out var format) == Error.SUCCESS)
			{
				result = ((!(format == "cgroup2")) ? CGroupVersion.CGroup1 : CGroupVersion.CGroup2);
			}
			return result;
		}

		private static string FindCGroupMemoryHierarchyMountPath(CGroupVersion cgroupVersion)
		{
			if (TryFindHierarchyMount(cgroupVersion, "memory", out var _, out var path))
			{
				return path;
			}
			return null;
		}

		private static string FindCGroupMemoryPath(CGroupVersion cgroupVersion)
		{
			return FindCGroupPath(cgroupVersion, "memory");
		}

		private static string FindCGroupPath(CGroupVersion cgroupVersion, string subsystem)
		{
			if (cgroupVersion == CGroupVersion.None)
			{
				return null;
			}
			if (TryFindHierarchyMount(cgroupVersion, subsystem, out var root, out var path) && TryFindCGroupPathForSubsystem(cgroupVersion, subsystem, out var path2))
			{
				return FindCGroupPath(root, path, path2);
			}
			return null;
		}

		internal static string FindCGroupPath(string hierarchyRoot, string hierarchyMount, string cgroupPathRelativeToMount)
		{
			int num = hierarchyRoot.Length;
			if (num == 1 || !cgroupPathRelativeToMount.StartsWith(hierarchyRoot, StringComparison.Ordinal))
			{
				num = 0;
			}
			return string.Concat(hierarchyMount.AsSpan(), cgroupPathRelativeToMount.AsSpan(num));
		}

		private static bool TryFindHierarchyMount(CGroupVersion cgroupVersion, string subsystem, [NotNullWhen(true)] out string root, [NotNullWhen(true)] out string path)
		{
			return TryFindHierarchyMount(cgroupVersion, "/proc/self/mountinfo", subsystem, out root, out path);
		}

		internal static bool TryFindHierarchyMount(CGroupVersion cgroupVersion, string mountInfoFilePath, string subsystem, [NotNullWhen(true)] out string root, [NotNullWhen(true)] out string path)
		{
			if (File.Exists(mountInfoFilePath))
			{
				try
				{
					using StreamReader streamReader = new StreamReader(mountInfoFilePath);
					string text;
					while ((text = streamReader.ReadLine()) != null)
					{
						if (!procfs.TryParseMountInfoLine(text.AsSpan(), out var result))
						{
							continue;
						}
						switch (cgroupVersion)
						{
						case CGroupVersion.CGroup1:
							if (!result.FileSystemType.SequenceEqual("cgroup".AsSpan()) || result.SuperOptions.IndexOf(subsystem.AsSpan()) < 0)
							{
								continue;
							}
							break;
						case CGroupVersion.CGroup2:
							if (!result.FileSystemType.SequenceEqual("cgroup2".AsSpan()))
							{
								continue;
							}
							break;
						}
						root = result.Root.ToString();
						path = result.MountPoint.ToString();
						return true;
					}
				}
				catch (Exception)
				{
				}
			}
			root = null;
			path = null;
			return false;
		}

		private static bool TryFindCGroupPathForSubsystem(CGroupVersion cgroupVersion, string subsystem, [NotNullWhen(true)] out string path)
		{
			return TryFindCGroupPathForSubsystem(cgroupVersion, "/proc/self/cgroup", subsystem, out path);
		}

		internal static bool TryFindCGroupPathForSubsystem(CGroupVersion cgroupVersion, string procCGroupFilePath, string subsystem, [NotNullWhen(true)] out string path)
		{
			if (File.Exists(procCGroupFilePath))
			{
				try
				{
					using StreamReader streamReader = new StreamReader(procCGroupFilePath);
					Span<Range> destination = stackalloc Range[4];
					string text;
					while ((text = streamReader.ReadLine()) != null)
					{
						ReadOnlySpan<char> source = text.AsSpan();
						if (source.Split(destination, ':') != 3)
						{
							continue;
						}
						switch (cgroupVersion)
						{
						case CGroupVersion.CGroup1:
						{
							Range range = destination[1];
							if (Array.IndexOf(text[range.Start..range.End].Split(','), subsystem) >= 0)
							{
								range = destination[2];
								path = text[range.Start..range.End];
								return true;
							}
							break;
						}
						case CGroupVersion.CGroup2:
						{
							Range range = destination[0];
							if (source[range.Start..range.End].SequenceEqual("0".AsSpan()))
							{
								range = destination[1];
								if (source[range.Start..range.End].IsEmpty)
								{
									range = destination[2];
									path = text[range.Start..range.End];
									return true;
								}
							}
							break;
						}
						}
					}
				}
				catch (Exception)
				{
				}
			}
			path = null;
			return false;
		}
	}

	internal static class procfs
	{
		internal ref struct ParsedMount
		{
			public required ReadOnlySpan<char> Root { get; init; }

			public required ReadOnlySpan<char> MountPoint { get; init; }

			public required ReadOnlySpan<char> FileSystemType { get; init; }

			public required ReadOnlySpan<char> SuperOptions { get; init; }
		}

		internal struct ParsedStat
		{
			internal int pid;

			internal string comm;

			internal char state;

			internal int ppid;

			internal int session;

			internal ulong utime;

			internal ulong stime;

			internal long nice;

			internal ulong starttime;

			internal ulong vsize;

			internal long rss;

			internal ulong rsslim;
		}

		internal enum ProcPid
		{
			Invalid = -1,
			Self
		}

		internal struct ParsedStatus
		{
			internal ulong VmHWM;

			internal ulong VmRSS;

			internal ulong VmData;

			internal ulong VmSwap;

			internal ulong VmSize;

			internal ulong VmPeak;
		}

		internal static Error GetFileSystemTypeForRealPath(string path, out string format)
		{
			format = "";
			if (File.Exists("/proc/self/mountinfo"))
			{
				try
				{
					ReadOnlySpan<char> readOnlySpan = default(ReadOnlySpan<char>);
					int num = 0;
					using StreamReader streamReader = new StreamReader("/proc/self/mountinfo");
					string text;
					while ((text = streamReader.ReadLine()) != null)
					{
						if (TryParseMountInfoLine(text.AsSpan(), out var result) && result.MountPoint.Length >= num && path.AsSpan().StartsWith(result.MountPoint))
						{
							if (result.MountPoint.Length == path.Length)
							{
								readOnlySpan = result.FileSystemType;
								break;
							}
							if (result.MountPoint.Length <= 1 || path[result.MountPoint.Length] == '/')
							{
								num = result.MountPoint.Length;
								readOnlySpan = result.FileSystemType;
							}
						}
					}
					if (readOnlySpan.Length > 0)
					{
						format = readOnlySpan.ToString();
						return Error.SUCCESS;
					}
					return Error.ENOENT;
				}
				catch (Exception)
				{
				}
			}
			return Error.ENOTSUP;
		}

		internal static bool TryParseMountInfoLine(ReadOnlySpan<char> line, out ParsedMount result)
		{
			result = default(ParsedMount);
			MemoryExtensions.SpanSplitEnumerator<char> spanSplitEnumerator = line.Split(' ');
			if (!spanSplitEnumerator.MoveNext() || !spanSplitEnumerator.MoveNext() || !spanSplitEnumerator.MoveNext())
			{
				return false;
			}
			if (!spanSplitEnumerator.MoveNext())
			{
				return false;
			}
			Range current = spanSplitEnumerator.Current;
			ReadOnlySpan<char> root = line[current.Start..current.End];
			if (!spanSplitEnumerator.MoveNext())
			{
				return false;
			}
			current = spanSplitEnumerator.Current;
			ReadOnlySpan<char> mountPoint = line[current.Start..current.End];
			int num = line.IndexOf(" - ".AsSpan(), StringComparison.Ordinal);
			if (num == -1)
			{
				return false;
			}
			line = line.Slice(num + " - ".Length);
			spanSplitEnumerator = line.Split(' ');
			if (!spanSplitEnumerator.MoveNext())
			{
				return false;
			}
			current = spanSplitEnumerator.Current;
			ReadOnlySpan<char> fileSystemType = line[current.Start..current.End];
			if (!spanSplitEnumerator.MoveNext())
			{
				return false;
			}
			if (!spanSplitEnumerator.MoveNext())
			{
				return false;
			}
			current = spanSplitEnumerator.Current;
			ReadOnlySpan<char> superOptions = line[current.Start..current.End];
			result = new ParsedMount
			{
				Root = root,
				MountPoint = mountPoint,
				FileSystemType = fileSystemType,
				SuperOptions = superOptions
			};
			return true;
		}

		internal static string GetExeFilePathForProcess(ProcPid pid)
		{
			if (pid == ProcPid.Self)
			{
				return "/proc/self/exe";
			}
			IFormatProvider formatProvider = null;
			IFormatProvider provider = formatProvider;
			Span<char> initialBuffer = stackalloc char[256];
			DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(0, 3, formatProvider, initialBuffer);
			handler.AppendFormatted("/proc/");
			handler.AppendFormatted((uint)pid);
			handler.AppendFormatted("/exe");
			return string.Create(provider, initialBuffer, ref handler);
		}

		internal static string GetCmdLinePathForProcess(ProcPid pid)
		{
			if (pid == ProcPid.Self)
			{
				return "/proc/self/cmdline";
			}
			IFormatProvider formatProvider = null;
			IFormatProvider provider = formatProvider;
			Span<char> initialBuffer = stackalloc char[256];
			DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(0, 3, formatProvider, initialBuffer);
			handler.AppendFormatted("/proc/");
			handler.AppendFormatted((uint)pid);
			handler.AppendFormatted("/cmdline");
			return string.Create(provider, initialBuffer, ref handler);
		}

		internal static string GetStatFilePathForProcess(ProcPid pid)
		{
			if (pid == ProcPid.Self)
			{
				return "/proc/self/stat";
			}
			IFormatProvider formatProvider = null;
			IFormatProvider provider = formatProvider;
			Span<char> initialBuffer = stackalloc char[256];
			DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(0, 3, formatProvider, initialBuffer);
			handler.AppendFormatted("/proc/");
			handler.AppendFormatted((uint)pid);
			handler.AppendFormatted("/stat");
			return string.Create(provider, initialBuffer, ref handler);
		}

		internal static string GetTaskDirectoryPathForProcess(ProcPid pid)
		{
			if (pid == ProcPid.Self)
			{
				return "/proc/self/task/";
			}
			IFormatProvider formatProvider = null;
			IFormatProvider provider = formatProvider;
			Span<char> initialBuffer = stackalloc char[256];
			DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(0, 3, formatProvider, initialBuffer);
			handler.AppendFormatted("/proc/");
			handler.AppendFormatted((uint)pid);
			handler.AppendFormatted("/task/");
			return string.Create(provider, initialBuffer, ref handler);
		}

		internal static string GetFileDescriptorDirectoryPathForProcess(ProcPid pid)
		{
			if (pid == ProcPid.Self)
			{
				return "/proc/self/fd/";
			}
			IFormatProvider formatProvider = null;
			IFormatProvider provider = formatProvider;
			Span<char> initialBuffer = stackalloc char[256];
			DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(0, 3, formatProvider, initialBuffer);
			handler.AppendFormatted("/proc/");
			handler.AppendFormatted((uint)pid);
			handler.AppendFormatted("/fd/");
			return string.Create(provider, initialBuffer, ref handler);
		}

		private static string GetStatFilePathForThread(ProcPid pid, int tid)
		{
			IFormatProvider formatProvider2;
			IFormatProvider formatProvider;
			Span<char> span;
			if (pid == ProcPid.Self)
			{
				formatProvider = null;
				formatProvider2 = formatProvider;
				span = stackalloc char[256];
				IFormatProvider provider = formatProvider2;
				Span<char> initialBuffer = span;
				DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(0, 5, formatProvider, span);
				handler.AppendFormatted("/proc/");
				handler.AppendFormatted("self");
				handler.AppendFormatted("/task/");
				handler.AppendFormatted((uint)tid);
				handler.AppendFormatted("/stat");
				return string.Create(provider, initialBuffer, ref handler);
			}
			formatProvider2 = null;
			formatProvider = formatProvider2;
			span = stackalloc char[256];
			IFormatProvider provider2 = formatProvider;
			Span<char> initialBuffer2 = span;
			DefaultInterpolatedStringHandler handler2 = new DefaultInterpolatedStringHandler(0, 5, formatProvider2, span);
			handler2.AppendFormatted("/proc/");
			handler2.AppendFormatted((uint)pid);
			handler2.AppendFormatted("/task/");
			handler2.AppendFormatted((uint)tid);
			handler2.AppendFormatted("/stat");
			return string.Create(provider2, initialBuffer2, ref handler2);
		}

		internal static bool TryReadStatFile(ProcPid pid, out ParsedStat result)
		{
			return TryParseStatFile(GetStatFilePathForProcess(pid), out result);
		}

		internal static bool TryReadStatFile(ProcPid pid, int tid, out ParsedStat result)
		{
			return TryParseStatFile(GetStatFilePathForThread(pid, tid), out result);
		}

		internal static bool TryParseStatFile(string statFilePath, out ParsedStat result)
		{
			if (!TryReadFile(statFilePath, out var contents))
			{
				result = default(ParsedStat);
				return false;
			}
			StringParser stringParser = new StringParser(contents, ' ');
			ParsedStat parsedStat = new ParsedStat
			{
				pid = stringParser.ParseNextInt32(),
				comm = stringParser.MoveAndExtractNextInOuterParens(),
				state = stringParser.ParseNextChar(),
				ppid = stringParser.ParseNextInt32()
			};
			stringParser.MoveNextOrFail();
			parsedStat.session = stringParser.ParseNextInt32();
			stringParser.MoveNextOrFail();
			stringParser.MoveNextOrFail();
			stringParser.MoveNextOrFail();
			stringParser.MoveNextOrFail();
			stringParser.MoveNextOrFail();
			stringParser.MoveNextOrFail();
			stringParser.MoveNextOrFail();
			parsedStat.utime = stringParser.ParseNextUInt64();
			parsedStat.stime = stringParser.ParseNextUInt64();
			stringParser.MoveNextOrFail();
			stringParser.MoveNextOrFail();
			stringParser.MoveNextOrFail();
			parsedStat.nice = stringParser.ParseNextInt64();
			stringParser.MoveNextOrFail();
			stringParser.MoveNextOrFail();
			parsedStat.starttime = stringParser.ParseNextUInt64();
			parsedStat.vsize = stringParser.ParseNextUInt64();
			parsedStat.rss = stringParser.ParseNextInt64();
			parsedStat.rsslim = stringParser.ParseNextUInt64();
			result = parsedStat;
			return true;
		}

		private static string GetMapsFilePathForProcess(ProcPid pid)
		{
			if (pid == ProcPid.Self)
			{
				return "/proc/self/maps";
			}
			IFormatProvider formatProvider = null;
			IFormatProvider provider = formatProvider;
			Span<char> initialBuffer = stackalloc char[256];
			DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(0, 3, formatProvider, initialBuffer);
			handler.AppendFormatted("/proc/");
			handler.AppendFormatted((uint)pid);
			handler.AppendFormatted("/maps");
			return string.Create(provider, initialBuffer, ref handler);
		}

		internal static ProcessModuleCollection ParseMapsModules(ProcPid pid)
		{
			try
			{
				return ParseMapsModulesCore(File.ReadLines(GetMapsFilePathForProcess(pid)));
			}
			catch (IOException)
			{
			}
			catch (UnauthorizedAccessException)
			{
			}
			return null;
		}

		private unsafe static ProcessModuleCollection ParseMapsModulesCore(IEnumerable<string> lines)
		{
			ProcessModule module = null;
			ProcessModuleCollection modules = new ProcessModuleCollection(0);
			bool moduleHasReadAndExecFlags = false;
			foreach (string line in lines)
			{
				if (!TryParseMapsEntry(line, out (long, int, bool, string) parsedLine))
				{
					CommitCurrentModule();
					continue;
				}
				if (module != null && module.FileName == parsedLine.Item4 && (long)module.BaseAddress + (long)module.ModuleMemorySize == parsedLine.Item1)
				{
					module.ModuleMemorySize += parsedLine.Item2;
					moduleHasReadAndExecFlags |= parsedLine.Item3;
					continue;
				}
				CommitCurrentModule();
				module = new ProcessModule(parsedLine.Item4, Path.GetFileName(parsedLine.Item4))
				{
					ModuleMemorySize = parsedLine.Item2,
					EntryPointAddress = IntPtr.Zero
				};
				module.BaseAddress = new IntPtr((void*)parsedLine.Item1);
				moduleHasReadAndExecFlags = parsedLine.Item3;
			}
			CommitCurrentModule();
			return modules;
			void CommitCurrentModule()
			{
				if (moduleHasReadAndExecFlags && module != null)
				{
					modules.Add(module);
					module = null;
				}
			}
		}

		private static bool TryParseMapsEntry(string line, out (long StartAddress, int Size, bool HasReadAndExecFlags, string Path) parsedLine)
		{
			StringParser stringParser = new StringParser(line, ' ', skipEmpty: true);
			var (item, num) = stringParser.ParseRaw(TryParseAddressRange);
			if (num < 0)
			{
				parsedLine = default((long, int, bool, string));
				return false;
			}
			bool item2 = stringParser.ParseRaw(HasReadAndExecFlags);
			stringParser.MoveNext();
			stringParser.MoveNext();
			stringParser.MoveNext();
			if (!stringParser.MoveNext())
			{
				parsedLine = default((long, int, bool, string));
				return false;
			}
			string item3 = stringParser.ExtractCurrentToEnd();
			parsedLine = (StartAddress: item, Size: num, HasReadAndExecFlags: item2, Path: item3);
			return true;
			static bool HasReadAndExecFlags(string s, ref int start, ref int end)
			{
				ReadOnlySpan<char> span = s.AsSpan(start, end - start);
				if (span.Contains('r'))
				{
					return span.Contains('x');
				}
				return false;
			}
			static (long Start, int Size) TryParseAddressRange(string s, ref int start, ref int end)
			{
				int num2 = s.IndexOf('-', start, end - start);
				if (num2 > 0 && long.TryParse(s.AsSpan(start, num2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result) && long.TryParse(s.AsSpan(num2 + 1, end - (num2 + 1)), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result2))
				{
					return (Start: result, Size: (int)(result2 - result));
				}
				return (Start: 0L, Size: -1);
			}
		}

		internal static string GetStatusFilePathForProcess(ProcPid pid)
		{
			if (pid == ProcPid.Self)
			{
				return "/proc/self/status";
			}
			IFormatProvider formatProvider = null;
			IFormatProvider provider = formatProvider;
			Span<char> initialBuffer = stackalloc char[256];
			DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(0, 3, formatProvider, initialBuffer);
			handler.AppendFormatted("/proc/");
			handler.AppendFormatted((uint)pid);
			handler.AppendFormatted("/status");
			return string.Create(provider, initialBuffer, ref handler);
		}

		internal static bool TryReadStatusFile(ProcPid pid, out ParsedStatus result)
		{
			return TryParseStatusFile(GetStatusFilePathForProcess(pid), out result);
		}

		internal static bool TryParseStatusFile(string statusFilePath, out ParsedStatus result)
		{
			if (!TryReadFile(statusFilePath, out var contents))
			{
				result = default(ParsedStatus);
				return false;
			}
			ParsedStatus parsedStatus = default(ParsedStatus);
			SpanLineEnumerator enumerator = contents.AsSpan().EnumerateLines().GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ReadOnlySpan<char> current = enumerator.Current;
					int num = current.IndexOf(':');
					if (num == -1)
					{
						break;
					}
					ReadOnlySpan<char> readOnlySpan = current.Slice(num + 1);
					switch (current.Slice(0, num))
					{
					case "VmHWM":
						ulong.TryParse(readOnlySpan.Slice(0, readOnlySpan.Length - 3), out parsedStatus.VmHWM);
						break;
					case "VmRSS":
						ulong.TryParse(readOnlySpan.Slice(0, readOnlySpan.Length - 3), out parsedStatus.VmRSS);
						break;
					case "VmData":
					{
						ulong.TryParse(readOnlySpan.Slice(0, readOnlySpan.Length - 3), out var result3);
						parsedStatus.VmData += result3;
						break;
					}
					case "VmSwap":
						ulong.TryParse(readOnlySpan.Slice(0, readOnlySpan.Length - 3), out parsedStatus.VmSwap);
						break;
					case "VmSize":
						ulong.TryParse(readOnlySpan.Slice(0, readOnlySpan.Length - 3), out parsedStatus.VmSize);
						break;
					case "VmPeak":
						ulong.TryParse(readOnlySpan.Slice(0, readOnlySpan.Length - 3), out parsedStatus.VmPeak);
						break;
					case "VmStk":
					{
						ulong.TryParse(readOnlySpan.Slice(0, readOnlySpan.Length - 3), out var result2);
						parsedStatus.VmData += result2;
						break;
					}
					}
				}
			}
			finally
			{
				((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
			}
			parsedStatus.VmData *= 1024uL;
			parsedStatus.VmPeak *= 1024uL;
			parsedStatus.VmSize *= 1024uL;
			parsedStatus.VmSwap *= 1024uL;
			parsedStatus.VmRSS *= 1024uL;
			parsedStatus.VmHWM *= 1024uL;
			result = parsedStatus;
			return true;
		}

		private static bool TryReadFile(string path, [NotNullWhen(true)] out string contents)
		{
			byte[] array = ArrayPool<byte>.Shared.Rent(4096);
			int num = 0;
			try
			{
				using FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 1, useAsync: false);
				while (true)
				{
					int num2 = fileStream.Read(array, num, array.Length - num);
					if (num2 == 0)
					{
						break;
					}
					num += num2;
					if (num >= array.Length)
					{
						byte[] array2 = ArrayPool<byte>.Shared.Rent(array.Length * 2);
						Array.Copy(array, array2, array.Length);
						byte[] array3 = array;
						array = array2;
						ArrayPool<byte>.Shared.Return(array3);
					}
				}
				contents = Encoding.UTF8.GetString(array, 0, num);
				return true;
			}
			catch (Exception ex) when (ex is IOException || ex.InnerException is IOException)
			{
				contents = null;
				return false;
			}
			finally
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}
	}
}
