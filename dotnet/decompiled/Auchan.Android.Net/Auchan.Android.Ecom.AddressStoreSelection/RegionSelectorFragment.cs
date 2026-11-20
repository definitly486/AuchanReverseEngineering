using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.App;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.AddressStoreSelection.ViewModels;
using Auchan.Common.Extensions;
using Google.Android.Material.Button;

namespace Auchan.Android.Ecom.AddressStoreSelection;

internal class RegionSelectorFragment : BaseDialogFragment<RegionSelectorViewModel>
{
	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493486;

	public RegionSelectorFragment(Func<BrokerToken, RegionSelectorViewModel> newViewModel)
		: base((Func<AndroidX.Fragment.App.Fragment, RegionSelectorViewModel>)((AndroidX.Fragment.App.Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override Dialog OnCreateDialog(Bundle? savedInstanceState)
	{
		Dialog dialog = base.OnCreateDialog(savedInstanceState);
		Window? window = dialog.Window;
		if (window != null)
		{
			window.SetSoftInputMode(SoftInput.AdjustResize);
			return dialog;
		}
		return dialog;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131297266);
		View view2 = view.RequireViewById<View>(2131296795);
		CustomSearchView customSearchView = view.RequireViewById<CustomSearchView>(2131298322);
		EditText searchViewText = customSearchView.RequireViewById<EditText>(2131298321);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131298192);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131298336);
		TextView notFoundText = view.RequireViewById<TextView>(2131297697);
		ObservableRecyclerAdapter<SelectionItemViewModel<City>, CachingViewHolder> observableRecyclerAdapter = new ObservableRecyclerAdapter<SelectionItemViewModel<City>, CachingViewHolder>
		{
			CellLayoutId = 2131493210,
			DataSource = base.ViewModel.FilteredRegions,
			BindViewHolderDelegate = OnBindRegion,
			ClickCallback = delegate(CachingViewHolder vm, SelectionItemViewModel<City> r, int i)
			{
				base.ViewModel.SelectedRegion = r.Item;
			}
		};
		ObservableRecyclerAdapter<object, CachingViewHolder> observableRecyclerAdapter2 = new ObservableRecyclerAdapter<object, CachingViewHolder>
		{
			CellLayoutId = 2131493279,
			DataSource = new global::_003C_003Ez__ReadOnlySingleElementList<object>(base.ViewModel),
			BindViewHolderDelegate = delegate
			{
			}
		};
		recyclerView.SetAdapter(new ConcatAdapter(observableRecyclerAdapter, observableRecyclerAdapter2));
		textView.Text = base.ViewModel.Title;
		materialButton.Text = base.ViewModel.SaveButtonText;
		customSearchView.QueryHint = base.ViewModel.SearchPlaceholder;
		notFoundText.Text = base.ViewModel.NotFoundText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			notFoundText.Visibility = base.ViewModel.NotFound.ToVisibility();
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NotFound")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(materialButton.OnClick(base.ViewModel.Save), view2.OnClick(base.ViewModel.Close), ((TextView)searchViewText).OnTextChanged((EventHandler<TextChangedEventArgs>)delegate
		{
			base.ViewModel.SearchQuery = searchViewText.Text ?? "";
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}

	private static void OnBindRegion(CachingViewHolder holder, SelectionItemViewModel<City> regionModel, int position, CompositeDisposable disposable)
	{
		CompoundButton radioButton = holder.RequireCachedView<CompoundButton>(2131298135);
		holder.RequireCachedView<TextView>(2131297632).Text = regionModel.Item.Name;
		regionModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			radioButton.Checked = regionModel.Selected;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposable);
	}
}
