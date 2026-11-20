using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;

namespace Microsoft.Maui.ApplicationModel;

public static class Permissions
{
	public abstract class BasePermission
	{
		public BasePermission()
		{
		}

		public abstract Task<PermissionStatus> CheckStatusAsync();

		public abstract Task<PermissionStatus> RequestAsync();

		public abstract void EnsureDeclared();

		public abstract bool ShouldShowRationale();
	}

	public class Camera : BasePlatformPermission
	{
		public override (string androidPermission, bool isRuntime)[] RequiredPermissions => new(string, bool)[1] { ("android.permission.CAMERA", true) };
	}

	public class LocationWhenInUse : BasePlatformPermission
	{
		public override (string androidPermission, bool isRuntime)[] RequiredPermissions => new(string, bool)[2]
		{
			("android.permission.ACCESS_COARSE_LOCATION", true),
			("android.permission.ACCESS_FINE_LOCATION", true)
		};

		public override async Task<PermissionStatus> RequestAsync()
		{
			if (await CheckStatusAsync() == PermissionStatus.Granted)
			{
				return PermissionStatus.Granted;
			}
			return (await DoRequest(new string[2] { "android.permission.ACCESS_COARSE_LOCATION", "android.permission.ACCESS_FINE_LOCATION" })).GrantResults.Count((Permission x) => x == Permission.Granted) switch
			{
				2 => PermissionStatus.Granted, 
				1 => PermissionStatus.Restricted, 
				_ => PermissionStatus.Denied, 
			};
		}
	}

	public class LocationAlways : BasePlatformPermission
	{
		public override (string androidPermission, bool isRuntime)[] RequiredPermissions
		{
			get
			{
				List<(string, bool)> list = new List<(string, bool)>();
				if (OperatingSystem.IsAndroidVersionAtLeast(29) && Application.Context.ApplicationInfo.TargetSdkVersion >= BuildVersionCodes.Q)
				{
					list.Add(("android.permission.ACCESS_BACKGROUND_LOCATION", true));
				}
				list.Add(("android.permission.ACCESS_COARSE_LOCATION", true));
				list.Add(("android.permission.ACCESS_FINE_LOCATION", true));
				return list.ToArray();
			}
		}

		public override async Task<PermissionStatus> RequestAsync()
		{
			if (await CheckStatusAsync() == PermissionStatus.Granted)
			{
				return PermissionStatus.Granted;
			}
			if (OperatingSystem.IsAndroidVersionAtLeast(30))
			{
				PermissionStatus permissionResult = await new LocationWhenInUse().RequestAsync();
				if (permissionResult == PermissionStatus.Denied)
				{
					return PermissionStatus.Denied;
				}
				if (!(await DoRequest(new string[1] { "android.permission.ACCESS_BACKGROUND_LOCATION" })).GrantResults.All((Permission x) => x == Permission.Granted))
				{
					permissionResult = PermissionStatus.Restricted;
				}
				return permissionResult;
			}
			return await base.RequestAsync();
		}
	}

	public class Media : BasePlatformPermission
	{
	}

	public class NetworkState : BasePlatformPermission
	{
		public override (string androidPermission, bool isRuntime)[] RequiredPermissions
		{
			get
			{
				List<(string, bool)> list = new List<(string, bool)> { ("android.permission.ACCESS_NETWORK_STATE", false) };
				if (IsDeclaredInManifest("android.permission.CHANGE_NETWORK_STATE"))
				{
					list.Add(("android.permission.CHANGE_NETWORK_STATE", true));
				}
				return list.ToArray();
			}
		}
	}

	public class StorageRead : BasePlatformPermission
	{
		public override (string androidPermission, bool isRuntime)[] RequiredPermissions
		{
			get
			{
				if (OperatingSystem.IsAndroidVersionAtLeast(33))
				{
					return Array.Empty<(string, bool)>();
				}
				return new(string, bool)[1] { ("android.permission.READ_EXTERNAL_STORAGE", true) };
			}
		}

