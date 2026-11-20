using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Recommendations.API.Requests;
using Refit;

namespace Auchan.Common.Recommendations.API;

public interface IProductPostApi
{
	[Post("/{apiKey}/products/{gimaId}")]
	Task<HttpResponseMessage> ProductPost([Body] ProductPostRequest request, string apiKey, string gimaId, CancellationToken token = default(CancellationToken));
}
