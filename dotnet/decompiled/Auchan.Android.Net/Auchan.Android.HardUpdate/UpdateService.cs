using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Auchan.Common.HardUpdate;
using Auchan.Common.Logs;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.HardUpdate;

internal sealed class UpdateService : IUpdateService
{
	private const string GOOGLE_PLAY = "com.android.vending";

	private const string RUSTORE = "ru.vk.store";

	private const string HUAWEI_STORE = "com.huawei.appmarket";

	private const string XIAOMI_STORE = "com.xiaomi.mipicks";

	private const bool HAS_PLAY_SERVICES = false;

	private readonly ILogService _logService;

	private readonly Context _context;

	private readonly PackageManager _packageManager;

	private readonly string _packageName;

	private readonly bool _applicationContext;

	public UpdatePackageOwner InstalledFrom => GetUpdatePackageOwner();

	private global::Android.Net.Uri UpdateUri => global::Android.Net.Uri.Parse("market://details?id=" + _packageName);

	public UpdateService(ILogService logService)
	{
		_logService = logService;
		Activity currentActivity = ActivityStateManager.Default.GetCurrentActivity();
		if (currentActivity == null)
		{
			_context = Application.Context;
			_applicationContext = true;
		}
		else
		{
			_context = currentActivity;
		}
		_packageManager = _context.PackageManager;
		_packageName = _context.PackageName;
	}

	public Task NavigateToStoreAsync()
	{
		string text = FindInstallerPackage();
		if (text == null)
		{
			global::Android.Net.Uri uri = global::Android.Net.Uri.Parse("https://www.rustore.ru/catalog/app/" + _packageName);
			StartIntent(new Intent("android.intent.action.VIEW", uri));
			return Task.CompletedTask;
		}
		Intent intent = new Intent("android.intent.action.VIEW", UpdateUri);
		intent.SetPackage(text);
		StartIntent(intent);
		return Task.CompletedTask;
	}

	private string? FindInstallerPackage()
	{
		string updateOwner = GetUpdateOwner();
		if (updateOwner != null)
		{
			return updateOwner;
		}
		Intent intent = new Intent("android.intent.action.VIEW", UpdateUri);
		ImmutableList<string> immutableList = (from i in _packageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly)
			select i.ActivityInfo.PackageName).ToImmutableList();
		_logService.LogInfo("UpdateService", "found stores [" + string.Join(", ", immutableList) + "]", LogType.Debug, SystemType.MobileApp);
		string text = FilterSupportedStores(immutableList);
		_logService.LogInfo("UpdateService", $"selected store package [{text}] due has play services {0}", LogType.Debug, SystemType.MobileApp);
		return text;
	}

	private string? GetUpdateOwner()
	{
		string text = null;
		if (OperatingSystem.IsAndroidVersionAtLeast(30))
		{
			InstallSourceInfo installSourceInfo = _packageManager.GetInstallSourceInfo(_packageName);
			if (OperatingSystem.IsAndroidVersionAtLeast(34))
			{
				text = FilterSupportedStores(new global::_003C_003Ez__ReadOnlySingleElementList<string>(installSourceInfo.UpdateOwnerPackageName));
				_logService.LogInfo("UpdateService", "found package owner " + installSourceInfo.UpdateOwnerPackageName, LogType.Debug, SystemType.MobileApp);
				if (!string.IsNullOrEmpty(installSourceInfo.UpdateOwnerPackageName))
				{
					return text;
				}
			}
			if (text == null)
			{
				text = FilterSupportedStores(new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { installSourceInfo.InstallingPackageName, installSourceInfo.InitiatingPackageName }));
				_logService.LogInfo("UpdateService", "found installer " + installSourceInfo.InstallingPackageName + " and  initator " + installSourceInfo.InitiatingPackageName, LogType.Debug, SystemType.MobileApp);
			}
		}
		else
		{
			string installerPackageName = _packageManager.GetInstallerPackageName(_packageName);
			text = FilterSupportedStores(new global::_003C_003Ez__ReadOnlySingleElementList<string>(installerPackageName));
			_logService.LogInfo("UpdateService", "found installer package " + installerPackageName, LogType.Debug, SystemType.MobileApp);
		}
		return text;
	}

	private string? FilterSupportedStores(IEnumerable<string?> stores)
	{
		return (from sp in new global::_003C_003Ez__ReadOnlyArray<string>(new string[3] { "ru.vk.store", "com.huawei.appmarket", "com.xiaomi.mipicks" })
			join store in stores on sp equals store
			select store).FirstOrDefault();
	}

	private void StartIntent(Intent intent)
	{
		if (_applicationContext)
		{
			intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
		}
		_context.StartActivity(intent);
	}

	private UpdatePackageOwner GetUpdatePackageOwner()
	{
		return FindInstallerPackage() switch
		{
			"com.android.vending" => UpdatePackageOwner.Google, 
			"ru.vk.store" => UpdatePackageOwner.RuStore, 
			"com.huawei.appmarket" => UpdatePackageOwner.Huawei, 
			"com.xiaomi.mipicks" => UpdatePackageOwner.Xiaomi, 
			_ => UpdatePackageOwner.Unknown, 
		};
	}
}
