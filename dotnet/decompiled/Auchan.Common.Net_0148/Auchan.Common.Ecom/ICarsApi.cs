using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Ecom.DTO;
using Refit;

namespace Auchan.Common.Ecom;

public interface ICarsApi
{
	[Get("/lk/cars")]
	Task<CarsResponse> Cars([Header("X-Token-CMD")] string token80, CancellationToken cancellationToken = default(CancellationToken));

	[Put("/lk/cars")]
	Task<CarsResponse> UpdateCars([Header("X-Token-CMD")] string token80, [Body] SetCarsRequest request, CancellationToken cancellationToken = default(CancellationToken));
}
