using System.Collections.Immutable;
using System.Linq;
using Auchan.Common.AdminTool.DTO;
using Auchan.Common.AdminTool.Models;

namespace Auchan.Common.AdminTool;

public static class InitializationMapper
{
	public static Initialization ToModel(this InitializationDto dto)
	{
		Udid udid = dto.UdidDto.ToModel();
		AppConfig appConfig = dto.AppConfigDto.ToModel();
		ImmutableList<ExtraPromotion> extraPromotions = dto.ExtraPromotionDtos.Select(PromotionMapper.ToModel).ToImmutableList();
		return new Initialization(udid, appConfig, extraPromotions);
	}
}
