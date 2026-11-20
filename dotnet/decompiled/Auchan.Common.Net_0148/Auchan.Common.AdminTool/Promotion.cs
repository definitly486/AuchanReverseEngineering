using System;
using System.Collections.Generic;
using Auchan.Common.Deeplinks;
using Auchan.Common.Helpers;

namespace Auchan.Common.AdminTool;

public class Promotion : IEquatable<Promotion>
{
	public int Id { get; }

	public string Name { get; }

	public string Picture { get; }

	public string? ShortPicture { get; }

	public string? Animation { get; }

	public DateTime BeginsOn { get; }

	public DateTime EndsOn { get; }

	public string? CategoryCode { get; set; }

	public string? CategoryTitle { get; set; }

	public string? CategoryDescription { get; set; }

	public string? CategoryLinkText { get; set; }

	public string? CategoryLink { get; set; }

	public string? Description { get; }

	public string? Url { get; }

	public PromotionKind PromotionKind { get; }

	public List<Position> Positions { get; }

	public DeeplinkType? Deeplink { get; }

	public string? DeeplinkId { get; }

	public string GimaId { get; }

	public Promotion(int id, string name, string picture, string? shortPicture, string? animation, long? beginsOn, long? endsOn, string? categoryСode, string? categoryTitle, string? categoryDescription, string? categoryLinkText, string? categoryLink, string? description, string? url, PromotionKind promotionKind, DeeplinkType? deeplink, string? deeplinkId, List<Position> positions, string gimaId = "")
	{
		Id = id;
		Name = name;
		Picture = picture;
		ShortPicture = shortPicture;
		Animation = animation;
		BeginsOn = TimeHelper.ConvertFromUnixTimestamp(beginsOn.GetValueOrDefault());
		EndsOn = TimeHelper.ConvertFromUnixTimestamp(endsOn.GetValueOrDefault());
		CategoryCode = categoryСode;
		CategoryTitle = categoryTitle;
		CategoryDescription = categoryDescription;
		CategoryLinkText = categoryLinkText;
		CategoryLink = categoryLink;
		Description = description;
		Url = url;
		Positions = positions;
		PromotionKind = promotionKind;
		Deeplink = deeplink;
		DeeplinkId = deeplinkId;
		GimaId = gimaId;
	}

	public bool Equals(Promotion? other)
	{
		if (other == null)
		{
			return false;
		}
		if (Id == other.Id && Name == other.Name && Picture == other.Picture && BeginsOn == other.BeginsOn && EndsOn == other.EndsOn && CategoryCode == other.CategoryCode && CategoryTitle == other.CategoryTitle && CategoryDescription == other.CategoryDescription && CategoryLinkText == other.CategoryLinkText && CategoryLink == other.CategoryLink && Description == other.Description && Url == other.Url && Positions == other.Positions && PromotionKind == other.PromotionKind && Deeplink == other.Deeplink && DeeplinkId == other.DeeplinkId)
		{
			return GimaId == other.GimaId;
		}
		return false;
	}
}
