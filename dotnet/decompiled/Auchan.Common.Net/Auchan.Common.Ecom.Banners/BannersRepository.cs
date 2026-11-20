using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.Banners.Models;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Ecom.Banners;

internal class BannersRepository : IBannersRepository
{
	private readonly WeakEventManager<BannersUpdatedEventArgs> _bannersUpdatedWeakEventManager = new WeakEventManager<BannersUpdatedEventArgs>();

	private readonly Lazy<IEcomContext> _ecomContext;

	private readonly Lazy<IBannersApiService> _apiService;

	private Store? _updatedFor;

	private Task<Result<IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>, DomainError>>? _pendingRequest;

	private IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>? _banners;

	private object _requestLock = new object();

	public event EventHandler<BannersUpdatedEventArgs>? BannersUpdateWeakEvent
	{
		add
		{
			_bannersUpdatedWeakEventManager.AddEventHandler(value, "BannersUpdateWeakEvent");
		}
		remove
		{
			_bannersUpdatedWeakEventManager.RemoveEventHandler(value, "BannersUpdateWeakEvent");
		}
	}

	public BannersRepository(Lazy<IEcomContext> ecomContext, Lazy<IBannersApiService> apiService)
	{
		_ecomContext = ecomContext;
		_apiService = apiService;
	}

	public Task<Result<IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>, DomainError>> GetBannersAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		lock (_requestLock)
		{
			Task<Result<IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>, DomainError>> task = _pendingRequest;
			if (task == null || (task.IsCompleted && task.Result.IsFailure))
			{
				task = (_pendingRequest = GetBannersPrivate(cancellationToken));
			}
			return task;
		}
	}

	private async Task<Result<IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>, DomainError>> GetBannersPrivate(CancellationToken cancellationToken = default(CancellationToken))
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		bool isCompleted = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		using (Disposable.Create(delegate
		{
			lock (_requestLock)
			{
				_pendingRequest = null;
			}
		}))
		{
			Store activeStore = await _ecomContext.Value.GetActiveStoreAsync();
			if (_updatedFor != null && _updatedFor.Id == activeStore.Id && _banners != null)
			{
				return Result.Success<IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>, DomainError>(_banners);
			}
			Result<IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>, DomainError> result = await _apiService.Value.GetBanners(cancellationToken);
			if (result.TryGetValue(out IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>> banners))
			{
				_banners = banners;
				if (_updatedFor == null)
				{
					_ecomContext.Value.OnPropertyChanged("ActiveStore", delegate
					{
						UpdateBannersAsync().SafeFireAndForget((Action<Exception>)null, false);
					});
				}
				_updatedFor = activeStore;
				MainThread.BeginInvokeOnMainThread(delegate
				{
					_bannersUpdatedWeakEventManager.RaiseEvent((object?)this, new BannersUpdatedEventArgs
					{
						Banners = banners
					}, "BannersUpdateWeakEvent");
				});
			}
			return result;
		}
	}

	private async Task UpdateBannersAsync()
	{
		Task<Result<IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>, DomainError>> pendingRequest = _pendingRequest;
		if (pendingRequest != null)
		{
			await pendingRequest;
		}
		await GetBannersAsync();
	}
}
