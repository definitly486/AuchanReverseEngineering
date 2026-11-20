using System.Threading;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;

namespace Auchan.Common.Ecom.PriceChecker;

public class ProductMiniViewModel : ScreenViewModel<ProductMiniViewModel.Parameter>
{
	public class Parameter : BrokeredParameter<Result>
	{
		public required Product Product { get; init; }

		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	public enum Result
	{
		None,
		NavigateToFeedback
	}

	private Result _result;

	public UICommand CloseCommand { get; } = new UICommand();

	public Product Product => base.Argument.Product;

	public string Title => base.Argument.Product.Title ?? "";

	public bool HasDiscount => Product.Discount != null;

	public string Price => $"{base.Argument.Product.Price?.Value ?? 0m:C2}";

	public string OldPrice => $"{base.Argument.Product.OldPrice?.Value ?? 0m:F2}";

	public string UnitTypeText
	{
		get
		{
			Price? price = Product.Price;
			if ((object)price == null || price.UnitType != ProductUnitType.Kilogram_1)
			{
				return "";
			}
			return "цена за 1 кг";
		}
	}

	public bool IsUnitTypeVisible
	{
		get
		{
			Price? price = Product.Price;
			if ((object)price == null)
			{
				return false;
			}
			return price.UnitType == ProductUnitType.Kilogram_1;
		}
	}

	public string FeedbackButtonTitle => "Сообщить о неточности";

	public ProductMiniViewModel(BrokerToken brokerToken)
		: base(brokerToken)
	{
	}

	public void OnFeedbackClicked()
	{
		_result = Result.NavigateToFeedback;
		CloseCommand.Trigger();
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(_result);
	}
}
