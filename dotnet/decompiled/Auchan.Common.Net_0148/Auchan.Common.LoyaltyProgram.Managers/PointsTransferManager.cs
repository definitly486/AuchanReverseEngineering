using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Custom;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgram.Services;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Managers;

public class PointsTransferManager : IPointsTransferManager
{
	private readonly IPointsTransferService _pointsTransferService;

	public PointsTransferManager(IPointsTransferService pointsTransferService)
	{
		_pointsTransferService = pointsTransferService;
	}

	public async Task<Result<PointsTransferResponseDto, PointsTransactionError>> TransferPointsAsync(string? phone, int amount, string code)
	{
		Result<PointsTransferResponseDto, PointsTransactionError> result = await _pointsTransferService.TransferPointsAsync(phone, amount, code);
		if (result.IsFailure)
		{
			return Result.Failure<PointsTransferResponseDto, PointsTransactionError>(result.Error);
		}
		return result.Value;
	}
}
