using System.Threading.Tasks;

namespace Auchan.Common.Deeplinks;

public interface IBaseDeeplinkManager
{
	Task ResolveDeeplink(Deeplink deeplink);
}
