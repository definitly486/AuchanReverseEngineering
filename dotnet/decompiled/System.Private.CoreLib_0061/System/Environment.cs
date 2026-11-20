using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;

namespace System;

public static class Environment
{
	public readonly struct ProcessCpuUsage
	{
		public TimeSpan UserTime { get; internal init; }

		public TimeSpan PrivilegedTime { get; internal init; }

		public TimeSpan TotalTime => UserTime + PrivilegedTime;
	}

	public enum SpecialFolder
	{
		ApplicationData = 26,
		CommonApplicationData = 35,
		LocalApplicationData = 28,
		Cookies = 33,
		Desktop = 0,
		Favorites = 6,
		History = 34,
		InternetCache = 32,
		Programs = 2,
		MyComputer = 17,
		MyMusic = 13,
		MyPictures = 39,
		MyVideos = 14,
		Recent = 8,
		SendTo = 9,
		StartMenu = 11,
		Startup = 7,
		System = 37,
		Templates = 21,
		DesktopDirectory = 16,
		Personal = 5,
		MyDocuments = 5,
		ProgramFiles = 38,
		CommonProgramFiles = 43,
		AdminTools = 48,
		CDBurning = 59,
		CommonAdminTools = 47,
		CommonDocuments = 46,
		CommonMusic = 53,
		CommonOemLinks = 58,
		CommonPictures = 54,
		CommonStartMenu = 22,
		CommonPrograms = 23,
		CommonStartup = 24,
		CommonDesktopDirectory = 25,
		CommonTemplates = 45,
		CommonVideos = 55,
		Fonts = 20,
		NetworkShortcuts = 19,
		PrinterShortcuts = 27,
		UserProfile = 40,
		CommonProgramFilesX86 = 44,
		ProgramFilesX86 = 42,
		Resources = 56,
		LocalizedResources = 57,
		SystemX86 = 41,
		Windows = 36
	}

	public enum SpecialFolderOption
	{
		None = 0,
		Create = 32768,
		DoNotVerify = 16384
	}

	private static volatile sbyte s_privilegedProcess;

	private static volatile int s_processId;

	private static volatile string s_processPath;

	private static volatile OperatingSystem s_osVersion;

	private static volatile int s_systemPageSize;

	private static Dictionary<SpecialFolder, string> s_specialFolders;

	private static Dictionary<string, string> s_environment;

	public static int CurrentManagedThreadId => Thread.CurrentThread.ManagedThreadId;

	public static extern int ExitCode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	public static int ProcessorCount { get; } = GetProcessorCount();

	internal static bool IsSingleProcessor => ProcessorCount == 1;

	public static bool IsPrivilegedProcess
	{
		get
		{
			sbyte b = s_privilegedProcess;
			if (b == 0)
			{
				b = (s_privilegedProcess = (sbyte)(IsPrivilegedProcessCore() ? 1 : (-1)));
			}
			return b > 0;
		}
	}

	public static bool HasShutdownStarted => false;

	public static string CommandLine => PasteArguments.Paste(GetCommandLineArgs(), pasteFirstArgumentUsingArgV0Rules: true);

	public static string CurrentDirectory
	{
		get
		{
			return CurrentDirectoryCore;
		}
		set
		{
			ArgumentException.ThrowIfNullOrEmpty(value, "value");
			CurrentDirectoryCore = value;
		}
	}

	public static int ProcessId
	{
		get
		{
			int num = s_processId;
			if (num == 0)
			{
				num = (s_processId = GetProcessId());
			}
			return num;
		}
	}

	public static string? ProcessPath
	{
		get
		{
			string text = s_processPath;
			if (text == null)
			{
				Interlocked.CompareExchange(ref s_processPath, GetProcessPath() ?? "", null);
				text = s_processPath;
			}
			if (text.Length == 0)
			{
				return null;
			}
			return text;
		}
	}

	public static bool Is64BitProcess => 4 == 8;

	public static bool Is64BitOperatingSystem
	{
		get
		{
			_ = 0;
			return false;
		}
	}

	public static string NewLine => "\n";

	public static OperatingSystem OSVersion
	{
		get
		{
			OperatingSystem operatingSystem = s_osVersion;
			if (operatingSystem == null)
			{
				Interlocked.CompareExchange(ref s_osVersion, GetOSVersion(), null);
				operatingSystem = s_osVersion;
			}
			return operatingSystem;
		}
	}

