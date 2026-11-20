using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

public class InfoPageIntermediateViewModel : ScreenViewModel
{
	public enum VisualState
	{
		Default,
		InProgress,
		Error
	}

	public class Parameter
	{
		public List<string> InfoTypeSlugs { get; set; }

		public string Title { get; set; }

		public Parameter()
		{
			InfoTypeSlugs = new List<string>();
			Title = "";
		}

		public Parameter(List<string> infoTypeSlugs, string title)
		{
			InfoTypeSlugs = infoTypeSlugs;
			Title = title;
		}

		public Parameter(List<InfoType> infoTypes, string title)
		{
			InfoTypeSlugs = infoTypes.Select((InfoType x) => InfoPagesConverter.InfoTypeToSlug(x)).ToList();
			Title = title;
		}
	}

	private readonly IInfoPagesRepository _infoPagesRepository;

	private readonly IErrorTranslator _errorTranslator;

	private Parameter _parameter;

	private readonly Subject<string> _navigateNext = new Subject<string>();

	private readonly Subject<Unit> _onRetry = new Subject<Unit>();

	[CompilerGenerated]
	private string _003CScreenTitle_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorButtonText_003Ek__BackingField;

	public string ScreenTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CScreenTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CScreenTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CScreenTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ScreenTitle");
			}
		}
	}

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

	public IObservable<InfoPageViewModel.Parameter> NavigateNextCommand => from slug in _navigateNext.Debounce()
		select new InfoPageViewModel.Parameter(slug);

	public ObservableRangeCollection<InfoPageIntermediateModel> InfoTypeModels { get; } = new ObservableRangeCollection<InfoPageIntermediateModel>();

	public InfoPageIntermediateViewModel(DefaultErrorTranslator defaultErrorTranslator, IInfoPagesRepository infoPagesRepository, Parameter parameter)
	{
		_errorTranslator = defaultErrorTranslator;
		_infoPagesRepository = infoPagesRepository;
		_parameter = parameter;
		ScreenTitle = ((string.IsNullOrEmpty(parameter.Title) || string.IsNullOrWhiteSpace(parameter.Title)) ? "Информация" : parameter.Title);
		_onRetry.PerformDebouncingTask((Unit _) => LoadInfoPages()).Subscribe().AddTo(base.CloseDisposable);
	}

	protected override async Task Start()
	{
		await base.Start();
		await LoadInfoPages();
	}

	public void RetryClick()
	{
		_onRetry.OnNext(Unit.Default);
	}

	public void NavigateNextClick(string slug)
	{
		_navigateNext.OnNext(slug);
	}

	private async Task LoadInfoPages()
	{
		State = VisualState.InProgress;
		Result<List<InfoPage>, DomainError> result = await _infoPagesRepository.InfoPages();
		if (result.IsSuccess)
		{
			InfoTypeModels.ReplaceRange(from x in result.Value
				where _parameter.InfoTypeSlugs.Contains(x.Slug)
				select new InfoPageIntermediateModel(x));
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
