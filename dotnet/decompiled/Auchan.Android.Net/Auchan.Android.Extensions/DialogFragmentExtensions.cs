using System.Threading.Tasks;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using Auchan.Android.Base;

namespace Auchan.Android.Extensions;

internal static class DialogFragmentExtensions
{
	public static async Task DismissAsync(this DialogFragment @this)
	{
		await @this.Activity.WaitForStateAsync(Lifecycle.State.Resumed);
		@this.Dismiss();
	}
}
