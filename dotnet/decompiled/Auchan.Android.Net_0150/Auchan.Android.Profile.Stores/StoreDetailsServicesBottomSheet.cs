using System;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Profile.Stores;

namespace Auchan.Android.Profile.Stores;

internal sealed class StoreDetailsServicesBottomSheet : BaseBottomSheetDialogFragment<StoreDetailsServicesViewModel>
{
	protected override int LayoutId => 2131493496;

	public override int Theme => 2131951914;

	public StoreDetailsServicesBottomSheet(Func<StoreDetailsServicesViewModel.Parameter, StoreDetailsServicesViewModel> newViewModel)
		: base((Func<Fragment, StoreDetailsServicesViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<StoreDetailsServicesViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131297266);
		ImageView imageView = view.RequireViewById<ImageView>(2131296795);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131297963);
		textView.Text = base.ViewModel.TitleText;
		recyclerView.SetAdapter(new ObservableRecyclerAdapter<StoreDetailsServicesItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493285,
			DataSource = base.ViewModel.Services,
			BindViewHolderDelegate = OnBindService
		});
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
		base.ViewModel.BindEvents(imageView.OnClick(base.ViewModel.Close)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	public override void OnPause()
	{
		base.OnPause();
		Dismiss();
	}

	private void OnBindService(CachingViewHolder vh, StoreDetailsServicesItemViewModel vm, int pos, CompositeDisposable disposable)
	{
		vh.FindCachedView<TextView>(2131297962).Text = vm.NameText;
	}
}
