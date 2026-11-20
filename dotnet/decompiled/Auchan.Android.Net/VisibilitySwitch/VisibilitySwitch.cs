using System;
using System.Linq;
using Android.Views;

namespace VisibilitySwitch;

public class VisibilitySwitch<T> : VisibilitySwitchBase<T, View>
{
	public VisibilitySwitch(T initialState = default(T))
		: base(initialState)
	{
	}

	public override void Add(T state, params View[] views)
	{
		foreach (ViewStub item in views.OfType<ViewStub>())
		{
			item.InflateEvent += OnViewStubInflated;
		}
		base.Add(state, views);
	}

	private void OnViewStubInflated(object sender, ViewStub.InflateEventArgs e)
	{
		ViewStub viewStub = (ViewStub)sender;
		viewStub.InflateEvent -= OnViewStubInflated;
		ReplaceViewStub(viewStub, e.Inflated);
	}

	private void ReplaceViewStub(ViewStub stub, View inflated)
	{
		foreach (View[] value in base.Values)
		{
			int num = Array.IndexOf(value, stub);
			if (num != -1)
			{
				value[num] = inflated;
			}
		}
	}

	protected override void SetVisibility(View view, bool visibility)
	{
		view.Visibility = ((!visibility) ? ViewStates.Gone : ViewStates.Visible);
	}
}
