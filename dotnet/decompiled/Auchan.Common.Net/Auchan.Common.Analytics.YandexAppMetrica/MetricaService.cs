using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Analytics.YandexAppMetrica;

public class MetricaService : IMetricaService
{
	private readonly IMetricaApi _api;

	private readonly IRequestExecutor _requestExecutor;

	public MetricaService(IMetricaApi api, IRequestExecutor requestExecutor)
	{
		_api = api;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<string, DomainError>> TrackEvent(string postApiKey, string csvContent)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.TrackEvent(postApiKey, postApiKey, csvContent))).Ensure((string p) => p != null, new ApiContractError()).Map((string dto) => dto, (ServiceError err) => err.ToBaseDomainError());
	}
}
