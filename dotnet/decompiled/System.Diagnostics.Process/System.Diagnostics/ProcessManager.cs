using System.Globalization;
using System.IO;
using Microsoft.Win32.SafeHandles;

namespace System.Diagnostics;

internal static class ProcessManager
{
	private static volatile int _procMatchesPidNamespace;

	internal static bool ProcMatchesPidNamespace
	{
		get
		{
			if (_procMatchesPidNamespace == 0)
			{
				int? num = null;
				string text = global::Interop.Sys.ReadLink("/proc/self".AsSpan());
				if (text != null && int.TryParse(text, out var result))
				{
					num = result;
				}
				_procMatchesPidNamespace = ((!num.HasValue || num == Environment.ProcessId) ? 1 : 2);
			}
			return _procMatchesPidNamespace == 1;
		}
	}

	public static bool IsRemoteMachine(string machineName)
	{
		ArgumentException.ThrowIfNullOrEmpty(machineName, "machineName");
		return IsRemoteMachineCore(machineName);
	}

	public static ProcessInfo GetProcessInfo(int processId, string machineName)
	{
		ThrowIfRemoteMachine(machineName);
		return CreateProcessInfo(processId);
	}

	public static int GetProcessIdFromHandle(SafeProcessHandle processHandle)
	{
		return processHandle.ProcessId;
	}

	private static bool IsRemoteMachineCore(string machineName)
	{
		if (machineName != ".")
		{
			return machineName != global::Interop.Sys.GetHostName();
		}
		return false;
	}

	internal static void ThrowIfRemoteMachine(string machineName)
	{
		if (IsRemoteMachine(machineName))
		{
			throw new PlatformNotSupportedException("RemoteMachinesNotSupported");
		}
	}

	internal static ProcessModuleCollection GetModules(int processId)
	{
		ProcessModuleCollection processModuleCollection = null;
		if (TryGetProcPid(processId, out var procPid))
		{
			processModuleCollection = global::Interop.procfs.ParseMapsModules(procPid);
			if (processModuleCollection != null)
			{
				string exePath = Process.GetExePath(procPid);
				if (exePath != null)
				{
					for (int i = 0; i < processModuleCollection.Count; i++)
					{
						ProcessModule processModule = processModuleCollection[i];
						if (processModule.FileName == exePath)
						{
							if (i > 0)
							{
								processModuleCollection.RemoveAt(i);
								processModuleCollection.Insert(0, processModule);
							}
							break;
						}
					}
				}
			}
		}
		return processModuleCollection ?? new ProcessModuleCollection(0);
	}

	internal static ProcessInfo CreateProcessInfo(int pid)
	{
		if (TryGetProcPid(pid, out var procPid) && global::Interop.procfs.TryReadStatFile(procPid, out var result))
		{
			global::Interop.procfs.TryReadStatusFile(procPid, out var result2);
			return CreateProcessInfo(procPid, ref result, ref result2);
		}
		return null;
	}

	internal static ProcessInfo CreateProcessInfo(global::Interop.procfs.ProcPid procPid, ref global::Interop.procfs.ParsedStat procFsStat, ref global::Interop.procfs.ParsedStatus procFsStatus, string processName = null)
	{
		int pid = procFsStat.pid;
		ProcessInfo processInfo = new ProcessInfo
		{
			ProcessId = pid,
			ProcessName = (processName ?? Process.GetUntruncatedProcessName(procPid, ref procFsStat) ?? string.Empty),
			BasePriority = (int)procFsStat.nice,
			SessionId = procFsStat.session,
			PoolPagedBytes = (long)procFsStatus.VmSwap,
			VirtualBytes = (long)procFsStatus.VmSize,
			VirtualBytesPeak = (long)procFsStatus.VmPeak,
			WorkingSetPeak = (long)procFsStatus.VmHWM,
			WorkingSet = (long)procFsStatus.VmRSS,
			PageFileBytes = (long)procFsStatus.VmSwap,
			PrivateBytes = (long)procFsStatus.VmData
		};
		string taskDirectoryPathForProcess = global::Interop.procfs.GetTaskDirectoryPathForProcess(procPid);
		try
		{
			foreach (string item in Directory.EnumerateDirectories(taskDirectoryPathForProcess))
			{
				if (int.TryParse(Path.GetFileName(item), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result) && global::Interop.procfs.TryReadStatFile(procPid, result, out var result2))
				{
					processInfo._threadInfoList.Add(new ThreadInfo
					{
						_processId = pid,
						_threadId = (ulong)result,
						_basePriority = processInfo.BasePriority,
						_currentPriority = (int)result2.nice,
						_startAddress = null,
						_threadState = ProcFsStateToThreadState(result2.state),
						_threadWaitReason = ThreadWaitReason.Unknown
					});
				}
			}
		}
		catch (IOException)
		{
		}
		return processInfo;
	}

	private static ThreadState ProcFsStateToThreadState(char c)
	{
		switch (c)
		{
		case 'R':
			return ThreadState.Running;
		case 'D':
		case 'P':
		case 'S':
		case 'T':
		case 't':
			return ThreadState.Wait;
		case 'X':
		case 'Z':
		case 'x':
			return ThreadState.Terminated;
		case 'K':
		case 'W':
			return ThreadState.Transition;
		case 'I':
			return ThreadState.Ready;
		default:
			return ThreadState.Unknown;
		}
	}

	internal static bool TryReadStatFile(int pid, out global::Interop.procfs.ParsedStat stat)
	{
		if (!TryGetProcPid(pid, out var procPid))
		{
			stat = default(global::Interop.procfs.ParsedStat);
			return false;
		}
		return global::Interop.procfs.TryReadStatFile(procPid, out stat);
	}

	internal static bool TryGetProcPid(int pid, out global::Interop.procfs.ProcPid procPid)
	{
		if (pid == Environment.ProcessId)
		{
			procPid = global::Interop.procfs.ProcPid.Self;
			return true;
		}
		if (ProcMatchesPidNamespace)
		{
			procPid = (global::Interop.procfs.ProcPid)pid;
			return true;
		}
		procPid = global::Interop.procfs.ProcPid.Invalid;
		return false;
	}
}
