using System.Collections;
using System.Globalization;

namespace System.Xml.Serialization;

public class CodeIdentifiers
{
	private Hashtable _identifiers;

	private Hashtable _reservedIdentifiers;

	private ArrayList _list;

	public CodeIdentifiers()
		: this(caseSensitive: true)
	{
	}

	public CodeIdentifiers(bool caseSensitive)
	{
		if (caseSensitive)
		{
			_identifiers = new Hashtable();
			_reservedIdentifiers = new Hashtable();
		}
		else
		{
			IEqualityComparer equalityComparer = new CaseInsensitiveKeyComparer();
			_identifiers = new Hashtable(equalityComparer);
			_reservedIdentifiers = new Hashtable(equalityComparer);
		}
		_list = new ArrayList();
	}

	public string MakeUnique(string identifier)
	{
		if (IsInUse(identifier))
		{
			int num = 1;
			string text;
			while (true)
			{
				text = identifier + num.ToString(CultureInfo.InvariantCulture);
				if (!IsInUse(text))
				{
					break;
				}
				num++;
			}
			identifier = text;
		}
		if (identifier.Length > 511)
		{
			return MakeUnique("Item");
		}
		return identifier;
	}

	public string AddUnique(string identifier, object? value)
	{
		identifier = MakeUnique(identifier);
		Add(identifier, value);
		return identifier;
	}

	public bool IsInUse(string identifier)
	{
		if (!_identifiers.Contains(identifier))
		{
			return _reservedIdentifiers.Contains(identifier);
		}
		return true;
	}

	public void Add(string identifier, object? value)
	{
		_identifiers.Add(identifier, value);
		_list.Add(value);
	}
}
