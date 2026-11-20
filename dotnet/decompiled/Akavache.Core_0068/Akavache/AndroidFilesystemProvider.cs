using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reactive;
using System.Reactive.Concurrency;
using Android.App;

namespace Akavache;

[RequiresUnreferencedCode("Registrations for Akavache.Core")]
[RequiresDynamicCode("Registrations for Akavache.Core")]
public class AndroidFilesystemProvider : IFilesystemProvider
{
	private readonly SimpleFilesystemProvider _inner = new SimpleFilesystemProvider();

	public IObservable<Stream> OpenFileForReadAsync(string path, IScheduler scheduler)
	{
		return _inner.OpenFileForReadAsync(path, scheduler);
	}

	public IObservable<Stream> OpenFileForWriteAsync(string path, IScheduler scheduler)
	{
		return _inner.OpenFileForWriteAsync(path, scheduler);
	}

	public IObservable<Unit> CreateRecursive(string path)
	{
		return _inner.CreateRecursive(path);
	}

	public IObservable<Unit> Delete(string path)
	{
		return _inner.Delete(path);
	}

	public string? GetDefaultLocalMachineCacheDirectory()
	{
		return Application.Context.CacheDir?.AbsolutePath;
	}

	public string? GetDefaultRoamingCacheDirectory()
	{
		return Application.Context.FilesDir?.AbsolutePath;
	}

	public string? GetDefaultSecretCacheDirectory()
	{
		string text = Application.Context.FilesDir?.AbsolutePath;
		if (text == null)
		{
			return null;
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(text, "Secret"));
		if (!directoryInfo.Exists)
		{
			directoryInfo.CreateRecursive();
		}
		return directoryInfo.FullName;
	}
}
