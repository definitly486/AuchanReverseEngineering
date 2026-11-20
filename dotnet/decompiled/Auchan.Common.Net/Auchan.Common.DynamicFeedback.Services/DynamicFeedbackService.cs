using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Disposables;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.DynamicFeedback.Dto;
using Auchan.Common.DynamicFeedback.Responses;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Storage;
using Refit;

namespace Auchan.Common.DynamicFeedback.Services;

public class DynamicFeedbackService
{
	private readonly IDynamicFeedbackApi _api;

	private readonly IRequestExecutor _requestExecutor;

	public DynamicFeedbackService(IDynamicFeedbackApi api, IRequestExecutor requestExecutor)
	{
		_api = api;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<FeedbackCategoriesResponse, DomainError>> GetCategories()
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.GetCategories(t))).Map((FeedbackCategoriesResponse x) => x, (ServiceError error) => error.ToBaseDomainError());
	}

	public async Task<Result<FeedbackChannelsResponse, DomainError>> GetChannels()
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.GetChannels(t))).Map((FeedbackChannelsResponse x) => x, (ServiceError x) => x.ToBaseDomainError());
	}

	public async Task<Result<FeedbackCitiesResponse, DomainError>> GetCities()
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.GetCities(t))).Map((FeedbackCitiesResponse x) => x, (ServiceError x) => x.ToBaseDomainError());
	}

	public async Task<Result<FeedbackFieldsResponse, DomainError>> GetFields(string serviceCrmId)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.GetFields(serviceCrmId, t))).Map((FeedbackFieldsResponse x) => x, (ServiceError x) => x.ToBaseDomainError());
	}

	public async Task<Result<IsFeedbackActiveDto, DomainError>> IsFeedbackActive()
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.IsFeedbackActive(t))).Ensure((IsFeedbackActiveDto x) => x.IsActive, new UnknownServiceError()).Map((IsFeedbackActiveDto x) => x, (ServiceError x) => x.ToBaseDomainError());
	}

	public async Task<Result<FeedbackRespondResponse, DomainError>> Respond(object body)
	{
		return (await _requestExecutor.ExecuteWithCustomTimeout((CancellationToken t) => _api.Respond(body, t), 40)).Map((FeedbackRespondResponse x) => x, (ServiceError x) => x.ToBaseDomainError());
	}

	public async Task<Result<List<FeedbackUploadFilesResponse>, DomainError>> UploadFiles(List<FileResult> files)
	{
		var x = files.Select((FileResult i) => new
		{
			Name = Path.GetFileName(i.FileName),
			Stream = i.OpenReadAsync()
		});
		using (new CompositeDisposable(await Task.WhenAll(x.Select(i => i.Stream))))
		{
			IEnumerable<StreamPart> streamParts = x.Select(i => new StreamPart(i.Stream.Result, i.Name, "application/x-binary"));
			return (await _requestExecutor.Execute((CancellationToken t) => _api.UploadFiles(streamParts, t))).Map((List<FeedbackUploadFilesResponse> result) => result, (ServiceError serviceError) => serviceError.ToBaseDomainError());
		}
	}
}
