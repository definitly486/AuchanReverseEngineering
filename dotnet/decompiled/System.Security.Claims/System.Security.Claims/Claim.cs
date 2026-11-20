using System.Collections.Generic;

namespace System.Security.Claims;

public class Claim
{
	private readonly byte[] _userSerializationData;

	private readonly string _issuer;

	private readonly string _originalIssuer;

	private Dictionary<string, string> _properties;

	private readonly ClaimsIdentity _subject;

	private readonly string _type;

	private readonly string _value;

	private readonly string _valueType;

	public ClaimsIdentity? Subject => _subject;

	public string Type => _type;

	public string Value => _value;

	public Claim(string type, string value, string? valueType, string? issuer, string? originalIssuer, ClaimsIdentity? subject)
		: this(type, value, valueType, issuer, originalIssuer, subject, null, null)
	{
	}

	internal Claim(string type, string value, string valueType, string issuer, string originalIssuer, ClaimsIdentity subject, string propertyKey, string propertyValue)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		ArgumentNullException.ThrowIfNull(value, "value");
		_type = type;
		_value = value;
		_valueType = (string.IsNullOrEmpty(valueType) ? "http://www.w3.org/2001/XMLSchema#string" : valueType);
		_issuer = (string.IsNullOrEmpty(issuer) ? "LOCAL AUTHORITY" : issuer);
		_originalIssuer = (string.IsNullOrEmpty(originalIssuer) ? _issuer : originalIssuer);
		_subject = subject;
		if (propertyKey != null)
		{
			_properties = new Dictionary<string, string>();
			_properties[propertyKey] = propertyValue;
		}
	}

	protected Claim(Claim other, ClaimsIdentity? subject)
	{
		ArgumentNullException.ThrowIfNull(other, "other");
		_issuer = other._issuer;
		_originalIssuer = other._originalIssuer;
		_subject = subject;
		_type = other._type;
		_value = other._value;
		_valueType = other._valueType;
		if (other._properties != null)
		{
			_properties = new Dictionary<string, string>(other._properties);
		}
		if (other._userSerializationData != null)
		{
			_userSerializationData = other._userSerializationData.Clone() as byte[];
		}
	}

	public virtual Claim Clone(ClaimsIdentity? identity)
	{
		return new Claim(this, identity);
	}

	public override string ToString()
	{
		return _type + ": " + _value;
	}
}
