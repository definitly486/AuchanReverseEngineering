using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;

namespace System.Security.Claims;

[DebuggerDisplay("{DebuggerToString(),nq}")]
public class ClaimsIdentity : IIdentity
{
	private byte[] _userSerializationData;

	private ClaimsIdentity _actor;

	private string _authenticationType;

	private object _bootstrapContext;

	private List<List<Claim>> _externalClaims;

	private string _label;

	private readonly List<Claim> _instanceClaims = new List<Claim>();

	private string _nameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";

	private string _roleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

	private readonly StringComparison _stringComparison = StringComparison.OrdinalIgnoreCase;

	public virtual string? AuthenticationType => _authenticationType;

	public virtual bool IsAuthenticated => !string.IsNullOrEmpty(_authenticationType);

	public ClaimsIdentity? Actor => _actor;

	public virtual IEnumerable<Claim> Claims
	{
		get
		{
			if (_externalClaims == null)
			{
				return _instanceClaims;
			}
			return CombinedClaimsIterator();
		}
	}

	internal List<List<Claim>> ExternalClaims => _externalClaims ?? (_externalClaims = new List<List<Claim>>());

	public virtual string? Name => FindFirst(_nameClaimType)?.Value;

	public string NameClaimType => _nameClaimType;

	public string RoleClaimType => _roleClaimType;

	public ClaimsIdentity()
		: this(null, null, null, null, null)
	{
	}

	public ClaimsIdentity(IIdentity? identity)
		: this(identity, null, null, null, null)
	{
	}

	public ClaimsIdentity(IIdentity? identity, IEnumerable<Claim>? claims, string? authenticationType, string? nameType, string? roleType)
	{
		ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
		_authenticationType = ((identity != null && string.IsNullOrEmpty(authenticationType)) ? identity.AuthenticationType : authenticationType);
		_nameClaimType = ((!string.IsNullOrEmpty(nameType)) ? nameType : ((claimsIdentity != null) ? claimsIdentity._nameClaimType : "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"));
		_roleClaimType = ((!string.IsNullOrEmpty(roleType)) ? roleType : ((claimsIdentity != null) ? claimsIdentity._roleClaimType : "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"));
		if (claimsIdentity != null)
		{
			_label = claimsIdentity._label;
			_bootstrapContext = claimsIdentity._bootstrapContext;
			if (claimsIdentity.Actor != null)
			{
				if (IsCircular(claimsIdentity.Actor))
				{
					throw new InvalidOperationException("InvalidOperationException_ActorGraphCircular");
				}
				_actor = claimsIdentity.Actor;
			}
			SafeAddClaims(claimsIdentity._instanceClaims);
		}
		else if (identity != null && !string.IsNullOrEmpty(identity.Name))
		{
			SafeAddClaim(new Claim(_nameClaimType, identity.Name, "http://www.w3.org/2001/XMLSchema#string", "LOCAL AUTHORITY", "LOCAL AUTHORITY", this));
		}
		if (claims != null)
		{
			SafeAddClaims(claims);
		}
	}

	protected ClaimsIdentity(ClaimsIdentity other)
	{
		ArgumentNullException.ThrowIfNull(other, "other");
		Initialize(other);
	}

	protected ClaimsIdentity(ClaimsIdentity other, StringComparison stringComparison)
	{
		ArgumentNullException.ThrowIfNull(other, "other");
		ValidateStringComparison(stringComparison);
		_stringComparison = stringComparison;
		Initialize(other);
	}

	private IEnumerable<Claim> CombinedClaimsIterator()
	{
		for (int i = 0; i < _instanceClaims.Count; i++)
		{
			yield return _instanceClaims[i];
		}
		for (int i = 0; i < _externalClaims.Count; i++)
		{
			if (_externalClaims[i] == null)
			{
				continue;
			}
			foreach (Claim item in _externalClaims[i])
			{
				yield return item;
			}
		}
	}

	public virtual ClaimsIdentity Clone()
	{
		return new ClaimsIdentity(this, _stringComparison);
	}

	public virtual void AddClaim(Claim claim)
	{
		ArgumentNullException.ThrowIfNull(claim, "claim");
		if (claim.Subject == this)
		{
			_instanceClaims.Add(claim);
		}
		else
		{
			_instanceClaims.Add(claim.Clone(this));
		}
	}

	private void SafeAddClaims(IEnumerable<Claim> claims)
	{
		foreach (Claim claim in claims)
		{
			if (claim != null)
			{
				if (claim.Subject == this)
				{
					_instanceClaims.Add(claim);
				}
				else
				{
					_instanceClaims.Add(claim.Clone(this));
				}
			}
		}
	}

	private void SafeAddClaim(Claim claim)
	{
		if (claim != null)
		{
			if (claim.Subject == this)
			{
				_instanceClaims.Add(claim);
			}
			else
			{
				_instanceClaims.Add(claim.Clone(this));
			}
		}
	}

	public virtual Claim? FindFirst(string type)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		foreach (Claim claim in Claims)
		{
			if (claim != null && string.Equals(claim.Type, type, _stringComparison))
			{
				return claim;
			}
		}
		return null;
	}

	public virtual bool HasClaim(string type, string value)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		ArgumentNullException.ThrowIfNull(value, "value");
		foreach (Claim claim in Claims)
		{
			if (claim != null && string.Equals(claim.Type, type, _stringComparison) && string.Equals(claim.Value, value, StringComparison.Ordinal))
			{
				return true;
			}
		}
		return false;
	}

	private void Initialize(ClaimsIdentity other)
	{
		if (other._actor != null)
		{
			_actor = other._actor.Clone();
		}
		_authenticationType = other._authenticationType;
		_bootstrapContext = other._bootstrapContext;
		_label = other._label;
		_nameClaimType = other._nameClaimType;
		_roleClaimType = other._roleClaimType;
		if (other._userSerializationData != null)
		{
			_userSerializationData = other._userSerializationData.Clone() as byte[];
		}
		SafeAddClaims(other._instanceClaims);
	}

	private bool IsCircular(ClaimsIdentity subject)
	{
		if (this == subject)
		{
			return true;
		}
		ClaimsIdentity claimsIdentity = subject;
		while (claimsIdentity.Actor != null)
		{
			if (this == claimsIdentity.Actor)
			{
				return true;
			}
			claimsIdentity = claimsIdentity.Actor;
		}
		return false;
	}

	internal string DebuggerToString()
	{
		int num = 0;
		foreach (Claim claim in Claims)
		{
			_ = claim;
			num++;
		}
		string text = "IsAuthenticated = " + (IsAuthenticated ? "true" : "false");
		if (Name != null)
		{
			text = text + ", Name = " + Name;
		}
		if (num > 0)
		{
			text += $", Claims = {num}";
		}
		return text;
	}

	private static void ValidateStringComparison(StringComparison stringComparison)
	{
		if ((uint)(stringComparison - 2) > 3u)
		{
			throw new ArgumentException("ArgumentException_StringComparisonCultureAware", "stringComparison");
		}
	}
}
