using System;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Extensions;
using Auchan.Common.Managers.Dialogs;
using EBind;

namespace Auchan.Common.Profile.WaitList;

public class SubscribeProductButtonViewModel : BaseItemViewModel
{
	private readonly WaitListProducts _waitListProducts;

	private readonly IWaitListDialogService _waitListDialogService;

	private Product? _product;

	[CompilerGenerated]
	private bool _003CProductInWaitList_003Ek__BackingField;

	public static string ToWaitListText => "В лист ожидания";

	public static string UnsubscribeText => "Отписаться";

	public UICommand ShowPopupCommand { get; } = new UICommand();

	public bool ProductInWaitList
	{
		[CompilerGenerated]
		get
		{
			return _003CProductInWaitList_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CProductInWaitList_003Ek__BackingField != value)
			{
				_003CProductInWaitList_003Ek__BackingField = value;
				RaisePropertyChanged("ProductInWaitList");
			}
		}
	}

	public SubscribeProductButtonViewModel(WaitListProducts waitListProducts, IWaitListDialogService waitListDialogService)
	{
		_waitListProducts = waitListProducts;
		_waitListDialogService = waitListDialogService;
		_waitListProducts.UpdateProductState += new DisposableDelegate<Action<Product>>(IsProductInWaitList, delegate(Action<Product?> h)
		{
			_waitListProducts.UpdateProductState -= h;
		}).AddTo(base.Disposables);
	}

	public SubscribeProductButtonViewModel SetProduct(Product product)
	{
		_product = product;
		ProductInWaitList = product.InWaitList;
		return this;
	}

	public async void OnButtonClicked()
	{
		if (_product == null)
		{
			return;
		}
		if (ProductInWaitList)
		{
			if (await _waitListDialogService.ShowUnsubscribeDialogAsync() == AgreeState.Yes)
			{
				_waitListProducts.Remove(_product);
			}
		}
		else
		{
			_waitListProducts.Add(_product, ShowPopupCommand);
		}
	}

	private void IsProductInWaitList(Product? product)
	{
		if (_product != null && (product == null || product.GimaId == _product.GimaId))
		{
			ProductInWaitList = _waitListProducts.IsProductInWaitList(_product);
		}
	}
}
