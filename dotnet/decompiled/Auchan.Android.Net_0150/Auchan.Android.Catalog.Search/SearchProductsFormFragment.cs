using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.Activity;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls.AutoLayout;
using Auchan.Android.Extensions;
using Auchan.Android.Recommendations;
using Auchan.Android.Reviews;
using Auchan.Common.Base;
using Auchan.Common.Controls.AutoLayout;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Ecom.Search;
using Auchan.Common.Extensions;
using Auchan.Common.Recommendations.ViewModels;
using Auchan.Common.Reviews;
using EBind;
using Google.Flexbox;
using VisibilitySwitch;

namespace Auchan.Android.Catalog.Search;

internal class SearchProductsFormFragment : AutoLayoutFragment<SearchProductsFormViewModel>
{
	private View? _autofillView;

	private SearchView? _searchView;

	private OnBackPressedCallback? _backPressCallback;

	private bool _restoreSearchFocus;

	private bool _keyboardOpened;

	protected override int LayoutId => 2131493090;

	public SearchProductsFormFragment(Func<SearchProductsFormViewModel.Parameter, SearchProductsFormViewModel> newViewModel)
		: base((Func<Fragment, SearchProductsFormViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<SearchProductsFormViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.LayoutManager = new FlexboxLayoutManager(Context);
		base.OnViewCreated(view, savedInstanceState);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131296909);
		ViewGroup viewGroup = view.RequireViewById<ViewGroup>(2131298084);
		TextView textView = viewGroup.RequireViewById<TextView>(2131298080);
		_searchView = view.RequireViewById<SearchView>(2131298132);
		TextView textView2 = view.RequireViewById<TextView>(2131296613);
		_autofillView = view.RequireViewById<ViewGroup>(2131296477);
		RecyclerView recyclerView = _autofillView.RequireViewById<RecyclerView>(2131296475);
		VisibilitySwitch<SearchProductsFormViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<SearchProductsFormViewModel.VisualState>(SearchProductsFormViewModel.VisualState.Default)
		{
			{
				SearchProductsFormViewModel.VisualState.Default,
				constraintLayout
			},
			{
				SearchProductsFormViewModel.VisualState.InProgress,
				viewGroup
			}
		};
		textView.Text = base.ViewModel.ProgressTitle;
		_searchView.QueryTextSubmit += new DisposableDelegate<EventHandler<SearchView.QueryTextSubmitEventArgs>>(delegate(object? sender, SearchView.QueryTextSubmitEventArgs args)
		{
			args.Handled = true;
			base.Activity.HideKeyboard();
			base.ViewModel.SearchCommand.Trigger();
		}, delegate(EventHandler<SearchView.QueryTextSubmitEventArgs> d)
		{
			_searchView.QueryTextSubmit -= d;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		_searchView.QueryTextChange += new DisposableDelegate<EventHandler<SearchView.QueryTextChangeEventArgs>>(delegate(object? sender, SearchView.QueryTextChangeEventArgs args)
		{
			base.ViewModel.SearchQuery = args.NewText ?? "";
		}, delegate(EventHandler<SearchView.QueryTextChangeEventArgs> d)
		{
			_searchView.QueryTextChange -= d;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		textView2.Text = base.ViewModel.CancelText;
		_searchView.QueryHint = base.ViewModel.SearchPlaceholder;
		ObservableRecyclerAdapter<SearchAutofillItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<SearchAutofillItemViewModel, CachingViewHolder>
		{
			DataSource = base.ViewModel.Autofills,
			CellLayoutId = 2131493326,
			BindViewHolderDelegate = OnBindAutofill
		};
		recyclerView.SetLayoutManager(new LinearLayoutManager(Context, 0, reverseLayout: false));
		recyclerView.SetAdapter(adapter);
		EndlessScrollChangeListener endlessScrollChangeListener = new EndlessScrollChangeListener(delegate
		{
			base.ViewModel.Recommendations.LoadMoreCommand.Trigger(subject: false);
		});
		base.AutoLayoutRecycler.AddOnScrollListener(endlessScrollChangeListener);
		endlessScrollChangeListener.AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.AutoLayoutRecycler.AddProductsAutoLayoutDecoration(base.ViewModel.AutoLayout);
		constraintLayout.AddGoToTopButton(base.AutoLayoutRecycler, delegate
		{
			base.AutoLayoutRecycler.GetLayoutManager()?.SmoothScrollToPosition(base.AutoLayoutRecycler, null, 0);
		}, ViewLifecycleOwner);
		base.ViewModel.Autofills.CollectionChangedAsObservable().SafeSubscribe(delegate
		{
			UpdateAutofillsVisibility();
		}, ViewLifecycleOwner);
		textView2.SetOnClickListener(new ViewOnClickListener(base.ViewModel.CloseCommand.Trigger).AutoDisposeOnDestroy(ViewLifecycleOwner));
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				if (base.ViewModel.SearchQuery != _searchView.Query)
				{
					_searchView.SetQuery(base.ViewModel.SearchQuery, submit: false);
				}
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SearchQuery"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseFormCommand.SafeSubscribe(delegate
		{
			base.Activity.HideKeyboard();
			this.PopBackStackImmediateAsync().SafeFireAndForget((Action<Exception>)null, false);
		}, ViewLifecycleOwner);
		base.ViewModel.CloseParentCommand.SafeSubscribe(delegate
		{
			base.Activity.HideKeyboard();
			this.PopBackStackImmediateAsync(2).SafeFireAndForget((Action<Exception>)null, false);
		}, ViewLifecycleOwner);
		base.ViewModel.Recommendations.NavigateToProductCommand.SafeSubscribe(delegate(ProductDetailsViewModel.Parameter p)
		{
			NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(p, null, add: true);
		}, ViewLifecycleOwner);
		base.ViewModel.Recommendations.ShowQtyDialogCommand.SafeSubscribe(delegate(ProductItemViewModel vm)
		{
			_searchView.ClearFocus();
			ProductItemViewHolder.ShowQtyInputDialog(vm, base.LayoutInflater, Context);
		}, ViewLifecycleOwner);
		base.ViewModel.Recommendations.OpenReviewsCommand.SafeSubscribe(delegate(ProductReviewsViewModel.Parameter p)
		{
			NavigateTo<ProductReviewsFragment, ProductReviewsViewModel.Parameter>(p, null, add: true);
		}, ViewLifecycleOwner);
		view.ViewTreeObserver.OnGlobalLayout((Action)delegate
		{
			UpdateAutofillsVisibility();
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		_backPressCallback = RequireActivity().OnBackPressedDispatcher.AddCallback(ViewLifecycleOwner, base.ViewModel.CloseCommand.Trigger);
		_restoreSearchFocus = true;
		view.PostDelayed(RestoreSearchFocus, 200L);
	}

	public override void OnHiddenChanged(bool hidden)
	{
		base.OnHiddenChanged(hidden);
		if (_backPressCallback != null)
		{
			_backPressCallback.Enabled = !hidden;
		}
		if (hidden)
		{
			SearchView? searchView = _searchView;
			_restoreSearchFocus = searchView != null && searchView.HasFocus && _keyboardOpened;
		}
		else if (_restoreSearchFocus)
		{
			_restoreSearchFocus = false;
			View?.Post(RestoreSearchFocus);
		}
	}

	private void RestoreSearchFocus()
	{
		if (_searchView != null && View != null && base.IsAdded)
		{
			_searchView.RequestFocusFromTouch();
			((InputMethodManager)RequireActivity().GetSystemService("input_method"))?.ShowSoftInput(_searchView.FindFocus(), (ShowFlags)0);
		}
	}

	private void UpdateAutofillsVisibility()
	{
		if (View != null)
		{
			Rect rect = new Rect();
			View.GetWindowVisibleDisplayFrame(rect);
			int num = ((View.Height > rect.Height()) ? (View.Height - rect.Height()) : 0);
			_keyboardOpened = num > 0;
			bool flag = num > 0 && _searchView.HasFocus && base.ViewModel.AutofillsAvailable;
			_autofillView.Visibility = flag.ToVisibility();
			int num2 = (flag ? _autofillView.Height : 0);
			int num3 = num + (_searchView.HasFocus ? num2 : 0);
			if (base.AutoLayoutRecycler.LayoutParameters is ViewGroup.MarginLayoutParams marginLayoutParams && marginLayoutParams.BottomMargin != num3)
			{
				marginLayoutParams.BottomMargin = num3;
				base.AutoLayoutRecycler.LayoutParameters = marginLayoutParams;
			}
			if (_autofillView.LayoutParameters is ViewGroup.MarginLayoutParams { BottomMargin: 0 } marginLayoutParams2 && _searchView.HasFocus)
			{
				marginLayoutParams2.BottomMargin = num;
				_autofillView.LayoutParameters = marginLayoutParams2;
			}
		}
	}

	protected override void BindAutoLayoutView(AutoLayoutViewModel.AutoLayoutElement vm, int position, CachingViewHolder vh, CompositeDisposable disposables)
	{
		string type = vm.Type;
		if (type == null)
		{
			return;
		}
		object data;
		RecomProductItemViewModel rpvm;
		switch (type.Length)
		{
		case 23:
			switch (type[10])
			{
			case 'H':
				if (type == "SearchFormHistoryHeader")
				{
					OnBindHistoryHeader(vh, base.ViewModel, position, disposables);
				}
				break;
			case 'P':
				if (type == "SearchFormPopularHeader")
				{
					OnBindPopularHeader(vh, base.ViewModel, position, disposables);
				}
				break;
			}
			break;
		case 21:
			switch (type[10])
			{
			default:
				return;
			case 'H':
				if (type == "SearchFormHistoryItem")
				{
					OnBindHistoryEntry(vh, vm.Data as SearchFormHistoryItemViewModel, position, disposables);
				}
				return;
			case 'P':
				if (type == "SearchFormPopularItem")
				{
					OnBindPopular(vh, vm.Data as SearchTextRecomItemViewModel, position, disposables);
				}
				return;
			case 't':
				break;
			}
			if (!(type == "RecommendationProduct"))
			{
				break;
			}
			goto IL_0199;
		case 24:
			_ = type == "SearchFormCategoryHeader";
			break;
		case 22:
			if (type == "SearchFormCategoryItem")
			{
				OnBindCategory(vh, vm.Data as SearchCategoryRecomItemViewModel, position, disposables);
			}
			break;
		case 19:
			if (type == "RecommendationTitle")
			{
				vh.RequireCachedView<TextView>(2131298603).Text = vm.Data as string;
			}
			break;
		case 25:
			if (!(type == "RecommendationProductStub"))
			{
				break;
			}
			goto IL_0199;
		case 28:
			if (type == "RecommendationLoadMoreButton")
			{
				vh.RequireCachedView<TextView>(2131298603).Text = base.ViewModel.Recommendations.LoadMoreText;
				vh.ItemView.SetOnClickListener(new ViewOnClickListener((Action)delegate
				{
					base.ViewModel.Recommendations.LoadMoreCommand.Trigger(subject: true);
				}).AddTo(disposables));
			}
			break;
		case 20:
		case 26:
		case 27:
			break;
			IL_0199:
			AdjustProductCardSize(vh);
			if (!(vh is ProductItemViewHolder productItemViewHolder))
			{
				break;
			}
			data = vm.Data;
			rpvm = data as RecomProductItemViewModel;
			if (rpvm != null)
			{
				base.ViewModel.OnRecommendationsViewed();
				productItemViewHolder.BindData(base.ViewModel, rpvm, disposables, base.ViewModel.Recommendations.ShowQtyDialogCommand, showPackageLabel: true);
				productItemViewHolder.ItemView.SetOnClickListener(new ViewOnClickListener((Action)delegate
				{
					base.ViewModel.Recommendations.ProductClickCommand.Trigger(rpvm);
				}).AddTo(disposables));
			}
			break;
		}
	}

	private void OnBindAutofill(CachingViewHolder viewHolder, SearchAutofillItemViewModel itemViewModel, int index, CompositeDisposable disposables)
	{
		TextView title = viewHolder.RequireCachedView<TextView>(2131298646);
		itemViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			title.Text = itemViewModel.Text;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Text")))).AddTo(disposables);
		viewHolder.ItemView.SetOnClickListener(new ViewOnClickListener((Action)delegate
		{
			base.ViewModel.SelectAutofillItemCommand.Trigger(itemViewModel);
		}).AddTo(disposables));
	}

	private void OnBindHistoryHeader(CachingViewHolder viewHolder, SearchProductsFormViewModel itemViewModel, int index, CompositeDisposable disposables)
	{
		viewHolder.ItemView.SetPaddingDp(16, 16, 16, 0);
		TextView textView = viewHolder.RequireCachedView<TextView>(2131297286);
		TextView textView2 = viewHolder.RequireCachedView<TextView>(2131297285);
		textView.Text = base.ViewModel.HistoryTitle;
		textView2.Text = base.ViewModel.ClearText;
		textView2.SetOnClickListener(new ViewOnClickListener(itemViewModel.ClearHistoryCommand.Trigger).AddTo(disposables));
	}

	private void OnBindHistoryEntry(CachingViewHolder viewHolder, SearchFormHistoryItemViewModel itemViewModel, int index, CompositeDisposable disposables)
	{
		viewHolder.ItemView.SetPaddingDp(16, 0, 16, 0);
		TextView title = viewHolder.RequireCachedView<TextView>(2131298646);
		View view = viewHolder.RequireCachedView<View>(2131296783);
		itemViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			title.SetBoldSpan(Context, itemViewModel.Text, base.ViewModel.SearchQuery);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Text")))).AddTo(disposables);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			title.SetBoldSpan(Context, itemViewModel.Text, base.ViewModel.SearchQuery);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SearchQuery")))).AddTo(disposables);
		viewHolder.ItemView.SetOnClickListener(new ViewOnClickListener((Action)delegate
		{
			base.ViewModel.SelectHistoryItemCommand.Trigger(itemViewModel);
		}).AddTo(disposables));
		view.SetOnClickListener(new ViewOnClickListener((Action)delegate
		{
			base.ViewModel.ClearHistoryItemCommand.Trigger(itemViewModel);
		}).AddTo(disposables));
	}

	private void OnBindPopularHeader(CachingViewHolder viewHolder, SearchProductsFormViewModel itemViewModel, int index, CompositeDisposable disposables)
	{
		viewHolder.ItemView.SetPaddingDp(16, 0, 16, 0);
		TextView title = viewHolder.RequireCachedView<TextView>(2131298646);
		itemViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			title.Text = itemViewModel.RecommendationsTitle;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("RecommendationsTitle")))).AddTo(disposables);
	}

	private void OnBindPopular(CachingViewHolder viewHolder, SearchTextRecomItemViewModel itemViewModel, int index, CompositeDisposable disposables)
	{
		viewHolder.ItemView.SetPaddingDp(16, 0, 16, 0);
		TextView title = viewHolder.RequireCachedView<TextView>(2131298646);
		itemViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			title.SetBoldSpan(Context, itemViewModel.Title, base.ViewModel.SearchQuery);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")))).AddTo(disposables);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			title.SetBoldSpan(Context, itemViewModel.Title, base.ViewModel.SearchQuery);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SearchQuery")))).AddTo(disposables);
		viewHolder.ItemView.SetOnClickListener(new ViewOnClickListener((Action)delegate
		{
			base.ViewModel.SelectRecomTextItemCommand.Trigger(itemViewModel);
		}).AddTo(disposables));
	}

	private void OnBindCategory(CachingViewHolder viewHolder, SearchCategoryRecomItemViewModel itemViewModel, int index, CompositeDisposable disposables)
	{
		viewHolder.ItemView.SetPaddingDp(16, 0, 16, 0);
		TextView title = viewHolder.RequireCachedView<TextView>(2131298646);
		TextView description = viewHolder.RequireCachedView<TextView>(2131296958);
		itemViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				title.SetBoldSpan(Context, itemViewModel.Title, base.ViewModel.SearchQuery);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				description.Text = itemViewModel.Description;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Description"))
		})).AddTo(disposables);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			title.SetBoldSpan(Context, itemViewModel.Title, base.ViewModel.SearchQuery);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SearchQuery")))).AddTo(disposables);
		viewHolder.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.SelectRecomCategoryItemCommand.Trigger(itemViewModel);
		}).AddTo(disposables);
	}

	private void AdjustProductCardSize(CachingViewHolder vh)
	{
		ViewGroup.LayoutParams layoutParameters = vh.ItemView.LayoutParameters;
		layoutParameters.Width = (base.Resources.DisplayMetrics.WidthPixels - (Converter.DpToPx(40f) + Converter.DpToPx(10f))) / 2;
		layoutParameters.Height = Converter.DpToPx(288f);
		vh.ItemView.LayoutParameters = layoutParameters;
	}
}
