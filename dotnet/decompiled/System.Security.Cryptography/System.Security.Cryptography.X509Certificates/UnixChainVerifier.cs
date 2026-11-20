using Internal.Cryptography;

namespace System.Security.Cryptography.X509Certificates;

internal static class UnixChainVerifier
{
	public static bool Verify(X509ChainElement[] chainElements, X509VerificationFlags flags)
	{
		bool isEndEntity = true;
		foreach (X509ChainElement element in chainElements)
		{
			if (HasUnsuppressedError(flags, element, isEndEntity))
			{
				return false;
			}
			isEndEntity = false;
		}
		return true;
	}

	private static bool HasUnsuppressedError(X509VerificationFlags flags, X509ChainElement element, bool isEndEntity)
	{
		X509ChainStatus[] chainElementStatus = element.ChainElementStatus;
		for (int i = 0; i < chainElementStatus.Length; i++)
		{
			X509ChainStatus x509ChainStatus = chainElementStatus[i];
			if (x509ChainStatus.Status == X509ChainStatusFlags.NoError)
			{
				return false;
			}
			X509VerificationFlags? x509VerificationFlags;
			if (x509ChainStatus.Status == X509ChainStatusFlags.RevocationStatusUnknown)
			{
				x509VerificationFlags = (isEndEntity ? new X509VerificationFlags?(X509VerificationFlags.IgnoreEndRevocationUnknown) : ((!IsSelfSigned(element.Certificate)) ? new X509VerificationFlags?(X509VerificationFlags.IgnoreCertificateAuthorityRevocationUnknown) : new X509VerificationFlags?(X509VerificationFlags.IgnoreRootRevocationUnknown)));
			}
			else
			{
				if (x509ChainStatus.Status == X509ChainStatusFlags.OfflineRevocation)
				{
					continue;
				}
				x509VerificationFlags = GetSuppressionFlag(x509ChainStatus.Status);
			}
			if (!x509VerificationFlags.HasValue || (flags & x509VerificationFlags) == 0)
			{
				return true;
			}
		}
		return false;
	}

	private static bool IsSelfSigned(X509Certificate2 cert)
	{
		return cert.SubjectName.RawData.ContentsEqual(cert.IssuerName.RawData);
	}

	private static X509VerificationFlags? GetSuppressionFlag(X509ChainStatusFlags status)
	{
		switch (status)
		{
		case X509ChainStatusFlags.UntrustedRoot:
		case X509ChainStatusFlags.PartialChain:
			return X509VerificationFlags.AllowUnknownCertificateAuthority;
		case X509ChainStatusFlags.NotValidForUsage:
		case X509ChainStatusFlags.CtlNotValidForUsage:
			return X509VerificationFlags.IgnoreWrongUsage;
		case X509ChainStatusFlags.NotTimeValid:
			return X509VerificationFlags.IgnoreNotTimeValid;
		case X509ChainStatusFlags.CtlNotTimeValid:
			return X509VerificationFlags.IgnoreCtlNotTimeValid;
		case X509ChainStatusFlags.InvalidNameConstraints:
		case X509ChainStatusFlags.HasNotSupportedNameConstraint:
		case X509ChainStatusFlags.HasNotDefinedNameConstraint:
		case X509ChainStatusFlags.HasNotPermittedNameConstraint:
		case X509ChainStatusFlags.HasExcludedNameConstraint:
			return X509VerificationFlags.IgnoreInvalidName;
		case X509ChainStatusFlags.InvalidPolicyConstraints:
		case X509ChainStatusFlags.NoIssuanceChainPolicy:
			return X509VerificationFlags.IgnoreInvalidPolicy;
		case X509ChainStatusFlags.InvalidBasicConstraints:
			return X509VerificationFlags.IgnoreInvalidBasicConstraints;
		case X509ChainStatusFlags.HasNotSupportedCriticalExtension:
			return (X509VerificationFlags)8192;
		case X509ChainStatusFlags.NotTimeNested:
			return X509VerificationFlags.IgnoreNotTimeNested;
		default:
			return null;
		}
	}
}
