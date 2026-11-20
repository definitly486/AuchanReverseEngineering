using System.Threading.Tasks;
using Auchan.Common.Ecom.Address.Models;

namespace Auchan.Common.Ecom.PriceChecker;

public interface IPriceCheckerContext
{
	Store? SavedStore { get; }

	long? RegionId { get; }

	void SaveStore(Store store);

	void ResetIfRegionChanged(long onlineRegionId);

	Task CleanDeinitialize();
}
