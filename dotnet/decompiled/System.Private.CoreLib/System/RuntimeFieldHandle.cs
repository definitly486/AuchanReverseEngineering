using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System;

public struct RuntimeFieldHandle : IEquatable<RuntimeFieldHandle>, ISerializable
{
	private readonly nint value;

	public nint Value => value;

	internal RuntimeFieldHandle(nint v)
	{
		value = v;
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException();
	}

	internal bool IsNullHandle()
	{
		return value == IntPtr.Zero;
	}

	public override bool Equals(object? obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return value == ((RuntimeFieldHandle)obj).Value;
	}

	public bool Equals(RuntimeFieldHandle handle)
	{
		return value == handle.Value;
	}

	public override int GetHashCode()
	{
		return ((IntPtr)value).GetHashCode();
	}

	public static RuntimeFieldHandle FromIntPtr(nint value)
	{
		return new RuntimeFieldHandle(value);
	}

	public static nint ToIntPtr(RuntimeFieldHandle value)
	{
		return value.Value;
	}

	public static bool operator ==(RuntimeFieldHandle left, RuntimeFieldHandle right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(RuntimeFieldHandle left, RuntimeFieldHandle right)
	{
		return !left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal unsafe static extern object GetValueDirect(RuntimeFieldInfo field, RuntimeType fieldType, void* pTypedRef, RuntimeType contextType);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal unsafe static extern void SetValueDirect(RuntimeFieldInfo field, RuntimeType fieldType, void* pTypedRef, object value, RuntimeType contextType);

	internal static ref byte GetFieldDataReference(object target, RuntimeFieldInfo field)
	{
		return ref GetFieldDataReferenceInternal(target, field.FieldHandle.Value);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern ref byte GetFieldDataReferenceInternal(object target, nint field);

	internal static ref byte GetFieldDataReference(ref byte target, RuntimeFieldInfo field)
	{
		int fieldOffset = field.GetFieldOffset();
		return ref Unsafe.AddByteOffset(ref target, fieldOffset);
	}
}
