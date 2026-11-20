using System;
using System.Reflection;

namespace AsyncAwaitBestPractices;

internal readonly struct Subscription
{
	public WeakReference? Subscriber { get; }

	public MethodInfo Handler { get; }

	public Subscription(in WeakReference? subscriber, in MethodInfo handler)
	{
		Subscriber = subscriber;
		Handler = handler ?? throw new ArgumentNullException("handler");
	}
}
