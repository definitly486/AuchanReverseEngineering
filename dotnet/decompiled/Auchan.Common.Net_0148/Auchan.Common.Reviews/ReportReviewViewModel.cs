using System;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;

namespace Auchan.Common.Reviews;

public class ReportReviewViewModel : ScreenViewModel<ReportReviewViewModel.Parameter>
{
	public class Parameter : BrokeredParameter
	{
		public int ReviewId { get; }

		public Parameter(int reviewId)
		{
			ReviewId = reviewId;
		}
	}

	public string ReportReviewText { get; } = "Пожаловаться на отзыв";

	public string CancelText { get; } = "Отменить";

	public UICommand ReportCommand { get; } = new UICommand();

	public UICommand<BrokerToken> OpenReportReasonCommand { get; } = new UICommand<BrokerToken>();

	public UICommand CancelCommand { get; } = new UICommand();

	public ReportReviewViewModel(BrokerToken parameter, IDataBroker dataBroker)
		: base(parameter)
	{
		ReportReviewViewModel reportReviewViewModel = this;
		ReportCommand.Subscribe(delegate
		{
			reportReviewViewModel.OpenReportReasonCommand.Trigger(dataBroker.Push(new ReportReviewReasonSelectViewModel.Parameter(reportReviewViewModel.Argument.ReviewId)));
		}).AddTo(base.CloseDisposable);
	}
}
