using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using Auchan.Common.Logs;
using Auchan.Common.Managers.Dialogs;
using Auchan.Common.Promotions.ExtraPromotions;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Products.ViewModels;

public class CategoryViewModel : ScreenViewModel
{
	public class Parameter
	{
		public Category Category { get; }

		public List<string>? Breadcrumbs { get; set; }

		public Parameter(Category category)
		{
			Category = category;
		}
	}

	private Category _category;

	private readonly IEcomContext _ecomContext;

	private readonly IAgeGateDialog _ageGateDialog;

	private readonly ILogService _logService;

	private readonly IExtraPromotionService _extraPromotionService;

	private readonly ICategoryManager _categoryManager;

	private readonly IDataBroker _dataBroker;

	private readonly Parameter _parameter;

	private readonly Subject<Unit> _onDismiss = new Subject<Unit>();

	private readonly Subject<BrokerToken> _navigateNext = new Subject<BrokerToken>();

	private bool _activeStoreWasChanged;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

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

	public string Title => _category.Name;

	public long CategoryId => _category.Id;

	public bool IsAdult => _category.IsAdult;

	public string SearchPlaceholder => "Поиск товаров";

	public ObservableRangeCollection<CategoryItemViewModel> Categories { get; } = new ObservableRangeCollection<CategoryItemViewModel>();

	public IObservable<BrokerToken> NavigateNextCommand => _navigateNext.Debounce();

	public IObservable<Unit> OnDismiss => _onDismiss.Debounce();

	public CategoryViewModel(Parameter parameter, IEcomContext ecomContext, IAgeGateDialog ageGateDialog, ILogService logService, IExtraPromotionService extraPromotionService, ICategoryManager categoryManager, IDataBroker dataBroker)
	{
		_parameter = parameter;
		_extraPromotionService = extraPromotionService;
		_category = parameter.Category;
		_ecomContext = ecomContext;
		_ageGateDialog = ageGateDialog;
		_logService = logService;
		_categoryManager = categoryManager;
		_dataBroker = dataBroker;
	}

	protected override async Task Start()
	{
		await base.Start();
		bool flag = await ReloadCategories();
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ActiveStore).Subscribe(delegate
		{
			_activeStoreWasChanged = true;
		}).AddTo(base.CloseDisposable);
		if (flag)
		{
			await OpenAgeGateOrNothing();
		}
	}

	private async Task OpenAgeGateOrNothing()
	{
		if (_ecomContext.AgeGateAgreement != AgreeState.Yes && _category.IsAdult)
		{
			switch (await _ageGateDialog.ShowAgeGateDialogAsync())
			{
			case AgreeState.None:
			case AgreeState.No:
				_onDismiss.OnNext(Unit.Default);
				break;
			case AgreeState.Yes:
				await _extraPromotionService.OpenPromotionDirectly(this);
				break;
			}
		}
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		_logService.LogInfo("CategoryViewModel", "Открыт список подкатегорий", LogType.UserAction, SystemType.MobileApp);
		if (_activeStoreWasChanged)
		{
			_activeStoreWasChanged = false;
			if (await ReloadCategories())
			{
				await OpenAgeGateOrNothing();
			}
		}
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ActiveStore).PerformTask((Func<Store, Task>)async delegate
		{
			_activeStoreWasChanged = false;
			if (await ReloadCategories())
			{
				await OpenAgeGateOrNothing();
			}
		}, (IScheduler?)null).Subscribe()
			.AddTo(base.PauseDisposable);
	}

	public async Task ToggleCategoryIfNeeded(CategoryItemViewModel selectedItem)
	{
		if (!selectedItem.Category.Expandable || selectedItem.Categories == null || selectedItem.Categories.Count < 1)
		{
			List<string> breadcrumbs = new List<string>();
			_parameter.Breadcrumbs?.ForEach(delegate(string b)
			{
				breadcrumbs.Add(b);
			});
			if (selectedItem is SubCategoryItemViewModel { Parent: not null } subCategoryItemViewModel)
			{
				breadcrumbs.Add(subCategoryItemViewModel.Parent.Name);
			}
			breadcrumbs.Add(selectedItem.Category.Name);
			bool flag = selectedItem.Category.IsAdult && _ecomContext.AgeGateAgreement != AgreeState.Yes;
			if (flag)
			{
				flag = await _ageGateDialog.ShowAgeGateDialogAsync() != AgreeState.Yes;
			}
			if (!flag)
			{
				_navigateNext.OnNext(_dataBroker.Push(new CatalogProductsViewModel.Parameter(selectedItem.Category, breadcrumbs)));
			}
			return;
		}
		if (!selectedItem.IsExpanded)
		{
			Category category = new Category
			{
				Name = "Все",
				Code = selectedItem.Code,
				Id = selectedItem.Id,
				DefaultSortMap = selectedItem.Category.DefaultSortMap,
				Items = selectedItem.Category.Items,
				Expandable = false
			};
			Categories.Insert(Categories.IndexOf(selectedItem) + 1, new SubCategoryItemViewModel(category));
			Categories.InsertRange(Categories.IndexOf(selectedItem) + 2, selectedItem.Categories.Select((Category item) => new SubCategoryItemViewModel(item, selectedItem.Category)));
		}
		else
		{
			Categories.RemoveRange(Categories.IndexOf(selectedItem) + 1, selectedItem.Categories.Count + 1);
		}
		selectedItem.IsExpanded = !selectedItem.IsExpanded;
	}

	private async Task<bool> ReloadCategories()
	{
		State = VisualState.InProgress;
		Result<IReadOnlyList<CategoryItemViewModel>, DomainError> result = await _categoryManager.GetTopCategories();
		if (result.IsFailure)
		{
			_onDismiss.OnNext(Unit.Default);
			State = VisualState.Default;
			return false;
		}
		Category category = result.Value.Select((CategoryItemViewModel x) => x.Category).FirstOrDefaultRecursive((Category x) => x.Id == CategoryId, (Category x) => x.Items);
		if (category == null || category.Items.Count == 0)
		{
			_onDismiss.OnNext(Unit.Default);
			State = VisualState.Default;
			return false;
		}
		_category = category;
		Categories.Clear();
		Categories.AddRange(_category.Items.Select((Category items) => new CategoryItemViewModel(items)));
		State = VisualState.Default;
		return true;
	}
}
