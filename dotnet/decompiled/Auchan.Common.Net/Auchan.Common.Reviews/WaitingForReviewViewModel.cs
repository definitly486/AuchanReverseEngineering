using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Reviews;

public class WaitingForReviewViewModel : ScreenViewModel
{
	public enum VisualState
	{
		Default,
		InProgress,
		Error
	}

	private readonly ReviewsEcomService _reviewsEcomService;

	private readonly IDataBroker _dataBroker;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

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

	public bool HasProducts => PagedUnreviewedProducts.HasItems;

	public string ScreenTitle => "Товары ожидают отзыва";

	public string ProgressTitle => "Загружаем ваши отзывы…";

	public string AllButtonTitle => "Все";

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

	public PagedDataLoader<UnreviewedProductItemViewModel> PagedUnreviewedProducts { get; }

	public UICommand<BrokerToken> AddReviewCommand { get; } = new UICommand<BrokerToken>();

	public WaitingForReviewViewModel(ReviewsEcomService reviewsEcomService, IDataBroker dataBroker)
	{
		_reviewsEcomService = reviewsEcomService;
		_dataBroker = dataBroker;
		PagedUnreviewedProducts = new PagedDataLoader<UnreviewedProductItemViewModel>(async (int offset, int limit) => await _reviewsEcomService.GetUnreviewedProductsAsync(offset, limit));
	}

	public async void OnProductClick(UnreviewedProductItemViewModel product)
	{
		AddReviewViewModel.Parameter parameter = new AddReviewViewModel.Parameter(product.Title, product.GimaId, product.ImageUrl);
		AddReviewCommand.Trigger(_dataBroker.Push(parameter));
		if (await parameter.WaitForResultAsync())
		{
			LoadProductsAsync(reload: true).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public async void OnProductDelete(UnreviewedProductItemViewModel product)
	{
		PagedUnreviewedProducts.Remove(product);
		await _reviewsEcomService.HideProductFromUnreviewed(product.GimaId);
		await LoadProductsAsync(reload: true);
	}

	protected override async Task Start()
	{
		await base.Start();
		await LoadProductsAsync(reload: false);
	}

	public void Retry()
	{
		LoadProductsAsync(reload: false).SafeFireAndForget((Action<Exception>)null, false);
	}

	public async Task LoadProductsAsync(bool reload)
	{
		State = VisualState.InProgress;
		Result<(IReadOnlyList<UnreviewedProductItemViewModel>, int), DomainError> result = await (reload ? PagedUnreviewedProducts.Reload() : PagedUnreviewedProducts.LoadFirst());
		if (result.IsSuccess)
		{
			State = VisualState.Default;
		}
		else
		{
			ErrorTitle = ((result.Error is ConnectionError) ? "Нет соединения с интернетом" : "Упс! Что-то пошло не так.");
			ErrorMessage = ((result.Error is ConnectionError) ? "Проверьте интернет-соединение и повторите попытку" : "Небольшие технические проблемы,\nпопробуйте обновить экран.");
			State = VisualState.Error;
		}
		RaisePropertyChanged("HasProducts");
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
	}
}
