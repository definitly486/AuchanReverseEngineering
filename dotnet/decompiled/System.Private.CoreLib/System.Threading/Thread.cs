using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Principal;

namespace System.Threading;

[StructLayout(LayoutKind.Sequential)]
public sealed class Thread : CriticalFinalizerObject
{
	private sealed class StartHelper
	{
		internal int _maxStackSize;

		internal Delegate _start;

		internal object _startArg;

		internal CultureInfo _culture;

		internal CultureInfo _uiCulture;

		internal ExecutionContext _executionContext;

		internal static readonly ContextCallback s_threadStartContextCallback = Callback;

		internal StartHelper(Delegate start)
		{
			_start = start;
		}

		private static void Callback(object state)
		{
			((StartHelper)state).RunWorker();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Run()
		{
			if (_executionContext != null && !_executionContext.IsDefault)
			{
				System.Threading.ExecutionContext.RunInternal(_executionContext, s_threadStartContextCallback, this);
			}
			else
			{
				RunWorker();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RunWorker()
		{
			InitializeCulture();
			Delegate start = _start;
			_start = null;
			try
			{
				if (start is ThreadStart threadStart)
				{
					threadStart();
					return;
				}
				ParameterizedThreadStart obj = (ParameterizedThreadStart)start;
				object startArg = _startArg;
				_startArg = null;
				obj(startArg);
			}
			catch (Exception ex) when (ExceptionHandling.IsHandledByGlobalHandler(ex))
			{
			}
		}

		private void InitializeCulture()
		{
			if (_culture != null)
			{
				CultureInfo.CurrentCulture = _culture;
				_culture = null;
			}
			if (_uiCulture != null)
			{
				CultureInfo.CurrentUICulture = _uiCulture;
				_uiCulture = null;
			}
		}
	}

	private static class LocalDataStore
	{
		private static Dictionary<string, LocalDataStoreSlot> s_nameToSlotMap;

		public static LocalDataStoreSlot AllocateSlot()
		{
			return new LocalDataStoreSlot(new ThreadLocal<object>());
		}

		private static Dictionary<string, LocalDataStoreSlot> EnsureNameToSlotMap()
		{
			Dictionary<string, LocalDataStoreSlot> dictionary = s_nameToSlotMap;
			if (dictionary != null)
			{
				return dictionary;
			}
			dictionary = new Dictionary<string, LocalDataStoreSlot>();
			return Interlocked.CompareExchange(ref s_nameToSlotMap, dictionary, null) ?? dictionary;
		}

		public static LocalDataStoreSlot AllocateNamedSlot(string name)
		{
			LocalDataStoreSlot localDataStoreSlot = AllocateSlot();
			Dictionary<string, LocalDataStoreSlot> dictionary = EnsureNameToSlotMap();
			lock (dictionary)
			{
				dictionary.Add(name, localDataStoreSlot);
				return localDataStoreSlot;
			}
		}

		public static LocalDataStoreSlot GetNamedSlot(string name)
		{
			Dictionary<string, LocalDataStoreSlot> dictionary = EnsureNameToSlotMap();
			lock (dictionary)
			{
				if (!dictionary.TryGetValue(name, out var value))
				{
					value = (dictionary[name] = AllocateSlot());
				}
				return value;
			}
		}

		public static void FreeNamedSlot(string name)
		{
			Dictionary<string, LocalDataStoreSlot> dictionary = EnsureNameToSlotMap();
			lock (dictionary)
			{
				dictionary.Remove(name);
			}
		}

		private static ThreadLocal<object> GetThreadLocal(LocalDataStoreSlot slot)
		{
			ArgumentNullException.ThrowIfNull(slot, "slot");
			return slot.Data;
		}

		public static object GetData(LocalDataStoreSlot slot)
		{
			return GetThreadLocal(slot).Value;
		}

		public static void SetData(LocalDataStoreSlot slot, object value)
		{
			GetThreadLocal(slot).Value = value;
		}
	}

	private int lock_thread_id;

	private nint handle;

	private nint native_handle;

	private nint name;

	private int name_free;

	private int name_length;

	private ThreadState state;

	private object abort_exc;

	private int abort_state_handle;

	internal long thread_id;

	private nint debugger_thread;

	private nuint static_data;

	private nint runtime_thread_info;

	private int interruption_requested;

	private nint longlived;

	internal bool threadpool_thread;

	internal bool external_eventloop;

	internal byte apartment_state;

	internal int managed_id;

	private int small_id;

	private nint manage_callback;

	private nint flags;

	private nint thread_pinning_ref;

	private int priority;

	private nint owned_mutex;

	private nint suspended_event;

	private int self_suspended;

	private nint thread_state;

	private Thread self;

	private object pending_exception;

	private nint last;

	private string _name;

	private StartHelper _startHelper;

	internal ExecutionContext _executionContext;

	internal SynchronizationContext _synchronizationContext;

	internal WaitSubsystem.ThreadWaitInfo _waitInfo;

	private bool _mayNeedResetForThreadPool;

	private static AsyncLocal<IPrincipal> s_asyncLocalPrincipal;

	[ThreadStatic]
	private static Thread t_currentThread;

	public bool IsAlive => (GetState(this) & (ThreadState.Unstarted | ThreadState.Stopped | ThreadState.Aborted)) == 0;

	public bool IsBackground
	{
		get
		{
			return (ValidateThreadState() & ThreadState.Background) != 0;
		}
		set
		{
			ValidateThreadState();
			if (value)
			{
				SetState(this, ThreadState.Background);
				return;
			}
			ClrState(this, ThreadState.Background);
			_mayNeedResetForThreadPool = true;
		}
	}

	public bool IsThreadPoolThread
	{
		get
		{
			ValidateThreadState();
			return threadpool_thread;
		}
		internal set
		{
			threadpool_thread = value;
		}
	}

	public int ManagedThreadId => managed_id;

	internal WaitSubsystem.ThreadWaitInfo WaitInfo
	{
		get
		{
			return Volatile.Read(in _waitInfo) ?? AllocateWaitInfo();
			WaitSubsystem.ThreadWaitInfo AllocateWaitInfo()
			{
				Interlocked.CompareExchange(ref _waitInfo, new WaitSubsystem.ThreadWaitInfo(this), null);
				return _waitInfo;
			}
		}
	}

	public ThreadPriority Priority
	{
		get
		{
			ValidateThreadState();
			return (ThreadPriority)priority;
		}
		set
		{
			SetPriority(this, (int)value);
			if (value != ThreadPriority.Normal)
			{
				_mayNeedResetForThreadPool = true;
			}
		}
	}

	public ThreadState ThreadState => GetState(this);

	public CultureInfo CurrentCulture
	{
		get
		{
			RequireCurrentThread();
			return CultureInfo.CurrentCulture;
		}
		set
		{
			if (this != CurrentThread)
			{
				SetCultureOnUnstartedThread(value, uiCulture: false);
			}
			else
			{
				CultureInfo.CurrentCulture = value;
			}
		}
	}

	public CultureInfo CurrentUICulture
	{
		get
		{
			RequireCurrentThread();
			return CultureInfo.CurrentUICulture;
		}
		set
		{
			if (this != CurrentThread)
			{
				SetCultureOnUnstartedThread(value, uiCulture: true);
			}
			else
			{
				CultureInfo.CurrentUICulture = value;
			}
		}
	}

	public static IPrincipal? CurrentPrincipal
	{
		get
		{
			IPrincipal principal = s_asyncLocalPrincipal?.Value;
			if (principal == null)
			{
				principal = (CurrentPrincipal = AppDomain.CurrentDomain.GetThreadPrincipal());
			}
			return principal;
		}
		set
		{
			if (s_asyncLocalPrincipal == null)
			{
				if (value == null)
				{
					return;
				}
				Interlocked.CompareExchange(ref s_asyncLocalPrincipal, new AsyncLocal<IPrincipal>(), null);
			}
			s_asyncLocalPrincipal.Value = value;
		}
	}

	public static Thread CurrentThread
	{
		[Intrinsic]
		get
		{
			return t_currentThread ?? InitializeCurrentThread();
		}
	}

	internal static ulong CurrentOSThreadId => GetCurrentOSThreadId();

	public ExecutionContext? ExecutionContext => System.Threading.ExecutionContext.Capture();

	public string? Name
	{
		get
		{
			return _name;
		}
		set
		{
			lock (this)
			{
				if (_name != value)
				{
					_name = value;
					ThreadNameChanged(value);
					_mayNeedResetForThreadPool = true;
				}
			}
		}
	}

	[Obsolete("The ApartmentState property has been deprecated. Use GetApartmentState, SetApartmentState or TrySetApartmentState instead.")]
	public ApartmentState ApartmentState
	{
		get
		{
			return ApartmentState.Unknown;
		}
		set
		{
			TrySetApartmentState(value);
		}
	}

	private Thread()
	{
		Initialize();
	}

	~Thread()
	{
		FreeInternal();
	}

	public ApartmentState GetApartmentState()
	{
		return ApartmentState.Unknown;
	}

	public void DisableComObjectEagerCleanup()
	{
	}

	public void Interrupt()
	{
		WaitSubsystem.Interrupt(this);
		InterruptInternal(this);
	}

	public bool Join(int millisecondsTimeout)
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(millisecondsTimeout, -1, "millisecondsTimeout");
		return JoinInternal(this, millisecondsTimeout);
	}

	private void Initialize()
	{
		InitInternal(this);
	}

	public static void SpinWait(int iterations)
	{
		if (iterations >= 0)
		{
			while (iterations-- > 0)
			{
				SpinWait_nop();
			}
		}
	}

	internal void StartCallback()
	{
		StartHelper startHelper = _startHelper;
		_startHelper = null;
		startHelper.Run();
	}

	internal static void ThrowThreadStartException(Exception ex)
	{
		throw new ThreadStartException(ex);
	}

	private void StartCore()
	{
		StartInternal(this, _startHelper?._maxStackSize ?? 0);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void StartInternal(Thread runtimeThread, int stackSize);

	private void ThreadNameChanged(string value)
	{
		SetName(this, value);
	}

	public static bool Yield()
	{
		return YieldInternal();
	}

	private static bool SetApartmentStateUnchecked(ApartmentState state, bool throwOnError)
	{
		if (state != ApartmentState.Unknown)
		{
			if (throwOnError)
			{
				throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
			}
			return false;
		}
		return true;
	}

	private ThreadState ValidateThreadState()
	{
		ThreadState num = GetState(this);
		if ((num & ThreadState.Stopped) != ThreadState.Running)
		{
			throw new ThreadStateException("ThreadState_Dead_State");
		}
		return num;
	}

	internal void SetWaitSleepJoinState()
	{
		SetState(this, ThreadState.WaitSleepJoin);
	}

	internal void ClearWaitSleepJoinState()
	{
		ClrState(this, ThreadState.WaitSleepJoin);
	}

	private static void OnThreadExiting(Thread thread)
	{
		thread.WaitInfo.OnThreadExiting();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern ulong GetCurrentOSThreadId();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[MemberNotNull("self")]
	private static extern void InitInternal(Thread thread);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Thread GetCurrentThread();

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Thread InitializeCurrentThread()
	{
		t_currentThread = GetCurrentThread();
		return t_currentThread;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern void FreeInternal();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern ThreadState GetState(Thread thread);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetState(Thread thread, ThreadState set);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ClrState(Thread thread, ThreadState clr);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern void SetName_icall(Thread thread, char* name, int nameLength);

	private unsafe static void SetName(Thread thread, string name)
	{
		fixed (char* ptr = name)
		{
			SetName_icall(thread, ptr, name?.Length ?? 0);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool YieldInternal();

	[Intrinsic]
	private static void SpinWait_nop()
	{
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool JoinInternal(Thread thread, int millisecondsTimeout);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void InterruptInternal(Thread thread);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetPriority(Thread thread, int priority);

	internal int GetSmallId()
	{
		return small_id;
	}

	public Thread(ThreadStart start)
	{
		ArgumentNullException.ThrowIfNull(start, "start");
		_startHelper = new StartHelper(start);
		Initialize();
	}

	public Thread(ThreadStart start, int maxStackSize)
	{
		ArgumentNullException.ThrowIfNull(start, "start");
		ArgumentOutOfRangeException.ThrowIfNegative(maxStackSize, "maxStackSize");
		_startHelper = new StartHelper(start)
		{
			_maxStackSize = maxStackSize
		};
		Initialize();
	}

	public Thread(ParameterizedThreadStart start)
	{
		ArgumentNullException.ThrowIfNull(start, "start");
		_startHelper = new StartHelper(start);
		Initialize();
	}

	public Thread(ParameterizedThreadStart start, int maxStackSize)
	{
		ArgumentNullException.ThrowIfNull(start, "start");
		ArgumentOutOfRangeException.ThrowIfNegative(maxStackSize, "maxStackSize");
		_startHelper = new StartHelper(start)
		{
			_maxStackSize = maxStackSize
		};
		Initialize();
	}

	internal static void ThrowIfNoThreadStart()
	{
		_ = 1;
	}

	[UnsupportedOSPlatform("browser")]
	public void Start(object? parameter)
	{
		Start(parameter, captureContext: true);
	}

	[UnsupportedOSPlatform("browser")]
	public void UnsafeStart(object? parameter)
	{
		Start(parameter, captureContext: false);
	}

	private void Start(object parameter, bool captureContext)
	{
		ThrowIfNoThreadStart();
		StartHelper startHelper = _startHelper;
		if (startHelper != null)
		{
			if (startHelper._start is ThreadStart)
			{
				throw new InvalidOperationException("InvalidOperation_ThreadWrongThreadStart");
			}
			startHelper._startArg = parameter;
			startHelper._executionContext = (captureContext ? System.Threading.ExecutionContext.Capture() : null);
		}
		StartCore();
	}

	[UnsupportedOSPlatform("browser")]
	public void Start()
	{
		Start(captureContext: true);
	}

	[UnsupportedOSPlatform("browser")]
	public void UnsafeStart()
	{
		Start(captureContext: false);
	}

	private void Start(bool captureContext)
	{
		ThrowIfNoThreadStart();
		StartHelper startHelper = _startHelper;
		if (startHelper != null)
		{
			startHelper._startArg = null;
			startHelper._executionContext = (captureContext ? System.Threading.ExecutionContext.Capture() : null);
		}
		StartCore();
	}

	private void RequireCurrentThread()
	{
		if (this != CurrentThread)
		{
			throw new InvalidOperationException("Thread_Operation_RequiresCurrentThread");
		}
	}

	private void SetCultureOnUnstartedThread(CultureInfo value, bool uiCulture)
	{
		ArgumentNullException.ThrowIfNull(value, "value");
		StartHelper startHelper = _startHelper;
		if ((ThreadState & ThreadState.Unstarted) == 0)
		{
			throw new InvalidOperationException("Thread_Operation_RequiresCurrentThread");
		}
		if (uiCulture)
		{
			startHelper._uiCulture = value;
		}
		else
		{
			startHelper._culture = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Sleep(int millisecondsTimeout)
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(millisecondsTimeout, -1, "millisecondsTimeout");
		SleepInternal(millisecondsTimeout);
	}

	internal void SetThreadPoolWorkerThreadName()
	{
		lock (this)
		{
			_name = ".NET TP Worker";
			ThreadNameChanged(".NET TP Worker");
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal void ResetThreadPoolThread()
	{
		if (_mayNeedResetForThreadPool)
		{
			ResetThreadPoolThreadSlow();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetThreadPoolThreadSlow()
	{
		_mayNeedResetForThreadPool = false;
		if (_name != ".NET TP Worker")
		{
			SetThreadPoolWorkerThreadName();
		}
		if (!IsBackground)
		{
			IsBackground = true;
		}
		if (Priority != ThreadPriority.Normal)
		{
			Priority = ThreadPriority.Normal;
		}
	}

	[Obsolete("Thread.Abort is not supported and throws PlatformNotSupportedException.", DiagnosticId = "SYSLIB0006", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public void Abort()
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ThreadAbort");
	}

	[Obsolete("Thread.Abort is not supported and throws PlatformNotSupportedException.", DiagnosticId = "SYSLIB0006", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public void Abort(object? stateInfo)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ThreadAbort");
	}

	[Obsolete("Thread.ResetAbort is not supported and throws PlatformNotSupportedException.", DiagnosticId = "SYSLIB0006", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public static void ResetAbort()
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ThreadAbort");
	}

	[Obsolete("Thread.Suspend has been deprecated. Use other classes in System.Threading, such as Monitor, Mutex, Event, and Semaphore, to synchronize Threads or protect resources.")]
	public void Suspend()
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ThreadSuspend");
	}

	[Obsolete("Thread.Resume has been deprecated. Use other classes in System.Threading, such as Monitor, Mutex, Event, and Semaphore, to synchronize Threads or protect resources.")]
	public void Resume()
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ThreadSuspend");
	}

	public static void BeginCriticalRegion()
	{
	}

	public static void EndCriticalRegion()
	{
	}

	public static void BeginThreadAffinity()
	{
	}

	public static void EndThreadAffinity()
	{
	}

	public static LocalDataStoreSlot AllocateDataSlot()
	{
		return LocalDataStore.AllocateSlot();
	}

	public static LocalDataStoreSlot AllocateNamedDataSlot(string name)
	{
		return LocalDataStore.AllocateNamedSlot(name);
	}

	public static LocalDataStoreSlot GetNamedDataSlot(string name)
	{
		return LocalDataStore.GetNamedSlot(name);
	}

	public static void FreeNamedDataSlot(string name)
	{
		LocalDataStore.FreeNamedSlot(name);
	}

	public static object? GetData(LocalDataStoreSlot slot)
	{
		return LocalDataStore.GetData(slot);
	}

	public static void SetData(LocalDataStoreSlot slot, object? data)
	{
		LocalDataStore.SetData(slot, data);
	}

	[SupportedOSPlatform("windows")]
	public void SetApartmentState(ApartmentState state)
	{
		SetApartmentState(state, throwOnError: true);
	}

	public bool TrySetApartmentState(ApartmentState state)
	{
		return SetApartmentState(state, throwOnError: false);
	}

	private bool SetApartmentState(ApartmentState state, bool throwOnError)
	{
		if ((uint)state > 2u)
		{
			throw new ArgumentOutOfRangeException("state", "ArgumentOutOfRange_Enum");
		}
		return SetApartmentStateUnchecked(state, throwOnError);
	}

	[Obsolete("Code Access Security is not supported or honored by the runtime.", DiagnosticId = "SYSLIB0003", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public CompressedStack GetCompressedStack()
	{
		throw new InvalidOperationException("Thread_GetSetCompressedStack_NotSupported");
	}

	[Obsolete("Code Access Security is not supported or honored by the runtime.", DiagnosticId = "SYSLIB0003", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public void SetCompressedStack(CompressedStack stack)
	{
		throw new InvalidOperationException("Thread_GetSetCompressedStack_NotSupported");
	}

	public static AppDomain GetDomain()
	{
		return AppDomain.CurrentDomain;
	}

	public static int GetDomainID()
	{
		return 1;
	}

	public override int GetHashCode()
	{
		return ManagedThreadId;
	}

	public void Join()
	{
		Join(-1);
	}

	public bool Join(TimeSpan timeout)
	{
		return Join(WaitHandle.ToTimeoutMilliseconds(timeout));
	}

	public static void MemoryBarrier()
	{
		Interlocked.MemoryBarrier();
	}

	public static void Sleep(TimeSpan timeout)
	{
		Sleep(WaitHandle.ToTimeoutMilliseconds(timeout));
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static byte VolatileRead(ref byte address)
	{
		return Volatile.Read(in address);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static double VolatileRead(ref double address)
	{
		return Volatile.Read(in address);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static short VolatileRead(ref short address)
	{
		return Volatile.Read(in address);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static int VolatileRead(ref int address)
	{
		return Volatile.Read(in address);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static long VolatileRead(ref long address)
	{
		return Volatile.Read(in address);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static nint VolatileRead(ref nint address)
	{
		return Volatile.Read(in address);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[return: NotNullIfNotNull("address")]
	public static object? VolatileRead([NotNullIfNotNull("address")] ref object? address)
	{
		return Volatile.Read(in address);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CLSCompliant(false)]
	public static sbyte VolatileRead(ref sbyte address)
	{
		return Volatile.Read(in address);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static float VolatileRead(ref float address)
	{
		return Volatile.Read(in address);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CLSCompliant(false)]
	public static ushort VolatileRead(ref ushort address)
	{
		return Volatile.Read(in address);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CLSCompliant(false)]
	public static uint VolatileRead(ref uint address)
	{
		return Volatile.Read(in address);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CLSCompliant(false)]
	public static ulong VolatileRead(ref ulong address)
	{
		return Volatile.Read(in address);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CLSCompliant(false)]
	public static nuint VolatileRead(ref nuint address)
	{
		return Volatile.Read(in address);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void VolatileWrite(ref byte address, byte value)
	{
		Volatile.Write(ref address, value);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void VolatileWrite(ref double address, double value)
	{
		Volatile.Write(ref address, value);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void VolatileWrite(ref short address, short value)
	{
		Volatile.Write(ref address, value);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void VolatileWrite(ref int address, int value)
	{
		Volatile.Write(ref address, value);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void VolatileWrite(ref long address, long value)
	{
		Volatile.Write(ref address, value);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void VolatileWrite(ref nint address, nint value)
	{
		Volatile.Write(ref address, value);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void VolatileWrite([NotNullIfNotNull("value")] ref object? address, object? value)
	{
		Volatile.Write(ref address, value);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CLSCompliant(false)]
	public static void VolatileWrite(ref sbyte address, sbyte value)
	{
		Volatile.Write(ref address, value);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void VolatileWrite(ref float address, float value)
	{
		Volatile.Write(ref address, value);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CLSCompliant(false)]
	public static void VolatileWrite(ref ushort address, ushort value)
	{
		Volatile.Write(ref address, value);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CLSCompliant(false)]
	public static void VolatileWrite(ref uint address, uint value)
	{
		Volatile.Write(ref address, value);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CLSCompliant(false)]
	public static void VolatileWrite(ref ulong address, ulong value)
	{
		Volatile.Write(ref address, value);
	}

	[Obsolete("Thread.VolatileRead and Thread.VolatileWrite are obsolete. Use Volatile.Read or Volatile.Write respectively instead.", DiagnosticId = "SYSLIB0054", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CLSCompliant(false)]
	public static void VolatileWrite(ref nuint address, nuint value)
	{
		Volatile.Write(ref address, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int GetCurrentProcessorId()
	{
		return ProcessorIdCache.GetCurrentProcessorId();
	}

	internal static void UninterruptibleSleep0()
	{
		Yield();
	}

	private static void SleepInternal(int millisecondsTimeout)
	{
		WaitSubsystem.Sleep(millisecondsTimeout);
	}

	internal static int GetCurrentProcessorNumber()
	{
		return Interop.Sys.SchedGetCpu();
	}
}
