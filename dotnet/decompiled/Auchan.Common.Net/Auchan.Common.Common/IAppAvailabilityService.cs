using System.Collections.Generic;

namespace Auchan.Common.Common;

public interface IAppAvailabilityService
{
	static readonly IReadOnlyList<string> TPayDeeplinks = new global::_003C_003Ez__ReadOnlySingleElementList<string>("tinkoffbank://");

	bool MirPayAvailable => false;

	bool TPayAvailable => false;

	bool SberPayAvailable => false;
}
