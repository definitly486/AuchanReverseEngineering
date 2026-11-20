namespace System.Security.Cryptography;

public sealed class Oid
{
	private string _value;

	private string _friendlyName;

	private bool _hasInitializedFriendlyName;

	private readonly OidGroup _group;

	public string? Value
	{
		get
		{
			return _value;
		}
		set
		{
			if (_value != null && !_value.Equals(value, StringComparison.Ordinal))
			{
				throw new PlatformNotSupportedException("Cryptography_Oid_SetOnceValue");
			}
			_value = value;
		}
	}

	public string? FriendlyName
	{
		get
		{
			if (!_hasInitializedFriendlyName && _value != null)
			{
				_friendlyName = OidLookup.ToFriendlyName(_value, _group, fallBackToAllGroups: true);
				_hasInitializedFriendlyName = true;
			}
			return _friendlyName;
		}
	}

	public Oid(string oid)
	{
		Value = OidLookup.ToOid(oid, OidGroup.All, fallBackToAllGroups: false) ?? oid;
		_group = OidGroup.All;
	}

	public Oid(string? value, string? friendlyName)
	{
		_value = value;
		_friendlyName = friendlyName;
		_hasInitializedFriendlyName = friendlyName != null;
	}

	public static Oid FromFriendlyName(string friendlyName, OidGroup group)
	{
		ArgumentNullException.ThrowIfNull(friendlyName, "friendlyName");
		return new Oid(OidLookup.ToOid(friendlyName, group, fallBackToAllGroups: false) ?? throw new CryptographicException("Cryptography_Oid_InvalidName"), friendlyName, group);
	}

	private Oid(string value, string friendlyName, OidGroup group)
	{
		_value = value;
		_friendlyName = friendlyName;
		_group = group;
		_hasInitializedFriendlyName = true;
	}
}
