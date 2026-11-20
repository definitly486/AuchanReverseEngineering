using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Base.Widgets;
using Auchan.Android.Catalog;
using Auchan.Android.Controls.EmptyView;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using Auchan.Common.LoyaltyProgram;
using EBind;
using VisibilitySwitch;

namespace Auchan.Android.LoyaltyProgram;

internal class MyOffersFragment : BaseToolbarFragment<MyOffersViewModel>
{
	protected override int LayoutId => 2131493064;

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public MyOffersFragment(Func<MyOffersViewModel.Parameter, MyOffersViewModel> newViewModel)
		: base((Func<Fragment, MyOffersViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<MyOffersViewModel.Parameter>())))
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.OpenOfferDetailsCommand.SafeSubscribe(delegate(BrokerToken x)
		{
			Show<OfferDetailsFragment, BrokerToken>(x);
		}, this);
		base.ViewModel.OpenAIOfferDetailsCommand.SafeSubscribe(delegate(BrokerToken x)
		{
			Show<AIOfferDetailsFragment, BrokerToken>(x);
		}, this);
		base.ViewModel.OpenProductDetailsCommand.SafeSubscribe(delegate(ProductDetailsViewModel.Parameter p)
		{
			NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(p);
		}, this);
		base.ViewModel.ShowQrCommand.SafeSubscribe(delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		}, this);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			OnNavigationButtonClick();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Toolbar supportActionBar = view.RequireViewById<Toolbar>(2131298669);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		AisEmptyView aisEmptyView = view.RequireViewById<AisEmptyView>(2131297070);
		TextView emptyTitle = aisEmptyView.RequireViewById<TextView>(2131297083);
		TextView emptyMessage = aisEmptyView.RequireViewById<TextView>(2131297078);
		View topSeparator = view.RequireViewById<View>(2131298709);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		TextView errorTitle = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView errorHint = constraintLayout.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout.RequireViewById<Button>(2131296325);
		Button button2 = constraintLayout.RequireViewById<Button>(2131298371);
		LinearLayout offersCounter = view.RequireViewById<LinearLayout>(2131297338);
		TextView offersCounterText = offersCounter.RequireViewById<TextView>(2131297342);
		TextView textView = frameLayout.RequireViewById<TextView>(2131298080);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131296515);
		(base.Activity as AppCompatActivity)?.SetSupportActionBar(supportActionBar);
		base.ToolbarTitle = base.ViewModel.Title;
		textView.Text = base.ViewModel.ProgressTitle;
		emptyTitle.Text = base.ViewModel.EmptyTitle;
		emptyMessage.Text = base.ViewModel.EmptyDescription;
		VisibilitySwitch<MyOffersViewModel.VisualState> viewSwitch = new VisibilitySwitch<MyOffersViewModel.VisualState>(base.ViewModel.State)
		{
			{
				MyOffersViewModel.VisualState.Default,
				recyclerView
			},
			{
				MyOffersViewModel.VisualState.InProgress,
				frameLayout
			},
			{
				MyOffersViewModel.VisualState.Empty,
				aisEmptyView
			},
			{
				MyOffersViewModel.VisualState.Error,
				constraintLayout
			}
		};
		SetupBannersList(recyclerView, base.ViewModel.PersonalOffers);
		base.ViewModel.PersonalOffers.OnPropertyChanges((ObservableRangeCollection<PersOfferItemViewModel> x) => x.Count).Subscribe(delegate(int x)
		{
			topSeparator.Visibility = (x > 0).ToVisibility();
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[7]
		{
			(delegate
			{
				errorTitle.Text = base.ViewModel.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				errorHint.Text = base.ViewModel.ErrorDescription;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorDescription")),
			(delegate
			{
				emptyTitle.Text = base.ViewModel.EmptyTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EmptyTitle")),
			(delegate
			{
				emptyMessage.Text = base.ViewModel.EmptyDescription;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EmptyDescription")),
			(delegate
			{
				viewSwitch.State = base.ViewModel.State;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				offersCounter.Visibility = (!string.IsNullOrEmpty(base.ViewModel.NewOffersCountText)).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NewOffersCountText")),
			(delegate
			{
				offersCounterText.Text = base.ViewModel.NewOffersCountText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NewOffersCountText"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.Retry), button2.OnClick(base.ViewModel.ShowQr)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void SetupBannersList(RecyclerView bannersList, IReadOnlyList<PersOfferItemViewModel> banners)
	{
		ObservableRecyclerAdapter<PersOfferItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<PersOfferItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493277,
			DataSource = banners,
			BindViewHolderDelegate = OnBindBannerInList
		};
		bannersList.SetAdapter(adapter);
	}

	private void OnBindBannerInList(CachingViewHolder holder, PersOfferItemViewModel entry, int position, CompositeDisposable disposable)
	{
		holder.ItemView.ViewAttachedToWindow += new DisposableDelegate<EventHandler<View.ViewAttachedToWindowEventArgs>>(delegate(object? s, View.ViewAttachedToWindowEventArgs e)
		{
			for (IViewParent viewParent = e.AttachedView as IViewParent; viewParent != null; viewParent = viewParent.Parent)
			{
				if (viewParent is ViewGroup viewGroup)
				{
					viewGroup.SetClipChildren(clipChildren: false);
					viewGroup.SetClipToPadding(clipToPadding: false);
				}
				if (viewParent is RecyclerView)
				{
					break;
				}
			}
		}, delegate(EventHandler<View.ViewAttachedToWindowEventArgs> d)
		{
			holder.ItemView.ViewAttachedToWindow -= d;
		}).AddTo(disposable);
		PersonalOfferView offerView = holder.RequireCachedView<PersonalOfferView>(2131297726);
		offerView.Setup(entry);
		ViewGroup.MarginLayoutParams marginLayoutParams = (ViewGroup.MarginLayoutParams)holder.ItemView.LayoutParameters;
		marginLayoutParams.SetMargins(0, 0, 0, Converter.DpToPx(5f));
		holder.ItemView.LayoutParameters = marginLayoutParams;
		entry.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				offerView.NewIndicator.Visibility = (!entry.IsViewed).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsViewed")),
			(delegate
			{
				UpdateActivateButton(offerView.AcceptButton, entry);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAccepted"))
		})).AddTo(disposable);
		holder.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.OnBannerClicked(entry);
		}).AddTo(disposable);
		((View)offerView.AcceptButton).OnClick((Action)delegate
		{
			base.ViewModel.OnActivateOfferTapped(entry);
		}).AddTo(disposable);
	}

	private void UpdateActivateButton(AppCompatButton acceptButton, PersOfferItemViewModel entry)
	{
		acceptButton.SetBackgroundResource(entry.IsAccepted ? 2131231547 : 2131231546);
		acceptButton.Text = entry.ActivateLabel;
	}
}
