using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Helpers;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Profile.Orders;

public class AddProductsToOrderPopupViewModel : ScreenViewModel<AddProductsToOrderPopupViewModel.Parameter>
{
	public sealed class Parameter : BrokeredParameter<bool>
	{
		public required string OrderNumber { get; init; }

		public required int AvailableItemsCount { get; init; }

		public required decimal NewOrderPrice { get; init; }

		public required IReadOnlyList<AdditionalOrderProductItem> AvailableItems { get; init; }

		public required IReadOnlyList<AdditionalOrderProductItem> UnavailableItems { get; init; }

		public required decimal ProductsSum { get; init; }

		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	private bool _result;

	public string Title => "Добавить товары к заказу\n" + OrderNumber;

	private string OrderNumber => "№" + base.Argument.OrderNumber;

	public bool InfoVisible
	{
		get
		{
			if (UnavailableItemsCount <= 0)
			{
				return AvailableItems.Any((AdditionalOrderProductItem x) => x.HaveConstraints);
			}
			return true;
		}
	}

	public string InfoText
	{
		get
		{
			if (UnavailableItemsCount <= 0)
			{
				return "Проверьте наличие и цену на товары";
			}
			return $"К текущему заказу мы добавим {AvailableItemsCount} из {AvailableItemsCount + UnavailableItemsCount} товаров";
		}
	}

	public string ProductsCount => $"{AvailableItemsCount} товар{GrammarHelper.DeclineNoun(AvailableItemsCount)}";

	public int UnavailableItemsCount => UnavailableItems.Count;

	public int AvailableItemsCount => base.Argument.AvailableItemsCount;

	public IReadOnlyList<AdditionalOrderProductItem> AvailableItems => base.Argument.AvailableItems;

	public IReadOnlyList<AdditionalOrderProductItem> UnavailableItems => base.Argument.UnavailableItems;

	public string ProductsSum => $"Товары на сумму: {base.Argument.ProductsSum:C2}";

	public string NewOrderPriceLabel => $"Новая стоимость заказа:\n{base.Argument.NewOrderPrice:C2}";

	public string HintText => "Цена учитывает стоимость доставки,\nкоторая могла измениться";

	public string ButtonText => "Добавить к заказу";

	public string UnavailableItemsTitle => "Недоступны для добавления";

	public UICommand CloseCommand { get; } = new UICommand();

	public AddProductsToOrderPopupViewModel(BrokerToken token)
		: base(token)
	{
	}

	public void AddToOrder()
	{
		_result = true;
		CloseCommand.Trigger();
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(_result);
	}
}
