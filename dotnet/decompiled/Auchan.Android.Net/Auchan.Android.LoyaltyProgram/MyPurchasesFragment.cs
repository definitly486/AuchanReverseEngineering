using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram.ViewHolders;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsExpiration;
using VisibilitySwitch;

namespace Auchan.Android.LoyaltyProgram;

internal sealed class MyPurchasesFragment : BaseToolbarFragment<MyPurchasesViewModel>
{
	private readonly FragmentFactory _fragmentFactory;

	protected override int LayoutId => 2131493065;

	public MyPurchasesFragment(Func<MyPurchasesViewModel.Parameter, MyPurchasesViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base((Func<Fragment, MyPurchasesViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<MyPurchasesViewModel.Parameter>())))
	{
		_fragmentFactory = fragmentFactory;
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.OpenOperationDetailsCommand.SafeSubscribe(OpenOperationDetails, this);
		base.ViewModel.OpenPurchaseDetailsCommand.SafeSubscribe(OpenPurchaseDetails, this);
		base.ViewModel.ShowDelayedPointsInfoCommand.SafeSubscribe(delegate
		{
			Show<DelayedPointsInformerFragment>();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131296910);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298087);
		TextView textView = frameLayout.RequireViewById<TextView>(2131298080);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297081);
		TextView textView2 = constraintLayout.RequireViewById<TextView>(2131297074);
		TextView textView3 = constraintLayout.RequireViewById<TextView>(2131297072);
		ConstraintLayout constraintLayout2 = view.RequireViewById<ConstraintLayout>(2131297118);
		TextView textView4 = constraintLayout2.RequireViewById<TextView>(2131296808);
		ImageView errorImage = constraintLayout2.RequireViewById<ImageView>(2131296807);
		constraintLayout2.RequireViewById<Group>(2131296569).Visibility = ViewStates.Gone;
		RecyclerView filtersRecycler = linearLayout.RequireViewById<RecyclerView>(2131297174);
		RecyclerView purchasesRecycler = view.RequireViewById<RecyclerView>(2131298121);
		base.ToolbarTitle = base.ViewModel.ScreenTitle;
		textView.Text = base.ViewModel.ProgressTitle;
		textView4.AddScrollBehaviour();
		textView2.Text = base.ViewModel.EmptyHistoryTitle;
		textView3.Text = base.ViewModel.EmptyHistoryDescription;
		filtersRecycler.SetLayoutManager(new LinearLayoutManager(base.Activity, 0, reverseLayout: false));
		ObservableRecyclerAdapter<FilterItemViewModel, FilterItemViewHolder> filtersAdapter = new ObservableRecyclerAdapter<FilterItemViewModel, FilterItemViewHolder>
		{
			CellLayoutId = 2131493310,
			BindViewHolderDelegate = OnBindFilters,
			ClickCallback = OnFilterItemClick
		};
		filtersRecycler.SetAdapter(filtersAdapter);
		purchasesRecycler.SetLayoutManager(new LinearLayoutManager(base.Activity, 1, reverseLayout: false));
		ObservableRecyclerAdapter<FeedItemViewModel, CachingViewHolder> purchasesAdapter = new ObservableRecyclerAdapter<FeedItemViewModel, CachingViewHolder>
		{
			CreateViewHolderDelegate = CreateViewHolderDelegate,
			GetItemViewTypeDelegate = GetItemViewTypeDelegate,
			BindViewHolderDelegate = BindViewHolderDelegate,
			ClickCallback = OnItemClick
		};
		purchasesRecycler.SetAdapter(purchasesAdapter);
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				linearLayout
			},
			{
				VisualState.InProgress,
				frameLayout
			},
			{
				VisualState.Empty,
				constraintLayout
			},
			{
				VisualState.Error,
				constraintLayout2
			}
		};
		textView4.SetLinkedHtml(base.ViewModel.ConnectionErrorText, base.ViewModel.HandleLink).AutoDisposeAllOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				errorImage.FromUrlWithPlaceholder(base.ViewModel.ConnectionErrorImage, 2131231054);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ConnectionErrorImage")),
			(delegate
			{
				purchasesAdapter.DataSource = base.ViewModel.ItemsCollection;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ItemsCollection"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.FiltersPane.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				filtersAdapter.DataSource = base.ViewModel.FiltersPane.Filters;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Filters")),
			(delegate
			{
				OnActiveFilterChanged(filtersRecycler, base.ViewModel.FiltersPane.ActiveFilter);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ActiveFilter"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(purchasesRecycler.OnScrollChange(ScrollViewScrolled)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.ResetCollectionCommand.SafeSubscribe(delegate
		{
			purchasesRecycler.ScrollToPosition(0);
		}, ViewLifecycleOwner);
	}

	private void ScrollViewScrolled(object? sender, View.ScrollChangeEventArgs e)
	{
		if (sender is RecyclerView { ChildCount: not 0 } recyclerView && recyclerView.GetChildAt(0) != null)
		{
			int height = recyclerView.GetChildAt(0).Height;
			int height2 = recyclerView.Height;
			if (recyclerView.ScrollY > height - 2 * height2)
			{
				base.ViewModel.LoadNext();
			}
		}
	}

	private void OnActiveFilterChanged(RecyclerView filtersRecycler, FilterItemViewModel? activeFilter)
	{
		if (activeFilter != null)
		{
			int num = base.ViewModel.FiltersPane.Filters.IndexOf<FilterItemViewModel>(activeFilter);
			if (num >= 0)
			{
				filtersRecycler.GetLayoutManager().ScrollToPosition(num);
			}
		}
	}

	private CachingViewHolder CreateViewHolderDelegate(ViewGroup recyclerView, int cellLayoutId)
	{
		View itemView = base.LayoutInflater.Inflate(cellLayoutId, recyclerView, attachToRoot: false);
		return cellLayoutId switch
		{
			2131493261 => new CachingViewHolder(itemView), 
			2131493307 => new DateItemViewHolder(itemView), 
			2131493306 => new PurchaseItemViewHolder(itemView), 
			2131493308 => new PurchaseDelayedPointsItemViewHolder(itemView), 
			2131493311 => new PurchasePointsExpirationItemViewHolder(itemView), 
			_ => throw new NotImplementedException($"Cannot resolve any ViewHolder for {cellLayoutId} cell layout id"), 
		};
	}

	private int GetItemViewTypeDelegate(int position)
	{
		FeedItemViewModel feedItemViewModel = base.ViewModel.ItemsCollection[position];
		if (!(feedItemViewModel is DeleayedPointsInformerItemViewModel))
		{
			if (!(feedItemViewModel is DateItemViewModel))
			{
				if (!(feedItemViewModel is PurchaseItemViewModel))
				{
					if (!(feedItemViewModel is DelayedPointsItemViewModel))
					{
						if (feedItemViewModel is PointsExpirationItemViewModel)
						{
							return 2131493311;
						}
						throw new NotImplementedException($"Cannot resolve any cell layout id for {base.ViewModel.ItemsCollection[position].GetType()} type");
					}
					return 2131493308;
				}
				return 2131493306;
			}
			return 2131493307;
		}
		return 2131493261;
	}

	private void BindViewHolderDelegate(CachingViewHolder holder, FeedItemViewModel model, int position, CompositeDisposable disposable)
	{
		if (holder == null)
		{
			return;
		}
		if (!(model is DeleayedPointsInformerItemViewModel ipi))
		{
			if (!(holder is DateItemViewHolder dateItemViewHolder))
			{
				if (!(holder is PurchaseItemViewHolder purchaseItemViewHolder))
				{
					if (!(holder is PurchaseDelayedPointsItemViewHolder purchaseDelayedPointsItemViewHolder))
					{
						if (holder is PurchasePointsExpirationItemViewHolder purchasePointsExpirationItemViewHolder)
						{
							purchasePointsExpirationItemViewHolder.DoBind((PointsExpirationItemViewModel)model);
						}
					}
					else
					{
						purchaseDelayedPointsItemViewHolder.DoBind(Context, (DelayedPointsItemViewModel)model, disposable);
					}
				}
				else
				{
					purchaseItemViewHolder.DoBind(Context, (PurchaseItemViewModel)model, disposable);
				}
			}
			else
			{
				dateItemViewHolder.DoBind((DateItemViewModel)model, disposable);
			}
		}
		else
		{
			BindInactivePointsInformer(holder, ipi);
		}
	}

	private void OnItemClick(CachingViewHolder cachingViewHolder, FeedItemViewModel feedItemViewModel, int position)
	{
		base.ViewModel.OnPurchaseItemsSelected(feedItemViewModel, position);
	}

	private void BindInactivePointsInformer(CachingViewHolder cvh, DeleayedPointsInformerItemViewModel ipi)
	{
		cvh.RequireCachedView<TextView>(2131296958).AddLinkedText(ipi.Description);
	}

	private void OnBindFilters(FilterItemViewHolder vh, FilterItemViewModel vm, int pos, CompositeDisposable disposable)
	{
		vh.DoBind(vm, disposable);
	}

	private void OnFilterItemClick(FilterItemViewHolder vh, FilterItemViewModel vm, int pos)
	{
		vm.OnItemsSelected(vh.Model, pos);
	}

	private void OpenPurchaseDetails(PurchaseDetailsViewModel.Parameter parameter)
	{
		NavigateTo<PurchaseDetailsFragment, PurchaseDetailsViewModel.Parameter>(parameter);
	}

	private void OpenOperationDetails(OperationDetailsViewModel.Parameter parameter)
	{
		OperationDetailsFragment operationDetailsFragment = _fragmentFactory.Instantiate<OperationDetailsFragment>();
		operationDetailsFragment.Arguments = parameter.ToNavBundle();
		operationDetailsFragment.Show(RequireActivity().SupportFragmentManager, null);
	}
}
