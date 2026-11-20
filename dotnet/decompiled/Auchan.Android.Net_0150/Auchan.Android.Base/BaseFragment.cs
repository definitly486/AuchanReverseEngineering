using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Views;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AsyncAwaitBestPractices;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Navigation;
using DryIoc;

namespace Auchan.Android.Base;

internal abstract class BaseFragment : AndroidX.Fragment.App.Fragment, IFragmentNavigation, IFragment, INativeController
{
	protected abstract int LayoutId { get; }

	object? INativeController.View => View;

	public override View? OnCreateView(LayoutInflater inflater, ViewGroup? container, Bundle? savedInstanceState)
	{
		return inflater.Inflate(LayoutId, container, attachToRoot: false);
	}

	public T? FindFragment<T>() where T : AndroidX.Fragment.App.Fragment
	{
		return (T)base.ParentFragmentManager.FindFragmentByTag(typeof(T).FullName);
	}

	public bool IsInBackStack<T>() where T : AndroidX.Fragment.App.Fragment
	{
		return FindFragment<T>() != null;
	}

	public bool TryPopToFragmentImmediate<T>(bool inclusive = false) where T : AndroidX.Fragment.App.Fragment
	{
		T fragment;
		return TryPopToFragmentImmediate<T>(out fragment, inclusive);
	}

	public bool TryPopToFragmentImmediate<T>([NotNullWhen(true)] out T? fragment, bool inclusive = false) where T : AndroidX.Fragment.App.Fragment
	{
		fragment = FindFragment<T>();
		if (fragment != null)
		{
			return base.ParentFragmentManager.PopBackStackImmediate(fragment.GetType().FullName, inclusive ? 1 : 0);
		}
		return false;
	}

	public void NavigateTo<TFragment>(int? containerViewId = null, bool add = false) where TFragment : AndroidX.Fragment.App.Fragment
	{
		CommitFragmentTransaction<TFragment, object>(null, containerViewId, add);
	}

	public void NavigateTo<TFragment, TParameter>(TParameter parameter, int? containerViewId = null, bool add = false) where TFragment : AndroidX.Fragment.App.Fragment where TParameter : class
	{
		CommitFragmentTransaction<TFragment, TParameter>(parameter, containerViewId, add);
	}

	private void CommitFragmentTransaction<TFragment, TParameter>(TParameter? parameter, int? containerViewId, bool add) where TFragment : AndroidX.Fragment.App.Fragment where TParameter : class
	{
		base.ParentFragmentManager.BeginTransaction().Commit<TFragment, TParameter>(this, parameter, containerViewId, add);
	}

	public Task NavigateToAsync<TFragment>(int? containerViewId = null, bool add = false) where TFragment : AndroidX.Fragment.App.Fragment
	{
		return CommitFragmentTransactionAsync<TFragment, object>(null, containerViewId, add);
	}

	public Task NavigateToAsync<TFragment, TParameter>(TParameter parameter, int? containerViewId = null, bool add = false) where TFragment : AndroidX.Fragment.App.Fragment where TParameter : class
	{
		return CommitFragmentTransactionAsync<TFragment, TParameter>(parameter, containerViewId, add);
	}

	private async Task CommitFragmentTransactionAsync<TFragment, TParameter>(TParameter? parameter, int? containerViewId = null, bool add = false) where TFragment : AndroidX.Fragment.App.Fragment where TParameter : class
	{
		(await this.GetParentFragmentManagerAsync()).BeginTransaction().Commit<TFragment, TParameter>(this, parameter, containerViewId, add);
	}

	protected TFragment Show<TFragment>() where TFragment : DialogFragment
	{
		return Show<TFragment, object>(null);
	}

	protected TFragment Show<TFragment, TParameter>(TParameter? parameter) where TFragment : DialogFragment
	{
		TFragment val = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<FragmentFactory>().Instantiate<TFragment>();
		if (parameter != null)
		{
			val.Arguments = parameter.ToNavBundle();
		}
		val.Show(base.ChildFragmentManager, null);
		return val;
	}

	protected Task<TFragment> ShowAsync<TFragment>() where TFragment : DialogFragment
	{
		return ShowAsync<TFragment, object>(null);
	}

