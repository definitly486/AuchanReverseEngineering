using System;
using System.ComponentModel;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public interface ICartScreenViewModel : IBindable, INotifyPropertyChanged, IScreenViewModel
{
	bool IsTooManyMarkedGoodsVisible
	{
		get
		{
			throw new NotImplementedException("dead code");
		}
	}

	UICommand<CartItemViewModel> OpenDeleteItemDialogCommand
	{
		get
		{
			throw new NotImplementedException("dead code");
		}
	}

	void OnQtyLabelTap(CartItemViewModel item)
	{
		throw new NotImplementedException("dead code");
	}

	void OnItemClick(CartItemViewModel item)
	{
		throw new NotImplementedException("dead code");
	}

	void RefreshAdultInformers()
	{
		throw new NotImplementedException("dead code");
	}
}
