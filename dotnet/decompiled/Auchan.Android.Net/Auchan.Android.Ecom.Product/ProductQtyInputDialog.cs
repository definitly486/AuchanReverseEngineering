using System;
using Android.Content;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using AndroidX.AppCompat.App;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products.ViewModels;
using Google.Android.Material.TextField;

namespace Auchan.Android.Ecom.Product;

internal sealed class ProductQtyInputDialog
{
	private readonly Lazy<IFullScreenDialogState> _fullScreenDialogState;

	public ProductQtyInputDialog(Lazy<IFullScreenDialogState> fullScreenDialogState)
	{
		_fullScreenDialogState = fullScreenDialogState;
	}

	public void Show(View footer, ProductFooterViewModel viewModel)
	{
		if (!viewModel.ProductInStock)
		{
			return;
		}
		Context context = footer.Context;
		TextInputEditText input;
		if (context != null)
		{
			View view = LayoutInflater.From(context).Inflate(2131492969, null);
			input = view.RequireViewById<TextInputEditText>(2131298129);
			viewModel.OnClearQtyInput();
			input.Text = viewModel.ManualInputQty;
			input.TextChanged += OnTextChanged;
			IDisposable fsd = _fullScreenDialogState.Value.SetVisible();
			DialogInterfaceOnDismissListener dialogInterfaceOnDismissListener = new DialogInterfaceOnDismissListener(delegate
			{
				fsd.Dispose();
				input.TextChanged -= OnTextChanged;
			});
			AlertDialog alertDialog = new AlertDialog.Builder(context).SetTitle(viewModel.QtyDialogTitle).SetMessage(viewModel.ProductTitle).SetPositiveButton(viewModel.QtyDialogDone, async delegate
			{
				await viewModel.OnChangeQtyDoneButtonClick();
			})
				.SetNegativeButton(viewModel.QtyDialogClose, delegate
				{
				})
				.SetView(view)
				.SetOnDismissListener(dialogInterfaceOnDismissListener)
				.SetOnCancelListener(dialogInterfaceOnDismissListener)
				.Create();
			alertDialog.SetCanceledOnTouchOutside(cancel: true);
			alertDialog.Window.SetSoftInputMode(SoftInput.StateVisible);
			alertDialog.ShowCentered();
			input.RequestFocus();
			input.PostDelayed(delegate
			{
				(context.GetSystemService("input_method") as InputMethodManager)?.ShowSoftInput(input, ShowFlags.Implicit);
			}, 200L);
		}
		void OnTextChanged(object? sender, TextChangedEventArgs e)
		{
			if (!(input.Text == viewModel.ManualInputQty))
			{
				viewModel.OnQtyEnteredManually(input.Text);
				input.Text = viewModel.ManualInputQty;
				input.SetSelection(input.Text.Length);
			}
		}
	}
}
