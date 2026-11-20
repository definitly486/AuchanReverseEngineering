using System.Runtime.CompilerServices;
using System.Security.Authentication;

namespace System.Net.Security;

public readonly struct SslClientHelloInfo
{
	[CompilerGenerated]
	private readonly string _003CServerName_003Ek__BackingField;

	[CompilerGenerated]
	private readonly SslProtocols _003CSslProtocols_003Ek__BackingField;

	public SslClientHelloInfo(string serverName, SslProtocols sslProtocols)
	{
		_003CServerName_003Ek__BackingField = serverName;
		_003CSslProtocols_003Ek__BackingField = sslProtocols;
	}
}
