using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public abstract class ValueType
{
	internal static bool DefaultEquals(object o1, object o2)
	{
		RuntimeType obj = (RuntimeType)o1.GetType();
		RuntimeType runtimeType = (RuntimeType)o2.GetType();
		if (obj != runtimeType)
		{
			return false;
		}
		object[] fields;
		bool result = InternalEquals(o1, o2, out fields);
		if (fields == null)
		{
			return result;
		}
		for (int i = 0; i < fields.Length; i += 2)
		{
			object obj2 = fields[i];
			object obj3 = fields[i + 1];
			if (obj2 == null)
			{
				if (obj3 != null)
				{
					return false;
				}
			}
			else if (!obj2.Equals(obj3))
			{
				return false;
			}
		}
		return true;
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj == null)
		{
			return false;
		}
		return DefaultEquals(this, obj);
	}

	public override int GetHashCode()
	{
		object[] fields;
		int num = InternalGetHashCode(this, out fields);
		if (fields != null)
		{
			for (int i = 0; i < fields.Length; i++)
			{
				if (fields[i] != null)
				{
					num ^= fields[i].GetHashCode();
				}
			}
		}
		return num;
	}

	public override string? ToString()
	{
		return GetType().ToString();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int InternalGetHashCode(object o, out object[] fields);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool InternalEquals(object o1, object o2, out object[] fields);
}
