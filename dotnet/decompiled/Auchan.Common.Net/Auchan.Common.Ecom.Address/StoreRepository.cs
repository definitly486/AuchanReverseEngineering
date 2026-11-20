using System;
using System.Threading;
using System.Threading.Tasks;
using Akavache.Sqlite3.Internal;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.Address.DTO;
using Auchan.Common.Ecom.PriceChecker;
using Auchan.Common.Home;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Storage;

namespace Auchan.Common.Ecom.Address;

public class StoreRepository
{
	private const string EXPRESS_DELIVERY_INFORMER_SHOWN_KEY = "ExpressDeliveryInformerShown";

	private readonly TimeSpan ReceiveMethodsCacheTime = TimeSpan.FromSeconds(5L);

	private readonly Lazy<IStoreService> _storeService;

	private readonly IPriceCheckerContext _priceCheckerContext;

	private readonly AsyncLock _receiveMethodsLock = new AsyncLock();

	private readonly SemaphoreSlim _expressDeliveryInformerGate = new SemaphoreSlim(1, 1);

	private bool _expressDeliveryHighlightIsInProgress;

	private Result<ReceiveMethodsResponseDTO, DomainError> _receiveMethodsResult = new NoDataError();

	private DateTime _receiveMethodsResultTime = DateTime.MinValue;

	private Task<Result<ReceiveMethodsResponseDTO, DomainError>>? _prefetch;

	public bool IsExpressDeliveryInformerShown
	{
		get
		{
			_expressDeliveryInformerGate.Wait();
			try
			{
				return GetIsExpressDeliveryInformerShown();
			}
			finally
			{
				_expressDeliveryInformerGate.Release();
			}
		}
	}

	public StoreRepository(Lazy<IStoreService> storeService, IHomeScreenTracker homeScreenTracker, IUserContext userContext, IPriceCheckerContext priceCheckerContext)
	{
		_storeService = storeService;
		_priceCheckerContext = priceCheckerContext;
		homeScreenTracker.OnShown += delegate
		{
			_prefetch = null;
		};
		userContext.AfterLoggedIn += ResetExpressDeliveryInformer;
		userContext.AfterLoggedOut += ResetExpressDeliveryInformer;
	}

	public void PrefetchReceiveMethods()
	{
		_prefetch = Task.Run((Func<Task<Result<ReceiveMethodsResponseDTO, DomainError>>?>)LoadReceiveMethods);
	}

	public void CleanupReceiveMethodsCache()
	{
		_prefetch = null;
		_receiveMethodsResultTime = DateTime.MinValue;
	}

	public async Task<Result<ReceiveMethodsResponseDTO, DomainError>> ReceiveMethods()
	{
		using (await _receiveMethodsLock.LockAsync(default(CancellationToken)))
		{
			if (_prefetch != null)
			{
				return CacheResult(await _prefetch);
			}
			if (DateTime.UtcNow - _receiveMethodsResultTime <= ReceiveMethodsCacheTime)
			{
				return _receiveMethodsResult;
			}
			return CacheResult(await LoadReceiveMethods());
		}
		Result<ReceiveMethodsResponseDTO, DomainError> CacheResult(Result<ReceiveMethodsResponseDTO, DomainError> result)
		{
			if (result.TryGetValue(out ReceiveMethodsResponseDTO _))
			{
				_receiveMethodsResult = result;
				_receiveMethodsResultTime = DateTime.UtcNow;
			}
			return result;
		}
	}

	private async Task<Result<ReceiveMethodsResponseDTO, DomainError>> LoadReceiveMethods()
	{
		Result<ReceiveMethodsResponseDTO, DomainError> result = await _storeService.Value.ReceiveMethods();
		if (result.TryGetValue(out var value))
		{
			ReceiveMethodsResponseShopDTO receiveMethodsResponseShopDTO = value.Data?.Store;
			if (receiveMethodsResponseShopDTO != null)
			{
				_priceCheckerContext.ResetIfRegionChanged(receiveMethodsResponseShopDTO.RegionId);
			}
		}
		return result;
	}

	public bool TryBeginExpressDeliveryHighlight()
	{
		_expressDeliveryInformerGate.Wait();
		try
		{
			if (GetIsExpressDeliveryInformerShown())
			{
				return false;
			}
			if (_expressDeliveryHighlightIsInProgress)
			{
				return false;
			}
			_expressDeliveryHighlightIsInProgress = true;
			return true;
		}
		finally
		{
			_expressDeliveryInformerGate.Release();
		}
	}

	public void EndExpressDeliveryHighlight()
	{
		_expressDeliveryInformerGate.Wait();
		try
		{
			_expressDeliveryHighlightIsInProgress = false;
		}
		finally
		{
			_expressDeliveryInformerGate.Release();
		}
	}

	public bool TryMarkExpressDeliveryInformerShown()
	{
		_expressDeliveryInformerGate.Wait();
		try
		{
			if (GetIsExpressDeliveryInformerShown())
			{
				return false;
			}
			Preferences.Set("ExpressDeliveryInformerShown", value: true, "UserContextPreferences");
			return true;
		}
		finally
		{
			_expressDeliveryInformerGate.Release();
		}
	}

	private async Task ResetExpressDeliveryInformer()
	{
		await _expressDeliveryInformerGate.WaitAsync();
		try
		{
			Preferences.Remove("ExpressDeliveryInformerShown", "UserContextPreferences");
			_expressDeliveryHighlightIsInProgress = false;
		}
		finally
		{
			_expressDeliveryInformerGate.Release();
		}
	}

	private static bool GetIsExpressDeliveryInformerShown()
	{
		return Preferences.Get("ExpressDeliveryInformerShown", defaultValue: false, "UserContextPreferences");
	}
}
