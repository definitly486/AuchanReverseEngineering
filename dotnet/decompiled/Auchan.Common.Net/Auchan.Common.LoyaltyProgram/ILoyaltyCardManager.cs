using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common.Binding;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram;

public interface ILoyaltyCardManager
{
	UICommand<string> CodeUpdatedCommand { get; }

	Task<Result<LoyaltyCardEntity, DomainError>> GetLoyaltyCard(CancellationToken token, bool forceUpdate = false, int timeout = 15);

	Task<Result<Unit, DomainError>> BlockCardAsync();

	Task<Result<Unit, DomainError>> BlockAndReissueCardAsync(string? cardNumber = null, string? cardCvc = null);

	Task<LoyaltyCardState> GetCardState();

	Task<bool> IsCardSilentRolloutNeeded();

	Task<Result<LoyaltyEnrollmentModel, DomainError>> EnrollVirtualCard(LoyaltyEnrollmentRequestDto.ChannelDto fromChannel);

	Task<Result<LoyaltyEnrollmentModel, DomainError>> EnrollPlasticCard(LoyaltyCardEntity card);

	Task<Result<LoyaltyEnrollmentModel, DomainError>> EnrollVirtualCard(ProfileModel profileModel, LoyaltyEnrollmentRequestDto.ChannelDto fromChannel);
}
