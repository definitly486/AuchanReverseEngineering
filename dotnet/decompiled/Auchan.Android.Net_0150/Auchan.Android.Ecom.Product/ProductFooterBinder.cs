using System;
using System.Collections.Generic;
using System.Drawing;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Profile.WaitList;
using Google.Android.Material.Button;

namespace Auchan.Android.Ecom.Product;

internal sealed class ProductFooterBinder
{
	private sealed class Controls
	{
		public View AddingStateView { get; } = footer.RequireViewById<View>(2131296371);

		public View SuggestionAnchor { get; } = footer.RequireViewById<View>(2131298567);

		public MaterialButton AddToCartButton { get; } = footer.RequireViewById<MaterialButton>(2131296326);

		public AppCompatImageButton DecreaseButton { get; } = footer.RequireViewById<AppCompatImageButton>(2131296903);

		public AppCompatImageButton IncreaseButton { get; } = footer.RequireViewById<AppCompatImageButton>(2131297336);

		public TextView CountLabel { get; } = footer.RequireViewById<TextView>(2131296857);

		public TextView TotalCostLabel { get; } = footer.RequireViewById<TextView>(2131298733);

		public View CostAndEconomyLayout { get; } = footer.RequireViewById<View>(2131296851);

		public ViewGroup EconomyLayout { get; } = footer.RequireViewById<ViewGroup>(2131297032);

		public TextView EconomyLabel { get; } = footer.RequireViewById<TextView>(2131297031);

		public TextView EconomyText { get; } = footer.RequireViewById<TextView>(2131297033);

		public View PriceLayout { get; } = footer.RequireViewById<View>(2131297978);

		public TextView PriceTextView { get; } = footer.RequireViewById<TextView>(2131297983);

		public View DiscountLayout { get; } = footer.RequireViewById<View>(2131296992);

		public TextView DiscountTextView { get; } = footer.RequireViewById<TextView>(2131296993);

		public View OldPriceLayout { get; } = footer.RequireViewById<View>(2131297733);

		public TextView OldPriceTextView { get; } = footer.RequireViewById<TextView>(2131297734);

		public View SubscribeProductButtonBackground { get; } = footer.RequireViewById<View>(2131298555);

		public AppCompatButton SubscribeProductButton { get; } = footer.RequireViewById<AppCompatButton>(2131298557);

		public TextView NotifyWhenGoodsArriveLabel { get; } = footer.RequireViewById<TextView>(2131297716);

		public HighlightedTextView Tooltip { get; } = footer.RequireViewById<HighlightedTextView>(2131298701);

		public Controls(View footer)
		{
		}
	}

	private readonly ProductQtyInputDialog _qtyInputDialog;

	public ProductFooterBinder(ProductQtyInputDialog qtyInputDialog)
	{
		_qtyInputDialog = qtyInputDialog;
	}

