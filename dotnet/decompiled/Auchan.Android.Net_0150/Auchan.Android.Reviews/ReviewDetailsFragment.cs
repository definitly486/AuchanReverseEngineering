using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Controls.ZoomableImageSlider;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Reviews;
using Auchan.Common.Reviews.Model;

namespace Auchan.Android.Reviews;

internal class ReviewDetailsFragment : BaseToolbarFragment<ReviewDetailsViewModel>
{
	private readonly FragmentFactory _fragmentFactory;

	private RecyclerView _commentList;

	private ReviewView _reviewView;

	private CompositeDisposable disposable = new CompositeDisposable();

	protected override int LayoutId => 2131493187;

	public ReviewDetailsFragment(Func<ReviewDetailsViewModel.Parameter, ReviewDetailsViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base((Func<Fragment, ReviewDetailsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<ReviewDetailsViewModel.Parameter>())))
	{
		_fragmentFactory = fragmentFactory;
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		_commentList = view.RequireViewById<RecyclerView>(2131298226);
		_reviewView = view.RequireViewById<ReviewView>(2131298239);
		TextView toolBarTitle = view.RequireViewById<TextView>(2131298679);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				toolBarTitle.Text = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				SetupCommentsList(base.ViewModel.Comments);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Comments")),
			(delegate
			{
				SetupReviewView(base.ViewModel.Review);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Review"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(_reviewView.OnClick(ShowWholeReview), _reviewView.MenuOptionsView.OnClick((Action)delegate
		{
			base.ViewModel.OnMenuOptionsCommand.Trigger(base.ViewModel.Review);
		}), _reviewView.OnThumbnailTappedEvent(OnThumbnailTapped)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OpenMenuOptionsCommand.Subscribe(delegate(BrokerToken p)
		{
			Show<ReportReviewFragment, BrokerToken>(p);
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void OnThumbnailTapped(IReadOnlyList<string?> urls, int index)
	{
		ZoomableImageSliderFragment zoomableImageSliderFragment = _fragmentFactory.Instantiate<ZoomableImageSliderFragment>();
		zoomableImageSliderFragment.ImageItemViewModels.AddRange(urls.Select((string x) => new ImageItemViewModel(x)));
		zoomableImageSliderFragment.CurrentIndex = index;
		zoomableImageSliderFragment.Show(base.ChildFragmentManager, null);
	}

	private void ShowWholeReview()
	{
		if (_reviewView.Mode != ReviewViewMode.FullView)
		{
			_reviewView.Setup(base.ViewModel.Review, delegate
			{
			}, ReviewViewMode.FullView, disposable);
		}
	}

	private void SetupReviewView(Review review)
	{
		_reviewView.Setup(review, delegate
		{
			ShowWholeReview();
		}, ReviewViewMode.LargePreview, disposable);
	}

	private void SetupCommentsList(IReadOnlyList<ReviewComment> comments)
	{
		ObservableRecyclerAdapter<ReviewComment, CachingViewHolder> adapter = new ObservableRecyclerAdapter<ReviewComment, CachingViewHolder>
		{
			CellLayoutId = 2131493186,
			DataSource = comments,
			BindViewHolderDelegate = OnBindCommentInList
		};
		_commentList.SetLayoutManager(new LinearLayoutManager(Context, 1, reverseLayout: false));
		_commentList.SetAdapter(adapter);
	}

	private void OnBindCommentInList(CachingViewHolder holder, ReviewComment entry, int position, CompositeDisposable disposable)
	{
		holder.RequireCachedView<ReviewCommentView>(2131298235).UpdateWithComment(entry, base.ViewModel.CommentTitle, disposable);
	}
}
