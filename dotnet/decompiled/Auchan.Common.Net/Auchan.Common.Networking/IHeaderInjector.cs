using System.Collections.Generic;

namespace Auchan.Common.Networking;

public interface IHeaderInjector
{
	bool Inject(string url, IDictionary<string, string> existingHeaders);
}
