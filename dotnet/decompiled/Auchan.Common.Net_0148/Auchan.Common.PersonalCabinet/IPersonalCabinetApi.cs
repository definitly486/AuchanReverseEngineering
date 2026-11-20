using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.PersonalCabinet.DTO;
using Refit;

namespace Auchan.Common.PersonalCabinet;

public interface IPersonalCabinetApi
{
	[Get("/clientauth/token")]
	Task<TokenDto> Token20([Header("password")] string password, [Header("login")] string login = "checkmail_user", CancellationToken cancellationToken = default(CancellationToken));

	[Get("/clientprofile/rgSessionId")]
	Task<string> NewYearGameToken([Header("access_token")] string token80, CancellationToken token);

	[Get("/clientauth/token")]
	Task<TokenDto> Token80([Header("phone")] string phone, [Header("password")] string pin, [Header("deviceid")] string deviceId, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/clientprofile/subscribes")]
	Task<SubscriptionsListDto> GetSubscriptions([Header("access_token")] string token80, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/clientprofile/checkphone")]
	[Headers(new string[] { "source: 1" })]
	Task<CheckPhoneDto> CheckPhone([Header("access_token")] string token20, [Header("phone")] string phone, [Header("deviceid")] string deviceid, [Query] bool needHash, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/clientprofile/checkAccount")]
	Task<BasePersonalCabinetResponseDto> CheckAccount([Header("access_token")] string token80, [Body] CheckAccountRequestDto dto, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/clientprofile/verifyphone")]
	Task<BasePersonalCabinetResponseDto> BeginVerifyPhone([Header("access_token")] string token80, [Header("phone")] string phone, [Query] bool needHash, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/clientprofile/verifyphone")]
	Task<BasePersonalCabinetResponseDto> VerifyPhone([Header("access_token")] string token80, [Header("phone")] string phone, [Header("pin")] string pin, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/clientauth/logout")]
	Task<LogoutResponseDto> Logout([Header("access_token")] string token80, [Header("forAll")] bool forAll, [Header("ostype")] string osType = "", [Header("mobiletype")] string mobileType = "", [Header("resolution")] string resolution = "");
}
