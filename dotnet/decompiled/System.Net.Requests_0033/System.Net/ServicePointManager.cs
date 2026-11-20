using System.Collections.Concurrent;
using System.Net.Security;
using System.Runtime.CompilerServices;

namespace System.Net;

[Obsolete("WebRequest, HttpWebRequest, ServicePoint, and WebClient are obsolete. Use HttpClient instead. Settings on ServicePointManager no longer affect SslStream or HttpClient.", DiagnosticId = "SYSLIB0014", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
public class ServicePointManager
{
	private static readonly ConcurrentDictionary<string, WeakReference<ServicePoint>> s_servicePointTable = new ConcurrentDictionary<string, WeakReference<ServicePoint>>();

	private static SecurityProtocolType s_securityProtocolType = SecurityProtocolType.SystemDefault;

	private static int s_connectionLimit = 2;

	private static int s_maxServicePointIdleTime = 100000;

	private static int s_dnsRefreshTimeout = 120000;

	[CompilerGenerated]
	private static bool _003CExpect100Continue_003Ek__BackingField = true;

	[CompilerGenerated]
	private static readonly EncryptionPolicy _003CEncryptionPolicy_003Ek__BackingField = EncryptionPolicy.RequireEncryption;

	public static SecurityProtocolType SecurityProtocol => s_securityProtocolType;

	public static RemoteCertificateValidationCallback? ServerCertificateValidationCallback { get; }

	public static bool CheckCertificateRevocationList { get; }
}
