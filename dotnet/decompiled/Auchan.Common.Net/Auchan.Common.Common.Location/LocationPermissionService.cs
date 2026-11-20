using System;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Extensions;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Common.Location;

public sealed class LocationPermissionService : ILocationPermissionService, IApplicationStateObserver
{
	private TaskCompletionSource<PermissionStatus> _permissionTcs = new TaskCompletionSource<PermissionStatus>();

	private int _pendingPermissionRequests;

	public async Task<bool> IsForegroundPermissionGranted()
	{
		return await GetForegroundPermissionStatus() == PermissionStatus.Granted;
	}

	public Task<PermissionStatus> GetForegroundPermissionStatus()
	{
		return PermissionExtensions.CheckAsyncSafe<Permissions.LocationWhenInUse>();
	}

	public async Task<PermissionStatus> RequestForegroundPermission()
	{
		PermissionStatus permissionStatus = await GetForegroundPermissionStatus();
		if (permissionStatus == PermissionStatus.Granted)
		{
			return permissionStatus;
		}
		MainThread.BeginInvokeOnMainThread(PrivateRequestPermission);
		return await _permissionTcs.Task;
	}

	private void PrivateRequestPermission()
	{
		MainThread.BeginInvokeOnMainThread(async delegate
		{
			try
			{
				Interlocked.Increment(ref _pendingPermissionRequests);
				PermissionStatus result = await PermissionExtensions.RequestAsync<Permissions.LocationWhenInUse>();
				Interlocked.Exchange(ref _permissionTcs, new TaskCompletionSource<PermissionStatus>()).TrySetResult(result);
			}
			catch (Exception exception)
			{
				Interlocked.Exchange(ref _permissionTcs, new TaskCompletionSource<PermissionStatus>()).TrySetException(exception);
			}
			finally
			{
				Interlocked.Decrement(ref _pendingPermissionRequests);
			}
		});
	}

	void IApplicationStateObserver.OnResumed()
	{
		if (_pendingPermissionRequests > 0)
		{
			_ = 1;
			PrivateRequestPermission();
		}
	}
}
