using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Disposables;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.DateOfBirthSelection;
using Google.Android.Material.Button;

namespace Auchan.Android.Authorization;

internal class DateOfBirthSelectionFragment : BaseFragment<DateOfBirthSelectionViewModel>
{
	protected override int LayoutId => 2131493018;

	public DateOfBirthSelectionFragment(Func<DateOfBirthSelectionViewModel.Parameter, DateOfBirthSelectionViewModel> newViewModel)
		: base((Func<Fragment, DateOfBirthSelectionViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<DateOfBirthSelectionViewModel.Parameter>())))
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		if (RequireParentFragment() is IToolbarContainer toolbarContainer)
		{
			toolbarContainer.Toolbar.Visibility = ViewStates.Gone;
		}
		base.ViewModel.CloseCommand.SafeSubscribe(OnClose, this);
		base.ViewModel.SaveCommand.SafeSubscribe(OnSave, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298655);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131296795);
		TextView subtitleLabel = view.RequireViewById<TextView>(2131298560);
		RecyclerView yearsList = view.RequireViewById<RecyclerView>(2131298853);
		RecyclerView monthsList = view.RequireViewById<RecyclerView>(2131297596);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131296898);
		MaterialButton saveButton = view.RequireViewById<MaterialButton>(2131298287);
		MaterialButton materialButton2 = view.RequireViewById<MaterialButton>(2131296613);
		textView.Text = base.ViewModel.ScreenTitle;
		materialButton.Text = base.ViewModel.CloseTitle;
		ObservableRecyclerAdapter<YearSelectorItemViewModel, CachingViewHolder> yearsAdapter = new ObservableRecyclerAdapter<YearSelectorItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493239,
			BindViewHolderDelegate = OnBindYear,
			ClickCallback = OnYearClicked
		};
		yearsList.SetAdapter(yearsAdapter);
		yearsList.SetLayoutManager(new LinearLayoutManager(base.Activity, 0, reverseLayout: false));
		ObservableRecyclerAdapter<MonthSelectorItemViewModel, CachingViewHolder> monthsAdapter = new ObservableRecyclerAdapter<MonthSelectorItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493239,
			BindViewHolderDelegate = OnBindMonth,
			ClickCallback = OnMonthClicked
		};
		monthsList.SetAdapter(monthsAdapter);
		monthsList.SetLayoutManager(new LinearLayoutManager(base.Activity, 0, reverseLayout: false));
		ObservableRecyclerAdapter<DaySelectorItemViewModel, CachingViewHolder> daysAdapter = new ObservableRecyclerAdapter<DaySelectorItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493238,
			BindViewHolderDelegate = OnBindDay,
			ClickCallback = OnDayClicked
		};
		recyclerView.SetAdapter(daysAdapter);
		int num = (Converter.PxToDp(base.ParentFragment.View.MeasuredWidth) - 40 - 252) / 6;
		float dimension = base.Resources.GetDimension(2131165335);
		recyclerView.SetPadding(Converter.DpToPx(8f) - num, recyclerView.PaddingTop, Converter.DpToPx(8f) - num, recyclerView.PaddingBottom);
		recyclerView.SetLayoutManager(new GridLayoutManager(base.Activity, 7, 1, reverseLayout: false));
		recyclerView.AddItemDecoration(new GridSpacesItemDecoration2(Converter.PxToDp(dimension), num));
		saveButton.Text = base.ViewModel.SaveButtonTitle;
		materialButton2.Text = base.ViewModel.CancelButtonTitle;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[7]
		{
			(delegate
			{
				yearsAdapter.DataSource = base.ViewModel.YearsCollection;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("YearsCollection")),
			(delegate
			{
				monthsAdapter.DataSource = base.ViewModel.MonthsCollection;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("MonthsCollection")),
			(delegate
			{
				daysAdapter.DataSource = base.ViewModel.AllDaysCollection;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AllDaysCollection")),
			(delegate
			{
				yearsList.ScrollToPosition(base.ViewModel.YearCollectionInitialPositionIndex);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("YearCollectionInitialPositionIndex")),
			(delegate
			{
				monthsList.ScrollToPosition(base.ViewModel.MonthsCollectionInitialPositionIndex);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("MonthsCollectionInitialPositionIndex")),
			(delegate
			{
				saveButton.Enabled = base.ViewModel.IsSaveButtonEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSaveButtonEnabled")),
			(delegate
			{
				subtitleLabel.Text = base.ViewModel.ScreenSubtitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ScreenSubtitle"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(materialButton.OnClick(base.ViewModel.OnCloseButtonSelected), saveButton.OnClick(base.ViewModel.OnSaveButtonSelected), materialButton2.OnClick(base.ViewModel.OnCancelButtonSelected)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void OnYearClicked(CachingViewHolder vh, YearSelectorItemViewModel vm, int index)
	{
		vm.OnItemsSelected(vm, index);
	}

	private void OnMonthClicked(CachingViewHolder vh, MonthSelectorItemViewModel vm, int index)
	{
		vm.OnItemsSelected(vm, index);
	}

	private void OnDayClicked(CachingViewHolder vh, DaySelectorItemViewModel vm, int index)
	{
		vm.OnItemsSelected(vm, index);
	}

	private void OnBindYear(CachingViewHolder vh, YearSelectorItemViewModel vm, int index, CompositeDisposable cd)
	{
		TextView title = vh.RequireCachedView<TextView>(2131298655);
		vm.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				title.Text = vm.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				title.Activated = vm.IsSelected;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSelected")),
			(delegate
			{
				title.SetTypeface(Typeface.Default, (!vm.IsSelected) ? TypefaceStyle.Bold : TypefaceStyle.Normal);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSelected"))
		})).AddTo(cd);
	}

	private void OnBindMonth(CachingViewHolder vh, MonthSelectorItemViewModel vm, int index, CompositeDisposable cd)
	{
		TextView title = vh.RequireCachedView<TextView>(2131298655);
		vm.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				title.Text = vm.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				title.Activated = vm.IsSelected;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSelected")),
			(delegate
			{
				title.SetTypeface(Typeface.Default, (!vm.IsSelected) ? TypefaceStyle.Bold : TypefaceStyle.Normal);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSelected"))
		})).AddTo(cd);
	}

	private void OnBindDay(CachingViewHolder vh, DaySelectorItemViewModel vm, int index, CompositeDisposable cd)
	{
		TextView title = vh.RequireCachedView<TextView>(2131298655);
		vm.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				title.Text = vm.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				title.Activated = vm.IsSelected;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSelected")),
			(delegate
			{
				title.Enabled = vm.IsEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsEnabled"))
		})).AddTo(cd);
	}

	private void OnClose(Unit obj)
	{
		if (RequireParentFragment() is IToolbarContainer toolbarContainer)
		{
			toolbarContainer.Toolbar.Visibility = ViewStates.Visible;
		}
		base.ParentFragmentManager.PopBackStack();
		this.ReturnResult(DateTime.MinValue);
	}

	private void OnSave(DateTime result)
	{
		if (RequireParentFragment() is IToolbarContainer toolbarContainer)
		{
			toolbarContainer.Toolbar.Visibility = ViewStates.Visible;
		}
		base.ParentFragmentManager.PopBackStack();
		this.ReturnResult(result);
	}
}
