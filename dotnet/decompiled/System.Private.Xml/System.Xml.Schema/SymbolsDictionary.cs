using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace System.Xml.Schema;

[DefaultMember("Item")]
internal sealed class SymbolsDictionary
{
	private int _last;

	private readonly Dictionary<XmlQualifiedName, int> _names;

	private Dictionary<string, int> _wildcards;

	private readonly ArrayList _particles;

	private object _particleLast;

	private bool _isUpaEnforced = true;

	public int Count => _last + 1;

	public bool IsUpaEnforced
	{
		get
		{
			return _isUpaEnforced;
		}
		set
		{
			_isUpaEnforced = value;
		}
	}

	public SymbolsDictionary()
	{
		_names = new Dictionary<XmlQualifiedName, int>();
		_particles = new ArrayList();
	}

	public int AddName(XmlQualifiedName name, object particle)
	{
		if (_names.TryGetValue(name, out var value))
		{
			if (_particles[value] != particle)
			{
				_isUpaEnforced = false;
			}
			return value;
		}
		_names.Add(name, _last);
		_particles.Add(particle);
		return _last++;
	}

	public void AddNamespaceList(NamespaceList list, object particle, bool allowLocal)
	{
		switch (list.Type)
		{
		case NamespaceList.ListType.Any:
			_particleLast = particle;
			break;
		case NamespaceList.ListType.Other:
			AddWildcard(list.Excluded, null);
			if (!allowLocal)
			{
				AddWildcard(string.Empty, null);
			}
			break;
		case NamespaceList.ListType.Set:
		{
			foreach (string item in list.Enumerate)
			{
				AddWildcard(item, particle);
			}
			break;
		}
		}
	}

	private void AddWildcard(string wildcard, object particle)
	{
		if (_wildcards == null)
		{
			_wildcards = new Dictionary<string, int>();
		}
		if (!_wildcards.TryGetValue(wildcard, out var value))
		{
			_wildcards.Add(wildcard, _last);
			_particles.Add(particle);
			_last++;
		}
		else if (particle != null)
		{
			_particles[value] = particle;
		}
	}

	public ICollection GetNamespaceListSymbols(NamespaceList list)
	{
		ArrayList arrayList = new ArrayList();
		foreach (KeyValuePair<XmlQualifiedName, int> name in _names)
		{
			XmlQualifiedName key = name.Key;
			if (key != XmlQualifiedName.Empty && list.Allows(key))
			{
				arrayList.Add(_names[key]);
			}
		}
		if (_wildcards != null)
		{
			foreach (KeyValuePair<string, int> wildcard in _wildcards)
			{
				if (list.Allows(wildcard.Key))
				{
					arrayList.Add(wildcard.Value);
				}
			}
		}
		if (list.Type == NamespaceList.ListType.Any || list.Type == NamespaceList.ListType.Other)
		{
			arrayList.Add(_last);
		}
		return arrayList;
	}

	public bool Exists(XmlQualifiedName name)
	{
		return _names.ContainsKey(name);
	}

	public object GetParticle(int symbol)
	{
		if (symbol != _last)
		{
			return _particles[symbol];
		}
		return _particleLast;
	}
}
