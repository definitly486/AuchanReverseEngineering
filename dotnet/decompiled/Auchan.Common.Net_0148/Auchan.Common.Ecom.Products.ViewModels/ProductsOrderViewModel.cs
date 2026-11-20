using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.ProducModels;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Products.ViewModels;

public class ProductsOrderViewModel : ScreenViewModel<ProductsOrderViewModel.Parameter>
{
	public sealed class Parameter : BrokeredParameter<Result<ProductSortType?>>
	{
		public IReadOnlyList<ProductSortType> OrderOptions { get; }

		public ProductSortType? SelectedType { get; }

		public Parameter(ProductSortType? selectedType, IReadOnlyList<ProductSortType> orderOptions)
			: base(default(CancellationToken))
		{
			SelectedType = selectedType;
			OrderOptions = orderOptions;
		}
	}

	private bool _apply;

	[CompilerGenerated]
	private ObservableRangeCollection<string> _003COrderOptions_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CSelectedValue_003Ek__BackingField;

	public string Title => "Сортировка";

	public string ApplyButtonTitle => "Применить";

	public ObservableRangeCollection<string> OrderOptions
	{
		[CompilerGenerated]
		get
		{
			return _003COrderOptions_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COrderOptions_003Ek__BackingField, value))
			{
				_003COrderOptions_003Ek__BackingField = value;
				RaisePropertyChanged("OrderOptions");
			}
		}
	}

	public UICommand CloseDialogCommand { get; } = new UICommand();

	public string? SelectedValue
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedValue_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CSelectedValue_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSelectedValue_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedValue");
			}
		}
	}

	public ProductsOrderViewModel(BrokerToken token)
		: base(token)
	{
		SelectedValue = base.Argument.SelectedType?.Name ?? null;
		OrderOptions = new ObservableRangeCollection<string>(base.Argument.OrderOptions.Select((ProductSortType x) => x.Name));
	}

	public void ApplyButtonClick()
	{
		_apply = true;
		CloseDialogCommand.Trigger();
	}

	public void CloseButtonClick()
	{
		CloseDialogCommand.Trigger();
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(_apply ? Result.Success(base.Argument.OrderOptions.FirstOrDefault((ProductSortType x) => x.Name == SelectedValue)) : Result.Failure<ProductSortType>("no result"));
	}
}
