namespace System.Net;

internal static class InteropIPAddressExtensions
{
	public unsafe static IPAddress GetIPAddress(this global::Interop.Sys.IPAddress nativeIPAddress)
	{
		if (!nativeIPAddress.IsIPv6)
		{
			return new IPAddress((uint)(*(int*)nativeIPAddress.Address));
		}
		return new IPAddress(new ReadOnlySpan<byte>(nativeIPAddress.Address, 16), nativeIPAddress.ScopeId);
	}
}
