namespace System.Net.NetworkInformation;

public abstract class IPInterfaceProperties
{
	public abstract UnicastIPAddressInformationCollection UnicastAddresses { get; }
}