	public static string StackTrace
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return new StackTrace(fNeedFileInfo: true).ToString(System.Diagnostics.StackTrace.TraceFormat.Normal);
		}
	}

	public static int SystemPageSize
	{
		get
		{
			int num = s_systemPageSize;
			if (num == 0)
			{
				num = (s_systemPageSize = GetSystemPageSize());
			}
			return num;
		}
	}

	public static int TickCount => (int)TickCount64;

	public static bool UserInteractive => true;

	private static string CurrentDirectoryCore
	{
		get
		{
			return Interop.Sys.GetCwd();
		}
		set
		{
			Interop.CheckIo(Interop.Sys.ChDir(value), value, isDirError: true);
		}
	}

	public static string SystemDirectory => GetFolderPathCore(SpecialFolder.System, SpecialFolderOption.None);

	public static string UserDomainName => MachineName;

	[UnsupportedOSPlatform("ios")]
	[UnsupportedOSPlatform("tvos")]
	[UnsupportedOSPlatform("browser")]
	[SupportedOSPlatform("maccatalyst")]
	public static ProcessCpuUsage CpuUsage
	{
		get
		{
			Interop.Sys.ProcessCpuInformation previousCpuInfo = default(Interop.Sys.ProcessCpuInformation);
			Interop.Sys.GetCpuUtilization(ref previousCpuInfo);
			ulong ticks = Math.Min(previousCpuInfo.lastRecordedUserTime / 100, 9223372036854775807uL);
			ulong ticks2 = Math.Min(previousCpuInfo.lastRecordedKernelTime / 100, 9223372036854775807uL);
			return new ProcessCpuUsage
			{
				UserTime = new TimeSpan((long)ticks),
				PrivilegedTime = new TimeSpan((long)ticks2)
			};
		}
	}

	public static long TickCount64 => Interop.Sys.GetLowResolutionTimestamp();

	public static string MachineName
	{
		get
		{
			string hostName = Interop.Sys.GetHostName();
			int num = hostName.IndexOf('.');
			if (num >= 0)
			{
				return hostName.Substring(0, num);
			}
			return hostName;
		}
	}

	public static string UserName => Interop.Sys.GetUserNameFromPasswd(Interop.Sys.GetEUid());

	public static long WorkingSet
	{
		get
		{
			if (!Interop.procfs.TryReadStatusFile(Interop.procfs.ProcPid.Self, out var result))
			{
				return 0L;
			}
			return (long)result.VmRSS;
		}
	}

	public static Version Version => new Version(10, 0, 12);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetProcessorCount();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[DoesNotReturn]
	public static extern void Exit(int exitCode);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] GetCommandLineArgs();

	[DoesNotReturn]
	public static void FailFast(string? message)
	{
		FailFast(message, null, null);
	}

	[DoesNotReturn]
	public static void FailFast(string? message, Exception? exception)
	{
		FailFast(message, exception, null);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[DoesNotReturn]
	internal static extern void FailFast(string message, Exception exception, string errorSource);

	public static string? GetEnvironmentVariable(string variable)
	{
		ArgumentNullException.ThrowIfNull(variable, "variable");
		return GetEnvironmentVariableCore(variable);
	}

	public static string? GetEnvironmentVariable(string variable, EnvironmentVariableTarget target)
	{
		if (target == EnvironmentVariableTarget.Process)
		{
			return GetEnvironmentVariable(variable);
		}
		ArgumentNullException.ThrowIfNull(variable, "variable");
		bool fromMachine = ValidateAndConvertRegistryTarget(target);
		return GetEnvironmentVariableFromRegistry(variable, fromMachine);
	}

	public static IDictionary GetEnvironmentVariables(EnvironmentVariableTarget target)
	{
		if (target == EnvironmentVariableTarget.Process)
		{
			return GetEnvironmentVariables();
		}
		return GetEnvironmentVariablesFromRegistry(ValidateAndConvertRegistryTarget(target));
	}

	public static void SetEnvironmentVariable(string variable, string? value)
	{
		ValidateVariable(variable);
		SetEnvironmentVariableCore(variable, value);
	}

	public static void SetEnvironmentVariable(string variable, string? value, EnvironmentVariableTarget target)
	{
		if (target == EnvironmentVariableTarget.Process)
		{
			SetEnvironmentVariable(variable, value);
			return;
		}
		ValidateVariable(variable);
		ValidateAndConvertRegistryTarget(target);
	}

	public static string ExpandEnvironmentVariables(string name)
	{
		ArgumentNullException.ThrowIfNull(name, "name");
		if (name.Length == 0)
		{
			return name;
		}
		return ExpandEnvironmentVariablesCore(name);
	}

	public static string GetFolderPath(SpecialFolder folder)
	{
		return GetFolderPathCore(folder, SpecialFolderOption.None);
	}

	public static string GetFolderPath(SpecialFolder folder, SpecialFolderOption option)
	{
		if (option != SpecialFolderOption.None && option != SpecialFolderOption.Create && option != SpecialFolderOption.DoNotVerify)
		{
			Throw(option);
		}
		return GetFolderPathCore(folder, option);
		static void Throw(SpecialFolderOption specialFolderOption)
		{
			throw new ArgumentOutOfRangeException("option", specialFolderOption, SR.Format("Arg_EnumIllegalVal", specialFolderOption));
		}
	}

	private static bool ValidateAndConvertRegistryTarget(EnvironmentVariableTarget target)
	{
		return target switch
		{
			EnvironmentVariableTarget.Machine => true, 
			EnvironmentVariableTarget.User => false, 
			_ => throw new ArgumentOutOfRangeException("target", target, SR.Format("Arg_EnumIllegalVal", target)), 
		};
	}

	private static void ValidateVariable(string variable)
	{
		ArgumentException.ThrowIfNullOrEmpty(variable, "variable");
		if (variable[0] == '\0')
		{
			throw new ArgumentException("Argument_StringFirstCharIsZero", "variable");
		}
		if (variable.Contains('='))
		{
			throw new ArgumentException("Argument_IllegalEnvVarName", "variable");
		}
	}

	private static string GetFolderPathCore(SpecialFolder folder, SpecialFolderOption _)
	{
		if (s_specialFolders == null)
		{
			Interlocked.CompareExchange(ref s_specialFolders, new Dictionary<SpecialFolder, string>(), null);
		}
		string value;
		lock (s_specialFolders)
		{
			if (!s_specialFolders.TryGetValue(folder, out value))
			{
				value = GetSpecialFolder(folder) ?? string.Empty;
				s_specialFolders[folder] = value;
			}
		}
		return value;
	}

	private static string GetSpecialFolder(SpecialFolder folder)
	{
		string text = null;
		try
		{
			text = PersistedFiles.GetHomeDirectory();
		}
		catch (Exception)
		{
		}
		if (string.IsNullOrEmpty(text))
		{
			text = "/";
		}
		switch (folder)
		{
		case SpecialFolder.LocalApplicationData:
			return text;
		case SpecialFolder.ApplicationData:
			return Path.Combine(text, ".config");
		case SpecialFolder.Desktop:
		case SpecialFolder.DesktopDirectory:
			return Path.Combine(text, "Desktop");
		case SpecialFolder.Personal:
			return Path.Combine(text, "Documents");
		case SpecialFolder.MyMusic:
			return Path.Combine(text, "Music");
		case SpecialFolder.MyPictures:
			return Path.Combine(text, "Pictures");
		case SpecialFolder.Templates:
			return Path.Combine(text, "Templates");
		case SpecialFolder.MyVideos:
			return Path.Combine(text, "Videos");
		case SpecialFolder.CommonTemplates:
			return "/usr/share/templates";
		case SpecialFolder.Fonts:
			return Path.Combine(text, ".fonts");
		case SpecialFolder.UserProfile:
			return text;
		case SpecialFolder.CommonApplicationData:
			return "/usr/share";
		default:
			if (!Enum.IsDefined(folder))
			{
				throw new ArgumentOutOfRangeException("folder", folder, SR.Format("Arg_EnumIllegalVal", folder));
			}
			return null;
		}
	}

	private static string GetEnvironmentVariableFromRegistry(string variable, bool fromMachine)
	{
		return null;
	}

	private static Hashtable GetEnvironmentVariablesFromRegistry(bool fromMachine)
	{
		return new Hashtable();
	}

	private static string ExpandEnvironmentVariablesCore(string name)
	{
		Span<char> initialBuffer = stackalloc char[128];
		ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
		int num = 0;
		int num2;
		while (num < name.Length && (num2 = name.IndexOf('%', num + 1)) >= 0)
		{
			if (name[num] == '%')
			{
				string environmentVariable = GetEnvironmentVariable(name.Substring(num + 1, num2 - num - 1));
				if (environmentVariable != null)
				{
					valueStringBuilder.Append(environmentVariable);
					num = num2 + 1;
					continue;
				}
			}
			valueStringBuilder.Append(name.AsSpan(num, num2 - num));
			num = num2;
		}
		valueStringBuilder.Append(name.AsSpan(num));
		return valueStringBuilder.ToString();
	}

	private static int GetSystemPageSize()
	{
		return CheckedSysConf(Interop.Sys.SysConfName._SC_PAGESIZE);
	}

	private static int CheckedSysConf(Interop.Sys.SysConfName name)
	{
		long num = Interop.Sys.SysConf(name);
		if (num == -1)
		{
			Interop.ErrorInfo lastErrorInfo = Interop.Sys.GetLastErrorInfo();
			throw (lastErrorInfo.Error == Interop.Error.EINVAL) ? new ArgumentOutOfRangeException("name", name, lastErrorInfo.GetErrorMessage()) : Interop.GetIOException(lastErrorInfo);
		}
		return (int)num;
	}

	private static string GetEnvironmentVariableCore(string variable)
	{
		if (s_environment == null)
		{
			return Marshal.PtrToStringUTF8(Interop.Sys.GetEnv(variable));
		}
		variable = TrimStringOnFirstZero(variable);
		lock (s_environment)
		{
			s_environment.TryGetValue(variable, out var value);
			return value;
		}
	}

	internal static string GetEnvironmentVariableCore_NoArrayPool(string variable)
	{
		return GetEnvironmentVariableCore(variable);
	}

	private static void SetEnvironmentVariableCore(string variable, string value)
	{
		EnsureEnvironmentCached();
		variable = TrimStringOnFirstZero(variable);
		value = ((value == null) ? null : TrimStringOnFirstZero(value));
		lock (s_environment)
		{
			if (value == null)
			{
				s_environment.Remove(variable);
			}
			else
			{
				s_environment[variable] = value;
			}
		}
	}

	public static IDictionary GetEnvironmentVariables()
	{
		Hashtable hashtable = new Hashtable();
		EnsureEnvironmentCached();
		lock (s_environment)
		{
			foreach (KeyValuePair<string, string> item in s_environment)
			{
				hashtable.Add(item.Key, item.Value);
			}
			return hashtable;
		}
	}

	private static string TrimStringOnFirstZero(string value)
	{
		int num = value.IndexOf('\0');
		if (num >= 0)
		{
			return value.Substring(0, num);
		}
		return value;
	}

	private static void EnsureEnvironmentCached()
	{
		if (s_environment == null)
		{
			Interlocked.CompareExchange(ref s_environment, GetSystemEnvironmentVariables(), null);
		}
	}

	private static Dictionary<string, string> GetSystemEnvironmentVariables()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		nint environ = Interop.Sys.GetEnviron();
		if (environ != IntPtr.Zero)
		{
			try
			{
				string key;
				string value;
				for (nint num = environ; ParseEntry(num, out key, out value); num += 4)
				{
					if (key != null && value != null)
					{
						try
						{
							dictionary.Add(key, value);
						}
						catch (ArgumentException)
						{
						}
					}
				}
			}
			finally
			{
				Interop.Sys.FreeEnviron(environ);
			}
		}
		return dictionary;
		unsafe static bool ParseEntry(nint current, out string reference, out string reference2)
		{
			reference = null;
			reference2 = null;
			byte* ptr = *(byte**)current;
			if (ptr == null)
			{
				return false;
			}
			byte* ptr2;
			for (ptr2 = ptr; *ptr2 != 61 && *ptr2 != 0; ptr2++)
			{
			}
			if (ptr2 == ptr || *ptr2 == 0)
			{
				return true;
			}
			reference = new string((sbyte*)ptr, 0, checked((int)(ptr2 - ptr)));
			reference2 = new string((sbyte*)(ptr2 + 1));
			return true;
		}
	}

	public static string[] GetLogicalDrives()
	{
		return Interop.Sys.GetAllMountPoints();
	}

	private static bool IsPrivilegedProcessCore()
	{
		return Interop.Sys.GetEUid() == 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetProcessId()
	{
		return Interop.Sys.GetPid();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetProcessPath()
	{
		return Interop.Sys.GetProcessPath();
	}

	private static OperatingSystem GetOSVersion()
	{
		return GetOperatingSystem(Interop.Sys.GetUnixRelease());
	}

	private static OperatingSystem GetOperatingSystem(string release)
	{
		int major = 0;
		int minor = 0;
		int build = 0;
		int revision = 0;
		if (release != null)
		{
			int pos = 0;
			major = FindAndParseNextNumber(release, ref pos);
			minor = FindAndParseNextNumber(release, ref pos);
			build = FindAndParseNextNumber(release, ref pos);
			revision = FindAndParseNextNumber(release, ref pos);
		}
		return new OperatingSystem(PlatformID.Unix, new Version(major, minor, build, revision));
	}

	private static int FindAndParseNextNumber(string text, ref int pos)
	{
		int num = text.AsSpan(pos).IndexOfAnyInRange('0', '9');
		pos = ((num >= 0) ? (pos + num) : text.Length);
		int num2 = 0;
		while ((uint)pos < (uint)text.Length)
		{
			char c = text[pos];
			if (!char.IsAsciiDigit(c))
			{
				break;
			}
			try
			{
				num2 = checked(num2 * 10 + (c - 48));
			}
			catch (OverflowException)
			{
				return int.MaxValue;
			}
			pos++;
		}
		return num2;
	}
}
