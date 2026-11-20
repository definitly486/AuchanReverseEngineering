using System;
using System.Threading;

namespace DryIoc;

public sealed class AsyncExecutionFlowScopeContext : IScopeContext, IDisposable
{
	public static readonly string ScopeContextName = typeof(AsyncExecutionFlowScopeContext).FullName;

	public static readonly AsyncExecutionFlowScopeContext Default = new AsyncExecutionFlowScopeContext();

	private static readonly AsyncLocal<IScope> _ambientScope = new AsyncLocal<IScope>();

	public IScope GetCurrentOrDefault()
	{
		return _ambientScope.Value;
	}

	public IScope SetCurrent(SetCurrentScopeHandler changeCurrentScope)
	{
		return _ambientScope.Value = changeCurrentScope(GetCurrentOrDefault());
	}

	public void Dispose()
	{
	}
}
