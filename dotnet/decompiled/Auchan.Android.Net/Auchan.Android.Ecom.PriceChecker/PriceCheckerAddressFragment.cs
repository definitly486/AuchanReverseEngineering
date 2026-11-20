using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Ecom.AddressStoreSelection;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.PriceChecker;
using Auchan.Common.Extensions;
using Google.Android.Material.RadioButton;

namespace Auchan.Android.Ecom.PriceChecker;

internal class PriceCheckerAddressFragment : BaseFragment<PriceCheckerAddressViewModel>
{
	private sealed class StickyTitleScrollListener : RecyclerView.OnScrollListener
	{
		private readonly LinearLayoutManager _layoutManager;

		private readonly View _stickyTitle;

		private readonly int _threshold;

		public StickyTitleScrollListener(LinearLayoutManager layoutManager, View stickyTitle, int threshold)
		{
			_layoutManager = layoutManager;
			_stickyTitle = stickyTitle;
			_threshold = threshold;
		}

		public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
		{
			base.OnScrolled(recyclerView, dx, dy);
			View view = _layoutManager.FindViewByPosition(0);
			bool flag;
			if (view == null)
			{
				flag = true;
			}
			else
			{
				View view2 = view.FindViewById(2131296953);
				flag = view.Top + (view2?.Top ?? 0) <= _threshold;
			}
			_stickyTitle.Visibility = ((!flag) ? ViewStates.Gone : ViewStates.Visible);
		}
	}

	protected override int LayoutId => 2131493508;

