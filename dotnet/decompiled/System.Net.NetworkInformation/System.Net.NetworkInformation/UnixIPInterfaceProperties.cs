using System.IO;

namespace System.Net.NetworkInformation;

internal abstract class UnixIPInterfaceProperties : IPInterfaceProperties
{
	private UnicastIPAddressInformationCollection _unicastAddresses;

	private readonly UnixNetworkInterface _uni;

	internal string _dnsSuffix;

	internal IPAddressCollection _dnsAddresses;

	public override UnicastIPAddressInformationCollection UnicastAddresses => _unicastAddresses ?? (_unicastAddresses = GetUnicastAddresses(_uni));

	public UnixIPInterfaceProperties(UnixNetworkInterface uni, bool globalConfig = false)
	{
		_uni = uni;
		if (!globalConfig)
		{
			_dnsSuffix = GetDnsSuffix();
			_dnsAddresses = GetDnsAddresses();
		}
		else
		{
			_dnsAddresses = new InternalIPAddressCollection();
		}
	}

	private static UnicastIPAddressInformationCollection GetUnicastAddresses(UnixNetworkInterface uni)
	{
		UnicastIPAddressInformationCollection unicastIPAddressInformationCollection = new UnicastIPAddressInformationCollection();
		foreach (UnixUnicastIPAddressInformation item in uni.UnicastAddress)
		{
			unicastIPAddressInformationCollection.InternalAdd(item);
		}
		return unicastIPAddressInformationCollection;
	}

	private static string GetDnsSuffix()
	{
		try
		{
			return StringParsingHelpers.ParseDnsSuffixFromResolvConfFile(File.ReadAllText("/etc/resolv.conf"));
		}
		catch (FileNotFoundException)
		{
			return null;
		}
	}

	private static InternalIPAddressCollection GetDnsAddresses()
	{
		try
		{
			return new InternalIPAddressCollection(StringParsingHelpers.ParseDnsAddressesFromResolvConfFile(File.ReadAllText("/etc/resolv.conf")));
		}
		catch (FileNotFoundException)
		{
			return new InternalIPAddressCollection();
		}
	}
}
