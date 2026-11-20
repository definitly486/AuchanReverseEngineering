using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpFunctionalExtensions;

[Serializable]
public abstract class ValueObject
{
	private int? _cachedHashCode;

	protected abstract IEnumerable<object> GetEqualityComponents();

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (GetUnproxiedType(this) != GetUnproxiedType(obj))
		{
			return false;
		}
		ValueObject valueObject = (ValueObject)obj;
		return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
	}

	public override int GetHashCode()
	{
		if (!_cachedHashCode.HasValue)
		{
			_cachedHashCode = GetEqualityComponents().Aggregate(1, (int current, object obj) => current * 23 + (obj?.GetHashCode() ?? 0));
		}
		return _cachedHashCode.Value;
	}

	public static bool operator ==(ValueObject a, ValueObject b)
	{
		if ((object)a == null && (object)b == null)
		{
			return true;
		}
		if ((object)a == null || (object)b == null)
		{
			return false;
		}
		return a.Equals(b);
	}

	public static bool operator !=(ValueObject a, ValueObject b)
	{
		return !(a == b);
	}

	internal static Type GetUnproxiedType(object obj)
	{
		Type type = obj.GetType();
		string text = type.ToString();
		if (text.Contains("Castle.Proxies.") || text.EndsWith("Proxy"))
		{
			return type.BaseType;
		}
		return type;
	}
}
[Serializable]
public abstract class ValueObject<T> where T : ValueObject<T>
{
	private int? _cachedHashCode;

	public override bool Equals(object obj)
	{
		if (!(obj is T other))
		{
			return false;
		}
		if (ValueObject.GetUnproxiedType(this) != ValueObject.GetUnproxiedType(obj))
		{
			return false;
		}
		return EqualsCore(other);
	}

	protected abstract bool EqualsCore(T other);

	public override int GetHashCode()
	{
		if (!_cachedHashCode.HasValue)
		{
			_cachedHashCode = GetHashCodeCore();
		}
		return _cachedHashCode.Value;
	}

	protected abstract int GetHashCodeCore();

	public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
	{
		if ((object)a == null && (object)b == null)
		{
			return true;
		}
		if ((object)a == null || (object)b == null)
		{
			return false;
		}
		return a.Equals(b);
	}

	public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
	{
		return !(a == b);
	}
}
