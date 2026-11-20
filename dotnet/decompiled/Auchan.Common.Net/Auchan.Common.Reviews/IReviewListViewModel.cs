using System;
using System.Collections.Generic;
using System.ComponentModel;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Reviews.Model;

namespace Auchan.Common.Reviews;

public interface IReviewListViewModel : IBindable, INotifyPropertyChanged
{
	ReviewList? ReviewList { get; }

	UICommand<Review> OnMenuOptionsCommand { get; }

	UICommand<OpenThumbnailRequest> OpenThumbnailCommand { get; }

	UICommand<ReviewDetailsViewModel.Parameter> OpenReviewDetailsCommand { get; }

	sealed IReadOnlyList<Review> GetReviews()
	{
		return ReviewList?.Reviews ?? Array.Empty<Review>();
	}
}
