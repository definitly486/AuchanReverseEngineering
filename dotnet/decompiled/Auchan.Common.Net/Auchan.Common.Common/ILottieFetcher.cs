using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Auchan.Common.Common;

public interface ILottieFetcher
{
	Task<Stream?> FetchStreamAsync(string url, CancellationToken cancellationToken = default(CancellationToken));

	Task RemoveFromCache(string url);
}
