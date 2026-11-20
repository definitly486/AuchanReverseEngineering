using Android.App;
using Auchan.Common.Common;

namespace Auchan.Android.Common;

public class AndroidAppAvailabilityService : IAppAvailabilityService
{
	bool IAppAvailabilityService.MirPayAvailable => IsPackageAvailable("ru.nspk.mirpay");

	bool IAppAvailabilityService.TPayAvailable => IsPackageAvailable("com.idamob.tinkoff.android");

	bool IAppAvailabilityService.SberPayAvailable => IsPackageAvailable("ru.sberbankmobile");

	private static bool IsPackageAvailable(string packageName)
	{
		return Application.Context.PackageManager?.GetLaunchIntentForPackage(packageName) != null;
	}
}
