using System.Threading.Tasks;

namespace Auchan.Common.Common;

public interface ILogoutService
{
	Task LogoutAsync();

	void RequestForLogoutDueTokenFailure();
}
