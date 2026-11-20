using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Banners;
using Auchan.Common.Ecom.Banners.Models;
using Auchan.Common.Extensions;
using Auchan.Common.StoreReview;

namespace Auchan.Common.Profile.SalesAndNews;

public class SalesAndNewsViewModel : ScreenViewModel, ISalesAndNewsSource
{
	public enum VisualState
	{
		Default,
		InProgress,
		ErrorOrEmpty
	}

	private readonly Auchan.Common.StoreReview.StoreReview _storeReview;

	private readonly IBannersRepository _bannersRepository;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CNewOffersCountText_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<Banner> _003CSalesAndNewsList_003Ek__BackingField;

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

	public string Title => "Акции и новости";

	public string ProgressTitle => "Загружаем акции и новости…";

	public string NewOffersCountText
	{
		[CompilerGenerated]
		get
		{
			return _003CNewOffersCountText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CNewOffersCountText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CNewOffersCountText_003Ek__BackingField = value;
				RaisePropertyChanged("NewOffersCountText");
			}
		}
	} = string.Empty;

	public string ErrorOrEmptyDescription => "Для вас сейчас нет доступных акций";

	public bool HasSalesAndNews => SalesAndNewsList.Any();

	public ObservableRangeCollection<Banner> SalesAndNewsList
	{
		[CompilerGenerated]
		get
		{
			return _003CSalesAndNewsList_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSalesAndNewsList_003Ek__BackingField, value))
			{
				_003CSalesAndNewsList_003Ek__BackingField = value;
				RaisePropertyChanged("HasSalesAndNews");
				RaisePropertyChanged("SalesAndNewsList");
			}
		}
	} = new ObservableRangeCollection<Banner>();

	public BannerNavigationSupport BannerNavigationSupport { get; } = new BannerNavigationSupport();

	public SalesAndNewsViewModel(Auchan.Common.StoreReview.StoreReview storeReview, IBannersRepository bannersRepository)
	{
		_storeReview = storeReview;
		_bannersRepository = bannersRepository;
	}

	protected override async Task Start()
	{
		await base.Start();
		_bannersRepository.OnBannersUpdate(delegate(object? o, BannersUpdatedEventArgs e)
		{
			UpdateState(e.Banners);
		}).AddTo(base.CloseDisposable);
		if (!(await _bannersRepository.GetBannersAsync()).TryGetValue(out var value))
		{
			value = _bannersRepository.NoBanners;
		}
		UpdateState(value);
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		_storeReview.RequestReviewIfNeeded().SafeFireAndForget((Action<Exception>)null, false);
	}

	public void OnSalesOrNewsClicked(Banner banner)
	{
		banner.NavigateTo.Activate(BannerNavigationSupport);
	}

	private void UpdateState(IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>> allBanners)
	{
		if (!allBanners.TryGetValue(BannerType.PromotionNews, out IReadOnlyList<Banner> value))
		{
			value = Array.Empty<Banner>();
		}
		SalesAndNewsList.SetState(value);
		State = ((!SalesAndNewsList.Any()) ? VisualState.ErrorOrEmpty : VisualState.Default);
		NewOffersCountText = SalesAndNewsList.Count.ToString();
	}
}
