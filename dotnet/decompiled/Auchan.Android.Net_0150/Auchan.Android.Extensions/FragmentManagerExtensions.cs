using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;

namespace Auchan.Android.Extensions;

internal static class FragmentManagerExtensions
{
	public static IDisposable OnBackStackChanged(this FragmentManager @this, Action handler)
	{
		return @this.OnBackStackChanged((EventHandler)delegate
		{
			handler();
		});
	}

	public static IDisposable OnBackStackChanged(this FragmentManager @this, EventHandler handler)
	{
		@this.BackStackChanged += handler;
		return Disposable.Create(delegate
		{
			@this.BackStackChanged -= handler;
		});
	}

	public static bool ObserveActiveDialogs(this FragmentManager @this, ISet<DialogFragment> observedDialogs, Action onDialogDestroyed)
	{
		List<DialogFragment> list = @this.Fragments.OfType<DialogFragment>().Where(IsActiveDialog).ToList();
		foreach (DialogFragment dialog in list)
		{
			if (observedDialogs.Add(dialog))
			{
				dialog.LaunchWhen(delegate
				{
					observedDialogs.Remove(dialog);
					onDialogDestroyed();
				}, Lifecycle.Event.OnDestroy);
			}
		}
		return list.Count > 0;
	}

	private static bool IsActiveDialog(Fragment fragment)
	{
		if (fragment is DialogFragment && fragment.IsAdded && !fragment.IsHidden)
		{
			return !fragment.IsRemoving;
		}
		return false;
	}
}
