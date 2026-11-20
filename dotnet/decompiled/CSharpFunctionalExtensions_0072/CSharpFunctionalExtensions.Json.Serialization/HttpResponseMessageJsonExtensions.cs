using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Json.Serialization;

public static class HttpResponseMessageJsonExtensions
{
	public static async Task<Result> ReadResultAsync(this HttpResponseMessage response, bool ensureSuccessStatusCode = true, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (response == null)
		{
			return Result.Failure(DtoMessages.HttpResponseMessageIsNull);
		}
		if (ensureSuccessStatusCode && !response.IsSuccessStatusCode)
		{
			HttpStatusCode statusCode = response.StatusCode;
			return Result.Failure(DtoMessages.NotSuccessStatusCodeFormat(statusCode, await response.Content.ReadAsStringAsync()));
		}
		return await Result.Try(() => response.Content.ReadFromJsonAsync<Result>(CSharpFunctionalExtensionsJsonSerializerOptions.Options, cancellationToken), (Exception ex) => DtoMessages.ContentJsonNotResult).Bind((Result result) => result);
	}

	public static async Task<Result<T>> ReadResultAsync<T>(this HttpResponseMessage response, bool ensureSuccessStatusCode = true, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (response == null)
		{
			return Result.Failure<T>(DtoMessages.HttpResponseMessageIsNull);
		}
		if (ensureSuccessStatusCode && !response.IsSuccessStatusCode)
		{
			HttpStatusCode statusCode = response.StatusCode;
			return Result.Failure<T>(DtoMessages.NotSuccessStatusCodeFormat(statusCode, await response.Content.ReadAsStringAsync()));
		}
		return await Result.Try(() => response.Content.ReadFromJsonAsync<Result<T>>(CSharpFunctionalExtensionsJsonSerializerOptions.Options, cancellationToken), (Exception ex) => DtoMessages.ContentJsonNotResult).Bind((Result<T> result) => result);
	}

	public static async Task<Result<T, E>> ReadResultAsync<T, E>(this HttpResponseMessage response, bool ensureSuccessStatusCode = true, CancellationToken cancellationToken = default(CancellationToken)) where E : new()
	{
		if (response == null || (ensureSuccessStatusCode && !response.IsSuccessStatusCode))
		{
			return Result.Failure<T, E>(new E());
		}
		try
		{
			return await response.Content.ReadFromJsonAsync<Result<T, E>>(CSharpFunctionalExtensionsJsonSerializerOptions.Options, cancellationToken);
		}
		catch (JsonException)
		{
			return Result.Failure<T, E>(new E());
		}
	}

	public static async Task<UnitResult<E>> ReadUnitResultAsync<E>(this HttpResponseMessage? response, bool ensureSuccessStatusCode = true, CancellationToken cancellationToken = default(CancellationToken)) where E : new()
	{
		if (response == null || (ensureSuccessStatusCode && !response.IsSuccessStatusCode))
		{
			return UnitResult.Failure<E>(new E());
		}
		try
		{
			return await response.Content.ReadFromJsonAsync<UnitResult<E>>(CSharpFunctionalExtensionsJsonSerializerOptions.Options, cancellationToken);
		}
		catch (JsonException)
		{
			return UnitResult.Failure<E>(new E());
		}
	}
}
