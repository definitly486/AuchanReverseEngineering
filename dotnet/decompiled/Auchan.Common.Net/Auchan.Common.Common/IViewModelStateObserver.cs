using Auchan.Common.Base;

namespace Auchan.Common.Common;

public interface IViewModelStateObserver
{
	void OnViewModelStarted(ScreenViewModel vm)
	{
	}

	void OnViewModelResumed(ScreenViewModel vm)
	{
	}
}
