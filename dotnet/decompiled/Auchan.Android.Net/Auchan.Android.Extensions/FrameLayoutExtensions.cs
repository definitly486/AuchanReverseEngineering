using System;
using System.Reactive.Disposables;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.CoordinatorLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Lifecycle;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common.ScrollListeners;
using Auchan.Android.Common.UiUtils;
using Auchan.Common.Controls.AutoLayout;
using Google.Android.Material.AppBar;
using Google.Android.Material.FloatingActionButton;

namespace Auchan.Android.Extensions;

internal static class FrameLayoutExtensions
{
	private const int GoToTopButtonAnimationDuration = 200;

	public static (FloatingActionButton, GoToTopButtonScrollListener) AddGoToTopButton(this FrameLayout viewGroup, RecyclerView recyclerView, Action buttonAction, ILifecycleOwner lifecycleOwner, AppBarLayout appBarLayout = null)
	{
		int num = Converter.DpToPx(56f);
		FrameLayout.LayoutParams layoutParams = new FrameLayout.LayoutParams(num, num, GravityFlags.End | GravityFlags.Bottom);
		int bottomMargin = (layoutParams.MarginEnd = Converter.DpToPx(16f));
		layoutParams.BottomMargin = bottomMargin;
		return AddGoToTopButton(viewGroup, recyclerView, CreateGoToTopButton(viewGroup, layoutParams), buttonAction, lifecycleOwner, null, appBarLayout);
	}

	public static (FloatingActionButton, GoToTopButtonScrollListener) AddGoToTopButton(this CoordinatorLayout viewGroup, RecyclerView recyclerView, AutoLayoutViewModel viewModel, Action buttonAction, ILifecycleOwner lifecycleOwner, AppBarLayout appBarLayout = null)
	{
		int num = Converter.DpToPx(56f);
		CoordinatorLayout.LayoutParams layoutParams = new CoordinatorLayout.LayoutParams(num, num);
		layoutParams.Gravity = 8388693;
		int bottomMargin = (layoutParams.MarginEnd = Converter.DpToPx(16f));
		layoutParams.BottomMargin = bottomMargin;
		FloatingActionButton floatingActionButton = CreateGoToTopButton(viewGroup, layoutParams);
		GoToTopButtonAutoLayoutScrollListener scrollListener = new GoToTopButtonAutoLayoutScrollListener(recyclerView, viewModel, floatingActionButton, floatingActionButton.Show, floatingActionButton.Hide, appBarLayout);
		return AddGoToTopButton(viewGroup, recyclerView, floatingActionButton, buttonAction, lifecycleOwner, scrollListener, appBarLayout);
	}

	public static (FloatingActionButton, GoToTopButtonScrollListener) AddGoToTopButton(this CoordinatorLayout viewGroup, RecyclerView recyclerView, Action buttonAction, ILifecycleOwner lifecycleOwner, AppBarLayout appBarLayout = null)
	{
		int num = Converter.DpToPx(56f);
		CoordinatorLayout.LayoutParams layoutParams = new CoordinatorLayout.LayoutParams(num, num);
		layoutParams.Gravity = 8388693;
		int bottomMargin = (layoutParams.MarginEnd = Converter.DpToPx(16f));
		layoutParams.BottomMargin = bottomMargin;
		return AddGoToTopButton(viewGroup, recyclerView, CreateGoToTopButton(viewGroup, layoutParams), buttonAction, lifecycleOwner, null, appBarLayout);
	}

	public static (FloatingActionButton, GoToTopButtonScrollListener) AddGoToTopButton(this ConstraintLayout viewGroup, RecyclerView recyclerView, Action buttonAction, ILifecycleOwner lifecycleOwner, AppBarLayout appBarLayout = null)
	{
		int num = Converter.DpToPx(56f);
		ConstraintLayout.LayoutParams layoutParams = new ConstraintLayout.LayoutParams(num, num);
		FloatingActionButton floatingActionButton = CreateGoToTopButton(viewGroup, layoutParams);
		ConstraintSet constraintSet = new ConstraintSet();
		constraintSet.Clone(viewGroup);
		constraintSet.Connect(floatingActionButton.Id, 4, viewGroup.Id, 4, Converter.DpToPx(16f));
		constraintSet.Connect(floatingActionButton.Id, 7, viewGroup.Id, 7, Converter.DpToPx(16f));
		constraintSet.ApplyTo(viewGroup);
		return AddGoToTopButton(viewGroup, recyclerView, floatingActionButton, buttonAction, lifecycleOwner, null, appBarLayout);
	}

	private static FloatingActionButton CreateGoToTopButton(ViewGroup viewGroup, ViewGroup.LayoutParams layoutParams)
	{
		FloatingActionButton floatingActionButton = new FloatingActionButton(viewGroup.Context)
		{
			Id = View.GenerateViewId(),
			RippleColor = 0,
			BackgroundTintList = ContextCompat.GetColorStateList(viewGroup.Context, 2131099697),
			ImageTintList = ContextCompat.GetColorStateList(viewGroup.Context, 2131100611),
			Visibility = ViewStates.Invisible
		};
		floatingActionButton.SetImageResource(2131231037);
		viewGroup.AddView(floatingActionButton, layoutParams);
		return floatingActionButton;
	}

	private static (FloatingActionButton, GoToTopButtonScrollListener) AddGoToTopButton(ViewGroup viewGroup, RecyclerView recyclerView, FloatingActionButton goToTopButton, Action buttonAction, ILifecycleOwner lifecycleOwner, GoToTopButtonScrollListener scrollListener = null, AppBarLayout appBarLayout = null)
	{
		if (viewGroup == null || recyclerView == null || goToTopButton == null || buttonAction == null)
		{
			throw new ArgumentNullException();
		}
		AnimationSet animationSet = new AnimationSet(shareInterpolator: true);
		animationSet.Duration = 200L;
		animationSet.FillAfter = true;
		animationSet.AddAnimation(new ScaleAnimation(0f, 1f, 0f, 1f, 50f, 50f));
		animationSet.AddAnimation(new AlphaAnimation(0f, 1f));
		AnimationSet animationSet2 = new AnimationSet(shareInterpolator: true);
		animationSet2.Duration = 200L;
		animationSet2.FillAfter = true;
		animationSet2.AddAnimation(new ScaleAnimation(1f, 0f, 1f, 0f, 50f, 50f));
		animationSet2.AddAnimation(new AlphaAnimation(1f, 0f));
		scrollListener = scrollListener ?? new GoToTopButtonScrollListener(goToTopButton, goToTopButton.Show, goToTopButton.Hide, appBarLayout);
		recyclerView.AddScrollListener(scrollListener).AutoDisposeOnDestroy(lifecycleOwner);
		goToTopButton.SetOnClickListener(new ViewOnClickListener((Action<View>)delegate
		{
			OnButtonClicked();
		}).AutoDisposeOnDestroy(lifecycleOwner));
		Disposable.Create(delegate
		{
			goToTopButton?.SetOnClickListener(null);
			scrollListener?.Dispose();
		}).AutoDisposeOnDestroy(lifecycleOwner);
		return (goToTopButton, scrollListener);
		void OnButtonClicked()
		{
			scrollListener.SetAutoScrollingToTop();
			buttonAction();
			goToTopButton?.Hide();
		}
	}
}
