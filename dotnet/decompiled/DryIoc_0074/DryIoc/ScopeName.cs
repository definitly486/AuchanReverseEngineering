using System;

namespace DryIoc;

public sealed class ScopeName : IScopeName
{
	public readonly Func<object, bool> MatchPredicate;

	public static ScopeName Of(Func<object, bool> matchPredicate)
	{
		return new ScopeName(matchPredicate);
	}

	private ScopeName(Func<object, bool> matchPredicate)
	{
		MatchPredicate = matchPredicate;
	}

	public bool Match(object scopeName)
	{
		return MatchPredicate(scopeName);
	}
}
