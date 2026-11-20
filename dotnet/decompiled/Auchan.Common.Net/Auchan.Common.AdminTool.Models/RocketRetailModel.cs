namespace Auchan.Common.AdminTool.Models;

public class RocketRetailModel
{
	public string ApiKey { get; }

	public string PartnerId { get; }

	public RocketRetailModel(string apiKey, string partnerId)
	{
		ApiKey = apiKey;
		PartnerId = partnerId;
	}
}
