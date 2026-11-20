using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using Mono;

namespace System;

public struct RuntimeTypeHandle : IEquatable<RuntimeTypeHandle>, ISerializable
{
	private readonly nint value;

	public nint Value => value;

	internal RuntimeTypeHandle(nint val)
	{
		value = val;
	}

	internal RuntimeTypeHandle(RuntimeType type)
		: this(type._impl.value)
	{
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException();
	}

	public override bool Equals(object? obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return value == ((RuntimeTypeHandle)obj).Value;
	}

	public bool Equals(RuntimeTypeHandle handle)
	{
		return value == handle.Value;
	}

	public override int GetHashCode()
	{
		return ((IntPtr)value).GetHashCode();
	}

	public static RuntimeTypeHandle FromIntPtr(nint value)
	{
		return new RuntimeTypeHandle(value);
	}

	public static nint ToIntPtr(RuntimeTypeHandle value)
	{
		return value.Value;
	}

	public static bool operator ==(RuntimeTypeHandle left, object right)
	{
		if (right != null && right is RuntimeTypeHandle)
		{
			return left.Equals((RuntimeTypeHandle)right);
		}
		return false;
	}

	public static bool operator !=(RuntimeTypeHandle left, object right)
	{
		if (right != null && right is RuntimeTypeHandle)
		{
			return !left.Equals((RuntimeTypeHandle)right);
		}
		return true;
	}

	public static bool operator ==(object left, RuntimeTypeHandle right)
	{
		if (left != null && left is RuntimeTypeHandle runtimeTypeHandle)
		{
			return runtimeTypeHandle.Equals(right);
		}
		return false;
	}

