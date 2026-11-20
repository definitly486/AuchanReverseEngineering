using System;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Common.Common;
using Auchan.Common.Controls.AutoLayout;

namespace Auchan.Android.Controls.AutoLayout;

internal abstract class AutoLayoutToolbarFragment<TViewModel> : BaseToolbarFragment<TViewModel> where TViewModel : AutoLayoutScreenViewModel
{
	protected override int LayoutId => 2131492990;

	protected RecyclerView.LayoutManager? LayoutManager { get; set; }

	protected RecyclerView? AutoLayoutRecycler { get; private set; }

	public AutoLayoutToolbarFragment(Func<Fragment, TViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		AutoLayoutRecycler = view.RequireViewById<RecyclerView>(2131298187);
		AutoLayoutRecyclerAdapter autoLayoutRecyclerAdapter = new AutoLayoutRecyclerAdapter(RequireContext(), base.ViewModel.AutoLayout, BindAutoLayoutView);
		autoLayoutRecyclerAdapter.AutoDisposeOnDestroy(ViewLifecycleOwner);
		AutoLayoutRecycler.SetLayoutManager(LayoutManager ?? new LinearLayoutManager(RequireContext(), 1, reverseLayout: false));
		AutoLayoutRecycler.SetAdapter(autoLayoutRecyclerAdapter);
	}

	protected abstract void BindAutoLayoutView(AutoLayoutViewModel.AutoLayoutElement vm, int position, CachingViewHolder vh, CompositeDisposable disposables);
}
internal abstract class AutoLayoutToolbarFragment<TViewModel, TParameter> : BaseToolbarFragment<TViewModel> where TViewModel : AutoLayoutScreenViewModel<TParameter> where TParameter : BrokeredParameter
{
	protected override int LayoutId => 2131492990;

	protected RecyclerView.LayoutManager? LayoutManager { get; set; }

	protected RecyclerView? AutoLayoutRecycler { get; private set; }

	public AutoLayoutToolbarFragment(Func<BrokerToken, TViewModel> newViewModel)
		: base((Func<Fragment, TViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		AutoLayoutRecycler = view.RequireViewById<RecyclerView>(2131298187);
		AutoLayoutRecyclerAdapter autoLayoutRecyclerAdapter = new AutoLayoutRecyclerAdapter(RequireContext(), base.ViewModel.AutoLayout, BindAutoLayoutView);
		autoLayoutRecyclerAdapter.AutoDisposeOnDestroy(ViewLifecycleOwner);
		AutoLayoutRecycler.SetLayoutManager(LayoutManager ?? new LinearLayoutManager(RequireContext(), 1, reverseLayout: false));
		AutoLayoutRecycler.SetAdapter(autoLayoutRecyclerAdapter);
	}

	protected abstract void BindAutoLayoutView(AutoLayoutViewModel.AutoLayoutElement vm, int position, CachingViewHolder vh, CompositeDisposable disposables);
}
