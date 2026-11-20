using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using AndroidX.CardView.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Common;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Recommendations.ViewModels;

namespace Auchan.Android.Recommendations;

internal sealed class RecommendationSectionBindings(CachingViewHolder viewHolder, RecommendationsViewModel viewModel, bool nestedScrollEnabled)
{
	private readonly View _headerLayout = viewHolder.RequireCachedView<View>(2131297268);

	private readonly TextView _header = viewHolder.RequireCachedView<TextView>(2131298328);

	private readonly ChevronRightButtonControls _showAllButton = new ChevronRightButtonControls(viewHolder.RequireCachedView<View>(2131296423));

	public void Bind(SectionItemViewModel itemViewModel, IYandexMetricaScreenViewModel screenViewModel, Func<View, IObservable<bool>>? notifier, int sectionTopMargin, int sectionLeftMargin, int sectionRightMargin, CompositeDisposable disposables, bool onDarkBackground = false)
	{
		_showAllButton.View.Visibility = (itemViewModel.ShowAllButton && itemViewModel.ShowShevronButton).ToInvisibleVisibility();
		_showAllButton.TextView.Text = itemViewModel.ShevronAllButtonText;
		_headerLayout.UpdateLayoutParams(delegate(ViewGroup.MarginLayoutParams lp)
		{
			lp.TopMargin = sectionTopMargin;
			lp.LeftMargin = sectionLeftMargin;
			lp.RightMargin = sectionRightMargin;
		});
		_header.Text = itemViewModel.Title;
		if (onDarkBackground)
		{
			_header.SetTextColor(new Color(255, 255, 255));
		}
		_showAllButton.View.OnClick((Action)delegate
		{
			viewModel.ShowAll(itemViewModel);
		}).AddTo(disposables);
		RecyclerView innerRecycler = viewHolder.RequireCachedView<RecyclerView>(2131298178);
		innerRecycler.SetClipToPadding(clipToPadding: false);
		innerRecycler.SetPadding(sectionLeftMargin, innerRecycler.PaddingTop, sectionRightMargin, innerRecycler.PaddingBottom);
		if (innerRecycler.ItemDecorationCount > 0)
		{
			innerRecycler.RemoveItemDecorationAt(0);
		}
		RecyclerViewDivider decor = new RecyclerViewDivider
		{
			Offset = Converter.DpToPx(8f)
		};
		innerRecycler.AddItemDecoration(decor);
		innerRecycler.NestedScrollingEnabled = nestedScrollEnabled;
		ObservableRecyclerAdapter<RecomProductItemViewModel, CachingViewHolder> observableRecyclerAdapter = innerRecycler.GetAdapter() as ObservableRecyclerAdapter<RecomProductItemViewModel, CachingViewHolder>;
		if (observableRecyclerAdapter == null)
		{
			observableRecyclerAdapter = new ObservableRecyclerAdapter<RecomProductItemViewModel, CachingViewHolder>
			{
				GetItemViewTypeDelegate = (int _) => 2131493288,
				CreateViewHolderDelegate = (ViewGroup v, int i) => OnCreateViewHolder(v, i),
				BindViewHolderDelegate = delegate(CachingViewHolder holder, RecomProductItemViewModel model, int positions, CompositeDisposable disposabless)
				{
					BindProduct(holder, screenViewModel, model, positions, disposabless, itemViewModel);
				}
			};
			observableRecyclerAdapter.DisposeViewHolders().AddTo(disposables);
			Disposable.Create(delegate
			{
				innerRecycler.SetAdapter(null);
			}).AddTo(disposables);
			innerRecycler.SetAdapter(observableRecyclerAdapter);
		}
		if (itemViewModel.ShowAllButton)
		{
			List<RecomProductItemViewModel> list = itemViewModel.Preview.ToList();
			list.Add(itemViewModel.Preview.Last());
			observableRecyclerAdapter.DataSource = list;
		}
		else
		{
			observableRecyclerAdapter.DataSource = itemViewModel.Preview;
		}
		observableRecyclerAdapter.ClickCallback = delegate(CachingViewHolder holder, RecomProductItemViewModel model, int pos)
		{
			viewModel.Clicked(itemViewModel, model);
		};
		viewHolder.ItemView.Post(delegate
		{
			notifier?.Invoke(viewHolder.ItemView).DistinctUntilChanged().SafeSubscribe(delegate(bool isVisible)
			{
				bool isVisible2 = itemViewModel.IsVisible;
				itemViewModel.IsVisible = isVisible;
				if (!isVisible2 && isVisible)
				{
					viewModel.Viewed(itemViewModel);
				}
			}, disposables);
		});
	}

	private CachingViewHolder OnCreateViewHolder(ViewGroup viewGroup, int type)
	{
		return new ProductItemViewHolder(LayoutInflater.From(viewGroup.Context)?.Inflate(type, viewGroup, attachToRoot: false) ?? throw new InvalidOperationException("Could not create a view holder"));
	}

	private void BindProduct(CachingViewHolder vh, IYandexMetricaScreenViewModel screenViewModel, ProductItemViewModel vm, int position, CompositeDisposable disposables, SectionItemViewModel sectionItemViewModel)
	{
		ViewGroup.LayoutParams layoutParameters = vh.ItemView.LayoutParameters;
		layoutParameters.Width = ProductItemViewHolder.GetHorizontalCardWidthPx(vh.ItemView.Context);
		CardView cardView = vh.RequireCachedView<CardView>(2131297419);
		ConstraintLayout constraintLayout = vh.RequireCachedView<ConstraintLayout>(2131296908);
		if (position >= sectionItemViewModel.Preview.Count && sectionItemViewModel.ShowAllButton)
		{
			cardView.Visibility = ViewStates.Visible;
			constraintLayout.Visibility = ViewStates.Gone;
			((View)cardView).OnClick((Action)delegate
			{
				viewModel.ShowAll(sectionItemViewModel);
			}).AddTo(disposables);
			return;
		}
		cardView.Visibility = ViewStates.Gone;
		constraintLayout.Visibility = ViewStates.Visible;
		if (vh is ProductItemViewHolder productItemViewHolder)
		{
			layoutParameters.Height = Converter.DpToPx(288f);
			productItemViewHolder.BindData(screenViewModel, vm, disposables, viewModel.ShowQtyDialogCommand, showPackageLabel: true, allowImagePaging: false);
		}
		vh.ItemView.LayoutParameters = layoutParameters;
	}
}
