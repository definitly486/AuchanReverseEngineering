using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http.Json;

public static class HttpContentJsonExtensions
{
	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext.")]
	public static Task<T?> ReadFromJsonAsync<T>(this HttpContent content, JsonSerializerOptions? options, CancellationToken cancellationToken = default(CancellationToken))
	{
		ArgumentNullException.ThrowIfNull(content, "content");
		return ReadFromJsonAsyncCore<T>(content, options, cancellationToken);
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext.")]
	private static async Task<T> ReadFromJsonAsyncCore<T>(HttpContent content, JsonSerializerOptions options, CancellationToken cancellationToken)
	{
		using Stream contentStream = await GetContentStreamAsync(content, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		return await JsonSerializer.DeserializeAsync<T>(contentStream, options ?? JsonSerializerOptions.Web, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	internal static ValueTask<Stream> GetContentStreamAsync(HttpContent content, CancellationToken cancellationToken)
	{
		Task<Stream> task = ReadHttpContentStreamAsync(content, cancellationToken);
		Encoding encoding = JsonHelpers.GetEncoding(content);
		if (encoding == null || encoding == Encoding.UTF8)
		{
			return new ValueTask<Stream>(task);
		}
		return GetTranscodingStreamAsync(task, encoding);
	}

	private static async ValueTask<Stream> GetTranscodingStreamAsync(Task<Stream> task, Encoding sourceEncoding)
	{
		return GetTranscodingStream(await task.ConfigureAwait(continueOnCapturedContext: false), sourceEncoding);
	}

	private static Task<Stream> ReadHttpContentStreamAsync(HttpContent content, CancellationToken cancellationToken)
	{
		return content.ReadAsStreamAsync(cancellationToken);
	}

	private static Stream GetTranscodingStream(Stream contentStream, Encoding sourceEncoding)
	{
		return Encoding.CreateTranscodingStream(contentStream, sourceEncoding, Encoding.UTF8);
	}
}
