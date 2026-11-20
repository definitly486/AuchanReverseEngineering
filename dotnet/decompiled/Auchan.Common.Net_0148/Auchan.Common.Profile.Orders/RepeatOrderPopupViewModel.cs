using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Cart.Managers;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Profile.Orders;

public class RepeatOrderPopupViewModel : ScreenViewModel<RepeatOrderPopupViewModel.Parameter>
{
	public enum ResultType
	{
		Cancel,
		AddToCart,
		ShowReplacement
	}

	public sealed class Parameter : BrokeredParameter<Result>
	{
		public IReadOnlyList<RepeatOrderProductModel> Available { get; init; } = Array.Empty<RepeatOrderProductModel>();

		public IReadOnlyList<RepeatOrderProductModel> Unavailable { get; init; } = Array.Empty<RepeatOrderProductModel>();

		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	public sealed class Result
	{
		public required IReadOnlyList<ProductOffer> Products { get; init; }

		public required ResultType Type { get; init; }
	}

	private IReadOnlyList<ProductOffer> _resultProducts = new List<ProductOffer>();

	private ResultType _resultType;

	public readonly UICommand<RepeatOrderProductItemViewModel> ShowQtyDialogCommand = new UICommand<RepeatOrderProductItemViewModel>();

	[CompilerGenerated]
	private decimal _003CTotalPrice_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CAllSelected_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CNoSelected_003Ek__BackingField;

	public string TitleText => "Повторить заказ";

	public string InfoText
	{
		get
		{
			if (!UnavailableOnly)
			{
				return GetItemsUnavailableWarningMessage(Unavailable.Count);
			}
			return "Товаров из заказа нет в наличии, но вы можете подобрать замену";
		}
	}

	public bool InfoVisible => Unavailable.Any();

	private int SelectedItemsCount => Available.Count((RepeatOrderProductItemViewModel x) => x.IsSelected);

	public string AddToCartText => "Добавить в корзину";

	public string UnavailableItemsTitle => "Нет в наличии";

	public string Count => $"{SelectedItemsCount} товар{GrammarHelper.DeclineNoun(SelectedItemsCount)}";

	public string TotalPriceText => GetTotalPriceText();

	private decimal TotalPrice
	{
		[CompilerGenerated]
		get
		{
			return _003CTotalPrice_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!decimal.Equals(_003CTotalPrice_003Ek__BackingField, value))
			{
				_003CTotalPrice_003Ek__BackingField = value;
				RaisePropertyChanged("TotalPriceText");
				RaisePropertyChanged("TotalPrice");
			}
		}
	}

