using System.Collections.Generic;
using Auchan.Common.Base;

namespace Auchan.Common.Common;

public class ViewModelStateManager : IViewModelStateManager
{
	private readonly IEnumerable<IViewModelStateObserver> _observers;

	public ViewModelStateManager(IEnumerable<IViewModelStateObserver> observers)
	{
		_observers = observers;
	}

	public void Started(ScreenViewModel vm)
	{
		foreach (IViewModelStateObserver observer in _observers)
		{
			observer.OnViewModelStarted(vm);
		}
	}

	public void Resumed(ScreenViewModel vm)
	{
		foreach (IViewModelStateObserver observer in _observers)
		{
			observer.OnViewModelResumed(vm);
		}
	}
}
