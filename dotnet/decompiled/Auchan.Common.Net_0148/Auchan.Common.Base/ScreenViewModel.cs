using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Analytics.YandexAppMetrica.DataStores;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Extensions;
using Auchan.Common.Navigation;
using DryIoc;

namespace Auchan.Common.Base;

public abstract class ScreenViewModel : IOnNavigateFrom, INotifyPropertyChanged, IDisposable, IScreenViewModel, IBindable
{
	private enum State
	{
		Created,
		Started,
		Resumed,
		Disposed
	}

	private WeakReference<INativeController> _nativeView = new WeakReference<INativeController>(null);

	private CancellationTokenSource? _navigationCts;

	private State _state;

	private TaskCompletionSource<bool> _pauseTcs = new TaskCompletionSource<bool>();

	private TaskCompletionSource<bool> _resumeTcs = new TaskCompletionSource<bool>();

	private readonly IViewModelStateManager _viewModelStateManager;

	private readonly ScreenDataStore _screenDataStore;

	private readonly CompositeDisposable _pauseDisposable = new CompositeDisposable();

	private readonly CompositeDisposable _closeDisposable = new CompositeDisposable();

	[CompilerGenerated]
	private bool _003CTabBarVisible_003Ek__BackingField;

	protected ICollection<IDisposable> CloseDisposable => _closeDisposable;

	protected ICollection<IDisposable> PauseDisposable => _pauseDisposable;

	protected ICollection<ElementViewModel> ElementViewModels { get; } = new List<ElementViewModel>();

	protected virtual string? ScreenName => null;

	protected CancellationToken? NavigationToken => _navigationCts?.Token;

	public virtual bool TabBarVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CTabBarVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			if (_003CTabBarVisible_003Ek__BackingField != value)
			{
				_003CTabBarVisible_003Ek__BackingField = value;
				RaisePropertyChanged("TabBarVisible");
			}
		}
	} = true;

	public virtual bool ShowInPopup => false;

	public bool IsActive => _state == State.Resumed;

	public UICommand ResumeCommand { get; } = new UICommand();

	public UICommand PauseCommand { get; } = new UICommand();

	public event PropertyChangedEventHandler? PropertyChanged;

	protected ScreenViewModel()
	{
		_viewModelStateManager = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<IViewModelStateManager>();
		_screenDataStore = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<ScreenDataStore>();
	}

	public T? GetNativeView<T>() where T : class
	{
		return _nativeView.Invoke((INativeController? i) => i?.View as T);
	}

	public Task DoStart(INativeController nativeController)
	{
		if (_state >= State.Started)
		{
			return Task.CompletedTask;
		}
		_state = State.Started;
		_nativeView.SetTarget(nativeController);
		_screenDataStore.AddToListCurrentScreenViewModelType(this).AddTo(CloseDisposable);
		_viewModelStateManager.Started(this);
		return Start();
	}

	protected virtual async Task Start()
	{
		await Task.WhenAll(ElementViewModels.Select((ElementViewModel e) => e.Start()));
	}

	public async Task DoResume()
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		if (_state < State.Resumed)
		{
			_state = State.Resumed;
			Interlocked.Exchange(ref _resumeTcs, new TaskCompletionSource<bool>()).TrySetResult(result: true);
			_screenDataStore.AddToListCurrentScreenViewModelType(this).AddTo(CloseDisposable);
			_navigationCts?.Cancel();
			_navigationCts = new CancellationTokenSource();
			_viewModelStateManager.Resumed(this);
			await OnResumed();
		}
	}

	protected virtual async Task OnResumed()
	{
		ResumeCommand.Trigger();
		await Task.WhenAll(ElementViewModels.Select((ElementViewModel e) => e.OnResumed()));
	}

	public async Task DoPause()
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		if (_state > State.Started)
		{
			_state = State.Started;
			Interlocked.Exchange(ref _pauseTcs, new TaskCompletionSource<bool>()).TrySetResult(result: true);
			await OnPaused();
		}
	}

	protected virtual async Task OnPaused()
	{
		_navigationCts?.Cancel();
		_pauseDisposable.Clear();
		PauseCommand.Trigger();
		await Task.WhenAll(ElementViewModels.Select((ElementViewModel e) => e.OnPaused()));
	}

	public virtual void Dispose()
	{
		_state = State.Disposed;
		_pauseTcs.TrySetResult(result: false);
		_resumeTcs.TrySetResult(result: false);
		_pauseDisposable.Dispose();
		_closeDisposable.Dispose();
		ElementViewModels.ForEach(delegate(ElementViewModel i)
		{
			i.Dispose();
		});
		ElementViewModels.Clear();
		if (_nativeView.TryGetTarget(out INativeController _))
		{
			_nativeView.SetTarget(null);
		}
	}

	protected void RaisePropertyChanged(string property)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
	}

	public virtual NavigationPossibilityType OnNavigateFrom()
	{
		return NavigationPossibilityType.Possible;
	}

	protected Task<bool> WaitForResume()
	{
		return _resumeTcs.Task;
	}

	protected Task<bool> WaitForPause()
	{
		return _pauseTcs.Task;
	}
}
public abstract class ScreenViewModel<TArgument> : ScreenViewModel where TArgument : BrokeredParameter
{
	protected IDataBroker DataBroker { get; }

	protected TArgument Argument { get; }

	protected ScreenViewModel(BrokerToken parameter)
	{
		DataBroker = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<IDataBroker>();
		Argument = DataBroker.Pop<TArgument>(parameter);
	}
}
