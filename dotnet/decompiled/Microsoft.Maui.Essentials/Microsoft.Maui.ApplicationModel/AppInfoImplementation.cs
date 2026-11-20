using System;
using System.Globalization;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using AndroidX.Core.Content.PM;

namespace Microsoft.Maui.ApplicationModel;

internal class AppInfoImplementation : IAppInfo
{
	private static readonly Lazy<string> _name = new Lazy<string>(() => Application.Context.ApplicationInfo.LoadLabel(Application.Context.PackageManager));

	private static readonly Lazy<string> _packageName = new Lazy<string>(() => Application.Context.PackageName);

	private static readonly Lazy<PackageInfo> _packageInfo = new Lazy<PackageInfo>(() => Application.Context.PackageManager.GetPackageInfo(_packageName.Value, PackageInfoFlags.MetaData));

	public string PackageName => _packageName.Value;

	public string VersionString => _packageInfo.Value.VersionName;

	public string BuildString => PackageInfoCompat.GetLongVersionCode(_packageInfo.Value).ToString(CultureInfo.InvariantCulture);

	public void ShowSettingsUI()
	{
		Context context = ActivityStateManager.Default.GetCurrentActivity(throwOnNull: false) ?? Application.Context;
		Intent intent = new Intent();
		intent.SetAction("android.settings.APPLICATION_DETAILS_SETTINGS");
		intent.AddCategory("android.intent.category.DEFAULT");
		intent.SetData(global::Android.Net.Uri.Parse("package:" + PackageName));
		ActivityFlags flags = ActivityFlags.ExcludeFromRecents | ActivityFlags.NewTask | ActivityFlags.NoHistory;
		intent.SetFlags(flags);
		context.StartActivity(intent);
	}
}
