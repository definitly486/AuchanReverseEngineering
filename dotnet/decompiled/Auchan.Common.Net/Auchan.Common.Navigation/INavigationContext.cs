using System;
using System.Threading.Tasks;

namespace Auchan.Common.Navigation;

public interface INavigationContext
{
	bool ShouldNavigateToSScan { get; set; }

	Type? DelayedNavigationType { get; set; }

	object? DelayedNavigationParameter { get; set; }

	TaskCompletionSource? DelayedNavigationTaskSource { get; set; }

	Type? AfterAuthNavigationType { get; set; }

	object? AfterAuthNavigationParameter { get; set; }

	bool IsStartForExtraOnboardingsShowed { get; set; }

	bool IsAwaitingDelayedNavigation => DelayedNavigationType != null;

	bool IsNavigatedFromStart { get; set; }

	bool IsNavigating { get; set; }

	void Reset();
}
