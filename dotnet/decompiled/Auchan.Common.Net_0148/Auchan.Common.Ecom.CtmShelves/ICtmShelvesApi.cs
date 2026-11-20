using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Ecom.CtmShelves.DTO;
using Refit;

namespace Auchan.Common.Ecom.CtmShelves;

internal interface ICtmShelvesApi
{
	[Post("/shelves")]
	Task<ShelfResponseDto> GetShelves([Body] ShelfRequestDto body, CancellationToken cancellationToken);
}
