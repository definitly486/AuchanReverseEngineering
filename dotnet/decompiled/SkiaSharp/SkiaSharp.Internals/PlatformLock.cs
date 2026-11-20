using System;
using System.Threading;

namespace SkiaSharp.Internals;

public static class PlatformLock
{
	private class ReadWriteLock : IPlatformLock
	{
		private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

		public void EnterWriteLock()
		{
			_lock.EnterWriteLock();
		}

		public void ExitWriteLock()
		{
			_lock.ExitWriteLock();
		}

		public void EnterUpgradeableReadLock()
		{
			_lock.EnterUpgradeableReadLock();
		}

		public void ExitUpgradeableReadLock()
		{
			_lock.ExitUpgradeableReadLock();
		}
	}

	public static Func<IPlatformLock> Factory { get; } = DefaultFactory;

	public static IPlatformLock Create()
	{
		return Factory();
	}

	public static IPlatformLock DefaultFactory()
	{
		return new ReadWriteLock();
	}
}
