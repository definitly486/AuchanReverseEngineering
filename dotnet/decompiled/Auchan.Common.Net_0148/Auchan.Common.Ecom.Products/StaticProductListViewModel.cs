using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Profile;
using Auchan.Common.Recommendations;
using Auchan.Common.Recommendations.Models;
using Auchan.Common.Recommendations.ViewModels;
using Auchan.Common.Reviews;

namespace Auchan.Common.Ecom.Products;

public class StaticProductListViewModel : ScreenViewModel<StaticProductListViewModel.Parameter>, IYandexMetricaScreenViewModel, IScreenViewModel
{
	public class Parameter : BrokeredParameter
	{
		public required string Title { get; init; }

		public required IReadOnlyList<ProductWithAnalyticsInfo> Items { get; init; }

		public bool HasCategories { get; init; }
	}

	private readonly Func<ProductWithAnalyticsInfo, ICollection<IDisposable>, RecomProductItemViewModel> _recomFactory;

	private const string AllCategories = "Все";

	private IReadOnlyCollection<RecomProductItemViewModel> _products = (IReadOnlyCollection<RecomProductItemViewModel>)(object)Array.Empty<RecomProductItemViewModel>();

	private readonly IRecommendationAnalyticsActionsFactory _actionFactory;

	[CompilerGenerated]
	private string _003CTitle_003Ek__BackingField;

	public readonly ObservableRangeCollection<RecomProductItemViewModel> Products = new ObservableRangeCollection<RecomProductItemViewModel>();

	[CompilerGenerated]
	private string _003CTotalCount_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CCategorySelected_003Ek__BackingField;

	public string Title
	{
		[CompilerGenerated]
		get
		{
			return _003CTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTitle_003Ek__BackingField = value;
				RaisePropertyChanged("Title");
			}
		}
	}

	public ObservableRangeCollection<CategoryItemViewModel> CategoryItemViewModels { get; } = new ObservableRangeCollection<CategoryItemViewModel>();

	public bool CategoriesVisible => CategoryItemViewModels.Any();

	public string TotalCount
	{
		[CompilerGenerated]
		get
		{
			return _003CTotalCount_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CTotalCount_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTotalCount_003Ek__BackingField = value;
				RaisePropertyChanged("TotalCount");
			}
		}
	}

	public UICommand<ProductDetailsViewModel.Parameter> NavigateToProductCommand { get; } = new UICommand<ProductDetailsViewModel.Parameter>();

	public UICommand<ProductItemViewModel> ShowQtyDialogCommand { get; } = new UICommand<ProductItemViewModel>();

	public UICommand<ProductReviewsViewModel.Parameter> OpenReviewsCommand { get; } = new UICommand<ProductReviewsViewModel.Parameter>();

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "Сollections_" + base.Argument.Title;

	string IYandexMetricaScreenViewModel.ScreenName => "Сollections_" + base.Argument.Title;

	public UICommand<int> SelectCategoryCommand { get; } = new UICommand<int>();

	public bool CategorySelected
	{
		[CompilerGenerated]
		get
		{
			return _003CCategorySelected_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CCategorySelected_003Ek__BackingField != value)
			{
				_003CCategorySelected_003Ek__BackingField = value;
				RaisePropertyChanged("CategorySelected");
			}
		}
	}

	public StaticProductListViewModel(BrokerToken token, IRecommendationAnalyticsActionsFactory actionFactory, Func<ProductWithAnalyticsInfo, ICollection<IDisposable>, RecomProductItemViewModel> recomFactory)
		: base(token)
	{
		_actionFactory = actionFactory;
		_recomFactory = recomFactory;
		Title = base.Argument.Title;
		TotalCount = string.Empty;
	}

	protected override async Task Start()
	{
		await base.Start();
		IReadOnlyList<ProductWithAnalyticsInfo> items = base.Argument.Items;
		ProductWithAnalyticsInfo productWithAnalyticsInfo = items.FirstOrDefault();
		if (!string.IsNullOrWhiteSpace(productWithAnalyticsInfo?.Analytics.BlockId))
		{
			_actionFactory.Get(productWithAnalyticsInfo).BlockViewed(productWithAnalyticsInfo.Analytics.BlockId);
		}
		IEnumerable<RecomProductItemViewModel> source = items.Select((ProductWithAnalyticsInfo p) => _recomFactory(p, base.CloseDisposable));
		_products = source.ToList();
		TotalCount = _products.Count.ToString();
		Products.ReplaceRange(_products);
		if (base.Argument.HasCategories)
		{
			CreateCategories();
		}
	}

	public void NavigateToDetails(ProductItemViewModel itemViewModel)
	{
		itemViewModel.RecomAnalyticActions.OnNavigateToProductDetails(itemViewModel);
		ProductDetailsViewModel.Parameter subject = new ProductDetailsViewModel.Parameter(itemViewModel.Product);
		NavigateToProductCommand.Trigger(subject);
	}

	private void CreateCategories()
	{
		List<string> list = (from x in _products
			select x.Product.CategoryCodes?.FirstOrDefault()?.Name ?? string.Empty into categoryName
			where !string.IsNullOrWhiteSpace(categoryName)
			select categoryName).Distinct().ToList();
		if (list.Count > 0)
		{
			CategoryItemViewModels.Add(new CategoryItemViewModel("Все"));
			CategoryItemViewModels.AddRange(list.Select((string x) => new CategoryItemViewModel(x)));
			CategoryItemViewModels.First().Selected = true;
		}
	}

	public void OnCategorySelected(CategoryItemViewModel selectedCategoryItemViewModel)
	{
		if (CategorySelected)
		{
			return;
		}
		CategorySelected = true;
		CategoryItemViewModel selectedCategory;
		if (selectedCategoryItemViewModel.Selected && selectedCategoryItemViewModel.Title != "Все")
		{
			selectedCategoryItemViewModel.Selected = false;
			selectedCategory = CategoryItemViewModels.First();
			SelectCategoryCommand.Trigger(0);
		}
		else
		{
			if (selectedCategoryItemViewModel != null && selectedCategoryItemViewModel.Selected && selectedCategoryItemViewModel.Title == "Все")
			{
				return;
			}
			CategoryItemViewModels.ForEach(delegate(CategoryItemViewModel x)
			{
				x.Selected = false;
			});
			selectedCategory = CategoryItemViewModels.First((CategoryItemViewModel categoryItemViewModel) => categoryItemViewModel.Title == selectedCategoryItemViewModel.Title);
			int subject = CategoryItemViewModels.IndexOf(selectedCategory);
			SelectCategoryCommand.Trigger(subject);
		}
		selectedCategory.Selected = true;
		List<RecomProductItemViewModel> list = _products.Where((RecomProductItemViewModel x) => x.Product.CategoryCodes?.FirstOrDefault()?.Name == selectedCategory.Title).ToList();
		ObservableRangeCollection<RecomProductItemViewModel> products = Products;
		IReadOnlyCollection<RecomProductItemViewModel> collection;
		if (!(selectedCategory.Title == "Все"))
		{
			IReadOnlyCollection<RecomProductItemViewModel> readOnlyCollection = list;
			collection = readOnlyCollection;
		}
		else
		{
			collection = _products;
		}
		products.ReplaceRange(collection);
	}
}
