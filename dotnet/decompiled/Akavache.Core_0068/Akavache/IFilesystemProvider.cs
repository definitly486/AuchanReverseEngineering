using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reactive;
using System.Reactive.Concurrency;

namespace Akavache;

public interface IFilesystemProvider
{
	IObservable<Stream> OpenFileForReadAsync(string path, IScheduler scheduler);

	IObservable<Stream> OpenFileForWriteAsync(string path, IScheduler scheduler);

	IObservable<Unit> CreateRecursive(string path);

	[RequiresUnreferencedCode("Registrations for Akavache.Core")]
	[RequiresDynamicCode("Registrations for Akavache.Core")]
	IObservable<Unit> Delete(string path);

	string? GetDefaultLocalMachineCacheDirectory();

	string? GetDefaultRoamingCacheDirectory();

	string? GetDefaultSecretCacheDirectory();
}
