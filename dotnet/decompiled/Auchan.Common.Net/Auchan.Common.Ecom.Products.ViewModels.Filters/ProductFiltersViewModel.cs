using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels.Filters;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Products.ViewModels.Filters;

public sealed class ProductFiltersViewModel : ScreenViewModel<ProductFiltersViewModel.Parameter>, IProductFilterObserver, INotifyPropertyChanged, IScreenViewModel, IBindable
{
	public sealed class Parameter : BrokeredParameter<Result?>
	{
		public ProductFilterResult FilterResult { get; }

		public IEnumerable<BaseProductFilterItemViewModel.Usage>? Usages { get; }

		public string CategoryCode { get; }

		public Parameter(ProductFilterResult filterResult, IEnumerable<BaseProductFilterItemViewModel.Usage>? usages, string categoryCode, CancellationToken cancellationToken = default(CancellationToken))
			: base(cancellationToken)
		{
			FilterResult = filterResult;
			Usages = usages;
			CategoryCode = categoryCode;
		}
	}

	public sealed class Result
	{
		public ProductFilterResult Filters { get; }

		public IEnumerable<BaseProductFilterItemViewModel.Usage> Usages { get; }

		public Result(ProductFilterResult filters, IEnumerable<BaseProductFilterItemViewModel.Usage> usages)
		{
			Filters = filters;
			Usages = usages;
		}
	}

	private readonly IProductsManager _productsManager;

	private bool _applyChanges;

	private ProductFilterResult? _result;

	private bool _startupCompleted;

	private bool _dismissing;

	[CompilerGenerated]
	private string _003CApplyText_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CApplyAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsWaitingForResponse_003Ek__BackingField;

	private readonly UICommand<ProductMultiCheckFilterItemViewModel> _openMultiCheckCommand = new UICommand<ProductMultiCheckFilterItemViewModel>();

	private readonly UICommand<ProductRadioFilterItemViewModel> _openRadioCheckCommand = new UICommand<ProductRadioFilterItemViewModel>();

	public string Title => "Фильтр";

