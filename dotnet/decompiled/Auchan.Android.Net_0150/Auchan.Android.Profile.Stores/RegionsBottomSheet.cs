using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Android.OS;
using Android.Views;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Profile.Stores;
using Google.Android.Material.RadioButton;

namespace Auchan.Android.Profile.Stores;

internal sealed class RegionsBottomSheet : BaseBottomSheetDialogFragment<StoresFilterRegionsViewModel>
{
	private BehaviorSubject<int>? _selectedPosition = new BehaviorSubject<int>(-1);

	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493498;

	public RegionsBottomSheet(Func<Fragment, StoresFilterRegionsViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		View view2 = view.RequireViewById<View>(2131296795);
		view.RequireViewById<RecyclerView>(2131298192).SetAdapter(new ObservableRecyclerAdapter<StoresFilterRegionItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493346,
			DataSource = base.ViewModel.Regions,
			BindViewHolderDelegate = OnBindRegion
		});
		base.ViewModel.BindEvents(view2.OnClick(Dismiss)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void OnBindRegion(CachingViewHolder viewHolder, StoresFilterRegionItemViewModel vm, int position, CompositeDisposable disposable)
	{
		MaterialRadioButton element = (MaterialRadioButton)viewHolder.ItemView;
		element.Text = vm.Name;
		if (base.ViewModel.Filter.RegionId == vm.Id)
		{
			_selectedPosition.OnNext(position);
		}
		_selectedPosition.ObserveOn(MainThread.Scheduler).Subscribe(delegate(int pos)
		{
			element.Checked = position == pos;
		}).AddTo(disposable);
		vm.BindEvents(((View)element).OnClick((Action)delegate
		{
			_selectedPosition.OnNext(position);
			base.ViewModel.SetRegionsId(vm.Id, vm.Name);
			base.ViewModel.ApplyFilter();
		})).AddTo(disposable);
	}
}
