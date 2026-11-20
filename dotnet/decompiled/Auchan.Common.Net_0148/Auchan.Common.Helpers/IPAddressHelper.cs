using System.Net;
using System.Net.Sockets;

namespace Auchan.Common.Helpers;

public static class IPAddressHelper
{
	public static string GetLocalIPAddress()
	{
		try
		{
			IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
			foreach (IPAddress iPAddress in addressList)
			{
				if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
				{
					return iPAddress.ToString();
				}
			}
		}
		catch
		{
		}
		return string.Empty;
	}
}
