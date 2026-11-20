using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.IsolatedStorage;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Akavache;

[RequiresUnreferencedCode("Registrations for Akavache.Core")]
[RequiresDynamicCode("Registrations for Akavache.Core")]
public class IsolatedStorageProvider : IFilesystemProvider
{
	public IObservable<Stream> OpenFileForReadAsync(string path, IScheduler scheduler)
	{
		return Observable.Create(delegate(IObserver<Stream> subj)
		{
			CompositeDisposable compositeDisposable = new CompositeDisposable();
			try
			{
				IsolatedStorageFile fs = IsolatedStorageFile.GetUserStoreForApplication();
				compositeDisposable.Add(fs);
				compositeDisposable.Add(Observable.Start(() => fs.OpenFile(path, FileMode.Open, FileAccess.Read, FileShare.Read), BlobCache.TaskpoolScheduler).Subscribe(subj));
			}
			catch (Exception error)
			{
				subj.OnError(error);
			}
			return compositeDisposable;
		});
	}

	public IObservable<Stream> OpenFileForWriteAsync(string path, IScheduler scheduler)
	{
		return Observable.Create(delegate(IObserver<Stream> subj)
		{
			CompositeDisposable compositeDisposable = new CompositeDisposable();
			try
			{
				IsolatedStorageFile fs = IsolatedStorageFile.GetUserStoreForApplication();
				compositeDisposable.Add(fs);
				compositeDisposable.Add(Observable.Start(() => fs.OpenFile(path, FileMode.Create, FileAccess.Write, FileShare.None), BlobCache.TaskpoolScheduler).Subscribe(subj));
			}
			catch (Exception error)
			{
				subj.OnError(error);
			}
			return compositeDisposable;
		});
	}

	public IObservable<Unit> CreateRecursive(string dirPath)
	{
		return Observable.Start(delegate
		{
			using IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();
			string path = string.Empty;
			string[] array = dirPath.Split(Path.DirectorySeparatorChar);
			foreach (string path2 in array)
			{
				string text = Path.Combine(path, path2);
				if (text[text.Length - 1] == Path.VolumeSeparatorChar)
				{
					text += Path.DirectorySeparatorChar;
				}
				if (!isolatedStorageFile.DirectoryExists(text))
				{
					isolatedStorageFile.CreateDirectory(text);
				}
				path = text;
			}
		}, BlobCache.TaskpoolScheduler);
	}

	public IObservable<Unit> Delete(string path)
	{
		return Observable.Start(delegate
		{
			using IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();
			if (!isolatedStorageFile.FileExists(path))
			{
				return;
			}
			try
			{
				isolatedStorageFile.DeleteFile(path);
			}
			catch (FileNotFoundException)
			{
			}
			catch (IsolatedStorageException)
			{
			}
		}, BlobCache.TaskpoolScheduler);
	}

	public string GetDefaultRoamingCacheDirectory()
	{
		return "BlobCache";
	}

	public string GetDefaultSecretCacheDirectory()
	{
		return "SecretCache";
	}

	public string GetDefaultLocalMachineCacheDirectory()
	{
		return "LocalBlobCache";
	}
}
