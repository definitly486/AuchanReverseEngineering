using System;
using AndroidX.Fragment.App;

namespace Auchan.Android.Base;

internal static class FragmentResultReturnExtensions
{
	public static void ReturnResult<T>(this Fragment fragment, T result)
	{
		try
		{
			((IFragmentResultReceiver<T>)fragment.TargetFragment).OnResult(fragment.TargetRequestCode, result);
		}
		catch (Exception)
		{
		}
	}
}
