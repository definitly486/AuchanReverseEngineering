using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgram.Dtos.Balance;
using Refit;

namespace Auchan.Common.LoyaltyProgram.Services;

public interface ILoyaltyProgramApi
{
	[Get("/balance?channel=M")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<LoyaltyProgramBalanceResponseDto> Balance([Header("access_token")] string token80, CancellationToken token);

	[Post("/card-blocking?channel=M")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<LoyaltyProgramBlockCardResponseDto> BlockCard([Header("access_token")] string token80, [Body] LoyaltyCardBlockDto request, CancellationToken token);

	[Post("/card-merge?channel=M")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<LoyaltyProgramBlockCardResponseDto> BlockAndReissueCard([Header("access_token")] string token80, [Header("identifierNo")] string? cardNumber, [Header("identifierSecretNo")] string? cardCvvNumber, CancellationToken token);

	[Get("/history?channel=M")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<IEnumerable<LoyaltyProgramPurchaseDto>> Purchases([Header("access_token")] string token80, CancellationToken token);

	[Get("/transaction-details/{transactionId}?channel=M")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<TransactionDetailsDto> TransactionDetails([Header("access_token")] string token80, string transactionId, CancellationToken token);

	[Post("/profile/enrollment?channel=M")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<LoyaltyEnrollmentDto> Enrollment([Header("access_token")] string token80, [Body] object request, CancellationToken token);

	[Get("/social-status?channel=M")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<LoyaltyProgramSocialStatusResponseDto> SocialStatus([Header("access_token")] string token80, CancellationToken token);
}
