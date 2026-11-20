using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base;

namespace Auchan.Common.Analytics.YandexAppMetrica.DataStores;

public class ScreenDataStore
{
	private sealed class DummyDisposable : IDisposable
	{
		public static DummyDisposable Instance { get; } = new DummyDisposable();

		public void Dispose()
		{
		}
	}

	private sealed class Remover(ScreenDataStore store, IYandexMetricaScreenViewModel vm) : IDisposable
	{
		public void Dispose()
		{
			store.RemoveReference(vm);
		}
	}

	private int _addCounter;

	private readonly object _lock = new object();

	private readonly List<(WeakReference<IYandexMetricaScreenViewModel> ViewModel, string SearchQuery)> _screenViewModelTypeList = new List<(WeakReference<IYandexMetricaScreenViewModel>, string)>();

	public Func<IYandexMetricaScreenViewModel, string, Task>? OnScreenChanged;

	public IYandexMetricaScreenViewModel? GetCurrentScreenViewModelType()
	{
		return GetElementFromEnd(0).ViewModel;
	}

	private (IYandexMetricaScreenViewModel? ViewModel, string? SearchQuery) GetElementFromEnd(int offset)
	{
		lock (_lock)
		{
			for (int num = _screenViewModelTypeList.Count - 1 - offset; num >= 0; num--)
			{
				(WeakReference<IYandexMetricaScreenViewModel>, string) tuple = _screenViewModelTypeList[num];
				if (tuple.Item1.TryGetTarget(out var target))
				{
					return (ViewModel: target, SearchQuery: tuple.Item2);
				}
				_screenViewModelTypeList.RemoveAt(num);
			}
		}
		return default((IYandexMetricaScreenViewModel, string));
	}

	public IYandexMetricaScreenViewModel? GetPreviousScreenViewModelType()
	{
		return GetElementFromEnd(1).ViewModel;
	}

	public IDisposable AddToListCurrentScreenViewModelType(ScreenViewModel? vm)
	{
		if (!(vm is IYandexMetricaScreenViewModel yandexMetricaScreenViewModel))
		{
			return DummyDisposable.Instance;
		}
		IDisposable disposable = null;
		lock (_lock)
		{
			for (int i = 0; i < _screenViewModelTypeList.Count; i++)
			{
				if (_screenViewModelTypeList[i].ViewModel.TryGetTarget(out IYandexMetricaScreenViewModel target) && vm == target)
				{
					if (i == _screenViewModelTypeList.Count - 1)
					{
						return DummyDisposable.Instance;
					}
					_screenViewModelTypeList.RemoveAt(i);
					disposable = DummyDisposable.Instance;
					break;
				}
			}
			_screenViewModelTypeList.Add((new WeakReference<IYandexMetricaScreenViewModel>(yandexMetricaScreenViewModel), yandexMetricaScreenViewModel.SearchQuery));
		}
		Cleanup();
		OnScreenChanged?.Invoke(yandexMetricaScreenViewModel, yandexMetricaScreenViewModel.SearchQuery);
		return disposable ?? new Remover(this, yandexMetricaScreenViewModel);
	}

	private void Cleanup()
	{
		if (Interlocked.Increment(ref _addCounter) % 255 != 0)
		{
			return;
		}
		lock (_lock)
		{
			for (int i = 0; i < _screenViewModelTypeList.Count; i++)
			{
				if (!_screenViewModelTypeList[i].ViewModel.TryGetTarget(out IYandexMetricaScreenViewModel _))
				{
					_screenViewModelTypeList.RemoveAt(i--);
				}
			}
		}
	}

	private void RemoveReference(IYandexMetricaScreenViewModel vm)
	{
		lock (_lock)
		{
			for (int i = 0; i < _screenViewModelTypeList.Count; i++)
			{
				if (_screenViewModelTypeList[i].ViewModel.TryGetTarget(out IYandexMetricaScreenViewModel target) && vm == target)
				{
					_screenViewModelTypeList.RemoveAt(i);
				}
			}
		}
	}
}
