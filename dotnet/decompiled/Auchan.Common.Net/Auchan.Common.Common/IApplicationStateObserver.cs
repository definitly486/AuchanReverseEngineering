using System.Threading.Tasks;

namespace Auchan.Common.Common;

public interface IApplicationStateObserver
{
	Task StartAsync()
	{
		Start();
		return Task.CompletedTask;
	}

	void Start()
	{
	}

	Task OnResumedAsync()
	{
		OnResumed();
		return Task.CompletedTask;
	}

	void OnResumed()
	{
	}

	Task DidBecomeActiveAsync()
	{
		DidBecomeActive();
		return Task.CompletedTask;
	}

	void DidBecomeActive()
	{
	}

	Task OnPausedAsync()
	{
		OnPaused();
		return Task.CompletedTask;
	}

	void OnPaused()
	{
	}
}
