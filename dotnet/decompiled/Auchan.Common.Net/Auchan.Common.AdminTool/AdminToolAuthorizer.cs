using System;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.AdminTool.DTO;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Common;
using Auchan.Common.Networking;
using CSharpFunctionalExtensions;
using Polly.Timeout;

namespace Auchan.Common.AdminTool;

public class AdminToolAuthorizer : IAdminToolAuthorizer
{
	private readonly Lazy<IAuthApi> _api;

	private readonly Lazy<IDeviceService> _deviceService;

	private readonly Lazy<IRequestExecutor> _requestExecutor;

	private string? _cachedUdidKey;

	public AdminToolAuthorizer(Lazy<IAuthApi> api, IEnvironmentManager environmentManager, Lazy<IDeviceService> deviceService, Lazy<IRequestExecutor> requestExecutor)
	{
		_api = api;
		_deviceService = deviceService;
		_requestExecutor = requestExecutor;
		environmentManager.EnvironmentChangedWeak += delegate
		{
			_cachedUdidKey = null;
		};
	}

	public void InitializeUdidKeyAtAppStart(string udidKey)
	{
		_cachedUdidKey = udidKey;
	}

	public async Task<Result<string, ServiceError>> UdidKey(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (_cachedUdidKey != null)
		{
			return Result.Success<string, ServiceError>(_cachedUdidKey);
		}
		return (await _requestExecutor.Value.Execute((CancellationToken ct) => _api.Value.Udid(_deviceService.Value.Udid, ct), default(CancellationToken), TimeoutStrategy.Pessimistic)).Map((UdidDto dto) => _cachedUdidKey = dto.Key);
	}
}
