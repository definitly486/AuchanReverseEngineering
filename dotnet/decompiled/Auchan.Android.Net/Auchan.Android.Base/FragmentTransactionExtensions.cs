using Android.OS;
using AndroidX.Fragment.App;
using Java.Lang;

namespace Auchan.Android.Base;

internal static class FragmentTransactionExtensions
{
	private static string GetFragmentName<T>() where T : Fragment
	{
		return typeof(T).FullName ?? typeof(T).Name;
	}

	public static FragmentTransaction Add<T>(this FragmentTransaction transaction, Fragment parentFragment, Bundle? args = null, int? requestCode = null, int? containerViewId = null) where T : Fragment
	{
		return transaction.Add(containerViewId ?? parentFragment.Id, CreateFragment<T>(parentFragment, args, requestCode), GetFragmentName<T>());
	}

	public static FragmentTransaction Replace<T>(this FragmentTransaction transaction, Fragment parentFragment, Bundle? args = null, int? requestCode = null, int? containerViewId = null) where T : Fragment
	{
		return transaction.Replace(containerViewId ?? parentFragment.Id, CreateFragment<T>(parentFragment, args, requestCode), GetFragmentName<T>());
	}

	public static void Commit<TFragment, TParameter>(this FragmentTransaction transaction, Fragment from, TParameter? parameter, int? containerViewId, bool add) where TFragment : Fragment where TParameter : class
	{
		transaction.Hide(from);
		if (!add)
		{
			transaction.Replace<TFragment>(from, parameter?.ToNavBundle());
		}
		else
		{
			transaction.Add<TFragment>(from, parameter?.ToNavBundle());
		}
		transaction.AddToBackStack(GetFragmentName<TFragment>());
		transaction.Commit();
	}

	private static Fragment CreateFragment<T>(Fragment parentFragment, Bundle? args, int? requestCode) where T : Fragment
	{
		Fragment fragment = parentFragment.ParentFragmentManager.FragmentFactory.Instantiate(parentFragment.Context.ClassLoader, Class.FromType(typeof(T)).Name);
		if (args != null)
		{
			fragment.Arguments = args;
		}
		if (requestCode.HasValue)
		{
			fragment.SetTargetFragment(parentFragment, requestCode.Value);
		}
		return fragment;
	}

	public static FragmentTransaction Replace<T>(this FragmentManager manager, int containerViewId, Bundle? args = null) where T : Fragment
	{
		FragmentTransaction fragmentTransaction = manager.BeginTransaction();
		Class obj = Class.FromType(typeof(T));
		Fragment fragment = manager.FragmentFactory.Instantiate(obj.ClassLoader, obj.Name);
		if (args != null)
		{
			fragment.Arguments = args;
		}
		return fragmentTransaction.Replace(containerViewId, fragment);
	}
}
