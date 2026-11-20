using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reactive.Disposables;
using Android.App;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Controls.Badges;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Extensions;
using Bumptech.Glide.Load;
using Google.Android.Material.TextField;
using JP.Wasabeef.Glide.Transformations;

namespace Auchan.Android.Ecom.Cart;

internal sealed class CartItemViewHolder : CachingViewHolder
{
	private readonly IInputFilter[] _inputFilterArray = new IInputFilter[1]
	{
		new InputFilterLengthFilter(255)
	};

	private readonly ConstraintLayout _root;

	private readonly ImageView _favoriteButton;

	private readonly ImageView _logo;

	private readonly CompoundButton _itemSelected;

	private readonly TextView _title;

	private readonly TextView _oldPrice;

	private readonly View _oldPriceCrossingLine;

	private readonly TextView _price;

	private readonly TextView _pricePerItem;

	private readonly TextView _discountEndDate;

	private readonly TextView _discountByLoyaltyProgram;

	private readonly View _cartIncDecLayout;

	private readonly ImageButton _increaseButton;

	private readonly ImageButton _decreaseButton;

	private readonly TextView _itemCount;

	private readonly RecyclerView _modificationsList;

	private readonly BadgesView _badgesView;

	private readonly LinearLayout _salesLayout;

	private readonly View _commentLayout;

	private readonly View _commentDefaultLayout;

	private readonly ImageView _commentCheckbox;

	private readonly TextView _commentCheckboxTitle;

	private readonly TextInputLayout _commentInputLayout;

	private readonly TextInputEditText _commentInput;

	private readonly View _commentProgressView;

	private readonly ImageView _deleteIcon;

	private readonly AdultsOnlyControls _adultsOnlyControls;

	private readonly View _markedProductCardView;

	private readonly TextView _markedProductTextView;

	private bool _isSavingComment;

	public CartItemViewHolder(View itemView)
		: base(itemView)
	{
		_root = itemView.RequireViewById<ConstraintLayout>(2131296734);
		_favoriteButton = itemView.RequireViewById<ImageView>(2131297148);
		_logo = itemView.RequireViewById<ImageView>(2131296683);
		_itemSelected = itemView.RequireViewById<CompoundButton>(2131297387);
		_title = itemView.RequireViewById<TextView>(2131296685);
		_oldPrice = itemView.RequireViewById<TextView>(2131297737);
		_oldPriceCrossingLine = itemView.RequireViewById<View>(2131297735);
		_price = itemView.RequireViewById<TextView>(2131296684);
		_pricePerItem = itemView.RequireViewById<TextView>(2131296686);
		_discountEndDate = itemView.RequireViewById<TextView>(2131296996);
		_discountByLoyaltyProgram = itemView.RequireViewById<TextView>(2131296995);
		_cartIncDecLayout = itemView.RequireViewById<View>(2131296680);
		_increaseButton = itemView.RequireViewById<ImageButton>(2131296681);
		_decreaseButton = itemView.RequireViewById<ImageButton>(2131296678);
		_itemCount = itemView.RequireViewById<TextView>(2131296682);
		_modificationsList = itemView.RequireViewById<RecyclerView>(2131297585);
		_badgesView = itemView.RequireViewById<BadgesView>(2131296504);
		_salesLayout = itemView.RequireViewById<LinearLayout>(2131298280);
		_commentLayout = itemView.RequireViewById<View>(2131296827);
		_commentDefaultLayout = itemView.RequireViewById<View>(2131296824);
		_commentCheckbox = itemView.RequireViewById<ImageView>(2131296768);
		_commentCheckboxTitle = itemView.RequireViewById<TextView>(2131296771);
		_commentInputLayout = itemView.RequireViewById<TextInputLayout>(2131296826);
		_commentInput = itemView.RequireViewById<TextInputEditText>(2131296825);
		_commentProgressView = itemView.RequireViewById<View>(2131296828);
		_deleteIcon = itemView.RequireViewById<ImageView>(2131296691);
		_adultsOnlyControls = new AdultsOnlyControls(itemView.RequireViewById<View>(2131296411));
		_markedProductCardView = itemView.RequireViewById<View>(2131297522);
		_markedProductTextView = itemView.RequireViewById<TextView>(2131297523);
	}

