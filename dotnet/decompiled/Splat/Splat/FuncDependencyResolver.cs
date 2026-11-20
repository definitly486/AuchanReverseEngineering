using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Splat;

public class FuncDependencyResolver : IDependencyResolver, IReadonlyDependencyResolver, IMutableDependencyResolver, IDisposable
{
	private readonly Func<Type?, string?, IEnumerable<object>> _innerGetServices;

	private readonly Action<Func<object?>, Type?, string?>? _innerRegister;

	private readonly Action<Type?, string?>? _unregisterCurrent;

	private readonly Action<Type?, string?>? _unregisterAll;

	private readonly Dictionary<(Type? type, string callback), List<Action<IDisposable>>> _callbackRegistry;

	private IDisposable _inner;

	private bool _isDisposed;

	public FuncDependencyResolver(Func<Type?, string?, IEnumerable<object>> getAllServices, Action<Func<object?>, Type?, string?>? register = null, Action<Type?, string?>? unregisterCurrent = null, Action<Type?, string?>? unregisterAll = null, IDisposable? toDispose = null)
	{
		_innerGetServices = getAllServices;
		_innerRegister = register;
		_unregisterCurrent = unregisterCurrent;
		_unregisterAll = unregisterAll;
		_callbackRegistry = new Dictionary<(Type, string), List<Action<IDisposable>>>();
		_inner = toDispose ?? ActionDisposable.Empty;
		base._002Ector();
	}

	public object? GetService(Type? serviceType, string? contract = null)
	{
		return GetServices(serviceType, contract).LastOrDefault();
	}

	public IEnumerable<object> GetServices(Type? serviceType, string? contract = null)
	{
		if ((object)serviceType == null)
		{
			serviceType = typeof(NullServiceType);
		}
		return _innerGetServices(serviceType, contract) ?? Array.Empty<object>();
	}

	public bool HasRegistration(Type? serviceType, string? contract = null)
	{
		if ((object)serviceType == null)
		{
			serviceType = typeof(NullServiceType);
		}
		return _innerGetServices(serviceType, contract) != null;
	}

	public void Register(Func<object?> factory, Type? serviceType, string? contract = null)
	{
		if (_innerRegister == null)
		{
			throw new NotImplementedException();
		}
		bool isNull = (object)serviceType == null;
		if ((object)serviceType == null)
		{
			serviceType = typeof(NullServiceType);
		}
		_innerRegister(() => (!isNull) ? factory() : new NullServiceType(factory), serviceType, contract);
		(Type, string) key = (serviceType, contract ?? string.Empty);
		if (!_callbackRegistry.TryGetValue(key, out List<Action<IDisposable>> value))
		{
			return;
		}
		List<Action<IDisposable>> list = null;
		foreach (Action<IDisposable> item in value)
		{
			using BooleanDisposable booleanDisposable = new BooleanDisposable();
			item(booleanDisposable);
			if (booleanDisposable.IsDisposed)
			{
				(list ?? (list = new List<Action<IDisposable>>())).Add(item);
			}
		}
		if (list == null)
		{
			return;
		}
		foreach (Action<IDisposable> item2 in list)
		{
			_callbackRegistry[key].Remove(item2);
		}
	}

	public void UnregisterCurrent(Type? serviceType, string? contract = null)
	{
		if (_unregisterCurrent == null)
		{
			throw new NotImplementedException();
		}
		if ((object)serviceType == null)
		{
			serviceType = typeof(NullServiceType);
		}
		_unregisterCurrent(serviceType, contract);
	}

	public void UnregisterAll(Type? serviceType, string? contract = null)
	{
		if (_unregisterAll == null)
		{
			throw new NotImplementedException();
		}
		if ((object)serviceType == null)
		{
			serviceType = typeof(NullServiceType);
		}
		_unregisterAll(serviceType, contract);
	}

	public IDisposable ServiceRegistrationCallback(Type serviceType, string? contract, Action<IDisposable> callback)
	{
		(Type, string) key = (serviceType, contract ?? string.Empty);
		if (!_callbackRegistry.TryGetValue(key, out List<Action<IDisposable>> value))
		{
			value = new List<Action<IDisposable>>();
			_callbackRegistry[key] = value;
		}
		value.Add(callback);
		return new ActionDisposable(delegate
		{
			value.Remove(callback);
		});
	}

	public void Dispose()
	{
		Dispose(isDisposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool isDisposing)
	{
		if (!_isDisposed)
		{
			if (isDisposing)
			{
				Interlocked.Exchange(ref _inner, ActionDisposable.Empty).Dispose();
			}
			_isDisposed = true;
		}
	}
}
