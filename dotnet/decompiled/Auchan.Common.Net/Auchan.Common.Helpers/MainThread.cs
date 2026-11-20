using System;
using System.Reactive.Concurrency;
using System.Threading;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Helpers;

public static class MainThread
{
	private static Lazy<SynchronizationContextScheduler> _lazyScheduler { get; } = new Lazy<SynchronizationContextScheduler>(() => new SynchronizationContextScheduler(SynchronizationContext.Current ?? throw new InvalidOperationException("SynchronizationContext.Current is null")));

	public static IScheduler Scheduler => _lazyScheduler.Value;

	public static void InitializeScheduler()
	{
		_ = _lazyScheduler.Value;
	}

	public static void EnsureOnMainThread()
	{
		if (!Microsoft.Maui.ApplicationModel.MainThread.IsMainThread)
		{
			throw new InvalidOperationException("This should be called on main thread");
		}
	}
}
