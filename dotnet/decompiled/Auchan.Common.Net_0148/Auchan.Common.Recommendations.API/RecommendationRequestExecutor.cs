using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.Networking;
using Auchan.Common.Recommendations.Models;
using CSharpFunctionalExtensions;
using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API;

internal sealed class RecommendationRequestExecutor : IRecommendationRequestExecutor
{
	private readonly ILogService _logService;

	private readonly IPolicyProvider _policyProvider;

	public RecommendationRequestExecutor(ILogService logService, IPolicyProvider policyProvider)
	{
		_logService = logService;
		_policyProvider = policyProvider;
	}

	public Task<Result<RecommendationList, DomainError>> Execute(int timeoutInSeconds, string blockId, RecomendationAnalyticActionsTag actionsTag, IRecommendationRequestExecutor.ReadResponseDelegate readResponseDelegate, Func<CancellationToken, Task<HttpResponseMessage>> requestFactory, CancellationToken token)
	{
		return Task.Run(async delegate
		{
			Result<HttpResponseMessage, ServiceError> result = await _policyProvider.DefaultPolicy<HttpResponseMessage>(timeoutInSeconds).ExecuteAsync((CancellationToken ct) => requestFactory(ct).CatchErrors(), token);
			if (result.TryGetValue(out var value))
			{
				using (value)
				{
					return await ExtractFromResponse(value, blockId, actionsTag, readResponseDelegate, token);
				}
			}
			return Result.Failure<RecommendationList, DomainError>(result.Error.ToBaseDomainError());
		});
	}

	private async Task<Result<RecommendationList, DomainError>> ExtractFromResponse(HttpResponseMessage response, string blockId, RecomendationAnalyticActionsTag actionsTag, IRecommendationRequestExecutor.ReadResponseDelegate readResponseDelegate, CancellationToken cancellationToken)
	{
		if (!response.IsSuccessStatusCode)
		{
			HttpStatusCode code = response.StatusCode;
			string text = await response.GetContentAsyncSafe(cancellationToken);
			return new UnknownError
			{
				Message = (string.IsNullOrWhiteSpace(text) ? code.ToString() : text)
			};
		}
		try
		{
			using StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync(cancellationToken));
			using JsonTextReader jsonTextReader = new JsonTextReader(reader);
			IReadOnlyList<RecommendationList.Item> readOnlyList = readResponseDelegate(jsonTextReader, blockId, actionsTag);
			if (readOnlyList == null)
			{
				return new NoDataError
				{
					Message = "No recommendations available"
				};
			}
			RecommendationList recommendationList = new RecommendationList
			{
				Items = readOnlyList
			};
			TimeSpan timeSpan = response.Headers.CacheControl?.MaxAge ?? TimeSpan.Zero;
			if (timeSpan > TimeSpan.Zero)
			{
				recommendationList.CacheTime = timeSpan;
			}
			return recommendationList;
		}
		catch (Exception ex)
		{
			string value = response.RequestMessage?.RequestUri?.ToString() ?? "";
			_logService.LogError("RecommendationApiService", $"Ошибка чтения запроса {value}: {ex}", LogType.ApiRequest, SystemType.RocketRetail);
			DevAnalytics.Report("Failed to extract recommendations", ex, new Dictionary<string, string> { { "url", value } });
			return new UnknownError
			{
				Message = ex.ToString()
			};
		}
	}
}
