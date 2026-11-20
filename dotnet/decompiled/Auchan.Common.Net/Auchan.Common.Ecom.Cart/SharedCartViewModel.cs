using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.Cart.ViewModels;

namespace Auchan.Common.Ecom.Cart;

public sealed class SharedCartViewModel : ScreenViewModel<SharedCartViewModel.Parameter>
{
	public sealed class Parameter : BrokeredParameter<Result>
	{
		public required SharedCartModel Model { get; init; }

		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	public sealed class Result
	{
		public required ResultType Type { get; init; }

		public required ProductOffer? Product { get; init; }
	}

	public enum ResultType
	{
		Cancel,
		AddToCart,
		ShowProduct
	}

	private ResultType _resultType;

	private ProductOffer? _resultProduct;

	public string TitleText => "С вами поделились товарами";

	public string CountText => "Товаров";

	public string AddToCartText => "Добавить товары";

	public string CancelText => "Отмена";

	public string UnavailableItemsTitle => "Нет в наличии";

	public string Count => base.Argument.Model.Count.ToString();

	public string TotalPrice => GetTotalPriceText();

	public IReadOnlyList<SharedCartProductItemViewModel> Available { get; }

	public IReadOnlyList<SharedCartProductItemViewModel> Unavailable { get; }

	public bool IsUnavailableVisibility => Unavailable.Count > 0;

	public UICommand DismissCommand { get; } = new UICommand();

	public SharedCartViewModel(BrokerToken parameter, Func<SharedCartProductItemViewModel.Parameter, SharedCartProductItemViewModel> itemFactory)
		: base(parameter)
	{
		int num = base.Argument.Model.Available.Count - 1;
		int num2 = base.Argument.Model.Unavailable.Count - 1;
		int ul = num2;
		int al = num;
		Available = base.Argument.Model.Available.Select((ProductOffer s, int i) => itemFactory(new SharedCartProductItemViewModel.Parameter
		{
			Product = s,
			IsLast = (i == al && ul < 0),
			IsAvailable = true
		})).ToImmutableList();
		Unavailable = base.Argument.Model.Unavailable.Select((ProductOffer s, int i) => itemFactory(new SharedCartProductItemViewModel.Parameter
		{
			Product = s,
			IsLast = (i == ul),
			IsAvailable = false
		})).ToImmutableList();
	}

	public void AddToCart()
	{
		_resultType = ResultType.AddToCart;
		Dismiss();
	}

	public void Dismiss()
	{
		DismissCommand.Trigger();
	}

	public void OnItemSelected(SharedCartProductItemViewModel m)
	{
		_resultType = ResultType.ShowProduct;
		_resultProduct = m.Product;
		Dismiss();
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(new Result
		{
			Type = _resultType,
			Product = _resultProduct
		});
	}

	private string GetTotalPriceText()
	{
		decimal totalPrice = base.Argument.Model.TotalPrice;
		if (Math.Abs(Math.Round(totalPrice) - totalPrice) == 0m)
		{
			return totalPrice.ToString("C0");
		}
		return totalPrice.ToString("C2");
	}
}
