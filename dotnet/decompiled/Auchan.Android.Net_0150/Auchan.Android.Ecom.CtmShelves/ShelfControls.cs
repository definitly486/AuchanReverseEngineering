using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Common;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Ecom.CtmShelves.ViewModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Extensions;

namespace Auchan.Android.Ecom.CtmShelves;

internal sealed class ShelfControls(CachingViewHolder vh, bool nestedScrollEnabled)
{
	private enum ViewType
	{
		Banner,
		Product
	}

	public void Bind(IYandexMetricaScreenViewModel screenViewModel, ShelfItemViewModel vm, int sectionTopMargin, int sectionLeftMargin, int sectionRightMargin, ICollection<IDisposable> disposables)
	{
		View view = vh.RequireCachedView<View>(2131297268);
		TextView textView = vh.RequireCachedView<TextView>(2131298646);
		TextView textView2 = vh.RequireCachedView<TextView>(2131298559);
		ChevronRightButtonControls chevronRightButtonControls = new ChevronRightButtonControls(vh.RequireCachedView<View>(2131296423));
		RecyclerView items = vh.RequireCachedView<RecyclerView>(2131297400);
		view.UpdateLayoutParams(delegate(ViewGroup.MarginLayoutParams lp)
		{
			lp.TopMargin = sectionTopMargin;
			lp.LeftMargin = sectionLeftMargin;
			lp.RightMargin = sectionRightMargin;
		});
		textView.Text = vm.Shelf.Title;
		textView2.Text = vm.Shelf.Subtitle;
		textView2.Visibility = vm.IsSubtitleVisible.ToVisibility();
		chevronRightButtonControls.View.Visibility = vm.IsAllButtonVisible.ToVisibility();
		chevronRightButtonControls.TextView.Text = vm.AllButtonText;
		items.SetClipToPadding(clipToPadding: false);
		items.SetPadding(sectionLeftMargin, items.PaddingTop, sectionRightMargin, items.PaddingBottom);
		if (items.ItemDecorationCount > 0)
		{
			items.RemoveItemDecorationAt(0);
		}
		RecyclerViewDivider decor = new RecyclerViewDivider
		{
			Offset = Converter.DpToPx(8f)
		};
		items.AddItemDecoration(decor);
		items.NestedScrollingEnabled = nestedScrollEnabled;
		ObservableRecyclerAdapter<BaseItemViewModel, CachingViewHolder> observableRecyclerAdapter = new ObservableRecyclerAdapter<BaseItemViewModel, CachingViewHolder>
		{
			GetItemViewTypeDelegate = (int pos) => GetItemViewType(vm, pos),
			CreateViewHolderDelegate = CreateViewHolder,
			BindViewHolderDelegate = delegate(CachingViewHolder holder, BaseItemViewModel model, int position, CompositeDisposable compositeDisposable)
			{
				if (holder is ProductItemViewHolder productItemViewHolder && model is ProductItemViewModel productItemViewModel)
				{
					productItemViewHolder.BindData(screenViewModel, productItemViewModel, compositeDisposable, vm.ShowQtyDialogCommand, showPackageLabel: true, allowImagePaging: false);
					UpdateCardLayoutParams(holder);
				}
				if (holder != null)
				{
					if (model is CtmBannerItemViewModel bivm)
					{
						BindBanner(holder, bivm, compositeDisposable);
					}
				}
			},
			DataSource = vm.Items,
			ClickCallback = delegate(CachingViewHolder h, BaseItemViewModel model, int i)
			{
				if (model is ProductItemViewModel product)
				{
					vm.NavigateToProduct(product);
				}
			}
		};
		observableRecyclerAdapter.DisposeViewHolders().AddTo(disposables);
		Disposable.Create(delegate
		{
			items.SetAdapter(null);
		}).AddTo(disposables);
		items.SetAdapter(observableRecyclerAdapter);
		vm.BindEvents(chevronRightButtonControls.View.OnClick((Action)delegate
		{
			vm.OnAllButtonClick();
		})).AddTo(disposables);
	}

	private CachingViewHolder CreateViewHolder(ViewGroup vg, int type)
	{
		return (ViewType)type switch
		{
			ViewType.Banner => new CachingViewHolder(Inflate(2131493342)), 
			ViewType.Product => new ProductItemViewHolder(Inflate(2131493288)), 
			_ => throw new NotSupportedException("unknown item type"), 
		};
	}

	private View Inflate(int resourceId)
	{
		return LayoutInflater.From(vh.ItemView.Context)?.Inflate(resourceId, (ViewGroup)vh.ItemView, attachToRoot: false) ?? throw new ArgumentException("resourceId");
	}

	private static int GetItemViewType(ShelfItemViewModel vm, int pos)
	{
		if (vm.Items[pos] is CtmBannerItemViewModel)
		{
			return 0;
		}
		if (vm.Items[pos] is ProductItemViewModel)
		{
			return 1;
		}
		throw new NotSupportedException("unknown item type");
	}

	private void BindBanner(CachingViewHolder cvh, CtmBannerItemViewModel bivm, ICollection<IDisposable> disposables)
	{
		ImageView imageView = cvh.RequireCachedView<ImageView>(2131297319);
		TextView textView = cvh.RequireCachedView<TextView>(2131296587);
		textView.Visibility = bivm.IsButtonVisible.ToVisibility();
		textView.Text = bivm.Banner.Button?.ButtonText;
		imageView.FromUrlAnimated(bivm.Banner.ImageUrl);
		bivm.BindEvents(((View)imageView).OnClick((Action)delegate
		{
			bivm.OnClick();
		}), ((View)textView).OnClick((Action)delegate
		{
			bivm.OnClick();
		})).AddTo(disposables);
		UpdateCardLayoutParams(cvh);
	}

	private static void UpdateCardLayoutParams(RecyclerView.ViewHolder vh)
	{
		vh.ItemView.UpdateLayoutParams<ViewGroup.LayoutParams>((Action<ViewGroup.LayoutParams>)delegate(ViewGroup.LayoutParams lp)
		{
			lp.Width = ProductItemViewHolder.GetHorizontalCardWidthPx(vh.ItemView.Context);
			lp.Height = Converter.DpToPx(286f);
		});
	}
}
