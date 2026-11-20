using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls.Badges;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Extensions;
using Bumptech.Glide.Load;
using JP.Wasabeef.Glide.Transformations;

namespace Auchan.Android.Ecom.Cart;

internal sealed class UnavailableCartItemViewHolder : CachingViewHolder
{
	private readonly View _root;

	private readonly ImageView _favoriteButton;

	private readonly ImageView _logo;

	private readonly TextView _title;

	private readonly BadgesView _badgesView;

	private readonly LinearLayout _salesLayout;

	private readonly ImageView _deleteIcon;

	private readonly View _findReplacement;

	private readonly TextView _findReplacementText;

	private readonly View _adultsOnlyContainer;

	private readonly TextView _adultsOnlyText;

	public UnavailableCartItemViewHolder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public UnavailableCartItemViewHolder(View itemView)
		: base(itemView)
	{
		_root = itemView.RequireViewById<View>(2131296734);
		_favoriteButton = itemView.RequireViewById<ImageView>(2131297148);
		_logo = itemView.RequireViewById<ImageView>(2131296683);
		_title = itemView.RequireViewById<TextView>(2131296685);
		_badgesView = itemView.RequireViewById<BadgesView>(2131296504);
		_salesLayout = itemView.RequireViewById<LinearLayout>(2131298280);
		_deleteIcon = itemView.RequireViewById<ImageView>(2131296691);
		_findReplacement = itemView.RequireViewById<View>(2131297175);
		_findReplacementText = itemView.RequireViewById<TextView>(2131297176);
		_adultsOnlyContainer = itemView.RequireViewById<View>(2131296411);
		_adultsOnlyText = itemView.RequireViewById<TextView>(2131296413);
	}

	public void BindData(CartScreenViewModel viewModel, CartItemUnavailableViewModel item, CompositeDisposable disposable)
	{
		_logo.FromUrlAnimated(item.ImageUrl, (!item.ShouldBlur) ? Array.Empty<ITransformation>() : new ITransformation[1]
		{
			new BlurTransformation(25, 1)
		});
		_title.Text = item.Title;
		_findReplacementText.Text = item.FindReplacementText;
		_adultsOnlyText.Text = item.AdultsOnlyText;
		_badgesView.SetBadges(item.Badges);
		_salesLayout.Visibility = (item.Badges.VisibleItems.Count() > 0).ToVisibility();
		ViewOnClickListener viewOnClickListener = new ViewOnClickListener(delegate(View v)
		{
			OnClick(v, viewModel, item);
		});
		_findReplacement.SetOnClickListener(viewOnClickListener);
		_root.SetOnClickListener(viewOnClickListener);
		_favoriteButton.SetOnClickListener(viewOnClickListener);
		_deleteIcon.SetOnClickListener(viewOnClickListener);
		viewOnClickListener.AddTo(disposable);
		item.FavoritesButtonViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				_favoriteButton.SetBackgroundResource(item.FavoritesButtonViewModel.ProductInFavorites ? 2131231168 : 2131231165);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductInFavorites")),
			(delegate
			{
				_adultsOnlyContainer.Visibility = item.ShouldBlur.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ShouldBlur"))
		})).AddTo(disposable);
	}

	private void OnClick(View view, CartScreenViewModel viewModel, CartItemUnavailableViewModel item)
	{
		if (_favoriteButton.Id == view.Id)
		{
			item.FavoritesButtonViewModel.OnHeartClicked();
		}
		else if (_deleteIcon.Id == view.Id)
		{
			viewModel.OnDeleteUnavailableItem(item).SafeFireAndForget((Action<Exception>)null, false);
		}
		else if (_findReplacement.Id == view.Id)
		{
			viewModel.ShowReplacementsCommand.Trigger(item);
		}
		else
		{
			viewModel.OnUnavailableItemClick(item);
		}
	}
}
