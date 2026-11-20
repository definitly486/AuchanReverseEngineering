using System;
using System.Threading.Tasks;

namespace Auchan.Common.Common;

public interface IApplicationStateManager
{
	event Action? OnStartCallback;

	event Action? OnResumedCallback;

	event Action? OnPausedCallback;

	Task StartAsync();

	Task OnResumedAsync();

	Task DidBecomeActiveAsync();

	Task OnPausedAsync();
}