	public bool AllSelected
	{
		[CompilerGenerated]
		get
		{
			return _003CAllSelected_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CAllSelected_003Ek__BackingField != value)
			{
				_003CAllSelected_003Ek__BackingField = value;
				RaisePropertyChanged("AllSelected");
			}
		}
	}

	public bool NoSelected
	{
		[CompilerGenerated]
		get
		{
			return _003CNoSelected_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CNoSelected_003Ek__BackingField != value)
			{
				_003CNoSelected_003Ek__BackingField = value;
				RaisePropertyChanged("NoSelected");
			}
		}
	}

	public string QtyDialogTitle => "Количество товара";

	public string QtyDialogClose => "Закрыть";

	public string QtyDialogDone => "Готово";

	public bool UnavailableOnly
	{
		get
		{
			if (Available.Count == 0)
			{
				return Unavailable.Any();
			}
			return false;
		}
	}

	public ObservableRangeCollection<RepeatOrderProductItemViewModel> Available { get; } = new ObservableRangeCollection<RepeatOrderProductItemViewModel>();

	public ObservableRangeCollection<RepeatOrderProductItemViewModel> Unavailable { get; } = new ObservableRangeCollection<RepeatOrderProductItemViewModel>();

	public UICommand DismissCommand { get; } = new UICommand();

	public string SelectAllText => "Выбрать все";

	public RepeatOrderPopupViewModel(BrokerToken parameter, Func<RepeatOrderProductItemViewModel.Parameter, RepeatOrderProductItemViewModel> itemFactory)
		: base(parameter)
	{
		int num = base.Argument.Available.Count - 1;
		int num2 = base.Argument.Unavailable.Count - 1;
		int ul = num2;
		int al = num;
		Available.ReplaceRange(base.Argument.Available.Select((RepeatOrderProductModel s, int i) => itemFactory(new RepeatOrderProductItemViewModel.Parameter
		{
			ProductModel = s,
			IsLast = (i == al && ul < 0)
		})).ToImmutableList());
		Unavailable.ReplaceRange(base.Argument.Unavailable.Select((RepeatOrderProductModel s, int i) => itemFactory(new RepeatOrderProductItemViewModel.Parameter
		{
			ProductModel = s,
			IsLast = (i == ul)
		})).ToImmutableList());
		UpdateTotalPrice();
		CheckSelectedItems();
	}

	public void OnQtyLabelTap(RepeatOrderProductItemViewModel item)
	{
		ShowQtyDialogCommand.Trigger(item);
	}

	public void AddToCart()
	{
		_resultProducts = (from x in Available
			where x.IsSelected
			select x.ProductOffer).ToImmutableList();
		_resultType = (_resultProducts.Any() ? ResultType.AddToCart : ResultType.Cancel);
		Dismiss();
	}

	public void Dismiss()
	{
		DismissCommand.Trigger();
	}

	public void ShowReplacement(RepeatOrderProductItemViewModel itemViewModel)
	{
		_resultType = ResultType.ShowReplacement;
		_resultProducts = new ProductOffer[1] { itemViewModel.ProductOffer };
		Dismiss();
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(new Result
		{
			Type = _resultType,
			Products = _resultProducts
		});
	}

	private string GetTotalPriceText()
	{
		if (Math.Abs(Math.Round(TotalPrice) - TotalPrice) == 0m)
		{
			return TotalPrice.ToString("C0");
		}
		return TotalPrice.ToString("C2");
	}

	public void OnQtyEnteredManually(RepeatOrderProductItemViewModel itemViewModel, string newQtyWithAlias)
	{
		itemViewModel.ManualInputQty = ManualQtyHandler.OnQtyEnteredManually(itemViewModel.ProductOffer, itemViewModel.ManualInputQty, newQtyWithAlias);
	}

	public void SelectAllItems(bool selected)
	{
		Available.ForEach(delegate(RepeatOrderProductItemViewModel x)
		{
			x.IsSelected = selected;
		});
		CheckSelectedItems();
	}

	public void CheckSelectedItems()
	{
		AllSelected = Available.All((RepeatOrderProductItemViewModel x) => x.IsSelected);
		NoSelected = Available.All((RepeatOrderProductItemViewModel x) => !x.IsSelected);
		RaisePropertyChanged("AllSelected");
		RaisePropertyChanged("NoSelected");
		RaisePropertyChanged("Count");
		UpdateTotalPrice();
	}

	public void UpdateTotalPrice()
	{
		TotalPrice = Available.Where((RepeatOrderProductItemViewModel x) => x.IsSelected).Sum((RepeatOrderProductItemViewModel x) => x.Price);
	}

	public void CheckResult(RepeatOrderProductItemViewModel itemViewModel, string input)
	{
		ProductOffer productOffer = itemViewModel.ProductOffer;
		decimal num = ManualQtyHandler.NormalizeQtyIfNeeded(input, productOffer);
		if (num == 0m)
		{
			itemViewModel.ResetManualQty();
			CheckSelectedItems();
			return;
		}
		if (num > productOffer.LastKnownStock)
		{
			num = productOffer.LastKnownStock;
		}
		itemViewModel.QtyValue = num;
		UpdateTotalPrice();
	}

	private string GetItemsUnavailableWarningMessage(int count)
	{
		int num = count % 10;
		string value = ((count % 100 / 10 == 1) ? "ов" : ((num == 1) ? "а" : "ов"));
		return $"Нет в наличии {count} товар{value}.";
	}
}
