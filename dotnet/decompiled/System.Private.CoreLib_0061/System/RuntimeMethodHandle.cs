using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace System;

public struct RuntimeMethodHandle : IEquatable<RuntimeMethodHandle>, ISerializable
{
	private readonly nint value;

	public nint Value => value;

	internal RuntimeMethodHandle(nint v)
	{
		value = v;
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint GetFunctionPointer(nint m);

	public nint GetFunctionPointer()
	{
		return GetFunctionPointer(value);
	}

	public override bool Equals(object? obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return value == ((RuntimeMethodHandle)obj).Value;
	}

	public bool Equals(RuntimeMethodHandle handle)
	{
		return value == handle.Value;
	}

	public override int GetHashCode()
	{
		return ((IntPtr)value).GetHashCode();
	}

	public static RuntimeMethodHandle FromIntPtr(nint value)
	{
		return new RuntimeMethodHandle(value);
	}

	public static nint ToIntPtr(RuntimeMethodHandle value)
	{
		return value.Value;
	}

	public static bool operator ==(RuntimeMethodHandle left, RuntimeMethodHandle right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(RuntimeMethodHandle left, RuntimeMethodHandle right)
	{
		return !left.Equals(right);
	}

	internal static string ConstructInstantiation(RuntimeMethodInfo method)
	{
		StringBuilder stringBuilder = new StringBuilder();
		Type[] genericArguments = method.GetGenericArguments();
		stringBuilder.Append('[');
		for (int i = 0; i < genericArguments.Length; i++)
		{
			if (i > 0)
			{
				stringBuilder.Append(',');
			}
			stringBuilder.Append(genericArguments[i].Name);
		}
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}

	internal bool IsNullHandle()
	{
		return value == IntPtr.Zero;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReboxFromNullable(object src, ObjectHandleOnStack res);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReboxToNullable(object src, QCallTypeHandle destNullableType, ObjectHandleOnStack res);

	internal static object ReboxFromNullable(object src)
	{
		object o = null;
		ReboxFromNullable(src, ObjectHandleOnStack.Create(ref o));
		return o;
	}

	internal static object ReboxToNullable(object src, RuntimeType destNullableType)
	{
		object o = null;
		ReboxToNullable(src, new QCallTypeHandle(ref destNullableType), ObjectHandleOnStack.Create(ref o));
		return o;
	}
}
