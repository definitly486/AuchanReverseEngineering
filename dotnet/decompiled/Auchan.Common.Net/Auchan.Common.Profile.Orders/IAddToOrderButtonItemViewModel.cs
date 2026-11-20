using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Profile.Orders;

public interface IAddToOrderButtonItemViewModel : IBindable, INotifyPropertyChanged, IDisposable
{
	string InfoText { get; }

	string AddToCartButtonText { get; }

	UICommand AddToCartButtonCommand { get; }

	bool IsVisible { get; }

	Task NavigateToOrderDetails();

	void Setup(AddToOrderButtonPlacement placement, IOrderModel? orderModel, UICommand<OrderDetailsViewModel.Parameter>? navigateToOrderDetailsCommand);
}
