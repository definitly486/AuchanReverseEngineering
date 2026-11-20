using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using Splat;

namespace Akavache;

[RequiresUnreferencedCode("Registrations for Akavache.Core")]
[RequiresDynamicCode("Registrations for Akavache.Core")]
public static class BlobCache
{
	private class ShutdownBlobCache : ISecureBlobCache, IBlobCache, IDisposable
	{
		IObservable<Unit> IBlobCache.Shutdown => Observable.Return(Unit.Default);

		public IScheduler Scheduler => System.Reactive.Concurrency.Scheduler.Immediate;

		public DateTimeKind? ForcedDateTimeKind
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Dispose()
		{
		}

		public IObservable<Unit> Insert(string key, byte[] data, DateTimeOffset? absoluteExpiration = null)
		{
			return Observable.Empty<Unit>();
		}

		public IObservable<byte[]> Get(string key)
		{
			return Observable.Empty<byte[]>();
		}

		public IObservable<IEnumerable<string>> GetAllKeys()
		{
			return Observable.Empty<IEnumerable<string>>();
		}

		public IObservable<DateTimeOffset?> GetCreatedAt(string key)
		{
			return Observable.Empty<DateTimeOffset?>();
		}

		public IObservable<Unit> Flush()
		{
			return Observable.Empty<Unit>();
		}

		public IObservable<Unit> Invalidate(string key)
		{
			return Observable.Empty<Unit>();
		}

		public IObservable<Unit> InvalidateAll()
		{
			return Observable.Empty<Unit>();
		}

		public IObservable<Unit> Vacuum()
		{
			return Observable.Empty<Unit>();
		}
	}

	private static string? _applicationName;

	private static IBlobCache? _localMachine;

	private static IBlobCache? _userAccount;

	private static ISecureBlobCache? _secure;

	private static bool _shutdownRequested;

	private static IScheduler? _taskPoolOverride;

	[ThreadStatic]
	private static IBlobCache? _unitTestLocalMachine;

	[ThreadStatic]
	private static IBlobCache? _unitTestUserAccount;

	[ThreadStatic]
	private static ISecureBlobCache? _unitTestSecure;

	public static string ApplicationName
	{
		get
		{
			return _applicationName ?? throw new Exception("Make sure to set BlobCache.ApplicationName on startup");
		}
		set
		{
			_applicationName = value;
		}
	}

	public static IBlobCache LocalMachine
	{
		get
		{
			object obj = _unitTestLocalMachine;
			if (obj == null)
			{
				obj = _localMachine;
				if (obj == null)
				{
					IBlobCache blobCache = (_shutdownRequested ? new ShutdownBlobCache() : null);
					obj = blobCache ?? Locator.Current.GetService<IBlobCache>("LocalMachine") ?? throw new InvalidOperationException("Unable to resolve LocalMachine cache. Make sure Akavache is initialized properly.");
				}
			}
			return (IBlobCache)obj;
		}
		set
		{
			if (ModeDetector.InUnitTestRunner())
			{
				_unitTestLocalMachine = value;
				if (_localMachine == null)
				{
					_localMachine = value;
				}
			}
			else
			{
				_localMachine = value;
			}
		}
	}

	public static IBlobCache UserAccount
	{
		get
		{
			object obj = _unitTestUserAccount;
			if (obj == null)
			{
				obj = _userAccount;
				if (obj == null)
				{
					IBlobCache blobCache = (_shutdownRequested ? new ShutdownBlobCache() : null);
					obj = blobCache ?? Locator.Current.GetService<IBlobCache>("UserAccount") ?? throw new InvalidOperationException("Unable to resolve UserAccount cache. Make sure Akavache is initialized properly.");
				}
			}
			return (IBlobCache)obj;
		}
		set
		{
			if (ModeDetector.InUnitTestRunner())
			{
				_unitTestUserAccount = value;
				if (_userAccount == null)
				{
					_userAccount = value;
				}
			}
			else
			{
				_userAccount = value;
			}
		}
	}

	public static ISecureBlobCache Secure
	{
		get
		{
			object obj = _unitTestSecure;
			if (obj == null)
			{
				obj = _secure;
				if (obj == null)
				{
					ISecureBlobCache secureBlobCache = (_shutdownRequested ? new ShutdownBlobCache() : null);
					obj = secureBlobCache ?? Locator.Current.GetService<ISecureBlobCache>() ?? throw new InvalidOperationException("Unable to resolve Secure cache. Make sure Akavache is initialized properly.");
				}
			}
			return (ISecureBlobCache)obj;
		}
		set
		{
			if (ModeDetector.InUnitTestRunner())
			{
				_unitTestSecure = value;
				if (_secure == null)
				{
					_secure = value;
				}
			}
			else
			{
				_secure = value;
			}
		}
	}

	public static ISecureBlobCache InMemory { get; set; }

	public static DateTimeKind? ForcedDateTimeKind { get; set; }

	public static IScheduler TaskpoolScheduler
	{
		get
		{
			return _taskPoolOverride ?? Locator.Current.GetService<IScheduler>("Taskpool") ?? TaskPoolScheduler.Default;
		}
		set
		{
			_taskPoolOverride = value;
		}
	}

	static BlobCache()
	{
		Locator.RegisterResolverCallbackChanged(delegate
		{
			if (Locator.CurrentMutable != null)
			{
				Locator.CurrentMutable.InitializeAkavache(Locator.Current);
			}
		});
		InMemory = new InMemoryBlobCache(Scheduler.Default);
	}

	public static void EnsureInitialized()
	{
		LogHost.Default.Debug("Initializing Akavache", "EnsureInitialized");
	}

	public static Task Shutdown()
	{
		_shutdownRequested = true;
		return (from _ in new IBlobCache[4] { LocalMachine, UserAccount, Secure, InMemory }.Select(delegate(IBlobCache x)
			{
				x.Dispose();
				return x.Shutdown;
			}).Merge().ToList()
			select Unit.Default).ToTask();
	}
}
