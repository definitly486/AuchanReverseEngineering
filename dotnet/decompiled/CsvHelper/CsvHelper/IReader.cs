using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CsvHelper;

public interface IReader : IReaderRow, IDisposable
{
	bool ReadHeader();

	bool Read();

	Task<bool> ReadAsync();

	IEnumerable<T> GetRecords<T>();

	IEnumerable<T> GetRecords<T>(T anonymousTypeDefinition);

	IEnumerable<object> GetRecords(Type type);

	IEnumerable<T> EnumerateRecords<T>(T record);

	IAsyncEnumerable<T> GetRecordsAsync<T>(CancellationToken cancellationToken = default(CancellationToken));

	IAsyncEnumerable<T> GetRecordsAsync<T>(T anonymousTypeDefinition, CancellationToken cancellationToken = default(CancellationToken));

	IAsyncEnumerable<object> GetRecordsAsync(Type type, CancellationToken cancellationToken = default(CancellationToken));

	IAsyncEnumerable<T> EnumerateRecordsAsync<T>(T record, CancellationToken cancellationToken = default(CancellationToken));
}
