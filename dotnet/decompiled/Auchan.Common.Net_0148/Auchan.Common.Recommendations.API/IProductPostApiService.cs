using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Recommendations.API.Requests;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Recommendations.API;

public interface IProductPostApiService
{
	Task<Result<Unit, DomainError>> ProductPost(ProductPostRequest request, string gimaId, CancellationToken token);
}
