using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reactive.Linq;
using Akavache.Core;
using Splat;

namespace Akavache.Sqlite3;

[Preserve(AllMembers = true)]
[RequiresUnreferencedCode("Registrations for Akavache.Sqlite3")]
[RequiresDynamicCode("Registrations for Akavache.Sqlite3")]
public class Registrations : IWantsToRegisterStuff
{
	public static void Start(string applicationName, Action initSql)
	{
		BlobCache.ApplicationName = applicationName;
		initSql?.Invoke();
	}

	public void Register(IMutableDependencyResolver resolver, IReadonlyDependencyResolver readonlyDependencyResolver)
	{
		if (resolver == null)
		{
			throw new ArgumentNullException("resolver");
		}
		IFilesystemProvider fs = Locator.Current.GetService<IFilesystemProvider>() ?? throw new InvalidOperationException("Failed to initialize Akavache properly. Do you have a reference to Akavache.dll?");
		Lazy<IBlobCache> localCache = new Lazy<IBlobCache>(delegate
		{
			string defaultLocalMachineCacheDirectory = fs.GetDefaultLocalMachineCacheDirectory();
			if (defaultLocalMachineCacheDirectory == null || string.IsNullOrWhiteSpace(defaultLocalMachineCacheDirectory))
			{
				throw new InvalidOperationException("There is a invalid directory being returned by the file system provider.");
			}
			fs.CreateRecursive(defaultLocalMachineCacheDirectory).SubscribeOn(BlobCache.TaskpoolScheduler).Wait();
			return new SqlRawPersistentBlobCache(Path.Combine(defaultLocalMachineCacheDirectory, "blobs.db"), BlobCache.TaskpoolScheduler);
		});
		resolver.Register(() => localCache.Value, typeof(IBlobCache), "LocalMachine");
		Lazy<IBlobCache> userAccount = new Lazy<IBlobCache>(delegate
		{
			string defaultRoamingCacheDirectory = fs.GetDefaultRoamingCacheDirectory();
			if (defaultRoamingCacheDirectory == null || string.IsNullOrWhiteSpace(defaultRoamingCacheDirectory))
			{
				throw new InvalidOperationException("There is a invalid directory being returned by the file system provider.");
			}
			fs.CreateRecursive(defaultRoamingCacheDirectory).SubscribeOn(BlobCache.TaskpoolScheduler).Wait();
			return new SqlRawPersistentBlobCache(Path.Combine(defaultRoamingCacheDirectory, "userblobs.db"), BlobCache.TaskpoolScheduler);
		});
		resolver.Register(() => userAccount.Value, typeof(IBlobCache), "UserAccount");
		Lazy<ISecureBlobCache> secure = new Lazy<ISecureBlobCache>(delegate
		{
			string defaultSecretCacheDirectory = fs.GetDefaultSecretCacheDirectory();
			if (defaultSecretCacheDirectory == null || string.IsNullOrWhiteSpace(defaultSecretCacheDirectory))
			{
				throw new InvalidOperationException("There is a invalid directory being returned by the file system provider.");
			}
			fs.CreateRecursive(defaultSecretCacheDirectory).SubscribeOn(BlobCache.TaskpoolScheduler).Wait();
			return new SQLiteEncryptedBlobCache(Path.Combine(defaultSecretCacheDirectory, "secret.db"), Locator.Current.GetService<IEncryptionProvider>(), BlobCache.TaskpoolScheduler);
		});
		resolver.Register(() => secure.Value, typeof(ISecureBlobCache));
	}
}
