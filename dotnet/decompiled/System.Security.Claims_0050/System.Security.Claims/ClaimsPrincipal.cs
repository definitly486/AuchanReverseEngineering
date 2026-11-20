using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;

namespace System.Security.Claims;

[DebuggerDisplay("{DebuggerToString(),nq}")]
public class ClaimsPrincipal : IPrincipal
{
	private readonly List<ClaimsIdentity> _identities = new List<ClaimsIdentity>();

	private static Func<IEnumerable<ClaimsIdentity>, ClaimsIdentity> s_identitySelector = SelectPrimaryIdentity;

	public virtual IEnumerable<Claim> Claims
	{
		get
		{
			foreach (ClaimsIdentity identity in Identities)
			{
				foreach (Claim claim in identity.Claims)
				{
					yield return claim;
				}
			}
		}
	}

	public virtual IEnumerable<ClaimsIdentity> Identities => _identities;

	public virtual IIdentity? Identity
	{
		get
		{
			if (s_identitySelector != null)
			{
				return s_identitySelector(_identities);
			}
			return SelectPrimaryIdentity(_identities);
		}
	}

	private static ClaimsIdentity SelectPrimaryIdentity(IEnumerable<ClaimsIdentity> identities)
	{
		ArgumentNullException.ThrowIfNull(identities, "identities");
		foreach (ClaimsIdentity identity in identities)
		{
			if (identity != null)
			{
				return identity;
			}
		}
		return null;
	}

	public virtual void AddIdentity(ClaimsIdentity identity)
	{
		ArgumentNullException.ThrowIfNull(identity, "identity");
		_identities.Add(identity);
	}

	public virtual bool IsInRole(string role)
	{
		for (int i = 0; i < _identities.Count; i++)
		{
			if (_identities[i] != null && _identities[i].HasClaim(_identities[i].RoleClaimType, role))
			{
				return true;
			}
		}
		return false;
	}

	private string DebuggerToString()
	{
		int num = 0;
		foreach (ClaimsIdentity identity in Identities)
		{
			_ = identity;
			num++;
		}
		if (num == 1 && Identity is ClaimsIdentity claimsIdentity)
		{
			return claimsIdentity.DebuggerToString();
		}
		int num2 = 0;
		foreach (Claim claim in Claims)
		{
			_ = claim;
			num2++;
		}
		return $"Identities = {num}, Claims = {num2}";
	}
}
