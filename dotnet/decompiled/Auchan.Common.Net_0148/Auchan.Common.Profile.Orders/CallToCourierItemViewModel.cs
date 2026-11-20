using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Orders.Models;
using Microsoft.Maui.ApplicationModel.Communication;

namespace Auchan.Common.Profile.Orders;

internal class CallToCourierItemViewModel : BaseItemViewModel, ICallToCourierItemViewModel, IBindable, INotifyPropertyChanged, IDisposable
{
	private readonly IPhoneDialer _phoneDialer;

	[CompilerGenerated]
	private IListOrderModel? _003COrder_003Ek__BackingField;

	public IListOrderModel? Order
	{
		[CompilerGenerated]
		get
		{
			return _003COrder_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003COrder_003Ek__BackingField, value))
			{
				_003COrder_003Ek__BackingField = value;
				RaisePropertyChanged("IsVisible");
				RaisePropertyChanged("Order");
			}
		}
	}

	public bool IsVisible => !string.IsNullOrEmpty(Order?.CourierNumber);

	public string Text => "Звонок курьеру";

	public UICommand Command { get; } = new UICommand();

	public CallToCourierItemViewModel(IPhoneDialer phoneDialer)
	{
		Command.Subscribe(delegate
		{
			OnCallToCourier();
		}).AddTo(base.Disposables);
		_phoneDialer = phoneDialer;
	}

	private void OnCallToCourier()
	{
		IPhoneDialer phoneDialer = _phoneDialer;
		if (phoneDialer.IsSupported && !string.IsNullOrEmpty(Order?.CourierNumber))
		{
			phoneDialer.Open(Order.CourierNumber);
		}
	}
}
