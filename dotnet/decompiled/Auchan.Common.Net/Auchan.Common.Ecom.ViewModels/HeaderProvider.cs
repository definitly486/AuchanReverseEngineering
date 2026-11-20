using System.Collections.Generic;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Cart.Managers;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.LoyaltyProgram.Mappers;

namespace Auchan.Common.Ecom.ViewModels;

internal class HeaderProvider : IHeaderProvider
{
	private static readonly string HashKey = "YXV0aF9oYXNo".Decode();

	private static readonly string TimestampKey = "dGltZXN0YW1w".Decode();

	private static readonly string VersionKey = "YnVpbGRfdmVyc2lvbg==".Decode();

	private readonly string BuildVersion;

	private readonly string Salt;

	public HeaderProvider(INetworkSettings settings, IDeviceService deviceService)
	{
		BuildVersion = deviceService.BuildVersion;
		Salt = settings.GetVersionString();
	}

	public IDictionary<string, string> GetHeaders(string url)
	{
		string text = TimeHelper.CurrentUnixTimeStamp.ToString();
		string hash = GetHash(url, text);
		return new Dictionary<string, string>
		{
			{ HashKey, hash },
			{ TimestampKey, text },
			{ VersionKey, BuildVersion }
		};
	}

	public bool IsValidHeaders(IDictionary<string, string>? headers)
	{
		if (headers != null && headers.Count > 0)
		{
			if (headers.ContainsKey(HashKey) && headers.ContainsKey(TimestampKey))
			{
				return headers.ContainsKey(VersionKey);
			}
			return false;
		}
		return false;
	}

	private string GetHash(string url, string timestamp)
	{
		return HashHelper.GetMD5(Salt + url + timestamp);
	}
}
