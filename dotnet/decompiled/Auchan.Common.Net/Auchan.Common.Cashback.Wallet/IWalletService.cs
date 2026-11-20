using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cashback.Wallet.DTO;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Cashback.Wallet;

public interface IWalletService
{
	Task<Result<PassAndroidDTO, DomainError>> CashbackQrPassAndroid();

	Task<Result<PassiOSDTO, DomainError>> CashbackQrPassiOS();

	Task<Result<PassCheckAndroidDTO, DomainError>> LoyaltyQrPassCheckAndroid();

	Task<Result<PassAndroidDTO, DomainError>> LoyaltyQrPassAndroid();

	Task<Result<PassiOSDTO, DomainError>> LoyaltyQrPassiOS();
}
