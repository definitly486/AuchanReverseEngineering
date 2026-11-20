using System;
using System.Collections.Generic;
using System.Linq;

namespace Splat;

public class ModernDependencyResolver : IDependencyResolver, IReadonlyDependencyResolver, IMutableDependencyResolver, IDisposable
{
	private readonly Dictionary<(Type serviceType, string? contract), List<Action<IDisposable>>> _callbackRegistry;

	private Dictionary<(Type serviceType, string? contract), List<Func<object?>>>? _registry;

	private bool _isDisposed;

	public ModernDependencyResolver()
		: this(null)
	{
	}

	protected ModernDependencyResolver(Dictionary<(Type serviceType, string? contract), List<Func<object?>>>? registry)
	{
		_registry = ((registry != null) ? registry.ToDictionary<KeyValuePair<(Type, string), List<Func<object>>>, (Type, string), List<Func<object>>>((KeyValuePair<(Type serviceType, string contract), List<Func<object>>> k) => k.Key, (KeyValuePair<(Type serviceType, string contract), List<Func<object>>> v) => v.Value.ToList()) : new Dictionary<(Type, string), List<Func<object>>>());
		_callbackRegistry = new Dictionary<(Type, string), List<Action<IDisposable>>>();
	}

	public bool HasRegistration(Type? serviceType, string? contract = null)
	{
		if (_registry == null)
		{
			return false;
		}
		if ((object)serviceType == null)
		{
			serviceType = typeof(NullServiceType);
		}
		(Type, string) key = GetKey(serviceType, contract);
		if (_registry.TryGetValue(key, out List<Func<object>> value))
		{
			return value.Count > 0;
		}
		return false;
	}

	public void Register(Func<object?> factory, Type? serviceType, string? contract = null)
	{
		if (_registry == null)
		{
			return;
		}
		bool isNull = (object)serviceType == null;
		if ((object)serviceType == null)
		{
			serviceType = typeof(NullServiceType);
		}
		(Type, string) key = GetKey(serviceType, contract);
		if (!_registry.TryGetValue(key, out List<Func<object>> value))
		{
			value = new List<Func<object>>();
			_registry[key] = value;
		}
		value.Add(() => (!isNull) ? factory() : new NullServiceType(factory));
		if (!_callbackRegistry.TryGetValue(key, out List<Action<IDisposable>> value2))
		{
			return;
		}
		List<Action<IDisposable>> list = null;
		foreach (Action<IDisposable> item in value2)
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

	public object? GetService(Type? serviceType, string? contract = null)
	{
		if (_registry == null)
		{
			return null;
		}
		if ((object)serviceType == null)
		{
			serviceType = typeof(NullServiceType);
		}
		(Type, string) key = GetKey(serviceType, contract);
		if (!_registry.TryGetValue(key, out List<Func<object>> value))
		{
			return null;
		}
		Func<object> func = value.LastOrDefault();
		object obj = null;
		if (func != null)
		{
			obj = func();
			if (obj is NullServiceType nullServiceType)
			{
				return nullServiceType.Factory();
			}
		}
		return obj;
	}

	public IEnumerable<object> GetServices(Type? serviceType, string? contract = null)
	{
		if (_registry == null)
		{
			return Array.Empty<object>();
		}
		if ((object)serviceType == null)
		{
			serviceType = typeof(NullServiceType);
		}
		(Type, string) key = GetKey(serviceType, contract);
		if (_registry.TryGetValue(key, out List<Func<object>> value))
		{
			return value.ConvertAll((Func<object?> x) => x());
		}
		return Array.Empty<object>();
	}

	public void UnregisterCurrent(Type? serviceType, string? contract = null)
	{
		if (_registry == null)
		{
			return;
		}
		if ((object)serviceType == null)
		{
			serviceType = typeof(NullServiceType);
		}
		(Type, string) key = GetKey(serviceType, contract);
		if (_registry.TryGetValue(key, out List<Func<object>> value))
		{
			int num = value.Count - 1;
			if (num >= 0)
			{
				value.RemoveAt(num);
			}
		}
	}

	public void UnregisterAll(Type? serviceType, string? contract = null)
	{
		if (_registry != null)
		{
			if ((object)serviceType == null)
			{
				serviceType = typeof(NullServiceType);
			}
			(Type, string) key = GetKey(serviceType, contract);
			_registry[key] = new List<Func<object>>();
		}
	}

	public IDisposable ServiceRegistrationCallback(Type serviceType, string? contract, Action<IDisposable> callback)
	{
		serviceType.ThrowArgumentNullExceptionIfNull("serviceType");
		callback.ThrowArgumentNullExceptionIfNull("callback");
		if (_registry == null)
		{
			return new ActionDisposable(delegate
			{
			});
		}
		(Type, string) key = GetKey(serviceType, contract);
		if (!_callbackRegistry.TryGetValue(key, out List<Action<IDisposable>> value))
		{
			value = new List<Action<IDisposable>>();
			_callbackRegistry[key] = value;
		}
		value.Add(callback);
		ActionDisposable actionDisposable = new ActionDisposable(delegate
		{
			value.Remove(callback);
		});
		if (!_registry.TryGetValue(key, out List<Func<object>> value2))
		{
			return actionDisposable;
		}
		foreach (Func<object> item in value2)
		{
			_ = item;
			callback(actionDisposable);
		}
		return actionDisposable;
	}

	public ModernDependencyResolver Duplicate()
	{
		return new ModernDependencyResolver(_registry);
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
				_registry = null;
			}
			_isDisposed = true;
		}
	}

	private static (Type type, string contract) GetKey(Type? serviceType, string? contract = null)
	{
		return (type: serviceType, contract: contract ?? string.Empty);
	}
}
