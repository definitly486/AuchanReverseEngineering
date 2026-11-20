using System;
using System.Linq;
using System.Reactive.Disposables;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Common.UiUtils;
using Auchan.Common.Controls.AutoLayout;
using Auchan.Common.Extensions;

namespace Auchan.Android.Extensions;

public static class RecyclerViewExtensions
{
	public static bool IsAtTop(this RecyclerView recyclerView)
	{
		return !recyclerView.CanScrollVertically(-1);
	}

	public static IDisposable AddScrollListener(this RecyclerView recyclerView, RecyclerView.OnScrollListener listener)
	{
		recyclerView.AddOnScrollListener(listener);
		return Disposable.Create(recyclerView, delegate(RecyclerView view)
		{
			view.RemoveOnScrollListener(listener);
		});
	}

	public static IDisposable OnTouchEvent(this RecyclerView @this, Action handler)
	{
		return @this.OnTouchEvent((EventHandler<RecyclerView.TouchEventEventArgs>)delegate
		{
			handler();
		});
	}

	public static IDisposable OnTouchEvent(this RecyclerView @this, EventHandler<RecyclerView.TouchEventEventArgs> handler)
	{
		@this.TouchEvent += handler;
		return Disposable.Create(delegate
		{
			@this.TouchEvent -= handler;
		});
	}

	public static IDisposable OnInterceptTouch(this RecyclerView @this, Action handler)
	{
		return @this.OnInterceptTouch((EventHandler<RecyclerView.InterceptTouchEventEventArgs>)delegate
		{
			handler();
		});
	}

	public static IDisposable OnInterceptTouch(this RecyclerView @this, EventHandler<RecyclerView.InterceptTouchEventEventArgs> handler)
	{
		@this.InterceptTouchEvent += handler;
		return Disposable.Create(delegate
		{
			@this.InterceptTouchEvent -= handler;
		});
	}

	public static void AddProductsAutoLayoutDecoration(this RecyclerView recyclerView, AutoLayoutViewModel autoLayout, int topDP = 4, int bottomDP = 4, int startDP = 20, int endDP = 20, int spacingDP = 5)
	{
		recyclerView.AddItemDecoration(new GridSpacesItemDecoration3(topDP, bottomDP, startDP, spacingDP, delegate(int pos)
		{
			AutoLayoutViewModel.AutoLayoutElement autoLayoutElement = autoLayout.Elements.ElementAtOrDefault(pos);
			int num = autoLayout.Elements.Where((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "RecommendationProduct" || e.Type == "RecommendationProductStub").IndexOf(autoLayoutElement);
			return (autoLayoutElement != null && (autoLayoutElement.Type == "RecommendationProduct" || autoLayoutElement.Type == "RecommendationProductStub") && num % 2 == 0) ? true : false;
		}));
		recyclerView.AddItemDecoration(new GridSpacesItemDecoration3(topDP, bottomDP, spacingDP, endDP, delegate(int pos)
		{
			AutoLayoutViewModel.AutoLayoutElement autoLayoutElement = autoLayout.Elements.ElementAtOrDefault(pos);
			int num = autoLayout.Elements.Where((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "RecommendationProduct" || e.Type == "RecommendationProductStub").IndexOf(autoLayoutElement);
			return (autoLayoutElement != null && (autoLayoutElement.Type == "RecommendationProduct" || autoLayoutElement.Type == "RecommendationProductStub") && num % 2 == 1) ? true : false;
		}));
	}
}
