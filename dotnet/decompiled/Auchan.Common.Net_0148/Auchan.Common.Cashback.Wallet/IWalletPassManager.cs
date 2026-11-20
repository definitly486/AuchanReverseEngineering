using System.IO;
using System.Threading.Tasks;

namespace Auchan.Common.Cashback.Wallet;

public interface IWalletPassManager
{
	bool AddToWalletAvaliable { get; }

	Task<bool> AddPassAndroid(string addPassUrl);

	Task<bool> LoyaltyQrPassCheckiOS();

	Task<bool> AddPassiOS(Stream passFileStream);
}
