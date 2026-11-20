using System.Threading.Tasks;
using Android.App;
using AndroidX.AppCompat.App;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Ecom.Product;
using Auchan.Android.Extensions;
using Auchan.Common.Common;
using Auchan.Common.Managers.Dialogs;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Dialogs;

public class WaitListDialogService : IWaitListDialogService
{
	private readonly FragmentFactory _fragmentFactory;

	public WaitListDialogService(FragmentFactory fragmentFactory)
	{
		_fragmentFactory = fragmentFactory;
	}

	public async Task<AgreeState> ShowUnsubscribeDialogAsync()
	{
		Activity currentActivity = Platform.CurrentActivity;
		AppCompatActivity activity = currentActivity as AppCompatActivity;
		if (activity != null)
		{
			return await MainThread.InvokeOnMainThreadAsync(async delegate
			{
				await activity.WaitForStateAsync(Lifecycle.State.Resumed);
				UnsubscribeProductFragment unsubscribeProductFragment = _fragmentFactory.Instantiate<UnsubscribeProductFragment>();
				unsubscribeProductFragment.Show(activity.SupportFragmentManager, null);
				return await unsubscribeProductFragment.Execute();
			});
		}
		return AgreeState.None;
	}
}
