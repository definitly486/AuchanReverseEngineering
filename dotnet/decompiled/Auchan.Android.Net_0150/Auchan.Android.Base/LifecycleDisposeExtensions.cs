using System;
using System.Collections.Generic;
using AndroidX.Lifecycle;

namespace Auchan.Android.Base;

public static class LifecycleDisposeExtensions
{
	public static T AutoDispose<T>(this T self, ILifecycleOwner lifecycleOwner, Lifecycle.Event disposeEvent) where T : IDisposable
	{
		LifecycleEventObserver observer = new LifecycleEventObserver();
		observer.StateChanged += delegate(ILifecycleOwner s, Lifecycle.Event e)
		{
			if (e != disposeEvent)
			{
				return;
			}
			ref T reference = ref self;
			T val = default(T);
			if (val == null)
			{
				val = reference;
				reference = ref val;
				if (val == null)
				{
					goto IL_003d;
				}
			}
			reference.Dispose();
			goto IL_003d;
			IL_003d:
			s.Lifecycle.RemoveObserver(observer);
		};
		lifecycleOwner.Lifecycle.AddObserver(observer);
		return self;
	}

	public static T AutoDisposeOnDestroy<T>(this T self, ILifecycleOwner lifecycleOwner) where T : IDisposable
	{
		self.AutoDispose(lifecycleOwner, Lifecycle.Event.OnDestroy);
		return self;
	}

	public static T AutoDisposeAllOnDestroy<T>(this T self, ILifecycleOwner lifecycleOwner) where T : IEnumerable<IDisposable>
	{
		return self.AutoDisposeAll(lifecycleOwner, Lifecycle.Event.OnDestroy);
	}

	public static T AutoDisposeAll<T>(this T self, ILifecycleOwner lifecycleOwner, Lifecycle.Event disposeEvent) where T : IEnumerable<IDisposable>
	{
		LifecycleEventObserver observer = new LifecycleEventObserver();
		observer.StateChanged += delegate(ILifecycleOwner s, Lifecycle.Event e)
		{
			if (e == disposeEvent)
			{
				foreach (IDisposable item in self)
				{
					item.Dispose();
				}
				s.Lifecycle.RemoveObserver(observer);
			}
		};
		lifecycleOwner.Lifecycle.AddObserver(observer);
		return self;
	}
}
