using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgramLoymax.Dtos;
using Auchan.Common.PersonalCabinet.DTO;
using Refit;

namespace Auchan.Common.LoyaltyProgramLoymax;

public interface ILoymaxLoyaltyApi
{
	[Post("/loyalty/enrollment")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<LoyaltyEnrollmentDtos> LoyaltyEnrollment([Body] LoyaltyEnrollmentRequestDto body, [Header("X-Token-CMD")] string token80, CancellationToken token);

	[Get("/cmd/profile")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<ProfileResponseSnackCaseDto> GetProfile([Header("X-Token-CMD")] string token80, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/cmd/profile")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<ProfileResponseSnackCaseDto> UpdateProfile([Body] ProfileSnackCaseDto profileDto, [Header("X-Token-CMD")] string token80, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/loyalty/card-merge")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<LoymaxResponseBaseDto> LoyaltyCardMerge(object? requestBody, [Header("X-Token-CMD")] string token80, CancellationToken token);

	[Post("/loyalty/operations")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<LoyaltyOperationsResponseDto> LoyaltyPointsOperations(object? requestBody, [Header("X-Token-CMD")] string token80, CancellationToken token);

	[Get("/loyalty/balance")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<BalanceDto> Balance([Header("X-Token-CMD")] string token80, CancellationToken token);

	[Get("/loyalty/qr")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<LoyaltyProgramQrCodeResponseDto> GetQrCode([Header("X-Token-CMD")] string token80, CancellationToken token);

	[Get("/loyalty/social-status")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<SocialStatusDto> SocialStatus([Header("X-Token-CMD")] string token80, CancellationToken token);

	[Post("/loyalty/pushes")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<object> Pushes([Header("X-Token-CMD")] string token80, [Body] object requestBody, CancellationToken token);

	[Post("/lk/loyalty/history")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<LoymaxHistoryResponseDto> LoyaltyHistory([Body] object requestBody, [Header("X-Token-CMD")] string token80, CancellationToken token);

	[Post("/loyalty/transfer")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<PointsTransferResponseDto> TransferPoints([Header("X-Token-CMD")] string token80, [Body] object body, CancellationToken token);

	[Get("/loyalty/favorite-categories")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<FavoriteCategoriesDto> FavoriteCategories([Header("X-Token-CMD")] string token80, [Header("X-Source")] string source, CancellationToken token);

	[Post("/loyalty/favorite-categories:accept")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<FavoriteCategoriesDto> SendCategories([Header("X-Token-CMD")] string token80, [Header("X-Source")] string source, [Body] object body, CancellationToken cancellationToken);
}
