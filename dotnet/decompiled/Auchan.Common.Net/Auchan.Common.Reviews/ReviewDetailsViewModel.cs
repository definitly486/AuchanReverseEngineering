using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.Reviews.Model;

namespace Auchan.Common.Reviews;

public class ReviewDetailsViewModel : ScreenViewModel
{
	public class Parameter
	{
		public Review Review { get; set; }

		public Parameter(Review review)
		{
			Review = review;
		}
	}

	[CompilerGenerated]
	private Review _003CReview_003Ek__BackingField;

	public Review Review
	{
		[CompilerGenerated]
		get
		{
			return _003CReview_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CReview_003Ek__BackingField, value))
			{
				_003CReview_003Ek__BackingField = value;
				RaisePropertyChanged("Comments");
				RaisePropertyChanged("Review");
			}
		}
	}

	public string Title => "Отзыв о товаре";

	public string CommentTitle => "Ответ";

	public IReadOnlyList<ReviewComment> Comments => Review.Comments;

	public UICommand<Review> OnMenuOptionsCommand { get; } = new UICommand<Review>();

	public UICommand<BrokerToken> OpenMenuOptionsCommand { get; } = new UICommand<BrokerToken>();

	public ReviewDetailsViewModel(Parameter parameter, IDataBroker dataBroker)
	{
		ReviewDetailsViewModel reviewDetailsViewModel = this;
		Review = parameter.Review;
		OnMenuOptionsCommand.Subscribe(delegate
		{
			reviewDetailsViewModel.OpenMenuOptionsCommand.Trigger(dataBroker.Push(new ReportReviewViewModel.Parameter(parameter.Review.Id)));
		}).AddTo(base.CloseDisposable);
	}
}
