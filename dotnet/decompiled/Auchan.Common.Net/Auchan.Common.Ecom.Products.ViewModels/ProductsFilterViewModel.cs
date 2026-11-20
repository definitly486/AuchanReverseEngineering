using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Products.ViewModels;

public class ProductsFilterViewModel : ScreenViewModel<ProductsFilterViewModel.Parameter>
{
	public enum VisualState
	{
		Default,
		InProgress,
		Error
	}

	public sealed class Parameter : BrokeredParameter<Maybe<List<string>>>
	{
		public ProductsToLoad LoadType { get; }

		public string Code { get; }

		public List<ProductsFilterItemViewModel> FilterOptions { get; }

		public Parameter(ProductsToLoad loadType, string code, List<ProductsFilterItemViewModel> filterOptions)
			: base(default(CancellationToken))
		{
			LoadType = loadType;
			Code = code;
			FilterOptions = filterOptions;
		}
	}

	private readonly Subject<Unit> _onRetry = new Subject<Unit>();

	private bool _apply;

	[CompilerGenerated]
	private ObservableRangeCollection<ProductsFilterItemViewModel> _003CFilterOptions_003Ek__BackingField;

	public string Title => "Фильтр";

	public string ApplyButtonTitle => "Применить";

	public string ClearButtonTitle => "Очистить фильтр";

	public string CloseButtonTitle => "Закрыть";

	public ObservableRangeCollection<ProductsFilterItemViewModel> FilterOptions
	{
		[CompilerGenerated]
		get
		{
			return _003CFilterOptions_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CFilterOptions_003Ek__BackingField, value))
			{
				_003CFilterOptions_003Ek__BackingField = value;
				RaisePropertyChanged("FilterOptions");
			}
		}
	}

	public UICommand CloseDialogCommand { get; } = new UICommand();

	public ProductsFilterViewModel(BrokerToken brokerToken)
		: base(brokerToken)
	{
		FilterOptions = new ObservableRangeCollection<ProductsFilterItemViewModel>(base.Argument.FilterOptions);
	}

	public void ApplyButtonClick()
	{
		_apply = true;
		CloseDialogCommand.Trigger();
	}

	public void ClearButtonClick()
	{
		FilterOptions.ToList().ForEach(delegate(ProductsFilterItemViewModel x)
		{
			x.Selected = false;
		});
	}

	public void CloseButtonClick()
	{
		CloseDialogCommand.Trigger();
	}

	public override void Dispose()
	{
		base.Dispose();
		Maybe<List<string>> result = (_apply ? Maybe<List<string>>.From((from x in FilterOptions
			where x.Selected
			select x.Code).ToList()) : Maybe<List<string>>.None);
		base.Argument.TaskCompletionSource.TrySetResult(result);
	}
}
