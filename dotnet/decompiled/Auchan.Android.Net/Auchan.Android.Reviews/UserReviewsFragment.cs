using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Controls.ZoomableImageSlider;
using Auchan.Android.Ecom.Banners;
using Auchan.Android.Extensions;
using Auchan.Android.InfoPages;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages;
using Auchan.Common.Reviews;
using Auchan.Common.Reviews.Api.Ecom.Dto.Enums;
using Auchan.Common.Reviews.Model;
using VisibilitySwitch;

namespace Auchan.Android.Reviews;

internal class UserReviewsFragment : BaseToolbarFragment<UserReviewsViewModel>, IBannerNavigationSupport, IFragmentNavigation
{
	private readonly FragmentFactory _fragmentFactory;

	private RecyclerView _reviewsList;

	private RecyclerView _productsList;

	private NestedScrollView _scrollView;

	private TextView _waitigProductsTitle;

	private TextView _reviewsHistoryTitle;

	private TextView _allProductsButtonTitle;

	private ViewGroup _waitingProductsHeader;

	private ViewGroup _allProductsButton;

	private View _bannerContainer;

	private ViewGroup _noReviewsLayout;

	private TextView _noReviewsTitle;

	private TextView _noReviewsSubtitle;

	private ObservableRecyclerAdapter<UnreviewedProductItemViewModel, CachingViewHolder> _productListAdapter;

	protected override int LayoutId => 2131493120;

	private bool IsEmptyState
	{
		get
		{
			if (!base.ViewModel.WaitingForReviewViewModel.PagedUnreviewedProducts.HasItems)
			{
				return !base.ViewModel.PagedReviews.HasItems;
			}
			return false;
		}
	}