	public string ApplyText
	{
		[CompilerGenerated]
		get
		{
			return _003CApplyText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CApplyText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CApplyText_003Ek__BackingField = value;
				RaisePropertyChanged("ApplyText");
			}
		}
	} = "Применить";

	public bool ApplyAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CApplyAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CApplyAvailable_003Ek__BackingField != value)
			{
				_003CApplyAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("ApplyAvailable");
			}
		}
	}

	public bool IsWaitingForResponse
	{
		[CompilerGenerated]
		get
		{
			return _003CIsWaitingForResponse_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsWaitingForResponse_003Ek__BackingField != value)
			{
				_003CIsWaitingForResponse_003Ek__BackingField = value;
				RaisePropertyChanged("IsWaitingForResponse");
			}
		}
	}

	public ObservableRangeCollection<SelectedFilterItemViewModel> SelectedFilters { get; } = new ObservableRangeCollection<SelectedFilterItemViewModel>
	{
		ShouldDeferEvents = false
	};

	public ObservableRangeCollection<BaseProductFilterItemViewModel> Filters { get; } = new ObservableRangeCollection<BaseProductFilterItemViewModel>
	{
		ShouldDeferEvents = false
	};

	IReadOnlyList<BaseProductFilterItemViewModel> IProductFilterObserver.Filters => Filters;

	public UICommand ApplyFiltersCommand { get; } = new UICommand();

	public UICommand CloseCommand { get; } = new UICommand();

	public UICommand<SelectedFilterItemViewModel> SelectedFilterSelectedCommand { get; } = new UICommand<SelectedFilterItemViewModel>();

	UICommand<ProductMultiCheckFilterItemViewModel> IProductFilterObserver.OpenMultiCheckCommand => _openMultiCheckCommand;

	public UICommand<BrokerToken> OpenMultiCheckCommand { get; } = new UICommand<BrokerToken>();

	UICommand<ProductRadioFilterItemViewModel> IProductFilterObserver.OpenRadioCheckCommand => _openRadioCheckCommand;

	public UICommand<BrokerToken> OpenRadioCheckCommand { get; } = new UICommand<BrokerToken>();

	public ProductFiltersViewModel(BrokerToken parameter, IProductsManager productsManager)
		: base(parameter)
	{
		_productsManager = productsManager;
	}

	protected override async Task Start()
	{
		await base.Start();
		UpdateApplyButton(isSucces: true, () => base.Argument.FilterResult.ProductCount);
		ProcessReceivedFilters(base.Argument.FilterResult);
		RestoreFilters(base.Argument.Usages);
		_openMultiCheckCommand.PerformDebouncingTask((ProductMultiCheckFilterItemViewModel ivm) => RequestOpenMultiCheckPopupAsync(ivm)).Subscribe().AddTo(base.CloseDisposable);
		_openRadioCheckCommand.PerformDebouncingTask((ProductRadioFilterItemViewModel ivm) => RequestOpenRadionCheckPopupAsync(ivm)).Subscribe().AddTo(base.CloseDisposable);
		SelectedFilterSelectedCommand.PerformDebouncingTask((SelectedFilterItemViewModel f) => RemoveFilterAsync(f)).Subscribe().AddTo(base.CloseDisposable);
		ApplyFiltersCommand.Do(delegate
		{
			_applyChanges = true;
			CloseCommand.Trigger();
		}).Subscribe().AddTo(base.CloseDisposable);
		CloseCommand.Do(delegate
		{
			_dismissing = true;
		}).Subscribe().AddTo(base.CloseDisposable);
		_startupCompleted = true;
	}

	private async Task RequestOpenMultiCheckPopupAsync(ProductMultiCheckFilterItemViewModel ivm)
	{
		ProductMultiCheckFilterViewModel.Parameter parameter = new ProductMultiCheckFilterViewModel.Parameter(ivm);
		OpenMultiCheckCommand.Trigger(base.DataBroker.Push(parameter));
		IEnumerable<ProductFilterMultiItem> enumerable = await parameter.WaitForResultAsync();
		if (enumerable != null)
		{
			ivm.SetSelectedCodes(enumerable.Select((ProductFilterMultiItem i) => i.Code));
		}
	}

	private async Task RequestOpenRadionCheckPopupAsync(ProductRadioFilterItemViewModel ivm)
	{
		ProductRadioFilterViewModel.Parameter parameter = new ProductRadioFilterViewModel.Parameter(ivm);
		OpenRadioCheckCommand.Trigger(base.DataBroker.Push(parameter));
		Result<ProductFilterMultiItem> result = await parameter.WaitForResultAsync();
		if (result.IsSuccess)
		{
			ivm.SelectedItem = result.Value;
		}
	}

	private Task RemoveFilterAsync(SelectedFilterItemViewModel ivm)
	{
		if (ivm.IsDeleteAll)
		{
			Filters.ForEach(delegate(BaseProductFilterItemViewModel f)
			{
				f.ResetFilter();
			});
			SelectedFilters.Clear();
		}
		else
		{
			ivm.Filter?.ResetFilter(raiseFilterChanged: true);
			SelectedFilters.Remove(ivm);
		}
		return LoadFiltersAsync();
	}

	private async Task LoadFiltersAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (!IsWaitingForResponse)
		{
			IsWaitingForResponse = true;
			ApplyAvailable = false;
			Result<ProductFilterResult, DomainError> filters = await _productsManager.GetFiltersAsync(base.Argument.CategoryCode, CreateFilterRequestDto(), cancellationToken);
			UpdateApplyButton(filters.IsSuccess, () => filters.Value.ProductCount);
			if (filters.IsSuccess)
			{
				ProcessReceivedFilters(filters.Value);
			}
			IsWaitingForResponse = false;
		}
	}

	private void ProcessReceivedFilters(ProductFilterResult value)
	{
		_result = value;
		if (value.Filters.Any())
		{
			SetFilters(value.Filters.Where((ProductFilter f) => f.IsCanBeDisplayed()).ToArray(), Filters);
			if (value.SelectedFilters.Any())
			{
				RestoreFilters(value.SelectedFilters, Filters);
			}
		}
	}

	private void SetFilters(IReadOnlyList<ProductFilter> filters, ObservableRangeCollection<BaseProductFilterItemViewModel> targetFilters)
	{
		if (filters.Count == targetFilters.Count && targetFilters.All((BaseProductFilterItemViewModel tf) => filters.Any((ProductFilter f) => f.Code == tf.Code)))
		{
			filters.ForEach(delegate(ProductFilter f)
			{
				targetFilters.FirstOrDefault((BaseProductFilterItemViewModel tf) => tf.Code == f.Code)?.SetFilter(f);
			});
			return;
		}
		IOrderedEnumerable<BaseProductFilterItemViewModel> collection = from f in filters.SelectNotNull((ProductFilter f) => f.Type switch
			{
				ProductFilterType.Range => new ProductRangeFilterItemViewModel(this, f), 
				ProductFilterType.Radio => new ProductRadioFilterItemViewModel(this, f), 
				ProductFilterType.Check => new ProductCheckFilterItemViewModel(this, f), 
				ProductFilterType.MultiCheck => new ProductMultiCheckFilterItemViewModel(this, f), 
				_ => null, 
			}).Select(delegate(BaseProductFilterItemViewModel newFilter)
			{
				BaseProductFilterItemViewModel? baseProductFilterItemViewModel = targetFilters.FirstOrDefault((BaseProductFilterItemViewModel f) => f.Code == newFilter.Code);
				Tuple<string, object> tuple = baseProductFilterItemViewModel?.GetSelectedFilter();
				if (tuple != null)
				{
					newFilter.SetSelectedFilter(tuple);
				}
				BaseProductFilterItemViewModel.Usage usage = baseProductFilterItemViewModel?.GetUsage();
				if (usage != null)
				{
					newFilter.SetUsage(usage);
				}
				return newFilter;
			})
			orderby (int)f.Filter.Type, f.Filter.Sort
			select f;
		targetFilters.ReplaceRange(collection);
	}

	private void RestoreFilters(IReadOnlyDictionary<string, object> selectedFilters, ObservableRangeCollection<BaseProductFilterItemViewModel> targetFilters)
	{
		foreach (KeyValuePair<string, object> selectedFilter in selectedFilters)
		{
			targetFilters.FirstOrDefault((BaseProductFilterItemViewModel f) => f.Code == selectedFilter.Key)?.Restore(selectedFilter);
		}
	}

	private void RestoreFilters(IEnumerable<BaseProductFilterItemViewModel.Usage>? usages)
	{
		if (usages == null)
		{
			return;
		}
		foreach (var (baseProductFilterItemViewModel, usage) in from i in Filters
			join j in usages on i.Filter.Code equals j.FilterCode
			select (filter: i, usage: j))
		{
			baseProductFilterItemViewModel.SetUsage(usage);
		}
	}

	private FilterRequestDto CreateFilterRequestDto()
	{
		Dictionary<string, object> dictionary = (from f in Filters
			let sf = f.GetSelectedFilter()
			where sf != null
			let rq = f.Filter.Url ?? f.Filter.Code
			let value = sf.Item2
			select (rq: rq, value: value)).ToDictionary();
		if (base.Argument.FilterResult.SelectedFilters.TryGetValue("is_adult", out object value))
		{
			dictionary["is_adult"] = value;
		}
		return new FilterRequestDto(dictionary);
	}

	public void OnFilterChanged(BaseProductFilterItemViewModel filter)
	{
		SelectedFilters.ReplaceRange(from filter2 in Filters
			where filter2.GetSelectedFilter() != null
			select new SelectedFilterItemViewModel(filter2) into selectedFilterItemViewModel
			orderby (int)selectedFilterItemViewModel.Filter.Filter.Type, selectedFilterItemViewModel.Filter.Filter.Sort
			select selectedFilterItemViewModel);
		if (SelectedFilters.Count > 0)
		{
			SelectedFilters.Add(new SelectedFilterItemViewModel(null));
		}
		if (_startupCompleted && !_dismissing)
		{
			LoadFiltersAsync().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private void UpdateApplyButton(bool isSucces, Func<int> getProductCount)
	{
		if (isSucces)
		{
			int num = getProductCount();
			ApplyText = ((num < 1) ? "Товары не найдены" : $"Показать {num} товар{GrammarHelper.DeclineNoun(num)}");
			ApplyAvailable = num > 0;
		}
		else
		{
			ApplyText = "Показать товары";
			ApplyAvailable = true;
		}
	}

	public override void Dispose()
	{
		base.Dispose();
		if (_result == null)
		{
			return;
		}
		if (Filters.Any((BaseProductFilterItemViewModel f) => f.GetSelectedFilter() != null))
		{
			base.Argument.TaskCompletionSource.TrySetResult(_applyChanges ? new Result(new ProductFilterResult
			{
				Filters = _result.Filters,
				RequiredRedirects = _result.RequiredRedirects,
				ProductCount = _result.ProductCount,
				SelectedFilters = Filters.SelectNotNull((BaseProductFilterItemViewModel f) => f.GetSelectedFilter()).ToDictionary((Tuple<string, object> f) => f.Item1, (Tuple<string, object> f) => f.Item2)
			}, Filters.Select((BaseProductFilterItemViewModel f) => f.GetUsage()).ToArray()) : null);
		}
		else
		{
			base.Argument.TaskCompletionSource.TrySetResult(_applyChanges ? new Result(_result, Filters.Select((BaseProductFilterItemViewModel f) => f.GetUsage()).ToArray()) : null);
		}
	}
}
