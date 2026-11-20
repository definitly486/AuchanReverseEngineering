using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.DynamicFeedback;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.Reviews.Api.Ecom.Dto;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Media;
using Microsoft.Maui.Storage;
using Newtonsoft.Json;
using Refit;

namespace Auchan.Common.Reviews;

public class AddReviewViewModel : ScreenViewModel<AddReviewViewModel.Parameter>
{
	public class Parameter : BrokeredParameter<bool>
	{
		public string? GimaId { get; set; }

		public string? Title { get; set; }

		public string ImageUrl { get; set; }

		public int? GimaIdInt
		{
			get
			{
				int result;
				return int.TryParse(GimaId?.Trim(), out result) ? result : 0;
			}
		}

		public Parameter(Product product)
			: base(default(CancellationToken))
		{
			ImageUrl = product.ImageUrl ?? product.MediaUrls?.FirstOrDefault() ?? "";
			GimaId = product.GimaId;
			Title = product.Title;
		}

		[JsonConstructor]
		public Parameter(string title, string gimaId, string imageUrl)
			: base(default(CancellationToken))
		{
			Title = title;
			GimaId = gimaId;
			ImageUrl = imageUrl;
		}
	}

	public sealed class TriggerWordItem
	{
		public required int Id { get; init; }

		public required string Name { get; init; }

		public bool IsCustom { get; init; }

		public bool IsSelected { get; set; }
	}

	public sealed class ImageLoadFailedStubItem
	{
		public Guid Id { get; init; } = Guid.NewGuid();
	}

	public enum CommentProgressIndicatorState
	{
		QuarterGray,
		HalfYellow,
		FullGreen
	}

	private const int CommentProgressBarThreshold = 20;

	private const long MaxPhotoSizeBytes = 20971520L;

	private const string DefaultCommentSmallText = "Добавьте больше подробностей — отзыв станет ещё полезнее!";

	private const string DefaultCommentLongText = "Спасибо за детали! Они помогут другим покупателям!";

	private const int MaxFailedStubsCount = 1;

	private readonly Dictionary<int, long> _fileLengths = new Dictionary<int, long>();

	private readonly Parameter _parameter;

	private readonly ReviewsEcomService _reviewsEcomService;

	private readonly IInfoMessageService _infoMessageService;

	private readonly IUserContext _userContext;

	private readonly IAdminContext _adminContext;

	private string? _commentSmallText;

	private string? _commentLongText;

	private bool _isCommentProgressWarningAvailable;

	private int _rating = 5;

	private DateTime? _productProductionDate;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CComment_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CManufacturer_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CProductProductionDateText_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CSendButtonWasPressedFirstTime_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<FileResult> _003CFileResults_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CShowPhotoUploadError_003Ek__BackingField;

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.Default;

	public string Title => "Поделитесь Вашими\nвпечатлениями о товаре";

	public string ProductImageUrl => _parameter.ImageUrl;

	public string ProductName => _parameter.Title ?? "";

	public string RateProductText => "Поставьте оценку*";

	public int Rating
	{
		get
		{
			return _rating;
		}
		set
		{
			if (_rating != value)
			{
				_rating = value;
				RaisePropertyChanged("SendReviewButtonEnabled");
				RaisePropertyChanged("Rating");
				RaisePropertyChanged("HasRating");
				RaisePropertyChanged("TriggerWordsTitle");
				RaisePropertyChanged("ShowAdditionalProductFields");
				ApplyAdditionalFieldsVisibility();
			}
		}
	}

	public bool HasRating => Rating != 0;

	public string TriggerWordsTitle
	{
		get
		{
			string text = (string.IsNullOrEmpty(Comment) ? "*" : "");
			if (Rating == 4)
			{
				return "Что можно улучшить?" + text;
			}
			if (Rating > 0 && Rating <= 3)
			{
				return "Что не понравилось?" + text;
			}
			return "Что понравилось?" + text;
		}
	}

	public bool ShowTriggerWords => TriggerWords.Count > 0;