	protected async Task<TFragment> ShowAsync<TFragment, TParameter>(TParameter? parameter) where TFragment : DialogFragment
	{
		await RequireActivity().WaitForStateAsync(AndroidX.Lifecycle.Lifecycle.State.Resumed);
		TFragment val = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<FragmentFactory>().Instantiate<TFragment>();
		if (parameter != null)
		{
			val.Arguments = parameter.ToNavBundle();
		}
		val.Show(base.ChildFragmentManager, null);
		return val;
	}

	LayoutInflater IFragment.get_LayoutInflater()
	{
		return base.LayoutInflater;
	}

	FragmentManager IFragment.get_ParentFragmentManager()
	{
		return base.ParentFragmentManager;
	}
}
internal abstract class BaseFragment<T> : BaseFragmentWithViewModel, IOnNavigateFrom where T : ScreenViewModel
{
	private readonly Func<AndroidX.Fragment.App.Fragment, T> _newViewModel;

	public T ViewModel { get; private set; }

	protected virtual bool NeedToAdjustScreenToKeyboardMoves => false;

	protected BaseFragment(Func<AndroidX.Fragment.App.Fragment, T> newViewModel)
	{
		_newViewModel = newViewModel;
	}

	public sealed override ScreenViewModel GetViewModel()
	{
		return ViewModel;
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
		if (base.ParentFragment is IFragmentContainer { IsHidden: not false })
		{
			if (hidden)
			{
				ViewModel.DoPause().SafeFireAndForget((Action<Exception>)null, false);
			}
			return;
		}
		if (Lifecycle.CurrentState.IsAtLeast(AndroidX.Lifecycle.Lifecycle.State.Started) && !hidden)
		{
			UpdateTabBarVisibility();
		}
		if (hidden)
		{
			ViewModel.DoPause().SafeFireAndForget((Action<Exception>)null, false);
		}
		else
		{
			ViewModel.DoResume().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public virtual NavigationPossibilityType OnNavigateFrom()
	{
		return ((IOnNavigateFrom)ViewModel)?.OnNavigateFrom() ?? NavigationPossibilityType.Impossible;
	}

	public override void OnResume()
	{
		base.OnResume();
		UpdateTabBarVisibility();
		AdjustScreenToKeyboardMovesIfNeeded(enable: true);
	}

	public override void OnPause()
	{
		base.OnPause();
		AdjustScreenToKeyboardMovesIfNeeded(enable: false);
	}

	private void AdjustScreenToKeyboardMovesIfNeeded(bool enable)
	{
		FragmentActivity fragmentActivity = RequireActivity();
		if (!NeedToAdjustScreenToKeyboardMoves)
		{
			ActivityAttribute customAttribute = fragmentActivity.GetType().GetCustomAttribute<ActivityAttribute>();
			if (customAttribute != null && customAttribute.WindowSoftInputMode != SoftInput.AdjustUnspecified)
			{
				fragmentActivity.Window?.SetSoftInputMode(customAttribute.WindowSoftInputMode);
			}
		}
		else
		{
			fragmentActivity.Window?.SetSoftInputMode(enable ? SoftInput.AdjustPan : SoftInput.AdjustResize);
		}
	}

	protected bool IsVisibleInCurrentTab()
	{
		AndroidX.Fragment.App.Fragment fragment = this;
		while (fragment != null && !(fragment is BottomNavigationHostFragment))
		{
			fragment = fragment.ParentFragment;
		}
		if (fragment == null)
		{
			return false;
		}
		ContainerFragment container = ((BottomNavigationHostFragment)fragment).GetContainer();
		bool flag = false;
		for (fragment = this; fragment != null; fragment = fragment.ParentFragment)
		{
			if (fragment == container)
			{
				flag = true;
			}
		}
		AndroidX.Fragment.App.Fragment fragment2 = container?.ChildFragmentManager?.Fragments?.LastOrDefault();
		bool flag2 = false;
		if (fragment2 != null && fragment2 == this)
		{
			flag2 = true;
		}
		return flag && flag2;
	}

	private void UpdateTabBarVisibility()
	{
		if (IsVisibleInCurrentTab() && base.Activity?.SupportFragmentManager.Fragments.FirstOrDefault() is BottomNavigationHostFragment bottomNavigationHostFragment)
		{
			bottomNavigationHostFragment.SetBottomNavigationVisible(ViewModel.TabBarVisible);
		}
	}
}
