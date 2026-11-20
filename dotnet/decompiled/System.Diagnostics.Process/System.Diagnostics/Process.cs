using System.Buffers;
using System.ComponentModel;
using System.IO;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace System.Diagnostics;

[Designer("System.Diagnostics.Design.ProcessDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
public class Process : Component, IDisposable
{
	private enum StreamReadMode
	{
		Undefined,
		SyncMode,
		AsyncMode
	}

	private enum State
	{
		HaveId = 1,
		IsLocal = 2,
		HaveNonExitedId = 5,
		HaveProcessInfo = 8,
		Exited = 16,
		Associated = 32
	}

	private bool _haveProcessId;

	private int _processId;

	private bool _haveProcessHandle;

	private SafeProcessHandle _processHandle;

	private bool _isRemoteMachine;

	private string _machineName;

	private ProcessInfo _processInfo;

	private ProcessThreadCollection _threads;

	private ProcessModuleCollection _modules;

	private bool _haveWorkingSetLimits;

	private nint _minWorkingSet;

	private nint _maxWorkingSet;

	private bool _haveProcessorAffinity;

	private nint _processorAffinity;

	private bool _havePriorityClass;

	private ProcessPriorityClass _priorityClass;

	private ProcessStartInfo _startInfo;

	private bool _watchForExit;

	private bool _watchingForExit;

	private EventHandler _onExited;

	private bool _exited;

	private int _exitCode;

	private DateTime? _startTime;

	private DateTime _exitTime;

	private bool _haveExitTime;

	private bool _priorityBoostEnabled;

	private bool _havePriorityBoostEnabled;

	private bool _raisedOnExited;

	private RegisteredWaitHandle _registeredWaitHandle;

	private WaitHandle _waitHandle;

	private StreamReader _standardOutput;

	private StreamWriter _standardInput;

	private StreamReader _standardError;

	private bool _disposed;

	private bool _standardInputAccessed;

	private StreamReadMode _outputStreamReadMode;

	private StreamReadMode _errorStreamReadMode;

	internal AsyncStreamReader _output;

	internal AsyncStreamReader _error;

	private static readonly object s_initializedGate = new object();

	private static readonly ReaderWriterLockSlim s_processStartLock = new ReaderWriterLockSlim();

	private ProcessWaitState.Holder _waitStateHolder;

	private static long s_ticksPerSecond;

	private static long s_bootTimeTicks;

	public SafeProcessHandle SafeHandle
	{
		get
		{
			EnsureState(State.Associated);
			return GetOrOpenProcessHandle();
		}
	}

	public nint Handle => SafeHandle.DangerousGetHandle();

	private bool Associated
	{
		get
		{
			if (!_haveProcessId)
			{
				return _haveProcessHandle;
			}
			return true;
		}
	}

	public int BasePriority
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return _processInfo.BasePriority;
		}
	}

	public int ExitCode
	{
		get
		{
			EnsureState(State.Exited);
			return _exitCode;
		}
	}

	public bool HasExited
	{
		get
		{
			if (!_exited)
			{
				EnsureState(State.Associated);
				UpdateHasExited();
				if (_exited)
				{
					RaiseOnExited();
				}
			}
			return _exited;
		}
	}

	[UnsupportedOSPlatform("ios")]
	[UnsupportedOSPlatform("tvos")]
	[SupportedOSPlatform("maccatalyst")]
	public DateTime StartTime
	{
		get
		{
			if (!_startTime.HasValue)
			{
				_startTime = StartTimeCore;
			}
			return _startTime.Value;
		}
	}

	public DateTime ExitTime
	{
		get
		{
			if (!_haveExitTime)
			{
				EnsureState(State.Exited);
				_exitTime = ExitTimeCore;
				_haveExitTime = true;
			}
			return _exitTime;
		}
	}

	public int Id
	{
		get
		{
			EnsureState(State.HaveId);
			return _processId;
		}
	}

	public string MachineName
	{
		get
		{
			EnsureState(State.Associated);
			return _machineName;
		}
	}

	public nint MaxWorkingSet
	{
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		[SupportedOSPlatform("maccatalyst")]
		get
		{
			EnsureWorkingSetLimits();
			return _maxWorkingSet;
		}
		[SupportedOSPlatform("freebsd")]
		[SupportedOSPlatform("macos")]
		[SupportedOSPlatform("maccatalyst")]
		[SupportedOSPlatform("windows")]
		set
		{
			SetWorkingSetLimits(null, value);
		}
	}

	public nint MinWorkingSet
	{
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		[SupportedOSPlatform("maccatalyst")]
		get
		{
			EnsureWorkingSetLimits();
			return _minWorkingSet;
		}
		[SupportedOSPlatform("freebsd")]
		[SupportedOSPlatform("macos")]
		[SupportedOSPlatform("maccatalyst")]
		[SupportedOSPlatform("windows")]
		set
		{
			SetWorkingSetLimits(value, null);
		}
	}

	public ProcessModuleCollection Modules
	{
		get
		{
			if (_modules == null)
			{
				EnsureState((State)7);
				_modules = ProcessManager.GetModules(_processId);
			}
			return _modules;
		}
	}

	public long NonpagedSystemMemorySize64
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return _processInfo.PoolNonPagedBytes;
		}
	}

	[Obsolete("Process.NonpagedSystemMemorySize has been deprecated because the type of the property can't represent all valid results. Use System.Diagnostics.Process.NonpagedSystemMemorySize64 instead.")]
	public int NonpagedSystemMemorySize
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return (int)_processInfo.PoolNonPagedBytes;
		}
	}

	public long PagedMemorySize64
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return _processInfo.PageFileBytes;
		}
	}

	[Obsolete("Process.PagedMemorySize has been deprecated because the type of the property can't represent all valid results. Use System.Diagnostics.Process.PagedMemorySize64 instead.")]
	public int PagedMemorySize
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return (int)_processInfo.PageFileBytes;
		}
	}

	public long PagedSystemMemorySize64
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return _processInfo.PoolPagedBytes;
		}
	}

	[Obsolete("Process.PagedSystemMemorySize has been deprecated because the type of the property can't represent all valid results. Use System.Diagnostics.Process.PagedSystemMemorySize64 instead.")]
	public int PagedSystemMemorySize
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return (int)_processInfo.PoolPagedBytes;
		}
	}

	public long PeakPagedMemorySize64
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return _processInfo.PageFileBytesPeak;
		}
	}

	[Obsolete("Process.PeakPagedMemorySize has been deprecated because the type of the property can't represent all valid results. Use System.Diagnostics.Process.PeakPagedMemorySize64 instead.")]
	public int PeakPagedMemorySize
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return (int)_processInfo.PageFileBytesPeak;
		}
	}

	public long PeakWorkingSet64
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return _processInfo.WorkingSetPeak;
		}
	}

	[Obsolete("Process.PeakWorkingSet has been deprecated because the type of the property can't represent all valid results. Use System.Diagnostics.Process.PeakWorkingSet64 instead.")]
	public int PeakWorkingSet
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return (int)_processInfo.WorkingSetPeak;
		}
	}

	public long PeakVirtualMemorySize64
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return _processInfo.VirtualBytesPeak;
		}
	}

	[Obsolete("Process.PeakVirtualMemorySize has been deprecated because the type of the property can't represent all valid results. Use System.Diagnostics.Process.PeakVirtualMemorySize64 instead.")]
	public int PeakVirtualMemorySize
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return (int)_processInfo.VirtualBytesPeak;
		}
	}

	public bool PriorityBoostEnabled
	{
		get
		{
			if (!_havePriorityBoostEnabled)
			{
				_priorityBoostEnabled = false;
				_havePriorityBoostEnabled = true;
			}
			return _priorityBoostEnabled;
		}
		set
		{
			PriorityBoostEnabledCore = value;
			_priorityBoostEnabled = value;
			_havePriorityBoostEnabled = true;
		}
	}

	public ProcessPriorityClass PriorityClass
	{
		get
		{
			if (!_havePriorityClass)
			{
				_priorityClass = PriorityClassCore;
				_havePriorityClass = true;
			}
			return _priorityClass;
		}
		set
		{
			if (!Enum.IsDefined(value))
			{
				throw new InvalidEnumArgumentException("value", (int)value, typeof(ProcessPriorityClass));
			}
			PriorityClassCore = value;
			_priorityClass = value;
			_havePriorityClass = true;
		}
	}

	public long PrivateMemorySize64
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return _processInfo.PrivateBytes;
		}
	}

	[Obsolete("Process.PrivateMemorySize has been deprecated because the type of the property can't represent all valid results. Use System.Diagnostics.Process.PrivateMemorySize64 instead.")]
	public int PrivateMemorySize
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return (int)_processInfo.PrivateBytes;
		}
	}

	[SupportedOSPlatform("windows")]
	[SupportedOSPlatform("linux")]
	public nint ProcessorAffinity
	{
		get
		{
			if (!_haveProcessorAffinity)
			{
				_processorAffinity = ProcessorAffinityCore;
				_haveProcessorAffinity = true;
			}
			return _processorAffinity;
		}
		set
		{
			ProcessorAffinityCore = value;
			_processorAffinity = value;
			_haveProcessorAffinity = true;
		}
	}

	public int SessionId
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return _processInfo.SessionId;
		}
	}

	public ProcessStartInfo StartInfo
	{
		get
		{
			if (_startInfo == null)
			{
				if (Associated)
				{
					throw new InvalidOperationException("CantGetProcessStartInfo");
				}
				_startInfo = new ProcessStartInfo();
			}
			return _startInfo;
		}
		set
		{
			ArgumentNullException.ThrowIfNull(value, "value");
			if (Associated)
			{
				throw new InvalidOperationException("CantSetProcessStartInfo");
			}
			_startInfo = value;
		}
	}

	public ProcessThreadCollection Threads
	{
		get
		{
			if (_threads == null)
			{
				EnsureState(State.HaveProcessInfo);
				int count = _processInfo._threadInfoList.Count;
				ProcessThread[] array = new ProcessThread[count];
				for (int i = 0; i < count; i++)
				{
					array[i] = new ProcessThread(_isRemoteMachine, _processId, _processInfo._threadInfoList[i]);
				}
				ProcessThreadCollection threads = new ProcessThreadCollection(array);
				_threads = threads;
			}
			return _threads;
		}
	}

	public int HandleCount
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			EnsureHandleCountPopulated();
			return _processInfo.HandleCount;
		}
	}

	public long VirtualMemorySize64
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return _processInfo.VirtualBytes;
		}
	}

	[Obsolete("Process.VirtualMemorySize has been deprecated because the type of the property can't represent all valid results. Use System.Diagnostics.Process.VirtualMemorySize64 instead.")]
	public int VirtualMemorySize
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return (int)_processInfo.VirtualBytes;
		}
	}

	public bool EnableRaisingEvents
	{
		get
		{
			return _watchForExit;
		}
		set
		{
			if (value == _watchForExit)
			{
				return;
			}
			if (Associated)
			{
				if (value)
				{
					EnsureWatchingForExit();
				}
				else
				{
					StopWatchingForExit();
				}
			}
			_watchForExit = value;
		}
	}

	public StreamWriter StandardInput
	{
		get
		{
			CheckDisposed();
			if (_standardInput == null)
			{
				throw new InvalidOperationException("CantGetStandardIn");
			}
			_standardInputAccessed = true;
			return _standardInput;
		}
	}

	public StreamReader StandardOutput
	{
		get
		{
			CheckDisposed();
			if (_standardOutput == null)
			{
				throw new InvalidOperationException("CantGetStandardOut");
			}
			if (_outputStreamReadMode == StreamReadMode.Undefined)
			{
				_outputStreamReadMode = StreamReadMode.SyncMode;
			}
			else if (_outputStreamReadMode != StreamReadMode.SyncMode)
			{
				throw new InvalidOperationException("CantMixSyncAsyncOperation");
			}
			return _standardOutput;
		}
	}

	public StreamReader StandardError
	{
		get
		{
			CheckDisposed();
			if (_standardError == null)
			{
				throw new InvalidOperationException("CantGetStandardError");
			}
			if (_errorStreamReadMode == StreamReadMode.Undefined)
			{
				_errorStreamReadMode = StreamReadMode.SyncMode;
			}
			else if (_errorStreamReadMode != StreamReadMode.SyncMode)
			{
				throw new InvalidOperationException("CantMixSyncAsyncOperation");
			}
			return _standardError;
		}
	}

	public long WorkingSet64
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return _processInfo.WorkingSet;
		}
	}

	[Obsolete("Process.WorkingSet has been deprecated because the type of the property can't represent all valid results. Use System.Diagnostics.Process.WorkingSet64 instead.")]
	public int WorkingSet
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return (int)_processInfo.WorkingSet;
		}
	}

	public ISynchronizeInvoke? SynchronizingObject { get; set; }

	private bool IsCurrentProcess => _processId == Environment.ProcessId;

	public ProcessModule? MainModule
	{
		get
		{
			ProcessModuleCollection modules = Modules;
			if (modules.Count <= 0)
			{
				return null;
			}
			return modules[0];
		}
	}

	private DateTime ExitTimeCore => GetWaitState().ExitTime;

	private static bool PriorityBoostEnabledCore
	{
		set
		{
		}
	}

	private ProcessPriorityClass PriorityClassCore
	{
		get
		{
			EnsureState(State.HaveNonExitedId);
			int priority2;
			int priority = global::Interop.Sys.GetPriority(global::Interop.Sys.PriorityWhich.PRIO_PROCESS, _processId, out priority2);
			if (priority != 0)
			{
				throw new Win32Exception(priority);
			}
			if (priority2 >= -15)
			{
				if (priority2 >= -10)
				{
					if (priority2 >= -5)
					{
						if (priority2 != 0)
						{
							if (priority2 > 10)
							{
								return ProcessPriorityClass.Idle;
							}
							return ProcessPriorityClass.BelowNormal;
						}
						return ProcessPriorityClass.Normal;
					}
					return ProcessPriorityClass.AboveNormal;
				}
				return ProcessPriorityClass.High;
			}
			return ProcessPriorityClass.RealTime;
		}
		set
		{
			EnsureState(State.HaveNonExitedId);
			int nice = 0;
			switch (value)
			{
			case ProcessPriorityClass.RealTime:
				nice = -19;
				break;
			case ProcessPriorityClass.High:
				nice = -11;
				break;
			case ProcessPriorityClass.AboveNormal:
				nice = -6;
				break;
			case ProcessPriorityClass.BelowNormal:
				nice = 10;
				break;
			case ProcessPriorityClass.Idle:
				nice = 19;
				break;
			}
			if (global::Interop.Sys.SetPriority(global::Interop.Sys.PriorityWhich.PRIO_PROCESS, _processId, nice) == -1)
			{
				throw new Win32Exception();
			}
		}
	}

	public nint MainWindowHandle => IntPtr.Zero;

	public string MainWindowTitle => string.Empty;

	public bool Responding => true;

	public string ProcessName
	{
		get
		{
			EnsureState(State.HaveProcessInfo);
			return _processInfo.ProcessName;
		}
	}

	[UnsupportedOSPlatform("ios")]
	[UnsupportedOSPlatform("tvos")]
	[SupportedOSPlatform("maccatalyst")]
	public TimeSpan PrivilegedProcessorTime
	{
		get
		{
			if (!IsCurrentProcess)
			{
				return TicksToTimeSpan(GetStat().stime);
			}
			return Environment.CpuUsage.PrivilegedTime;
		}
	}

	internal DateTime StartTimeCore => BootTimeToDateTime(TicksToTimeSpan(GetStat().starttime));

	private static DateTime BootTime
	{
		get
		{
			long num = Interlocked.Read(ref s_bootTimeTicks);
			if (num == 0L)
			{
				num = global::Interop.Sys.GetBootTimeTicks();
				long num2 = Interlocked.CompareExchange(ref s_bootTimeTicks, num, 0L);
				if (num2 != 0L)
				{
					num = num2;
				}
			}
			return new DateTime(num);
		}
	}

	[UnsupportedOSPlatform("ios")]
	[UnsupportedOSPlatform("tvos")]
	[SupportedOSPlatform("maccatalyst")]
	public TimeSpan TotalProcessorTime
	{
		get
		{
			if (IsCurrentProcess)
			{
				return Environment.CpuUsage.TotalTime;
			}
			global::Interop.procfs.ParsedStat stat = GetStat();
			return TicksToTimeSpan(stat.utime + stat.stime);
		}
	}

	[UnsupportedOSPlatform("ios")]
	[UnsupportedOSPlatform("tvos")]
	[SupportedOSPlatform("maccatalyst")]
	public TimeSpan UserProcessorTime
	{
		get
		{
			if (!IsCurrentProcess)
			{
				return TicksToTimeSpan(GetStat().utime);
			}
			return Environment.CpuUsage.UserTime;
		}
	}

	private nint ProcessorAffinityCore
	{
		get
		{
			EnsureState(State.HaveNonExitedId);
			if (global::Interop.Sys.SchedGetAffinity(_processId, out var mask) != 0)
			{
				throw new Win32Exception();
			}
			return mask;
		}
		set
		{
			EnsureState(State.HaveNonExitedId);
			if (global::Interop.Sys.SchedSetAffinity(_processId, ref value) != 0)
			{
				throw new Win32Exception();
			}
		}
	}

	private Process(string machineName, bool isRemoteMachine, int processId, ProcessInfo processInfo)
	{
		GC.SuppressFinalize(this);
		_processInfo = processInfo;
		_machineName = machineName;
		_isRemoteMachine = isRemoteMachine;
		_processId = processId;
		_haveProcessId = true;
		_outputStreamReadMode = StreamReadMode.Undefined;
		_errorStreamReadMode = StreamReadMode.Undefined;
	}

	private void EnsureHandleCountPopulated()
	{
		if (_processInfo.HandleCount > 0 || !_haveProcessId || GetHasExited(refresh: false) || !ProcessManager.TryGetProcPid(_processId, out var procPid))
		{
			return;
		}
		string fileDescriptorDirectoryPathForProcess = global::Interop.procfs.GetFileDescriptorDirectoryPathForProcess(procPid);
		if (!Directory.Exists(fileDescriptorDirectoryPathForProcess))
		{
			return;
		}
		try
		{
			_processInfo.HandleCount = Directory.GetFiles(fileDescriptorDirectoryPathForProcess, "*", SearchOption.TopDirectoryOnly).Length;
		}
		catch (DirectoryNotFoundException)
		{
		}
	}

	private void CompletionCallback(object waitHandleContext, bool wasSignaled)
	{
		lock (this)
		{
			if (waitHandleContext == _waitHandle)
			{
				StopWatchingForExit();
				RaiseOnExited();
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			if (disposing)
			{
				Close();
			}
			_disposed = true;
		}
	}

	public void Close()
	{
		if (!Associated)
		{
			return;
		}
		lock (this)
		{
			StopWatchingForExit();
		}
		if (_haveProcessHandle)
		{
			_processHandle.Dispose();
			_processHandle = null;
			_haveProcessHandle = false;
		}
		_haveProcessId = false;
		_isRemoteMachine = false;
		_machineName = ".";
		_raisedOnExited = false;
		try
		{
			if (_standardOutput != null && (_outputStreamReadMode == StreamReadMode.AsyncMode || _outputStreamReadMode == StreamReadMode.Undefined))
			{
				if (_outputStreamReadMode == StreamReadMode.AsyncMode)
				{
					_output?.CancelOperation();
					_output?.Dispose();
				}
				_standardOutput.Close();
			}
			if (_standardError != null && (_errorStreamReadMode == StreamReadMode.AsyncMode || _errorStreamReadMode == StreamReadMode.Undefined))
			{
				if (_errorStreamReadMode == StreamReadMode.AsyncMode)
				{
					_error?.CancelOperation();
					_error?.Dispose();
				}
				_standardError.Close();
			}
			if (_standardInput != null && !_standardInputAccessed)
			{
				_standardInput.Close();
			}
		}
		finally
		{
			_standardOutput = null;
			_standardInput = null;
			_standardError = null;
			_output = null;
			_error = null;
			CloseCore();
			Refresh();
		}
	}

	private void ThrowIfExited(bool refresh)
	{
		if ((_waitStateHolder != null || refresh) && GetHasExited(refresh))
		{
			throw new InvalidOperationException(System.SR.Format("ProcessHasExited", _processId.ToString()));
		}
	}

	private void EnsureState(State state)
	{
		if ((state & State.Associated) != 0 && !Associated)
		{
			throw new InvalidOperationException("NoAssociatedProcess");
		}
		if ((state & State.HaveId) != 0)
		{
			if (!_haveProcessId)
			{
				if (!_haveProcessHandle)
				{
					EnsureState(State.Associated);
					throw new InvalidOperationException("ProcessIdRequired");
				}
				SetProcessId(ProcessManager.GetProcessIdFromHandle(_processHandle));
			}
			if ((state & State.HaveNonExitedId) == State.HaveNonExitedId)
			{
				ThrowIfExited(refresh: false);
			}
		}
		if ((state & State.IsLocal) != 0 && _isRemoteMachine)
		{
			throw new NotSupportedException("NotSupportedRemote");
		}
		if ((state & State.HaveProcessInfo) != 0 && _processInfo == null)
		{
			if ((state & State.HaveNonExitedId) != State.HaveNonExitedId)
			{
				EnsureState(State.HaveNonExitedId);
			}
			_processInfo = ProcessManager.GetProcessInfo(_processId, _machineName);
			if (_processInfo == null)
			{
				throw new InvalidOperationException("NoProcessInfo");
			}
		}
		if ((state & State.Exited) != 0)
		{
			if (!HasExited)
			{
				throw new InvalidOperationException("WaitTillExit");
			}
			if (!_haveProcessHandle)
			{
				throw new InvalidOperationException("NoProcessHandle");
			}
		}
	}

	private void EnsureWorkingSetLimits()
	{
		if (!_haveWorkingSetLimits)
		{
			GetWorkingSetLimits(out _minWorkingSet, out _maxWorkingSet);
			_haveWorkingSetLimits = true;
		}
	}

	private void SetWorkingSetLimits(nint? min, nint? max)
	{
		SetWorkingSetLimitsCore(min, max, out _minWorkingSet, out _maxWorkingSet);
		_haveWorkingSetLimits = true;
	}

	public static Process GetCurrentProcess()
	{
		return new Process(".", isRemoteMachine: false, Environment.ProcessId, null);
	}

	protected void OnExited()
	{
		EventHandler onExited = _onExited;
		if (onExited != null)
		{
			ISynchronizeInvoke synchronizingObject = SynchronizingObject;
			if (synchronizingObject != null && synchronizingObject.InvokeRequired)
			{
				synchronizingObject.BeginInvoke(onExited, new object[2]
				{
					this,
					EventArgs.Empty
				});
			}
			else
			{
				onExited(this, EventArgs.Empty);
			}
		}
	}

	private void RaiseOnExited()
	{
		if (_raisedOnExited)
		{
			return;
		}
		lock (this)
		{
			if (!_raisedOnExited)
			{
				_raisedOnExited = true;
				OnExited();
			}
		}
	}

	public void Refresh()
	{
		_processInfo = null;
		_threads?.Dispose();
		_threads = null;
		_modules?.Dispose();
		_modules = null;
		_exited = false;
		_haveWorkingSetLimits = false;
		_haveProcessorAffinity = false;
		_havePriorityClass = false;
		_haveExitTime = false;
		_havePriorityBoostEnabled = false;
	}

	private SafeProcessHandle GetOrOpenProcessHandle()
	{
		if (!_haveProcessHandle)
		{
			CheckDisposed();
			SetProcessHandle(GetProcessHandle());
		}
		return _processHandle;
	}

	private void SetProcessHandle(SafeProcessHandle processHandle)
	{
		_processHandle = processHandle;
		_haveProcessHandle = true;
		if (_watchForExit)
		{
			EnsureWatchingForExit();
		}
	}

	private void SetProcessId(int processId)
	{
		_processId = processId;
		_haveProcessId = true;
		ConfigureAfterProcessIdSet();
	}

	private void ConfigureAfterProcessIdSet()
	{
		GetWaitState();
	}

	private void StopWatchingForExit()
	{
		if (!_watchingForExit)
		{
			return;
		}
		RegisteredWaitHandle registeredWaitHandle = null;
		WaitHandle waitHandle = null;
		lock (this)
		{
			if (_watchingForExit)
			{
				_watchingForExit = false;
				waitHandle = _waitHandle;
				_waitHandle = null;
				registeredWaitHandle = _registeredWaitHandle;
				_registeredWaitHandle = null;
			}
		}
		registeredWaitHandle?.Unregister(null);
		waitHandle?.Dispose();
	}

	public override string ToString()
	{
		string text = base.ToString();
		try
		{
			if (Associated)
			{
				if (_processInfo == null)
				{
					_processInfo = ProcessManager.GetProcessInfo(_processId, _machineName);
				}
				if (_processInfo != null)
				{
					string processName = _processInfo.ProcessName;
					if (processName.Length != 0)
					{
						text = text + " (" + processName + ")";
					}
				}
			}
		}
		catch
		{
		}
		return text;
	}

	private void CheckDisposed()
	{
		ObjectDisposedException.ThrowIf(_disposed, this);
	}

	private bool GetHasExited(bool refresh)
	{
		int? exitCode;
		return GetWaitState().GetExited(out exitCode, refresh);
	}

	private void CloseCore()
	{
		if (_waitStateHolder != null)
		{
			_waitStateHolder.Dispose();
			_waitStateHolder = null;
		}
	}

	private void EnsureWatchingForExit()
	{
		if (_watchingForExit)
		{
			return;
		}
		lock (this)
		{
			if (!_watchingForExit)
			{
				_watchingForExit = true;
				try
				{
					_waitHandle = new ProcessWaitHandle(GetWaitState());
					_registeredWaitHandle = ThreadPool.RegisterWaitForSingleObject(_waitHandle, CompletionCallback, _waitHandle, -1, executeOnlyOnce: true);
					return;
				}
				catch
				{
					_waitHandle?.Dispose();
					_waitHandle = null;
					_watchingForExit = false;
					throw;
				}
			}
		}
	}

	private void UpdateHasExited()
	{
		_exited = GetWaitState().GetExited(out var exitCode, refresh: true);
		if (_exited && exitCode.HasValue)
		{
			_exitCode = exitCode.Value;
		}
	}

	private SafeProcessHandle GetProcessHandle()
	{
		if (_haveProcessHandle)
		{
			ThrowIfExited(refresh: true);
			return _processHandle;
		}
		EnsureState((State)7);
		return new SafeProcessHandle(_processId, GetSafeWaitHandle());
	}

	internal static TimeSpan TicksToTimeSpan(double ticks)
	{
		long num = Volatile.Read(in s_ticksPerSecond);
		if (num == 0L)
		{
			num = global::Interop.Sys.SysConf(global::Interop.Sys.SysConfName._SC_CLK_TCK);
			if (num <= 0)
			{
				throw new Win32Exception();
			}
			Volatile.Write(ref s_ticksPerSecond, num);
		}
		return TimeSpan.FromSeconds(ticks / (double)num);
	}

	private ProcessWaitState GetWaitState()
	{
		if (_waitStateHolder == null)
		{
			EnsureState(State.HaveId);
			_waitStateHolder = new ProcessWaitState.Holder(_processId);
		}
		return _waitStateHolder._state;
	}

	private SafeWaitHandle GetSafeWaitHandle()
	{
		return GetWaitState().EnsureExitedEvent().GetSafeWaitHandle();
	}

	internal static DateTime BootTimeToDateTime(TimeSpan timespanAfterBoot)
	{
		return (BootTime + timespanAfterBoot).ToLocalTime();
	}

	private void GetWorkingSetLimits(out nint minWorkingSet, out nint maxWorkingSet)
	{
		minWorkingSet = IntPtr.Zero;
		EnsureState(State.HaveNonExitedId);
		if (!global::Interop.cgroups.TryGetMemoryLimit(out var limit))
		{
			limit = GetStat().rsslim;
		}
		switch (8)
		{
		case 4:
			if (limit > int.MaxValue)
			{
				limit = 2147483647uL;
			}
			break;
		case 8:
			if (limit > long.MaxValue)
			{
				limit = 9223372036854775807uL;
			}
			break;
		}
		maxWorkingSet = (nint)limit;
	}

	private void SetWorkingSetLimitsCore(nint? newMin, nint? newMax, out nint resultingMin, out nint resultingMax)
	{
		EnsureState(State.HaveNonExitedId);
		throw new PlatformNotSupportedException("MinimumWorkingSetNotSupported");
	}

	internal static string GetExePath(global::Interop.procfs.ProcPid procPid)
	{
		if (procPid != global::Interop.procfs.ProcPid.Self)
		{
			return global::Interop.Sys.ReadLink(global::Interop.procfs.GetExeFilePathForProcess(procPid).AsSpan());
		}
		return Environment.ProcessPath;
	}

	internal static string GetUntruncatedProcessName(global::Interop.procfs.ProcPid procPid, ref global::Interop.procfs.ParsedStat stat)
	{
		string cmdLinePathForProcess = global::Interop.procfs.GetCmdLinePathForProcess(procPid);
		byte[] array = null;
		try
		{
			using FileStream fileStream = new FileStream(cmdLinePathForProcess, FileMode.Open, FileAccess.Read, FileShare.Read, 1, useAsync: false);
			Span<byte> span = stackalloc byte[512];
			int num = 0;
			int num2;
			do
			{
				if (num == span.Length)
				{
					uint minimumLength = (uint)(span.Length * 2);
					byte[] array2 = ArrayPool<byte>.Shared.Rent((int)minimumLength);
					span.CopyTo(array2);
					byte[] array3 = array;
					span = (array = array2);
					if (array3 != null)
					{
						ArrayPool<byte>.Shared.Return(array3);
					}
				}
				num2 = fileStream.Read(span.Slice(num));
				num += num2;
				ReadOnlySpan<byte> span2 = span.Slice(0, num);
				int num3 = span2.IndexOf<byte>(0);
				if (num3 != -1)
				{
					string text = GetUntruncatedNameFromArg(span2.Slice(0, num3), stat.comm);
					if (text != null)
					{
						return text;
					}
					span2 = span2.Slice(num3 + 1);
					num3 = span2.IndexOf<byte>(0);
					if (num3 != -1)
					{
						text = GetUntruncatedNameFromArg(span2.Slice(0, num3), stat.comm);
						return text ?? stat.comm;
					}
				}
			}
			while (num2 != 0);
			return stat.comm;
		}
		catch (IOException)
		{
			return stat.comm;
		}
		finally
		{
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}
		static string GetUntruncatedNameFromArg(ReadOnlySpan<byte> arg, string prefix)
		{
			int start = arg.LastIndexOf<byte>(47) + 1;
			string text2 = Encoding.UTF8.GetString(arg.Slice(start));
			if (text2.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
			{
				return text2;
			}
			return null;
		}
	}

	private global::Interop.procfs.ParsedStat GetStat()
	{
		EnsureState(State.HaveNonExitedId);
		if (!ProcessManager.TryReadStatFile(_processId, out var stat))
		{
			throw new Win32Exception("ProcessInformationUnavailable");
		}
		return stat;
	}
}
