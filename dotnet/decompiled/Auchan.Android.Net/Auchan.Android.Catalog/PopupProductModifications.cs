using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Android.Content.Res;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products.Modifications;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Google.Android.Material.Button;
using Google.Flexbox;

namespace Auchan.Android.Catalog;

internal class PopupProductModifications : BaseBottomSheetDialogFragment<PopupModificationsViewModel>
{
	protected override int LayoutId => 2131493463;

	public override int Theme => 2131951914;

	public PopupProductModifications(Func<PopupModificationsViewModel.Parameter, PopupModificationsViewModel> newViewModel)
		: base((Func<Fragment, PopupModificationsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<PopupModificationsViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		View view2 = view.RequireViewById<View>(2131296795);
		TextView textView = view.RequireViewById<TextView>(2131297586);
		ImageView imageView = view.RequireViewById<ImageView>(2131297587);
		TextView textView2 = view.RequireViewById<TextView>(2131297588);
		TextView textView3 = view.RequireViewById<TextView>(2131297862);
		TextView countLabel = view.RequireViewById<TextView>(2131296857);
		View addingStateView = view.RequireViewById<View>(2131296371);
		MaterialButton actionClickableButton = view.RequireViewById<MaterialButton>(2131296326);
		AppCompatImageButton decreaseButton = view.RequireViewById<AppCompatImageButton>(2131296903);
		AppCompatImageButton increaseButton = view.RequireViewById<AppCompatImageButton>(2131297336);
		SnackView warningLayout = view.RequireViewById<SnackView>(2131296558);
		HighlightedTextView tooltip = view.RequireViewById<HighlightedTextView>(2131298701);
		TextView totalCostLabel = view.RequireViewById<TextView>(2131298733);
		ImageView favoritesButton = view.RequireViewById<ImageView>(2131297148);
		View suggestionAnchor = view.RequireViewById<View>(2131298567);
		textView.Text = base.ViewModel.ProductName;
		textView2.Text = base.ViewModel.ProductPrice;
		textView3.Text = base.ViewModel.PerUnitAlias;
		warningLayout.Text = base.ViewModel.WarningMessage;
		imageView.FromUrl(base.ViewModel.PreviewPath);
		tooltip.DismissImmediate();
		ConfigureModifications(view);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[10]
		{
			(delegate
			{
				addingStateView.Visibility = base.ViewModel.CanRemove.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanRemove")),
			(delegate
			{
				warningLayout.Visibility = base.ViewModel.IsWarningVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsWarningVisible")),
			(delegate
			{
				actionClickableButton.Text = base.ViewModel.CartButtonText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CartButtonText")),
			(delegate
			{
				countLabel.Text = base.ViewModel.QtyCartText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("QtyCartText")),
			(delegate
			{
				decreaseButton.Selected = !base.ViewModel.CanRemove;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanRemove")),
			(delegate
			{
				increaseButton.Selected = !base.ViewModel.CanAddToCart;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanAddToCart")),
			(delegate
			{
				actionClickableButton.Activated = base.ViewModel.IsAddToCartButtonHighlighted;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAddToCartButtonHighlighted")),
			(delegate
			{
				actionClickableButton.Visibility = (!base.ViewModel.CanRemove).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanRemove")),
			(delegate
			{
				actionClickableButton.SetTextSize(ComplexUnitType.Sp, base.ViewModel.CanRemove ? 16 : 14);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanRemove")),
			(delegate
			{
				totalCostLabel.Text = base.ViewModel.TotalPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalPrice"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.FavoritesButtonViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			favoritesButton.SetImageResource(base.ViewModel.FavoritesButtonViewModel.ProductInFavorites ? 2131231168 : 2131231165);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductInFavorites")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(view2.OnClick(Dismiss), decreaseButton.OnClick(base.ViewModel.RemoveOneItemFromCart), increaseButton.OnClick(base.ViewModel.AddOneItemToCart), actionClickableButton.OnClick(base.ViewModel.AddOneItemToCart), ((View)favoritesButton).OnClick((Action)delegate
		{
			base.ViewModel.FavoritesButtonViewModel.OnHeartClicked();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.ShowTooltipCommand.SafeSubscribe(delegate(AttributedText t)
		{
			tooltip.ShowOrHideAuto(t);
		}, ViewLifecycleOwner);
		base.ViewModel.ShowPromoTooltipCommand.SafeSubscribe(delegate(LinkedText t)
		{
			PopupModificationsViewModel viewModel = base.ViewModel;
			View anchor = suggestionAnchor;
			System.Drawing.Size sizeInDp = suggestionAnchor.GetSizeInDp();
			sizeInDp.Height = 0;
			HintPopup.Show(viewModel, t, anchor, default(Point), atTop: true, checkAnchorVisibility: false, sizeInDp, default(System.Drawing.Size), delegate
			{
				base.ViewModel.GotoTooltipLinkCommand.Trigger();
			});
		}, ViewLifecycleOwner);
	}

	private void ConfigureModifications(View view)
	{
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131297585);
		ObservableRecyclerAdapter<IModificationItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<IModificationItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493295,
			BindViewHolderDelegate = OnBindPicker,
			DataSource = base.ViewModel.Modifications
		};
		recyclerView.SetAdapter(adapter);
		recyclerView.SetLayoutManager(new LinearLayoutManager(Context, 1, reverseLayout: false));
	}

	private void OnBindPicker(CachingViewHolder vh, IModificationItemViewModel vm, int position, CompositeDisposable disposable)
	{
		switch (vm.Modification.ViewType)
		{
		case ModificationValueType.Enum:
			BindPicker(vh, vm, disposable, 2131493255, delegate(CachingViewHolder itemVh, ModificationValueViewModel itemVm, int _, CompositeDisposable itemDisposables)
			{
				OnBindEnumModification(vm, itemVh, itemVm, itemDisposables);
			});
			break;
		case ModificationValueType.Image_picker:
			BindPicker(vh, vm, disposable, 2131493256, delegate(CachingViewHolder itemVh, ModificationValueViewModel itemVm, int _, CompositeDisposable itemDisposables)
			{
				OnBindImageModification(vm, itemVh, itemVm, itemDisposables);
			});
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private void BindPicker(CachingViewHolder vh, IModificationItemViewModel vm, CompositeDisposable disposable, int cellLayoutId, Action<CachingViewHolder, ModificationValueViewModel, int, CompositeDisposable> bindViewHolderDelegate)
	{
		TextView modificationNameTextView = vh.RequireCachedView<TextView>(2131297893);
		TextView modificationValueTextView = vh.RequireCachedView<TextView>(2131298339);
		RecyclerView recyclerView = vh.RequireCachedView<RecyclerView>(2131297585);
		ColorStateList originalValueColor = modificationValueTextView.TextColors;
		ObservableRecyclerAdapter<ModificationValueViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<ModificationValueViewModel, CachingViewHolder>
		{
			CellLayoutId = cellLayoutId,
			BindViewHolderDelegate = bindViewHolderDelegate,
			DataSource = vm.Values
		};
		recyclerView.SetAdapter(adapter);
		recyclerView.SetLayoutManager(new FlexboxLayoutManager(Context)
		{
			FlexDirection = 0,
			JustifyContent = 0
		});
		vm.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				modificationNameTextView.Text = vm.ModificationTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ModificationTitle")),
			(delegate
			{
				SetModificationValueText();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[3] { "IsValueSelected", "ModificationHint", "ModificationValue" })),
			(delegate
			{
				SetModificationValueColor();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsValueSelected"))
		})).AddTo(disposable);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				SetModificationValueText();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsWarningVisible")),
			(delegate
			{
				SetModificationValueColor();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsWarningVisible"))
		})).AddTo(disposable);
		void SetModificationValueColor()
		{
			modificationValueTextView.SetTextColor((base.ViewModel.IsWarningVisible && !vm.IsValueSelected) ? ContextCompat.GetColorStateList(Context, 2131100557) : originalValueColor);
		}
		void SetModificationValueText()
		{
			modificationValueTextView.Text = ((base.ViewModel.IsWarningVisible && !vm.IsValueSelected) ? vm.ModificationHint : vm.ModificationValue);
		}
	}

	private void OnBindEnumModification(IModificationItemViewModel parentPickerVm, CachingViewHolder vh, ModificationValueViewModel vm, CompositeDisposable disposables)
	{
		View itemView = vh.ItemView;
		TextView textView = vh.RequireCachedView<TextView>(2131297583);
		View card = vh.RequireCachedView<View>(2131297584);
		textView.Text = vm.Text;
		card.Activated = true;
		vm.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			card.Selected = vm.Selected;
			card.Activated = !vm.Selected;
			card.Hovered = false;
			card.Invalidate();
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposables);
		vm.OnSelect.ObserveOn(MainThread.Scheduler).Subscribe(delegate(ModificationValueViewModel selected)
		{
			parentPickerVm.OnSelectValue(selected);
			base.ViewModel.WriteSelected(parentPickerVm, selected);
		}).AddTo(disposables);
		itemView.OnClick(vm.Tap).AddTo(disposables);
	}

	private void OnBindImageModification(IModificationItemViewModel parentPickerVm, CachingViewHolder vh, ModificationValueViewModel vm, CompositeDisposable disposable)
	{
		ImageView imageView = vh.RequireCachedView<ImageView>(2131297581);
		View card = vh.RequireCachedView<View>(2131297582);
		if (!string.IsNullOrEmpty(vm.Preview))
		{
			imageView.FromUrl(vm.Preview);
		}
		card.Activated = true;
		vm.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			card.Selected = vm.Selected;
			card.Activated = !vm.Selected;
			card.Hovered = false;
			card.Invalidate();
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposable);
		vm.OnSelect.ObserveOn(MainThread.Scheduler).Subscribe(delegate(ModificationValueViewModel selected)
		{
			parentPickerVm.OnSelectValue(selected);
			base.ViewModel.WriteSelected(parentPickerVm, selected);
		}).AddTo(disposable);
		imageView.OnClick(vm.Tap).AddTo(disposable);
	}
}
