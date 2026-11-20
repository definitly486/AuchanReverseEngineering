using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Controls.ListPicker;
using Auchan.Common.DynamicFeedback.Dto;
using Auchan.Common.DynamicFeedback.Responses;
using Auchan.Common.DynamicFeedback.Services;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages;
using Auchan.Common.Logs;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Media;
using Microsoft.Maui.Storage;

namespace Auchan.Common.DynamicFeedback;

public class DynamicFeedbackViewModel : ScreenViewModel
{
	public enum VisualState
	{
		Default,
		InProgress,
		Error,
		Success
	}

	public class Parameter
	{
		public FeedbackState CurrentState { get; set; }

		public ForCase? ForCase { get; set; }

		public string? PreselectedCategory { get; set; }

		public string? PreselectedTopic { get; set; }

		public Parameter(FeedbackState state, ForCase? forCase = null, string? preselectedCategory = null, string? preselectedTopic = null)
		{
			CurrentState = state;
			ForCase = forCase;
			PreselectedCategory = preselectedCategory;
			PreselectedTopic = preselectedTopic;
		}
	}

	private const string ErrorLogsMessage = "Не удалось отправить логи, повторите попытку";

	private readonly Parameter _parameter;

	private string _serviceSrmIdForNotAuthFeedback = string.Empty;

	private const string ShopsEnglishName = "siteCRMId";

	private const string CitiesEnglishName = "LkpTown";

	private const string ChannelsEnglishName = "PreferredCommunicationMethod";

	private readonly Subject<Unit> _onSend = new Subject<Unit>();

	private readonly DynamicFeedbackService _dynamicFeedbackService;

	private readonly IEnvironmentManager _environmentManager;

	private readonly ILogService _logService;

	private readonly IUserContext _userContext;

	private readonly IInfoMessageService _infoMessageService;

	private readonly List<City> _cities = new List<City>();

	private readonly List<Shop> _shops = new List<Shop>();

	[CompilerGenerated]
	private List<FeedbackTopicDto>? _003CTopics_003Ek__BackingField;

	private List<FeedbackCategoryDto>? _categories;

	private List<PreferredCommunicationMethod>? _communicationMethods = new List<PreferredCommunicationMethod>();

	private readonly Subject<(FieldItemViewModel, ListPickerViewModel.Parameter)> _openListPicker = new Subject<(FieldItemViewModel, ListPickerViewModel.Parameter)>();

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	public string ErrorMessage = "Извините, сейчас сервис временно недоступен. Мы уже работаем над исправлением. Позвоните нам по номеру 8 800 700-58-00";

	[CompilerGenerated]
	private bool _003CIsUserAgreed_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CWasFocusedOnFirstFieldWithError_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CGreetingsString_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CSuccessFeedbackDescription_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CSuccessFeedbackNumber_003Ek__BackingField;

	[CompilerGenerated]
	private FeedbackCategoryDto? _003CSelectedCategory_003Ek__BackingField;

	[CompilerGenerated]
	private FeedbackTopicDto? _003CSelectedTopic_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CSelectedCityName_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<FieldItemViewModel> _003CFieldViewModels_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<FileResult> _003CFileResults_003Ek__BackingField;

	private readonly Subject<InfoPageViewModel.Parameter> _onShowInfoPage = new Subject<InfoPageViewModel.Parameter>();

	public string DatePlaceholder = "ДД.ММ.ГГ";

	public string DateTimePlaceholder = "ДД.ММ.ГГ, ЧЧ:ММ";

	public UICommand<ILogService.SendFrom?> SendLogsCommand { get; } = new UICommand<ILogService.SendFrom?>();

