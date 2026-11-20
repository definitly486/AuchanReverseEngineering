using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Streams;

public class StreamsService
{
	private readonly IStreamApi _api;

	private readonly IRequestExecutor _requestExecutor;

	public StreamsService(IStreamApi api, IRequestExecutor requestExecutor)
	{
		_api = api;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<StreamsDtos.StreamBlockDto, DomainError>> GetStreams(string applicationId)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.GetStreams(applicationId, t))).Map((StreamsDtos.StreamBlockDto x) => x, (ServiceError x) => x.ToBaseDomainError());
	}
}
