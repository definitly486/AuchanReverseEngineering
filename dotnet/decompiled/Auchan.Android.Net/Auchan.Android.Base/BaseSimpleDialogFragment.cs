using System;
using Android.OS;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;

namespace Auchan.Android.Base;

internal abstract class BaseSimpleDialogFragment<T> : DialogFragment, INativeController where T : ScreenViewModel
{
	private readonly Func<Fragment, T> _newViewModel;

	protected T ViewModel { get; private set; }

	object INativeController.View => View;

	protected BaseSimpleDialogFragment(Func<Fragment, T> newViewModel)
	{
		_newViewModel = newViewModel;
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		ViewModel = this.Retain("ViewModel", delegate
		{
			T val = _newViewModel(this);
			val.DoStart(this).SafeFireAndForget((Action<Exception>)null, false);
			return val;
		}, delegate(T vm)
		{
			vm.Dispose();
		});
	}

	public override void OnStart()
	{
		base.OnStart();
		if (!base.IsHidden)
		{
			ViewModel.DoResume().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public override void OnStop()
	{
		base.OnStop();
		if (!base.IsHidden)
		{
			ViewModel.DoPause().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public override void OnHiddenChanged(bool hidden)
	{
		base.OnHiddenChanged(hidden);
		if (Lifecycle.CurrentState.IsAtLeast(AndroidX.Lifecycle.Lifecycle.State.Started))
		{
			if (hidden)
			{
				ViewModel.DoPause().SafeFireAndForget((Action<Exception>)null, false);
			}
			else
			{
				ViewModel.DoResume().SafeFireAndForget((Action<Exception>)null, false);
			}
		}
	}
}
