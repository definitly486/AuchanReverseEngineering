using Auchan.Common.AdminTool.DTO;

namespace Auchan.Common.AdminTool.Models;

public class YandexMapsModel
{
	public string ApiKey { get; }

	public YandexMapsModel(YandexMapsDto yandexMapsDto)
	{
		ApiKey = yandexMapsDto.ApiKey;
	}
}
