using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;

namespace Auchan.Common.Reviews;

public class ReportReviewReasonSelectViewModel : ScreenViewModel<ReportReviewReasonSelectViewModel.Parameter>
{
	public class Parameter : BrokeredParameter
	{
		public int ReviewId { get; }

		public Parameter(int reviewId)
		{
			ReviewId = reviewId;
		}
	}

	private readonly ReviewReportService _reviewReportService;

	[CompilerGenerated]
	private bool _003CReportAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CSelectedReason_003Ek__BackingField;

	public string TitleText { get; } = "Пожалуйста, укажите причину";

	public string ReportText { get; } = "Пожаловаться";

	public bool ReportAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CReportAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CReportAvailable_003Ek__BackingField != value)
			{
				_003CReportAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("ReportAvailable");
			}
		}
	}

	public string? SelectedReason
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedReason_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CSelectedReason_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSelectedReason_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedReason");
			}
		}
	}

	public ObservableRangeCollection<string> Reasons { get; } = new ObservableRangeCollection<string> { "Не соответствует действительности", "Некорректное фото, видео", "Нецензурная лексика", "Другая причина" };

	public UICommand ReportCommand { get; } = new UICommand();

	public UICommand<string> SelectReasonCommand { get; } = new UICommand<string>();

	public UICommand CloseCommand { get; } = new UICommand();

	public ReportReviewReasonSelectViewModel(BrokerToken parameter, ReviewReportService reviewReportService)
		: base(parameter)
	{
		_reviewReportService = reviewReportService;
		ReportCommand.PerformDebouncingTask(Report).Subscribe().AddTo(base.CloseDisposable);
		SelectReasonCommand.Subscribe(delegate(string r)
		{
			SelectedReason = r;
			ReportAvailable = !string.IsNullOrWhiteSpace(SelectedReason);
		}).AddTo(base.CloseDisposable);
	}

	private async Task Report()
	{
		if (ReportAvailable)
		{
			CloseCommand.Trigger();
			await _reviewReportService.Report(base.Argument.ReviewId, SelectedReason);
		}
	}
}
