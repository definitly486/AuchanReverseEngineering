using System.Runtime.CompilerServices;

namespace System.Security.Cryptography;

internal static class Oids
{
	[CompilerGenerated]
	private static Oid _003Csecp256r1Oid_003Ek__BackingField;

	[CompilerGenerated]
	private static Oid _003Csecp384r1Oid_003Ek__BackingField;

	[CompilerGenerated]
	private static Oid _003Csecp521r1Oid_003Ek__BackingField;

	[CompilerGenerated]
	private static Oid _003CLocalKeyIdOid_003Ek__BackingField;

	[CompilerGenerated]
	private static Oid _003CBasicConstraints2Oid_003Ek__BackingField;

	[CompilerGenerated]
	private static Oid _003CEnhancedKeyUsageOid_003Ek__BackingField;

	[CompilerGenerated]
	private static Oid _003CKeyUsageOid_003Ek__BackingField;

	[CompilerGenerated]
	private static Oid _003CAuthorityKeyIdentifierOid_003Ek__BackingField;

	[CompilerGenerated]
	private static Oid _003CSubjectKeyIdentifierOid_003Ek__BackingField;

	[CompilerGenerated]
	private static Oid _003CSubjectAltNameOid_003Ek__BackingField;

	[CompilerGenerated]
	private static Oid _003CAuthorityInformationAccessOid_003Ek__BackingField;

	internal static Oid secp256r1Oid => _003Csecp256r1Oid_003Ek__BackingField ?? (_003Csecp256r1Oid_003Ek__BackingField = new Oid("1.2.840.10045.3.1.7", "nistP256"));

	internal static Oid secp384r1Oid => _003Csecp384r1Oid_003Ek__BackingField ?? (_003Csecp384r1Oid_003Ek__BackingField = new Oid("1.3.132.0.34", "nistP384"));

	internal static Oid secp521r1Oid => _003Csecp521r1Oid_003Ek__BackingField ?? (_003Csecp521r1Oid_003Ek__BackingField = new Oid("1.3.132.0.35", "nistP521"));

	internal static Oid LocalKeyIdOid => _003CLocalKeyIdOid_003Ek__BackingField ?? (_003CLocalKeyIdOid_003Ek__BackingField = InitializeOid("1.2.840.113549.1.9.21"));

	internal static Oid BasicConstraints2Oid => _003CBasicConstraints2Oid_003Ek__BackingField ?? (_003CBasicConstraints2Oid_003Ek__BackingField = InitializeOid("2.5.29.19"));

	internal static Oid EnhancedKeyUsageOid => _003CEnhancedKeyUsageOid_003Ek__BackingField ?? (_003CEnhancedKeyUsageOid_003Ek__BackingField = InitializeOid("2.5.29.37"));

	internal static Oid KeyUsageOid => _003CKeyUsageOid_003Ek__BackingField ?? (_003CKeyUsageOid_003Ek__BackingField = InitializeOid("2.5.29.15"));

	internal static Oid AuthorityKeyIdentifierOid => _003CAuthorityKeyIdentifierOid_003Ek__BackingField ?? (_003CAuthorityKeyIdentifierOid_003Ek__BackingField = InitializeOid("2.5.29.35"));

	internal static Oid SubjectKeyIdentifierOid => _003CSubjectKeyIdentifierOid_003Ek__BackingField ?? (_003CSubjectKeyIdentifierOid_003Ek__BackingField = InitializeOid("2.5.29.14"));

	internal static Oid SubjectAltNameOid => _003CSubjectAltNameOid_003Ek__BackingField ?? (_003CSubjectAltNameOid_003Ek__BackingField = InitializeOid("2.5.29.17"));

	internal static Oid AuthorityInformationAccessOid => _003CAuthorityInformationAccessOid_003Ek__BackingField ?? (_003CAuthorityInformationAccessOid_003Ek__BackingField = InitializeOid("1.3.6.1.5.5.7.1.1"));

	private static Oid InitializeOid(string oidValue)
	{
		Oid oid = new Oid(oidValue, null);
		_ = oid.FriendlyName;
		return oid;
	}
}
