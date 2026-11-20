using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Addresses;

public sealed class LocationProvider : ILocationProvider, IApplicationStateObserver
{
	private TaskCompletionSource<PermissionStatus> _permissionTcs = new TaskCompletionSource<PermissionStatus>();

	private int _pendingPermissionRequests;

	private readonly IDeviceService _deviceService;

	public LocationProvider(IDeviceService deviceService)
	{
		_deviceService = deviceService;
	}

	public async Task<Result<Location, DomainError>> GetLocation(bool askPermission = true, GeolocationAccuracy geolocationAccuracy = GeolocationAccuracy.High, TimeSpan? timeout = null)
	{
		if (!(await _deviceService.IsLocationEnabled()))
		{
			return new ServiceDisabledError();
		}
		if (await GetPermissionAsync(askPermission) != PermissionStatus.Granted)
		{
			return Result.Failure<Location, DomainError>(new NoPermissionError());
		}
		try
		{
			Location location = await Task.Run(() => Geolocation.GetLocationAsync(new GeolocationRequest
			{
				DesiredAccuracy = geolocationAccuracy,
				Timeout = (timeout ?? TimeSpan.FromSeconds(30L))
			}));
			if (location != null)
			{
				return location;
			}
			DevAnalytics.Report("Can not define location: null result");
			return Result.Failure<Location, DomainError>(new UnknownError());
		}
		catch (Exception ex)
		{
			DevAnalytics.Report("Can not define location", ex);
			return Result.Failure<Location, DomainError>(new UnknownError());
		}
	}

	public async Task<PermissionStatus> GetPermissionAsync(bool askPermission)
	{
		_ = 2;
		try
		{
			YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
			_ = awaiter.IsCompleted;
			await awaiter;
			YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
			awaiter = yieldAwaiter;
			awaiter.GetResult();
			PermissionStatus permissionStatus = await MainThread.InvokeOnMainThreadAsync(() => Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>());
			if (permissionStatus == PermissionStatus.Granted || permissionStatus == PermissionStatus.Disabled || !askPermission)
			{
				return permissionStatus;
			}
			MainThread.BeginInvokeOnMainThread(delegate
			{
				PrivateRequestPermission();
			});
			return await _permissionTcs.Task;
		}
		catch (Exception ex)
		{
			DevAnalytics.Report("Can not request location permission", ex);
			return PermissionStatus.Unknown;
		}
	}

	private void PrivateRequestPermission()
	{
		MainThread.BeginInvokeOnMainThread(async delegate
		{
			try
			{
				Interlocked.Increment(ref _pendingPermissionRequests);
				PermissionStatus result = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
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

	public void OpenSystemLocationSettings()
	{
		_deviceService.OpenSystemLocationSettings();
	}

	async Task IApplicationStateObserver.DidBecomeActiveAsync()
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		if (_pendingPermissionRequests > 0 && 0 == 0)
		{
		}
	}
}
