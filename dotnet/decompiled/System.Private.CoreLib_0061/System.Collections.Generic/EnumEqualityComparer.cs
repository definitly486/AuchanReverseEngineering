using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Collections.Generic;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public sealed class EnumEqualityComparer<T> : EqualityComparer<T>, ISerializable where T : struct, Enum
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override bool Equals(T x, T y)
	{
		return JitHelpers.EnumEquals(x, y);
	}

	public EnumEqualityComparer()
	{
	}

	private EnumEqualityComparer(SerializationInfo information, StreamingContext context)
	{
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (Type.GetTypeCode(typeof(T)) != TypeCode.Int32)
		{
			info.SetType(typeof(ObjectEqualityComparer<T>));
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override int GetHashCode(T obj)
	{
		return obj.GetHashCode();
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj != null)
		{
			return GetType() == obj.GetType();
		}
		return false;
	}

	public override int GetHashCode()
	{
		return GetType().GetHashCode();
	}
}
