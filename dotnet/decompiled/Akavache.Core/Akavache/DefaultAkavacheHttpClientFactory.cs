using System.Collections.Concurrent;
using System.Net.Http;

namespace Akavache;

public class DefaultAkavacheHttpClientFactory : IAkavacheHttpClientFactory
{
	private static readonly ConcurrentDictionary<string, HttpClient> _instances = new ConcurrentDictionary<string, HttpClient>();

	public HttpClient CreateClient(string name)
	{
		return _instances.GetOrAdd(name, (string _) => new HttpClient());
	}
}
