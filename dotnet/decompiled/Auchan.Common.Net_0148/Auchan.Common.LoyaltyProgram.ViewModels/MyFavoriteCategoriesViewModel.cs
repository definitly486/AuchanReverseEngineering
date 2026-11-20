using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Home;
using Auchan.Common.LoyaltyProgramLoymax.Dtos;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.ViewModels;

public class MyFavoriteCategoriesViewModel(Parameter parameter, IDataBroker dataBroker) : ScreenViewModel()
{
	public class Parameter
	{
		public string DescriptionTitle { get; }

		public string Description { get; }

		public string DetailDescription { get; }

		public int MaxCount { get; set; }

		public bool Accepted { get; }

		public IReadOnlyList<FavoriteCategoryItemViewModel> Categories { get; }

		[JsonConstructor]
		public Parameter(string descriptionTitle, string description, string detailDescription, IReadOnlyList<FavoriteCategoryItemViewModel> categories, int maxCount, bool accepted)
		{
			DescriptionTitle = descriptionTitle;
			Description = description;
			DetailDescription = detailDescription;
			Categories = categories;
			MaxCount = maxCount;
			Accepted = accepted;
		}

		public Parameter(FavoriteCategoriesData data)
		{
			DescriptionTitle = data.DescriptionTitle;
			Description = data.Description;
			DetailDescription = data.DetailDescription;
			Categories = data.Categories.Select((FavoriteCategory category) => new FavoriteCategoryItemViewModel
			{
				Id = category.CategoryId,
				Code = category.Code,
				Description = category.Description,
				Name = category.Name,
				Image = category.MobileImageUrl,
				PreferenceType = category.PreferenceType,
				PreferenceValue = category.PreferenceValue
			}).ToImmutableList();
			MaxCount = data.MaxCount;
			Accepted = data.Accepted;
		}
	}

	[CompilerGenerated]
	private string _003CDetailDescription_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CMaxCount_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CCategoriesSelected_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	public string Title => "Мои категории";

	public string DescriptionTitle => parameter.DescriptionTitle;

	public string Description => parameter.Description.Replace(" <br/> ", "\n");

	public IReadOnlyList<FavoriteCategoryItemViewModel> Categories => parameter.Categories;

	public LinkedText Link => new LinkedText("Подробнее", "Подробнее", OpenMoreDetails);

	public string ButtonText
	{
		get
		{
			if (!Accepted)
			{
				return "Выбрать";
			}
			return "К покупкам";
		}
	}

	public string DetailDescription
	{
		[CompilerGenerated]
		get
		{
			return _003CDetailDescription_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CDetailDescription_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CDetailDescription_003Ek__BackingField = value;
				RaisePropertyChanged("Link");
				RaisePropertyChanged("DetailsAvailable");
				RaisePropertyChanged("DetailDescription");
			}
		}
	} = parameter.DetailDescription;

	public int MaxCount
	{
		[CompilerGenerated]
		get
		{
			return _003CMaxCount_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CMaxCount_003Ek__BackingField != value)
			{
				_003CMaxCount_003Ek__BackingField = value;
				RaisePropertyChanged("MaxCount");
			}
		}
	} = parameter.MaxCount;

	public bool CategoriesSelected
	{
		[CompilerGenerated]
		get
		{
			return _003CCategoriesSelected_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CCategoriesSelected_003Ek__BackingField != value)
			{
				_003CCategoriesSelected_003Ek__BackingField = value;
				RaisePropertyChanged("CategoriesSelected");
			}
		}
	}

	public bool Accepted => parameter.Accepted;

	public bool DetailsAvailable => !string.IsNullOrWhiteSpace(DetailDescription);

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
	}

	public UICommand<FavoriteCategoriesPopupViewModel.Parameter> ShowPopupCommand { get; } = new UICommand<FavoriteCategoriesPopupViewModel.Parameter>();

	public UICommand<BrokerToken> NavigateToCategoryCommand { get; } = new UICommand<BrokerToken>();

	public UICommand GoToCatalogCommand { get; } = new UICommand();

	protected override async Task Start()
	{
		State = VisualState.InProgress;
		await base.Start();
		State = VisualState.Default;
	}

	public void ShowCategoryInfo(FavoriteCategoryItemViewModel category)
	{
		AppAnalytics.AppMetrica.TrackEvent("Tap_MainPersonal_offer_informer");
		ShowPopupCommand.Trigger(new FavoriteCategoriesPopupViewModel.Parameter(category.Name, category.Description, Array.Empty<FavoriteCategoryItemViewModel>(), FavoriteCategoriesPopupViewModel.ForCase.InfoItem));
	}

	public void OpenMoreDetails()
	{
		AppAnalytics.AppMetrica.TrackEvent("Tap_MainPersonal_offer_detail");
		ShowPopupCommand.Trigger(new FavoriteCategoriesPopupViewModel.Parameter("Мои категории", DetailDescription, Array.Empty<FavoriteCategoryItemViewModel>(), FavoriteCategoriesPopupViewModel.ForCase.InfoCategories));
	}

	public void SelectCategory(FavoriteCategoryItemViewModel category, bool selected)
	{
		AppAnalytics.AppMetrica.TrackEvent("Tap_MainPersonal_offer_checkbox");
		category.Selected = selected;
		CategoriesSelected = Categories.Count((FavoriteCategoryItemViewModel x) => x.Selected) >= MaxCount;
	}

	public void OnButtonClick()
	{
		if (Accepted)
		{
			AppAnalytics.AppMetrica.TrackEvent("Tap_MainPersonal_backShopping");
			GoToCatalogCommand.Trigger();
			return;
		}
		AppAnalytics.AppMetrica.TrackEvent("Tap_MainPersonal_offer_select");
		ShowPopupCommand.Trigger(new FavoriteCategoriesPopupViewModel.Parameter("Выбранные категории", "", Categories.Where((FavoriteCategoryItemViewModel x) => x.Selected).ToArray(), FavoriteCategoriesPopupViewModel.ForCase.AcceptingItems));
	}

	public void OpenCategory(FavoriteCategoryItemViewModel vm)
	{
		AppAnalytics.AppMetrica.TrackEvent("Tap_MainPersonal_detailsCategory");
		NavigateToCategoryCommand.Trigger(dataBroker.Push(new CatalogProductsViewModel.Parameter(vm.Name, vm.Code, ProductsToLoad.ByCategory, Convert.ToInt64(vm.Id), null, fromSpotlight: false, fromMyCategories: true)));
	}
}
