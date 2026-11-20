using System.Collections.Generic;

namespace CSharpFunctionalExtensions;

public class MaybeEqualityComparer<T> : IEqualityComparer<Maybe<T>>
{
	private readonly IEqualityComparer<T> _equalityComparer;

	public MaybeEqualityComparer(IEqualityComparer<T> equalityComparer = null)
	{
		_equalityComparer = equalityComparer ?? EqualityComparer<T>.Default;
	}

	public bool Equals(Maybe<T> x, Maybe<T> y)
	{
		if (x.HasNoValue && y.HasNoValue)
		{
			return true;
		}
		if (x.HasValue && y.HasValue)
		{
			return _equalityComparer.Equals(x.Value, y.Value);
		}
		return false;
	}

	public int GetHashCode(Maybe<T> obj)
	{
		if (!obj.HasNoValue)
		{
			return _equalityComparer.GetHashCode(obj.Value);
		}
		return 0;
	}
}
