using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Reviews.Api.Ecom;

namespace Auchan.Common.Reviews;

public class WaitingForReviewPopupViewModel : ScreenViewModel
{
	private readonly ReviewsEcomRepository _reviewsEcomRepository;

	public UICommand AddReviewCommand = new UICommand();

	public UICommand CloseCommand = new UICommand();

	public string Title => "Оставьте отзыв о товарах";

	public string Description => "Поделитесь своим мнением о товарах \nв последнем заказе";

	public string AddReviewButtonText => "Оставить отзыв";

	public WaitingForReviewPopupViewModel(ReviewsEcomRepository reviewsEcomRepository)
	{
		_reviewsEcomRepository = reviewsEcomRepository;
	}

	protected override async Task Start()
	{
		await base.Start();
		await _reviewsEcomRepository.SetReviewPopupShown();
	}
}