	public static bool operator !=(object left, RuntimeTypeHandle right)
	{
		if (left != null && left is RuntimeTypeHandle runtimeTypeHandle)
		{
			return !runtimeTypeHandle.Equals(right);
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern TypeAttributes GetAttributes(QCallTypeHandle type);

	internal static TypeAttributes GetAttributes(RuntimeType type)
	{
		return type.GetAttributes();
	}

	public ModuleHandle GetModuleHandle()
	{
		if (value == IntPtr.Zero)
		{
			throw new ArgumentException("Arg_InvalidHandle");
		}
		return Type.GetTypeFromHandle(this).Module.ModuleHandle;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetMetadataToken(QCallTypeHandle type);

	internal static int GetToken(RuntimeType type)
	{
		return GetMetadataToken(new QCallTypeHandle(ref type));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetGenericTypeDefinition_impl(QCallTypeHandle type, ObjectHandleOnStack res);

	internal static Type GetGenericTypeDefinition(RuntimeType type)
	{
		Type o = null;
		GetGenericTypeDefinition_impl(new QCallTypeHandle(ref type), ObjectHandleOnStack.Create(ref o));
		if (o == null)
		{
			return type;
		}
		return o;
	}

	internal static bool IsPrimitive(RuntimeType type)
	{
		CorElementType corElementType = type.GetCorElementType();
		if (((int)corElementType < 2 || (int)corElementType > 13) && corElementType != CorElementType.ELEMENT_TYPE_I)
		{
			return corElementType == CorElementType.ELEMENT_TYPE_U;
		}
		return true;
	}

	internal static bool IsByRef(RuntimeType type)
	{
		return type.GetCorElementType() == CorElementType.ELEMENT_TYPE_BYREF;
	}

	internal static bool IsPointer(RuntimeType type)
	{
		return type.GetCorElementType() == CorElementType.ELEMENT_TYPE_PTR;
	}

	internal static bool IsFunctionPointer(RuntimeType type)
	{
		return type.GetCorElementType() == CorElementType.ELEMENT_TYPE_FNPTR;
	}

	internal static bool IsArray(RuntimeType type)
	{
		CorElementType corElementType = type.GetCorElementType();
		if (corElementType != CorElementType.ELEMENT_TYPE_ARRAY)
		{
			return corElementType == CorElementType.ELEMENT_TYPE_SZARRAY;
		}
		return true;
	}

	internal static bool IsSzArray(RuntimeType type)
	{
		return type.GetCorElementType() == CorElementType.ELEMENT_TYPE_SZARRAY;
	}

	internal static bool IsValueType(RuntimeType type)
	{
		return type.IsValueType;
	}

	internal static bool HasElementType(RuntimeType type)
	{
		CorElementType corElementType = type.GetCorElementType();
		if (corElementType != CorElementType.ELEMENT_TYPE_ARRAY && corElementType != CorElementType.ELEMENT_TYPE_SZARRAY && corElementType != CorElementType.ELEMENT_TYPE_PTR)
		{
			return corElementType == CorElementType.ELEMENT_TYPE_BYREF;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern CorElementType GetCorElementType(QCallTypeHandle type);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool HasInstantiation(QCallTypeHandle type);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool IsInstanceOfType(QCallTypeHandle type, [NotNullWhen(true)] object o);

	internal static bool IsInstanceOfType(RuntimeType type, [NotNullWhen(true)] object o)
	{
		return IsInstanceOfType(new QCallTypeHandle(ref type), o);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool HasReferences(QCallTypeHandle type);

	internal static bool HasReferences(RuntimeType type)
	{
		return HasReferences(new QCallTypeHandle(ref type));
	}

	internal static bool HasInstantiation(RuntimeType type)
	{
		return HasInstantiation(new QCallTypeHandle(ref type));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern int GetArrayRank(QCallTypeHandle type);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void GetAssembly(QCallTypeHandle type, ObjectHandleOnStack res);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void GetElementType(QCallTypeHandle type, ObjectHandleOnStack res);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void GetModule(QCallTypeHandle type, ObjectHandleOnStack res);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint GetMonoClass(QCallTypeHandle type);

	internal static int GetArrayRank(RuntimeType type)
	{
		return GetArrayRank(new QCallTypeHandle(ref type));
	}

	internal static RuntimeAssembly GetAssembly(RuntimeType type)
	{
		RuntimeAssembly o = null;
		GetAssembly(new QCallTypeHandle(ref type), ObjectHandleOnStack.Create(ref o));
		return o;
	}

	internal static RuntimeModule GetModule(RuntimeType type)
	{
		RuntimeModule o = null;
		GetModule(new QCallTypeHandle(ref type), ObjectHandleOnStack.Create(ref o));
		return o;
	}

	internal static RuntimeType GetElementType(RuntimeType type)
	{
		RuntimeType o = null;
		GetElementType(new QCallTypeHandle(ref type), ObjectHandleOnStack.Create(ref o));
		return o;
	}

	internal static nint GetMonoClass(RuntimeType type)
	{
		return GetMonoClass(new QCallTypeHandle(ref type));
	}

	internal static bool CanCastTo(RuntimeType type, RuntimeType target)
	{
		return type_is_assignable_from(new QCallTypeHandle(ref target), new QCallTypeHandle(ref type));
	}

	internal static bool IsGenericVariable(RuntimeType type)
	{
		CorElementType corElementType = type.GetCorElementType();
		if (corElementType != CorElementType.ELEMENT_TYPE_VAR)
		{
			return corElementType == CorElementType.ELEMENT_TYPE_MVAR;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool type_is_assignable_from(QCallTypeHandle a, QCallTypeHandle b);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool IsGenericTypeDefinition(QCallTypeHandle type);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern nint GetGenericParameterInfo(QCallTypeHandle type);

	internal static bool IsGenericTypeDefinition(RuntimeType type)
	{
		return IsGenericTypeDefinition(new QCallTypeHandle(ref type));
	}

	internal static nint GetGenericParameterInfo(RuntimeType type)
	{
		return GetGenericParameterInfo(new QCallTypeHandle(ref type));
	}

	internal static bool IsSubclassOf(RuntimeType childType, RuntimeType baseType)
	{
		return is_subclass_of(new QCallTypeHandle(ref childType), new QCallTypeHandle(ref baseType));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool is_subclass_of(QCallTypeHandle childType, QCallTypeHandle baseType);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool IsByRefLike(QCallTypeHandle type);

	internal static bool IsByRefLike(RuntimeType type)
	{
		return IsByRefLike(new QCallTypeHandle(ref type));
	}

	internal static bool IsTypeDefinition(RuntimeType type)
	{
		CorElementType corElementType = type.GetCorElementType();
		if (((int)corElementType < 1 || (int)corElementType >= 15) && corElementType != CorElementType.ELEMENT_TYPE_VALUETYPE && corElementType != CorElementType.ELEMENT_TYPE_CLASS && corElementType != CorElementType.ELEMENT_TYPE_TYPEDBYREF && corElementType != CorElementType.ELEMENT_TYPE_I && corElementType != CorElementType.ELEMENT_TYPE_U && corElementType != CorElementType.ELEMENT_TYPE_OBJECT)
		{
			return false;
		}
		if (HasInstantiation(type) && !IsGenericTypeDefinition(type))
		{
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void internal_from_name(nint name, ref StackCrawlMark stackMark, ObjectHandleOnStack res, bool throwOnError, bool ignoreCase);

	[RequiresUnreferencedCode("Types might be removed")]
	internal static RuntimeType GetTypeByName(string typeName, bool throwOnError, bool ignoreCase, ref StackCrawlMark stackMark)
	{
		ArgumentNullException.ThrowIfNull(typeName, "typeName");
		if (typeName.Length == 0)
		{
			if (throwOnError)
			{
				throw new TypeLoadException("Arg_TypeLoadNullStr");
			}
			return null;
		}
		RuntimeType o = null;
		using (SafeStringMarshal safeStringMarshal = new SafeStringMarshal(typeName))
		{
			internal_from_name(safeStringMarshal.Value, ref stackMark, ObjectHandleOnStack.Create(ref o), throwOnError, ignoreCase);
			if (throwOnError && o == null)
			{
				throw new TypeLoadException("Arg_TypeLoadException");
			}
		}
		return o;
	}

	internal static nint[] CopyRuntimeTypeHandles(RuntimeTypeHandle[] inHandles, out int length)
	{
		if (inHandles == null || inHandles.Length == 0)
		{
			length = 0;
			return null;
		}
		nint[] array = new nint[inHandles.Length];
		for (int i = 0; i < inHandles.Length; i++)
		{
			array[i] = inHandles[i].Value;
		}
		length = array.Length;
		return array;
	}
}
