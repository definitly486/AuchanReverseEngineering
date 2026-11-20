using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Profile.Orders;

public class OrderDetailProductItemViewModel : BaseItemViewModel
{
	private readonly NumberFormatInfo _priceFormat = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();

	private readonly ProductModel _product;

	public string ImagePath { get; }

	public int ItemId => _product.ItemId;

	public int? DestItemId => _product.DestItemId;

	public List<ListItemModificationValueViewModel> SelectedModifications { get; }

	public bool IsCanceled
	{
		get
		{
			if (_product.Qty == 0m)
			{
				return !IsReplaced;
			}
			return false;
		}
	}

	public bool IsReplaced => _product.DestItemId.HasValue;

	public string NameText => _product.Name;

	public string Code => _product.Code;

	public string PriceText
	{
		get
		{
			if (!IsCanceled && !IsReplaced)
			{
				return GetPriceText(_product.Price);
			}
			return GetPriceText(_product.PriceInit);
		}
	}

	public string PricePerItemText
	{
		get
		{
			if (!IsCanceled && !IsReplaced)
			{
				return GetPricePerItemText(_product.Qty, _product.Price);
			}
			return GetPricePerItemText(_product.QtyInit, _product.PriceInit);
		}
	}

	public string QtyText
	{
		get
		{
			if (!IsCanceled && !IsReplaced)
			{
				if (!IsReplacement)
				{
					if (!IsQtyChanged)
					{
						return GetQtyText(_product.Qty);
					}
					return GetQtyCorrectedText();
				}
				return GetQtyText(_product.Qty);
			}
			return GetQtyText(_product.QtyInit);
		}
	}

	private bool IsReplacement => _product.SourceItemId.HasValue;

	private bool IsQtyChanged => Math.Abs(_product.QtyInit - _product.Qty) > 0.0001m;

	public string GimaId => _product.GimaId;

	public decimal Qty => _product.Qty;

	public OrderDetailProductItemViewModel(ProductModel product)
	{
		_product = product;
		_priceFormat.NumberGroupSeparator = " ";
		SelectedModifications = GetSelectedModifications(product);
		string text = GetPreviewImageUrl(product);
		ImagePath = text ?? _product.ImageUrl ?? "";
		static string? GetPreviewImageUrl(ProductModel productModel)
		{
			return productModel.SelectedModifications.FirstOrDefault((SelectedModification c) => !string.IsNullOrEmpty(c.Value?.PreviewImageUrl))?.Value?.PreviewImageUrl;
		}
		static List<ListItemModificationValueViewModel> GetSelectedModifications(ProductModel productModel)
		{
			return productModel.SelectedModifications?.Select((SelectedModification c) => new ListItemModificationValueViewModel(c.Name, c.Value?.Description ?? string.Empty))?.ToList() ?? new List<ListItemModificationValueViewModel>();
		}
	}

	public IReadOnlyList<SelectedModification> GetOriginalModifications()
	{
		return _product.SelectedModifications;
	}

	private string GetPricePerItemText(decimal qty, decimal price)
	{
		if (qty == 0m)
		{
			return "";
		}
		return (price / qty).ToString("#,0.00", _priceFormat) + " ₽/" + (_product.ProductTypeIsPerKilo ? "кг." : "шт.");
	}

	private string GetPriceText(decimal price)
	{
		return price.ToString("#,0.00", _priceFormat) + " ₽";
	}

	private string GetQtyText(decimal qty)
	{
		if (_product.ProductTypeIsPerKilo)
		{
			return $"{qty} кг";
		}
		return $"{qty:N0} шт.";
	}

	private string GetQtyCorrectedText()
	{
		return "<s>" + GetQtyText(_product.QtyInit) + "</s> → " + GetQtyText(_product.Qty);
	}
}
