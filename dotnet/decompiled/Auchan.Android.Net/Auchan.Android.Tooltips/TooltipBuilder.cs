using System;
using System.Collections.Generic;
using Android.OS;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Tooltips;
using Newtonsoft.Json;

namespace Auchan.Android.Tooltips;

internal class TooltipBuilder
{
	private int _targetViewId;

	private int _scrollViewId;

	private readonly Dictionary<int, (TooltipTargetType type, float insets, float? customRadius, int scrollTargetId)> _views = new Dictionary<int, (TooltipTargetType, float, float?, int)>();

	public TooltipBuilder AddView(int targetId, TooltipTargetType type, float insets = 0f, float? customRadius = null, int? scrollTargetId = null)
	{
		if (_views.ContainsKey(targetId))
		{
			throw new InvalidOperationException($"View {targetId} is already used as {_views[targetId]}");
		}
		_views.Add(targetId, (type, insets, customRadius, scrollTargetId ?? targetId));
		return this;
	}

	public TooltipBuilder SetTargetView(int targetViewId)
	{
		_targetViewId = targetViewId;
		return this;
	}

	public TooltipBuilder SetScrollView(int scrollViewId)
	{
		_scrollViewId = scrollViewId;
		return this;
	}

	public void ShowInQueue(DroidPopupQueue queueManager, object arg)
	{
		Bundle bundle = BuildBundle();
		arg?.ToNavBundle(bundle);
		queueManager.Show<TooltipFragment>(bundle);
	}

	public void Show(FragmentManager fragmentManager, object? arg = null, string? tag = null)
	{
		TooltipFragment tooltipFragment = fragmentManager.FragmentFactory.Instantiate<TooltipFragment>();
		Bundle bundle = BuildBundle();
		arg?.ToNavBundle(bundle);
		tooltipFragment.Arguments = bundle;
		tooltipFragment.Show(fragmentManager, tag);
	}

	private Bundle BuildBundle()
	{
		Bundle bundle = new Bundle();
		string value = JsonConvert.SerializeObject(_views);
		bundle.PutInt("tooltip_fragment_target_key", _targetViewId);
		bundle.PutInt("tooltip_fragment_scroll_key", _scrollViewId);
		bundle.PutString("tooltip_fragment_views_key", value);
		return bundle;
	}
}
