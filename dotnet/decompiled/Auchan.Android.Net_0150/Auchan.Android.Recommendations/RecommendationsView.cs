using System;
using System.Reactive.Disposables;
using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Extensions;
using Auchan.Common.Recommendations.ViewModels;
using _Microsoft.Android.Resource.Designer;

namespace Auchan.Android.Recommendations;

[Register("auchan.RecommendationsView")]
public class RecommendationsView : FrameLayout
{
	private RecyclerView _recyclerView;

	private RecommendationsViewModel _viewModel;

	private IYandexMetricaScreenViewModel _screenViewModel;

	private Func<View, IObservable<bool>>? _notifier;

	public bool AlwaysHideDivider { get; set; }

	public bool OnDarkBackground { get; set; }

	public int SectionTopMargin { get; set; }

	public int AllSectionsBottomMargin { get; set; }

	public int SectionLeftMargin { get; set; }

	public int SectionRightMargin { get; set; }

	protected RecommendationsView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public RecommendationsView(Context context)
		: base(context)
	{
		Initialize(context);
	}

	public RecommendationsView(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public RecommendationsView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs, defStyleAttr);
	}

	public RecommendationsView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context, attrs, defStyleAttr, defStyleRes);
	}

	private void Initialize(Context context, IAttributeSet? attrs = null, int defStyleAttr = 0, int defStyleRes = 0)
	{
		if (attrs != null)
		{
			TypedArray typedArray = context.ObtainStyledAttributes(attrs, ResourceConstant.Styleable.RecommendationsView);
			AlwaysHideDivider = typedArray.GetBoolean(1, defValue: false);
			OnDarkBackground = typedArray.GetBoolean(2, defValue: false);
			SectionLeftMargin = typedArray.GetDimensionPixelSize(3, 0);
			SectionRightMargin = typedArray.GetDimensionPixelSize(4, 0);
			SectionTopMargin = typedArray.GetDimensionPixelSize(5, 0);
			AllSectionsBottomMargin = typedArray.GetDimensionPixelSize(0, 0);
			typedArray.Recycle();
		}
		SetClipChildren(clipChildren: false);
		SetClipToPadding(clipToPadding: false);
		View view = View.Inflate(context, 2131493179, this);
		_recyclerView = view.RequireViewById<RecyclerView>(2131298179);
		_recyclerView.SetPadding(0, 0, 0, AllSectionsBottomMargin);
	}

	public void Setup(IYandexMetricaScreenViewModel screenViewModel, RecommendationsViewModel viewModel, ILifecycleOwner lifecycleOwner, Func<View, IObservable<bool>>? notifier)
	{
		_screenViewModel = screenViewModel;
		_viewModel = viewModel;
		_notifier = notifier;
		ObservableRecyclerAdapter<SectionItemViewModel, CachingViewHolder> observableRecyclerAdapter = new ObservableRecyclerAdapter<SectionItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493315,
			DataSource = viewModel.Sections,
			BindViewHolderDelegate = BindRecommendation
		};
		observableRecyclerAdapter.DisposeViewHolders().AutoDisposeOnDestroy(lifecycleOwner);
		_recyclerView.SetAdapter(observableRecyclerAdapter);
		_recyclerView.NestedScrollingEnabled = false;
		_recyclerView.AddItemDecoration(new VerticalSpaceItemDecoration(22));
		View divider = RequireViewById<View>(2131298182);
		viewModel.OnPropertyChanges((RecommendationsViewModel x) => x.HasItems).SafeSubscribe(delegate(bool hasItems)
		{
			_recyclerView.Visibility = hasItems.ToVisibility();
			divider.Visibility = (AlwaysHideDivider ? ViewStates.Gone : hasItems.ToVisibility());
		}, lifecycleOwner);
	}

	private void BindRecommendation(CachingViewHolder viewHolder, SectionItemViewModel itemViewModel, int position, CompositeDisposable disposables)
	{
		new RecommendationSectionBindings(viewHolder, _viewModel, nestedScrollEnabled: true).Bind(itemViewModel, _screenViewModel, _notifier, SectionTopMargin, SectionLeftMargin, SectionRightMargin, disposables, OnDarkBackground);
	}

	public void ForceHideDivider()
	{
		AlwaysHideDivider = true;
	}
}
