using Auchan.Common.Base;

namespace Auchan.Common.LoyaltyProgram.Models;

public class LoyaltyProductViewModel : BaseItemViewModel
{
	private readonly LoyaltyProduct _loyaltyProduct;

	private readonly bool _shouldShowStamps;

	public string Code => _loyaltyProduct.Code ?? "";

	public string Name => _loyaltyProduct.Name ?? "Имя товара";

	public string Price => $"{_loyaltyProduct.Price:N2} ₽";

	public bool HasImage => !string.IsNullOrEmpty(_loyaltyProduct.Image);

	public string ImageUrl => _loyaltyProduct.Image ?? "";

	public string UnitPriceAndQuantity => $"{_loyaltyProduct.Price / _loyaltyProduct.Quantity:N2} ₽/шт · {_loyaltyProduct.Quantity} шт";

	public bool HasPoints => _loyaltyProduct.Points != 0m;

	public string Points
	{
		get
		{
			if (_loyaltyProduct.Points > 0m)
			{
				return $"+{_loyaltyProduct.Points:N2}";
			}
			return $"{_loyaltyProduct.Points:N2}";
		}
	}

	public bool HasExpressPoints => _loyaltyProduct.ExpressPoints != 0m;

	public string ExpressPoints
	{
		get
		{
			if (_loyaltyProduct.ExpressPoints > 0m)
			{
				return $"+{_loyaltyProduct.ExpressPoints:N2}";
			}
			return $"{_loyaltyProduct.ExpressPoints:N2}";
		}
	}

	public bool HasStamps
	{
		get
		{
			if (_shouldShowStamps)
			{
				return _loyaltyProduct.Stamps != 0m;
			}
			return false;
		}
	}

	public string Stamps
	{
		get
		{
			if (_loyaltyProduct.Stamps > 0m)
			{
				return $"+{(int)_loyaltyProduct.Stamps}";
			}
			return $"{(int)_loyaltyProduct.Stamps}";
		}
	}

	public bool NegativeStamps => _loyaltyProduct.Stamps < 0m;

	public bool NegativePoints => _loyaltyProduct.Points < 0m;

	public bool NegativeExpressPoints => _loyaltyProduct.ExpressPoints < 0m;

	public LoyaltyProductViewModel(LoyaltyProduct loyaltyProduct, bool showStamps)
	{
		_loyaltyProduct = loyaltyProduct;
		_shouldShowStamps = showStamps;
	}
}
