using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.SupportChat.ItemViewModels;
using Me.Relex.CircleIndicatorLib;

namespace Auchan.Android.SupportChat.Views;

public sealed class RefundOrderMessageView : FrameLayout, IChatContentView
{
	private sealed class ScrollListener(RefundOrderMessageView parent) : RecyclerView.OnScrollListener()
	{
		public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
		{
			base.OnScrolled(recyclerView, dx, dy);
			parent._offsetX += dx;
			int num = recyclerView.Width - recyclerView.PaddingStart - recyclerView.PaddingEnd;
			int num2 = ((num != 0) ? ((parent._offsetX + 1) / num) : 0);
			if (0 <= num2 && num2 < parent._itemsCount && parent._pageSelected != num2)
			{
				parent._pageSelected = num2;
				parent._indicator.AnimatePageSelected(num2);
			}
		}
	}

	private readonly RecyclerView _recycler;

	private readonly CircleIndicator _indicator;

	private int _itemsCount;

	private int _pageSelected;

	private int _offsetX;

	public RefundOrderMessageView(Context context)
		: base(context)
	{
		View view = View.Inflate(context, 2131493198, this) ?? throw new InvalidOperationException("can't inflate layout");
		LayoutParameters = new ViewGroup.LayoutParams(-1, -2);
		_recycler = view.RequireViewById<RecyclerView>(2131297400);
		new LinearSnapHelper().AttachToRecyclerView(_recycler);
		_recycler.AddOnScrollListener(new ScrollListener(this));
		_indicator = view.RequireViewById<CircleIndicator>(2131297338);
	}

	public void Bind(RefundOrderListItemViewModel ivm, ICollection<IDisposable> disposables)
	{
		_itemsCount = ivm.Items.Count;
		_offsetX = 0;
		ObservableRecyclerAdapter<RefundOrderItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<RefundOrderItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493227,
			DataSource = ivm.Items,
			BindViewHolderDelegate = BindItem
		};
		_recycler.SetAdapter(adapter);
		_recycler.ScrollToPosition(0);
		_indicator.Visibility = ivm.IsIndicatorVisible.ToVisibility();
		_indicator.CreateIndicators(ivm.Items.Count, 0);
	}

	private void BindItem(CachingViewHolder holder, RefundOrderItemViewModel model, int index, CompositeDisposable disposable)
	{
		TextView textView = holder.RequireCachedView<TextView>(2131297632);
		View view = holder.RequireCachedView<View>(2131296496);
		TextView textView2 = holder.RequireCachedView<TextView>(2131296497);
		TextView textView3 = holder.RequireCachedView<TextView>(2131298487);
		TextView textView4 = holder.RequireCachedView<TextView>(2131298130);
		TextView textView5 = holder.RequireCachedView<TextView>(2131296436);
		textView.Text = model.Name;
		view.Visibility = model.IsStatusVisible.ToVisibility();
		if (model.Status != null)
		{
			view.BackgroundTintList = model.Status.Background.ToColorStateList();
			textView2.Text = model.Status.Text;
			textView2.SetTextColor(model.Status.Foreground.ToColor());
		}
		textView3.Visibility = model.IsStoreVisible.ToVisibility();
		textView3.Text = model.Store;
		textView4.Visibility = model.IsQuantityVisible.ToVisibility();
		textView4.Text = model.QuantityText;
		textView5.Visibility = model.IsAmountVisible.ToVisibility();
		textView5.Text = model.AmountText;
		model.Parent.BindEvents(holder.ItemView.OnClick((Action)delegate
		{
			model.Parent.OnRefundClick(model);
		})).AddTo(disposable);
	}
}
