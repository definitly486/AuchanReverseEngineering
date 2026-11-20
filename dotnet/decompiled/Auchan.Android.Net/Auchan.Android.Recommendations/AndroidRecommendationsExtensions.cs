using System;
using System.Collections.Specialized;
using System.Reactive.Linq;
using AndroidX.Core.Widget;
using AndroidX.Lifecycle;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Extensions;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Extensions;
using Auchan.Common.Recommendations.ViewModels;

namespace Auchan.Android.Recommendations;

public static class AndroidRecommendationsExtensions
{
	public static void SetupWithScrollView(this RecommendationsView recommendationsView, IYandexMetricaScreenViewModel screenViewModel, RecommendationsViewModel viewModel, ILifecycleOwner lifecycleOwner, NestedScrollView scrollView)
	{
		recommendationsView.Setup(screenViewModel, viewModel, lifecycleOwner, scrollView.BecameVisible);
	}

	public static void SetupWithRecyclerView(this RecommendationsView recommendationsView, IYandexMetricaScreenViewModel screenViewModel, RecommendationsViewModel viewModel, ILifecycleOwner lifecycleOwner, RecyclerView recyclerView)
	{
		if (OperatingSystem.IsAndroidVersionAtLeast(23))
		{
			recommendationsView.Setup(screenViewModel, viewModel, lifecycleOwner, recyclerView.BecameVisible);
		}
		else
		{
			recommendationsView.Setup(screenViewModel, viewModel, lifecycleOwner, null);
		}
	}

	public static void HideWhenEmpty(this RecommendationsView recommendationsView, RecommendationsViewModel viewModel, ILifecycleOwner owner)
	{
		recommendationsView.Visibility = viewModel.HasItems.ToVisibility();
		(from c in viewModel.Sections.CollectionChangedAsObservable()
			select c != null && c.NewItems?.Count > 0).SafeSubscribe(delegate(bool v)
		{
			recommendationsView.Visibility = v.ToVisibility();
		}, owner);
	}
}
