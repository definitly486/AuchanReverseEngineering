using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Extensions;

public static class PermissionExtensions
{
	private static async Task<PermissionStatus> CheckAsyncSafe<TPermission>(this TPermission permission) where TPermission : Permissions.BasePermission
	{
		try
		{
			return await permission.CheckStatusAsync();
		}
		catch (PermissionException)
		{
			return PermissionStatus.Unknown;
		}
		catch (TaskCanceledException)
		{
			return PermissionStatus.Unknown;
		}
	}

	private static async Task<PermissionStatus> CheckOrRequestSafeAsync<TPermission>(this TPermission permission) where TPermission : Permissions.BasePermission
	{
		_ = 1;
		try
		{
			PermissionStatus permissionStatus = await permission.CheckStatusAsync();
			if (permissionStatus != PermissionStatus.Granted)
			{
				permissionStatus = await permission.RequestAsync();
			}
			return permissionStatus;
		}
		catch (PermissionException)
		{
			return PermissionStatus.Unknown;
		}
		catch (TaskCanceledException)
		{
			return PermissionStatus.Unknown;
		}
	}

	private static async Task<PermissionStatus> RequestSafeAsync<TPermission>(this TPermission permission) where TPermission : Permissions.BasePermission
	{
		_ = 1;
		try
		{
			PermissionStatus permissionStatus = await permission.CheckStatusAsync();
			if (permissionStatus != PermissionStatus.Granted)
			{
				permissionStatus = await permission.RequestAsync();
			}
			return permissionStatus;
		}
		catch (PermissionException)
		{
			return PermissionStatus.Unknown;
		}
		catch (TaskCanceledException)
		{
			return PermissionStatus.Unknown;
		}
	}

	public static async Task<PermissionStatus> CheckAsyncSafe<TPermission>() where TPermission : Permissions.BasePermission, new()
	{
		PermissionStatus result = PermissionStatus.Unknown;
		TPermission permission = new TPermission();
		if (!MainThread.IsMainThread)
		{
			await MainThread.InvokeOnMainThreadAsync(async () => result = await permission.CheckAsyncSafe());
		}
		else
		{
			result = await permission.CheckAsyncSafe();
		}
		return result;
	}

	public static async Task<PermissionStatus> CheckOrRequestAsync<TPermission>() where TPermission : Permissions.BasePermission, new()
	{
		PermissionStatus result = PermissionStatus.Unknown;
		TPermission permission = new TPermission();
		if (!MainThread.IsMainThread)
		{
			await MainThread.InvokeOnMainThreadAsync(async () => result = await permission.CheckOrRequestSafeAsync());
		}
		else
		{
			result = await permission.CheckOrRequestSafeAsync();
		}
		return result;
	}

	public static async Task<PermissionStatus> RequestAsync<TPermission>() where TPermission : Permissions.BasePermission, new()
	{
		PermissionStatus result = PermissionStatus.Unknown;
		TPermission permission = new TPermission();
		if (!MainThread.IsMainThread)
		{
			await MainThread.InvokeOnMainThreadAsync(async () => result = await permission.RequestAsync());
		}
		else
		{
			result = await permission.RequestAsync();
		}
		return result;
	}

	public static async Task<bool> ShouldShowRationale<TPermission>() where TPermission : Permissions.BasePermission, new()
	{
		bool result = false;
		TPermission permission = new TPermission();
		if (!MainThread.IsMainThread)
		{
			await MainThread.InvokeOnMainThreadAsync(() => result = permission.ShouldShowRationale());
		}
		else
		{
			result = permission.ShouldShowRationale();
		}
		return result;
	}
}
