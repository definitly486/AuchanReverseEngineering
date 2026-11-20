using System;
using System.Threading.Tasks;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Ecom.Product;
using Auchan.Android.Extensions;
using Auchan.Common.Common;
using Auchan.Common.Managers.Dialogs;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Dialogs;

internal sealed class DroidAgeGateDialog : AgeGateDialog
{
	private readonly Lazy<FragmentFactory> _fragmentFactory;

	public DroidAgeGateDialog(Lazy<FragmentFactory> fragmentFactory, Lazy<IDataBroker> dataBroker)
		: base(dataBroker)
	{
		_fragmentFactory = fragmentFactory;
	}

	protected override async Task PlatformShowAgeGateDialogAsync(BrokerToken token)
	{
		FragmentActivity activity = (FragmentActivity)Platform.CurrentActivity;
		await activity.WaitForStateAsync(Lifecycle.State.Resumed);
		AgeGateFragment ageGateFragment = _fragmentFactory.Value.Instantiate<AgeGateFragment>();
		ageGateFragment.Arguments = token.ToNavBundle();
		ageGateFragment.Show(activity.SupportFragmentManager, null);
	}
}
