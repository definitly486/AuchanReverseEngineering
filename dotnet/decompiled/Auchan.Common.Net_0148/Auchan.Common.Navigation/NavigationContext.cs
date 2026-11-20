using System;
using System.Threading.Tasks;

namespace Auchan.Common.Navigation;

public class NavigationContext : INavigationContext
{
	public bool ShouldNavigateToSScan { get; set; }

	public Type? DelayedNavigationType { get; set; }

	public object? DelayedNavigationParameter { get; set; }

	public TaskCompletionSource? DelayedNavigationTaskSource { get; set; }

	public Type? AfterAuthNavigationType { get; set; }

	public object? AfterAuthNavigationParameter { get; set; }

	public bool IsStartForExtraOnboardingsShowed { get; set; }

	public bool IsNavigating { get; set; }

	public bool IsNavigatedFromStart { get; set; }

	public void Reset()
	{
		ShouldNavigateToSScan = false;
	}
}
