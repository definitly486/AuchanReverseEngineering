using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Home;

public class WaitListNotificationBanner : BaseItemViewModel
{
	private Product _product = new Product();

	[CompilerGenerated]
	private bool _003CVisible_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CProductCount_003Ek__BackingField;

	public string ImageUrl => _product.ImageUrl ?? _product.MediaUrls?.FirstOrDefault() ?? "";

	public string ProductName => _product.Name ?? _product.Title ?? string.Empty;

	public Action? OnNotificationClicked { get; }

	public bool Visible
	{
		[CompilerGenerated]
		get
		{
			return _003CVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CVisible_003Ek__BackingField != value)
			{
				_003CVisible_003Ek__BackingField = value;
				RaisePropertyChanged("Visible");
			}
		}
	}

	public string ProductCount
	{
		[CompilerGenerated]
		get
		{
			return _003CProductCount_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CProductCount_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CProductCount_003Ek__BackingField = value;
				RaisePropertyChanged("ProductCount");
			}
		}
	} = string.Empty;

	public WaitListNotificationBanner(Action? onNotificationClicked)
	{
		OnNotificationClicked = onNotificationClicked;
	}

	public void ShowOrNot((Product? product, bool required, int productCount) data)
	{
		if (!data.required)
		{
			Visible = false;
			return;
		}
		if (data.product != null)
		{
			(_product, _, _) = data;
		}
		ProductCount = ((data.productCount > 0) ? $"({data.productCount})" : string.Empty);
		Visible = true;
		RaisePropertyChanged("ProductName");
		RaisePropertyChanged("ProductCount");
		RaisePropertyChanged("ImageUrl");
	}

	public void Hide()
	{
		Visible = false;
	}
}
