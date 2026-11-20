using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.ComponentModel.Design;

[Serializable]
[TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class CheckoutException : ExternalException
{
	public static readonly CheckoutException Canceled = new CheckoutException("CHECKOUTCanceled", -2147467260);

	public CheckoutException(string? message, int errorCode)
		: base(message, errorCode)
	{
	}
}
