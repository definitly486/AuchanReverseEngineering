using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reactive.Disposables;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Extensions;

namespace Auchan.Android.Catalog;

internal sealed class ProductItemMiniViewHolder : CachingViewHolder
{
	private readonly ImageView _productImage;

	private readonly LinearLayout _ratingLayout;

	private readonly TextView _ratingTextView;

	private readonly TextView _reviewCountTextView;

	private readonly TextView _titleLabel;

	private readonly ViewGroup _addingBlockView;

	private readonly ConstraintLayout _defaultStateView;

	private readonly TextView _oldPriceLabel;

	private readonly View _oldPriceCrossingLine;

	private readonly TextView _priceLabel;

	private readonly View _actionClickableView;

	private readonly View _addingStateView;

	private readonly AppCompatImageButton _increaseButton;

	private readonly TextView _countLabel;

	private readonly AppCompatImageButton _decreaseButton;

	private readonly TextView _priceSubTotal;

	private readonly HighlightedTextView _hintLabel;

	private readonly ZoomableImageView _productZoomableImage;

	public ProductItemMiniViewHolder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public ProductItemMiniViewHolder(View itemView)
		: base(itemView)
	{
		_productImage = itemView.RequireViewById<ImageView>(2131298011);
		_productZoomableImage = itemView.RequireViewById<ZoomableImageView>(2131298029);
		_ratingLayout = itemView.RequireViewById<LinearLayout>(2131298146);
		_ratingTextView = _ratingLayout.RequireViewById<TextView>(2131298147);
		_reviewCountTextView = _ratingLayout.RequireViewById<TextView>(2131298231);
		_hintLabel = itemView.RequireViewById<HighlightedTextView>(2131297281);
		_priceSubTotal = itemView.RequireViewById<TextView>(2131297991);
		_titleLabel = itemView.RequireViewById<TextView>(2131298655);
		ConstraintLayout constraintLayout = itemView.RequireViewById<ConstraintLayout>(2131297992);
		_addingBlockView = itemView.RequireViewById<ConstraintLayout>(2131296370);
		_defaultStateView = _addingBlockView.RequireViewById<ConstraintLayout>(2131296910);
		_oldPriceLabel = constraintLayout.RequireViewById<TextView>(2131297737);
		_oldPriceCrossingLine = constraintLayout.RequireViewById<View>(2131297735);
		_priceLabel = constraintLayout.RequireViewById<TextView>(2131297988);
		_actionClickableView = _defaultStateView.RequireViewById<View>(2131296326);
		_addingStateView = itemView.RequireViewById<View>(2131296371);
		_increaseButton = _addingStateView.RequireViewById<AppCompatImageButton>(2131297336);
		_countLabel = _addingStateView.RequireViewById<TextView>(2131296857);
		_decreaseButton = _addingStateView.RequireViewById<AppCompatImageButton>(2131296903);
		_hintLabel.DismissImmediate();
	}

