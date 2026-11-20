using System.Collections.Generic;
using System.IO;

namespace System.Net.NetworkInformation;

internal static class StringParsingHelpers
{
	internal static string ParseDnsSuffixFromResolvConfFile(string data)
	{
		if (!new RowConfigReader(data).TryGetNextValue("search", out var value))
		{
			return string.Empty;
		}
		return value;
	}

	internal static List<IPAddress> ParseDnsAddressesFromResolvConfFile(string data)
	{
		RowConfigReader rowConfigReader = new RowConfigReader(data);
		List<IPAddress> list = new List<IPAddress>();
		string value;
		while (rowConfigReader.TryGetNextValue("nameserver", out value))
		{
			if (IPAddress.TryParse(value, out IPAddress address))
			{
				list.Add(address);
			}
		}
		return list;
	}
}
