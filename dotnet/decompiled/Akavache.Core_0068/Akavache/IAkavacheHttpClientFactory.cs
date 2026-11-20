using System.Net.Http;

namespace Akavache;

public interface IAkavacheHttpClientFactory
{
	HttpClient CreateClient(string name);
}
