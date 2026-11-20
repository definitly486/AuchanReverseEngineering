using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Cashback.Wallet.DTO;
using Refit;

namespace Auchan.Common.Cashback.Wallet;

public interface IWalletApi
{
	[Get("/wallet_pass/cashback_android")]
	Task<PassAndroidDTO> CashbackQrPassAndroid([Header("access_token")] string token, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/wallet_pass/cashback_ios")]
	Task<HttpResponseMessage> CashbackQrPassiOS([Header("access_token")] string token, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/wallet_pass/loyalty_android_can_add")]
	Task<PassCheckAndroidDTO> LoyaltyQrPassCheckAndroid([Header("access_token")] string token, [Header("device_id")] string deviceId, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/wallet_pass/loyalty_android")]
	Task<PassAndroidDTO> LoyaltyQrPassAndroid([Header("access_token")] string token, [Header("device_id")] string deviceId, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/wallet_pass/loyalty_ios")]
	Task<HttpResponseMessage> LoyaltyQrPassiOS([Header("access_token")] string token, CancellationToken cancellationToken = default(CancellationToken));
}
