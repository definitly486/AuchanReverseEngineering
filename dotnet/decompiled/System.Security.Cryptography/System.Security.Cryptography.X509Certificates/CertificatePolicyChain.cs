using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates.Asn1;

namespace System.Security.Cryptography.X509Certificates;

internal sealed class CertificatePolicyChain
{
	private readonly CertificatePolicy[] _policies;

	private bool _failAllCertificatePolicies;

	public CertificatePolicyChain(List<X509Certificate2> chain)
	{
		_policies = new CertificatePolicy[chain.Count];
		ReadPolicies(chain);
	}

	internal bool MatchesCertificatePolicies(OidCollection policyOids)
	{
		OidEnumerator enumerator = policyOids.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Oid current = enumerator.Current;
			if (!MatchesCertificatePolicies(current))
			{
				return false;
			}
		}
		return true;
	}

	internal bool MatchesCertificatePolicies(Oid policyOid)
	{
		if (_failAllCertificatePolicies)
		{
			return false;
		}
		string text = policyOid.Value;
		for (int i = 1; i <= _policies.Length; i++)
		{
			int num = _policies.Length - i;
			CertificatePolicy certificatePolicy = _policies[num];
			string text2 = text;
			if (certificatePolicy.PolicyMapping != null)
			{
				for (int j = 0; j < certificatePolicy.PolicyMapping.Count; j++)
				{
					CertificatePolicyMappingAsn certificatePolicyMappingAsn = certificatePolicy.PolicyMapping[j];
					if (StringComparer.Ordinal.Equals(certificatePolicyMappingAsn.IssuerDomainPolicy, text2))
					{
						text = certificatePolicyMappingAsn.SubjectDomainPolicy;
					}
				}
			}
			if (!certificatePolicy.AllowsAnyCertificatePolicy)
			{
				if (certificatePolicy.DeclaredCertificatePolicies == null)
				{
					return false;
				}
				if (!certificatePolicy.DeclaredCertificatePolicies.Contains(text2))
				{
					return false;
				}
			}
		}
		return true;
	}

	internal bool MatchesApplicationPolicies(OidCollection policyOids)
	{
		OidEnumerator enumerator = policyOids.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Oid current = enumerator.Current;
			if (!MatchesApplicationPolicies(current))
			{
				return false;
			}
		}
		return true;
	}

	internal bool MatchesApplicationPolicies(Oid policyOid)
	{
		string value = policyOid.Value;
		for (int i = 1; i <= _policies.Length; i++)
		{
			int num = _policies.Length - i;
			CertificatePolicy certificatePolicy = _policies[num];
			if (!certificatePolicy.AllowsAnyApplicationPolicy)
			{
				if (certificatePolicy.DeclaredApplicationPolicies == null)
				{
					return false;
				}
				if (!certificatePolicy.DeclaredApplicationPolicies.Contains(value))
				{
					return false;
				}
			}
		}
		return true;
	}

	private void ReadPolicies(List<X509Certificate2> chain)
	{
		for (int i = 0; i < chain.Count; i++)
		{
			_policies[i] = ReadPolicy(chain[i]);
		}
		int restriction = chain.Count;
		int restriction2 = restriction;
		int restriction3 = restriction;
		for (int j = 1; j <= chain.Count; j++)
		{
			int num = chain.Count - j;
			CertificatePolicy certificatePolicy = _policies[num];
			if (certificatePolicy.DeclaredCertificatePolicies == null && restriction <= 0)
			{
				_failAllCertificatePolicies = true;
			}
			if (restriction2 <= 0)
			{
				certificatePolicy.ImplicitAnyCertificatePolicy = false;
				certificatePolicy.SpecifiedAnyCertificatePolicy = false;
			}
			else
			{
				restriction2--;
			}
			if (restriction3 <= 0)
			{
				certificatePolicy.PolicyMapping = null;
			}
			else
			{
				restriction2--;
			}
			if (restriction <= 0)
			{
				certificatePolicy.ImplicitAnyCertificatePolicy = false;
				certificatePolicy.ImplicitAnyApplicationPolicy = false;
			}
			else
			{
				restriction--;
			}
			ApplyRestriction(ref restriction2, certificatePolicy.InhibitAnyDepth);
			ApplyRestriction(ref restriction3, certificatePolicy.InhibitMappingDepth);
			ApplyRestriction(ref restriction, certificatePolicy.RequireExplicitPolicyDepth);
		}
	}

	private static void ApplyRestriction(ref int restriction, int? policyRestriction)
	{
		if (policyRestriction.HasValue)
		{
			restriction = Math.Min(restriction, policyRestriction.Value);
		}
	}

	private static CertificatePolicy ReadPolicy(X509Certificate2 cert)
	{
		HashSet<string> hashSet = null;
		HashSet<string> hashSet2 = null;
		CertificatePolicy certificatePolicy = new CertificatePolicy();
		PolicyData policyData = cert.Pal.GetPolicyData();
		if (policyData.ApplicationCertPolicies != null)
		{
			hashSet = ReadCertPolicyExtension(policyData.ApplicationCertPolicies);
		}
		if (policyData.CertPolicies != null)
		{
			certificatePolicy.DeclaredCertificatePolicies = ReadCertPolicyExtension(policyData.CertPolicies);
		}
		if (policyData.CertPolicyMappings != null)
		{
			certificatePolicy.PolicyMapping = ReadCertPolicyMappingsExtension(policyData.CertPolicyMappings);
		}
		if (policyData.CertPolicyConstraints != null)
		{
			ReadCertPolicyConstraintsExtension(policyData.CertPolicyConstraints, certificatePolicy);
		}
		if (policyData.EnhancedKeyUsage != null && hashSet == null)
		{
			hashSet2 = ReadExtendedKeyUsageExtension(policyData.EnhancedKeyUsage);
		}
		if (policyData.InhibitAnyPolicyExtension != null)
		{
			certificatePolicy.InhibitAnyDepth = ReadInhibitAnyPolicyExtension(policyData.InhibitAnyPolicyExtension);
		}
		certificatePolicy.DeclaredApplicationPolicies = hashSet ?? hashSet2;
		certificatePolicy.ImplicitAnyApplicationPolicy = certificatePolicy.DeclaredApplicationPolicies == null;
		certificatePolicy.ImplicitAnyCertificatePolicy = certificatePolicy.DeclaredCertificatePolicies == null;
		certificatePolicy.SpecifiedAnyApplicationPolicy = CheckExplicitAnyPolicy(certificatePolicy.DeclaredApplicationPolicies);
		certificatePolicy.SpecifiedAnyCertificatePolicy = CheckExplicitAnyPolicy(certificatePolicy.DeclaredCertificatePolicies);
		return certificatePolicy;
	}

	private static bool CheckExplicitAnyPolicy(ISet<string> declaredPolicies)
	{
		return declaredPolicies?.Remove("2.5.29.32.0") ?? false;
	}

	private static int ReadInhibitAnyPolicyExtension(byte[] rawData)
	{
		try
		{
			AsnValueReader asnValueReader = new AsnValueReader(rawData, AsnEncodingRules.DER);
			asnValueReader.TryReadInt32(out var value);
			asnValueReader.ThrowIfNotEmpty();
			return value;
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
	}

	private static void ReadCertPolicyConstraintsExtension(byte[] rawData, CertificatePolicy policy)
	{
		PolicyConstraintsAsn policyConstraintsAsn = PolicyConstraintsAsn.Decode(rawData, AsnEncodingRules.DER);
		policy.RequireExplicitPolicyDepth = policyConstraintsAsn.RequireExplicitPolicyDepth;
		policy.InhibitMappingDepth = policyConstraintsAsn.InhibitMappingDepth;
	}

	private static HashSet<string> ReadExtendedKeyUsageExtension(byte[] rawData)
	{
		HashSet<string> hashSet = new HashSet<string>();
		try
		{
			AsnValueReader asnValueReader = new AsnValueReader(rawData, AsnEncodingRules.DER);
			AsnValueReader asnValueReader2 = asnValueReader.ReadSequence();
			asnValueReader.ThrowIfNotEmpty();
			while (asnValueReader2.HasData)
			{
				hashSet.Add(asnValueReader2.ReadObjectIdentifier());
			}
			return hashSet;
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
	}

	internal static HashSet<string> ReadCertPolicyExtension(byte[] rawData)
	{
		try
		{
			AsnValueReader asnValueReader = new AsnValueReader(rawData, AsnEncodingRules.DER);
			AsnValueReader reader = asnValueReader.ReadSequence();
			asnValueReader.ThrowIfNotEmpty();
			HashSet<string> hashSet = new HashSet<string>();
			while (reader.HasData)
			{
				PolicyInformationAsn.Decode(ref reader, rawData, out var decoded);
				hashSet.Add(decoded.PolicyIdentifier);
			}
			return hashSet;
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
	}

	private static List<CertificatePolicyMappingAsn> ReadCertPolicyMappingsExtension(byte[] rawData)
	{
		try
		{
			AsnValueReader asnValueReader = new AsnValueReader(rawData, AsnEncodingRules.DER);
			AsnValueReader reader = asnValueReader.ReadSequence();
			asnValueReader.ThrowIfNotEmpty();
			List<CertificatePolicyMappingAsn> list = new List<CertificatePolicyMappingAsn>();
			while (reader.HasData)
			{
				CertificatePolicyMappingAsn.Decode(ref reader, out var decoded);
				list.Add(decoded);
			}
			return list;
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
	}
}
