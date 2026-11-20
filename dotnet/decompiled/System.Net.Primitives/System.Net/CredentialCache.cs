namespace System.Net;

public class CredentialCache
{
	public static ICredentials DefaultCredentials => SystemNetworkCredential.s_defaultCredential;

	public static NetworkCredential DefaultNetworkCredentials => SystemNetworkCredential.s_defaultCredential;
}
