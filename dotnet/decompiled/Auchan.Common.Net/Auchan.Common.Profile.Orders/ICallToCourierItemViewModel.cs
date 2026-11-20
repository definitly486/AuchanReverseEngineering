using System;
using System.ComponentModel;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Profile.Orders;

public interface ICallToCourierItemViewModel : IBindable, INotifyPropertyChanged, IDisposable
{
	UICommand Command { get; }

	bool IsVisible { get; }

	string Text { get; }

	IListOrderModel? Order { get; set; }
}
