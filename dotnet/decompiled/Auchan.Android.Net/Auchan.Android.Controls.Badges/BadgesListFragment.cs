using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Badges;
using Auchan.Common.Extensions;

namespace Auchan.Android.Controls.Badges;

internal sealed class BadgesListFragment : BaseBottomSheetDialogFragment<BadgesListViewModel>
{
	protected override int LayoutId => 2131493452;

	public override int Theme => 2131951914;

	public BadgesListFragment(Func<BadgesListViewModel.Parameter, BadgesListViewModel> newViewModel)
		: base((Func<Fragment, BadgesListViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<BadgesListViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131296505);
		recyclerView.SetItemAnimator(null);
		recyclerView.SetAdapter(new ObservableRecyclerAdapter<BadgeListItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493212,
			BindViewHolderDelegate = OnBindItem,
			DataSource = base.ViewModel.Items
		});
		base.ViewModel.DismissCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}

	private void OnBindItem(CachingViewHolder holder, BadgeListItemViewModel model, int position, CompositeDisposable disposable)
	{
		BadgeView badge = holder.RequireCachedView<BadgeView>(2131296496);
		TextView text = holder.RequireCachedView<TextView>(2131298603);
		badge.Setup(model.Badge);
		text.AddLinkedText(model.Description);
		model.Parent.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((async delegate
		{
			if (text.PaddingStart != (int)model.Parent.TextStartMargin)
			{
				YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
				_ = awaiter.IsCompleted;
				await awaiter;
				YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
				awaiter = yieldAwaiter;
				awaiter.GetResult();
				text.SetPadding((int)model.Parent.TextStartMargin, text.PaddingTop, text.PaddingEnd, text.PaddingBottom);
				text.FindParent<RecyclerView>().GetAdapter().NotifyItemChanged(position);
			}
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TextStartMargin")))).AddTo(disposable);
		model.Parent.BindEvents(((View)badge).OnLayoutChange((Action)delegate
		{
			model.Parent.SetTextStartMargin(badge.Width);
		})).AddTo(disposable);
	}
}
