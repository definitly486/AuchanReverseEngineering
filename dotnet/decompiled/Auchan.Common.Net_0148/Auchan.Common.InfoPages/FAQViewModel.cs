using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages.Models;
using Auchan.Common.Logs;
using CSharpFunctionalExtensions;

namespace Auchan.Common.InfoPages;

public class FAQViewModel : ScreenViewModel
{
	public enum VisualState
	{
		Default,
		InProgress,
		Error
	}

	public class Parameter
	{
		public FAQType Type { get; }

		public Parameter(FAQType type)
		{
			Type = type;
		}
	}

	private readonly Parameter _parameter;

	private readonly IInfoPagesRepository _infoPagesRepository;

	private readonly ILogService _logService;

	private readonly IErrorTranslator _errorTranslator;

	private readonly Subject<Unit> _onRetry = new Subject<Unit>();

	[CompilerGenerated]
	private ObservableRangeCollection<FAQEntry> _003CFAQEntries_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorButtonText_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	public ObservableRangeCollection<FAQEntry> FAQEntries
	{
		[CompilerGenerated]
		get
		{
			return _003CFAQEntries_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CFAQEntries_003Ek__BackingField, value))
			{
				_003CFAQEntries_003Ek__BackingField = value;
				RaisePropertyChanged("FAQEntries");
			}
		}
	} = new ObservableRangeCollection<FAQEntry>();

	public string ScreenTitle => "Вопросы и ответы";

	public string ErrorTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorTitle");
			}
		}
	} = "";

	public string ErrorMessage
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorMessage_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorMessage");
			}
		}
	} = "";

	public string ErrorButtonText
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorButtonText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorButtonText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorButtonText_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorButtonText");
			}
		}
	} = "Повторить";

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
	}

	public FAQViewModel(Parameter parameter, IInfoPagesRepository infoPagesRepository, ILogService logService, DefaultErrorTranslator errorTranslator)
	{
		_parameter = parameter;
		_infoPagesRepository = infoPagesRepository;
		_logService = logService;
		_errorTranslator = errorTranslator;
		_onRetry.PerformDebouncingTask((Unit _) => LoadFAQ()).Subscribe().AddTo(base.CloseDisposable);
	}

	protected override async Task Start()
	{
		await base.Start();
		await LoadFAQ();
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		_logService.LogInfo("FAQViewModel", "Открыт экран FAQ", LogType.UserAction, SystemType.MobileApp);
	}

	public void RetryClick()
	{
		_onRetry.OnNext(Unit.Default);
	}

	private async Task LoadFAQ()
	{
		State = VisualState.InProgress;
		Result<FAQ, DomainError> result = await _infoPagesRepository.FAQ(_parameter.Type);
		if (result.IsSuccess)
		{
			FAQEntries.Clear();
			foreach (FAQEntry entry in result.Value.Entries)
			{
				FAQEntries.Add(entry);
			}
			State = VisualState.Default;
		}
		else
		{
			(string, string) tuple = _errorTranslator.Translate(result.Error);
			ErrorTitle = tuple.Item1;
			ErrorMessage = tuple.Item2;
			State = VisualState.Error;
		}
	}
}
