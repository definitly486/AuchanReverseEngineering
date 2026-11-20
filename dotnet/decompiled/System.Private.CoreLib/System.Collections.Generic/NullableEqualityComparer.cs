using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Collections.Generic;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public sealed class NullableEqualityComparer<T> : EqualityComparer<T?>, ISerializable where T : struct
{
	public NullableEqualityComparer()
	{
	}

	private NullableEqualityComparer(SerializationInfo info, StreamingContext context)
	{
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (!typeof(T).IsAssignableTo(typeof(IEquatable<T>)))
		{
			info.SetType(typeof(ObjectEqualityComparer<T?>));
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override bool Equals(T? x, T? y)
	{
		if (x.HasValue)
		{
			if (y.HasValue)
			{
				return EqualityComparer<T>.Default.Equals(x.value, y.value);
			}
			return false;
		}
		if (y.HasValue)
		{
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override int GetHashCode(T? obj)
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
