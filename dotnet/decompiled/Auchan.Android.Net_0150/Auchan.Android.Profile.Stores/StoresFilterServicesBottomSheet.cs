using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Stores;
using Google.Android.Material.Button;
using Google.Android.Material.CheckBox;

namespace Auchan.Android.Profile.Stores;

internal sealed class StoresFilterServicesBottomSheet : BaseBottomSheetDialogFragment<StoresFilterServicesViewModel>
{
	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493499;

	public StoresFilterServicesBottomSheet(Func<Fragment, StoresFilterServicesViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		View view2 = view.RequireViewById<View>(2131296795);
		MaterialButton applyButton = view.RequireViewById<MaterialButton>(2131297167);
		view.RequireViewById<RecyclerView>(2131297964).SetAdapter(new ObservableRecyclerAdapter<StoresFilterServicesItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493347,
			DataSource = base.ViewModel.Services,
			BindViewHolderDelegate = OnBindService
		});
		base.ViewModel.BindEvents(view2.OnClick(base.ViewModel.Close), applyButton.OnClick(base.ViewModel.ApplyFilter)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			applyButton.Enabled = base.ViewModel.IsApplyEnabled;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsApplyEnabled")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OnDissmiss.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}

	private void OnBindService(CachingViewHolder vh, StoresFilterServicesItemViewModel vm, int pos, CompositeDisposable disposable)
	{
		MaterialCheckBox element = (MaterialCheckBox)vh.ItemView;
		element.Text = vm.Name;
		element.Checked = vm.Selected;
		vm.BindEvents(((View)element).OnClick((Action)delegate
		{
			base.ViewModel.SetServiceId(element.Checked, vm.Id);
		})).AddTo(disposable);
		vm.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			element.Checked = vm.Selected;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposable);
	}
}
