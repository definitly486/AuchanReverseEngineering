using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Controls.ZoomableImageSlider;
using Auchan.Android.Ecom.Product;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Reviews;
using Auchan.Common.Reviews.Model;
using Google.Android.Material.Button;
using Google.Android.Material.Card;
using VisibilitySwitch;

namespace Auchan.Android.Reviews;

internal class ProductReviewsFragment : BaseToolbarFragment<ProductReviewsViewModel>
{
	private sealed class FooterControls(ConstraintLayout layout)
	{
		public ConstraintLayout Layout => layout;

		public MaterialButton FeedbackButton { get; } = layout.RequireViewById<MaterialButton>(2131297149);
	}

	private sealed class Controls(View view)
	{
		public View View => view;

		public NestedScrollView ScrollView { get; } = view.RequireViewById<NestedScrollView>(2131298257);

		public View Toolbar { get; } = view.RequireViewById<View>(2131298669);

		public RecyclerView ReviewsList { get; } = view.RequireViewById<RecyclerView>(2131298243);

		public Button AddReviewButton { get; } = view.RequireViewById<Button>(2131296358);

		public LinearLayout DefaultLayout { get; } = view.RequireViewById<LinearLayout>(2131296904);

		public FrameLayout ProgressLayout { get; } = view.RequireViewById<FrameLayout>(2131298079);

		public View SortButton { get; } = view.RequireViewById<View>(2131298417);

		public TextView SortButtonTextView { get; } = view.RequireViewById<TextView>(2131298415);

		public View PhotoFilter { get; } = view.RequireViewById<View>(2131297886);

		public MaterialCardView PhoteFilterBorder { get; } = view.RequireViewById<MaterialCardView>(2131297885);

		public TextView PhotoFilterTextView { get; } = view.RequireViewById<TextView>(2131297887);

		public TextView ToolBarTitle { get; } = view.RequireViewById<TextView>(2131298679);

		public TextView ToolBarCount { get; } = view.RequireViewById<TextView>(2131298678);

		public ErrorLayoutControls ErrorLayout { get; } = new ErrorLayoutControls(view.RequireViewById<ConstraintLayout>(2131297111));

		public FooterControls Footer { get; } = new FooterControls(view.RequireViewById<ConstraintLayout>(2131297211));
	}

	private readonly FragmentFactory _fragmentFactory;

	private readonly ProductFooterBinder _footerBinder;

	private bool _alreadyScrolled;

	private const int REVIEWS_PAGE_SIZE = 10;

	private ObservableCollection<ReviewItemViewModel> _shownReviews = new ObservableCollection<ReviewItemViewModel>();

	protected override int LayoutId => 2131493079;