	public void BindData(CartItemViewModel item, LinearLayoutWithClickIntercept mainLayout, CompositeDisposable disposable)
	{
		bool flag = item.ProductSelectedModifications.Count > 0;
		if (flag)
		{
			ObservableRecyclerAdapter<SelectedModification, CachingViewHolder> observableRecyclerAdapter = _modificationsList.GetAdapter() as ObservableRecyclerAdapter<SelectedModification, CachingViewHolder>;
			if (observableRecyclerAdapter == null)
			{
				observableRecyclerAdapter = new ObservableRecyclerAdapter<SelectedModification, CachingViewHolder>
				{
					CellLayoutId = 2131493220,
					BindViewHolderDelegate = OnBindModification
				};
				_modificationsList.SetLayoutManager(new LinearLayoutManager(Application.Context, 1, reverseLayout: false));
				_modificationsList.SetAdapter(observableRecyclerAdapter);
			}
			observableRecyclerAdapter.DataSource = item.ProductSelectedModifications;
		}
		_modificationsList.Visibility = flag.ToVisibility();
		_commentLayout.Visibility = item.IsCommentAvailable.ToVisibility();
		_logo.FromUrlAnimated(item.ImageUrl, (!item.ShouldBlur) ? Array.Empty<ITransformation>() : new ITransformation[1]
		{
			new BlurTransformation(25, 1)
		});
		_title.Text = item.Title;
		_discountByLoyaltyProgram.Text = item.ByLoyaltyProgramText;
		_markedProductTextView.Text = item.MarkedProductText;
		_commentCheckboxTitle.Text = item.CheckboxTitle;
		_commentInput.SetFilters(_inputFilterArray);
		_commentInputLayout.SetEndIconOnClickListener(new ViewOnClickListener(OnEndIconClicked));
		item.FavoritesButtonViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			_favoriteButton.SetBackgroundResource(item.FavoritesButtonViewModel.ProductInFavorites ? 2131231168 : 2131231165);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductInFavorites")))).AddTo(disposable);
		item.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[15]
		{
			(delegate
			{
				_pricePerItem.Text = item.ItemPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ItemPrice")),
			(delegate
			{
				_discountEndDate.Text = item.DiscountEndDate;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DiscountEndDate")),
			(delegate
			{
				_discountEndDate.Visibility = item.IsSaleActive.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSaleActive")),
			(delegate
			{
				_discountByLoyaltyProgram.Visibility = item.IsLoyaltyProgramDiscount.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsLoyaltyProgramDiscount")),
			(delegate
			{
				_badgesView.SetBadges(item.Badges);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Badges")),
			(delegate
			{
				_salesLayout.Visibility = item.IsBadgesVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsBadgesVisible")),
			(delegate
			{
				_commentInput.ApplyText(item.CommentInput);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CommentInput")),
			(delegate
			{
				SwitchState(item.CommentState);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CommentState")),
			(delegate
			{
				_price.Text = item.TotalPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalPrice")),
			(delegate
			{
				_oldPrice.Text = item.OldPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OldPrice")),
			(delegate
			{
				TextView oldPrice = _oldPrice;
				ViewStates visibility = (_oldPriceCrossingLine.Visibility = item.IsOldPriceVisible.ToVisibility());
				oldPrice.Visibility = visibility;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsOldPriceVisible")),
			(delegate
			{
				_itemCount.Text = item.Qty;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Qty")),
			(delegate
			{
				_increaseButton.Enabled = item.IncreaseEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IncreaseEnabled")),
			(delegate
			{
				_commentInput.SetText(item.Comment, TextView.BufferType.Editable);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Comment")),
			(delegate
			{
				_itemSelected.Checked = item.IsSelected;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSelected"))
		})).AddTo(disposable);
		item.ShowPromoTooltipCommand.SafeSubscribe(delegate(LinkedText t)
		{
			ICartScreenViewModel parent = item.Parent;
			View cartIncDecLayout = _cartIncDecLayout;
			Size sizeInDp = _cartIncDecLayout.GetSizeInDp();
			sizeInDp.Height = 0;
			IDisposable dismissHandle = HintPopup.Show(parent, t, cartIncDecLayout, default(Point), atTop: true, checkAnchorVisibility: true, sizeInDp, default(Size), delegate
			{
				item.GotoTooltipLinkCommand.Trigger();
			});
			item.HintPopupShown(dismissHandle);
		}, disposable);
		item.Parent.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			_markedProductCardView.Visibility = item.IsMarkedProduct.ToVisibility();
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsTooManyMarkedGoodsVisible")))).AddTo(disposable);
		_adultsOnlyControls.Setup(item, disposable);
		item.BindEvents(((View)_itemSelected).OnClick((Action)delegate
		{
			item.SetSelected(!item.IsSelected).SafeFireAndForget((Action<Exception>)null, false);
		}), mainLayout.OnClickIntercepted(OnMainLayoutClickIntercepted), ((TextView)_commentInput).OnEditorAction((Action)delegate
		{
			_isSavingComment = true;
			item.SaveCommentCommand.Trigger();
			_commentInput.ForceUnfocusKeyboard();
			_isSavingComment = false;
		}), ((TextView)_commentInput).OnAfterTextChanged((Action)delegate
		{
			item.CommentInput = _commentInput.Text ?? string.Empty;
		}), _commentInput.OnFocusChange(delegate(object? o, View.FocusChangeEventArgs e)
		{
			if (!e.HasFocus && !_isSavingComment)
			{
				if (string.IsNullOrWhiteSpace(item.Comment))
				{
					item.ResetCommentChanges();
				}
				_commentInput.ForceUnfocusKeyboard();
			}
		}), ((View)_favoriteButton).OnClick((Action)delegate
		{
			item.FavoritesButtonViewModel.OnHeartClicked();
		}), ((View)_itemCount).OnClick((Action)delegate
		{
			item.Parent.OnQtyLabelTap(item);
		}), ((View)_increaseButton).OnClick((Action)delegate
		{
			item.OnIncrease();
		}), ((View)_decreaseButton).OnClick((Action)delegate
		{
			item.OnDecrease();
		}), ((View)_deleteIcon).OnClick((Action)delegate
		{
			item.Parent.OpenDeleteItemDialogCommand.Trigger(item);
		}), ((View)_commentCheckbox).OnClick((Action)delegate
		{
			item.OpenCommentInput();
			_commentInput.ShowKeyboardForced(ShowFlags.Forced);
		}), ((View)_root).OnClick((Action)delegate
		{
			item.Parent.OnItemClick(item);
		})).AddTo(disposable);
		void OnEndIconClicked(View _)
		{
			item.DeleteComment();
			_commentInput.ForceUnfocusKeyboard();
		}
		void OnMainLayoutClickIntercepted(MotionEvent ev)
		{
			if (_commentInput.HasFocus)
			{
				int x = (int)ev.RawX;
				int y = (int)ev.RawY;
				if (!_root.ScreenVisibleRect().Contains(x, y))
				{
					item.ResetCommentChanges();
					_commentInput.ForceUnfocusKeyboard();
				}
			}
		}
	}

	private void SwitchState(CartItemViewModel.CommentVisualState commentState)
	{
		if (commentState == CartItemViewModel.CommentVisualState.Default)
		{
			_commentDefaultLayout.Visibility = ViewStates.Visible;
			_commentInputLayout.Visibility = ViewStates.Gone;
			_commentProgressView.Visibility = ViewStates.Gone;
		}
		if (commentState == CartItemViewModel.CommentVisualState.Input)
		{
			_commentInputLayout.Visibility = ViewStates.Visible;
			_commentDefaultLayout.Visibility = ViewStates.Gone;
			_commentProgressView.Visibility = ViewStates.Gone;
		}
		if (commentState == CartItemViewModel.CommentVisualState.InProgress)
		{
			_commentProgressView.Visibility = ViewStates.Visible;
			_commentInputLayout.Visibility = ViewStates.Gone;
			_commentDefaultLayout.Visibility = ViewStates.Gone;
		}
	}

	private void OnBindModification(CachingViewHolder vh, SelectedModification selectedModification, int pos, CompositeDisposable disposable)
	{
		TextView textView = vh.RequireCachedView<TextView>(2131297434);
		TextView textView2 = vh.RequireCachedView<TextView>(2131297435);
		textView.Text = selectedModification.Name + ": ";
		textView2.Text = selectedModification.Value?.Description ?? string.Empty;
	}
}
