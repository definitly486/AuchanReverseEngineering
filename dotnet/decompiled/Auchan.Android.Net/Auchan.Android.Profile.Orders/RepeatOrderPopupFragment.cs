using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Orders;
using Auchan.Common.Profile.Orders.Models;
using Google.Android.Material.Button;
using Google.Android.Material.TextField;

namespace Auchan.Android.Profile.Orders;

internal sealed class RepeatOrderPopupFragment : BaseBottomSheetDialogFragment<RepeatOrderPopupViewModel>
{
	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493488;

	public RepeatOrderPopupFragment(Func<BrokerToken, RepeatOrderPopupViewModel> newViewModel)
		: base((Func<AndroidX.Fragment.App.Fragment, RepeatOrderPopupViewModel>)((AndroidX.Fragment.App.Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView title = view.RequireViewById<TextView>(2131298646);
		ImageView closeButton = view.RequireViewById<ImageView>(2131296789);
		SnackView info = view.RequireViewById<SnackView>(2131297362);
		AppCompatCheckBox checkBox = view.RequireViewById<AppCompatCheckBox>(2131296768);
		TextView selectAllLabel = view.RequireViewById<TextView>(2131298329);
		TextView countText = view.RequireViewById<TextView>(2131296858);
		View headerSeparator = view.RequireViewById<View>(2131298714);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131298188);
		TextView total = view.RequireViewById<TextView>(2131298720);
		MaterialButton addToCartButton = view.RequireViewById<MaterialButton>(2131296359);
		View footerSeparator = view.RequireViewById<View>(2131297213);
		checkBox.SetOnClickListener(new ViewOnClickListener((Action)delegate
		{
			base.ViewModel.SelectAllItems(checkBox.Checked);
		}).AutoDisposeOnDestroy(ViewLifecycleOwner));
		ObservableRecyclerAdapter<RepeatOrderProductItemViewModel, CachingViewHolder> observableRecyclerAdapter = new ObservableRecyclerAdapter<RepeatOrderProductItemViewModel, CachingViewHolder>
		{
			DataSource = base.ViewModel.Available,
			CellLayoutId = 2131493317,
			BindViewHolderDelegate = OnBindItem
		};
		ObservableRecyclerAdapter<RepeatOrderProductItemViewModel, CachingViewHolder> observableRecyclerAdapter2 = new ObservableRecyclerAdapter<RepeatOrderProductItemViewModel, CachingViewHolder>
		{
			DataSource = base.ViewModel.Unavailable,
			CellLayoutId = 2131493318,
			BindViewHolderDelegate = OnBindUnavailableItem
		};
		recyclerView.SetAdapter(new ConcatAdapter(observableRecyclerAdapter, observableRecyclerAdapter2));
		ViewOnClickListener onClickListener = new ViewOnClickListener(delegate(View v)
		{
			if (closeButton.Id == v.Id)
			{
				base.ViewModel.Dismiss();
			}
			else if (addToCartButton.Id == v.Id)
			{
				base.ViewModel.AddToCart();
			}
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		closeButton.SetOnClickListener(onClickListener);
		addToCartButton.SetOnClickListener(onClickListener);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[11]
		{
			(delegate
			{
				title.Text = base.ViewModel.TitleText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TitleText")),
			(delegate
			{
				info.Text = base.ViewModel.InfoText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("InfoText")),
			(delegate
			{
				info.Visibility = base.ViewModel.InfoVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("InfoVisible")),
			(delegate
			{
				ViewStates visibility = (!base.ViewModel.UnavailableOnly).ToVisibility();
				checkBox.Visibility = visibility;
				selectAllLabel.Visibility = visibility;
				headerSeparator.Visibility = visibility;
				footerSeparator.Visibility = visibility;
				addToCartButton.Visibility = visibility;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("UnavailableOnly")),
			(delegate
			{
				total.Visibility = (!base.ViewModel.UnavailableOnly && !base.ViewModel.NoSelected).ToVisibility();
				countText.Visibility = (!base.ViewModel.UnavailableOnly && !base.ViewModel.NoSelected).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "UnavailableOnly", "NoSelected" })),
			(delegate
			{
				checkBox.Checked = base.ViewModel.AllSelected;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AllSelected")),
			(delegate
			{
				addToCartButton.Enabled = !base.ViewModel.NoSelected;
				addToCartButton.BackgroundTintList = ColorStateList.ValueOf(new Color(ContextCompat.GetColor(Context, base.ViewModel.NoSelected ? 2131100615 : 2131099791)));
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NoSelected")),
			(delegate
			{
				selectAllLabel.Text = base.ViewModel.SelectAllText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectAllText")),
			(delegate
			{
				countText.Text = base.ViewModel.Count;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Count")),
			(delegate
			{
				total.Text = base.ViewModel.TotalPriceText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalPriceText")),
			(delegate
			{
				addToCartButton.Text = base.ViewModel.AddToCartText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AddToCartText"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.DismissCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
		base.ViewModel.ShowQtyDialogCommand.SafeSubscribe(ShowQtyInputDialog, ViewLifecycleOwner);
	}

	private void OnBindItem(CachingViewHolder holder, RepeatOrderProductItemViewModel vm, int position, CompositeDisposable disposable)
	{
		AppCompatCheckBox checkbox = holder.RequireCachedView<AppCompatCheckBox>(2131296768);
		ImageView imageView = holder.RequireCachedView<ImageView>(2131297394);
		TextView itemTitle = holder.RequireCachedView<TextView>(2131297398);
		RecyclerView recyclerView = holder.RequireCachedView<RecyclerView>(2131297585);
		TextView itemPrice = holder.RequireCachedView<TextView>(2131297397);
		TextView pricePerItem = holder.RequireCachedView<TextView>(2131297989);
		ImageView decreaseButton = holder.RequireCachedView<ImageView>(2131296903);
		TextView itemCount = holder.RequireCachedView<TextView>(2131297390);
		ImageView increaseButton = holder.RequireCachedView<ImageView>(2131297336);
		TextView stockLabel = holder.RequireCachedView<TextView>(2131298484);
		ImageView favoriteButton = holder.RequireCachedView<ImageView>(2131297148);
		View separator = holder.RequireCachedView<View>(2131298353);
		bool flag = vm.ProductSelectedModifications.Count > 0;
		if (flag)
		{
			ObservableRecyclerAdapter<ListItemModificationValueViewModel, CachingViewHolder> observableRecyclerAdapter = recyclerView.GetAdapter() as ObservableRecyclerAdapter<ListItemModificationValueViewModel, CachingViewHolder>;
			if (observableRecyclerAdapter == null)
			{
				observableRecyclerAdapter = new ObservableRecyclerAdapter<ListItemModificationValueViewModel, CachingViewHolder>
				{
					CellLayoutId = 2131493220,
					BindViewHolderDelegate = OnBindModification
				};
				recyclerView.SetLayoutManager(new LinearLayoutManager(Application.Context, 1, reverseLayout: false));
				recyclerView.SetAdapter(observableRecyclerAdapter);
			}
			observableRecyclerAdapter.DataSource = vm.ProductSelectedModifications;
		}
		recyclerView.Visibility = flag.ToVisibility();
		ViewOnClickListener onClickListener = new ViewOnClickListener(delegate(View v)
		{
			if (favoriteButton.Id == v.Id)
			{
				vm.FavoritesButtonViewModel.OnHeartClicked();
			}
			else if (itemCount.Id == v.Id)
			{
				base.ViewModel.OnQtyLabelTap(vm);
			}
			else if (increaseButton.Id == v.Id)
			{
				vm.OnChangeQty(increased: true);
				base.ViewModel.UpdateTotalPrice();
			}
			else if (decreaseButton.Id == v.Id)
			{
				vm.OnChangeQty();
				base.ViewModel.UpdateTotalPrice();
			}
			else if (checkbox.Id == v.Id)
			{
				vm.IsSelected = checkbox.Checked;
				base.ViewModel.CheckSelectedItems();
			}
		}).AddTo(disposable);
		favoriteButton.SetOnClickListener(onClickListener);
		itemCount.SetOnClickListener(onClickListener);
		increaseButton.SetOnClickListener(onClickListener);
		decreaseButton.SetOnClickListener(onClickListener);
		checkbox.SetOnClickListener(onClickListener);
		imageView.FromUrl(vm.ImageUrl);
		vm.FavoritesButtonViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			favoriteButton.SetBackgroundResource(vm.FavoritesButtonViewModel.ProductInFavorites ? 2131231168 : 2131231165);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductInFavorites")))).AddTo(disposable);
		vm.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[10]
		{
			(delegate
			{
				checkbox.Checked = vm.IsSelected;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSelected")),
			(delegate
			{
				itemTitle.Text = vm.TitleText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TitleText")),
			(delegate
			{
				itemPrice.Text = vm.PriceText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PriceText")),
			(delegate
			{
				pricePerItem.Text = vm.PricePerItemText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PricePerItemText")),
			(delegate
			{
				decreaseButton.Enabled = vm.DecreaseEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DecreaseEnabled")),
			(delegate
			{
				itemCount.Text = vm.ManualInputQty;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ManualInputQty")),
			(delegate
			{
				increaseButton.Enabled = vm.IncreaseEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IncreaseEnabled")),
			(delegate
			{
				stockLabel.Text = vm.StockLabel;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StockLabel")),
			(delegate
			{
				stockLabel.SetTextColor(vm.StockLabelHighlighted ? new Color(ContextCompat.GetColor(RequireContext(), 2131099790)) : new Color(ContextCompat.GetColor(RequireContext(), 2131100600)));
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StockLabelHighlighted")),
			(delegate
			{
				separator.Visibility = vm.IsSeparatorVisible.ToInvisibleVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSeparatorVisible"))
		})).AddTo(disposable);
	}

	private void OnBindUnavailableItem(CachingViewHolder holder, RepeatOrderProductItemViewModel vm, int position, CompositeDisposable disposable)
	{
		ConstraintLayout itemsUnavailableHeader = holder.RequireCachedView<ConstraintLayout>(2131297406);
		TextView itemsUnavailableHeaderText = holder.RequireCachedView<TextView>(2131297407);
		ImageView imageView = holder.RequireCachedView<ImageView>(2131297394);
		TextView itemTitle = holder.RequireCachedView<TextView>(2131297398);
		View findReplacement = holder.RequireCachedView<View>(2131297177);
		TextView findReplacementText = holder.RequireCachedView<TextView>(2131297179);
		ImageView favoriteButton = holder.RequireCachedView<ImageView>(2131297148);
		View separator = holder.RequireCachedView<View>(2131298353);
		ViewOnClickListener onClickListener = new ViewOnClickListener(delegate(View v)
		{
			if (favoriteButton.Id == v.Id)
			{
				vm.FavoritesButtonViewModel.OnHeartClicked();
			}
			else if (findReplacement.Id == v.Id)
			{
				base.ViewModel.ShowReplacement(vm);
			}
		});
		favoriteButton.SetOnClickListener(onClickListener);
		findReplacement.SetOnClickListener(onClickListener);
		imageView.FromUrl(vm.ImageUrl);
		vm.FavoritesButtonViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			favoriteButton.SetBackgroundResource(vm.FavoritesButtonViewModel.ProductInFavorites ? 2131231168 : 2131231165);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductInFavorites")))).AddTo(disposable);
		vm.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[5]
		{
			(delegate
			{
				itemsUnavailableHeader.Visibility = (!base.ViewModel.UnavailableOnly && position == 0).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("UnavailableOnly")),
			(delegate
			{
				itemsUnavailableHeaderText.Text = base.ViewModel.UnavailableItemsTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("UnavailableItemsTitle")),
			(delegate
			{
				itemTitle.Text = vm.TitleText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TitleText")),
			(delegate
			{
				findReplacementText.Text = vm.FindReplacementText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("FindReplacementText")),
			(delegate
			{
				separator.Visibility = vm.IsSeparatorVisible.ToInvisibleVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSeparatorVisible"))
		})).AddTo(disposable);
	}

	private void OnBindModification(CachingViewHolder vh, ListItemModificationValueViewModel selectedModification, int pos, CompositeDisposable disposable)
	{
		TextView textView = vh.RequireCachedView<TextView>(2131297434);
		TextView textView2 = vh.RequireCachedView<TextView>(2131297435);
		textView.Text = selectedModification.Name ?? "";
		textView2.Text = selectedModification.Value;
	}

	private void ShowQtyInputDialog(RepeatOrderProductItemViewModel vm)
	{
		View view = base.LayoutInflater.Inflate(2131492969, null);
		TextInputEditText input = view.RequireViewById<TextInputEditText>(2131298129);
		input.Text = vm.ManualInputQty;
		input.TextChanged += OnTextChanged;
		DialogInterfaceOnDismissListener dialogInterfaceOnDismissListener = new DialogInterfaceOnDismissListener(delegate
		{
			input.TextChanged -= OnTextChanged;
		});
		AlertDialog? alertDialog = new AlertDialog.Builder(Context).SetTitle(base.ViewModel.QtyDialogTitle).SetMessage(vm.TitleText).SetPositiveButton(base.ViewModel.QtyDialogDone, async delegate
		{
			base.ViewModel.CheckResult(vm, input.Text);
		})
			.SetNegativeButton(base.ViewModel.QtyDialogClose, delegate
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
			(Context?.GetSystemService("input_method") as InputMethodManager)?.ShowSoftInput(input, ShowFlags.Implicit);
		}, 200L);
		void OnTextChanged(object? sender, TextChangedEventArgs e)
		{
			if (!(input.Text == vm.ManualInputQty))
			{
				base.ViewModel.OnQtyEnteredManually(vm, input.Text);
				input.Text = vm.ManualInputQty;
				input.SetSelection(input.Text.Length);
			}
		}
	}
}
