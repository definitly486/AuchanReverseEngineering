using System;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using Splat;

namespace Akavache.Sqlite3;

[RequiresUnreferencedCode("Registrations for Akavache.Core")]
[RequiresDynamicCode("Registrations for Akavache.Core")]
public class SQLiteEncryptedBlobCache : SqlRawPersistentBlobCache, ISecureBlobCache, IBlobCache, IDisposable
{
	private readonly IEncryptionProvider _encryption;

	public SQLiteEncryptedBlobCache(string databaseFile, IEncryptionProvider? encryptionProvider = null, IScheduler? scheduler = null)
		: base(databaseFile, scheduler)
	{
		_encryption = encryptionProvider ?? Locator.Current.GetService<IEncryptionProvider>() ?? throw new InvalidOperationException("No IEncryptionProvider available. This should never happen, your DependencyResolver is broken");
	}

	protected override IObservable<byte[]> BeforeWriteToDiskFilter(byte[] data, IScheduler scheduler)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		if (data.Length == 0)
		{
			return Observable.Return(data);
		}
		return _encryption.EncryptBlock(data);
	}

	protected override IObservable<byte[]> AfterReadFromDiskFilter(byte[] data, IScheduler scheduler)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		if (data.Length == 0)
		{
			return Observable.Return(data);
		}
		return _encryption.DecryptBlock(data);
	}
}
