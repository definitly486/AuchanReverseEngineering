using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.LoyaltyProgram.Coupons.DTO;
using Refit;

namespace Auchan.Common.LoyaltyProgram.Coupons.Infrastructure;

public interface ICouponsApi
{
	[Get("/coupons/coupons")]
	Task<CouponsResponseDTO> Coupons([Header("X-Token-CMD")] string token80, CancellationToken token, [Header("channel")] string channel = "D");
}
