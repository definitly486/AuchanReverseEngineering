using System;
using System.Collections.Generic;
using Android.OS;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Newtonsoft.Json;

namespace Auchan.Android.Common.HighlightScreen;

internal class HighlightBundleBuilder
{
	private int _searchRootViewId;

	private int _targetViewId;

	private readonly Dictionary<int, (float insets, float? customRadius)> _views = new Dictionary<int, (float, float?)>();

	public HighlightBundleBuilder AddView(int? targetId, float insets = 0f, float? customRadius = null)
	{
		if (!targetId.HasValue)
		{
			return this;
		}
		if (_views.ContainsKey(targetId.Value))
		{
			throw new InvalidOperationException($"View {targetId.Value} is already used as {_views[targetId.Value]}");
		}
		_views.Add(targetId.Value, (insets, customRadius));
		return this;
	}

	public HighlightBundleBuilder SetTargetView(int targetViewId)
	{
		_targetViewId = targetViewId;
		return this;
	}

	public HighlightBundleBuilder SetSearchRoot(int searchRootViewId)
	{
		_searchRootViewId = searchRootViewId;
		return this;
	}

	public void ShowInQueue(DroidPopupQueue queueManager, object arg)
	{
		ShowInQueue<HighlightScreenFragment>(queueManager, arg);
	}

	public void ShowInQueue<TFragment>(DroidPopupQueue queueManager, object arg, Func<bool> canShow = null) where TFragment : DialogFragment
	{
		Bundle bundle = BuildBundle();
		arg?.ToNavBundle(bundle);
		queueManager.Show<TFragment>(bundle, canShow);
	}

	public void Show(FragmentManager fragmentManager, object args = null, string tag = null)
	{
		Show<HighlightScreenFragment>(fragmentManager, args, tag);
	}

	public void Show<TFragment>(FragmentManager fragmentManager, object args = null, string tag = null) where TFragment : DialogFragment
	{
		TFragment val = fragmentManager.FragmentFactory.Instantiate<TFragment>();
		Bundle bundle = BuildBundle();
		args?.ToNavBundle(bundle);
		val.Arguments = bundle;
		val.Show(fragmentManager, tag);
	}

	private Bundle BuildBundle()
	{
		Bundle bundle = new Bundle();
		string value = JsonConvert.SerializeObject(_views);
		bundle.PutInt("highlight_fragment_search_root_key", _searchRootViewId);
		bundle.PutInt("highlight_fragment_target_key", _targetViewId);
		bundle.PutString("highlight_fragment_views_key", value);
		return bundle;
	}
}
