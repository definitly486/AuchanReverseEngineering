using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Polly.Registry;

public class PolicyRegistry : IConcurrentPolicyRegistry<string>, IPolicyRegistry<string>, IReadOnlyPolicyRegistry<string>, IEnumerable<KeyValuePair<string, IsPolicy>>, IEnumerable
{
	private readonly ConcurrentDictionary<string, IsPolicy> _registry = new ConcurrentDictionary<string, IsPolicy>();

	public int Count => _registry.Count;

	public IsPolicy this[string key]
	{
		get
		{
			return _registry[key];
		}
		set
		{
			_registry[key] = value;
		}
	}

	public PolicyRegistry()
	{
	}

	internal PolicyRegistry(IDictionary<string, IsPolicy> registry)
	{
		_registry = new ConcurrentDictionary<string, IsPolicy>(registry);
	}

	public void Add<TPolicy>(string key, TPolicy policy) where TPolicy : IsPolicy
	{
		((IDictionary<string, IsPolicy>)_registry).Add(key, (IsPolicy)policy);
	}

	public bool TryAdd<TPolicy>(string key, TPolicy policy) where TPolicy : IsPolicy
	{
		return _registry.TryAdd(key, policy);
	}

	public TPolicy Get<TPolicy>(string key) where TPolicy : IsPolicy
	{
		return (TPolicy)_registry[key];
	}

	public bool TryGet<TPolicy>(string key, out TPolicy policy) where TPolicy : IsPolicy
	{
		policy = default(TPolicy);
		IsPolicy value;
		bool num = _registry.TryGetValue(key, out value);
		if (num)
		{
			policy = (TPolicy)value;
		}
		return num;
	}

	public void Clear()
	{
		_registry.Clear();
	}

	public bool ContainsKey(string key)
	{
		return _registry.ContainsKey(key);
	}

	public bool Remove(string key)
	{
		return ((IDictionary<string, IsPolicy>)_registry).Remove(key);
	}

	public bool TryRemove<TPolicy>(string key, out TPolicy policy) where TPolicy : IsPolicy
	{
		policy = default(TPolicy);
		IsPolicy value;
		bool num = _registry.TryRemove(key, out value);
		if (num)
		{
			policy = (TPolicy)value;
		}
		return num;
	}

	public bool TryUpdate<TPolicy>(string key, TPolicy newPolicy, TPolicy comparisonPolicy) where TPolicy : IsPolicy
	{
		return _registry.TryUpdate(key, newPolicy, comparisonPolicy);
	}

	public TPolicy GetOrAdd<TPolicy>(string key, Func<string, TPolicy> policyFactory) where TPolicy : IsPolicy
	{
		return (TPolicy)_registry.GetOrAdd(key, (string k) => policyFactory(k));
	}

	public TPolicy GetOrAdd<TPolicy>(string key, TPolicy policy) where TPolicy : IsPolicy
	{
		return (TPolicy)_registry.GetOrAdd(key, policy);
	}

	public TPolicy AddOrUpdate<TPolicy>(string key, Func<string, TPolicy> addPolicyFactory, Func<string, TPolicy, TPolicy> updatePolicyFactory) where TPolicy : IsPolicy
	{
		return (TPolicy)_registry.AddOrUpdate(key, (string k) => addPolicyFactory(k), (string k, IsPolicy e) => updatePolicyFactory(k, (TPolicy)e));
	}

	public TPolicy AddOrUpdate<TPolicy>(string key, TPolicy addPolicy, Func<string, TPolicy, TPolicy> updatePolicyFactory) where TPolicy : IsPolicy
	{
		return (TPolicy)_registry.AddOrUpdate(key, addPolicy, (string k, IsPolicy e) => updatePolicyFactory(k, (TPolicy)e));
	}

	public IEnumerator<KeyValuePair<string, IsPolicy>> GetEnumerator()
	{
		return _registry.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
