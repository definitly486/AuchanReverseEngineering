using System.Text;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Cart.Managers;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;

namespace Auchan.Common.InfoPages.ServiceErrors;

internal class NetworkSettings : INetworkSettings
{
	private readonly string Version;

	public NetworkSettings(IDeviceService deviceService)
	{
		Version = deviceService.BuildVersion;
	}

	public string GetVersionString()
	{
		byte[] bytes = new byte[24]
		{
			89, 106, 78, 79, 82, 86, 78, 114, 84, 109,
			86, 53, 86, 51, 108, 71, 101, 87, 53, 81,
			99, 81, 61, 61
		};
		return HashHelper.GetMD5(Encoding.UTF8.GetString(bytes).Decode() + Version);
	}
}
