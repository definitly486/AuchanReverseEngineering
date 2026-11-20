using System;
using System.Linq;
using System.Reflection;

namespace Refit;

internal struct CloseGenericMethodKey : IEquatable<CloseGenericMethodKey>
{
	public MethodInfo OpenMethodInfo { get; }

	public Type[] Types { get; }

	internal CloseGenericMethodKey(MethodInfo openMethodInfo, Type[] types)
	{
		OpenMethodInfo = openMethodInfo;
		Types = types;
	}

	public bool Equals(CloseGenericMethodKey other)
	{
		if (OpenMethodInfo == other.OpenMethodInfo)
		{
			return Types.SequenceEqual(other.Types);
		}
		return false;
	}

	public override bool Equals(object? obj)
	{
		if (obj is CloseGenericMethodKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = 17;
		num = num * 23 + OpenMethodInfo.GetHashCode();
		Type[] types = Types;
		foreach (Type type in types)
		{
			num = num * 23 + type.GetHashCode();
		}
		return num;
	}
}
