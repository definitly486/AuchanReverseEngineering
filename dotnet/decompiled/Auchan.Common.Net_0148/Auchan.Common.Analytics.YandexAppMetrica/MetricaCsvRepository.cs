using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Cache;
using Auchan.Common.Common;

namespace Auchan.Common.Analytics.YandexAppMetrica;

public class MetricaCsvRepository
{
	private const string METRICA_CSV_LIST_CACHE_KEY = "METRICA_CSV_LIST_CACHE_KEY";

	private const string METRICA_NOT_FULL_CSV_CACHE_KEY = "METRICA_NOT_FULL_CSV_CACHE_KEY";

	private const string METRICA_REQ_TIME_CACHE_KEY = "METRICA_REQ_TIME_CACHE_KEY";

	private readonly TaskQueue _csvSendingTaskQueue = new TaskQueue();

	private readonly List<MetricaCsvModel> _csvList = new List<MetricaCsvModel>();

	private readonly Lazy<IMetricaService> _metricaService;

	private readonly Lazy<IAppMetricaKeyProvider> _appMetricaKeyProvider;

	private readonly Lazy<ICache> _cache;

	public MetricaCsvRepository(Lazy<ICache> cache, Lazy<IMetricaService> metricaService, Lazy<IAppMetricaKeyProvider> appMetricaKeyProvider)
	{
		_cache = cache;
		_metricaService = metricaService;
		_appMetricaKeyProvider = appMetricaKeyProvider;
		Task.Run(() => _csvSendingTaskQueue.Enqueue(GetCsvListFromCache)).SafeFireAndForget((Action<Exception>)null, false);
	}

	public Task SaveNotFullCsv(string csvData)
	{
		return _cache.Value.Save("METRICA_NOT_FULL_CSV_CACHE_KEY", csvData);
	}

	public void SaveCsvToPoolAndTryToSend(string csvData)
	{
		_csvSendingTaskQueue.Enqueue(() => SendCsvTask(csvData)).SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task GetCsvListFromCache()
	{
		List<MetricaCsvModel> metricaCsvNotSentList = (await _cache.Value.TryGet<List<MetricaCsvModel>>("METRICA_CSV_LIST_CACHE_KEY")) ?? new List<MetricaCsvModel>();
		string text = (await _cache.Value.TryGet<string>("METRICA_NOT_FULL_CSV_CACHE_KEY")) ?? string.Empty;
		if (text.Length > 0)
		{
			metricaCsvNotSentList.Add(new MetricaCsvModel
			{
				IsSent = false,
				CsvData = text
			});
			await _cache.Value.Save("METRICA_NOT_FULL_CSV_CACHE_KEY", string.Empty);
		}
		if (metricaCsvNotSentList.Count <= 0)
		{
			return;
		}
		foreach (MetricaCsvModel metricaCsv in metricaCsvNotSentList)
		{
			_csvSendingTaskQueue.Enqueue(() => SendCsvTask(metricaCsv.CsvData)).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private async Task SendCsvTask(string csvData)
	{
		_csvList.Add(new MetricaCsvModel
		{
			IsSent = false,
			CsvData = csvData
		});
		foreach (MetricaCsvModel csv in _csvList.Where((MetricaCsvModel metricaCsvModel) => !metricaCsvModel.IsSent))
		{
			if (await SendCsv(csv.CsvData))
			{
				csv.IsSent = true;
			}
		}
		_csvList.RemoveAll((MetricaCsvModel x) => x.IsSent);
		await _cache.Value.Save("METRICA_CSV_LIST_CACHE_KEY", _csvList);
	}

	private async Task<bool> SendCsv(string csvData)
	{
		LimitDataModel newLimitData = new LimitDataModel
		{
			FirstRequestTime = DateTime.UtcNow,
			RequestsCount = 0,
			RequestLimit = 5000
		};
		LimitDataModel limitData = (await _cache.Value.TryGet<LimitDataModel>("METRICA_REQ_TIME_CACHE_KEY")) ?? newLimitData;
		DateTime utcNow = DateTime.UtcNow;
		DateTime? firstRequestTime = limitData.FirstRequestTime;
		if (utcNow - firstRequestTime > TimeSpan.FromDays(1))
		{
			limitData = newLimitData;
			await _cache.Value.Save("METRICA_REQ_TIME_CACHE_KEY", limitData);
		}
		if (limitData.RequestsCount >= limitData.RequestLimit)
		{
			return false;
		}
		string postApiKey = await _appMetricaKeyProvider.Value.GetKeyAsync();
		if ((await _metricaService.Value.TrackEvent(postApiKey, csvData)).IsSuccess)
		{
			limitData.RequestsCount++;
			await _cache.Value.Save("METRICA_REQ_TIME_CACHE_KEY", limitData);
		}
		return true;
	}
}
