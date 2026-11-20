using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Xml;

public class XmlNamespaceManager : IXmlNamespaceResolver, IEnumerable
{
	private struct NamespaceDeclaration
	{
		public string prefix;

		public string uri;

		public int scopeId;

		public int previousNsIndex;

		public void Set(string prefix, string uri, int scopeId, int previousNsIndex)
		{
			this.prefix = prefix;
			this.uri = uri;
			this.scopeId = scopeId;
			this.previousNsIndex = previousNsIndex;
		}
	}

	private NamespaceDeclaration[] _nsdecls;

	private int _lastDecl;

	private readonly XmlNameTable _nameTable;

	private int _scopeId;

	private Dictionary<string, int> _hashTable;

	private bool _useHashtable;

	private readonly string _xml;

	private readonly string _xmlNs;

	public virtual XmlNameTable? NameTable => _nameTable;

	public virtual string DefaultNamespace => LookupNamespace(string.Empty) ?? string.Empty;

	internal XmlNamespaceManager()
	{
	}

	public XmlNamespaceManager(XmlNameTable nameTable)
	{
		_nameTable = nameTable;
		_xml = nameTable.Add("xml");
		_xmlNs = nameTable.Add("xmlns");
		_nsdecls = new NamespaceDeclaration[8];
		string text = nameTable.Add(string.Empty);
		_nsdecls[0].Set(text, text, -1, -1);
		_nsdecls[1].Set(_xmlNs, nameTable.Add("http://www.w3.org/2000/xmlns/"), -1, -1);
		_nsdecls[2].Set(_xml, nameTable.Add("http://www.w3.org/XML/1998/namespace"), 0, -1);
		_lastDecl = 2;
		_scopeId = 1;
	}

	public virtual void PushScope()
	{
		_scopeId++;
	}

	public virtual bool PopScope()
	{
		int num = _lastDecl;
		if (_scopeId == 1)
		{
			return false;
		}
		while (_nsdecls[num].scopeId == _scopeId)
		{
			if (_useHashtable)
			{
				_hashTable[_nsdecls[num].prefix] = _nsdecls[num].previousNsIndex;
			}
			num--;
		}
		_lastDecl = num;
		_scopeId--;
		return true;
	}

	public virtual void AddNamespace(string prefix, [StringSyntax("Uri")] string uri)
	{
		ArgumentNullException.ThrowIfNull(prefix, "prefix");
		ArgumentNullException.ThrowIfNull(uri, "uri");
		prefix = _nameTable.Add(prefix);
		uri = _nameTable.Add(uri);
		if (Ref.Equal(_xml, prefix) && !uri.Equals("http://www.w3.org/XML/1998/namespace"))
		{
			throw new ArgumentException("Xml_XmlPrefix");
		}
		if (Ref.Equal(_xmlNs, prefix))
		{
			throw new ArgumentException("Xml_XmlnsPrefix");
		}
		int num = LookupNamespaceDecl(prefix);
		int previousNsIndex = -1;
		if (num != -1)
		{
			if (_nsdecls[num].scopeId == _scopeId)
			{
				_nsdecls[num].uri = uri;
				return;
			}
			previousNsIndex = num;
		}
		if (_lastDecl == _nsdecls.Length - 1)
		{
			NamespaceDeclaration[] array = new NamespaceDeclaration[_nsdecls.Length * 2];
			Array.Copy(_nsdecls, array, _nsdecls.Length);
			_nsdecls = array;
		}
		_nsdecls[++_lastDecl].Set(prefix, uri, _scopeId, previousNsIndex);
		if (_useHashtable)
		{
			_hashTable[prefix] = _lastDecl;
		}
		else if (_lastDecl >= 16)
		{
			_hashTable = new Dictionary<string, int>(_lastDecl);
			for (int i = 0; i <= _lastDecl; i++)
			{
				_hashTable[_nsdecls[i].prefix] = i;
			}
			_useHashtable = true;
		}
	}

	public virtual void RemoveNamespace(string prefix, [StringSyntax("Uri")] string uri)
	{
		ArgumentNullException.ThrowIfNull(prefix, "prefix");
		ArgumentNullException.ThrowIfNull(uri, "uri");
		for (int num = LookupNamespaceDecl(prefix); num != -1; num = _nsdecls[num].previousNsIndex)
		{
			if (string.Equals(_nsdecls[num].uri, uri) && _nsdecls[num].scopeId == _scopeId)
			{
				_nsdecls[num].uri = null;
			}
		}
	}

	public virtual IEnumerator GetEnumerator()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>(_lastDecl + 1);
		for (int i = 0; i <= _lastDecl; i++)
		{
			if (_nsdecls[i].uri != null)
			{
				dictionary[_nsdecls[i].prefix] = _nsdecls[i].prefix;
			}
		}
		return dictionary.Keys.GetEnumerator();
	}

	public virtual string? LookupNamespace(string prefix)
	{
		int num = LookupNamespaceDecl(prefix);
		if (num != -1)
		{
			return _nsdecls[num].uri;
		}
		return null;
	}

	private int LookupNamespaceDecl(string prefix)
	{
		if (_useHashtable)
		{
			if (_hashTable.TryGetValue(prefix, out var value))
			{
				while (value != -1 && _nsdecls[value].uri == null)
				{
					value = _nsdecls[value].previousNsIndex;
				}
				return value;
			}
			return -1;
		}
		for (int num = _lastDecl; num >= 0; num--)
		{
			if ((object)_nsdecls[num].prefix == prefix && _nsdecls[num].uri != null)
			{
				return num;
			}
		}
		for (int num2 = _lastDecl; num2 >= 0; num2--)
		{
			if (string.Equals(_nsdecls[num2].prefix, prefix) && _nsdecls[num2].uri != null)
			{
				return num2;
			}
		}
		return -1;
	}

	public virtual string? LookupPrefix([StringSyntax("Uri")] string uri)
	{
		for (int num = _lastDecl; num >= 0; num--)
		{
			if (string.Equals(_nsdecls[num].uri, uri))
			{
				string prefix = _nsdecls[num].prefix;
				if (string.Equals(LookupNamespace(prefix), uri))
				{
					return prefix;
				}
			}
		}
		return null;
	}
}
