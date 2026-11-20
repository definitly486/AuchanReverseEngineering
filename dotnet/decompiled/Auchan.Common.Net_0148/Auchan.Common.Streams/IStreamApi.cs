using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Auchan.Common.Streams;

public interface IStreamApi
{
	[Get("/v3/streams")]
	Task<StreamsDtos.StreamBlockDto> GetStreams([AliasAs("applicationId")] string applicationId, CancellationToken cancellationToken = default(CancellationToken));
}
