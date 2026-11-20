using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Profile.Stores;
using Auchan.Common.Profile.Stores.Models;
using Google.Android.Material.Button;

namespace Auchan.Android.Profile.Stores;

internal sealed class StoresFilterFragment : ScrollableBottomSheet<StoresFilterViewModel>
{
	private MaterialButton _supermarketButton;

	private MaterialButton _gipermarketButton;

	private TextView _regionChoice;

	private ObservableRecyclerAdapter<StoresFilterServicesItemViewModel, CachingViewHolder> _storesAdapter;

	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493102;

	public StoresFilterFragment(Func<Fragment, StoresFilterViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298659);
		View view2 = view.RequireViewById<View>(2131298516);
		_regionChoice = view2.RequireViewById<TextView>(2131298191);
		TextView textView2 = view.RequireViewById<TextView>(2131298519);
		_supermarketButton = view.RequireViewById<MaterialButton>(2131298518);
		_gipermarketButton = view.RequireViewById<MaterialButton>(2131298515);
		View view3 = view.RequireViewById<View>(2131296795);
		TextView textView3 = view.RequireViewById<TextView>(2131298522);
		Button applyButton = view.RequireViewById<Button>(2131298287);
		TextView textView4 = view.RequireViewById<TextView>(2131296783);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131298513);
		TextView textView5 = linearLayout.RequireViewById<TextView>(2131298514);
		textView.Text = base.ViewModel.TitleLabel;
		textView2.Text = base.ViewModel.TypeLabel;
		_supermarketButton.Text = base.ViewModel.SupermarketButtonLabel;
		_gipermarketButton.Text = base.ViewModel.GipermarketButtonLabel;
		textView3.Text = base.ViewModel.ServicesLabel;
		textView5.Text = base.ViewModel.AllServicesText;
		applyButton.Text = base.ViewModel.ApplyButtonText;
		textView4.Text = base.ViewModel.ClearButtonText;
		ConfigureReactive();
		ConfigureServiceAdapter(view);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				_regionChoice.Text = base.ViewModel.RegionChoiseText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("RegionChoiseText")),
			(delegate
			{
				applyButton.Enabled = base.ViewModel.IsApplyEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsApplyEnabled"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(view3.OnClick(Dismiss), _regionChoice.OnClick(base.ViewModel.NavigateToRegions), linearLayout.OnClick(base.ViewModel.NavigateToServices), ((View)_supermarketButton).OnClick((Action)delegate
		{
			base.ViewModel.SetStoreType(StoreType.Supermarket);
		}), ((View)_gipermarketButton).OnClick((Action)delegate
		{
			base.ViewModel.SetStoreType(StoreType.Gipermarket);
		}), applyButton.OnClick(base.ViewModel.ApplyFilterThenDissmiss), textView4.OnClick(base.ViewModel.ClearFilter)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.RestoreFilter();
	}

	private void ConfigureServiceAdapter(View view)
	{
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131298517);
		CustomFlexibleLayoutManager layoutManager = new CustomFlexibleLayoutManager(Context, 0, isScrollable: false);
		_storesAdapter = new ObservableRecyclerAdapter<StoresFilterServicesItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493345,
			DataSource = base.ViewModel.Services,
			BindViewHolderDelegate = OnBindService
		};
		recyclerView.SetLayoutManager(layoutManager);
		recyclerView.SetAdapter(_storesAdapter);
	}

	private void OnBindService(CachingViewHolder vh, StoresFilterServicesItemViewModel vm, int pos, CompositeDisposable disposable)
	{
		TextView nameTextView = vh.FindCachedView<TextView>(2131298521);
		View backgroundView = vh.FindCachedView(2131296491);
		nameTextView.Text = vm.Name;
		vm.BindEvents(vh.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.SetService(vm);
			UpdateView(vm.Selected, backgroundView, nameTextView);
		})).AddTo(disposable);
		vm.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			UpdateView(vm.Selected, backgroundView, nameTextView);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposable);
		vm.OnChecked.ObserveOn(MainThread.Scheduler).Subscribe(delegate(bool selected)
		{
			UpdateView(selected, backgroundView, nameTextView);
		}).AddTo(disposable);
	}

	private void ConfigureReactive()
	{
		base.ViewModel.OnStoreTypeChanged.ObserveOn(MainThread.Scheduler).Subscribe(delegate(StoreType type)
		{
			SetStoreTypeButtonChecked(type);
		}).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		base.ViewModel.NavigateRegionCommand.ObserveOn(MainThread.Scheduler).Subscribe(OnRegionsClick).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		base.ViewModel.NavigateServicesCommand.ObserveOn(MainThread.Scheduler).Subscribe(OnServicesClick).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		base.ViewModel.OnDissmiss.ObserveOn(MainThread.Scheduler).Subscribe(delegate
		{
			Dismiss();
		}).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
	}

	private void SetStoreTypeButtonChecked(StoreType type)
	{
		switch (type)
		{
		case StoreType.Supermarket:
			_supermarketButton.ForceChecked(check: true);
			_gipermarketButton.ForceChecked(check: false);
			break;
		case StoreType.Gipermarket:
			_supermarketButton.ForceChecked(check: false);
			_gipermarketButton.ForceChecked(check: true);
			break;
		case StoreType.None:
			_supermarketButton.ForceChecked(check: false);
			_gipermarketButton.ForceChecked(check: false);
			break;
		}
	}

	private void OnRegionsClick(StoresFilterRegionsViewModel regionsViewModel)
	{
		RegionsBottomSheet regionsBottomSheet = new RegionsBottomSheet((Fragment _) => regionsViewModel);
		regionsBottomSheet.SetTargetFragment(this, 0);
		regionsBottomSheet.Show(base.ParentFragmentManager, null);
	}

	private void OnServicesClick(StoresFilterServicesViewModel vm)
	{
		StoresFilterServicesBottomSheet storesFilterServicesBottomSheet = new StoresFilterServicesBottomSheet((Fragment _) => vm);
		storesFilterServicesBottomSheet.SetTargetFragment(this, 0);
		storesFilterServicesBottomSheet.Show(base.ParentFragmentManager, null);
	}

	private void UpdateView(bool isSelected, View root, params TextView[] textViews)
	{
		if (Context != null)
		{
			root.Background = ContextCompat.GetDrawable(Context, isSelected ? 2131231596 : 2131231595);
			int color = ContextCompat.GetColor(Context, isSelected ? 2131099697 : 2131099704);
			Color textColor = new Color(color);
			for (int i = 0; i < textViews.Length; i++)
			{
				textViews[i].SetTextColor(textColor);
			}
		}
	}
}