		public override Task<PermissionStatus> RequestAsync()
		{
			if (OperatingSystem.IsAndroidVersionAtLeast(33))
			{
				return Task.FromResult(PermissionStatus.Granted);
			}
			return base.RequestAsync();
		}

		public override Task<PermissionStatus> CheckStatusAsync()
		{
			if (OperatingSystem.IsAndroidVersionAtLeast(33))
			{
				return Task.FromResult(PermissionStatus.Granted);
			}
			return base.CheckStatusAsync();
		}
	}

	public class Vibrate : BasePlatformPermission
	{
		public override (string androidPermission, bool isRuntime)[] RequiredPermissions => new(string, bool)[1] { ("android.permission.VIBRATE", false) };
	}

	public class PermissionResult
	{
		[CompilerGenerated]
		private readonly string[] _003CPermissions_003Ek__BackingField;

		public Permission[] GrantResults { get; }

		public PermissionResult(string[] permissions, Permission[] grantResults)
		{
			_003CPermissions_003Ek__BackingField = permissions;
			GrantResults = grantResults;
		}
	}

	public abstract class BasePlatformPermission : BasePermission
	{
		private static readonly Dictionary<int, TaskCompletionSource<PermissionResult>> requests = new Dictionary<int, TaskCompletionSource<PermissionResult>>();

		private static readonly object locker = new object();

		private static int requestCode;

		public virtual (string androidPermission, bool isRuntime)[] RequiredPermissions { get; }

		public override Task<PermissionStatus> CheckStatusAsync()
		{
			if (RequiredPermissions == null || RequiredPermissions.Length == 0)
			{
				return Task.FromResult(PermissionStatus.Granted);
			}
			(string, bool)[] requiredPermissions = RequiredPermissions;
			for (int i = 0; i < requiredPermissions.Length; i++)
			{
				(string, bool) tuple = requiredPermissions[i];
				string item = tuple.Item1;
				bool item2 = tuple.Item2;
				string text = item;
				if (!IsDeclaredInManifest(text))
				{
					throw new PermissionException("You need to declare using the permission: `" + item + "` in your AndroidManifest.xml");
				}
				PermissionStatus permissionStatus = DoCheck(text);
				if (permissionStatus != PermissionStatus.Granted)
				{
					return Task.FromResult(PermissionStatus.Denied);
				}
			}
			return Task.FromResult(PermissionStatus.Granted);
		}

		public override async Task<PermissionStatus> RequestAsync()
		{
			if (await CheckStatusAsync() == PermissionStatus.Granted)
			{
				return PermissionStatus.Granted;
			}
			string[] array = RequiredPermissions.Where(((string androidPermission, bool isRuntime) p) => p.isRuntime)?.Select(((string androidPermission, bool isRuntime) p) => p.androidPermission)?.ToArray();
			if (array == null || !array.Any())
			{
				return PermissionStatus.Granted;
			}
			if ((await DoRequest(array)).GrantResults.Any((Permission g) => g == Permission.Denied))
			{
				return PermissionStatus.Denied;
			}
			return PermissionStatus.Granted;
		}

		protected virtual async Task<PermissionResult> DoRequest(string[] permissions)
		{
			TaskCompletionSource<PermissionResult> taskCompletionSource;
			lock (locker)
			{
				taskCompletionSource = new TaskCompletionSource<PermissionResult>();
				requestCode = PlatformUtils.NextRequestCode();
				requests.Add(requestCode, taskCompletionSource);
			}
			if (!MainThread.IsMainThread)
			{
				throw new PermissionException("Permission request must be invoked on main thread.");
			}
			ActivityCompat.RequestPermissions(ActivityStateManager.Default.GetCurrentActivity(throwOnNull: true), permissions.ToArray(), requestCode);
			return await taskCompletionSource.Task;
		}

