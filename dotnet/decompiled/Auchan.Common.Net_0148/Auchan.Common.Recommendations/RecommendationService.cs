using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Logs;
using Auchan.Common.Recommendations.API;
using Auchan.Common.Recommendations.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Recommendations;

internal class RecommendationService : IRecommendationService
{
	private const string Tag = "RecommendationService";

	private readonly IRecommendationApiService _apiService;

	private readonly ILogService _logService;

	public RecommendationService(IRecommendationApiService apiService, ILogService logService)
	{
		_apiService = apiService;
		_logService = logService;
	}

	public async Task<Result<RecommendationList, DomainError>> Get(IAlgorithm algorithm)
	{
		Result<RecommendationList, DomainError> result = await algorithm.MapRequest(_apiService, CancellationToken.None);
		if (result.IsFailure)
		{
			DomainError error = result.Error;
			string message = error.Message;
			Log($"Ошибка при запросе рекомендаций - '{message}' ({error.GetType().Name})", isError: true);
			return result.Error;
		}
		return result.Value with
		{
			Items = result.Value.Items.DistinctBy((RecommendationList.Item r) => r.GimaId).ToImmutableList()
		};
	}

	private void Log(string message, bool isError = false)
	{
		_logService.Log("RecommendationService", message, isError ? LogLevel.Error : LogLevel.Info, LogType.ApiRequest, SystemType.RocketRetail);
	}
}
