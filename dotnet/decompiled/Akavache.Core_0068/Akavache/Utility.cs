using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using Splat;

namespace Akavache;

[RequiresUnreferencedCode("Registrations for Akavache.Core")]
[RequiresDynamicCode("Registrations for Akavache.Core")]
internal static class Utility
{
	public static string GetMd5Hash(string input)
	{
		using MD5Managed mD5Managed = new MD5Managed();
		byte[] array = mD5Managed.ComputeHash(Encoding.UTF8.GetBytes(input));
		StringBuilder stringBuilder = new StringBuilder();
		byte[] array2 = array;
		foreach (byte b in array2)
		{
			stringBuilder.Append(b.ToString("x2", CultureInfo.InvariantCulture));
		}
		return stringBuilder.ToString();
	}

	public static IObservable<Stream> SafeOpenFileAsync(string path, FileMode mode, FileAccess access, FileShare share, IScheduler? scheduler = null)
	{
		if (scheduler == null)
		{
			scheduler = BlobCache.TaskpoolScheduler;
		}
		AsyncSubject<Stream> ret = new AsyncSubject<Stream>();
		Observable.Start(delegate
		{
			try
			{
				if (!new FileMode[3]
				{
					FileMode.Create,
					FileMode.CreateNew,
					FileMode.OpenOrCreate
				}.Contains(mode) && !File.Exists(path))
				{
					ret.OnError(new FileNotFoundException());
				}
				else
				{
					Observable.Start(() => new FileStream(path, mode, access, share, 4096, useAsync: false), scheduler).Cast<Stream>().Subscribe(ret);
				}
			}
			catch (Exception error)
			{
				ret.OnError(error);
			}
		}, scheduler);
		return ret;
	}

	public static void CreateRecursive(this DirectoryInfo directoryInfo)
	{
		directoryInfo.SplitFullPath().Aggregate(delegate(string parent, string dir)
		{
			string text = Path.Combine(parent, dir);
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			return text;
		});
	}

	public static IEnumerable<string> SplitFullPath(this DirectoryInfo directoryInfo)
	{
		string pathRoot = Path.GetPathRoot(directoryInfo.FullName);
		List<string> list = new List<string>();
		string text = directoryInfo.FullName;
		while (text != pathRoot && text != null)
		{
			string fileName = Path.GetFileName(text);
			if (!string.IsNullOrEmpty(fileName))
			{
				list.Add(fileName);
			}
			text = Path.GetDirectoryName(text);
		}
		if (pathRoot != null)
		{
			list.Add(pathRoot);
		}
		list.Reverse();
		return list;
	}

	public static IObservable<T> LogErrors<T>(this IObservable<T> observable, string? message = null)
	{
		return Observable.Create((IObserver<T> subj) => observable.Subscribe(subj.OnNext, delegate(Exception ex)
		{
			string callerMemberName = message ?? ("0x" + observable.GetHashCode().ToString("x", CultureInfo.InvariantCulture));
			LogHost.Default.Info(ex, "{0} failed", callerMemberName);
			subj.OnError(ex);
		}, subj.OnCompleted));
	}

	public static IObservable<Unit> CopyToAsync(this Stream stream, Stream destination, IScheduler? scheduler = null)
	{
		return Observable.Start(delegate
		{
			try
			{
				stream.CopyTo(destination);
			}
			catch (Exception exception)
			{
				LogHost.Default.Warn(exception, "CopyToAsync failed", "CopyToAsync");
			}
			finally
			{
				stream.Dispose();
				destination.Dispose();
			}
		}, scheduler ?? BlobCache.TaskpoolScheduler);
	}
}
