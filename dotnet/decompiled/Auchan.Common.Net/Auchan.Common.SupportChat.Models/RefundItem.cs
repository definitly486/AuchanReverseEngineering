using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.SupportChat.Models;

public sealed record RefundItem
{
	public required string? Image { get; init; }

	public required string? Title { get; init; }

	public bool IsTitleVisible => !string.IsNullOrEmpty(Title);

	public required decimal? PricePerOne { get; init; }

	public string PricePerOneText
	{
		get
		{
			if (!PricePerOne.HasValue)
			{
				return "8";
			}
			return $"{PricePerOne:C2}";
		}
	}

	public string PricePerOneChatText
	{
		get
		{
			if (!PricePerOne.HasValue)
			{
				return "";
			}
			return $" {PricePerOne:C2}";
		}
	}

	public bool IsPricePerOneVisible => PricePerOne.HasValue;

	public required decimal? Price { get; init; }

	public string PriceText
	{
		get
		{
			if (!Price.HasValue)
			{
				return "8";
			}
			return $"{Price:C2}";
		}
	}

	public bool IsPriceVisible => Price.HasValue;

	public required string? Status { get; init; }

	public bool IsStatusVisible => !string.IsNullOrEmpty(Status);

	public required bool IsEnabled { get; init; }

	public required decimal? AvailableToReturn { get; init; }

	public required string GimaId { get; init; }

	public required bool IsWeightGoods { get; init; }

	public bool IsQuantytVisible
	{
		get
		{
			if (IsEnabled)
			{
				decimal? availableToReturn = AvailableToReturn;
				decimal num = 1;
				if (!((availableToReturn.GetValueOrDefault() == num) & availableToReturn.HasValue))
				{
					availableToReturn = AvailableToReturn;
					return (availableToReturn.GetValueOrDefault() > default(decimal)) & availableToReturn.HasValue;
				}
			}
			return false;
		}
	}

	[CompilerGenerated]
	[SetsRequiredMembers]
	private RefundItem(RefundItem original)
	{
		Image = original.Image;
		Title = original.Title;
		PricePerOne = original.PricePerOne;
		Price = original.Price;
		Status = original.Status;
		IsEnabled = original.IsEnabled;
		AvailableToReturn = original.AvailableToReturn;
		GimaId = original.GimaId;
		IsWeightGoods = original.IsWeightGoods;
	}

	public RefundItem()
	{
	}
}
