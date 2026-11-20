using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;

namespace System.Runtime.CompilerServices;

public static class RuntimeHelpers
{
	public delegate void TryCode(object? userData);

	public delegate void CleanupCode(object? userData, bool exceptionThrown);

	[Obsolete("OffsetToStringData has been deprecated. Use string.GetPinnableReference() instead.")]
	public static int OffsetToStringData => 20;

	public static void InitializeArray(Array array, RuntimeFieldHandle fldHandle)
	{
		ArgumentNullException.ThrowIfNull(array, "array");
		ArgumentNullException.ThrowIfNull(fldHandle.Value, "fldHandle");
		InitializeArray(array, fldHandle.Value);
	}

	private unsafe static ref byte GetSpanDataFrom(RuntimeFieldHandle fldHandle, RuntimeTypeHandle targetTypeHandle, out int count)
	{
		fixed (int* value = &count)
		{
			return ref GetSpanDataFrom(fldHandle.Value, targetTypeHandle.Value, new IntPtr(value));
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int InternalGetHashCode(object o);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int GetHashCode(object? o)
	{
		if (ObjectHeader.TryGetHashCode(o, out var hash))
		{
			return hash;
		}
		return InternalGetHashCode(o);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int TryGetHashCode(object o)
	{
		if (ObjectHeader.TryGetHashCode(o, out var hash))
		{
			return hash;
		}
		return 0;
	}

	public new static bool Equals(object? o1, object? o2)
	{
		if (o1 == o2)
		{
			return true;
		}
		if (o1 == null || o2 == null)
		{
			return false;
		}
		if (o1 is ValueType)
		{
			return ValueType.DefaultEquals(o1, o2);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[return: NotNullIfNotNull("obj")]
	public static extern object? GetObjectValue(object? obj);

	[RequiresUnreferencedCode("Trimmer can't guarantee existence of class constructor")]
	public static void RunClassConstructor(RuntimeTypeHandle type)
	{
		if (type.Value == IntPtr.Zero)
		{
			throw new ArgumentException("InvalidOperation_HandleIsNotInitialized", "type");
		}
		RunClassConstructor(type.Value);
	}

	public static void EnsureSufficientExecutionStack()
	{
		if (SufficientExecutionStack())
		{
			return;
		}
		throw new InsufficientExecutionStackException();
	}

	public static bool TryEnsureSufficientExecutionStack()
	{
		return SufficientExecutionStack();
	}

	public static void PrepareDelegate(Delegate d)
	{
	}

	public unsafe static void PrepareMethod(RuntimeMethodHandle method)
	{
		if (method.IsNullHandle())
		{
			throw new ArgumentException("Argument_InvalidHandle");
		}
		PrepareMethod(method.Value, null, 0);
	}

	public unsafe static void PrepareMethod(RuntimeMethodHandle method, RuntimeTypeHandle[]? instantiation)
	{
		if (method.IsNullHandle())
		{
			throw new ArgumentException("Argument_InvalidHandle");
		}
		int length;
		fixed (nint* instantiations = RuntimeTypeHandle.CopyRuntimeTypeHandles(instantiation, out length))
		{
			PrepareMethod(method.Value, instantiations, length);
			GC.KeepAlive(instantiation);
		}
	}

	public static void RunModuleConstructor(ModuleHandle module)
	{
		if (module == ModuleHandle.EmptyHandle)
		{
			throw new ArgumentException("InvalidOperation_HandleIsNotInitialized", "module");
		}
		RunModuleConstructor(module.Value);
	}

	public unsafe static nint AllocateTypeAssociatedMemory(Type type, int size)
	{
		if (!(type is RuntimeType))
		{
			throw new ArgumentException("Arg_MustBeType", "type");
		}
		ArgumentOutOfRangeException.ThrowIfNegative(size, "size");
		return (nint)NativeMemory.AllocZeroed((uint)size);
	}

	[Intrinsic]
	internal static ref byte GetRawData(this object obj)
	{
		return ref obj.GetRawData();
	}

	[Intrinsic]
	internal static bool IsBitwiseEquatable<T>()
	{
		return IsBitwiseEquatable<T>();
	}

	[Intrinsic]
	internal static bool ObjectHasComponentSize(object obj)
	{
		return ObjectHasComponentSize(obj);
	}

	[Intrinsic]
	internal static bool ObjectHasReferences(object obj)
	{
		return RuntimeTypeHandle.HasReferences(obj.GetType() as RuntimeType);
	}

	public static object GetUninitializedObject([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type type)
	{
		RuntimeType obj = type as RuntimeType;
		if ((object)obj == null)
		{
			ArgumentNullException.ThrowIfNull(type, "type");
			throw new SerializationException(SR.Format("Serialization_InvalidType", type));
		}
		return GetUninitializedObjectInternal(new RuntimeTypeHandle(obj).Value);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern void PrepareMethod(nint method, nint* instantiations, int ninst);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern object GetUninitializedObjectInternal(nint type);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void InitializeArray(Array array, nint fldHandle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern ref byte GetSpanDataFrom(nint fldHandle, nint targetTypeHandle, nint count);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void RunClassConstructor(nint type);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void RunModuleConstructor(nint module);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool SufficientExecutionStack();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern object InternalBox(QCallTypeHandle type, ref byte target);

	public static object? Box(ref byte target, RuntimeTypeHandle type)
	{
		if (type.Value == 0)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.type);
		}
		if (Unsafe.IsNullRef(in target))
		{
			throw new NullReferenceException();
		}
		RuntimeType type2 = (RuntimeType)Type.GetTypeFromHandle(type);
		if (type2.ContainsGenericParameters || type2.IsPointer || type2.IsFunctionPointer || type2.IsByRef || type2.IsGenericParameter || type2 == typeof(void))
		{
			throw new ArgumentException("Arg_TypeNotSupported");
		}
		if (!type2.IsValueType)
		{
			return Unsafe.As<byte, object>(ref target);
		}
		if (type2.IsByRefLike)
		{
			throw new NotSupportedException("NotSupported_ByRefLike");
		}
		return InternalBox(new QCallTypeHandle(ref type2), ref target);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int SizeOf(QCallTypeHandle handle);

	public static int SizeOf(RuntimeTypeHandle type)
	{
		if (type.Value == IntPtr.Zero)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.type);
		}
		Type typeFromHandle = Type.GetTypeFromHandle(type);
		if (typeFromHandle.ContainsGenericParameters || typeFromHandle.IsGenericParameter || typeFromHandle == typeof(void))
		{
			throw new ArgumentException("Arg_TypeNotSupported");
		}
		return SizeOf(new QCallTypeHandle(ref type));
	}

	public static T[] GetSubArray<T>(T[] array, Range range)
	{
		if (array == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		var (elementOffset, num) = range.GetOffsetAndLength(array.Length);
		T[] array2;
		if (typeof(T[]) == array.GetType())
		{
			if (num == 0)
			{
				return Array.Empty<T>();
			}
			array2 = new T[num];
		}
		else
		{
			array2 = Unsafe.As<T[]>(Array.CreateInstanceFromArrayType(array.GetType(), num));
		}
		Buffer.Memmove(ref MemoryMarshal.GetArrayDataReference(array2), ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(array), elementOffset), (uint)num);
		return array2;
	}

	[Obsolete("The Constrained Execution Region (CER) feature is not supported.", DiagnosticId = "SYSLIB0004", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public static void ExecuteCodeWithGuaranteedCleanup(TryCode code, CleanupCode backoutCode, object? userData)
	{
		ArgumentNullException.ThrowIfNull(code, "code");
		ArgumentNullException.ThrowIfNull(backoutCode, "backoutCode");
		bool exceptionThrown = true;
		try
		{
			code(userData);
			exceptionThrown = false;
		}
		finally
		{
			backoutCode(userData, exceptionThrown);
		}
	}

	[Obsolete("The Constrained Execution Region (CER) feature is not supported.", DiagnosticId = "SYSLIB0004", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public static void PrepareContractedDelegate(Delegate d)
	{
	}

	[Obsolete("The Constrained Execution Region (CER) feature is not supported.", DiagnosticId = "SYSLIB0004", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public static void ProbeForSufficientStack()
	{
	}

	[Obsolete("The Constrained Execution Region (CER) feature is not supported.", DiagnosticId = "SYSLIB0004", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public static void PrepareConstrainedRegions()
	{
	}

	[Obsolete("The Constrained Execution Region (CER) feature is not supported.", DiagnosticId = "SYSLIB0004", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public static void PrepareConstrainedRegionsNoOP()
	{
	}

	internal static bool IsPrimitiveType(this CorElementType et)
	{
		return ((1 << (int)et) & 0x3003FFC) != 0;
	}

	[Intrinsic]
	public static ReadOnlySpan<T> CreateSpan<T>(RuntimeFieldHandle fldHandle)
	{
		int count;
		return new ReadOnlySpan<T>(ref Unsafe.As<byte, T>(ref GetSpanDataFrom(fldHandle, typeof(T).TypeHandle, out count)), count);
	}

	[Intrinsic]
	internal static bool IsKnownConstant(Type t)
	{
		return false;
	}

	[Intrinsic]
	internal static bool IsKnownConstant(string t)
	{
		return false;
	}

	[Intrinsic]
	internal static bool IsKnownConstant(char t)
	{
		return false;
	}

	[Intrinsic]
	internal static bool IsKnownConstant<T>(T t) where T : struct
	{
		return false;
	}

	[Intrinsic]
	public static bool IsReferenceOrContainsReferences<T>()
	{
		return IsReferenceOrContainsReferences<T>();
	}
}
