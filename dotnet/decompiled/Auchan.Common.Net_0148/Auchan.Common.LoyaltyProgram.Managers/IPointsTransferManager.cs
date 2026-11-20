using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Custom;
using Auchan.Common.LoyaltyProgram.Dtos;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Managers;

public interface IPointsTransferManager
{
	Task<Result<PointsTransferResponseDto, PointsTransactionError>> TransferPointsAsync(string? phone, int amount, string code);
}
