using System;
using System.Collections.Generic;
using System.Threading;

namespace Splat;

internal class InternalLocator : IDisposable
{
	private readonly List<Action> _resolverChanged = new List<Action>();

	private readonly IDisposable _resolverChangedNotification;

	private volatile int _resolverChangedNotificationSuspendCount;

	private bool _disposedValue;

	public IReadonlyDependencyResolver Current => Internal;

	public IMutableDependencyResolver CurrentMutable => Internal;

	internal IDependencyResolver Internal { get; private set; }

	internal InternalLocator()
	{
		Internal = new ModernDependencyResolver();
		_resolverChangedNotification = RegisterResolverCallbackChanged(delegate
		{
			if (CurrentMutable != null)
			{
				CurrentMutable.InitializeSplat();
			}
		});
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public void SetLocator(IDependencyResolver dependencyResolver)
	{
		Internal = dependencyResolver ?? throw new ArgumentNullException("dependencyResolver");
		if (AreResolverCallbackChangedNotificationsEnabled())
		{
			Action[] array = null;
			lock (_resolverChanged)
			{
				array = _resolverChanged.ToArray();
			}
			Action[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i]();
			}
		}
	}

	public IDisposable RegisterResolverCallbackChanged(Action callback)
	{
		lock (_resolverChanged)
		{
			_resolverChanged.Add(callback);
		}
		if (AreResolverCallbackChangedNotificationsEnabled())
		{
			callback();
		}
		return new ActionDisposable(delegate
		{
			lock (_resolverChanged)
			{
				_resolverChanged.Remove(callback);
			}
		});
	}

	public IDisposable SuppressResolverCallbackChangedNotifications()
	{
		Interlocked.Increment(ref _resolverChangedNotificationSuspendCount);
		return new ActionDisposable(delegate
		{
			Interlocked.Decrement(ref _resolverChangedNotificationSuspendCount);
		});
	}

	public bool AreResolverCallbackChangedNotificationsEnabled()
	{
		return _resolverChangedNotificationSuspendCount == 0;
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposedValue)
		{
			if (disposing)
			{
				Internal.Dispose();
				_resolverChangedNotification.Dispose();
			}
			_disposedValue = true;
		}
	}
}
