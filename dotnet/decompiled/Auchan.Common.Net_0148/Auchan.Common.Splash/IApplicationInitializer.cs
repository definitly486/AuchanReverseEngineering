using System.Threading.Tasks;

namespace Auchan.Common.Splash;

public interface IApplicationInitializer
{
	Task<AppInitializationResult> Initialize();
}
