using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Controls.AutoLayout;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Recommendations.Models;
using Auchan.Common.Recommendations.ViewModels;
using Auchan.Common.Reviews;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Recommendations;

public sealed class EndlessRecommendationsViewModel : INotifyPropertyChanged
{
	private enum BlockOrder
	{
		RecomTitle = 1000,
		Products = 1001,
		Stubs = 2000,
		LoadMoreButton = 3000
	}

	public const int StubCount = 3;

	public const int ProductsPerPage = 25;

	private readonly IInfoMessageService _messageService;

	private readonly Lazy<IRecommendationAnalyticsActionsFactory> _actionsFactory;

	private readonly IRecommendationsRepository _recommendationsRepository;

	private readonly Func<ProductWithAnalyticsInfo, ICollection<IDisposable>, RecomProductItemViewModel> _viewModelFactory;

	private ICollection<IDisposable>? _closeDisposables;

	private AutoLayoutViewModel? _autoLayoutViewModel;

	private ScreenViewModel? _viewModel;

	private SemaphoreSlim _loadingSemaphore = new SemaphoreSlim(1);

	private LoadRequest? _loadRequest;

	private string _titleText = string.Empty;

	private string? _blockIdLoadedFrom;

	private IRecommendationAnalyticsActions? _analyticsActions;

	public UICommand<ProductDetailsViewModel.Parameter> NavigateToProductCommand { get; } = new UICommand<ProductDetailsViewModel.Parameter>();

	public UICommand<RecomProductItemViewModel> ProductClickCommand { get; } = new UICommand<RecomProductItemViewModel>();

	public UICommand<ProductReviewsViewModel.Parameter> OpenReviewsCommand { get; } = new UICommand<ProductReviewsViewModel.Parameter>();

	public UICommand<ProductItemViewModel> ShowQtyDialogCommand { get; } = new UICommand<ProductItemViewModel>();

	public UICommand<bool> LoadMoreCommand { get; } = new UICommand<bool>();

	public UICommand ReloadCommand { get; } = new UICommand();

	public string LoadMoreText { get; } = "Загрузить еще";

	public event PropertyChangedEventHandler? PropertyChanged;

	public EndlessRecommendationsViewModel(IInfoMessageService messageService, Lazy<IRecommendationAnalyticsActionsFactory> actionsFactory, Func<ProductWithAnalyticsInfo, ICollection<IDisposable>, RecomProductItemViewModel> viewModelFactory, IRecommendationsRepository recommendationsRepository)
	{
		_messageService = messageService;
		_actionsFactory = actionsFactory;
		_viewModelFactory = viewModelFactory;
		_recommendationsRepository = recommendationsRepository;
	}

	internal EndlessRecommendationsViewModel Setup(ICollection<IDisposable> closeDisposables, ScreenViewModel viewModel, AutoLayoutViewModel autoLayout)
	{
		_closeDisposables = closeDisposables;
		_viewModel = viewModel;
		_autoLayoutViewModel = autoLayout;
		LoadMoreCommand.PerformDebouncingTask(LoadMore).Subscribe().AddTo(_closeDisposables);
		ReloadCommand.PerformDebouncingTask((Unit _) => Load(_loadRequest)).Subscribe().AddTo(_closeDisposables);
		ProductClickCommand.Subscribe(delegate(RecomProductItemViewModel ivm)
		{
			NavigateToProductCommand.Trigger(new ProductDetailsViewModel.Parameter(ivm.Product));
			ivm.RecomAnalyticActions.OnNavigateToProductDetails(ivm);
		}).AddTo(_closeDisposables);
		return this;
	}

	internal async Task Load(LoadRequest? loadRequest)
	{
		ClearItems();
		if (loadRequest == null || loadRequest.Sections.Length > 1 || !(loadRequest.Sections.FirstOrDefault()?.Algorithms.FirstOrDefault() is IAbstractEndlessAlgorithm))
		{
			throw new ArgumentException("Incorrect load request for endless recommendations");
		}
		_loadRequest = loadRequest;
		RecommendationSection sectionRequest = _loadRequest.Sections.First();
		_ = _loadRequest.ShowShevronButton;
		await _loadingSemaphore.WaitAsync();
		try
		{
			ClearItems();
			await LoadSection(sectionRequest);
		}
		catch
		{
			throw;
		}
		finally
		{
			_loadingSemaphore.Release();
		}
	}

