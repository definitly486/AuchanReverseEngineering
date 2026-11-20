using System;

namespace DryIoc;

public interface IScopeContext : IDisposable
{
	IScope GetCurrentOrDefault();

	IScope SetCurrent(SetCurrentScopeHandler setCurrentScope);
}
