using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Recommendations.Models;
using Auchan.Common.Reviews;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Recommendations.ViewModels;

public sealed class RecommendationsViewModel : ElementViewModel
{
	private const string Tag = "RecommendationsViewModel";

	private const int PreviewCount = 10;

	private readonly IDataBroker _dataBroker;

	private readonly IRecommendationsRepository _recommendationsRepository;

	private readonly RecommendationsTrackingRepository _recommendationsTrackingRepository;

	private readonly Func<ProductWithAnalyticsInfo, ICollection<IDisposable>, RecomProductItemViewModel> _viewModelFactory;

	private readonly IRecommendationsManager _recommendationsManager;

	private readonly Subject<ProductDetailsViewModel.Parameter> _navigateSubject = new Subject<ProductDetailsViewModel.Parameter>();

	private readonly CompositeDisposable _reloadDisposables = new CompositeDisposable();

	private ScreenViewModel? _viewModel;

	private LoadRequest? _loadRequest;

	private int _loadRequestId;

	private bool _isDisposed;

	[CompilerGenerated]
	private UICommand<ProductItemViewModel> _003CShowQtyDialogCommand_003Ek__BackingField;

	public ObservableRangeCollection<SectionItemViewModel> Sections { get; }

	public bool HasItems => Sections.Count > 0;

	public UICommand<BrokerToken> ShowAllCommand { get; } = new UICommand<BrokerToken>();

	public IObservable<ProductDetailsViewModel.Parameter> NavigateToProductCommand => _navigateSubject.Debounce();

	public UICommand<ProductReviewsViewModel.Parameter> OpenReviewsCommand { get; } = new UICommand<ProductReviewsViewModel.Parameter>();

