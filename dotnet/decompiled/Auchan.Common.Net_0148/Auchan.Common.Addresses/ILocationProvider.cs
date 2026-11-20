using System;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Addresses;

public interface ILocationProvider
{
	Task<Result<Location, DomainError>> GetLocation(bool askPermission = true, GeolocationAccuracy geolocationAccuracy = GeolocationAccuracy.High, TimeSpan? timeout = null);

	Task<PermissionStatus> GetPermissionAsync(bool askPermission);

	void OpenSystemLocationSettings();
}
