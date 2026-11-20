using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Controls.ListPicker;
using Auchan.Common.Extensions;
using Google.Android.Material.Button;
using Google.Android.Material.RadioButton;

namespace Auchan.Android.Controls.ListSelector;

internal class ListPickerFragment : BaseBottomSheetDialogFragment<ListPickerViewModel>
{
	public Action<ListPickerViewModel.Result>? ResultAction;

	protected override int LayoutId => 2131493474;

	protected override bool FullScreen => true;

	public override int Theme => 2131951914;

	public ListPickerFragment(Func<ListPickerViewModel.Parameter, ListPickerViewModel> newViewModel)
		: base((Func<Fragment, ListPickerViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<ListPickerViewModel.Parameter>())))
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.DismissCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, this);
		base.ViewModel.ReturnCommand.SafeSubscribe(delegate(ListPickerViewModel.Result x)
		{
			ResultAction(x);
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131297266);
		View view2 = view.RequireViewById<View>(2131296795);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131298192);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131298336);
		recyclerView.SetAdapter(new ObservableRecyclerAdapter<ListPickerItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493253,
			DataSource = base.ViewModel.Items,
			BindViewHolderDelegate = OnBindItem,
			ClickCallback = OnItemSelected
		});
		textView.Text = base.ViewModel.ScreenTitle;
		materialButton.Visibility = ViewStates.Gone;
		view2.OnClick(base.ViewModel.Close).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private static void OnBindItem(CachingViewHolder holder, ListPickerItemViewModel item, int position, CompositeDisposable disposable)
	{
		MaterialRadioButton element = (MaterialRadioButton)holder.ItemView;
		element.Text = item.Text;
		item.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			element.Checked = item.Selected;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposable);
	}

	private void OnItemSelected(CachingViewHolder cachingViewHolder, ListPickerItemViewModel listPickerItemViewModel, int position)
	{
		base.ViewModel.OnItemSelected(position);
	}
}