	public UICommand<ProductItemViewModel> ShowQtyDialogCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CShowQtyDialogCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CShowQtyDialogCommand_003Ek__BackingField, value))
			{
				_003CShowQtyDialogCommand_003Ek__BackingField = value;
				RaisePropertyChanged("ShowQtyDialogCommand");
			}
		}
	} = new UICommand<ProductItemViewModel>();

	public RecommendationsViewModel(IDataBroker dataBroker, Func<ProductWithAnalyticsInfo, ICollection<IDisposable>, RecomProductItemViewModel> viewModelFactory, IRecommendationsManager recommendationsManager, IRecommendationsRepository recommendationsRepository, RecommendationsTrackingRepository recommendationsTrackingRepository)
	{
		_dataBroker = dataBroker;
		_viewModelFactory = viewModelFactory;
		_recommendationsManager = recommendationsManager;
		Sections = new ObservableRangeCollection<SectionItemViewModel>();
		_recommendationsRepository = recommendationsRepository;
		_recommendationsTrackingRepository = recommendationsTrackingRepository;
	}

	internal RecommendationsViewModel Setup(ICollection<IDisposable> closeDisposables, ScreenViewModel viewModel)
	{
		_viewModel = viewModel;
		closeDisposables.Add(_reloadDisposables);
		closeDisposables.Add(Disposable.Create(delegate
		{
			_isDisposed = true;
		}));
		return this;
	}

	internal async Task Load(LoadRequest loadRequest)
	{
		if (!MainThread.IsMainThread)
		{
			throw new InvalidOperationException("should be called from main thread");
		}
		if (loadRequest == null)
		{
			throw new ArgumentNullException("loadRequest");
		}
		int rid = Interlocked.Increment(ref _loadRequestId);
		_loadRequest = loadRequest;
		_recommendationsManager.SaveCurrentRecommendations(this, _viewModel);
		RecommendationSection[] sections = loadRequest.Sections;
		bool showShevronButton = loadRequest.ShowShevronButton;
		if (sections.Length == 0)
		{
			throw new ArgumentException("Load request can not be empty");
		}
		CompositeDisposable disposables = new CompositeDisposable();
		IReadOnlyList<SectionItemViewModel> collection = await LoadSections((IReadOnlyCollection<RecommendationSection>)(object)sections, disposables, showShevronButton);
		if (rid == _loadRequestId)
		{
			_reloadDisposables.Clear();
			if (_isDisposed)
			{
				disposables.Clear();
				return;
			}
			Sections.ReplaceRange(collection);
			_reloadDisposables.Add(disposables);
			RaisePropertyChanged("HasItems");
		}
	}

	public Task Reload()
	{
		if (_loadRequest == null)
		{
			throw new InvalidOperationException("LoadRequest is not set. Please call Load first");
		}
		return Load(_loadRequest);
	}

	private async Task<IReadOnlyList<SectionItemViewModel>> LoadSections(IReadOnlyCollection<RecommendationSection> requests, ICollection<IDisposable> disposables, bool showShevronButton)
	{
		return (await Task.Run(() => Task.WhenAll(requests.Select(async (RecommendationSection i) => ((RecommendationSection request, Result<(IAlgorithm From, IReadOnlyList<ProductWithAnalyticsInfo> Products), DomainError> result))(request: i, result: await _recommendationsRepository.GetFirstAvailableAsync(i.Algorithms)))))).Where(((RecommendationSection request, Result<(IAlgorithm From, IReadOnlyList<ProductWithAnalyticsInfo> Products), DomainError> result) i) => i.result.IsSuccess && i.result.Value.Products.Any()).Select(delegate((RecommendationSection request, Result<(IAlgorithm From, IReadOnlyList<ProductWithAnalyticsInfo> Products), DomainError> result) i)
		{
			Result<(IAlgorithm, IReadOnlyList<ProductWithAnalyticsInfo>), DomainError> item = i.result;
			(IAlgorithm, IReadOnlyList<ProductWithAnalyticsInfo>) value = item.Value;
			IAlgorithm item2 = value.Item1;
			IReadOnlyList<ProductWithAnalyticsInfo> item3 = value.Item2;
			bool isNeedToShowAllProducts = item2.IsNeedToShowAllProducts;
			ObservableRangeCollection<RecomProductItemViewModel> preview = (from x in item3.Take(isNeedToShowAllProducts ? item3.Count : 10)
				select _viewModelFactory(x, disposables)).ToObservableRangeCollection();
			return new SectionItemViewModel
			{
				Parent = this,
				Title = item2.Title,
				Id = (item3.FirstOrDefault()?.Analytics.BlockId ?? ""),
				Products = item3.ToImmutableList(),
				Preview = preview,
				ShowAllButton = (!isNeedToShowAllProducts && item3.Count > 10),
				ShowShevronButton = showShevronButton,
				HasCategories = (item2.Name == "NoveltyAlgorithm")
			};
		}).ToImmutableList();
	}

	public void Viewed(SectionItemViewModel viewModel)
	{
		viewModel.Preview.FirstOrDefault()?.RecomAnalyticActions.BlockViewed(viewModel.Id);
	}

	public void Clicked(SectionItemViewModel block, RecomProductItemViewModel? itemViewModel)
	{
		if (itemViewModel != null)
		{
			itemViewModel.RecomAnalyticActions.OnNavigateToProductDetails(itemViewModel);
			_navigateSubject.OnNext(new ProductDetailsViewModel.Parameter(itemViewModel.Product.Code));
		}
	}

	public void AddedToCart(RecomProductItemViewModel itemViewModel)
	{
		_recommendationsTrackingRepository.AddedToCart(itemViewModel);
	}

	public void ShowAll(SectionItemViewModel block)
	{
		ShowAllCommand.Trigger(_dataBroker.Push(new StaticProductListViewModel.Parameter
		{
			Title = block.Title,
			Items = block.Products,
			HasCategories = block.HasCategories
		}));
	}

	public async Task Clear()
	{
		await MainThread.InvokeOnMainThreadAsync(delegate
		{
			_reloadDisposables.Clear();
			Sections.Clear();
			RaisePropertyChanged("HasItems");
		});
	}
}
