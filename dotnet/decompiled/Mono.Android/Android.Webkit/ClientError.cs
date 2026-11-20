using System.Runtime.Versioning;

namespace Android.Webkit;

public enum ClientError
{
	Authentication = -4,
	BadUrl = -12,
	Connect = -6,
	FailedSslHandshake = -11,
	File = -13,
	FileNotFound = -14,
	HostLookup = -2,
	Io = -7,
	ProxyAuthentication = -5,
	RedirectLoop = -9,
	Timeout = -8,
	TooManyRequests = -15,
	Unknown = -1,
	[SupportedOSPlatform("android26.0")]
	UnsafeResource = -16,
	UnsupportedAuthScheme = -3,
	UnsupportedScheme = -10
}
