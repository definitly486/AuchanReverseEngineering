using System.Collections.Generic;
using System.Security.Cryptography.Asn1;

namespace System.Security.Cryptography.X509Certificates;

public sealed class X509SubjectAlternativeNameExtension : X509Extension
{
	private List<GeneralNameAsn> _decoded;

	public X509SubjectAlternativeNameExtension()
		: base(Oids.SubjectAltNameOid)
	{
		_decoded = new List<GeneralNameAsn>(0);
	}

	public override void CopyFrom(AsnEncodedData asnEncodedData)
	{
		base.CopyFrom(asnEncodedData);
		_decoded = null;
	}
}