	public ObservableCollection<TriggerWordItem> TriggerWords { get; } = new ObservableCollection<TriggerWordItem>();

	public bool ShowCommentProgressWarning
	{
		get
		{
			if (_isCommentProgressWarningAvailable)
			{
				return CurrentCommentLength > 0;
			}
			return false;
		}
	}

	public string LengthInformerText
	{
		get
		{
			object obj;
			if (CurrentCommentLength >= 20)
			{
				obj = _commentLongText;
				if (obj == null)
				{
					return "Спасибо за детали! Они помогут другим покупателям!";
				}
			}
			else
			{
				obj = _commentSmallText ?? "Добавьте больше подробностей — отзыв станет ещё полезнее!";
			}
			return (string)obj;
		}
	}

	public string CommentText
	{
		get
		{
			if (!HasSelectedTriggerWords)
			{
				return "Поделитесь своим мнением*";
			}
			return "Поделитесь своим мнением";
		}
	}

	public CommentProgressIndicatorState CommentProgressState
	{
		get
		{
			if (CurrentCommentLength < 10)
			{
				return CommentProgressIndicatorState.QuarterGray;
			}
			if (CurrentCommentLength < 20)
			{
				return CommentProgressIndicatorState.HalfYellow;
			}
			return CommentProgressIndicatorState.FullGreen;
		}
	}

	public int CommentProgressPercent
	{
		get
		{
			int currentCommentLength = CurrentCommentLength;
			if (currentCommentLength <= 0)
			{
				return 0;
			}
			if (currentCommentLength < 10)
			{
				int num = Math.Max(1, 10 - 1);
				return (int)Math.Round(25f + ((float)currentCommentLength - 1f) / (float)num * 25f, MidpointRounding.AwayFromZero);
			}
			if (currentCommentLength < 20)
			{
				int num2 = Math.Max(1, 20 - 10);
				return (int)Math.Round(50f + (float)(currentCommentLength - 10) / (float)num2 * 50f, MidpointRounding.AwayFromZero);
			}
			return 100;
		}
	}

	public float CommentProgressValue => (float)CommentProgressPercent / 100f;

