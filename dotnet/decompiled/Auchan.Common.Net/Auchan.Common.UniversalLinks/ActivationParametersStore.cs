using System;
using System.Collections.Generic;

namespace Auchan.Common.UniversalLinks;

internal sealed class ActivationParametersStore : IActivationParametersStore
{
	private readonly object _lock = new object();

	private readonly Dictionary<Type, object> _parameters = new Dictionary<Type, object>();

	public object? PopFor(Type type)
	{
		lock (_lock)
		{
			if (_parameters.TryGetValue(type, out object value))
			{
				_parameters.Remove(type);
			}
			return value;
		}
	}

	public void PushFor(Type type, object parameters)
	{
		lock (_lock)
		{
			_parameters[type] = parameters;
		}
	}
}
