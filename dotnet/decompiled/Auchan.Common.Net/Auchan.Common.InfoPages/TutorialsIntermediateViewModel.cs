using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.InfoPages;

public class TutorialsIntermediateViewModel : ScreenViewModel
{
	public enum VisualState
	{
		Default,
		Error,
		InProgress
	}

	private readonly IInfoPagesRepository _infoPagesRepository;

	private readonly IErrorTranslator _errorTranslator;

	private readonly Subject<Tutorial> _navigateNext = new Subject<Tutorial>();

	private readonly Subject<Unit> _onRetry = new Subject<Unit>();

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorButtonText_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<Tutorial> _003CTutorialModels_003Ek__BackingField;

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

	public string ScreenTitle => "Обучающие инструкции";

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

	public IObservable<TutorialViewModel.Parameter> NavigateNextCommand => from x in _navigateNext.Debounce()
		select new TutorialViewModel.Parameter(x);

	public ObservableRangeCollection<Tutorial> TutorialModels
	{
		[CompilerGenerated]
		get
		{
			return _003CTutorialModels_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CTutorialModels_003Ek__BackingField, value))
			{
				_003CTutorialModels_003Ek__BackingField = value;
				RaisePropertyChanged("TutorialModels");
			}
		}
	} = new ObservableRangeCollection<Tutorial>();

	public TutorialsIntermediateViewModel(IInfoPagesRepository infoPagesRepository, DefaultErrorTranslator errorTranslator)
	{
		_infoPagesRepository = infoPagesRepository;
		_errorTranslator = errorTranslator;
		_onRetry.PerformDebouncingTask((Unit _) => LoadTutorials()).Subscribe().AddTo(base.CloseDisposable);
	}

	public void NavigateNextClick(Tutorial tutorial)
	{
		_navigateNext.OnNext(tutorial);
	}

	public void OnRetryClick()
	{
		_onRetry.OnNext(Unit.Default);
	}

	protected override async Task Start()
	{
		await base.Start();
		await LoadTutorials();
	}

	private async Task LoadTutorials()
	{
		State = VisualState.InProgress;
		Result<List<Tutorial>, DomainError> result = await _infoPagesRepository.Tutorials();
		if (result.IsFailure)
		{
			State = VisualState.Error;
			(ErrorTitle, ErrorMessage) = _errorTranslator.Translate(result.Error);
		}
		else
		{
			TutorialModels.ReplaceRange(result.Value);
			State = VisualState.Default;
		}
	}
}
