using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using Splat;

namespace Akavache;

[RequiresUnreferencedCode("Registrations for Akavache.Core")]
[RequiresDynamicCode("Registrations for Akavache.Core")]
public class SimpleFilesystemProvider : IFilesystemProvider
{
	public IObservable<Stream> OpenFileForReadAsync(string path, IScheduler scheduler)
	{
		return Utility.SafeOpenFileAsync(path, FileMode.Open, FileAccess.Read, FileShare.Read, scheduler);
	}

	public IObservable<Stream> OpenFileForWriteAsync(string path, IScheduler scheduler)
	{
		return Utility.SafeOpenFileAsync(path, FileMode.Create, FileAccess.Write, FileShare.None, scheduler);
	}

	public IObservable<Unit> CreateRecursive(string path)
	{
		new DirectoryInfo(path).CreateRecursive();
		return Observable.Return(Unit.Default);
	}

	public IObservable<Unit> Delete(string path)
	{
		return Observable.Start(delegate
		{
			File.Delete(path);
		}, BlobCache.TaskpoolScheduler);
	}

	public string GetDefaultRoamingCacheDirectory()
	{
		if (!ModeDetector.InUnitTestRunner())
		{
			return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), BlobCache.ApplicationName, "BlobCache");
		}
		return Path.Combine(GetAssemblyDirectoryName(), "BlobCache");
	}

	public string GetDefaultSecretCacheDirectory()
	{
		if (!ModeDetector.InUnitTestRunner())
		{
			return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), BlobCache.ApplicationName, "SecretCache");
		}
		return Path.Combine(GetAssemblyDirectoryName(), "SecretCache");
	}

	public string GetDefaultLocalMachineCacheDirectory()
	{
		if (!ModeDetector.InUnitTestRunner())
		{
			return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), BlobCache.ApplicationName, "BlobCache");
		}
		return Path.Combine(GetAssemblyDirectoryName(), "LocalBlobCache");
	}

	protected static string GetAssemblyDirectoryName()
	{
		return Path.GetDirectoryName(AppContext.BaseDirectory) ?? throw new InvalidOperationException("The directory name of the assembly location is null");
	}
}
