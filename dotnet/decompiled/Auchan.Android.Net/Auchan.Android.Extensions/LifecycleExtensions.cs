using System;
using AndroidX.Lifecycle;
using Auchan.Android.Common;

namespace Auchan.Android.Extensions;

public static class LifecycleExtensions
{
	public static void LaunchWhen(this ILifecycleOwner owner, Action callback, Lifecycle.Event @event)
	{
		owner.Lifecycle.AddObserver(new LifecycleCallback(callback, @event));
	}

	public static void LaunchWhenResumed(this ILifecycleOwner owner, Action callback)
	{
		owner.LaunchWhen(callback, Lifecycle.Event.OnResume);
	}
}
