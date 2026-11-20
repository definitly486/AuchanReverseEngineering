using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Search;
using Auchan.Common.Extensions;

namespace Auchan.Android.Catalog.Search;

internal class SearchProductsSortsFragment : BaseBottomSheetDialogFragment<SearchSortsViewModel>
{
	protected override int LayoutId => 2131493092;

	public override int Theme => 2131951914;

	public SearchProductsSortsFragment(Func<Fragment, SearchSortsViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298646);
		ImageView imageView = view.RequireViewById<ImageView>(2131296795);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131298188);
		Button button = view.RequireViewById<Button>(2131296454);
		textView.Text = base.ViewModel.Title;
		button.Text = base.ViewModel.ApplyText;
		recyclerView.SetLayoutManager(new LinearLayoutManager(Context));
		ObservableRecyclerAdapter<SortItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<SortItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493336,
			DataSource = base.ViewModel.Sorts,
			BindViewHolderDelegate = OnBind
		};
		recyclerView.SetAdapter(adapter);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			adapter.DataSource = base.ViewModel.Sorts;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Sorts")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		imageView.SetOnClickListener(new ViewOnClickListener(base.ViewModel.CloseCommand.Trigger).AutoDisposeOnDestroy(ViewLifecycleOwner));
		button.SetOnClickListener(new ViewOnClickListener(base.ViewModel.ApplyCommand.Trigger).AutoDisposeOnDestroy(ViewLifecycleOwner));
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}

	private void OnBind(CachingViewHolder vh, SortItemViewModel vm, int position, CompositeDisposable disposable)
	{
		CheckBox checkbox = vh.RequireCachedView<CheckBox>(2131296768);
		checkbox.Text = vm.Title;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			checkbox.Checked = base.ViewModel.SelectedSort.Value == vm.Value;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedSort")))).AddTo(disposable);
		vh.ItemView.SetOnClickListener(new ViewOnClickListener((Action)delegate
		{
			base.ViewModel.SelectSortCommand.Trigger(vm);
		}).AddTo(disposable));
	}
}
