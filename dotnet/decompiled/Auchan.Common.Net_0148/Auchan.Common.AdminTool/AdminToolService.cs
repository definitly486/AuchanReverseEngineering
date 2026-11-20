using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.AdminTool.DTO;
using Auchan.Common.AdminTool.Mappers;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.AdminTool;

public class AdminToolService : IAdminToolService
{
	private readonly Lazy<IAdminToolApi> _adminToolApi;

	private readonly Lazy<IStampsApi> _stampsApi;

	private readonly Lazy<IAdminToolAuthorizer> _authorizer;

	private readonly Lazy<IDeviceService> _deviceService;

	private readonly Lazy<IRequestExecutor> _requestExecutor;

	private readonly Lazy<IUserContext> _userContext;

	public AdminToolService(Lazy<IUserContext> userContext, Lazy<IAdminToolApi> adminToolApi, Lazy<IStampsApi> stampsApi, Lazy<IAdminToolAuthorizer> authorizer, Lazy<IDeviceService> deviceService, Lazy<IRequestExecutor> requestExecutor)
	{
		_userContext = userContext;
		_adminToolApi = adminToolApi;
		_stampsApi = stampsApi;
		_authorizer = authorizer;
		_deviceService = deviceService;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<Initialization, DomainError>> Initialize(string deviceUdid, string regionFiasId, string storeId)
	{
		Result<InitializationDto, ServiceError> result = await _requestExecutor.Value.Execute((CancellationToken t) => _adminToolApi.Value.Initialize(deviceUdid, regionFiasId, storeId, _deviceService.Value.BuildNumberAndOSVersion, t));
		if (result.IsFailure)
		{
			return result.Error.ToUpdateRequiredError();
		}
		return result.Map(delegate(InitializationDto dto)
		{
			if (dto.AppConfigDto.Loyalty?.StepTwo != null)
			{
				dto.AppConfigDto.Loyalty.StepTwo.IsEnabled = false;
			}
			return dto.ToModel();
		}, (ServiceError err) => err.ToUpdateRequiredError());
	}

	public async Task<Result<AppConfig, DomainError>> AppConfig()
	{
		Result<string, ServiceError> tokenResult = await _authorizer.Value.UdidKey();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<AppConfig, DomainError>(tokenResult.Error.ToBaseDomainError());
		}
		Result<AppConfigDto, ServiceError> result = await _requestExecutor.Value.Execute((CancellationToken t) => _adminToolApi.Value.AppConfig(tokenResult.Value, _deviceService.Value.BuildNumberAndOSVersion, t));
		if (result.IsFailure)
		{
			return result.Error.ToUpdateRequiredError();
		}
		return result.Map(delegate(AppConfigDto dto)
		{
			if (dto.Loyalty?.StepTwo != null)
			{
				dto.Loyalty.StepTwo.IsEnabled = false;
			}
			return dto.ToModel();
		}, (ServiceError err) => err.ToUpdateRequiredError());
	}

	public async Task<StampsConfig?> StampsConfig()
	{
		Task<Result<SectionVisibleDto, ServiceError>> sectionVisibleTask = _requestExecutor.Value.Execute((CancellationToken t) => _stampsApi.Value.SectionVisible(t));
		Task<Result<InformersDto, ServiceError>> informersTask = _requestExecutor.Value.Execute((CancellationToken t) => _stampsApi.Value.GetInformers(t));
		await Task.WhenAll(sectionVisibleTask, informersTask);
		StampsConfig result = null;
		if (sectionVisibleTask.Result.IsSuccess && informersTask.Result.IsSuccess)
		{
			result = StampsConfigMapper.GetStampsConfig(sectionVisibleTask.Result.Value, informersTask.Result.Value, _userContext.Value.LoyaltyProgramSegments ?? new List<string>(), _userContext.Value.Profile?.IsAuchanEmployee == true);
		}
		return result;
	}
}