	internal async Task LoadMore(bool force)
	{
		if (_loadRequest == null)
		{
			return;
		}
		RecommendationSection sectionRequest = _loadRequest.Sections.First();
		await _loadingSemaphore.WaitAsync();
		try
		{
			IAlgorithm algorithm = sectionRequest.Algorithms.FirstOrDefault();
			if (!(algorithm is IAbstractEndlessAlgorithm endlessAlg))
			{
				throw new ArgumentException("Non-endless algorithm is used with EndlessRecommendationsViewModel");
			}
			if (endlessAlg.LoadedAll || (endlessAlg.LoadingFailed && !force))
			{
				return;
			}
			AddStubItems();
			ImmutableArray<string> immutableArray = _autoLayoutViewModel.Elements.Where((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "RecommendationProduct").SelectNotNull((AutoLayoutViewModel.AutoLayoutElement e) => e.Data as RecomProductItemViewModel).SelectNotNull((RecomProductItemViewModel p) => p.Product.GimaId)
				.ToImmutableArray();
			Result<IReadOnlyList<ProductWithAnalyticsInfo>, DomainError> result = await _recommendationsRepository.GetMore(endlessAlg, immutableArray);
			if (result.IsFailure)
			{
				ReplaceStubItemsWithLoadMore();
				endlessAlg.LoadingFailed = true;
				_messageService.ShowSnackbar("Не удалось загрузить товары");
				return;
			}
			endlessAlg.LoadingFailed = false;
			if (result.IsSuccess && result.Value.IsNullOrEmpty())
			{
				ReplaceStubItems();
				endlessAlg.TrySetLoadedAll();
				return;
			}
			IEnumerable<AutoLayoutViewModel.AutoLayoutElement> source = from x in result.Value
				select _viewModelFactory(x, _closeDisposables) into x
				select AutoLayoutViewModel.AutoLayoutElement.New("RecommendationProduct", x, BlockOrder.Products);
			ReplaceStubItems(source.ToArray());
		}
		catch
		{
			throw;
		}
		finally
		{
			_loadingSemaphore.Release();
		}
	}

	public void Viewed()
	{
		if (_blockIdLoadedFrom != null && _analyticsActions != null)
		{
			_analyticsActions.BlockViewed(_blockIdLoadedFrom);
		}
	}

	private async Task LoadSection(RecommendationSection request)
	{
		IAlgorithm algorithm = request.Algorithms.FirstOrDefault();
		if (!(algorithm is IAbstractEndlessAlgorithm endlessAlg))
		{
			throw new ArgumentException("Non-endless algorithm is used with EndlessRecommendationsViewModel");
		}
		endlessAlg.LoadingFailed = false;
		Result<(IAlgorithm, IReadOnlyList<ProductWithAnalyticsInfo>), DomainError> result = await _recommendationsRepository.GetFirstAvailableAsync(request.Algorithms);
		if (result.IsFailure)
		{
			endlessAlg.LoadingFailed = true;
			return;
		}
		(IAlgorithm, IReadOnlyList<ProductWithAnalyticsInfo>) value = result.Value;
		IAlgorithm item = value.Item1;
		IReadOnlyList<ProductWithAnalyticsInfo> item2 = value.Item2;
		_titleText = item.Title;
		if (item2.Count == 0)
		{
			endlessAlg.TrySetLoadedAll();
			return;
		}
		if (_blockIdLoadedFrom == null)
		{
			ProductWithAnalyticsInfo productWithAnalyticsInfo = item2.FirstOrDefault();
			if (productWithAnalyticsInfo != null)
			{
				_blockIdLoadedFrom = productWithAnalyticsInfo.Analytics.BlockId;
				_analyticsActions = _actionsFactory.Value.Get(productWithAnalyticsInfo.Analytics.ActionsTag);
			}
		}
		IEnumerable<AutoLayoutViewModel.AutoLayoutElement> source = from x in item2.Take(item2.Count)
			select _viewModelFactory(x, _closeDisposables) into x
			select AutoLayoutViewModel.AutoLayoutElement.New("RecommendationProduct", x, BlockOrder.Products);
		AddFirstItems(source.ToArray());
	}

	public void ClearItems()
	{
		_autoLayoutViewModel.Elements.RemoveAll((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "RecommendationTitle" || e.Type == "RecommendationProduct" || e.Type == "RecommendationProductStub" || e.Type == "RecommendationLoadMoreButton");
	}

	private void AddStubItems()
	{
		List<AutoLayoutViewModel.AutoLayoutElement> list = new List<AutoLayoutViewModel.AutoLayoutElement>();
		for (int i = 0; i < 3; i++)
		{
			list.Add(new AutoLayoutViewModel.AutoLayoutElement("RecommendationProductStub", new object(), 2000 + i));
		}
		AutoLayoutViewModel.AutoLayoutElement autoLayoutElement = _autoLayoutViewModel.Elements.FirstOrDefault((AutoLayoutViewModel.AutoLayoutElement x) => x.Type == "RecommendationLoadMoreButton");
		if (autoLayoutElement != null)
		{
			_autoLayoutViewModel.Elements.ReplaceRange(_autoLayoutViewModel.Elements.IndexOf(autoLayoutElement), 1, list);
		}
		else
		{
			_autoLayoutViewModel.Elements.AddRange(list);
		}
	}

	private void ReplaceStubItems(params AutoLayoutViewModel.AutoLayoutElement[] elements)
	{
		AutoLayoutViewModel.AutoLayoutElement autoLayoutElement = _autoLayoutViewModel.Elements.FirstOrDefault((AutoLayoutViewModel.AutoLayoutElement x) => x.Type == "RecommendationProductStub");
		if (autoLayoutElement != null)
		{
			_autoLayoutViewModel.Elements.ReplaceRange(_autoLayoutViewModel.Elements.IndexOf(autoLayoutElement), 3, elements);
		}
		else
		{
			_autoLayoutViewModel.Elements.AddRange(elements);
		}
	}

	private void ReplaceStubItemsWithLoadMore()
	{
		AutoLayoutViewModel.AutoLayoutElement autoLayoutElement = AutoLayoutViewModel.AutoLayoutElement.New("RecommendationLoadMoreButton", new object(), BlockOrder.LoadMoreButton);
		ReplaceStubItems(autoLayoutElement);
	}

	private void AddFirstItems(AutoLayoutViewModel.AutoLayoutElement[] elements)
	{
		ReplaceStubItems(elements.Prepend(AutoLayoutViewModel.AutoLayoutElement.New("RecommendationTitle", _titleText, BlockOrder.RecomTitle)).ToArray());
	}

	[GeneratedCode("PropertyChanged.Fody", "4.1.0.0")]
	[DebuggerNonUserCode]
	private void _003C_003EOnPropertyChanged(PropertyChangedEventArgs eventArgs)
	{
		this.PropertyChanged?.Invoke(this, eventArgs);
	}
}
