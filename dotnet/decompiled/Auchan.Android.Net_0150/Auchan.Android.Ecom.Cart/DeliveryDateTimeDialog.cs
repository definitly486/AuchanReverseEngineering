using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Extensions;
using Google.Android.Material.Button;

namespace Auchan.Android.Ecom.Cart;

internal class DeliveryDateTimeDialog : BaseBottomSheetDialogFragment<DeliveryDateTimeViewModel>
{
	private int _maxDateItemWidth;

	protected override int LayoutId => 2131493491;

	public override int Theme => 2131951914;

	public DeliveryDateTimeDialog(Func<BrokerToken, DeliveryDateTimeViewModel> newViewModel)
		: base((Func<Fragment, DeliveryDateTimeViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ImageView imageView = view.RequireViewById<ImageView>(2131296791);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131296896);
		RecyclerView recyclerView2 = view.RequireViewById<RecyclerView>(2131298639);
		MaterialButton saveButton = view.RequireViewById<MaterialButton>(2131298284);
		TextView textView = view.RequireViewById<TextView>(2131298649);
		_maxDateItemWidth = FindMaxDateItemWidth();
		DeliveryDateDivider decor = new DeliveryDateDivider
		{
			Offset = Converter.DpToPx(8f)
		};
		ObservableRecyclerAdapter<DateItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<DateItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493234,
			BindViewHolderDelegate = BindDate,
			DataSource = base.ViewModel.DeliveryDates
		};
		ObservableRecyclerAdapter<TimeItemViewModel, CachingViewHolder> timeAdapter = new ObservableRecyclerAdapter<TimeItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493236,
			BindViewHolderDelegate = BindTime
		};
		recyclerView.AddItemDecoration(decor);
		recyclerView.SetAdapter(adapter);
		recyclerView.HasFixedSize = true;
		recyclerView.NestedScrollingEnabled = false;
		recyclerView2.SetAdapter(timeAdapter);
		textView.Text = base.ViewModel.Title;
		saveButton.Text = base.ViewModel.SaveButtonText;
		int num = base.ViewModel.DeliveryDates.ToList().IndexOf(base.ViewModel.SelectedDate);
		if (num > 0)
		{
			recyclerView.ScrollToPosition(num);
		}
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				saveButton.Enabled = base.ViewModel.CanSave;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanSave")),
			(delegate
			{
				timeAdapter.DataSource = base.ViewModel.DeliveryTimes;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryTimes"))
		})).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		base.ViewModel.BindEvents(imageView.OnClick(Dismiss), saveButton.OnClick(base.ViewModel.Save)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(async delegate
		{
			await RequireActivity().WaitForStateAsync(AndroidX.Lifecycle.Lifecycle.State.Resumed);
			Dismiss();
		}, ViewLifecycleOwner);
	}

	private int FindMaxDateItemWidth()
	{
		View view = global::Android.Views.View.Inflate(Context, 2131493234, null);
		TextView textView = view.RequireViewById<TextView>(2131296892);
		TextView textView2 = view.RequireViewById<TextView>(2131296897);
		int num = 0;
		View obj = RequireActivity().Window?.DecorView;
		int size = obj?.Width ?? 0;
		int size2 = obj?.Height ?? 0;
		foreach (DateItemViewModel deliveryDate in base.ViewModel.DeliveryDates)
		{
			textView.Text = deliveryDate.DateText;
			textView2.Text = deliveryDate.DayText;
			view.Measure(global::Android.Views.View.MeasureSpec.MakeMeasureSpec(size, MeasureSpecMode.AtMost), global::Android.Views.View.MeasureSpec.MakeMeasureSpec(size2, MeasureSpecMode.AtMost));
			num = Math.Max(num, view.MeasuredWidth);
		}
		textView.Text = "";
		textView2.Text = "";
		return num;
	}

	private void BindDate(CachingViewHolder viewHolder, DateItemViewModel item, int index, CompositeDisposable disposable)
	{
		View root = viewHolder.ItemView;
		TextView textView = viewHolder.RequireCachedView<TextView>(2131296892);
		TextView textView2 = viewHolder.RequireCachedView<TextView>(2131296897);
		if (_maxDateItemWidth > 0)
		{
			root.UpdateLayoutParams(delegate(ViewGroup.LayoutParams p)
			{
				p.Width = _maxDateItemWidth;
			});
		}
		textView.Text = item.DateText;
		textView2.Text = item.DayText;
		root.OnClick((Action)delegate
		{
			item.Parent.SelectedDate = item;
		}).AddTo(disposable);
		item.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			root.Selected = item.Selected;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposable);
	}

	private void BindTime(CachingViewHolder viewHolder, TimeItemViewModel item, int index, CompositeDisposable disposable)
	{
		View root = viewHolder.ItemView;
		TextView textView = viewHolder.RequireCachedView<TextView>(2131298635);
		ImageView imageView = viewHolder.RequireCachedView<ImageView>(2131298637);
		TextView textView2 = viewHolder.RequireCachedView<TextView>(2131298636);
		textView.Text = item.TimeText;
		textView2.Text = item.PriceText;
		textView2.Visibility = item.IsPriceVisible.ToVisibility();
		imageView.Visibility = (item.IsPriceVisible && item.HasSurge).ToVisibility();
		textView2.SetTextColor(new Color(ContextCompat.GetColor(RequireContext(), item.HasSurge ? 2131100601 : 2131100604)));
		root.OnClick((Action)delegate
		{
			item.Parent.SelectTime(item);
		}).AddTo(disposable);
		item.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			root.Selected = item.Selected;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposable);
	}
}