	public void Bind(ProductFooterViewModel viewModel, View footer, ILifecycleOwner lifecycleOwner, IScreenViewModel screenViewModel)
	{
		Controls controls = new Controls(footer);
		controls.EconomyLabel.Text = viewModel.EconomyText;
		controls.Tooltip.DismissImmediate();
		viewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[21]
		{
			(delegate
			{
				controls.PriceTextView.Text = viewModel.Price;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Price")),
			(delegate
			{
				controls.PriceLayout.Visibility = (!viewModel.IsCostAndEconomyVisible).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCostAndEconomyVisible")),
			(delegate
			{
				controls.OldPriceTextView.Text = viewModel.OldPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OldPrice")),
			(delegate
			{
				controls.OldPriceLayout.Visibility = viewModel.IsSaleActive.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSaleActive")),
			(delegate
			{
				controls.DiscountTextView.Text = viewModel.DiscountValue;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DiscountValue")),
			(delegate
			{
				controls.DiscountLayout.Visibility = viewModel.IsDiscountBadgeVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsDiscountBadgeVisible")),
			(delegate
			{
				controls.CostAndEconomyLayout.Visibility = viewModel.IsCostAndEconomyVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCostAndEconomyVisible")),
			(delegate
			{
				controls.TotalCostLabel.Text = viewModel.TotalPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalPrice")),
			(delegate
			{
				controls.EconomyText.Text = viewModel.EconomyAmountText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EconomyAmountText")),
			(delegate
			{
				controls.EconomyLayout.Visibility = viewModel.EconomyVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EconomyVisible")),
			(delegate
			{
				controls.CountLabel.Text = viewModel.ItemsInCartCountPresentation;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ItemsInCartCountPresentation")),
			(delegate
			{
				controls.AddingStateView.Visibility = (viewModel.CanRemove && viewModel.ProductInStock).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "CanRemove", "ProductInStock" })),
			(delegate
			{
				controls.AddToCartButton.Visibility = (!viewModel.CanRemove && viewModel.ProductInStock).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "CanRemove", "ProductInStock" })),
			(delegate
			{
				controls.AddToCartButton.Text = viewModel.ToCartText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ToCartText")),
			(delegate
			{
				controls.AddToCartButton.Activated = viewModel.IsAddToCartButtonHighlighted;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAddToCartButtonHighlighted")),
			(delegate
			{
				controls.AddToCartButton.SetTextSize(ComplexUnitType.Sp, viewModel.CanRemove ? 16 : 14);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanRemove")),
			(delegate
			{
				controls.DecreaseButton.Selected = !viewModel.CanRemove;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanRemove")),
			(delegate
			{
				controls.IncreaseButton.Selected = !viewModel.CanAddToCart;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanAddToCart")),
			(delegate
			{
				AppCompatButton subscribeProductButton = controls.SubscribeProductButton;
				ViewStates visibility = (controls.SubscribeProductButtonBackground.Visibility = (!viewModel.ProductInStock).ToVisibility());
				subscribeProductButton.Visibility = visibility;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductInStock")),
			(delegate
			{
				controls.NotifyWhenGoodsArriveLabel.Text = viewModel.NotifyWhenGoodsArriveText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NotifyWhenGoodsArriveText")),
			(delegate
			{
				controls.NotifyWhenGoodsArriveLabel.Visibility = IsNotifyLabelVisible(viewModel).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductInStock"))
		})).AutoDisposeOnDestroy(lifecycleOwner);
		viewModel.WaitListButtonViewModel.ShowPopupCommand.SafeSubscribe(delegate
		{
			WaitListButtonPopup.Show(controls.SubscribeProductButton);
		}, lifecycleOwner);
		viewModel.WaitListButtonViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				controls.SubscribeProductButton.Text = (viewModel.WaitListButtonViewModel.ProductInWaitList ? "Отписаться" : "В лист ожидания");
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductInWaitList")),
			(delegate
			{
				controls.NotifyWhenGoodsArriveLabel.Visibility = IsNotifyLabelVisible(viewModel).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductInWaitList"))
		})).AutoDisposeOnDestroy(lifecycleOwner);
		viewModel.BindEvents(controls.SubscribeProductButton.OnClick(viewModel.WaitListButtonViewModel.OnButtonClicked), controls.AddToCartButton.OnClick(viewModel.AddToCart), controls.IncreaseButton.OnClick(viewModel.AddOneItemToCart), controls.DecreaseButton.OnClick(viewModel.RemoveOneItemFromCart), controls.AddingStateView.OnClick(viewModel.ShowQtyDialogCommand.Trigger)).AutoDisposeOnDestroy(lifecycleOwner);
		viewModel.ShowTooltipCommand.SafeSubscribe(controls.Tooltip.ShowOrHideAuto, lifecycleOwner);
		viewModel.ShowQtyDialogCommand.SafeSubscribe(delegate
		{
			_qtyInputDialog.Show(footer, viewModel);
		}, lifecycleOwner);
		viewModel.ShowPromoTooltipCommand.SafeSubscribe(delegate(LinkedText t)
		{
			IScreenViewModel viewModel2 = screenViewModel;
			View suggestionAnchor = controls.SuggestionAnchor;
			System.Drawing.Size sizeInDp = controls.SuggestionAnchor.GetSizeInDp();
			sizeInDp.Height = 0;
			HintPopup.Show(viewModel2, t, suggestionAnchor, default(Point), atTop: true, checkAnchorVisibility: false, sizeInDp, default(System.Drawing.Size), delegate
			{
				viewModel.GotoTooltipLinkCommand.Trigger();
			});
		}, lifecycleOwner);
	}

	private static bool IsNotifyLabelVisible(ProductFooterViewModel viewModel)
	{
		SubscribeProductButtonViewModel waitListButtonViewModel = viewModel.WaitListButtonViewModel;
		if (waitListButtonViewModel != null && waitListButtonViewModel.ProductInWaitList)
		{
			return !viewModel.ProductInStock;
		}
		return false;
	}
}
