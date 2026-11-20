using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auchan.Common.Networking;

public interface IBasicAuthorizationHeaderInjector
{
	Task Inject(HttpRequestMessage request, CancellationToken cancellationToken);
}
