using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;
using Android.App;
using Android.Content.PM;
using Splat;

namespace Akavache.Core;

[Preserve(AllMembers = true)]
[RequiresUnreferencedCode("Registrations for Akavache.Core")]
[RequiresDynamicCode("Registrations for Akavache.Core")]
public class Registrations : IWantsToRegisterStuff
{
	[ObsoletedOSPlatform("android33.0")]
	public void Register(IMutableDependencyResolver resolver, IReadonlyDependencyResolver readonlyDependencyResolver)
	{
		ArgumentNullException.ThrowIfNull(resolver, "resolver");
		IsolatedStorageProvider fs = new IsolatedStorageProvider();
		resolver.Register(() => fs, typeof(IFilesystemProvider));
		EncryptionProvider enc = new EncryptionProvider();
		resolver.Register(() => enc, typeof(IEncryptionProvider));
		Lazy<IBlobCache> localCache = new Lazy<IBlobCache>(() => new InMemoryBlobCache());
		Lazy<IBlobCache> userAccount = new Lazy<IBlobCache>(() => new InMemoryBlobCache());
		Lazy<ISecureBlobCache> secure = new Lazy<ISecureBlobCache>(() => new InMemoryBlobCache());
		resolver.Register(() => localCache.Value, typeof(IBlobCache), "LocalMachine");
		resolver.Register(() => userAccount.Value, typeof(IBlobCache), "UserAccount");
		resolver.Register(() => secure.Value, typeof(ISecureBlobCache));
		resolver.Register(() => new AkavacheHttpMixin(), typeof(IAkavacheHttpMixin));
		resolver.Register(() => new DefaultAkavacheHttpClientFactory(), typeof(IAkavacheHttpClientFactory));
		PackageManager packageManager = Application.Context.PackageManager;
		string packageName = Application.Context.PackageName ?? "Unknown Package";
		BlobCache.ApplicationName = packageManager?.GetApplicationInfo(packageName, (PackageInfoFlags)0)?.LoadLabel(packageManager) ?? "Unknown";
		resolver.Register(() => new AndroidFilesystemProvider(), typeof(IFilesystemProvider));
	}
}
