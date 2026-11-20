using System.Threading.Tasks;
using Auchan.Common.SafeEntrance.Enums;

namespace Auchan.Common.SafeEntrance.Managers;

public interface IBiometryManager
{
	BiometryTypes CanAuthenticate();

	Task<bool> AuthenticateAsync();

	void OpenBiometrySettings();
}
