using System;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Profile.Cases.Api;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.Cases;

public sealed class CaseDetailsViewModel : ScreenViewModel
{
	public sealed class Parameter
	{
		public string Id { get; }

		public string Number { get; }

		public Parameter(string id, string number)
		{
			Id = id;
			Number = number;
		}
	}

	public enum VisualState
	{
		Default,
		InProgress,
		Error,
		Empty
	}

	private readonly Parameter _parameter;

	private readonly CasesService _casesService;

	private readonly TaskQueue _loadQueue = new TaskQueue();

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CEmptyTitleText_003Ek__BackingField;

	[CompilerGenerated]
	private CaseStatus _003CStatus_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CStatusText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CTopicsText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCreatedOnText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CDescriptionText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CAnswerDateText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CAnswerText_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CRating_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CRatingStarsText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CClosedText_003Ek__BackingField;

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.InProgress;

	public string Title
	{
		[CompilerGenerated]
		get
		{
			return _003CTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTitle_003Ek__BackingField = value;
				RaisePropertyChanged("Title");
			}
		}
	}

	public string EmptyTitleText
	{
		[CompilerGenerated]
		get
		{
			return _003CEmptyTitleText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CEmptyTitleText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CEmptyTitleText_003Ek__BackingField = value;
				RaisePropertyChanged("EmptyTitleText");
			}
		}
	} = "Здесь будут ваши обращения";

	public string ErrorTitleText => "Что-то пошло не так...";

	public string ErrorMessageText => "Повторите попытку позже";

	public string ErrorButtonText => "Повторить";

	public string ProgressTitle => "Загружаем обращение…";

	public string TopicTitleText => "Тема:";

	public string DescriptionTitleText => "Описание:";

	public string AnswerTitleText => "Ответ специалиста АШАН:";

	public string RatingTitleText => "Ваша оценка:";

	public CaseStatus Status
	{
		[CompilerGenerated]
		get
		{
			return _003CStatus_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CStatus_003Ek__BackingField != value)
			{
				_003CStatus_003Ek__BackingField = value;
				RaisePropertyChanged("Status");
			}
		}
	}

	public string StatusText
	{
		[CompilerGenerated]
		get
		{
			return _003CStatusText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CStatusText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CStatusText_003Ek__BackingField = value;
				RaisePropertyChanged("HasStatus");
				RaisePropertyChanged("StatusText");
			}
		}
	} = string.Empty;

	public bool HasStatus => !string.IsNullOrWhiteSpace(StatusText);

	public string TopicsText
	{
		[CompilerGenerated]
		get
		{
			return _003CTopicsText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CTopicsText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTopicsText_003Ek__BackingField = value;
				RaisePropertyChanged("HasTopics");
				RaisePropertyChanged("TopicsText");
			}
		}
	} = string.Empty;

	public string CreatedOnText
	{
		[CompilerGenerated]
		get
		{
			return _003CCreatedOnText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCreatedOnText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCreatedOnText_003Ek__BackingField = value;
				RaisePropertyChanged("HasCreatedOn");
				RaisePropertyChanged("CreatedOnText");
			}
		}
	} = string.Empty;

	public bool HasTopics => !string.IsNullOrWhiteSpace(TopicsText);

	public bool HasCreatedOn => !string.IsNullOrWhiteSpace(CreatedOnText);

	public string DescriptionText
	{
		[CompilerGenerated]
		get
		{
			return _003CDescriptionText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CDescriptionText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CDescriptionText_003Ek__BackingField = value;
				RaisePropertyChanged("HasDescription");
				RaisePropertyChanged("DescriptionText");
			}
		}
	} = string.Empty;

	public bool HasDescription => !string.IsNullOrWhiteSpace(DescriptionText);

	public string AnswerDateText
	{
		[CompilerGenerated]
		get
		{
			return _003CAnswerDateText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CAnswerDateText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAnswerDateText_003Ek__BackingField = value;
				RaisePropertyChanged("HasAnswer");
				RaisePropertyChanged("AnswerDateText");
			}
		}
	} = string.Empty;

	public string AnswerText
	{
		[CompilerGenerated]
		get
		{
			return _003CAnswerText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CAnswerText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAnswerText_003Ek__BackingField = value;
				RaisePropertyChanged("HasAnswer");
				RaisePropertyChanged("AnswerText");
			}
		}
	} = string.Empty;

	public bool HasAnswer
	{
		get
		{
			if (string.IsNullOrWhiteSpace(AnswerDateText))
			{
				return !string.IsNullOrWhiteSpace(AnswerText);
			}
			return true;
		}
	}

	public int Rating
	{
		[CompilerGenerated]
		get
		{
			return _003CRating_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CRating_003Ek__BackingField != value)
			{
				_003CRating_003Ek__BackingField = value;
				RaisePropertyChanged("HasRating");
				RaisePropertyChanged("Rating");
			}
		}
	}

	public string RatingStarsText
	{
		[CompilerGenerated]
		get
		{
			return _003CRatingStarsText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CRatingStarsText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CRatingStarsText_003Ek__BackingField = value;
				RaisePropertyChanged("RatingStarsText");
			}
		}
	} = "★★★★★";

	public bool HasRating => Rating > 0;

	public string ClosedText
	{
		[CompilerGenerated]
		get
		{
			return _003CClosedText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CClosedText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CClosedText_003Ek__BackingField = value;
				RaisePropertyChanged("HasClosedText");
				RaisePropertyChanged("ClosedText");
			}
		}
	} = string.Empty;

	public bool HasClosedText => !string.IsNullOrWhiteSpace(ClosedText);

	public UICommand InfoCommand { get; } = new UICommand();

	public CaseDetailsViewModel(Parameter parameter, CasesService casesService)
	{
		_parameter = parameter;
		_casesService = casesService;
		Title = BuildTitle(parameter.Number);
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		LoadQueued();
	}

	public void Retry()
	{
		LoadQueued();
	}

	private void LoadQueued()
	{
		_loadQueue.Enqueue(LoadInternal).SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task LoadInternal()
	{
		State = VisualState.InProgress;
		EmptyTitleText = "Здесь будут ваши обращения";
		Result<CasesDtos.CaseDetailsResponseDto, DomainError> result = await _casesService.GetCaseById(_parameter.Id, _parameter.Number);
		if (result.IsFailure)
		{
			ApplyError(result.Error);
			return;
		}
		CasesDtos.CaseDetailsDataDto data = result.Value.Data;
		CasesDtos.CaseDetailsDto caseDetailsDto = data?.Case;
		if (caseDetailsDto == null)
		{
			State = VisualState.Empty;
			return;
		}
		string number = (string.IsNullOrWhiteSpace(caseDetailsDto.Number) ? _parameter.Number : caseDetailsDto.Number);
		Title = BuildTitle(number);
		string rawStatus = caseDetailsDto.Status ?? string.Empty;
		string solutionDateText = FormatDate(caseDetailsDto.SolutionDate, "dd.MM");
		Status = CaseStatusExtensions.Parse(rawStatus);
		StatusText = CaseStatusExtensions.GetDisplayText(Status, rawStatus, solutionDateText);
		TopicsText = BuildTopics(caseDetailsDto.CategoryFeedbackForm, caseDetailsDto.TopicFeedbackForm);
		CreatedOnText = FormatDate(caseDetailsDto.CreatedOn, "dd.MM.yyyy") ?? string.Empty;
		DescriptionText = caseDetailsDto.Description?.Trim() ?? string.Empty;
		CasesDtos.CaseAnswerDto caseAnswerDto = data?.Answers?.FirstOrDefault((CasesDtos.CaseAnswerDto x) => !string.IsNullOrWhiteSpace(x.Text) || !string.IsNullOrWhiteSpace(x.Date));
		AnswerDateText = FormatDate(caseAnswerDto?.Date, "dd.MM.yyyy") ?? string.Empty;
		AnswerText = caseAnswerDto?.Text?.Trim() ?? string.Empty;
		Rating = Math.Clamp(caseDetailsDto.Rating.GetValueOrDefault(), 0, 5);
		ClosedText = BuildClosedText(caseDetailsDto.CloseDate);
		State = VisualState.Default;
	}

	private void ApplyError(DomainError error)
	{
		if (error is CaseDetailsAccessDeniedError)
		{
			EmptyTitleText = "Извините, просмотр обращения недоступен";
			State = VisualState.Empty;
		}
		else if (error is NoDataError)
		{
			EmptyTitleText = "Здесь будут ваши обращения";
			State = VisualState.Empty;
		}
		else
		{
			State = VisualState.Error;
		}
	}

	private static string BuildTopics(string? category, string? topic)
	{
		if (string.IsNullOrWhiteSpace(category) && string.IsNullOrWhiteSpace(topic))
		{
			return string.Empty;
		}
		if (string.IsNullOrWhiteSpace(category))
		{
			return topic.Trim();
		}
		if (string.IsNullOrWhiteSpace(topic))
		{
			return category.Trim();
		}
		return category.Trim() + " • " + topic.Trim();
	}

	private static string BuildClosedText(string? closeDateRaw)
	{
		DateTimeOffset? dateTimeOffset = TryParseDate(closeDateRaw);
		if (!dateTimeOffset.HasValue)
		{
			return string.Empty;
		}
		DateTimeOffset value = dateTimeOffset.Value.ToLocalTime();
		_ = DateTimeOffset.Now.Date;
		return $"Закрыто {value:dd.MM.yyyy} в {value:HH:mm}";
	}

	private static string BuildTitle(string? number)
	{
		if (!string.IsNullOrWhiteSpace(number))
		{
			return "Обращение №" + number;
		}
		return "Обращение";
	}

	private static string? FormatDate(string? raw, string format)
	{
		DateTimeOffset? dateTimeOffset = TryParseDate(raw);
		if (!dateTimeOffset.HasValue)
		{
			return null;
		}
		return dateTimeOffset.Value.ToString(format, CultureInfo.InvariantCulture);
	}

	private static DateTimeOffset? TryParseDate(string? raw)
	{
		if (string.IsNullOrWhiteSpace(raw))
		{
			return null;
		}
		if (DateTimeOffset.TryParse(raw, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out var result))
		{
			return result;
		}
		string text = NormalizeDate(raw);
		if (!string.Equals(text, raw, StringComparison.Ordinal) && DateTimeOffset.TryParse(text, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out result))
		{
			return result;
		}
		return null;
	}

	private static string NormalizeDate(string raw)
	{
		string text = raw.Trim();
		string text2 = string.Empty;
		if (text.EndsWith("Z", StringComparison.OrdinalIgnoreCase))
		{
			text2 = "Z";
			text = text.Substring(0, text.Length - 1);
		}
		int num = text.LastIndexOf(':');
		if (num < 0)
		{
			return raw;
		}
		string text3 = text.Substring(num + 1);
		if (text3.Length <= 2 || text3.Any((char c) => !char.IsDigit(c)))
		{
			return raw;
		}
		string text4 = text3.Substring(0, 2);
		string text5 = text3.Substring(2);
		return text.Substring(0, num + 1) + text4 + "." + text5 + text2;
	}
}
