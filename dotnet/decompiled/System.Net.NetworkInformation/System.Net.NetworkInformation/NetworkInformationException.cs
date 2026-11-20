using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.Net.NetworkInformation;

[Serializable]
[TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class NetworkInformationException : Win32Exception
{
	public override int ErrorCode => base.NativeErrorCode;

	internal NetworkInformationException(string message)
		: base(message)
	{
	}
}
