namespace System.Net.NetworkInformation;

internal sealed class UnixUnicastIPAddressInformation : UnicastIPAddressInformation
{
	private readonly IPAddress _address;

	private readonly int _prefixLength;

	public override IPAddress Address => _address;

	public UnixUnicastIPAddressInformation(IPAddress address, int prefixLength)
	{
		_address = address;
		_prefixLength = prefixLength;
	}
}