	public PriceCheckerAddressFragment(Func<BrokerToken, PriceCheckerAddressViewModel> newViewModel)
		: base((Func<Fragment, PriceCheckerAddressViewModel>)((Fragment fragment) => newViewModel(fragment.RequireNavToken())))
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			base.ViewModel.OnBackPressed();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		RequireActivity().OnBackPressedDispatcher.AddCallback(this, delegate
		{
			base.ViewModel.OnBackPressed();
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		View progress = view.RequireViewById<View>(2131297242);
		View error = view.RequireViewById<View>(2131297111);
		TextView errorTitle = error.RequireViewById<TextView>(2131298646);
		TextView errorMessage = error.RequireViewById<TextView>(2131297563);
		View view2 = error.RequireViewById<View>(2131296325);
		Button button = error.RequireViewById<Button>(2131298371);
		view2.Visibility = ViewStates.Invisible;
		button.Visibility = ViewStates.Gone;
		TextView title = view.RequireViewById<TextView>(2131298679);
		AppCompatImageButton appCompatImageButton = view.RequireViewById<AppCompatImageButton>(2131296490);
		TextView saveButton = view.RequireViewById<TextView>(2131298287);
		View view3 = view.RequireViewById<View>(2131296951);
		CustomSearchView searchView = view3.RequireViewById<CustomSearchView>(2131298322);
		ImageView imageView = searchView.RequireViewById<ImageView>(2131298319);
		if (imageView.LayoutParameters is ViewGroup.MarginLayoutParams marginLayoutParams)
		{
			int marginStart = (marginLayoutParams.LeftMargin = (int)RequireActivity().ConvertDpToPx(12f));
			marginLayoutParams.MarginStart = marginStart;
			imageView.LayoutParameters = marginLayoutParams;
		}
		searchView.RequireViewById<ImageView>(2131298315).SetImageResource(2131231122);
		View contentLayout = view3.RequireViewById<View>(2131298490);
		TextView stickyTitle = view3.RequireViewById<TextView>(2131296954);
		stickyTitle.Text = base.ViewModel.DeliveryTitle;
		View emptyStateView = view3.RequireViewById<View>(2131297081);
		TextView textView = emptyStateView.RequireViewById<TextView>(2131297083);
		TextView textView2 = emptyStateView.RequireViewById<TextView>(2131297071);
		searchView.QueryHint = base.ViewModel.SearchPlaceholder;
		searchView.SetQuery(base.ViewModel.SearchQuery, submit: false);
		textView.Text = base.ViewModel.StoresNotFoundTitle;
		textView2.Text = base.ViewModel.StoresNotFoundSubtitle;
		RecyclerView deliveryStoreList = view3.RequireViewById<RecyclerView>(2131296952);
		ObservableRecyclerAdapter<SelectionItemViewModel<Store, PriceCheckerAddressViewModel>, CachingViewHolder> _deliveryStoreListAdapter = new ObservableRecyclerAdapter<SelectionItemViewModel<Store, PriceCheckerAddressViewModel>, CachingViewHolder>
		{
			CellLayoutId = 2131493286,
			BindViewHolderDelegate = OnBindPriceCheckerStore
		};
		ObservableRecyclerAdapter<object, CachingViewHolder> observableRecyclerAdapter = new ObservableRecyclerAdapter<object, CachingViewHolder>
		{
			CellLayoutId = 2131493287,
			DataSource = new global::_003C_003Ez__ReadOnlySingleElementList<object>(base.ViewModel),
			BindViewHolderDelegate = delegate(CachingViewHolder holder, object _, int _, CompositeDisposable _)
			{
				holder.RequireCachedView<SnackView>(2131296950).Text = base.ViewModel.DifPricesWarningText;
				holder.RequireCachedView<TextView>(2131296953).Text = base.ViewModel.DeliveryTitle;
			}
		};
		deliveryStoreList.SetAdapter(new ConcatAdapter(observableRecyclerAdapter, _deliveryStoreListAdapter));
		LinearLayoutManagerWrapperForSupportsPredictiveItemAnimations layoutManager = new LinearLayoutManagerWrapperForSupportsPredictiveItemAnimations(Context, 1, reverseLayout: false);
		deliveryStoreList.SetLayoutManager(layoutManager);
		deliveryStoreList.AddItemDecoration(new SimpleDividerItemDecoration(RequireContext()));
		int threshold = (int)RequireActivity().ConvertDpToPx(24f);
		deliveryStoreList.AddOnScrollListener(new StickyTitleScrollListener(layoutManager, stickyTitle, threshold));
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[7]
		{
			(delegate
			{
				progress.Visibility = (base.ViewModel.State == VisualState.InProgress).ToVisibility();
				error.Visibility = (base.ViewModel.State == VisualState.Error).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				title.Text = base.ViewModel.SelectAddressText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectAddressText")),
			(delegate
			{
				errorTitle.Text = base.ViewModel.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				_deliveryStoreListAdapter.DataSource = base.ViewModel.PriceCheckerStores;
				deliveryStoreList.ScrollToPosition(0);
				stickyTitle.Visibility = ViewStates.Gone;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PriceCheckerStores")),
			(delegate
			{
				contentLayout.Visibility = (!base.ViewModel.StoresNotFound).ToVisibility();
				emptyStateView.Visibility = base.ViewModel.StoresNotFound.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StoresNotFound")),
			(delegate
			{
				saveButton.Enabled = base.ViewModel.CanSave;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanSave"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(appCompatImageButton.OnClick(base.ViewModel.OnClose), saveButton.OnClick(base.ViewModel.OnSaveClick), ((SearchView)searchView).OnQueryTextChange((EventHandler<SearchView.QueryTextChangeEventArgs>)delegate
		{
			base.ViewModel.SearchQuery = searchView.Query ?? string.Empty;
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			base.ParentFragmentManager.PopBackStack();
		}, ViewLifecycleOwner);
	}

	private void OnBindPriceCheckerStore(CachingViewHolder holder, SelectionItemViewModel<Store, PriceCheckerAddressViewModel> model, int position, CompositeDisposable disposable)
	{
		MaterialRadioButton selectionButton = holder.RequireCachedView<MaterialRadioButton>(2131298340);
		TextView textView = holder.RequireCachedView<TextView>(2131297632);
		TextView textView2 = holder.RequireCachedView<TextView>(2131296384);
		TextView textView3 = holder.RequireCachedView<TextView>(2131297004);
		textView.Text = model.Item.Name;
		textView2.Text = model.Item.Address;
		textView3.Text = model.Item.DistanceFromUserLocationText;
		selectionButton.Clickable = false;
		model.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			selectionButton.Checked = model.Selected;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposable);
		holder.ItemView.OnClick((Action)delegate
		{
			model.Parent.OnStoreSelected(model);
		}).AddTo(disposable);
	}
}
