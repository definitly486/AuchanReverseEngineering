using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram.ViewHolders;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsExpiration;
using Java.Interop;
using VisibilitySwitch;

namespace Auchan.Android.LoyaltyProgram;

internal class LoyaltyCardPointsExpirationFragment : BaseToolbarFragment<LoyaltyCardPointsExpirationViewModel>, NestedScrollView.IOnScrollChangeListener, IJavaObject, IDisposable, IJavaPeerable
{
	private NestedScrollView _scrollView;

	private View _scrolledLineView;

	private View _topContentView;

	private View _warningInfoView;

	protected override int LayoutId => 2131493043;

	public LoyaltyCardPointsExpirationFragment(Func<LoyaltyCardPointsExpirationViewModel.Parameter, LoyaltyCardPointsExpirationViewModel> newViewModel)
		: base((Func<Fragment, LoyaltyCardPointsExpirationViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<LoyaltyCardPointsExpirationViewModel.Parameter>())))
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		base.ToolbarTitle = base.ViewModel.ScreenTitle;
		_scrollView = view.RequireViewById<NestedScrollView>(2131298303);
		_scrolledLineView = view.RequireViewById<View>(2131298305);
		_topContentView = _scrollView.RequireViewById<View>(2131298711);
		NewLoyaltyBalanceView newLoyaltyBalanceView = _topContentView.RequireViewById<NewLoyaltyBalanceView>(2131297486);
		_warningInfoView = _scrollView.RequireViewById<View>(2131298823);
		TextView warningLabel = _warningInfoView.RequireViewById<TextView>(2131298824);
		RecyclerView recyclerView = _scrollView.RequireViewById<RecyclerView>(2131297942);
		View view2 = _scrollView.RequireViewById<View>(2131297084);
		TextView textView = view2.RequireViewById<TextView>(2131297083);
		TextView textView2 = view2.RequireViewById<TextView>(2131297078);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		TextView errorTitle = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView errorMessage = constraintLayout.RequireViewById<TextView>(2131297563);
		AppCompatButton appCompatButton = constraintLayout.RequireViewById<AppCompatButton>(2131296325);
		Button button = constraintLayout.RequireViewById<Button>(2131298371);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		recyclerView.NestedScrollingEnabled = false;
		recyclerView.SetLayoutManager(new LinearLayoutManager(base.Activity, 1, reverseLayout: false));
		ObservableRecyclerAdapter<FeedItemViewModel, CachingViewHolder> pointsAdapter = new ObservableRecyclerAdapter<FeedItemViewModel, CachingViewHolder>
		{
			CreateViewHolderDelegate = CreateViewHolderDelegate,
			GetItemViewTypeDelegate = GetItemViewTypeDelegate,
			BindViewHolderDelegate = BindViewHolderDelegate
		};
		recyclerView.SetAdapter(pointsAdapter);
		textView.Text = base.ViewModel.EmptyTitle;
		textView2.Text = base.ViewModel.EmptyDescription;
		_scrollView.SetOnScrollChangeListener(this);
		view2.ViewTreeObserver.AddOnGlobalLayoutListener(new OneTimeOnGlobalLayoutListener(view2, ViewTreeMeasured));
		VisibilitySwitch<LoyaltyCardPointsExpirationViewModel.VisualState> viewSwitch = new VisibilitySwitch<LoyaltyCardPointsExpirationViewModel.VisualState>(base.ViewModel.State)
		{
			LoyaltyCardPointsExpirationViewModel.VisualState.Default,
			{
				LoyaltyCardPointsExpirationViewModel.VisualState.InProgress,
				frameLayout
			},
			{
				LoyaltyCardPointsExpirationViewModel.VisualState.Error,
				constraintLayout
			},
			{
				LoyaltyCardPointsExpirationViewModel.VisualState.Empty,
				view2
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[5]
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
				errorMessage.Text = base.ViewModel.ErrorDescription;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorDescription")),
			(delegate
			{
				warningLabel.Text = base.ViewModel.HintText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HintText")),
			(delegate
			{
				pointsAdapter.DataSource = base.ViewModel.ItemsCollection;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ItemsCollection"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(appCompatButton.OnClick(base.ViewModel.Retry), ((View)button).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		newLoyaltyBalanceView.Setup(base.ViewModel.NewLoyaltyCardBalanceItemViewModel, ViewLifecycleOwner);
	}

	private CachingViewHolder CreateViewHolderDelegate(ViewGroup recyclerView, int cellLayoutId)
	{
		View itemView = base.LayoutInflater.Inflate(cellLayoutId, recyclerView, attachToRoot: false);
		return cellLayoutId switch
		{
			2131493283 => new MonthAndYearItemViewHolder(itemView), 
			2131493282 => new DateItemViewHolder(itemView), 
			2131493281 => new PointsExpirationItemViewHolder(itemView), 
			_ => throw new NotImplementedException($"Cannot resolve any ViewHolder for {cellLayoutId} cell layout id"), 
		};
	}

	private int GetItemViewTypeDelegate(int position)
	{
		Type type = base.ViewModel.ItemsCollection[position].GetType();
		if (type == typeof(MonthAndYearItemViewModel))
		{
			return 2131493283;
		}
		if (type == typeof(DateItemViewModel))
		{
			return 2131493282;
		}
		if (type == typeof(PointsExpirationItemViewModel))
		{
			return 2131493281;
		}
		throw new NotImplementedException($"Cannot resolve any cell layout id for {type} type");
	}

	private void BindViewHolderDelegate(CachingViewHolder holder, FeedItemViewModel model, int position, CompositeDisposable disposable)
	{
		if (holder is MonthAndYearItemViewHolder monthAndYearItemViewHolder)
		{
			monthAndYearItemViewHolder.DoBind((MonthAndYearItemViewModel)model, disposable);
		}
		else if (holder is DateItemViewHolder dateItemViewHolder)
		{
			dateItemViewHolder.DoBind((DateItemViewModel)model, disposable);
		}
		else if (holder is PointsExpirationItemViewHolder pointsExpirationItemViewHolder)
		{
			pointsExpirationItemViewHolder.DoBind((PointsExpirationItemViewModel)model, disposable);
		}
	}

	private void ViewTreeMeasured(View view)
	{
		int widthMeasureSpec = global::Android.Views.View.MeasureSpec.MakeMeasureSpec(_scrollView.MeasuredWidth, MeasureSpecMode.Exactly);
		int heightMeasureSpec = global::Android.Views.View.MeasureSpec.MakeMeasureSpec(View.MeasuredHeight, MeasureSpecMode.AtMost);
		view.Measure(widthMeasureSpec, heightMeasureSpec);
		int measuredHeight = view.MeasuredHeight;
		int measuredHeight2 = _scrollView.MeasuredHeight;
		int measuredHeight3 = _topContentView.MeasuredHeight;
		ViewGroup.LayoutParams layoutParameters = view.LayoutParameters;
		int num = measuredHeight2 - measuredHeight3;
		int height = ((measuredHeight < num) ? num : measuredHeight);
		layoutParameters.Height = height;
		view.LayoutParameters = layoutParameters;
	}

	public void OnScrollChange(NestedScrollView v, int scrollX, int scrollY, int oldScrollX, int oldScrollY)
	{
		_scrolledLineView.Visibility = ((scrollY == 0) ? ViewStates.Gone : ViewStates.Visible);
	}
}
