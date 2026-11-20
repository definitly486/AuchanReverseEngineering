using System.Linq;
using Auchan.Common.InfoPages.DTO;
using Auchan.Common.InfoPages.Models;

namespace Auchan.Common.InfoPages;

public static class InfoPageMapper
{
	public static InfoPage ToModel(this InfoResponseDto dto)
	{
		return new InfoPage(dto.ContentType, dto.Position, dto.Slug, dto.Url ?? string.Empty, dto.Title ?? string.Empty, dto.Content ?? string.Empty, dto.BannerUrl ?? string.Empty, dto.IconUrl ?? string.Empty);
	}

	public static FAQ ToModel(this FAQResponseDto dto)
	{
		int counter = 0;
		return new FAQ(dto.Id, dto.Name, dto.Entries.Select(delegate(FAQEntryDto x)
		{
			FAQEntry fAQEntry = x.ToModel();
			fAQEntry.Question = fAQEntry.Question.Insert(0, $"{++counter}. ");
			return fAQEntry;
		}).ToList());
	}

	public static FAQEntry ToModel(this FAQEntryDto dto)
	{
		return new FAQEntry(dto.Id, dto.Question, dto.Answer);
	}

	public static Tutorial ToModel(this TutorialDto dto)
	{
		return new Tutorial(dto.ContentType, dto.Title, dto.Description, dto.Url, dto.BannerUrl);
	}
}
