using System;
using System.Collections.Generic;
using System.Threading;

namespace DryIoc;

public sealed class ThreadScopeContext : IScopeContext, IDisposable
{
	public static readonly string ScopeContextName = "ThreadScopeContext";

	private ThreadLocal<IScope> _scope = new ThreadLocal<IScope>(trackAllValues: true);

	public IScope GetCurrentOrDefault()
	{
		return _scope.Value;
	}

	public IScope SetCurrent(SetCurrentScopeHandler setCurrentScope)
	{
		return _scope.Value = setCurrentScope(GetCurrentOrDefault());
	}

	public void Dispose()
	{
		IList<IScope> values = _scope.Values;
		foreach (IScope item in values)
		{
			IScope scope = item;
			while (scope != null)
			{
				IScope scope2 = scope;
				scope = scope.Parent;
				scope2.Dispose();
			}
		}
	}
}
