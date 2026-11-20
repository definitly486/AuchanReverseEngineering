using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Onboardings.Models;
using Auchan.Common.Extensions;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Onboardings;

public class OnboardingsViewModel : ScreenViewModel, IOnboardingActionSupport
{
	public enum VisualState
	{
		Default,
		InProgress,
		Error
	}

	public class Parameter
	{
		public ShowAt Position { get; }

		public Parameter(ShowAt position)
		{
			Position = position;
		}
	}

	private readonly Parameter _parameter;

	private readonly IOnboardingsManager _manager;

	private readonly DefaultErrorTranslator _errorTranslator;

	private readonly Lazy<AppMetrica> _appMetrica;

	[CompilerGenerated]
	private IReadOnlyList<OnboardingItemViewModel> _003COnboardings_003Ek__BackingField;

	private bool _countedShow;

	public int HeaderMaxLength = 70;

	public int DescriptionMaxLength = 140;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CCurrentOnboardingIndex_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CReloadCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CCloseCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CFinishCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CNextCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<WebViewModel.Parameter> _003CWebCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CAuthCommand_003Ek__BackingField;

	public IReadOnlyList<OnboardingItemViewModel> Onboardings
	{
		[CompilerGenerated]
		get
		{
			return _003COnboardings_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COnboardings_003Ek__BackingField, value))
			{
				_003COnboardings_003Ek__BackingField = value;
				RaisePropertyChanged("OnboardingCount");
				RaisePropertyChanged("IsIndicatorVisible");
				RaisePropertyChanged("Onboardings");
			}
		}
	} = Array.Empty<OnboardingItemViewModel>();

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
	} = string.Empty;

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
	} = string.Empty;

	public int OnboardingCount => Onboardings.Count;

	public bool IsIndicatorVisible => OnboardingCount > 1;

	public int CurrentOnboardingIndex
	{
		[CompilerGenerated]
		get
		{
			return _003CCurrentOnboardingIndex_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CCurrentOnboardingIndex_003Ek__BackingField != value)
			{
				int currentOnboardingIndex = CurrentOnboardingIndex;
				_003CCurrentOnboardingIndex_003Ek__BackingField = value;
				int currentOnboardingIndex2 = CurrentOnboardingIndex;
				OnCurrentOnboardingIndexChanged(currentOnboardingIndex, currentOnboardingIndex2);
				RaisePropertyChanged("CurrentOnboardingIndex");
			}
		}
	}

	public UICommand<OnboardingItemViewModel> DetailsCommand { get; } = new UICommand<OnboardingItemViewModel>();

	public UICommand ReloadCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CReloadCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CReloadCommand_003Ek__BackingField, value))
			{
				_003CReloadCommand_003Ek__BackingField = value;
				RaisePropertyChanged("ReloadCommand");
			}
		}
	} = new UICommand();

	public UICommand CloseCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CCloseCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CCloseCommand_003Ek__BackingField, value))
			{
				_003CCloseCommand_003Ek__BackingField = value;
				RaisePropertyChanged("CloseCommand");
			}
		}
	} = new UICommand();

	public UICommand FinishCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CFinishCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CFinishCommand_003Ek__BackingField, value))
			{
				_003CFinishCommand_003Ek__BackingField = value;
				RaisePropertyChanged("FinishCommand");
			}
		}
	} = new UICommand();

	public UICommand NextCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CNextCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CNextCommand_003Ek__BackingField, value))
			{
				_003CNextCommand_003Ek__BackingField = value;
				RaisePropertyChanged("NextCommand");
			}
		}
	} = new UICommand();

	public UICommand<WebViewModel.Parameter> WebCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CWebCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CWebCommand_003Ek__BackingField, value))
			{
				_003CWebCommand_003Ek__BackingField = value;
				RaisePropertyChanged("WebCommand");
			}
		}
	} = new UICommand<WebViewModel.Parameter>();

	public UICommand AuthCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CAuthCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CAuthCommand_003Ek__BackingField, value))
			{
				_003CAuthCommand_003Ek__BackingField = value;
				RaisePropertyChanged("AuthCommand");
			}
		}
	} = new UICommand();

	public OnboardingsViewModel(Parameter parameter, IOnboardingsManager manager, DefaultErrorTranslator errorTranslator, Lazy<AppMetrica> appMetrica)
	{
		_parameter = parameter;
		_manager = manager;
		_errorTranslator = errorTranslator;
		_appMetrica = appMetrica;
		ReloadCommand.PerformDebouncingTask(Load).Subscribe().AddTo(base.CloseDisposable);
		NextCommand.Subscribe(delegate
		{
			OnNextOnboarding();
		}).AddTo(base.CloseDisposable);
		DetailsCommand.PerformDebouncingTask(OpenDetailsAsync).Subscribe().AddTo(base.CloseDisposable);
		FinishCommand.Subscribe(delegate
		{
			if (_parameter.Position == ShowAt.BeforeAuth)
			{
				AuthCommand.Trigger();
			}
			else
			{
				CloseCommand.Trigger();
			}
		}).AddTo(base.CloseDisposable);
	}

	protected override async Task Start()
	{
		await base.Start();
		await Load();
	}

	public void CloseButtonClick()
	{
		_appMetrica.Value.SendFakeAdRevenue("onboardingSkip", ("onboardingName", Onboardings[CurrentOnboardingIndex].Model.Name), ("onboardingId", Onboardings[CurrentOnboardingIndex].Model.Id.ToString()));
	}

	private async Task Load()
	{
		State = VisualState.InProgress;
		Result<IReadOnlyList<OnboardingModel>, DomainError> result = await _manager.GetOnboardings(_parameter.Position);
		if (result.IsFailure)
		{
			State = VisualState.Error;
			(ErrorTitle, ErrorMessage) = _errorTranslator.Translate(result.Error);
			return;
		}
		if (result.Value.Count() == 0)
		{
			FinishCommand.Trigger();
			return;
		}
		Onboardings = result.Value.Select((OnboardingModel o) => new OnboardingItemViewModel(o)).ToImmutableList();
		if (!_countedShow)
		{
			_countedShow = true;
			foreach (OnboardingModel item in result.Value)
			{
				_manager.OnboardingShown(item.Id, _parameter.Position);
			}
		}
		_appMetrica.Value.SendFakeAdRevenue("onboardingView", ("onboardingName", Onboardings[CurrentOnboardingIndex].Model.Name), ("onboardingId", Onboardings[CurrentOnboardingIndex].Model.Id.ToString()));
		State = VisualState.Default;
	}

	private void OnNextOnboarding()
	{
		if (CurrentOnboardingIndex == OnboardingCount - 1)
		{
			FinishCommand.Trigger();
		}
		else
		{
			CurrentOnboardingIndex++;
		}
	}

	private async Task OpenDetailsAsync(OnboardingItemViewModel itemViewModel)
	{
		_appMetrica.Value.SendFakeAdRevenue("onboardingButton", ("onboardingName", Onboardings[CurrentOnboardingIndex].Model.Name), ("onboardingId", Onboardings[CurrentOnboardingIndex].Model.Id.ToString()), ("buttonName", itemViewModel.Model.Action.Text ?? ""));
		await itemViewModel.Model.Action.ActivateAsync(_parameter.Position, this);
	}

	private void OnCurrentOnboardingIndexChanged(int prev, int current)
	{
		_appMetrica.Value.SendFakeAdRevenue("onboardingView", ("onboardingName", Onboardings[CurrentOnboardingIndex].Model.Name), ("onboardingId", Onboardings[CurrentOnboardingIndex].Model.Id.ToString()));
	}
}