		public override void EnsureDeclared()
		{
			if (RequiredPermissions == null || RequiredPermissions.Length == 0)
			{
				return;
			}
			(string, bool)[] requiredPermissions = RequiredPermissions;
			for (int i = 0; i < requiredPermissions.Length; i++)
			{
				(string, bool) tuple = requiredPermissions[i];
				string item = tuple.Item1;
				bool item2 = tuple.Item2;
				string permission = item;
				if (!IsDeclaredInManifest(permission))
				{
					throw new PermissionException("You need to declare using the permission: `" + item + "` in your AndroidManifest.xml");
				}
			}
		}

		public override bool ShouldShowRationale()
		{
			if (RequiredPermissions == null || RequiredPermissions.Length == 0)
			{
				return false;
			}
			Activity currentActivity = ActivityStateManager.Default.GetCurrentActivity(throwOnNull: true);
			(string, bool)[] requiredPermissions = RequiredPermissions;
			for (int i = 0; i < requiredPermissions.Length; i++)
			{
				(string, bool) tuple = requiredPermissions[i];
				var (permission, _) = tuple;
				if (tuple.Item2 && ActivityCompat.ShouldShowRequestPermissionRationale(currentActivity, permission))
				{
					return true;
				}
			}
			return false;
		}

		protected virtual PermissionStatus DoCheck(string androidPermission)
		{
			Context appContext = Platform.AppContext;
			bool flag = appContext.ApplicationInfo.TargetSdkVersion >= BuildVersionCodes.M;
			if (!IsDeclaredInManifest(androidPermission))
			{
				throw new PermissionException("You need to declare using the permission: `" + androidPermission + "` in your AndroidManifest.xml");
			}
			PermissionStatus permissionStatus = PermissionStatus.Granted;
			if (flag)
			{
				return ContextCompat.CheckSelfPermission(appContext, androidPermission) switch
				{
					Permission.Granted => PermissionStatus.Granted, 
					Permission.Denied => PermissionStatus.Denied, 
					_ => PermissionStatus.Unknown, 
				};
			}
			return PermissionChecker.CheckSelfPermission(appContext, androidPermission) switch
			{
				0 => PermissionStatus.Granted, 
				-1 => PermissionStatus.Denied, 
				-2 => PermissionStatus.Denied, 
				_ => PermissionStatus.Unknown, 
			};
		}

		internal static void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
		{
			lock (locker)
			{
				if (requests.ContainsKey(requestCode))
				{
					PermissionResult result = new PermissionResult(permissions, grantResults);
					requests[requestCode].TrySetResult(result);
					requests.Remove(requestCode);
				}
			}
		}
	}

	public static Task<PermissionStatus> CheckStatusAsync<TPermission>() where TPermission : BasePermission, new()
	{
		return new TPermission().CheckStatusAsync();
	}

	public static Task<PermissionStatus> RequestAsync<TPermission>() where TPermission : BasePermission, new()
	{
		return new TPermission().RequestAsync();
	}

	internal static void EnsureDeclared<TPermission>() where TPermission : BasePermission, new()
	{
		new TPermission().EnsureDeclared();
	}

	internal static async Task EnsureGrantedOrRestrictedAsync<TPermission>() where TPermission : BasePermission, new()
	{
		PermissionStatus permissionStatus = await RequestAsync<TPermission>();
		if (permissionStatus != PermissionStatus.Granted && permissionStatus != PermissionStatus.Restricted)
		{
			throw new PermissionException($"{typeof(TPermission).Name} permission was not granted or restricted: {permissionStatus}");
		}
	}

	public static bool IsDeclaredInManifest(string permission)
	{
		Context context = Application.Context;
		return (context.PackageManager.GetPackageInfo(context.PackageName, PackageInfoFlags.Permissions)?.RequestedPermissions)?.Any((string r) => r.Equals(permission, StringComparison.OrdinalIgnoreCase)) ?? false;
	}

	internal static void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
	{
		BasePlatformPermission.OnRequestPermissionsResult(requestCode, permissions, grantResults);
	}
}
