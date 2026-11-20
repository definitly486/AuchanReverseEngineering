using System.Threading.Tasks;

namespace Auchan.Common.Cashback.Wallet;

public interface IWalletManager
{
	Task<bool> CanAddLoyaltyQr();

	Task<bool> AddLoyaltyQr();

	Task<bool> AddCashbackQr();
}
