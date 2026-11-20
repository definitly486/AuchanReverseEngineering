using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Mono;

namespace System.Runtime.Loader;

public class AssemblyLoadContext
{
	private enum InternalState
	{
		Alive,
		Unloading
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct ContextualReflectionScope : IDisposable
	{
		private readonly AssemblyLoadContext _activated;

		private readonly AssemblyLoadContext _predecessor;

		private readonly bool _initialized;

		internal ContextualReflectionScope(AssemblyLoadContext activating)
		{
			_predecessor = CurrentContextualReflectionContext;
			SetCurrentContextualReflectionContext(activating);
			_activated = activating;
			_initialized = true;
		}

		public void Dispose()
		{
			if (_initialized)
			{
				SetCurrentContextualReflectionContext(_predecessor);
			}
		}
	}

	private static Dictionary<long, WeakReference<AssemblyLoadContext>> s_allContexts;

	private static long s_nextId;

	private readonly nint _nativeAssemblyLoadContext;

	private readonly object _unloadLock;

	[CompilerGenerated]
	private Func<Assembly, string, nint> _resolvingUnmanagedDll;

	[CompilerGenerated]
	private Func<AssemblyLoadContext, AssemblyName, Assembly> _resolving;

	[CompilerGenerated]
	private Action<AssemblyLoadContext> _unloading;

	private readonly string _name;

	private readonly long _id;

	private InternalState _state;

	private readonly bool _isCollectible;

	[CompilerGenerated]
	private static AssemblyLoadEventHandler AssemblyLoad;

	[CompilerGenerated]
	private static ResolveEventHandler TypeResolve;

	[CompilerGenerated]
	private static ResolveEventHandler ResourceResolve;

	[CompilerGenerated]
	private static ResolveEventHandler AssemblyResolve;

	private static AsyncLocal<AssemblyLoadContext> s_asyncLocalCurrent;

	internal nint NativeALC => _nativeAssemblyLoadContext;

	[MemberNotNull("s_allContexts")]
	private static Dictionary<long, WeakReference<AssemblyLoadContext>> AllContexts
	{
		[MemberNotNull("s_allContexts")]
		get
		{
			return s_allContexts ?? Interlocked.CompareExchange(ref s_allContexts, new Dictionary<long, WeakReference<AssemblyLoadContext>>(), null) ?? s_allContexts;
		}
	}

	public IEnumerable<Assembly> Assemblies
	{
		get
		{
			Assembly[] loadedAssemblies = GetLoadedAssemblies();
			foreach (Assembly assembly in loadedAssemblies)
			{
				if (GetLoadContext(assembly) == this)
				{
					yield return assembly;
				}
			}
		}
	}

	public static AssemblyLoadContext Default => DefaultAssemblyLoadContext.s_loadContext;

	public bool IsCollectible => _isCollectible;

	public string? Name => _name;

