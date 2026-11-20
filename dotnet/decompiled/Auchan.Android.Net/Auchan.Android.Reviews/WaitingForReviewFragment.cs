using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Reviews;
using VisibilitySwitch;

namespace Auchan.Android.Reviews;

internal class WaitingForReviewFragment : BaseFragment<WaitingForReviewViewModel>
{
	private NestedScrollView _scrollView;

	private RecyclerView _unreviewedRecyclerView;

	protected override int LayoutId => 2131493124;

	public WaitingForReviewFragment(Func<Fragment, WaitingForReviewViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView? textView = view.FindViewById<TextView>(2131298679);
		AppCompatImageButton appCompatImageButton = view.FindViewById<AppCompatImageButton>(2131296490);
		_unreviewedRecyclerView = view.FindViewById<RecyclerView>(2131298785);
		_scrollView = view.RequireViewById<NestedScrollView>(2131298257);
		textView.Text = base.ViewModel.ScreenTitle;
		View view2 = view.FindViewById<View>(2131296904);
		View view3 = view.FindViewById<View>(2131297111);
		View view4 = view.FindViewById<View>(2131298079);
		TextView textView2 = view4.RequireViewById<TextView>(2131298080);
		TextView errorTitle = view3.RequireViewById<TextView>(2131298646);
		TextView errorMessage = view3.RequireViewById<TextView>(2131297563);
		AppCompatButton appCompatButton = view3.RequireViewById<AppCompatButton>(2131296325);
		view3.RequireViewById<Button>(2131298371).Visibility = ViewStates.Gone;
		VisibilitySwitch<WaitingForReviewViewModel.VisualState> viewSwitch = new VisibilitySwitch<WaitingForReviewViewModel.VisualState>(base.ViewModel.State)
		{
			{
				WaitingForReviewViewModel.VisualState.Default,
				view2
			},
			{
				WaitingForReviewViewModel.VisualState.InProgress,
				view4
			},
			{
				WaitingForReviewViewModel.VisualState.Error,
				view3
			}
		};
		textView2.Text = base.ViewModel.ProgressTitle;
		base.ViewModel.PagedUnreviewedProducts.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			SetupProductsList(base.ViewModel.PagedUnreviewedProducts.Count);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Count")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				viewSwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				errorTitle.Text = base.ViewModel.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(appCompatButton.OnClick(base.ViewModel.Retry), appCompatImageButton.OnClick(base.ParentFragmentManager.PopBackStack), _scrollView.OnScrollChange(ScrollViewScrolled)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.AddReviewCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<AddReviewFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
	}

	private void ScrollViewScrolled(object sender, NestedScrollView.ScrollChangeEventArgs e)
	{
		int height = _scrollView.GetChildAt(0).Height;
		int height2 = _scrollView.Height;
		int scrollY = _scrollView.ScrollY;
		int num = Converter.DpToPx(140f) * 5;
		if (scrollY > height - height2 - num)
		{
			base.ViewModel.PagedUnreviewedProducts.LoadMore();
		}
	}

	private void SetupProductsList(int count)
	{
		ObservableRecyclerAdapter<UnreviewedProductItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<UnreviewedProductItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493359,
			DataSource = base.ViewModel.PagedUnreviewedProducts,
			BindViewHolderDelegate = OnBindUnreviewedProducts,
			ClickCallback = OnReviewClicked
		};
		_unreviewedRecyclerView.SetLayoutManager(new LinearLayoutManager(Context, 1, reverseLayout: false));
		_unreviewedRecyclerView.SetAdapter(adapter);
	}

	private void OnBindUnreviewedProducts(CachingViewHolder holder, UnreviewedProductItemViewModel unreviewedProduct, int position, CompositeDisposable disposable)
	{
		ImageView? imageView = holder.FindCachedView<ImageView>(2131297999);
		TextView textView = holder.FindCachedView<TextView>(2131298004);
		RatingView ratingView = holder.FindCachedView<RatingView>(2131298148);
		ReviewRewardStickerView reviewRewardStickerView = holder.FindCachedView<ReviewRewardStickerView>(2131298232);
		((View)holder.FindCachedView<ImageView>(2131296924)).OnClick((Action)delegate
		{
			base.ViewModel.OnProductDelete(unreviewedProduct);
		}).AddTo(disposable);
		imageView.FromUrl(unreviewedProduct.ImageUrl);
		textView.Text = unreviewedProduct.Title;
		ratingView.SetupReadOnly(0.0, 16f, 2f);
		reviewRewardStickerView.Setup(unreviewedProduct.ReviewRewardSticker);
		ratingView.Visibility = (unreviewedProduct.ReviewRewardSticker == null).ToVisibility();
	}

	private void OnReviewClicked(CachingViewHolder vh, UnreviewedProductItemViewModel vm, int pos)
	{
		base.ViewModel.OnProductClick(vm);
	}
}
