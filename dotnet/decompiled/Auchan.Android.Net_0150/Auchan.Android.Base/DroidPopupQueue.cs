using System;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Android.OS;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AsyncAwaitBestPractices;
using Auchan.Android.Common;
using Auchan.Android.Extensions;
using Auchan.Common.Base.PopupQueue;
using Auchan.Common.DependencyInjection;
using Auchan.Common.UniversalLinks;
using DryIoc;

namespace Auchan.Android.Base;

public class DroidPopupQueue : AbstractPopupQueue<PopupQueueItem>, IDisposable
{
	private FragmentManager _fragmentManager;

	private string _lastTag;

	private bool _isVisible;

	private readonly IUniversalLinksService _universalLinksService;

	protected override bool CanShow
	{
		get
		{
			if (_isVisible)
			{
				FragmentManager fragmentManager = _fragmentManager;
				if (fragmentManager != null && !fragmentManager.IsStateSaved && !fragmentManager.IsDestroyed)
				{
					return !_universalLinksService.IsNavigating;
				}
			}
			return false;
		}
	}

	public event Action<Fragment>? WillShowPopup;

	public DroidPopupQueue(IUniversalLinksService universalLinksService)
	{
		_universalLinksService = universalLinksService;
	}

	public IDisposable OnCreate(FragmentManager manager)
	{
		_fragmentManager = manager;
		if (!string.IsNullOrWhiteSpace(_lastTag))
		{
			Fragment fragment = manager.FindFragmentByTag(_lastTag);
			if (fragment != null)
			{
				AttachObserver(fragment);
			}
			else
			{
				_lastTag = null;
			}
		}
		return Disposable.Create(OnDestroy);
	}

	private void OnDestroy()
	{
		_fragmentManager = null;
	}

	public void OnResume()
	{
		_isVisible = true;
		RaiseQueue();
	}

	public void OnPause()
	{
		_isVisible = false;
	}

	public void Show<T>(object? arg = null, Func<bool>? canShow = null) where T : DialogFragment
	{
		Enqueue(new PopupQueueItem(typeof(T), arg, canShow));
	}

	public void Show(Func<Task> action)
	{
		Enqueue(new PopupQueueItem(action));
	}

	public void RemoveFromQueue<T>() where T : DialogFragment
	{
		PopupQueueItem item = new PopupQueueItem(typeof(T), null);
		if (Contains(item))
		{
			RemoveFromQueue(item);
		}
	}

	public void RemoveAndDismiss<T>() where T : DialogFragment
	{
		RemoveFromQueue<T>();
		if (!string.IsNullOrWhiteSpace(_lastTag) && _fragmentManager?.FindFragmentByTag(_lastTag) is T val)
		{
			val.DismissAllowingStateLoss();
		}
	}

	protected override void OnPopupRequested(PopupQueueItem item)
	{
		if (item.Action != null)
		{
			RunAction(item.Action).SafeFireAndForget((Action<Exception>)null, false);
			return;
		}
		string text = Guid.NewGuid().ToString("N");
		DialogFragment dialogFragment = (DialogFragment)_fragmentManager.FragmentFactory.Instantiate(item.ScreenType);
		object parameter = item.Parameter;
		if (parameter != null)
		{
			Bundle arguments = ((!(parameter is Bundle bundle)) ? parameter.ToNavBundle() : bundle);
			dialogFragment.Arguments = arguments;
		}
		_lastTag = text;
		AttachObserver(dialogFragment);
		this.WillShowPopup?.Invoke(dialogFragment);
		dialogFragment.Show(_fragmentManager, text);
	}

	protected override bool CanShowItem(PopupQueueItem item)
	{
		return item.CanShow?.Invoke() ?? true;
	}

	public void Dispose()
	{
		_lastTag = null;
		_fragmentManager = null;
	}

	private void AttachObserver(ILifecycleOwner owner)
	{
		base.IsShowing = true;
		owner.Lifecycle.AddObserver(new LifecycleCallback(delegate
		{
			base.IsShowing = false;
			RaiseQueue();
		}, Lifecycle.Event.OnDestroy));
	}

	public static DroidPopupQueue CreateFor(Fragment fragment)
	{
		return fragment.Retain("DroidPopupQueue", () => DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<DroidPopupQueue>(), delegate(DroidPopupQueue q)
		{
			q.Dispose();
		});
	}
}
