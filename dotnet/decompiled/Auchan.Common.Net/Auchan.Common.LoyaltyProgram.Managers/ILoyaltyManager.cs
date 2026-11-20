using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgramLoymax;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Managers;

public interface ILoyaltyManager
{
	bool IsEPointsEnabled { get; }

	string ConnectionErrorText { get; }

	string ConnectionErrorImage { get; }

	bool IsTransferEnabled { get; }

	bool IsPointsTransferEnabled { get; }

	bool IsConnectionLost { get; }

	bool IsPointsTransferToUserEnabled { get; }

	bool IsPointsTransferToAuchanFundEnabled { get; }

	string PointsTransferDisabledMessage { get; }

	string PointsTransferToUserDisabledMessage { get; }

	string PointsTransferToAuchanFundDisabledMessage { get; }

	Task UpdateSocialStatus(bool updateProfile = true);

	IEnumerable<HintEntity> ProduceHintsList();

	Task<Result<(IEnumerable<DelayedPointsEntryEntity>, int), DomainError>> GetDelayedPoints(LoyaltyCurrencyDto[] currencies, int offset, int limit, int timeout = 15);

	Task<Result<LoyaltyCardEntity, DomainError>> GetBalanceAsync(int timeout = 15);

	Task<Result<LoyaltyProgramSocialStatusResponse, DomainError>> GetSocialStatusAsync(int timeout = 15);
}
