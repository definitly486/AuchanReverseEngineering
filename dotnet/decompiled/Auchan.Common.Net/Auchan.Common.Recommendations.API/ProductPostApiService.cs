using System.Net.Http;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.Recommendations.API.Requests;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Recommendations.API;

public class ProductPostApiService : IProductPostApiService
{
	private const string API_KEY = "5ecce55697a525075c900196";

	private readonly IProductPostApi _api;

	private readonly IRequestExecutor _requestExecutor;

	public ProductPostApiService(IProductPostApi api, IRequestExecutor requestExecutor)
	{
		_api = api;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<Unit, DomainError>> ProductPost(ProductPostRequest request, string gimaId, CancellationToken token)
	{
		return (await (await _requestExecutor.Execute((CancellationToken ct) => _api.ProductPost(request, "5ecce55697a525075c900196", gimaId, ct), token)).EnsureAsync<HttpResponseMessage, ServiceError>((HttpResponseMessage responseMessage) => responseMessage.IsSuccessStatusCode, async delegate(HttpResponseMessage responseMessage)
		{
			string text = await responseMessage.GetContentAsyncSafe();
			return new UnknownServiceError
			{
				Message = (text ?? responseMessage.StatusCode.ToString())
			};
		})).Map((HttpResponseMessage r) => Unit.Default, (ServiceError error) => error.ToBaseDomainError());
	}
}
