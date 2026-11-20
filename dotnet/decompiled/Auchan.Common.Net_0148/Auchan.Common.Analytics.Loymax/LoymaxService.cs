using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Analytics.Loymax.DTO;
using Auchan.Common.Analytics.Loymax.Models;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Analytics.Loymax;

public class LoymaxService
{
	private readonly ILoymaxApi _loymaxApi;

	private readonly ILoymaxLoyaltyApi _loymaxLoyaltyApi;

	private readonly IRequestExecutor _requestExecutor;

	public LoymaxService(ILoymaxApi loymaxApi, IRequestExecutor requestExecutor, ILoymaxLoyaltyApi loymaxLoyaltyApi)
	{
		_loymaxApi = loymaxApi;
		_requestExecutor = requestExecutor;
		_loymaxLoyaltyApi = loymaxLoyaltyApi;
	}

	public async Task<Result<Unit, DomainError>> Pushes(object requestObject)
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel token80) => _loymaxLoyaltyApi.Pushes(token80, requestObject, cancellationToken))).Map((object dto) => Unit.Default, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<LoymaxResponseDto, DomainError>> CommunicationPushes(string pushId, string type, string device, bool isDeleted, CancellationToken cancellationToken = default(CancellationToken))
	{
		LoymaxPushesRequestDto request = new LoymaxPushesRequestDto
		{
			PushId = pushId,
			Type = type,
			Device = device,
			IsDeleted = isDeleted
		};
		return (await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel t80) => _loymaxApi.CommunicationPushes(t80, request, ct))).Map((LoymaxResponseDto dto) => dto, (ServiceError err) => err.ToBaseDomainError()).Ensure((LoymaxResponseDto dto) => dto.Errors.Count == 0, (LoymaxResponseDto dto) => new LoymaxError(dto));
	}

	public async Task<Result<LoymaxResponseDto, DomainError>> CommunicationEvents(IEnumerable<Event> events, CancellationToken cancellationToken = default(CancellationToken))
	{
		LoymaxEventsRequestDto request = new LoymaxEventsRequestDto
		{
			Events = events.Select((Event e) => new LoymaxEventsRequestDto.EventDto
			{
				Type = e.Type,
				MessageId = e.MessageId
			}).ToImmutableList()
		};
		return (await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel t80) => _loymaxApi.CommunicationEvents(t80, request, ct), TokenLevel.L80, cancellationToken)).Map((LoymaxResponseDto dto) => dto, (ServiceError err) => err.ToBaseDomainError()).Ensure((LoymaxResponseDto dto) => dto != null && dto.Errors.Count == 0, (LoymaxResponseDto dto) => new LoymaxError(dto));
	}
}
