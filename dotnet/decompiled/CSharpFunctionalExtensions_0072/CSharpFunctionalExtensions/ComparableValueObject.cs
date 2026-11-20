using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpFunctionalExtensions;

[Serializable]
public abstract class ComparableValueObject : ValueObject, IComparable, IComparable<ComparableValueObject>
{
	protected abstract IEnumerable<IComparable> GetComparableEqualityComponents();

	protected sealed override IEnumerable<object> GetEqualityComponents()
	{
		return GetComparableEqualityComponents();
	}

	public virtual int CompareTo(ComparableValueObject other)
	{
		if ((object)other == null)
		{
			return 1;
		}
		if ((object)this == other)
		{
			return 0;
		}
		Type unproxiedType = ValueObject.GetUnproxiedType(this);
		Type unproxiedType2 = ValueObject.GetUnproxiedType(other);
		if (unproxiedType != unproxiedType2)
		{
			return string.Compare($"{unproxiedType}", $"{unproxiedType2}", StringComparison.Ordinal);
		}
		return GetComparableEqualityComponents().Zip(other.GetComparableEqualityComponents(), (IComparable left, IComparable right) => left?.CompareTo(right) ?? ((right != null) ? (-1) : 0)).FirstOrDefault((int cmp) => cmp != 0);
	}

	public virtual int CompareTo(object other)
	{
		return CompareTo(other as ComparableValueObject);
	}
}
