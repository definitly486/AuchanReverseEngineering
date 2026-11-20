using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;

namespace Auchan.Common.Profile.Orders.Models;

public class RepeatOrderProductItemViewModel : BaseItemViewModel
{
	public sealed class Parameter
	{
		public required RepeatOrderProductModel ProductModel { get; init; }

		public required bool IsLast { get; init; }
	}

	private readonly Parameter _parameter;

	private readonly RepeatOrderProductModel _productModel;

	private readonly ProductUnitType _unitType;

	[CompilerGenerated]
	private bool _003CIsSelected_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CManualInputQty_003Ek__BackingField;

	public readonly FavoritesButtonViewModel FavoritesButtonViewModel;

	private decimal _qtyValue;

	public ProductOffer ProductOffer => _productModel.GetProductOffer(QtyValue);

	public bool IsSelected
	{
		[CompilerGenerated]
		get
		{
			return _003CIsSelected_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsSelected_003Ek__BackingField != value)
			{
				_003CIsSelected_003Ek__BackingField = value;
				RaisePropertyChanged("IsSelected");
			}
		}
	} = true;

	public string ImageUrl => _productModel.ImagePath;

	public string TitleText => _productModel.Title;

	public IReadOnlyList<ListItemModificationValueViewModel> ProductSelectedModifications => _productModel.SelectedModifications;

	public decimal Price => GetPrice();

	public string PriceText => Price.ToString("C2");

	public string PricePerItemText => GetPricePerItem();

	public string StockLabel => ProductsConverter.GetStockInfo(_productModel.QtyInStock, _unitType, IsNeedToShowFractionPartOnStock(_productModel.QtyInStock))?.ToLower() ?? string.Empty;

	public string FindReplacementText => "Найти замену";

	public decimal QtyValue
	{
		get
		{
			return _qtyValue;
		}
		set
		{
			if (!decimal.Equals(_qtyValue, value))
			{
				_qtyValue = value;
				RaisePropertyChanged("ProductOffer");
				RaisePropertyChanged("Price");
				RaisePropertyChanged("PriceText");
				RaisePropertyChanged("IncreaseEnabled");
				RaisePropertyChanged("DecreaseEnabled");
				RaisePropertyChanged("StockLabelHighlighted");
				RaisePropertyChanged("QtyValue");
				ManualInputQty = ProductsConverter.FromProductToQty(value, _unitType);
			}
		}
	}

	public string ManualInputQty
	{
		[CompilerGenerated]
		get
		{
			return _003CManualInputQty_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CManualInputQty_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CManualInputQty_003Ek__BackingField = value;
				RaisePropertyChanged("ManualInputQty");
			}
		}
	}

	public bool IncreaseEnabled
	{
		get
		{
			if (_productModel.QtyInStock > 0m)
			{
				return _productModel.QtyInStock - QtyValue > 0.00001m;
			}
			return false;
		}
	}

	public bool DecreaseEnabled => QtyValue >= 2m * _productModel.BasketStep;

	public bool StockLabelHighlighted => QtyValue > _productModel.QtyInStock;

	public bool IsSeparatorVisible => !_parameter.IsLast;

	public RepeatOrderProductItemViewModel(Parameter parameter, Func<Product, FavoritesButtonViewModel> favoritesButtonViewModelFactory)
	{
		_parameter = parameter;
		_productModel = parameter.ProductModel;
		_unitType = _productModel.UnitType;
		QtyValue = _productModel.QtyInOrder;
		ManualInputQty = ProductsConverter.FromProductToQty(QtyValue, _unitType);
		FavoritesButtonViewModel = favoritesButtonViewModelFactory(_productModel.GetProduct());
	}

	private decimal GetPrice()
	{
		return _productModel.Price * ((_unitType == ProductUnitType.Gram_100) ? (QtyValue * 10m) : QtyValue);
	}

	private string GetPricePerItem()
	{
		string value = _unitType switch
		{
			ProductUnitType.Unit => "шт", 
			ProductUnitType.Kilogram_1 => "кг", 
			ProductUnitType.Gram_100 => "100г", 
			_ => throw new NotSupportedException("dead code"), 
		};
		return $"{_productModel.Price:C2}/{value}";
	}

	private bool IsNeedToShowFractionPartOnStock(decimal qty)
	{
		ProductUnitType unitType = _unitType;
		if ((uint)(unitType - 1) <= 1u)
		{
			return Math.Abs(qty - Math.Round(qty)) > 0.001m;
		}
		return false;
	}

	public void OnChangeQty(bool increased = false)
	{
		if ((!increased || IncreaseEnabled) && (increased || DecreaseEnabled))
		{
			decimal basketStep = _productModel.BasketStep;
			QtyValue = (increased ? (QtyValue + basketStep) : (QtyValue - basketStep));
		}
	}

	public void ResetManualQty()
	{
		QtyValue = 1m;
		ManualInputQty = ProductsConverter.FromProductToQty(QtyValue, _unitType);
		IsSelected = false;
	}
}
