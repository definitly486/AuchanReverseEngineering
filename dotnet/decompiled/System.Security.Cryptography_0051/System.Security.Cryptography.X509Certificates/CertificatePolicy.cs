using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates.Asn1;

namespace System.Security.Cryptography.X509Certificates;

internal sealed class CertificatePolicy
{
	public bool ImplicitAnyCertificatePolicy { get; set; }

	public bool SpecifiedAnyCertificatePolicy { get; set; }

	public ISet<string> DeclaredCertificatePolicies { get; set; }

	public bool ImplicitAnyApplicationPolicy { get; set; }

	public bool SpecifiedAnyApplicationPolicy { get; set; }

	public ISet<string> DeclaredApplicationPolicies { get; set; }

	public int? InhibitAnyDepth { get; set; }

	public List<CertificatePolicyMappingAsn> PolicyMapping { get; set; }

	public int? InhibitMappingDepth { get; set; }

	public int? RequireExplicitPolicyDepth { get; set; }

	public bool AllowsAnyCertificatePolicy
	{
		get
		{
			if (!ImplicitAnyCertificatePolicy)
			{
				return SpecifiedAnyCertificatePolicy;
			}
			return true;
		}
	}

	public bool AllowsAnyApplicationPolicy
	{
		get
		{
			if (!ImplicitAnyApplicationPolicy)
			{
				return SpecifiedAnyApplicationPolicy;
			}
			return true;
		}
	}
}
