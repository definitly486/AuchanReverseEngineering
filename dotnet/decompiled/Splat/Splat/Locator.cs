using System;

namespace Splat;

public static class Locator
{
	public static IReadonlyDependencyResolver Current => InternalLocator.Current;

	public static IMutableDependencyResolver CurrentMutable => InternalLocator.CurrentMutable;

	internal static InternalLocator InternalLocator { get; set; }

	static Locator()
	{
		InternalLocator = new InternalLocator();
	}

	public static void SetLocator(IDependencyResolver dependencyResolver)
	{
		InternalLocator.SetLocator(dependencyResolver);
	}

	public static IDependencyResolver GetLocator()
	{
		return InternalLocator.Internal;
	}

	public static IDisposable RegisterResolverCallbackChanged(Action callback)
	{
		callback.ThrowArgumentNullExceptionIfNull("callback");
		return InternalLocator.RegisterResolverCallbackChanged(callback);
	}

	public static IDisposable SuppressResolverCallbackChangedNotifications()
	{
		return InternalLocator.SuppressResolverCallbackChangedNotifications();
	}

	public static bool AreResolverCallbackChangedNotificationsEnabled()
	{
		return InternalLocator.AreResolverCallbackChangedNotificationsEnabled();
	}
}
