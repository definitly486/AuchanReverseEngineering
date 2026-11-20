using System;
using System.Collections.Generic;
using System.Linq;
using Auchan.Common.AdminTool.DTO;

namespace Auchan.Common.AdminTool;

public static class PromotionMapper
{
	public static Promotion ToModel(this PromotionDto dto)
	{
		return new Promotion(dto.Id, dto.Name, dto.Picture, dto.ShortPicture, dto.Animation, dto.BeginsOn, dto.EndsOn, dto.СategoryСode, dto.CategoryTitle, dto.CategoryDescription, dto.CategoryLinkText, dto.CategoryLink, dto.Description, dto.Url, dto.Kind, dto.Deeplink, dto.DeeplinkId, dto.Position?.Select((PromotionPosition x) => PromotionPositionConverter.FromDTOToModel(x))?.ToList() ?? new List<Position>(), dto.GimaId);
	}

	public static ExtraPromotion ToModel(this ExtraPromotionDto dto)
	{
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
		return new ExtraPromotion
		{
			BeginsOn = (dto.BeginsOn.HasValue ? dateTime.AddSeconds(dto.BeginsOn.Value) : DateTime.MinValue),
			EndsOn = (dto.EndsOn.HasValue ? dateTime.AddSeconds(dto.EndsOn.Value) : DateTime.MaxValue),
			Id = dto.Id,
			Name = dto.Name,
			Location = dto.Location,
			LocationId = dto.LocationId,
			Picture = dto.Picture,
			RegionId = dto.RegionId,
			Transition = dto.Transition,
			TransitionCode = dto.TransitionCode
		};
	}
}
