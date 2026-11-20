using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Services;

public interface ILoyaltyCardService
{
	Task<Result<LoyaltyProgramQrCodeResponseDto, DomainError>> GetLoyaltyCode(CancellationToken token, int timeout);

	Task<Result<Unit, DomainError>> BlockCardAsync();

	Task<Result<Unit, DomainError>> BlockAndReissueCardAsync(string? cardNumber, string? cardCvvNamber);

	Task<Result<LoyaltyEnrollmentModel, DomainError>> EnrollVirtualCard(LoyaltyEnrollmentRequestDto.ChannelDto fromChannel);

	Task<Result<LoyaltyEnrollmentModel, DomainError>> EnrollVirtualCard(ProfileModel profileModel, LoyaltyEnrollmentRequestDto.ChannelDto fromChannel);

	Task<Result<LoyaltyEnrollmentModel, DomainError>> EnrollPlasticCard(LoyaltyCardEntity card);
}
