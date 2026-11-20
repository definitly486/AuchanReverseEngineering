using System;
using System.Linq;
using System.Threading.Tasks;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Common.Extensions;

namespace Auchan.Android.Extensions;

public static class FragmentExtensions
{
	public static Fragment RequireTargetFragment(this Fragment fragment)
	{
		return fragment.TargetFragment ?? throw new InvalidOperationException("No target fragment found on " + fragment.GetType().Name);
	}

	public static async Task<FragmentManager> GetParentFragmentManagerAsync(this Fragment @this)
	{
		await @this.Activity.WaitForStateAsync(Lifecycle.State.Resumed);
		return @this.ParentFragmentManager;
	}

	public static async Task<FragmentManager> GetChildFragmentManagerAsync(this Fragment @this)
	{
		await @this.Activity.WaitForStateAsync(Lifecycle.State.Resumed);
		return @this.ChildFragmentManager;
	}

	public static Task PopBackStackAsync(this Fragment @this, int popCount = 1)
	{
		if (popCount == 1)
		{
			return @this.PopBackStackSingleAsync();
		}
		return @this.PopBackStackMultipleAsync(popCount);
	}

	private static async Task PopBackStackSingleAsync(this Fragment @this)
	{
		(await @this.GetParentFragmentManagerAsync()).PopBackStack();
	}

	private static async Task PopBackStackMultipleAsync(this Fragment @this, int popCount = 1)
	{
		FragmentManager fm = await @this.GetParentFragmentManagerAsync();
		Enumerable.Range(0, popCount).ForEach(delegate
		{
			fm.PopBackStack();
		});
	}

	public static async Task PopBackStackAsync(this Fragment @this, string name, int flags)
	{
		(await @this.GetParentFragmentManagerAsync()).PopBackStack(name, flags);
	}

	public static Task PopBackStackImmediateAsync(this Fragment @this, int popCount = 1)
	{
		if (popCount == 1)
		{
			return @this.PopBackStackSingleImmediateAsync();
		}
		return @this.PopBackStackMultipleImmediateAsync(popCount);
	}

	private static async Task PopBackStackSingleImmediateAsync(this Fragment @this)
	{
		(await @this.GetParentFragmentManagerAsync()).PopBackStackImmediate();
	}

	private static async Task PopBackStackMultipleImmediateAsync(this Fragment @this, int popCount = 1)
	{
		FragmentManager fm = await @this.GetParentFragmentManagerAsync();
		Enumerable.Range(0, popCount).ForEach(delegate
		{
			fm.PopBackStackImmediate();
		});
	}

	public static async Task PopBackStackImmediateAsync(this Fragment @this, string name, int flags)
	{
		(await @this.GetParentFragmentManagerAsync()).PopBackStackImmediate(name, flags);
	}
}