	public UserReviewsFragment(Func<Fragment, UserReviewsViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base(newViewModel)
	{
		_fragmentFactory = fragmentFactory;
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		_scrollView = view.RequireViewById<NestedScrollView>(2131298257);
		_bannerContainer = view.RequireViewById<View>(2131296510);
		ImageView bannerImageView = view.RequireViewById<ImageView>(2131296511);
		_reviewsList = view.RequireViewById<RecyclerView>(2131298243);
		_productsList = view.RequireViewById<RecyclerView>(2131298039);
		_waitigProductsTitle = view.RequireViewById<TextView>(2131298814);
		_allProductsButtonTitle = view.RequireViewById<TextView>(2131296429);
		_waitingProductsHeader = view.RequireViewById<ViewGroup>(2131298813);
		_allProductsButton = view.RequireViewById<ViewGroup>(2131296428);
		_reviewsHistoryTitle = view.RequireViewById<TextView>(2131298242);
		_noReviewsLayout = view.RequireViewById<ViewGroup>(2131297690);
		_noReviewsTitle = view.RequireViewById<TextView>(2131297693);
		_noReviewsSubtitle = view.RequireViewById<TextView>(2131297691);
		View view2 = view.FindViewById<View>(2131296904);
		View view3 = view.FindViewById<View>(2131297111);
		View view4 = view.FindViewById<View>(2131298079);
		TextView toolBarTitle = view.RequireViewById<TextView>(2131298679);
		TextView textView = view4.RequireViewById<TextView>(2131298080);
		TextView errorTitle = view3.RequireViewById<TextView>(2131298646);
		TextView errorMessage = view3.RequireViewById<TextView>(2131297563);
		AppCompatButton appCompatButton = view3.RequireViewById<AppCompatButton>(2131296325);
		view3.RequireViewById<Button>(2131298371).Visibility = ViewStates.Gone;
		VisibilitySwitch<UserReviewsViewModel.VisualState> viewSwitch = new VisibilitySwitch<UserReviewsViewModel.VisualState>(base.ViewModel.State)
		{
			{
				UserReviewsViewModel.VisualState.Default,
				view2
			},
			{
				UserReviewsViewModel.VisualState.InProgress,
				view4
			},
			{
				UserReviewsViewModel.VisualState.Error,
				view3
			}
		};
		textView.Text = base.ViewModel.ProgressTitle;
		_productListAdapter = new ObservableRecyclerAdapter<UnreviewedProductItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493363,
			DataSource = base.ViewModel.WaitingForReviewViewModel.PagedUnreviewedProducts,
			BindViewHolderDelegate = OnBindProductInList,
			ClickCallback = OnProductClicked
		};
		_productsList.SetLayoutManager(new LinearLayoutManager(Context, 0, reverseLayout: false));
		_productsList.SetAdapter(_productListAdapter);
		base.ViewModel.WaitingForReviewViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
		{
			(delegate
			{
				_waitigProductsTitle.Text = base.ViewModel.WaitingForReviewViewModel.ScreenTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ScreenTitle")),
			(delegate
			{
				_allProductsButtonTitle.Text = base.ViewModel.WaitingForReviewViewModel.AllButtonTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AllButtonTitle")),
			(delegate
			{
				SetupProductsList(base.ViewModel.WaitingForReviewViewModel.PagedUnreviewedProducts.Count);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Count")),
			(delegate
			{
				UpdateEmptyState();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasProducts"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.WaitingForReviewViewModel.PagedUnreviewedProducts.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			SetupProductsList(base.ViewModel.WaitingForReviewViewModel.PagedUnreviewedProducts.Count);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Count")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.PagedReviews.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			SetupReviewsList(base.ViewModel.PagedReviews.Count);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Count")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[14]
		{
			(delegate
			{
				viewSwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				toolBarTitle.Text = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				_waitigProductsTitle.Text = base.ViewModel.WaitingForReviewViewModel.ScreenTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("WaitingForReviewViewModel")),
			(delegate
			{
				_allProductsButtonTitle.Text = base.ViewModel.WaitingForReviewViewModel.AllButtonTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("WaitingForReviewViewModel")),
			(delegate
			{
				_reviewsHistoryTitle.Text = base.ViewModel.ReviewHistoryLabel;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReviewHistoryLabel")),
			(delegate
			{
				_noReviewsTitle.Text = base.ViewModel.NoReviewsTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NoReviewsTitle")),
			(delegate
			{
				_noReviewsSubtitle.Text = base.ViewModel.NoReviewsSubtitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NoReviewsSubtitle")),
			(delegate
			{
				SetupReviewsList(base.ViewModel.PagedReviews.Count);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PagedReviews")),
			(delegate
			{
				SetupProductsList(base.ViewModel.WaitingForReviewViewModel.PagedUnreviewedProducts.Count);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("WaitingForReviewViewModel")),
			(delegate
			{
				UpdateEmptyState();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "WaitingForReviewViewModel", "HasReviews" })),
			(delegate
			{
				errorTitle.Text = base.ViewModel.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				SetupBannerVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Banner")),
			(delegate
			{
				bannerImageView.FromUrl(base.ViewModel.Banner?.Image);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Banner"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(_allProductsButton.OnClick(base.ViewModel.OpenUnreviewedProducts), appCompatButton.OnClick(base.ViewModel.Retry), _scrollView.OnLayoutChange(ScrollViewLayoutChanged), _scrollView.OnScrollChange(ScrollViewScrolled), _productsList.OnScrollChange(ProductsScrolled), ((View)bannerImageView).OnClick((Action)delegate
		{
			base.ViewModel.BannerCommand.Trigger();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OpenReviewDetailsCommand.SafeSubscribe(delegate(ReviewDetailsViewModel.Parameter p)
		{
			NavigateTo<ReviewDetailsFragment, ReviewDetailsViewModel.Parameter>(p, null, add: true);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenUnreviewedProductsCommand.SafeSubscribe(delegate
		{
			NavigateTo<WaitingForReviewFragment>(null, add: true);
		}, ViewLifecycleOwner);
		base.ViewModel.AddReviewCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<AddReviewFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenReviewRulesCommand.SafeSubscribe(delegate(InfoPageViewModel.Parameter p)
		{
			NavigateTo<InfoPageFragment, InfoPageViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		this.SetupBannersNavigation(base.ViewModel.BannerNavigationSupport, this);
	}

	private void ProductsScrolled(object sender, View.ScrollChangeEventArgs e)
	{
		int num = _productsList.ComputeHorizontalScrollRange();
		int width = _productsList.Width;
		if (_productsList.ComputeHorizontalScrollOffset() > num - 2 * width)
		{
			base.ViewModel.WaitingForReviewViewModel.PagedUnreviewedProducts.LoadMore();
		}
	}

	private void ScrollViewScrolled(object sender, NestedScrollView.ScrollChangeEventArgs e)
	{
		int height = _scrollView.GetChildAt(0).Height;
		int height2 = _scrollView.Height;
		if (_scrollView.ScrollY > height - 2 * height2)
		{
			base.ViewModel.PagedReviews.LoadMore();
		}
	}

	private void ScrollViewLayoutChanged(object sender, View.LayoutChangeEventArgs e)
	{
		UpdateEmptyStateHeight();
	}

	private void SetupProductsList(int count)
	{
		_productListAdapter.NotifyDataSetChanged();
		_waitingProductsHeader.Visibility = base.ViewModel.WaitingForReviewViewModel.PagedUnreviewedProducts.HasItems.ToVisibility();
		_productsList.Visibility = base.ViewModel.WaitingForReviewViewModel.PagedUnreviewedProducts.HasItems.ToVisibility();
		_reviewsHistoryTitle.Visibility = (base.ViewModel.PagedReviews.HasItems && base.ViewModel.WaitingForReviewViewModel.PagedUnreviewedProducts.HasItems).ToVisibility();
		UpdateEmptyState();
	}

	private void OnProductClicked(CachingViewHolder holder, UnreviewedProductItemViewModel model, int position)
	{
		base.ViewModel.OnProductClick(model);
	}

	private void OnRemoveProductClicked(UnreviewedProductItemViewModel model)
	{
		base.ViewModel.WaitingForReviewViewModel.OnProductDelete(model);
	}

	private void OnBindProductInList(CachingViewHolder holder, UnreviewedProductItemViewModel model, int position, CompositeDisposable disposable)
	{
		holder.RequireCachedView<ImageView>(2131297999).FromUrl(model.ImageUrl);
		RatingView ratingView = holder.RequireCachedView<RatingView>(2131298138);
		ratingView.SetupReadOnly(0.0, 16f, 2f);
		holder.RequireCachedView<ReviewRewardStickerView>(2131298232).Setup(model.ReviewRewardSticker);
		ratingView.Visibility = (model.ReviewRewardSticker == null).ToVisibility();
		((View)holder.RequireCachedView<ImageView>(2131296791)).OnClick((Action)delegate
		{
			OnRemoveProductClicked(model);
		}).AddTo(disposable);
	}

	private void SetupReviewsList(int count)
	{
		ObservableRecyclerAdapter<UserReviewItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<UserReviewItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493362,
			DataSource = base.ViewModel.PagedReviews,
			BindViewHolderDelegate = OnBindReviewInList,
			ClickCallback = delegate(CachingViewHolder _, UserReviewItemViewModel vm, int _)
			{
				OnReviewClicked(vm.Review);
			}
		};
		_reviewsList.SetLayoutManager(new LinearLayoutManager(Context, 1, reverseLayout: false));
		_reviewsList.SetAdapter(adapter);
		_reviewsList.Visibility = base.ViewModel.PagedReviews.HasItems.ToVisibility();
		_reviewsHistoryTitle.Visibility = (base.ViewModel.PagedReviews.HasItems && base.ViewModel.WaitingForReviewViewModel.PagedUnreviewedProducts.HasItems).ToVisibility();
		UpdateEmptyState();
	}

	private void UpdateEmptyState()
	{
		_noReviewsLayout.Visibility = IsEmptyState.ToVisibility();
		if (IsEmptyState)
		{
			UpdateEmptyStateHeight();
		}
		else
		{
			_noReviewsLayout.SetMinimumHeight(0);
		}
	}

	private void SetupBannerVisibility()
	{
		_bannerContainer.Visibility = base.ViewModel.Banner.ToVisibility();
		UpdateEmptyState();
	}

	private void UpdateEmptyStateHeight()
	{
		if (IsEmptyState && _scrollView.Height != 0)
		{
			int num = ((_bannerContainer.Visibility == ViewStates.Visible) ? _bannerContainer.Height : 0);
			int num2 = Math.Max(_scrollView.Height - num, 0);
			if (_noReviewsLayout.MinimumHeight != num2)
			{
				_noReviewsLayout.SetMinimumHeight(num2);
			}
		}
	}

	private void OnReviewClicked(Review vm)
	{
		base.ViewModel.OpenReviewDetailsCommand.Trigger(new ReviewDetailsViewModel.Parameter(vm));
	}

	private void OnBindReviewInList(CachingViewHolder holder, UserReviewItemViewModel viewModel, int position, CompositeDisposable disposable)
	{
		holder.RequireCachedView<ImageView>(2131298476).SetImageResource(GetIconFromStatus(viewModel.Review));
		TextView textView = holder.RequireCachedView<TextView>(2131298478);
		textView.Text = viewModel.Review.StatusName;
		textView.SetTextColor(new Color(ContextCompat.GetColor(id: GetStatusColor(viewModel.Review), context: Context)));
		holder.RequireCachedView<ImageView>(2131297999).FromUrl(viewModel.Review.ProductImage);
		holder.RequireCachedView<TextView>(2131298004).Text = viewModel.Review.ProductTitle;
		new TriggerWordsControls(holder).Setup(viewModel.Review, delegate
		{
			OnReviewClicked(viewModel.Review);
		}).AddTo(disposable);
		TextView textView2 = holder.RequireCachedView<TextView>(2131298238);
		textView2.Text = viewModel.Review.Text;
		textView2.Visibility = viewModel.Review.IsTextVisible.ToVisibility();
		holder.RequireCachedView<RatingView>(2131298138).SetupReadOnly(viewModel.Review.Rate, 16f, 2f);
		holder.RequireCachedView<ViewGroup>(2131298263).Visibility = viewModel.Review.RulesVisible.ToVisibility();
		holder.RequireCachedView<TextView>(2131298264).AddLinkedText(base.ViewModel.RulesText, new Color(ContextCompat.GetColor(RequireContext(), 2131099872)), underlineLinks: true);
		holder.RequireCachedView<TextView>(2131296890).Text = viewModel.Review.CreatedAt.ToLongDateWithFullMonth();
		TextView textView3 = holder.RequireCachedView<TextView>(2131298224);
		textView3.Text = viewModel.Review.Comments.Count.ToString();
		ImageView imageView = holder.RequireCachedView<ImageView>(2131298225);
		ViewStates visibility = (imageView.Visibility = (viewModel.Review.Comments.Count > 0).ToVisibility());
		textView3.Visibility = visibility;
		ViewGroup viewGroup = holder.RequireCachedView<ViewGroup>(2131298633);
		string[] imageUrls = viewModel.Review.Images.Select((ReviewImage reviewImage) => reviewImage.Url).ToArray();
		foreach (ReviewImage img in viewModel.Review.Images)
		{
			ImageView imageView2 = new ImageView(Context);
			imageView2.SetScaleType(ImageView.ScaleType.CenterCrop);
			LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(Converter.DpToPx(28f), Converter.DpToPx(28f));
			layoutParams.SetMargins(0, 0, Converter.DpToPx(8f), 0);
			imageView2.LayoutParameters = layoutParams;
			imageView2.ClipToOutline = true;
			viewGroup.AddView(imageView2);
			((View)imageView2).OnClick((Action)delegate
			{
				OnThumbnailTapped(imageUrls, viewModel.Review.Images.IndexOf(img));
			}).AddTo(disposable);
			imageView2.FromUrl(img.ThumbnailUrl);
		}
		viewGroup.Visibility = viewModel.Review.Images.Any().ToVisibility();
	}

	private static int GetStatusColor(Review review)
	{
		return review.Status switch
		{
			ReviewStatus.Published => 2131100611, 
			ReviewStatus.Rejected => 2131100604, 
			_ => 2131100545, 
		};
	}

	private int GetIconFromStatus(Review review)
	{
		return review.Status switch
		{
			ReviewStatus.Published => 2131231321, 
			ReviewStatus.Rejected => 2131231140, 
			_ => 2131231320, 
		};
	}

	private void OnThumbnailTapped(string[] urls, int index)
	{
		ZoomableImageSliderFragment zoomableImageSliderFragment = _fragmentFactory.Instantiate<ZoomableImageSliderFragment>();
		zoomableImageSliderFragment.ImageItemViewModels.AddRange(urls.Select((string x) => new ImageItemViewModel(x)));
		zoomableImageSliderFragment.CurrentIndex = index;
		zoomableImageSliderFragment.Show(base.ChildFragmentManager, null);
	}
}
