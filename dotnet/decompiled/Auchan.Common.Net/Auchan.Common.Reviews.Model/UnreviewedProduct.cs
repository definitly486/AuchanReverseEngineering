using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Reviews.Model;

public class UnreviewedProduct
{
	public string Code { get; set; }

	public string GimaId { get; set; }

	public string Title { get; set; }

	public string ImageUrl { get; set; }

	public ReviewRewardSticker? ReviewRewardSticker { get; set; }

	public UnreviewedProduct(string? code, string? gimaId, string? title, string? imageUrl, ReviewRewardSticker? reviewRewardSticker)
	{
		Code = code ?? "";
		GimaId = gimaId ?? "";
		Title = title ?? "";
		ImageUrl = imageUrl ?? "";
		ReviewRewardSticker = reviewRewardSticker;
	}
}
