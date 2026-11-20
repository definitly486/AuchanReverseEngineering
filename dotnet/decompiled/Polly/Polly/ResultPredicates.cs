using System.Collections.Generic;

namespace Polly;

public class ResultPredicates<TResult>
{
	private List<ResultPredicate<TResult>> _predicates;

	public static readonly ResultPredicates<TResult> None = new ResultPredicates<TResult>();

	internal void Add(ResultPredicate<TResult> predicate)
	{
		if (_predicates == null)
		{
			_predicates = new List<ResultPredicate<TResult>>();
		}
		_predicates.Add(predicate);
	}

	public bool AnyMatch(TResult result)
	{
		if (_predicates == null)
		{
			return false;
		}
		return _predicates.Exists((ResultPredicate<TResult> predicate) => predicate(result));
	}
}
