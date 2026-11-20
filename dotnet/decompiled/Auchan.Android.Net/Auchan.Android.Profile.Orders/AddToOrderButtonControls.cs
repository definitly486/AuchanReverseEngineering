using System;
using Android.Views;
using Android.Widget;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Profile.Orders;

namespace Auchan.Android.Profile.Orders;

internal sealed class AddToOrderButtonControls(View view)
{
	public IDisposable Setup(IAddToOrderButtonItemViewModel viewModel)
	{
		View view = view.RequireViewById<View>(2131296785);
		TextView textView = view.RequireViewById<TextView>(2131296348);
		TextView textView2 = view.RequireViewById<TextView>(2131296349);
		textView.Text = viewModel.InfoText;
		textView2.Text = viewModel.AddToCartButtonText;
		view.Visibility = viewModel.IsVisible.ToVisibility();
		return viewModel.BindEvents(viewModel.OnPropertyChanged("IsVisible", delegate
		{
			view.Visibility = viewModel.IsVisible.ToVisibility();
		}), view.OnClick((Action)delegate
		{
			viewModel.NavigateToOrderDetails();
		}), ((View)textView2).OnClick((Action)delegate
		{
			viewModel.AddToCartButtonCommand.Trigger();
		}));
	}
}
