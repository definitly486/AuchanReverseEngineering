using System;

namespace EBind;

public class DisposableDelegate<T> : AbstractImplicitDelegate<T>, IDisposable where T : Delegate
{
	private Action<T>? _unsubscribe;

	protected override T InnerDelegate { get; }

	public DisposableDelegate(T delegatee, Action<T> unsubscribe)
	{
		InnerDelegate = delegatee ?? throw new ArgumentNullException("delegatee");
		_unsubscribe = unsubscribe ?? throw new ArgumentNullException("unsubscribe");
	}

	public void Dispose()
	{
		_unsubscribe?.Invoke(InnerDelegate);
		_unsubscribe = null;
	}
}
