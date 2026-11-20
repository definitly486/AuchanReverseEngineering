using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Refit;

public interface IHttpContentSerializer
{
	HttpContent ToHttpContent<T>(T item);

	Task<T?> FromHttpContentAsync<T>(HttpContent content, CancellationToken cancellationToken = default(CancellationToken));

	string? GetFieldNameForProperty(PropertyInfo propertyInfo);
}
