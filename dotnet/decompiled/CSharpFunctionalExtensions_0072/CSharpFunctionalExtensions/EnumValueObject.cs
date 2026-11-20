using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharpFunctionalExtensions;

public abstract class EnumValueObject<TEnumeration, TId> : ComparableValueObject where TEnumeration : EnumValueObject<TEnumeration, TId> where TId : struct, IComparable
{
	private int? _cachedHashCode;

	private static readonly Dictionary<TId, TEnumeration> EnumerationsById = GetEnumerations().ToDictionary((TEnumeration e) => e.Id);

	private static readonly Dictionary<string, TEnumeration> EnumerationsByName = GetEnumerations().ToDictionary((TEnumeration e) => e.Name);

	public static IReadOnlyCollection<TEnumeration> All = EnumerationsById.Values.OfType<TEnumeration>().ToList();

	public TId Id { get; protected set; }

	public string Name { get; protected set; }

	protected EnumValueObject(TId id, string name)
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			throw new ArgumentException("The name cannot be null or empty");
		}
		Id = id;
		Name = name;
	}

	public static bool operator ==(EnumValueObject<TEnumeration, TId> a, TId b)
	{
		return a?.Id.Equals(b) ?? false;
	}

	public static bool operator !=(EnumValueObject<TEnumeration, TId> a, TId b)
	{
		return !(a == b);
	}

	public static bool operator ==(TId a, EnumValueObject<TEnumeration, TId> b)
	{
		return b == a;
	}

	public static bool operator !=(TId a, EnumValueObject<TEnumeration, TId> b)
	{
		return !(b == a);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (ValueObject.GetUnproxiedType(this) != ValueObject.GetUnproxiedType(obj))
		{
			return false;
		}
		EnumValueObject<TEnumeration, TId> enumValueObject = (EnumValueObject<TEnumeration, TId>)obj;
		return GetEqualityComponents().SequenceEqual(enumValueObject.GetEqualityComponents());
	}

	public override int GetHashCode()
	{
		if (!_cachedHashCode.HasValue)
		{
			_cachedHashCode = GetEqualityComponents().Aggregate(1, (int current, object obj) => current * 23 + (obj?.GetHashCode() ?? 0));
		}
		return _cachedHashCode.Value;
	}

	public static Maybe<TEnumeration> FromId(TId id)
	{
		return EnumerationsById.ContainsKey(id) ? EnumerationsById[id] : null;
	}

	public static Maybe<TEnumeration> FromName(string name)
	{
		return EnumerationsByName.ContainsKey(name) ? EnumerationsByName[name] : null;
	}

	public static bool Is(string possibleName)
	{
		return All.Select((TEnumeration e) => e.Name).Contains(possibleName);
	}

	public static bool Is(TId possibleId)
	{
		return All.Select((TEnumeration e) => e.Id).Contains(possibleId);
	}

	public override string ToString()
	{
		return Name;
	}

	protected override IEnumerable<IComparable> GetComparableEqualityComponents()
	{
		yield return Id;
	}

	private static TEnumeration[] GetEnumerations()
	{
		return (from info in typeof(TEnumeration).GetFields(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public)
			where info.FieldType == typeof(TEnumeration)
			select (TEnumeration)info.GetValue(null)).ToArray();
	}
}
public abstract class EnumValueObject<TEnumeration> : ComparableValueObject where TEnumeration : EnumValueObject<TEnumeration>
{
	private int? _cachedHashCode;

	private static readonly Dictionary<string, TEnumeration> Enumerations = GetEnumerations().ToDictionary((TEnumeration e) => e.Id);

	public static IReadOnlyCollection<TEnumeration> All = Enumerations.Values.OfType<TEnumeration>().ToList();

	public virtual string Id { get; protected set; }

	protected EnumValueObject(string id)
	{
		if (string.IsNullOrWhiteSpace(id))
		{
			throw new ArgumentException("The enum key cannot be null or empty");
		}
		Id = id;
	}

	public static bool operator ==(EnumValueObject<TEnumeration> a, string b)
	{
		if ((object)a == null && b == null)
		{
			return true;
		}
		if ((object)a == null || b == null)
		{
			return false;
		}
		return a.Id.Equals(b);
	}

	public static bool operator !=(EnumValueObject<TEnumeration> a, string b)
	{
		return !(a == b);
	}

	public static bool operator ==(string a, EnumValueObject<TEnumeration> b)
	{
		return b == a;
	}

	public static bool operator !=(string a, EnumValueObject<TEnumeration> b)
	{
		return !(b == a);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (ValueObject.GetUnproxiedType(this) != ValueObject.GetUnproxiedType(obj))
		{
			return false;
		}
		EnumValueObject<TEnumeration> enumValueObject = (EnumValueObject<TEnumeration>)obj;
		return GetEqualityComponents().SequenceEqual(enumValueObject.GetEqualityComponents());
	}

	public override int GetHashCode()
	{
		if (!_cachedHashCode.HasValue)
		{
			_cachedHashCode = GetEqualityComponents().Aggregate(1, (int current, object obj) => current * 23 + (obj?.GetHashCode() ?? 0));
		}
		return _cachedHashCode.Value;
	}

	public static Maybe<TEnumeration> FromId(string id)
	{
		return Enumerations.ContainsKey(id) ? Enumerations[id] : null;
	}

	public static bool Is(string possibleId)
	{
		return All.Select((TEnumeration e) => e.Id).Contains(possibleId);
	}

	public override string ToString()
	{
		return Id;
	}

	protected override IEnumerable<IComparable> GetComparableEqualityComponents()
	{
		yield return Id;
	}

	private static TEnumeration[] GetEnumerations()
	{
		return (from info in typeof(TEnumeration).GetFields(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public)
			where info.FieldType == typeof(TEnumeration)
			select (TEnumeration)info.GetValue(null)).ToArray();
	}
}
