using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Cache;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Ecom.Cart;

public class CashbackLimitNotifier : IApplicationStateObserver
{
	private const string CASHBACK_LIMIT_CACHE_KEY = "CASHBACK_LIMIT_KEY";

	private readonly Lazy<IInfoMessageService> _infoMessageService;

	private readonly Lazy<ICache> _cache;

	private readonly TaskQueue _notificationQueue;

	public CashbackLimitNotifier(Lazy<IInfoMessageService> infoMessageService, Lazy<ICache> cache)
	{
		_infoMessageService = infoMessageService;
		_cache = cache;
		_notificationQueue = new TaskQueue();
	}

	public void OnPaused()
	{
		_notificationQueue.Enqueue(async delegate
		{
			await _cache.Value.Remove("CASHBACK_LIMIT_KEY");
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void CheckLimitAndNotify(ProductOffer product)
	{
		EnqueueNotification(product);
	}

	public void RemoveProductNotificationsFromCache(IReadOnlyList<ProductOffer> products)
	{
		_notificationQueue.Enqueue(async delegate
		{
			await RemoveFromCache(products.Select((ProductOffer i) => i.GimaId));
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	private void EnqueueNotification(ProductOffer product)
	{
		_notificationQueue.Enqueue(async delegate
		{
			await HandleNotification(product);
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task HandleNotification(ProductOffer product)
	{
		Auchan.Common.Ecom.ProducModels.Cashback? cashback = product.Cashback;
		if ((object)cashback == null || !(cashback.Limit == default(decimal)))
		{
			await CompareCashbackLimitThenShowSnack(product, product.Qty);
		}
	}

	private async Task CompareCashbackLimitThenShowSnack(ProductOffer product, decimal valueToCompare)
	{
		bool flag = product.Cashback == null;
		if (!flag)
		{
			flag = await WasNotifiedProductInSession(product.GimaId);
		}
		if (!flag && product.Cashback.Limit < valueToCompare)
		{
			await SaveAndShowSnack(product);
		}
	}

	private async Task SaveAndShowSnack(ProductOffer product)
	{
		await SaveInCache(product.GimaId);
		ShowSnackbar(product);
	}

	private async Task SaveInCache(string gimaId)
	{
		CashbackLimitNotifiedModel cashbackLimitNotifiedModel = await _cache.Value.TryGet<CashbackLimitNotifiedModel>("CASHBACK_LIMIT_KEY");
		if (cashbackLimitNotifiedModel == null)
		{
			cashbackLimitNotifiedModel = new CashbackLimitNotifiedModel(new List<string> { gimaId });
		}
		else
		{
			cashbackLimitNotifiedModel.LimitNotifiedGimaIds.Add(gimaId);
		}
		await _cache.Value.Save("CASHBACK_LIMIT_KEY", cashbackLimitNotifiedModel);
	}

	private async Task RemoveFromCache(IEnumerable<string> gimaIds)
	{
		CashbackLimitNotifiedModel cashbackLimitNotifiedModel = await _cache.Value.TryGet<CashbackLimitNotifiedModel>("CASHBACK_LIMIT_KEY");
		if (cashbackLimitNotifiedModel == null)
		{
			return;
		}
		foreach (string gimaId in gimaIds)
		{
			cashbackLimitNotifiedModel.LimitNotifiedGimaIds.Remove(gimaId);
		}
		await _cache.Value.Save("CASHBACK_LIMIT_KEY", cashbackLimitNotifiedModel);
	}

	private void ShowSnackbar(ProductOffer product)
	{
		_infoMessageService.Value.ShowSnackbar($"Кешбэк на выбранный товар будет начислен только на первые {product.Cashback.Limit} {((product.Cashback.LimitType == LimitType.Kg) ? "кг" : "штук")}.", SnackbarStyle.Warning, 5);
	}

	private async Task<bool> WasNotifiedProductInSession(string gimaId)
	{
		return (await _cache.Value.TryGet<CashbackLimitNotifiedModel>("CASHBACK_LIMIT_KEY"))?.LimitNotifiedGimaIds.Any((string x) => x == gimaId) ?? false;
	}
}