	public void BindDataForSmallProduct(IYandexMetricaScreenViewModel screenViewModel, ProductItemViewModel productItemViewModel, CompositeDisposable disposable, UICommand<ProductItemViewModel> showQtyDialogCommand)
	{
		productItemViewModel.ProductWasViewed(screenViewModel);
		_hintLabel.DismissImmediate();
		_productImage.FromUrlAnimated(productItemViewModel.ImageUrl);
		if (productItemViewModel.InStock)
		{
			_productZoomableImage.Setup(_productImage, this, productItemViewModel, disposable);
		}
		_ratingLayout.Visibility = productItemViewModel.HasRating.ToInvisibleVisibility();
		_ratingTextView.Text = productItemViewModel.Rating;
		_reviewCountTextView.Text = productItemViewModel.ReviewsCount;
		_hintLabel.AttributedText = productItemViewModel.NoMoreGoods;
		_titleLabel.Text = productItemViewModel.Name;
		SetPrice(productItemViewModel);
		productItemViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[5]
		{
			(delegate
			{
				_countLabel.Text = productItemViewModel.ItemsInCartCountPresentation;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ItemsInCartCountPresentation")),
			(delegate
			{
				_priceSubTotal.Text = productItemViewModel.SubTotalPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SubTotalPrice")),
			(delegate
			{
				_increaseButton.Selected = !productItemViewModel.CanAdd;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanAdd")),
			(delegate
			{
				_decreaseButton.Selected = !productItemViewModel.CanRemove;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanRemove")),
			(delegate
			{
				ItemsInCartChanged(productItemViewModel.ItemsInCartCount, productItemViewModel.IsChangeQtyVisible);
				OnItemsInCartCountChanged(productItemViewModel.ItemsInCartCount, productItemViewModel.IsChangeQtyVisible);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "IsChangeQtyVisible", "ItemsInCartCount" }))
		})).AddTo(disposable);
		productItemViewModel.BindEvents(_actionClickableView.OnClick((Action)delegate
		{
			productItemViewModel.AddToCart().SafeFireAndForget((Action<Exception>)null, false);
		}), ((View)_increaseButton).OnClick((Action)delegate
		{
			OnIncreaseButtonClicked(productItemViewModel);
		}), ((View)_decreaseButton).OnClick((Action)delegate
		{
			OnDecreaseButtonClicked(productItemViewModel);
		}), _addingStateView.OnClick((Action)delegate
		{
			showQtyDialogCommand.Trigger(productItemViewModel);
		})).AddTo(disposable);
		productItemViewModel.ShowPromoTooltipCommand.SafeSubscribe(delegate(LinkedText t)
		{
			IYandexMetricaScreenViewModel viewModel = screenViewModel;
			ViewGroup addingBlockView = _addingBlockView;
			Size sizeInDp = _addingStateView.GetSizeInDp();
			sizeInDp.Height = 0;
			HintPopup.Show(viewModel, t, addingBlockView, default(Point), atTop: true, checkAnchorVisibility: true, sizeInDp, default(Size), delegate
			{
				productItemViewModel.GotoTooltipLinkCommand.Trigger();
			});
		}, disposable);
	}

	private void OnItemsInCartCountChanged(decimal itemsInCartCount, bool viewModelActionLock)
	{
		if (viewModelActionLock)
		{
			_hintLabel.ShowFor(TimeSpan.FromSeconds(3L));
		}
	}

	private void SetPrice(ProductItemViewModel productItemViewModel)
	{
		_oldPriceLabel.Text = productItemViewModel.OldPrice;
		_priceLabel.Text = productItemViewModel.Price;
		_priceLabel.Visibility = (productItemViewModel.PriceLabelInvisible ? ViewStates.Gone : ViewStates.Visible);
		_oldPriceLabel.Visibility = productItemViewModel.SaleAndInStock.ToVisibility();
		_oldPriceCrossingLine.Visibility = productItemViewModel.SaleAndInStock.ToVisibility();
		if (productItemViewModel.ReceivingMethodNotSelected)
		{
			Stock stock = productItemViewModel.Product.Stock;
			if ((object)stock != null && stock.PriceFrom.HasValue)
			{
				IReadOnlyList<AvailableShop> shops = stock.Shops;
				if (shops != null && shops.Count > 2)
				{
					_oldPriceLabel.Visibility = ViewStates.Gone;
				}
			}
		}
		ConstraintSet constraintSet = new ConstraintSet();
		constraintSet.Clone(_defaultStateView);
		constraintSet.SetVerticalBias(_priceLabel.Id, productItemViewModel.IsSaleActive ? 1f : 0.5f);
		constraintSet.ApplyTo(_defaultStateView);
		constraintSet.Dispose();
	}

	private void ItemsInCartChanged(decimal count, bool viewModelActionLock)
	{
		bool flag = count > 0m;
		_defaultStateView.Visibility = (!flag).ToVisibility();
		_addingStateView.Visibility = flag.ToVisibility();
		if (viewModelActionLock)
		{
			_hintLabel.ShowFor(TimeSpan.FromSeconds(3L));
		}
	}

	private void OnIncreaseButtonClicked(ProductItemViewModel vm)
	{
		if (vm.CanAdd)
		{
			vm.AddOneItemToCart();
		}
		else
		{
			_hintLabel.ShowFor(TimeSpan.FromSeconds(3L));
		}
	}

	private void OnDecreaseButtonClicked(ProductItemViewModel vm)
	{
		if (vm.CanRemove)
		{
			vm.RemoveOneItemFromCart();
		}
	}
}
