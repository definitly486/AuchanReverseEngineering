using System;
using AndroidX.AppCompat.App;
using Auchan.Common.SafeEntrance;
using Auchan.Common.SafeEntrance.Managers;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.SafeEntrance;

public class AndroidSafeEntranceStateObserver : BaseSafeEntranceAppStateObserver
{
	public AndroidSafeEntranceStateObserver(Lazy<ISafeEntranceManager> safeEntranceManager)
		: base(safeEntranceManager)
	{
	}

	protected override void ShowEnterPinPageIfNeeded()
	{
		if (Platform.CurrentActivity is AppCompatActivity appCompatActivity && !(appCompatActivity is SafeEntranceContainerActivity))
		{
			SafeEntranceHelper.OpenEnterPinPageWhenEnterForeground(appCompatActivity);
		}
	}
}