	public static IEnumerable<AssemblyLoadContext> All
	{
		get
		{
			_ = Default;
			Dictionary<long, WeakReference<AssemblyLoadContext>> dictionary = s_allContexts;
			WeakReference<AssemblyLoadContext>[] array;
			lock (dictionary)
			{
				array = new WeakReference<AssemblyLoadContext>[dictionary.Count];
				int num = 0;
				foreach (KeyValuePair<long, WeakReference<AssemblyLoadContext>> item in dictionary)
				{
					array[num++] = item.Value;
				}
			}
			WeakReference<AssemblyLoadContext>[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i].TryGetTarget(out var target))
				{
					yield return target;
				}
			}
		}
	}

	public static AssemblyLoadContext? CurrentContextualReflectionContext => s_asyncLocalCurrent?.Value;

	private event Func<Assembly, string, nint>? _resolvingUnmanagedDll;

	private event Func<AssemblyLoadContext, AssemblyName, Assembly>? _resolving;

	private event Action<AssemblyLoadContext>? _unloading;

	public event Func<Assembly, string, nint>? ResolvingUnmanagedDll
	{
		add
		{
			_resolvingUnmanagedDll += value;
		}
		remove
		{
			_resolvingUnmanagedDll -= value;
		}
	}

	public event Func<AssemblyLoadContext, AssemblyName, Assembly?>? Resolving
	{
		add
		{
			_resolving += value;
		}
		remove
		{
			_resolving -= value;
		}
	}

	public event Action<AssemblyLoadContext>? Unloading
	{
		add
		{
			_unloading += value;
		}
		remove
		{
			_unloading -= value;
		}
	}

	internal static event AssemblyLoadEventHandler? AssemblyLoad;

	internal static event ResolveEventHandler? TypeResolve;

	internal static event ResolveEventHandler? ResourceResolve;

	internal static event ResolveEventHandler? AssemblyResolve;

	private nint InitializeAssemblyLoadContext(nint thisHandlePtr, bool representsTPALoadContext, bool isCollectible)
	{
		if (isCollectible)
		{
			KeepLoaderAllocator();
		}
		using SafeStringMarshal safeStringMarshal = new SafeStringMarshal(Name);
		return InternalInitializeNativeALC(thisHandlePtr, safeStringMarshal.Value, representsTPALoadContext, isCollectible);
	}

	private static void KeepLoaderAllocator()
	{
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void PrepareForAssemblyLoadContextRelease(nint nativeAssemblyLoadContext, nint assemblyLoadContextStrong);

	[RequiresUnreferencedCode("Types and members the loaded assembly depends on might be removed")]
	private Assembly InternalLoadFromPath(string assemblyPath, string nativeImagePath)
	{
		StackCrawlMark stackMark = StackCrawlMark.LookForMyCaller;
		assemblyPath = assemblyPath?.Replace('\\', Path.DirectorySeparatorChar);
		return InternalLoadFile(NativeALC, assemblyPath, ref stackMark);
	}

	[RequiresUnreferencedCode("Types and members the loaded assembly depends on might be removed")]
	internal unsafe Assembly InternalLoad(ReadOnlySpan<byte> arrAssembly, ReadOnlySpan<byte> arrSymbols)
	{
		fixed (byte* value = arrAssembly)
		{
			fixed (byte* value2 = arrSymbols)
			{
				return InternalLoadFromStream(NativeALC, new IntPtr(value), arrAssembly.Length, new IntPtr(value2), arrSymbols.Length);
			}
		}
	}

	internal static Assembly[] GetLoadedAssemblies()
	{
		return InternalGetLoadedAssemblies();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint GetLoadContextForAssembly(RuntimeAssembly rtAsm);

	public static AssemblyLoadContext? GetLoadContext(Assembly assembly)
	{
		ArgumentNullException.ThrowIfNull(assembly, "assembly");
		AssemblyLoadContext result = null;
		RuntimeAssembly runtimeAssembly = assembly as RuntimeAssembly;
		if (runtimeAssembly != null)
		{
			_ = Default;
			result = GetAssemblyLoadContext(GetLoadContextForAssembly(runtimeAssembly));
		}
		return result;
	}

	public void SetProfileOptimizationRoot(string directoryPath)
	{
	}

	public void StartProfileOptimization(string? profile)
	{
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[RequiresUnreferencedCode("Types and members the loaded assembly depends on might be removed")]
	private static extern Assembly InternalLoadFile(nint nativeAssemblyLoadContext, string assemblyFile, ref StackCrawlMark stackMark);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint InternalInitializeNativeALC(nint thisHandlePtr, nint name, bool representsTPALoadContext, bool isCollectible);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[RequiresUnreferencedCode("Types and members the loaded assembly depends on might be removed")]
	private static extern Assembly InternalLoadFromStream(nint nativeAssemblyLoadContext, nint assm, int assmLength, nint symbols, int symbolsLength);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Assembly[] InternalGetLoadedAssemblies();

	private static RuntimeAssembly MonoResolveUsingLoad(nint gchALC, string assemblyName)
	{
		return Resolve(gchALC, new AssemblyName(assemblyName));
	}

	private static RuntimeAssembly MonoResolveUsingResolvingEvent(nint gchALC, string assemblyName)
	{
		return GetAssemblyLoadContext(gchALC).ResolveUsingEvent(new AssemblyName(assemblyName));
	}

	private static RuntimeAssembly MonoResolveUsingResolveSatelliteAssembly(nint gchALC, string assemblyName)
	{
		return GetAssemblyLoadContext(gchALC).ResolveSatelliteAssembly(new AssemblyName(assemblyName));
	}

	private static AssemblyLoadContext GetAssemblyLoadContext(nint gchAssemblyLoadContext)
	{
		if (gchAssemblyLoadContext == IntPtr.Zero)
		{
			return Default;
		}
		return (AssemblyLoadContext)GCHandle.FromIntPtr(gchAssemblyLoadContext).Target;
	}

	private static void MonoResolveUnmanagedDll(string unmanagedDllName, nint gchAssemblyLoadContext, ref nint dll)
	{
		AssemblyLoadContext assemblyLoadContext = GetAssemblyLoadContext(gchAssemblyLoadContext);
		dll = assemblyLoadContext.LoadUnmanagedDll(unmanagedDllName);
	}

	private static void MonoResolveUnmanagedDllUsingEvent(string unmanagedDllName, Assembly assembly, nint gchAssemblyLoadContext, ref nint dll)
	{
		AssemblyLoadContext assemblyLoadContext = GetAssemblyLoadContext(gchAssemblyLoadContext);
		dll = assemblyLoadContext.GetResolvedUnmanagedDll(assembly, unmanagedDllName);
	}

	private static RuntimeAssembly GetRuntimeAssembly(Assembly asm)
	{
		if (!(asm == null))
		{
			if (!(asm is RuntimeAssembly result))
			{
				if (!(asm is AssemblyBuilder o))
				{
					return null;
				}
				return Unsafe.As<RuntimeAssembly>(o);
			}
			return result;
		}
		return null;
	}

	protected AssemblyLoadContext()
		: this(representsTPALoadContext: false, isCollectible: false, null)
	{
	}

	protected AssemblyLoadContext(bool isCollectible)
		: this(representsTPALoadContext: false, isCollectible, null)
	{
	}

	public AssemblyLoadContext(string? name, bool isCollectible = false)
		: this(representsTPALoadContext: false, isCollectible, name)
	{
	}

	private protected AssemblyLoadContext(bool representsTPALoadContext, bool isCollectible, string name)
	{
		_isCollectible = isCollectible;
		_name = name;
		_unloadLock = new object();
		if (!isCollectible)
		{
			GC.SuppressFinalize(this);
		}
		_nativeAssemblyLoadContext = InitializeAssemblyLoadContext(GCHandle.ToIntPtr(GCHandle.Alloc(this, IsCollectible ? GCHandleType.WeakTrackResurrection : GCHandleType.Normal)), representsTPALoadContext, isCollectible);
		Dictionary<long, WeakReference<AssemblyLoadContext>> allContexts = AllContexts;
		lock (allContexts)
		{
			_id = s_nextId++;
			allContexts.Add(_id, new WeakReference<AssemblyLoadContext>(this, trackResurrection: true));
		}
	}

	~AssemblyLoadContext()
	{
		if (_unloadLock != null)
		{
			InitiateUnload();
		}
	}

	private void RaiseUnloadEvent()
	{
		Interlocked.Exchange(ref this._unloading, null)?.Invoke(this);
	}

	private void InitiateUnload()
	{
		RaiseUnloadEvent();
		InternalState state;
		lock (_unloadLock)
		{
			state = _state;
			if (state == InternalState.Alive)
			{
				nint assemblyLoadContextStrong = GCHandle.ToIntPtr(GCHandle.Alloc(this, GCHandleType.Normal));
				PrepareForAssemblyLoadContextRelease(_nativeAssemblyLoadContext, assemblyLoadContextStrong);
				_state = InternalState.Unloading;
			}
		}
		if (state == InternalState.Alive)
		{
			Dictionary<long, WeakReference<AssemblyLoadContext>> allContexts = AllContexts;
			lock (allContexts)
			{
				allContexts.Remove(_id);
			}
		}
	}

	public override string ToString()
	{
		return $"\"{Name}\" {GetType()} #{_id}";
	}

	public static AssemblyName GetAssemblyName(string assemblyPath)
	{
		ArgumentNullException.ThrowIfNull(assemblyPath, "assemblyPath");
		return AssemblyName.GetAssemblyName(assemblyPath);
	}

	protected virtual Assembly? Load(AssemblyName assemblyName)
	{
		return null;
	}

	public Assembly LoadFromAssemblyName(AssemblyName assemblyName)
	{
		ArgumentNullException.ThrowIfNull(assemblyName, "assemblyName");
		StackCrawlMark stackMark = StackCrawlMark.LookForMyCaller;
		return RuntimeAssembly.InternalLoad(assemblyName, ref stackMark, this);
	}

	[RequiresUnreferencedCode("Types and members the loaded assembly depends on might be removed")]
	public Assembly LoadFromAssemblyPath(string assemblyPath)
	{
		ArgumentNullException.ThrowIfNull(assemblyPath, "assemblyPath");
		if (PathInternal.IsPartiallyQualified(assemblyPath.AsSpan()))
		{
			throw new ArgumentException(SR.Format("Argument_AbsolutePathRequired", assemblyPath), "assemblyPath");
		}
		lock (_unloadLock)
		{
			VerifyIsAlive();
			return InternalLoadFromPath(assemblyPath, null);
		}
	}

	[RequiresUnreferencedCode("Types and members the loaded assembly depends on might be removed")]
	public Assembly LoadFromNativeImagePath(string nativeImagePath, string? assemblyPath)
	{
		ArgumentNullException.ThrowIfNull(nativeImagePath, "nativeImagePath");
		if (PathInternal.IsPartiallyQualified(nativeImagePath.AsSpan()))
		{
			throw new ArgumentException(SR.Format("Argument_AbsolutePathRequired", nativeImagePath), "nativeImagePath");
		}
		if (assemblyPath != null && PathInternal.IsPartiallyQualified(assemblyPath.AsSpan()))
		{
			throw new ArgumentException(SR.Format("Argument_AbsolutePathRequired", assemblyPath), "assemblyPath");
		}
		lock (_unloadLock)
		{
			VerifyIsAlive();
			return InternalLoadFromPath(assemblyPath, nativeImagePath);
		}
	}

	[RequiresUnreferencedCode("Types and members the loaded assembly depends on might be removed")]
	public Assembly LoadFromStream(Stream assembly)
	{
		return LoadFromStream(assembly, null);
	}

	[RequiresUnreferencedCode("Types and members the loaded assembly depends on might be removed")]
	public Assembly LoadFromStream(Stream assembly, Stream? assemblySymbols)
	{
		ArgumentNullException.ThrowIfNull(assembly, "assembly");
		ReadOnlySpan<byte> arrAssembly = ReadAllBytes(assembly);
		if (arrAssembly.IsEmpty)
		{
			throw new BadImageFormatException("BadImageFormat_BadILFormat");
		}
		ReadOnlySpan<byte> arrSymbols = default(ReadOnlySpan<byte>);
		if (assemblySymbols != null)
		{
			arrSymbols = ReadAllBytes(assemblySymbols);
		}
		lock (_unloadLock)
		{
			VerifyIsAlive();
			return InternalLoad(arrAssembly, arrSymbols);
		}
		static ReadOnlySpan<byte> ReadAllBytes(Stream stream)
		{
			if (stream.GetType() == typeof(MemoryStream) && ((MemoryStream)stream).TryGetBuffer(out var buffer))
			{
				int start = (int)stream.Position;
				stream.Seek(0L, SeekOrigin.End);
				return buffer.AsSpan(start);
			}
			long num = stream.Length - stream.Position;
			if (num == 0L)
			{
				return ReadOnlySpan<byte>.Empty;
			}
			if ((ulong)num > 2147483591uL)
			{
				throw new BadImageFormatException("BadImageFormat_BadILFormat");
			}
			byte[] array = GC.AllocateUninitializedArray<byte>((int)num);
			stream.ReadExactly(array);
			return array;
		}
	}

	protected nint LoadUnmanagedDllFromPath(string unmanagedDllPath)
	{
		ArgumentException.ThrowIfNullOrEmpty(unmanagedDllPath, "unmanagedDllPath");
		if (PathInternal.IsPartiallyQualified(unmanagedDllPath.AsSpan()))
		{
			throw new ArgumentException(SR.Format("Argument_AbsolutePathRequired", unmanagedDllPath), "unmanagedDllPath");
		}
		return NativeLibrary.Load(unmanagedDllPath);
	}

	protected virtual nint LoadUnmanagedDll(string unmanagedDllName)
	{
		return IntPtr.Zero;
	}

	public void Unload()
	{
		if (!IsCollectible)
		{
			throw new InvalidOperationException("AssemblyLoadContext_Unload_CannotUnloadIfNotCollectible");
		}
		GC.SuppressFinalize(this);
		InitiateUnload();
	}

	internal static void OnProcessExit()
	{
		Dictionary<long, WeakReference<AssemblyLoadContext>> dictionary = s_allContexts;
		if (dictionary == null)
		{
			return;
		}
		lock (dictionary)
		{
			foreach (KeyValuePair<long, WeakReference<AssemblyLoadContext>> item in dictionary)
			{
				if (item.Value.TryGetTarget(out var target))
				{
					target.RaiseUnloadEvent();
				}
			}
		}
	}

	private void VerifyIsAlive()
	{
		if (_state != InternalState.Alive)
		{
			throw new InvalidOperationException("AssemblyLoadContext_Verify_NotUnloading");
		}
	}

	private static void SetCurrentContextualReflectionContext(AssemblyLoadContext value)
	{
		if (s_asyncLocalCurrent == null)
		{
			Interlocked.CompareExchange(ref s_asyncLocalCurrent, new AsyncLocal<AssemblyLoadContext>(), null);
		}
		s_asyncLocalCurrent.Value = value;
	}

	public ContextualReflectionScope EnterContextualReflection()
	{
		return new ContextualReflectionScope(this);
	}

	public static ContextualReflectionScope EnterContextualReflection(Assembly? activating)
	{
		if (activating == null)
		{
			return new ContextualReflectionScope(null);
		}
		return (GetLoadContext(activating) ?? throw new ArgumentException("Arg_MustBeRuntimeAssembly", "activating")).EnterContextualReflection();
	}

	private static RuntimeAssembly Resolve(nint gchAssemblyLoadContext, AssemblyName assemblyName)
	{
		return ((AssemblyLoadContext)GCHandle.FromIntPtr(gchAssemblyLoadContext).Target).ResolveUsingLoad(assemblyName);
	}

	[UnconditionalSuppressMessage("SingleFile", "IL3000: Avoid accessing Assembly file path when publishing as a single file", Justification = "The code handles the Assembly.Location equals null")]
	private Assembly GetFirstResolvedAssemblyFromResolvingEvent(AssemblyName assemblyName)
	{
		Delegate.InvocationListEnumerator<Func<AssemblyLoadContext, AssemblyName, Assembly>> enumerator = Delegate.EnumerateInvocationList(this._resolving).GetEnumerator();
		while (enumerator.MoveNext())
		{
			Assembly assembly = enumerator.Current(this, assemblyName);
			if (assembly != null)
			{
				return assembly;
			}
		}
		return null;
	}

	private static RuntimeAssembly ValidateAssemblyNameWithSimpleName(Assembly assembly, string requestedSimpleName)
	{
		ArgumentException.ThrowIfNullOrEmpty(requestedSimpleName, "AssemblyName.Name");
		RuntimeAssembly runtimeAssembly = GetRuntimeAssembly(assembly);
		if (runtimeAssembly == null)
		{
			throw new InvalidOperationException("InvalidOperation_ResolvedAssemblyMustBeRuntimeAssembly");
		}
		if (!requestedSimpleName.Equals(runtimeAssembly.GetSimpleName(), StringComparison.InvariantCultureIgnoreCase))
		{
			throw new InvalidOperationException("InvalidOperation_ResolvedAssemblyRequestedNameMismatch");
		}
		return runtimeAssembly;
	}

	private RuntimeAssembly ResolveUsingLoad(AssemblyName assemblyName)
	{
		string name = assemblyName.Name;
		Assembly assembly = Load(assemblyName);
		if (!(assembly != null))
		{
			return null;
		}
		return ValidateAssemblyNameWithSimpleName(assembly, name);
	}

	private RuntimeAssembly ResolveUsingEvent(AssemblyName assemblyName)
	{
		string name = assemblyName.Name;
		Assembly firstResolvedAssemblyFromResolvingEvent = GetFirstResolvedAssemblyFromResolvingEvent(assemblyName);
		if (!(firstResolvedAssemblyFromResolvingEvent != null))
		{
			return null;
		}
		return ValidateAssemblyNameWithSimpleName(firstResolvedAssemblyFromResolvingEvent, name);
	}

	private static void OnAssemblyLoad(RuntimeAssembly assembly)
	{
		AssemblyLoadContext.AssemblyLoad?.Invoke(AppDomain.CurrentDomain, new AssemblyLoadEventArgs(assembly));
	}

	internal static RuntimeAssembly OnResourceResolve(RuntimeAssembly assembly, string resourceName)
	{
		return InvokeResolveEvent(AssemblyLoadContext.ResourceResolve, assembly, resourceName);
	}

	internal static RuntimeAssembly OnTypeResolve(RuntimeAssembly assembly, string typeName)
	{
		return InvokeResolveEvent(AssemblyLoadContext.TypeResolve, assembly, typeName);
	}

	private static RuntimeAssembly OnAssemblyResolve(RuntimeAssembly assembly, string assemblyFullName)
	{
		return InvokeResolveEvent(AssemblyLoadContext.AssemblyResolve, assembly, assemblyFullName);
	}

	internal static void InvokeAssemblyLoadEvent(Assembly assembly)
	{
		AssemblyLoadContext.AssemblyLoad?.Invoke(AppDomain.CurrentDomain, new AssemblyLoadEventArgs(assembly));
	}

	[UnconditionalSuppressMessage("SingleFile", "IL3000: Avoid accessing Assembly file path when publishing as a single file", Justification = "The code handles the Assembly.Location equals null")]
	private static RuntimeAssembly InvokeResolveEvent(ResolveEventHandler eventHandler, RuntimeAssembly assembly, string name)
	{
		if (eventHandler == null)
		{
			return null;
		}
		ResolveEventArgs args = new ResolveEventArgs(name, assembly);
		Delegate.InvocationListEnumerator<ResolveEventHandler> enumerator = Delegate.EnumerateInvocationList(eventHandler).GetEnumerator();
		while (enumerator.MoveNext())
		{
			RuntimeAssembly runtimeAssembly = GetRuntimeAssembly(enumerator.Current(AppDomain.CurrentDomain, args));
			if (runtimeAssembly != null)
			{
				return runtimeAssembly;
			}
		}
		return null;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Satellite assemblies have no code in them and loading is not a problem")]
	[UnconditionalSuppressMessage("SingleFile", "IL3000: Avoid accessing Assembly file path when publishing as a single file", Justification = "This call is fine because native call runs before this and checks BindSatelliteResourceFromBundle")]
	private RuntimeAssembly ResolveSatelliteAssembly(AssemblyName assemblyName)
	{
		if (assemblyName.Name == null || !assemblyName.Name.EndsWith(".resources", StringComparison.Ordinal))
		{
			return null;
		}
		string assemblyName2 = assemblyName.Name.Substring(0, assemblyName.Name.Length - ".resources".Length);
		RuntimeAssembly obj = (RuntimeAssembly)LoadFromAssemblyName(new AssemblyName(assemblyName2));
		AssemblyLoadContext loadContext = GetLoadContext(obj);
		string directoryName = Path.GetDirectoryName(obj.Location);
		if (directoryName == null)
		{
			return null;
		}
		string text = Path.Combine(directoryName, assemblyName.CultureName, assemblyName.Name + ".dll");
		bool flag = FileSystem.FileExists(text.AsSpan());
		if (!flag)
		{
			_ = 1;
			text = Path.Combine(directoryName, assemblyName.CultureName.ToLowerInvariant(), assemblyName.Name + ".dll");
			flag = FileSystem.FileExists(text.AsSpan());
		}
		if (!flag)
		{
			return null;
		}
		return (RuntimeAssembly)loadContext.LoadFromAssemblyPath(text);
	}

	internal nint GetResolvedUnmanagedDll(Assembly assembly, string unmanagedDllName)
	{
		Delegate.InvocationListEnumerator<Func<Assembly, string, nint>> enumerator = Delegate.EnumerateInvocationList(this._resolvingUnmanagedDll).GetEnumerator();
		while (enumerator.MoveNext())
		{
			nint num = enumerator.Current(assembly, unmanagedDllName);
			if (num != IntPtr.Zero)
			{
				return num;
			}
		}
		return IntPtr.Zero;
	}
}
