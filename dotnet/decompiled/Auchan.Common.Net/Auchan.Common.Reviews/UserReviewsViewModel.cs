using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Banners;
using Auchan.Common.Ecom.Banners.Models;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.Reviews.Model;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Reviews;

public class UserReviewsViewModel : ScreenViewModel
{
	public enum VisualState
	{
		Default,
		InProgress,
		Error
	}

	private readonly ReviewsEcomService _reviewsEcomService;

	private readonly WaitingForReviewViewModel _waitingForReviewViewModel;

	private readonly IDataBroker _dataBroker;

	private readonly IUserContext _userContext;

	private readonly IBannersRepository _bannersRepository;

	[CompilerGenerated]
	private Banner? _003CBanner_003Ek__BackingField;

	[CompilerGenerated]
	private PagedDataLoader<UserReviewItemViewModel> _003CPagedReviews_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	public bool IsAuthorized => _userContext.Authorized;

	public Banner? Banner
	{
		[CompilerGenerated]
		get
		{
			return _003CBanner_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CBanner_003Ek__BackingField, value))
			{
				_003CBanner_003Ek__BackingField = value;
				RaisePropertyChanged("Banner");
			}
		}
	}

	public WaitingForReviewViewModel WaitingForReviewViewModel => _waitingForReviewViewModel;

	public PagedDataLoader<UserReviewItemViewModel> PagedReviews
	{
		[CompilerGenerated]
		get
		{
			return _003CPagedReviews_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CPagedReviews_003Ek__BackingField, value))
			{
				_003CPagedReviews_003Ek__BackingField = value;
				RaisePropertyChanged("HasReviews");
				RaisePropertyChanged("PagedReviews");
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
	} = VisualState.InProgress;

	public UICommand<ReviewDetailsViewModel.Parameter> OpenReviewDetailsCommand { get; } = new UICommand<ReviewDetailsViewModel.Parameter>();

	public UICommand OpenUnreviewedProductsCommand { get; } = new UICommand();

	public UICommand<InfoPageViewModel.Parameter> OpenReviewRulesCommand { get; } = new UICommand<InfoPageViewModel.Parameter>();

	public UICommand<BrokerToken> AddReviewCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<OpenThumbnailRequest> OpenThumbnailCommand { get; } = new UICommand<OpenThumbnailRequest>();

	public string Title => "Мои отзывы";

	public string ProgressTitle => "Загружаем ваши отзывы…";

	public string ReviewHistoryLabel => "История отзывов";

	public string NoReviewsTitle => "Здесь будут ваши отзывы";

	public string NoReviewsSubtitle => "Пока вы не совершали покупок товаров, к которым можно оставить отзыв";

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
	} = "Упс! Что-то пошло не так.";

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
	} = "Небольшие технические проблемы,\nпопробуйте обновить экран.";

	public bool HasReviews => PagedReviews.HasItems;

	public UICommand BannerCommand { get; } = new UICommand();

	public BannerNavigationSupport BannerNavigationSupport { get; } = new BannerNavigationSupport();

	public LinkedText RulesText => new LinkedText("Мы публикуем отзывы, соответствующие нашим правилам.", new string[1] { "правилам" }, new Action[1] { ReviewRulesTapped });

	public UserReviewsViewModel(ReviewsEcomService reviewsEcomService, WaitingForReviewViewModel waitingForReviewViewModel, IDataBroker dataBroker, IUserContext userContext, IBannersRepository bannersRepository)
	{
		_reviewsEcomService = reviewsEcomService;
		_waitingForReviewViewModel = waitingForReviewViewModel;
		_dataBroker = dataBroker;
		_userContext = userContext;
		_bannersRepository = bannersRepository;
		PagedReviews = new PagedDataLoader<UserReviewItemViewModel>(GetReviewsAsync);
	}

	public void OpenUnreviewedProducts()
	{
		AppAnalytics.AppMetrica.TrackEvent("TapMainOnReviewProductsAll");
		OpenUnreviewedProductsCommand.Trigger();
	}

	protected override async Task Start()
	{
		await base.Start();
		State = VisualState.InProgress;
		BannerCommand.Subscribe(delegate
		{
			OnBannerCommand();
		}).AddTo(base.CloseDisposable);
		if ((await _bannersRepository.GetBannersAsync()).TryGetValue(out var value) && value.TryGetValue(BannerType.UserReviews, out var value2))
		{
			Banner = value2.FirstOrDefault();
		}
		State = VisualState.Default;
		await LoadProductsAndReviewsAsync(reload: false);
	}

	private async Task LoadProductsAndReviewsAsync(bool reload)
	{
		State = VisualState.InProgress;
		Task<Result<(IReadOnlyList<UserReviewItemViewModel>, int), DomainError>> reviewsTask = LoadUserReviewsAsync(reload);
		InlineArray2<Task> buffer = default(InlineArray2<Task>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<InlineArray2<Task>, Task>(ref buffer, 0) = WaitingForReviewViewModel.LoadProductsAsync(reload);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<InlineArray2<Task>, Task>(ref buffer, 1) = reviewsTask;
		await Task.WhenAll(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<InlineArray2<Task>, Task>(in buffer, 2));
		Result<(IReadOnlyList<UserReviewItemViewModel>, int), DomainError> result = reviewsTask.Result;
		if (result.IsSuccess)
		{
			State = VisualState.Default;
			return;
		}
		ErrorTitle = ((result.Error is ConnectionError) ? "Нет соединения с интернетом" : "Упс! Что-то пошло не так.");
		ErrorMessage = ((result.Error is ConnectionError) ? "Проверьте интернет-соединение и повторите попытку" : "Небольшие технические проблемы,\nпопробуйте обновить экран.");
		State = VisualState.Error;
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		if (PagedReviews.HasItems)
		{
			PagedReviews.Reload().SafeFireAndForget((Action<Exception>)null, false);
		}
		if (WaitingForReviewViewModel.PagedUnreviewedProducts.HasItems)
		{
			WaitingForReviewViewModel.PagedUnreviewedProducts.Reload().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public void Retry()
	{
		LoadProductsAndReviewsAsync(reload: false).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void ReviewRulesTapped()
	{
		OpenReviewRulesCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.ReviewingRules));
	}

	public async void OnProductClick(UnreviewedProductItemViewModel product)
	{
		AppAnalytics.AppMetrica.TrackEvent("TapReviewFormProfile");
		AddReviewViewModel.Parameter parameter = new AddReviewViewModel.Parameter(product.Title, product.GimaId, product.ImageUrl);
		AddReviewCommand.Trigger(_dataBroker.Push(parameter));
		if (await parameter.WaitForResultAsync())
		{
			LoadProductsAndReviewsAsync(reload: true).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private Task<Result<(IReadOnlyList<UserReviewItemViewModel>, int), DomainError>> LoadUserReviewsAsync(bool reload)
	{
		if (!reload)
		{
			return PagedReviews.LoadFirst();
		}
		return PagedReviews.Reload();
	}

	private void OnBannerCommand()
	{
		Banner?.NavigateTo.Activate(BannerNavigationSupport);
	}

	private async Task<Result<(IReadOnlyList<UserReviewItemViewModel>, int), DomainError>> GetReviewsAsync(int offset, int limit)
	{
		Result<(IReadOnlyList<Review>, int), DomainError> result = await _reviewsEcomService.GetUserReviewsAsync(offset, limit);
		if (result.TryGetValue(out var value))
		{
			var (source, item) = value;
			return (source.Select((Review i) => new UserReviewItemViewModel
			{
				Review = i,
				Parent = this
			}).ToImmutableList(), item);
		}
		return result.Error;
	}
}
