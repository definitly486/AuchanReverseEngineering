using System;
using System.Collections.Generic;
using System.Linq;
using Auchan.Common.Reviews.Api.Ecom.Dto.Enums;

namespace Auchan.Common.Reviews.Model;

public sealed class Review
{
	public required int Id { get; init; }

	public required string? ExternalId { get; init; }

	public required DateTime CreatedAt { get; init; }

	public required string? UserName { get; init; }

	public required int Rate { get; init; }

	public required string Text { get; init; }

	public bool IsTextVisible => !string.IsNullOrEmpty(Text);

	public required IReadOnlyList<ReviewImage> Images { get; init; }

	public required IReadOnlyList<ReviewComment> Comments { get; init; }

	public required ReviewStatus Status { get; init; }

	public bool RulesVisible => Status == ReviewStatus.Rejected;

	public string StatusName => GetStatusName();

	public required string? ProductTitle { get; init; }

	public required string? ProductImage { get; init; }

	public required string TitleOfTriggerWords { get; init; }

	public bool IsTitleOfTriggerWordsVisible => !string.IsNullOrEmpty(TitleOfTriggerWords);

	public required IReadOnlyList<TriggerWord> TriggerWords { get; init; }

	public bool IsTriggerWordsVisible => TriggerWords.Any();

	public bool IsTriggerWordsContainerVisible
	{
		get
		{
			if (IsTitleOfTriggerWordsVisible)
			{
				return IsTriggerWordsVisible;
			}
			return false;
		}
	}

	private string GetStatusName()
	{
		return Status switch
		{
			ReviewStatus.Published => "Опубликован", 
			ReviewStatus.Rejected => "Не опубликован", 
			_ => "Ожидает модерации", 
		};
	}
}