	public string Comment
	{
		[CompilerGenerated]
		get
		{
			return _003CComment_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CComment_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CComment_003Ek__BackingField = value;
				RaisePropertyChanged("TriggerWordsTitle");
				RaisePropertyChanged("CurrentCommentLength");
				RaisePropertyChanged("ShowCommentProgressWarning");
				RaisePropertyChanged("LengthInformerText");
				RaisePropertyChanged("CommentProgressState");
				RaisePropertyChanged("CommentProgressPercent");
				RaisePropertyChanged("CommentProgressValue");
				RaisePropertyChanged("IsCommentValid");
				RaisePropertyChanged("SendReviewButtonEnabled");
				RaisePropertyChanged("Comment");
			}
		}
	} = string.Empty;

	public int MinCommentLength => 10;

	public int MaxCommentLength => 2000;

	public int CurrentCommentLength => StringInfo.ParseCombiningCharacters(Comment.Trim()).Count();

	public bool HasSelectedTriggerWords => TriggerWords.Any((TriggerWordItem t) => t.IsSelected);

	public bool HasSelectedCustomTriggerWords => TriggerWords.Any((TriggerWordItem t) => t.IsSelected && t.IsCustom);

	public bool ShowAdditionalProductFields
	{
		get
		{
			if (HasSelectedCustomTriggerWords)
			{
				return Rating <= 3;
			}
			return false;
		}
	}

	public string ManufacturerLabel => "Производитель";

	public string ProductionDateLabel => "дд.мм.гг";

	public string OptionalFieldHintText => "Необязательное поле";

	public string Manufacturer
	{
		[CompilerGenerated]
		get
		{
			return _003CManufacturer_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CManufacturer_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CManufacturer_003Ek__BackingField = value;
				RaisePropertyChanged("Manufacturer");
			}
		}
	} = string.Empty;

	public string ProductProductionDateText
	{
		[CompilerGenerated]
		get
		{
			return _003CProductProductionDateText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CProductProductionDateText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CProductProductionDateText_003Ek__BackingField = value;
				RaisePropertyChanged("ProductProductionDateText");
			}
		}
	} = string.Empty;

	public DateTime? ProductProductionDate
	{
		get
		{
			return _productProductionDate;
		}
		set
		{
			if (!Nullable.Equals(_productProductionDate, value))
			{
				_productProductionDate = value;
				RaisePropertyChanged("ProductProductionDate");
				ProductProductionDateText = value?.ToString("dd.MM.yy") ?? "";
			}
		}
	}

	private bool IsCommentValid
	{
		get
		{
			if (CurrentCommentLength == 0)
			{
				return HasSelectedTriggerWords;
			}
			if (CurrentCommentLength >= 10)
			{
				return CurrentCommentLength <= 2000;
			}
			return false;
		}
	}

	public bool SendButtonWasPressedFirstTime
	{
		[CompilerGenerated]
		get
		{
			return _003CSendButtonWasPressedFirstTime_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CSendButtonWasPressedFirstTime_003Ek__BackingField != value)
			{
				_003CSendButtonWasPressedFirstTime_003Ek__BackingField = value;
				RaisePropertyChanged("SendButtonWasPressedFirstTime");
			}
		}
	}

	public string AddPhotosText => "Добавьте фото";

	public string AddFileText => "Добавьте фото";

	public string LimitationsWarningText => "Общий размер файлов не более 20 Мб (jpeg, jpg, png)";

	public bool SendReviewButtonEnabled
	{
		get
		{
			if (HasRating)
			{
				return IsCommentValid;
			}
			return false;
		}
	}

	public string SendReviewButtonText => "Отправить";

	public LinkedText ChatBotText => new LinkedText("Вопрос не по товару?\nНапишите нам в {0}", "чат", ShowChatBot);

	public string SuccessSentTitle => "Спасибо за отзыв!";

	public string SuccessSentMessage => "Мы опубликуем его\nпосле модерации";

	public string SuccessSentButtonText => "Понятно";

	public string ErrorTitle => "Произошла ошибка";

	public string ErrorReviewSendingMessage => "Отзыв не отправлен";

	public string ErrorCloseButtonText => "Закрыть";

	public bool HasFileResults => GetTotalPhotoItemCount() > 0;

	public bool ShowRemoveAllFileResults => GetTotalPhotoItemCount() > 1;

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
				RaisePropertyChanged("ShowRemoveAllFileResults");
				RaisePropertyChanged("FileResults");
			}
		}
	} = new ObservableRangeCollection<FileResult>();

	public ObservableRangeCollection<ImageLoadFailedStubItem> ImageLoadFailedStubs { get; } = new ObservableRangeCollection<ImageLoadFailedStubItem>();

	public bool ShowPhotoUploadError
	{
		[CompilerGenerated]
		get
		{
			return _003CShowPhotoUploadError_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CShowPhotoUploadError_003Ek__BackingField != value)
			{
				_003CShowPhotoUploadError_003Ek__BackingField = value;
				RaisePropertyChanged("ShowPhotoUploadError");
			}
		}
	}

	public string PhotoUploadErrorText => "Произошла ошибка, загрузите файл заново";

	public UICommand CloseCommand { get; } = new UICommand();

	public UICommand<DynamicFeedbackViewModel.Parameter> GoToFeedbackCommand { get; } = new UICommand<DynamicFeedbackViewModel.Parameter>();

	public UICommand GoToSupportChatCommand { get; } = new UICommand();

	public UICommand<InfoPageViewModel.Parameter> OpenInfoPageCommand { get; } = new UICommand<InfoPageViewModel.Parameter>();

	public UICommand UploadImageCommand { get; } = new UICommand();

	public UICommand<int> ToggleTriggerWordCommand { get; } = new UICommand<int>();

	public UICommand SendReviewCommand { get; } = new UICommand();

	public LinkedText ReviewRulesLinkedText => new LinkedText("Перед нажатием, я ознакомился с {0} и {1}", new string[2] { "правилами публикации отзывов", "политикой конфиденциальности" }, new Action[2] { ShowReviewRules, ShowPrivacyPolicy });

	public AddReviewViewModel(BrokerToken brokerToken, ReviewsEcomService reviewsEcomService, IInfoMessageService infoMessageService, IUserContext userContext, IAdminContext adminContext)
		: base(brokerToken)
	{
		_parameter = base.Argument;
		_reviewsEcomService = reviewsEcomService;
		_infoMessageService = infoMessageService;
		_userContext = userContext;
		_adminContext = adminContext;
		UploadImageCommand.Subscribe(delegate
		{
			UploadImage().SafeFireAndForget((Action<Exception>)null, false);
		}).AddTo(base.CloseDisposable);
		SendReviewCommand.PerformDebouncingTask(SendReview).Subscribe().AddTo(base.CloseDisposable);
		ToggleTriggerWordCommand.Subscribe(ToggleTriggerWord).AddTo(base.CloseDisposable);
	}

	private void ShowChatBot()
	{
		if (_adminContext.AppConfig.IsChatEnabled)
		{
			GoToSupportChatCommand.Trigger();
		}
		else
		{
			GoToFeedbackCommand.Trigger(new DynamicFeedbackViewModel.Parameter(FeedbackState.WithTopicAndCategory));
		}
	}

	private void ShowReviewRules()
	{
		OpenInfoPageCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.ReviewingRules));
	}

	private void ShowPrivacyPolicy()
	{
		OpenInfoPageCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.PrivacyPolicy));
	}

	public void OnAcceptanceTap(bool isChecked)
	{
	}

	protected override async Task Start()
	{
		State = VisualState.InProgress;
		await base.Start();
		try
		{
			Result<ReviewFormSettingsDataDto, DomainError> result = await _reviewsEcomService.GetFormSettings(_parameter.GimaIdInt);
			if (result.IsFailure)
			{
				TriggerWords.Clear();
				_isCommentProgressWarningAvailable = false;
				RaisePropertyChanged("TriggerWords");
				RaisePropertyChanged("ShowTriggerWords");
				RaisePropertyChanged("ShowCommentProgressWarning");
				RaisePropertyChanged("LengthInformerText");
				RaisePropertyChanged("TriggerWordsTitle");
				RefreshAfterTriggerWordsChanged();
				return;
			}
			ReviewFormSettingsDataDto value = result.Value;
			_commentSmallText = value.CommentSmallText;
			_commentLongText = value.CommentLongText;
			_isCommentProgressWarningAvailable = true;
			TriggerWords.Clear();
			IEnumerable<ReviewFormSettingsTriggerWordDto> triggerWords = value.TriggerWords;
			foreach (ReviewFormSettingsTriggerWordDto item in triggerWords ?? Enumerable.Empty<ReviewFormSettingsTriggerWordDto>())
			{
				if (item.Id.HasValue && !string.IsNullOrWhiteSpace(item.Name))
				{
					TriggerWords.Add(new TriggerWordItem
					{
						Id = item.Id.Value,
						Name = item.Name,
						IsCustom = item.IsCustom
					});
				}
			}
			RaisePropertyChanged("TriggerWords");
			RaisePropertyChanged("ShowTriggerWords");
			RaisePropertyChanged("ShowCommentProgressWarning");
			RaisePropertyChanged("LengthInformerText");
			RaisePropertyChanged("TriggerWordsTitle");
			RefreshAfterTriggerWordsChanged();
		}
		finally
		{
			State = VisualState.Default;
		}
	}

	private void ToggleTriggerWord(int triggerWordId)
	{
		TriggerWordItem triggerWordItem = TriggerWords.FirstOrDefault((TriggerWordItem word) => word.Id == triggerWordId);
		if (triggerWordItem != null)
		{
			triggerWordItem.IsSelected = !triggerWordItem.IsSelected;
			RaisePropertyChanged("TriggerWords");
			RefreshAfterTriggerWordsChanged();
		}
	}

	private void RefreshAfterTriggerWordsChanged()
	{
		RaisePropertyChanged("HasSelectedTriggerWords");
		RaisePropertyChanged("HasSelectedCustomTriggerWords");
		RaisePropertyChanged("CommentText");
		RaisePropertyChanged("SendReviewButtonEnabled");
		RaisePropertyChanged("ShowAdditionalProductFields");
		ApplyAdditionalFieldsVisibility();
	}

	private void ApplyAdditionalFieldsVisibility()
	{
		if (!ShowAdditionalProductFields)
		{
			bool flag = false;
			if (!string.IsNullOrEmpty(Manufacturer))
			{
				Manufacturer = string.Empty;
				flag = true;
			}
			if (!string.IsNullOrEmpty(ProductProductionDateText))
			{
				ProductProductionDateText = string.Empty;
				flag = true;
			}
			if (flag)
			{
				RaisePropertyChanged("Manufacturer");
				RaisePropertyChanged("ProductProductionDateText");
			}
		}
	}

	private async Task UploadImage()
	{
		if (GetTotalPhotoItemCount() >= 5)
		{
			return;
		}
		PermissionStatus permissionStatus = await PermissionExtensions.CheckOrRequestAsync<Permissions.StorageRead>();
		if (permissionStatus == PermissionStatus.Denied)
		{
			permissionStatus = await PermissionExtensions.CheckOrRequestAsync<Permissions.Media>();
		}
		if (permissionStatus != PermissionStatus.Granted)
		{
			return;
		}
		FileResult file = await MediaPicker.Default.PickPhotoAsync();
		if (file == null)
		{
			return;
		}
		using (Stream stream = await file.OpenReadAsync())
		{
			_fileLengths.Add(file.GetHashCode(), stream.Length);
		}
		_ = 1;
		await WaitForResume();
		if (_fileLengths.Sum((KeyValuePair<int, long> x) => x.Value) > 20971520 || file.ContentType == "image/gif")
		{
			_fileLengths.Remove(file.GetHashCode());
			ReplaceFailedStub();
			ShowPhotoUploadError = true;
			RaisePhotoItemsChanged();
			RaisePropertyChanged("ShowPhotoUploadError");
			return;
		}
		if (ImageLoadFailedStubs.Count > 0)
		{
			ImageLoadFailedStubs.Clear();
		}
		FileResults.Add(file);
		ShowPhotoUploadError = false;
		if (!FileResults.IsNullOrEmpty())
		{
			AppAnalytics.AppMetrica.TrackEvent("TapReviewComposeOnAddPhoto");
			RaisePhotoItemsChanged();
			RaisePropertyChanged("ShowPhotoUploadError");
		}
	}

	public void OnRemoveFileResult(FileResult fileResult)
	{
		_fileLengths.Remove(fileResult.GetHashCode());
		FileResults.Remove(fileResult);
		RaisePhotoItemsChanged();
	}

	public void OnRemoveFileResultsClicked()
	{
		if (GetTotalPhotoItemCount() != 0)
		{
			_fileLengths.Clear();
			FileResults.Clear();
			ImageLoadFailedStubs.Clear();
			ShowPhotoUploadError = false;
			RaisePhotoItemsChanged();
			RaisePropertyChanged("ShowPhotoUploadError");
		}
	}

	public void OnImagePreviewLoadFailed(FileResult fileResult)
	{
		if (FileResults.Remove(fileResult))
		{
			RaisePhotoItemsChanged();
		}
	}

	public void OnRemoveImageLoadFailedStub(Guid stubId)
	{
		ImageLoadFailedStubItem imageLoadFailedStubItem = ImageLoadFailedStubs.FirstOrDefault((ImageLoadFailedStubItem item) => item.Id == stubId);
		if (imageLoadFailedStubItem != null)
		{
			ImageLoadFailedStubs.Remove(imageLoadFailedStubItem);
			ShowPhotoUploadError = false;
			RaisePhotoItemsChanged();
			RaisePropertyChanged("ShowPhotoUploadError");
		}
	}

	private async Task SendReview()
	{
		SendButtonWasPressedFirstTime = true;
		State = VisualState.InProgress;
		List<int> list = new List<int>();
		if (FileResults.Count > 0)
		{
			list = await SendPhotos();
			if (list.Count == 0)
			{
				State = VisualState.Default;
				return;
			}
		}
		List<int> list2 = (from word in TriggerWords
			where word.IsSelected
			select word.Id).ToList();
		string text = Comment.Trim();
		bool flag = !string.IsNullOrWhiteSpace(text);
		ReviewCreateRequestDto addReviewRequestDto = new ReviewCreateRequestDto
		{
			GimaId = _parameter.GimaIdInt,
			Channel = Channel.Online,
			Rate = Rating,
			Review = (flag ? text : null),
			Images = list,
			TriggerWordIds = ((list2.Count > 0) ? list2 : null),
			Manufacturer = ((ShowAdditionalProductFields && !string.IsNullOrWhiteSpace(Manufacturer)) ? Manufacturer : null),
			ProductProductionDate = ((!ShowAdditionalProductFields) ? null : ProductProductionDate?.ToString("yyyy-MM-dd")),
			AgreementTime = DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:ss.ffffffZ")
		};
		if ((await _reviewsEcomService.Create(addReviewRequestDto)).IsFailure)
		{
			await _infoMessageService.ShowDialogAsync(ErrorTitle, ErrorReviewSendingMessage, new AlertButton[1]
			{
				new AlertButton
				{
					Title = ErrorCloseButtonText,
					Action = null,
					Type = ActionType.Positive
				}
			});
			State = VisualState.Default;
			return;
		}
		await _infoMessageService.ShowDialogAsync(SuccessSentTitle, SuccessSentMessage, new AlertButton[1]
		{
			new AlertButton
			{
				Title = SuccessSentButtonText,
				Action = delegate
				{
					base.Argument.TaskCompletionSource.TrySetResult(result: true);
					CloseCommand.Trigger();
				},
				Type = ActionType.Positive
			}
		}, isCanceledOnTouchOutside: false, isCanceledOnBack: false);
	}

	public override void Dispose()
	{
		base.Argument.TaskCompletionSource.TrySetResult(result: false);
		base.Dispose();
	}

	private async Task<List<int>> SendPhotos()
	{
		var files = FileResults.Select((FileResult file) => new
		{
			Name = Path.GetFileName(file.FileName),
			StreamTask = file.OpenReadAsync()
		}).ToList();
		List<StreamPart> streamParts = files.Zip(await Task.WhenAll(files.Select(file => file.StreamTask)), (file, Stream stream) => new StreamPart(stream, file.Name, "application/x-binary")).ToList();
		Result<UploadImagesResponseDto, DomainError> result = await _reviewsEcomService.UploadImages(streamParts);
		if (result.IsFailure)
		{
			ShowPhotoUploadError = true;
			RaisePropertyChanged("ShowPhotoUploadError");
			return new List<int>();
		}
		ShowPhotoUploadError = false;
		RaisePropertyChanged("ShowPhotoUploadError");
		return result.Value.Data?.Images?.ToList() ?? new List<int>();
	}

	private int GetTotalPhotoItemCount()
	{
		return FileResults.Count + ImageLoadFailedStubs.Count;
	}

	private void RaisePhotoItemsChanged()
	{
		RaisePropertyChanged("FileResults");
		RaisePropertyChanged("ImageLoadFailedStubs");
		RaisePropertyChanged("HasFileResults");
		RaisePropertyChanged("ShowRemoveAllFileResults");
	}

	private void ReplaceFailedStub()
	{
		while (ImageLoadFailedStubs.Count >= 1)
		{
			ImageLoadFailedStubs.RemoveAt(0);
		}
		ImageLoadFailedStubs.Add(new ImageLoadFailedStubItem());
	}
}
