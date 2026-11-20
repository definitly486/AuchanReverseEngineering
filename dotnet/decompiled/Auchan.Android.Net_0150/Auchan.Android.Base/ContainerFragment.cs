using System;
using System.Linq;
using Android.OS;
using AndroidX.Activity;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using EBind;

namespace Auchan.Android.Base;

internal abstract class ContainerFragment : BaseFragment, IFragmentContainer
{
	public void PostRepeatedOpenEvent()
	{
		if (base.IsAdded)
		{
			base.ChildFragmentManager.PopBackStack(null, 1);
		}
	}

	bool IFragmentContainer.get_IsHidden()
	{
		return base.IsHidden;
	}
}
internal abstract class ContainerFragment<T> : ContainerFragment where T : Fragment
{
	private OnBackPressedCallback _backPressCallback;

	protected override int LayoutId => 2131493014;

	private bool CapturesBackPress
	{
		get
		{
			if (base.ChildFragmentManager.BackStackEntryCount > 0)
			{
				return !base.IsHidden;
			}
			return false;
		}
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		if (savedInstanceState == null)
		{
			FragmentTransaction transaction = base.ChildFragmentManager.BeginTransaction();
			int? containerViewId = 2131297216;
			transaction.Add<T>(this, null, null, containerViewId).Commit();
		}
		_backPressCallback = RequireActivity().OnBackPressedDispatcher.AddCallback(this, base.ChildFragmentManager.PopBackStack);
		UpdateBackPressCapture();
		base.ChildFragmentManager.BackStackChanged += new DisposableDelegate<EventHandler>(delegate
		{
			UpdateBackPressCapture();
		}, delegate(EventHandler h)
		{
			base.ChildFragmentManager.BackStackChanged -= h;
		}).AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
	}

	private void UpdateBackPressCapture()
	{
		_backPressCallback.Enabled = CapturesBackPress;
	}

	private void NotifyLastChildHiddenChanged(bool hidden)
	{
		if (base.IsAdded)
		{
			Fragment fragment = base.ChildFragmentManager.Fragments.LastOrDefault();
			if (fragment != null && fragment.IsHidden != hidden)
			{
				fragment?.OnHiddenChanged(hidden);
			}
		}
	}

	public override void OnHiddenChanged(bool hidden)
	{
		base.OnHiddenChanged(hidden);
		UpdateBackPressCapture();
		Fragment fragment = base.ChildFragmentManager.FindFragmentById(2131297216);
		if (fragment != null)
		{
			FragmentTransaction fragmentTransaction = base.ChildFragmentManager.BeginTransaction();
			if (hidden)
			{
				fragmentTransaction.Hide(fragment);
			}
			else
			{
				fragmentTransaction.Show(fragment);
			}
			if (base.ChildFragmentManager.IsStateSaved)
			{
				fragmentTransaction.CommitAllowingStateLoss();
			}
			else
			{
				fragmentTransaction.CommitNow();
			}
		}
		NotifyLastChildHiddenChanged(hidden);
	}
}