	private List<FeedbackTopicDto>? Topics
	{
		[CompilerGenerated]
		get
		{
			return _003CTopics_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CTopics_003Ek__BackingField, value))
			{
				_003CTopics_003Ek__BackingField = value;
				RaisePropertyChanged("Topics");
			}
		}
	}

	public string InfoViewTitle => "Данные о товаре";

	public string InfoViewMessage => "Мы ответственно подходим к качеству товара. Пожалуйста, укажите информацию ниже при описании обращения, если у Вас есть замечания по\u00a0качеству наших продуктов.\nНе знаете, где найти эту информацию? Переходите сюда, мы все расскажем!";

	public string InfoViewGreenMessage => "сюда";

	public string Title => "Обратная связь";

	public string ProgressTitle => "Загружаем форму обратной связи…";

	public string ErrorText => "Извините, сейчас сервис временно недоступен. Мы уже работаем над исправлением. Позвоните нам по номеру 8 800 700-58-00";

	public string SendBtnText => "Отправить обращение";

	public string WarningViewMessage => "Убедитесь, что ваша контактная информация верна.";

	public string ExcellentText => "Отлично!";

	public string ContinueText => _parameter.ForCase switch
	{
		ForCase.PriceChecker => "Вернуться в сканер", 
		ForCase.Chatbot => "Вернуться в чат", 
		_ => "Продолжить покупки", 
	};

	public string GoToProfileText => "Перейти в профиль";

	public bool IsAuthorized => _userContext.Authorized;

	public IObservable<(FieldItemViewModel fieldItemViewModel, ListPickerViewModel.Parameter parameter)> OpenListPickerCommand => _openListPicker.Debounce();

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

	public UICommand GoToProfileCommand { get; } = new UICommand();

	public UICommand ContinueShoppingCommand { get; } = new UICommand();

	public UICommand GoBackToPriceCheckerCommand { get; } = new UICommand();

	public UICommand GoBackToChatCommand { get; } = new UICommand();

	public UICommand ContinueSuccessCommand { get; } = new UICommand();

	public UICommand OpenAuthCommand { get; } = new UICommand();

	public bool NeedShowHeaderWithBackButton
	{
		get
		{
			if (_parameter.CurrentState != FeedbackState.WithoutTopicAndCategory || _parameter.ForCase == ForCase.SocialStatus)
			{
				return _parameter.ForCase == ForCase.PriceChecker;
			}
			return true;
		}
	}

	public bool WithTopicAndCategory => _parameter.CurrentState == FeedbackState.WithTopicAndCategory;

	public bool ForCasePriceChecker => _parameter.ForCase == ForCase.PriceChecker;

	public bool ForCaseChatbot => _parameter.ForCase == ForCase.Chatbot;

	public bool ProfileButtonVisibility
	{
		get
		{
			if (!ForCaseChatbot)
			{
				return !ForCasePriceChecker;
			}
			return false;
		}
	}

	public bool IsUserAgreed
	{
		[CompilerGenerated]
		get
		{
			return _003CIsUserAgreed_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsUserAgreed_003Ek__BackingField != value)
			{
				_003CIsUserAgreed_003Ek__BackingField = value;
				RaisePropertyChanged("IsUserAgreed");
			}
		}
	}

	public bool WasFocusedOnFirstFieldWithError
	{
		[CompilerGenerated]
		get
		{
			return _003CWasFocusedOnFirstFieldWithError_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CWasFocusedOnFirstFieldWithError_003Ek__BackingField != value)
			{
				_003CWasFocusedOnFirstFieldWithError_003Ek__BackingField = value;
				RaisePropertyChanged("WasFocusedOnFirstFieldWithError");
			}
		}
	}

	public bool HasFileResults => FileResults.Count > 0;

	public string GreetingsString
	{
		[CompilerGenerated]
		get
		{
			return _003CGreetingsString_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CGreetingsString_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CGreetingsString_003Ek__BackingField = value;
				RaisePropertyChanged("GreetingsString");
			}
		}
	} = string.Empty;

	public string SuccessFeedbackTitle => "Мы получили ваше обращение " + SuccessFeedbackNumber;

	public string SuccessFeedbackDescription
	{
		[CompilerGenerated]
		get
		{
			return _003CSuccessFeedbackDescription_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CSuccessFeedbackDescription_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSuccessFeedbackDescription_003Ek__BackingField = value;
				RaisePropertyChanged("SuccessFeedbackDescription");
			}
		}
	} = "";

	private string? SuccessFeedbackNumber
	{
		[CompilerGenerated]
		get
		{
			return _003CSuccessFeedbackNumber_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CSuccessFeedbackNumber_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSuccessFeedbackNumber_003Ek__BackingField = value;
				RaisePropertyChanged("SuccessFeedbackTitle");
				RaisePropertyChanged("SuccessFeedbackNumber");
			}
		}
	}

	public FieldItemViewModel CategoryItemViewModel { get; } = new FieldItemViewModel(FieldType.ListSelection, new FeedbackFieldDto
	{
		Name = "Категория обращения*",
		NameFos = "Категория обращения*"
	});

	public FieldItemViewModel TopicItemViewModel { get; } = new FieldItemViewModel(FieldType.ListSelection, new FeedbackFieldDto
	{
		Name = "Тема обращения*",
		NameFos = "Тема обращения*"
	});

	public FeedbackCategoryDto? SelectedCategory
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedCategory_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CSelectedCategory_003Ek__BackingField, value))
			{
				_003CSelectedCategory_003Ek__BackingField = value;
				RaisePropertyChanged("CategorySelected");
				RaisePropertyChanged("SelectedCategory");
			}
		}
	}

	public bool CategorySelected => SelectedCategory != null;

	public FeedbackTopicDto? SelectedTopic
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedTopic_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CSelectedTopic_003Ek__BackingField, value))
			{
				_003CSelectedTopic_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedTopic");
			}
		}
	}

	public string? SelectedCityName
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedCityName_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CSelectedCityName_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSelectedCityName_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedCityName");
			}
		}
	}

	public ObservableRangeCollection<FieldItemViewModel> FieldViewModels
	{
		[CompilerGenerated]
		get
		{
			return _003CFieldViewModels_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CFieldViewModels_003Ek__BackingField, value))
			{
				_003CFieldViewModels_003Ek__BackingField = value;
				RaisePropertyChanged("FieldViewModels");
			}
		}
	} = new ObservableRangeCollection<FieldItemViewModel>
	{
		new FieldItemViewModel(FieldType.Header, new FeedbackFieldDto
		{
			Binding = false,
			Display = true,
			Position = -1L
		})
	};

	public ObservableRangeCollection<FileResult> FileResults
	{
		[CompilerGenerated]
		get
		{
			return _003CFileResults_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CFileResults_003Ek__BackingField, value))
			{
				_003CFileResults_003Ek__BackingField = value;
				RaisePropertyChanged("HasFileResults");
				RaisePropertyChanged("FileResults");
			}
		}
	} = new ObservableRangeCollection<FileResult>();

	public LinkedText AcceptanceText
	{
		get
		{
			if (!WithTopicAndCategory)
			{
				return PersonalDataProcessingPolicyLinkedText;
			}
			return PrivacyPolicyLinkedText;
		}
	}

	public IObservable<InfoPageViewModel.Parameter> OpenInfoPageCommand => _onShowInfoPage.Debounce();

	private LinkedText PrivacyPolicyLinkedText => new LinkedText("Я принимаю условия Политики конфиденциальности и даю согласие на обработку персональных данных", "Политики конфиденциальности", ShowPrivacyPolicy);

	private LinkedText PersonalDataProcessingPolicyLinkedText => new LinkedText("Согласен с обработкой персональных данных", "обработкой персональных данных", ShowPersonalDataProcessingPolicy);

	public DynamicFeedbackViewModel(Parameter parameter, DynamicFeedbackService dynamicFeedbackService, IEnvironmentManager environmentManager, ILogService logService, IUserContext userContext, IInfoMessageService infoMessageService)
	{
		_parameter = parameter;
		_dynamicFeedbackService = dynamicFeedbackService;
		_environmentManager = environmentManager;
		_logService = logService;
		_userContext = userContext;
		_infoMessageService = infoMessageService;
		_onSend.PerformDebouncingTask(OnSend).Subscribe().AddTo(base.CloseDisposable);
		SendLogsCommand.PerformDebouncingTask(SendLogs).Subscribe().AddTo(base.CloseDisposable);
		TabBarVisible = !ForCaseChatbot;
		ContinueSuccessCommand.Subscribe(delegate
		{
			if (WithTopicAndCategory)
			{
				OnContinueButtonClicked();
			}
			else
			{
				AppAnalytics.AppMetrica.TrackEvent("helpFormSuccessScreenButtonGreat");
				OpenAuthCommand.Trigger();
			}
		}).AddTo(base.CloseDisposable);
	}

	public void OnListPickerClicked(FieldItemViewModel fieldItemViewModel)
	{
		List<ListPickerItemViewModel> itemList = GetItemList(fieldItemViewModel);
		_openListPicker.OnNext((fieldItemViewModel, new ListPickerViewModel.Parameter(itemList)));
	}

	public bool IsFieldEnabled(string? selectedCityName, FieldItemViewModel fieldItemViewModel)
	{
		if (fieldItemViewModel.EnglishName == "siteCRMId" && string.IsNullOrEmpty(selectedCityName))
		{
			return false;
		}
		return true;
	}

	public void GoToProfile()
	{
		GoToProfileCommand.Trigger();
	}

	public void OnContinueButtonClicked()
	{
		if (ForCaseChatbot)
		{
			GoBackToChatCommand.Trigger();
		}
		else if (ForCasePriceChecker)
		{
			GoBackToPriceCheckerCommand.Trigger();
		}
		else
		{
			ContinueShoppingCommand.Trigger();
		}
	}

	private void ShowPrivacyPolicy()
	{
		_onShowInfoPage.OnNext(new InfoPageViewModel.Parameter(InfoType.PrivacyPolicy));
	}

	private void ShowPersonalDataProcessingPolicy()
	{
		_onShowInfoPage.OnNext(new InfoPageViewModel.Parameter(InfoType.PersonalDataProcessingPolicy));
	}

	public void OnRemoveFileResult(FileResult FileResult)
	{
		FileResults.Remove(FileResult);
		RaisePropertyChanged("FileResults");
		RaisePropertyChanged("HasFileResults");
	}

	public void OnRemoveFileResultsClicked()
	{
		FileResults.Clear();
		RaisePropertyChanged("FileResults");
		RaisePropertyChanged("HasFileResults");
	}

	public void OnFirstFieldWithErrorFocused()
	{
		WasFocusedOnFirstFieldWithError = true;
	}

	protected override async Task Start()
	{
		await base.Start();
		if ((await _dynamicFeedbackService.IsFeedbackActive()).IsFailure)
		{
			State = VisualState.Error;
		}
		else if (!WithTopicAndCategory || _parameter.ForCase == ForCase.SocialStatus)
		{
			await StartForNotAuthorizedUserOrSocialStatusCase();
		}
		else if (_parameter.ForCase == ForCase.PriceChecker)
		{
			await StartForNotAuthorizedUserOrSocialStatusCase();
		}
		else
		{
			await StartForOtherCases();
		}
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		AppAnalytics.AppMetrica.OpenLoyaltyFeedback();
		AppAnalytics.AppMetrica.TrackEvent("helpFormScreenView");
	}

	public List<ListPickerItemViewModel> GetItemsForCategories()
	{
		return _categories?.Select((FeedbackCategoryDto category) => new ListPickerItemViewModel(category.CaseCategoryName, selected: false)).ToList() ?? new List<ListPickerItemViewModel>();
	}

	public void OnCategorySelected(ListPickerItemViewModel listResult)
	{
		SelectedCategory = _categories?.FirstOrDefault((FeedbackCategoryDto category) => category.CaseCategoryName == listResult.Text);
		SelectedTopic = null;
		SelectedCityName = null;
		FieldViewModels.Clear();
	}

	public List<ListPickerItemViewModel> GetItemsForTopics()
	{
		return (SelectedCategory?.Topics)?.Select((FeedbackTopicDto topic) => new ListPickerItemViewModel(topic?.CaseTopicName ?? "", selected: false)).ToList() ?? new List<ListPickerItemViewModel>();
	}

	public async Task OnTopicSelected(ListPickerItemViewModel listResult)
	{
		if (listResult.Text == SelectedTopic?.CaseTopicName)
		{
			return;
		}
		List<FeedbackFieldDto> list = SelectedCategory?.Topics?.FirstOrDefault((FeedbackTopicDto topic) => topic.CaseTopicName == listResult.Text)?.Fields;
		if (list == null)
		{
			return;
		}
		SelectedTopic = SelectedCategory?.Topics?.FirstOrDefault((FeedbackTopicDto topic) => topic.CaseTopicName == listResult.Text);
		List<FieldItemViewModel> fieldItemViewModels = (from x in list.Select(ToFieldViewModel)
			orderby x.Position
			select x).ToList();
		IEnumerable<FieldItemViewModel> enumerable = fieldItemViewModels.Where((FieldItemViewModel field) => field.FieldType == FieldType.ListSelection);
		foreach (FieldItemViewModel item in enumerable)
		{
			await AddItemsToSelectorField(item);
		}
		AutofillFields(fieldItemViewModels, new string[5] { "GivenName", "MobilePhone", "Email", "contactSource", "contactCMDId" });
		AddTextOverProductNameFieldIfNotNull(fieldItemViewModels, SelectedTopic?.ServiceQualityHint);
		SelectedCityName = null;
		fieldItemViewModels.Add(new FieldItemViewModel(FieldType.SendButton, new FeedbackFieldDto
		{
			Binding = false,
			Display = true,
			Position = 2147483647L
		}));
		FieldViewModels.ReplaceRange(fieldItemViewModels);
		State = VisualState.InProgress;
		await Task.Delay(500);
		State = VisualState.Default;
	}

	private void AutofillFields(List<FieldItemViewModel> fieldItemViewModels, string[] fieldNamesToAutofill)
	{
		foreach (string fieldName in fieldNamesToAutofill)
		{
			string text = fieldName switch
			{
				"GivenName" => _userContext.Profile.FirstName, 
				"MobilePhone" => _userContext.Profile.Phone, 
				"Email" => _userContext.Profile.Email, 
				"contactSource" => "ФОС МП", 
				"contactCMDId" => _userContext.Profile.ClientAccountId, 
				_ => string.Empty, 
			};
			FieldItemViewModel fieldItemViewModel = fieldItemViewModels.FirstOrDefault((FieldItemViewModel x) => x.EnglishName == fieldName);
			if (fieldItemViewModel != null)
			{
				fieldItemViewModel.Text = text ?? string.Empty;
			}
		}
	}

	public List<ListPickerItemViewModel> GetItemList(FieldItemViewModel fieldItemViewModel)
	{
		if (fieldItemViewModel.EnglishName != "siteCRMId")
		{
			return fieldItemViewModel.ListPickerItemViewModels;
		}
		City city = _cities.FirstOrDefault((City x) => x.LkpTown == SelectedCityName);
		if (city?.Shops == null)
		{
			return fieldItemViewModel.ListPickerItemViewModels;
		}
		return city.Shops.Select(delegate(Shop shop)
		{
			string? obj = shop.SiteLabel ?? "";
			bool selected = obj == fieldItemViewModel.Text;
			return new ListPickerItemViewModel(obj, selected);
		}).ToList();
	}

	public void OnListItemInFieldItemSelected(FieldItemViewModel fieldItemViewModel, ListPickerItemViewModel selectedListPickerItemViewModel)
	{
		fieldItemViewModel.OnListItemSelected(selectedListPickerItemViewModel);
		if (fieldItemViewModel.EnglishName == "LkpTown")
		{
			SelectedCityName = fieldItemViewModel.Text;
			FieldItemViewModel fieldItemViewModel2 = FieldViewModels.FirstOrDefault((FieldItemViewModel x) => x.EnglishName == "siteCRMId");
			if (fieldItemViewModel2 != null)
			{
				fieldItemViewModel2.Text = string.Empty;
			}
		}
	}

	public async Task UploadImage()
	{
		AppAnalytics.AppMetrica.TrackEvent("helpFormScreenButtonFileAttach");
		PermissionStatus permissionStatus = await PermissionExtensions.CheckOrRequestAsync<Permissions.StorageRead>();
		if (permissionStatus == PermissionStatus.Denied)
		{
			permissionStatus = await PermissionExtensions.CheckOrRequestAsync<Permissions.Media>();
		}
		if (permissionStatus != PermissionStatus.Granted)
		{
			return;
		}
		State = VisualState.InProgress;
		FileResult fileResult = await MediaPicker.Default.PickPhotoAsync();
		State = VisualState.Default;
		if (fileResult != null)
		{
			FileResults.Add(fileResult);
			if (FileResults.IsNullOrEmpty())
			{
				State = VisualState.Error;
				return;
			}
			RaisePropertyChanged("FileResults");
			RaisePropertyChanged("HasFileResults");
		}
	}

	public void OnSendClicked()
	{
		_onSend.OnNext(Unit.Default);
		AppAnalytics.AppMetrica.TrackEvent("helpFormScreenButtonSubmit");
	}

	private async Task OnSend()
	{
		if (!ValidateFields())
		{
			return;
		}
		State = VisualState.InProgress;
		object body = await CreateRespondObjectToSend();
		Result<FeedbackRespondResponse, DomainError> result = await _dynamicFeedbackService.Respond(body);
		if (result.IsFailure)
		{
			State = VisualState.Error;
		}
		if (result.IsSuccess)
		{
			AppAnalytics.AppMetrica.TrackEvent("helpFormScreenNieventSuccess");
			if (SelectedCategory?.CaseCategoryName == "Онлайн-магазин" && SelectedTopic?.CaseTopicName == "Ошибка на сайте/в приложении")
			{
				SendLogsCommand.Trigger(null);
			}
			else if (_parameter.ForCase == ForCase.AuthOrRegister)
			{
				SendLogsCommand.Trigger(ILogService.SendFrom.AuthOrRegister);
			}
			SuccessFeedbackNumber = result.Value.CaseNumber;
			SuccessFeedbackDescription = result.Value.InformerText ?? "Вернемся с ответом в течение 24 часов.<br /> Хорошего дня!";
			State = VisualState.Success;
			AppAnalytics.AppMetrica.TrackEvent("helpFormSuccessScreenView");
		}
		else
		{
			AppAnalytics.AppMetrica.TrackEvent("helpFormScreenNieventError", ("errorId", result.Error.GetType().Name + ": " + (result.Error.Message ?? string.Empty)));
		}
	}

	public void OnRetryClicked()
	{
		State = VisualState.Default;
	}

	private async Task SendLogs(ILogService.SendFrom? sendFrom = null)
	{
		Result<Unit, DomainError> result = await _logService.SendLogs(sendFrom);
		if (result.IsFailure)
		{
			if (!string.IsNullOrEmpty(result.Error?.Message))
			{
				_infoMessageService.ShowSnackbar(string.Format("Не удалось отправить логи, повторите попытку", "\nОтвет: " + result.Error.Message));
			}
			else
			{
				_infoMessageService.ShowSnackbar($"Не удалось отправить логи, повторите попытку");
			}
		}
		else
		{
			_infoMessageService.ShowSnackbar("Логи успешно отправлены", SnackbarStyle.Success);
		}
	}

	private async Task StartForOtherCases()
	{
		Result<FeedbackCategoriesResponse, DomainError> result = await _dynamicFeedbackService.GetCategories();
		if (result.IsSuccess)
		{
			_categories = result.Value.Categories;
			GreetingsString = result.Value.ServiceWelcomeText ?? "";
			Topics = SelectedCategory?.Topics;
			if (!string.IsNullOrEmpty(_parameter.PreselectedCategory))
			{
				FeedbackCategoryDto feedbackCategoryDto = _categories.FirstOrDefault((FeedbackCategoryDto c) => c.CaseCategoryName == _parameter.PreselectedCategory);
				if (feedbackCategoryDto != null && !string.IsNullOrEmpty(feedbackCategoryDto.CaseCategoryName))
				{
					OnCategorySelected(new ListPickerItemViewModel(feedbackCategoryDto.CaseCategoryName, selected: true));
					CategoryItemViewModel.Text = feedbackCategoryDto.CaseCategoryName;
					if (!string.IsNullOrEmpty(_parameter.PreselectedTopic))
					{
						FeedbackTopicDto topic = feedbackCategoryDto.Topics?.FirstOrDefault((FeedbackTopicDto t) => t.CaseTopicName == _parameter.PreselectedTopic);
						if (topic != null)
						{
							await OnTopicSelected(new ListPickerItemViewModel(topic.CaseTopicName ?? "", selected: true));
							TopicItemViewModel.Text = topic.CaseTopicName ?? "";
						}
					}
				}
			}
			State = VisualState.Default;
		}
		else
		{
			State = VisualState.Error;
		}
	}

	private async Task StartForNotAuthorizedUserOrSocialStatusCase()
	{
		Result<FeedbackCategoriesResponse, DomainError> result = await _dynamicFeedbackService.GetCategories();
		if (result.IsSuccess)
		{
			_categories = result.Value.Categories;
			GreetingsString = result.Value.ServiceWelcomeText ?? "";
		}
		_serviceSrmIdForNotAuthFeedback = _parameter.ForCase switch
		{
			ForCase.PriceChecker => "034c0e9a-7c2e-4547-9e56-22616c5c5486", 
			ForCase.SocialStatus => (_environmentManager.CurrentEnvironment == Auchan.Common.Networking.Environment.Production) ? "f15d0c36-65bf-4f81-839a-f6051c3e9489" : "f15d0c36-65bf-4f81-839a-f6051c3e9489", 
			_ => (_environmentManager.CurrentEnvironment == Auchan.Common.Networking.Environment.Production) ? "d5be5b5f-2c0d-47c5-a312-d33a0656c49c" : "772c2efe-da54-42ba-9022-fa46f2462fc4", 
		};
		Result<FeedbackFieldsResponse, DomainError> result2 = await _dynamicFeedbackService.GetFields(_serviceSrmIdForNotAuthFeedback);
		if (result2.IsSuccess)
		{
			List<FieldItemViewModel> fieldViewModels = (from field in result2.Value.Fields?.Where((FeedbackFieldDto x) => x.Display)
				orderby field.Position
				select field).Select(ToFieldViewModel).ToList();
			if (fieldViewModels != null)
			{
				IEnumerable<FieldItemViewModel> enumerable = fieldViewModels.Where((FieldItemViewModel field) => field.FieldType == FieldType.ListSelection);
				foreach (FieldItemViewModel item in enumerable)
				{
					await AddItemsToSelectorField(item);
				}
				AutofillFields(fieldViewModels, (_parameter.ForCase != ForCase.SocialStatus) ? new string[1] { "contactSource" } : new string[5] { "GivenName", "MobilePhone", "Email", "contactSource", "contactCMDId" });
				AddTextOverProductNameFieldIfNotNull(fieldViewModels, result2.Value.ServiceQualityHint);
				fieldViewModels.Add(new FieldItemViewModel(FieldType.SendButton, new FeedbackFieldDto
				{
					Binding = false,
					Display = true,
					Position = 2147483647L
				}));
				FieldViewModels.AddRange(fieldViewModels);
				State = VisualState.InProgress;
				await Task.Delay(500);
				State = VisualState.Default;
			}
			if (_parameter.ForCase == ForCase.PriceChecker)
			{
				OnCategorySelected(new ListPickerItemViewModel("Розничный магазин", selected: true));
				await OnTopicSelected(new ListPickerItemViewModel("Вопросы по чеку/ценнику", selected: true));
				CategoryItemViewModel.Text = "Розничный магазин";
				TopicItemViewModel.Text = "Вопросы по чеку/ценнику";
			}
		}
		else
		{
			State = VisualState.Error;
		}
	}

	private bool ValidateFields()
	{
		WasFocusedOnFirstFieldWithError = false;
		foreach (FieldItemViewModel fieldViewModel in FieldViewModels)
		{
			fieldViewModel.RemoveError();
		}
		if (FieldViewModels.Count == 0)
		{
			return true;
		}
		if (!FieldViewModels.Any((FieldItemViewModel x) => (x.FieldType != FieldType.Header && x.FieldType != FieldType.SendButton && x.FieldType != FieldType.File && x.Binding && string.IsNullOrEmpty(x.Text)) || (x.FieldType == FieldType.Date && x.Text.Length > 0 && x.Text.Length < 6) || (x.FieldType == FieldType.DateTime && x.Text.Length > 0 && x.Text.Length < 10) || (x.HasEmailMask && !x.IsEmailValid) || (x.HasPhoneMask && !x.IsPhoneValid)))
		{
			return true;
		}
		foreach (FieldItemViewModel fieldViewModel2 in FieldViewModels)
		{
			if (fieldViewModel2.HasEmailMask && !fieldViewModel2.IsEmailValid)
			{
				fieldViewModel2.ShowEmailError();
				continue;
			}
			if (fieldViewModel2.HasPhoneMask && !fieldViewModel2.IsPhoneValid)
			{
				fieldViewModel2.ShowNotFillError();
				continue;
			}
			FieldType fieldType = fieldViewModel2.FieldType;
			if (fieldType != FieldType.Date)
			{
				if (fieldType == FieldType.DateTime && fieldViewModel2.Text.Length > 0 && fieldViewModel2.Text.Length < 10)
				{
					goto IL_010b;
				}
			}
			else if (fieldViewModel2.Text.Length > 0 && fieldViewModel2.Text.Length < 6)
			{
				goto IL_010b;
			}
			if (fieldViewModel2.Binding && ((fieldViewModel2.Display && fieldViewModel2.FieldType == FieldType.File && FileResults.Count == 0) || (fieldViewModel2.Display && fieldViewModel2.FieldType != FieldType.File && string.IsNullOrEmpty(fieldViewModel2.Text))))
			{
				fieldViewModel2.ShowRequiredError();
			}
			continue;
			IL_010b:
			fieldViewModel2.ShowNotFillError();
		}
		if (DeviceInfo.Platform == DevicePlatform.Android)
		{
			FieldViewModels.ForceNotifyItemChanged(FieldViewModels.First());
		}
		return false;
	}

	private async Task<object> CreateRespondObjectToSend()
	{
		dynamic respondObject = new ExpandoObject();
		IDictionary<string, object> respondDictionary = (IDictionary<string, object>)respondObject;
		long num = -1L;
		if (WithTopicAndCategory)
		{
			num = SelectedTopic?.Id ?? (-1);
		}
		else
		{
			foreach (FeedbackCategoryDto item in _categories ?? new List<FeedbackCategoryDto>())
			{
				foreach (FeedbackTopicDto item2 in item.Topics ?? new List<FeedbackTopicDto>())
				{
					if (item2.ServiceCrmId.ToString() == _serviceSrmIdForNotAuthFeedback)
					{
						num = item2.Id;
					}
				}
			}
		}
		respondDictionary.Add("topic_id", num);
		respondDictionary.Add("KmkIsPresonalData", IsUserAgreed);
		await AddFileResultsToRespondDictionary(respondDictionary);
		AddDataFromFieldsToDictionary(respondDictionary);
		return respondObject;
	}

	private async Task AddFileResultsToRespondDictionary(IDictionary<string, object> respondDictionary)
	{
		if (FileResults.Count <= 0)
		{
			return;
		}
		Result<List<FeedbackUploadFilesResponse>, DomainError> result = await _dynamicFeedbackService.UploadFiles(FileResults.ToList());
		if (result.IsSuccess)
		{
			List<Dictionary<string, object>> value = result.Value.Select((FeedbackUploadFilesResponse file) => new Dictionary<string, object>
			{
				{
					"url",
					file.Url ?? ""
				},
				{
					"name",
					file.Name ?? ""
				}
			}).ToList();
			respondDictionary.Add("caseFiles", value);
		}
	}

	private void AddDataFromFieldsToDictionary(IDictionary<string, object> respondDictionary)
	{
		if (!WithTopicAndCategory && FieldViewModels.All((FieldItemViewModel x) => x.EnglishName != "contactSource"))
		{
			respondDictionary.Add("contactSource", "ФОС МП");
		}
		foreach (FieldItemViewModel fieldViewModel in FieldViewModels)
		{
			if (fieldViewModel.EnglishName == "caseFiles")
			{
				continue;
			}
			if (fieldViewModel.HasPhoneMask)
			{
				fieldViewModel.Text = Regex.Replace(fieldViewModel.Text, "[^0-9]", "", RegexOptions.None, TimeSpan.FromSeconds(60L));
			}
			switch (fieldViewModel.FieldType)
			{
			case FieldType.Bool:
				respondDictionary.Add(fieldViewModel.EnglishName, fieldViewModel.BoolResult == true);
				continue;
			case FieldType.Date:
				respondDictionary.Add(fieldViewModel.EnglishName, (fieldViewModel.Text.Length > 6) ? fieldViewModel.Text : Mask(fieldViewModel.Text, "##.##.##"));
				continue;
			case FieldType.DateTime:
				respondDictionary.Add(fieldViewModel.EnglishName, (fieldViewModel.Text.Length > 10) ? fieldViewModel.Text : Mask(fieldViewModel.Text, "##.##.##, ##:##"));
				continue;
			}
			string englishName = fieldViewModel.EnglishName;
			if (!(englishName == "siteCRMId"))
			{
				if (englishName == "PreferredCommunicationMethod")
				{
					string text = _communicationMethods?.FirstOrDefault((PreferredCommunicationMethod method) => method.Name == fieldViewModel.Text)?.Code.ToString();
					if (text != null)
					{
						respondDictionary.Add(fieldViewModel.EnglishName, text);
					}
				}
				else if (!string.IsNullOrEmpty(fieldViewModel.EnglishName))
				{
					respondDictionary.Add(fieldViewModel.EnglishName, fieldViewModel.Text);
				}
			}
			else
			{
				string value = _shops.FirstOrDefault((Shop shop) => shop.SiteLabel == fieldViewModel.Text)?.SiteCrmId.ToString() ?? string.Empty;
				respondDictionary.Add(fieldViewModel.EnglishName, value);
			}
		}
	}

	private async Task AddItemsToSelectorField(FieldItemViewModel fieldItemViewModel)
	{
		State = VisualState.InProgress;
		if (fieldItemViewModel.FieldType == FieldType.ListSelection)
		{
			if (fieldItemViewModel.EnglishName == "PreferredCommunicationMethod")
			{
				Result<FeedbackChannelsResponse, DomainError> result = await _dynamicFeedbackService.GetChannels();
				if (result.IsSuccess)
				{
					_communicationMethods = result.Value.CommunicationMethods;
					fieldItemViewModel.ListPickerItemViewModels = _communicationMethods?.Select((PreferredCommunicationMethod method) => new ListPickerItemViewModel(method.Name ?? "", selected: false)).ToList() ?? new List<ListPickerItemViewModel>();
				}
			}
			else
			{
				Result<FeedbackCitiesResponse, DomainError> result2 = await _dynamicFeedbackService.GetCities();
				if (fieldItemViewModel.EnglishName == "LkpTown")
				{
					if (result2.Value.Cities != null)
					{
						_cities.Clear();
						_cities.AddRange(result2.Value.Cities);
						fieldItemViewModel.ListPickerItemViewModels = result2.Value.Cities.Select((City city) => new ListPickerItemViewModel(city.LkpTown ?? "", selected: false)).ToList();
					}
				}
				else if (fieldItemViewModel.EnglishName == "siteCRMId" && result2.Value.Cities != null)
				{
					new List<ListPickerItemViewModel>();
					_shops.Clear();
					result2.Value.Cities.ForEach(delegate(City city)
					{
						_shops.AddRange(city.Shops);
					});
					List<ListPickerItemViewModel> listPickerItemViewModels = _shops.Select((Shop shop) => new ListPickerItemViewModel(shop.SiteLabel ?? "", selected: false)).ToList();
					fieldItemViewModel.ListPickerItemViewModels = listPickerItemViewModels;
				}
			}
		}
		State = VisualState.Default;
	}

	private void AddTextOverProductNameFieldIfNotNull(List<FieldItemViewModel> fieldViewModels, string? textOverProduct)
	{
		FieldItemViewModel fieldItemViewModel = fieldViewModels?.FirstOrDefault((FieldItemViewModel x) => x.EnglishName == "GivenName");
		int? num = fieldViewModels?.IndexOf(fieldItemViewModel);
		if (num != -1)
		{
			fieldViewModels.Insert(num.Value, new FieldItemViewModel(FieldType.Warning, new FeedbackFieldDto
			{
				Binding = false,
				Display = true,
				Position = (fieldItemViewModel?.Position ?? (-1))
			}));
		}
		FieldItemViewModel fieldItemViewModel2 = fieldViewModels.FirstOrDefault((FieldItemViewModel x) => x.EnglishName == "productName");
		int? num2 = fieldViewModels?.IndexOf(fieldItemViewModel2);
		if (num2 != -1)
		{
			fieldViewModels.Insert(num2.Value, new FieldItemViewModel(FieldType.Info, new FeedbackFieldDto
			{
				Name = textOverProduct,
				NameFos = textOverProduct,
				Binding = false,
				Display = true,
				Position = (fieldItemViewModel2?.Position ?? (-1))
			}));
		}
	}

	private static FieldItemViewModel ToFieldViewModel(FeedbackFieldDto field)
	{
		long type = field.Type;
		long num = type - 1;
		if ((ulong)num <= 10uL)
		{
			switch (num)
			{
			case 0L:
				return new FieldItemViewModel(FieldType.Bool, field);
			case 1L:
				return new FieldItemViewModel(FieldType.DateTime, field);
			case 2L:
				return new FieldItemViewModel(FieldType.Date, field);
			case 3L:
				return new FieldItemViewModel(FieldType.Integer, field);
			case 4L:
				return new FieldItemViewModel(FieldType.Float, field);
			case 5L:
				return new FieldItemViewModel(FieldType.ListSelection, field);
			case 6L:
				return new FieldItemViewModel(FieldType.TextField50, field);
			case 7L:
				return new FieldItemViewModel(FieldType.TextField250, field);
			case 8L:
				return new FieldItemViewModel(FieldType.TextField500, field);
			case 9L:
				return new FieldItemViewModel(FieldType.TextFieldUnlimited, field);
			case 10L:
				return new FieldItemViewModel(FieldType.File, field);
			}
		}
		return new FieldItemViewModel(FieldType.Undefined, field);
	}

	private string Mask(string value, string mask, char substituteChar = '#')
	{
		int valueIndex = 0;
		try
		{
			return new string(mask.Select((char maskChar) => (maskChar != substituteChar) ? maskChar : value[valueIndex++]).ToArray());
		}
		catch (IndexOutOfRangeException)
		{
			return string.Empty;
		}
	}
}
