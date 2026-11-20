using System;

namespace EBind;

public abstract class AbstractImplicitDelegate<T> where T : Delegate
{
	protected abstract T InnerDelegate { get; }

	public static implicit operator T(AbstractImplicitDelegate<T> self)
	{
		return self.InnerDelegate;
	}
}
