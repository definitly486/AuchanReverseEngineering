using System.Collections.Generic;

namespace Auchan.Common.Networking;

public interface IHeaderInjector2
{
	void Inject(string? url, IDictionary<string, string> headers);
}
