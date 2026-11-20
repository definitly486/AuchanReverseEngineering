using System.Threading.Tasks;
using AndroidX.Fragment.App;
using Auchan.Common.Deeplinks;

namespace Auchan.Android.Deeplinks;

public interface IDeeplinkManager
{
	Task ResolveDeeplink(Fragment fragment, Deeplink deeplink);
}
