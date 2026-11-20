using System;

namespace EBind;

public class SelfAwareDelegate<T> : AbstractImplicitDelegate<T> where T : Delegate
{
	protected override T InnerDelegate { get; }

	public SelfAwareDelegate(CreateDelegateWithItsGetter<T> createDelegate)
	{
		if (createDelegate == null)
		{
			throw new ArgumentNullException("createDelegate");
		}
		InnerDelegate = createDelegate(() => InnerDelegate);
	}
}
