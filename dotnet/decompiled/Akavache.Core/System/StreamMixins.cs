using System.IO;
using System.Reactive;
using System.Reactive.Subjects;

namespace System;

public static class StreamMixins
{
	public static IObservable<Unit> WriteAsyncRx(this Stream blobCache, byte[] data, int start, int length)
	{
		ArgumentNullException.ThrowIfNull(blobCache, "blobCache");
		AsyncSubject<Unit> ret = new AsyncSubject<Unit>();
		try
		{
			blobCache.BeginWrite(data, start, length, delegate(IAsyncResult result)
			{
				try
				{
					blobCache.EndWrite(result);
					ret.OnNext(Unit.Default);
					ret.OnCompleted();
				}
				catch (Exception error2)
				{
					ret.OnError(error2);
				}
			}, null);
		}
		catch (Exception error)
		{
			ret.OnError(error);
		}
		return ret;
	}
}