	public ProductReviewsFragment(Func<ProductReviewsViewModel.Parameter, ProductReviewsViewModel> newViewModel, FragmentFactory fragmentFactory, ProductFooterBinder footerBinder)
		: base((Func<Fragment, ProductReviewsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<ProductReviewsViewModel.Parameter>())))
	{
		_fragmentFactory = fragmentFactory;
		_footerBinder = footerBinder;
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.OpenSortPopup.SafeSubscribe(delegate(BrokerToken t)
		{
			Show<ReviewSortFragment, BrokerToken>(t);
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Controls controls = new Controls(view);
		controls.AddReviewButton.Text = base.ViewModel.AddReviewButtonTitle;
		controls.PhotoFilterTextView.Text = base.ViewModel.ReviewsWithPhotoText;
		controls.ErrorLayout.ShowQrButton.Visibility = ViewStates.Gone;
		controls.Footer.Layout.Visibility = ViewStates.Gone;
		controls.Footer.FeedbackButton.Visibility = ViewStates.Gone;
		_footerBinder.Bind(base.ViewModel.Footer, controls.Footer.Layout, ViewLifecycleOwner, base.ViewModel);
		VisibilitySwitch<ProductReviewsViewModel.VisualState> viewSwitch = new VisibilitySwitch<ProductReviewsViewModel.VisualState>(base.ViewModel.State)
		{
			{
				ProductReviewsViewModel.VisualState.Default,
				controls.DefaultLayout
			},
			{
				ProductReviewsViewModel.VisualState.InProgress,
				controls.ProgressLayout
			},
			{
				ProductReviewsViewModel.VisualState.Error,
				controls.ErrorLayout.Layout
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[11]
		{
			(delegate
			{
				viewSwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				controls.ToolBarTitle.Text = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				controls.ToolBarCount.Text = base.ViewModel.ReviewCountString;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReviewCountString")),
			(delegate
			{
				SetupRatePercentages(view, base.ViewModel.Rate);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Rate")),
			(delegate
			{
				controls.ErrorLayout.ShowQrButton.Visibility = base.ViewModel.IsAuthorized.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAuthorized")),
			(delegate
			{
				controls.AddReviewButton.Visibility = base.ViewModel.ReviewingIsAllowed.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReviewingIsAllowed")),
			(delegate
			{
				SwitchFilterButtonBorder(controls, base.ViewModel.IsPhotoFilterActive);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsPhotoFilterActive")),
			(delegate
			{
				SetupReviewsList(controls, base.ViewModel.ReviewList);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReviewList")),
			(delegate
			{
				controls.PhotoFilter.Visibility = base.ViewModel.IsPhotoFilterButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsPhotoFilterButtonVisible")),
			(delegate
			{
				controls.SortButtonTextView.Text = base.ViewModel.SelectedSort.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedSort")),
			(delegate
			{
				controls.Footer.Layout.Visibility = (base.ViewModel.IsFooterVisible && base.ViewModel.State == ProductReviewsViewModel.VisualState.Default).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "IsFooterVisible", "State" }))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(controls.ErrorLayout.Action.OnClick(base.ViewModel.Retry), ((View)controls.ErrorLayout.ShowQrButton).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		}), controls.AddReviewButton.OnClick(AddReview), controls.SortButton.OnClick(base.ViewModel.SortClickCommand.Trigger), controls.PhotoFilter.OnClick(base.ViewModel.PhotoFilterClickCommand.Trigger), controls.ScrollView.OnScrollChange((Action)delegate
		{
			ShowMoreReviewsIfNeeded(controls);
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OpenReviewDetailsCommand.SafeSubscribe(NavigateToReviewDetails, ViewLifecycleOwner);
		base.ViewModel.NavigateToAddReviewCommand.SafeSubscribe(delegate(BrokerToken x)
		{
			Show<AddReviewFragment, BrokerToken>(x);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenMenuOptionsCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<ReportReviewFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
	}

	private void SwitchFilterButtonBorder(Controls controls, bool isPhotoFilterActive)
	{
		controls.PhoteFilterBorder.SetStrokeColor(ContextCompat.GetColorStateList(Context, isPhotoFilterActive ? 2131100611 : 2131099848));
	}

	private void ScrollToSelectedIfNeeded(Controls controls)
	{
		if (_alreadyScrolled)
		{
			return;
		}
		_alreadyScrolled = true;
		Task.Delay(500).ContinueWith(delegate
		{
			if (base.ViewModel.InitialReviewIndex > 0)
			{
				ScrollToReviewAtIndex(controls, base.ViewModel.InitialReviewIndex);
			}
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	private void NavigateToReviewDetails(ReviewDetailsViewModel.Parameter parameter)
	{
		NavigateTo<ReviewDetailsFragment, ReviewDetailsViewModel.Parameter>(parameter, null, add: true);
	}

	private void AddReview()
	{
		base.ViewModel.AddReviewCommand.Trigger(base.ViewModel.AddReviewNavigationParameter);
	}

	private void ScrollToReviewAtIndex(Controls controls, int index)
	{
		View view = controls.ReviewsList.GetLayoutManager().FindViewByPosition(index);
		int[] array = new int[2];
		view.GetLocationOnScreen(array);
		double num = (double)array[1] - (double)controls.Toolbar.Height * 1.5;
		if (num > 0.0)
		{
			controls.ScrollView.SmoothScrollTo(0, (int)num);
		}
	}

	private void SetupRatePercentages(View view, Rate? rate)
	{
		if (rate != null)
		{
			RatePercentageView[] array = new RatePercentageView[5]
			{
				view.RequireViewById<RatePercentageView>(2131298141),
				view.RequireViewById<RatePercentageView>(2131298142),
				view.RequireViewById<RatePercentageView>(2131298143),
				view.RequireViewById<RatePercentageView>(2131298144),
				view.RequireViewById<RatePercentageView>(2131298145)
			};
			int[] array2 = new int[5] { rate.Rate1, rate.Rate2, rate.Rate3, rate.Rate4, rate.Rate5 };
			for (int i = 0; i < array2.Count(); i++)
			{
				RatePercentageView ratePercentageView = array[i];
				ratePercentageView.TitleText.Text = $"{i + 1} {GrammarHelper.DeclineNoun(i + 1, new string[3] { "звезда", "звезды", "звёзд" })}";
				ratePercentageView.CountText.Text = $"{array2[i]}";
				ratePercentageView.CountText.SetTextColor(ContextCompat.GetColorStateList(Context, (array2[i] > 0) ? 2131099706 : 2131100604));
				ratePercentageView.ProgressBar.Progress = (int)((double)array2[i] * 1.0 / (double)rate.ReviewsCount * 100.0);
			}
			view.RequireViewById<RatingView>(2131298138).SetupReadOnly(rate.Rating, 16f, 2f);
			view.RequireViewById<TextView>(2131298731).Text = $"{rate.Rating:0.#} / {array2.Count()}";
		}
	}

	private void SetupReviewsList(Controls controls, ReviewList reviewList)
	{
		_shownReviews = new ObservableCollection<ReviewItemViewModel>(base.ViewModel.Items.Take(InitialShownReviewsCount()));
		ObservableRecyclerAdapter<ReviewItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<ReviewItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493184,
			DataSource = _shownReviews,
			BindViewHolderDelegate = delegate(CachingViewHolder h, ReviewItemViewModel e, int p, CompositeDisposable d)
			{
				OnBindReviewInList(controls, h, e, p, d);
			},
			ClickCallback = delegate(CachingViewHolder vh, ReviewItemViewModel vm, int pos)
			{
				OnReviewClicked(vm.Review);
			}
		};
		controls.ReviewsList.SetLayoutManager(new LinearLayoutManager(Context, 1, reverseLayout: false));
		controls.ReviewsList.SetAdapter(adapter);
	}

	private int InitialShownReviewsCount()
	{
		return Math.Min(base.ViewModel.Items.Count, Math.Max(10, base.ViewModel.InitialReviewIndex + 1));
	}

	private void ShowMoreReviewsIfNeeded(Controls controls)
	{
		if (_shownReviews.Count >= base.ViewModel.Items.Count)
		{
			return;
		}
		View childAt = controls.ScrollView.GetChildAt(0);
		if (childAt == null || childAt.Height - controls.ScrollView.Height - controls.ScrollView.ScrollY > controls.ScrollView.Height)
		{
			return;
		}
		foreach (ReviewItemViewModel item in base.ViewModel.Items.Skip(_shownReviews.Count).Take(10))
		{
			_shownReviews.Add(item);
		}
	}

	private void OnReviewClicked(Review vm)
	{
		base.ViewModel.OpenReviewDetailsCommand.Trigger(new ReviewDetailsViewModel.Parameter(vm));
	}

	private void OnBindReviewInList(Controls controls, CachingViewHolder holder, ReviewItemViewModel itemViewModel, int position, CompositeDisposable disposable)
	{
		ReviewView reviewView = holder.RequireCachedView<ReviewView>(2131298240);
		reviewView.ClearSubscriptions();
		reviewView.Setup(itemViewModel.Review, delegate
		{
			OnReviewClicked(itemViewModel.Review);
		}, ReviewViewMode.CompactPreviewList, disposable);
		((View)reviewView).UpdateLayoutParams<ViewGroup.LayoutParams>((Action<ViewGroup.LayoutParams>)delegate(ViewGroup.LayoutParams lp)
		{
			lp.Width = -1;
			lp.Height = -2;
		});
		base.ViewModel.BindEvents(reviewView.OnThumbnailTappedEvent(OnThumbnailTapped), reviewView.MenuOptionsView.OnClick((Action)delegate
		{
			base.ViewModel.OnMenuOptionsCommand.Trigger(itemViewModel.Review);
		})).AddTo(disposable);
		if (position == _shownReviews.Count - 1)
		{
			ScrollToSelectedIfNeeded(controls);
		}
	}

	private void OnThumbnailTapped(IReadOnlyList<string?> urls, int index)
	{
		ZoomableImageSliderFragment zoomableImageSliderFragment = _fragmentFactory.Instantiate<ZoomableImageSliderFragment>();
		zoomableImageSliderFragment.ImageItemViewModels.AddRange(urls.Select((string x) => new ImageItemViewModel(x)));
		zoomableImageSliderFragment.CurrentIndex = index;
		zoomableImageSliderFragment.Show(base.ChildFragmentManager, null);
	}
}
