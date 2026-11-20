using System;
using System.Reactive.Disposables;
using System.Reflection;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using AndroidX.Activity;
using AndroidX.AppCompat.App;
using AndroidX.Core.Graphics;
using AndroidX.Core.View;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Helpers;
using Auchan.Common.Base;
using Auchan.Common.Cache;
using Auchan.Common.DependencyInjection;
using DryIoc;
using Microsoft.Maui.ApplicationModel;
using XamarinShortcutBadger;

namespace Auchan.Android.Base;

internal abstract class BaseActivity : AppCompatActivity, INativeController
{
	private readonly WeakEventManager<ChangedActivityInsetsArgs> _changedInsetsEventManager = new WeakEventManager<ChangedActivityInsetsArgs>();

	private Insets? _originalPadding;

	private Intent? _newIntent;

	private bool _insetListenerInstalled;

	protected virtual int? LayoutId { get; private set; }

	protected virtual bool ShouldProcessIntent => true;

	protected virtual View RootView => Window?.DecorView.RootView ?? throw new InvalidOperationException("not initialized");

	public virtual WindowInsetsCompat WindowInsets { get; private set; } = new WindowInsetsCompat(null);

	object? INativeController.View
	{
		get
		{
			View view = Window?.DecorView;
			return view?.FindViewById(2131296838) ?? view?.RootView ?? view;
		}
	}

	public event EventHandler? AnyClick;

	public event EventHandler<ChangedActivityInsetsArgs> InsetsChangedWeak
	{
		add
		{
			_changedInsetsEventManager.AddEventHandler(value, "InsetsChangedWeak");
		}
		remove
		{
			_changedInsetsEventManager.RemoveEventHandler(value, "InsetsChangedWeak");
		}
	}

	public IDisposable OnInsetsChanged(Action handler)
	{
		return OnInsetsChanged((EventHandler<ChangedActivityInsetsArgs>)delegate
		{
			handler();
		});
	}

	public IDisposable OnInsetsChanged(EventHandler<ChangedActivityInsetsArgs> handler)
	{
		InsetsChangedWeak += handler;
		return Disposable.Create(delegate
		{
			InsetsChangedWeak -= handler;
		});
	}

	protected void SetLayoutId(int layoutId)
	{
		LayoutId = layoutId;
	}

	protected override void OnCreate(Bundle? savedInstanceState)
	{
		SupportFragmentManager.FragmentFactory = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<FragmentFactory>();
		base.OnCreate(savedInstanceState);
		EdgeToEdge.Enable(this);
		UserFontSizeHelper.AdjustFontScale(Resources.Configuration, Resources, this);
		if (LayoutId.HasValue)
		{
			SetContentView(LayoutId.Value);
		}
	}

	public override void SetContentView(View? view, ViewGroup.LayoutParams? @params)
	{
		base.SetContentView(view, @params);
		InstallOnApplyWindowInsetsListener(view);
	}

	public override void SetContentView(View? view)
	{
		base.SetContentView(view);
		InstallOnApplyWindowInsetsListener(view);
	}

	public override void SetContentView(int layoutResID)
	{
		base.SetContentView(layoutResID);
		InstallOnApplyWindowInsetsListener(RootView);
	}

	private void InstallOnApplyWindowInsetsListener(View? view)
	{
		if (view != null && !_insetListenerInstalled)
		{
			_insetListenerInstalled = true;
			ViewCompat.SetOnApplyWindowInsetsListener(view, CreateInsetListener(view));
		}
	}

	protected virtual IOnApplyWindowInsetsListener CreateInsetListener(View view)
	{
		return new OnApplyWindowInsetsListener(delegate(WindowInsetsCompat insets)
		{
			WindowInsets = insets;
			OnWindowInsetsChanged(view, insets);
		});
	}

	protected virtual void OnWindowInsetsChanged(View view, WindowInsetsCompat insets)
	{
		if (_originalPadding == null)
		{
			_originalPadding = Insets.Of(view.PaddingLeft, view.PaddingTop, view.PaddingRight, view.PaddingBottom);
		}
		ChangedActivityInsetsArgs changedActivityInsetsArgs = new ChangedActivityInsetsArgs
		{
			ActivityView = view,
			ActivityViewOriginalPadding = _originalPadding,
			Insets = insets
		};
		try
		{
			_changedInsetsEventManager.RaiseEvent((object?)this, changedActivityInsetsArgs, "InsetsChangedWeak");
		}
		catch (TargetInvocationException ex) when (ex.InnerException is ObjectDisposedException)
		{
		}
		if (!changedActivityInsetsArgs.Handled)
		{
			Insets insets2 = insets.GetInsets(WindowInsetsCompat.Type.StatusBars());
			view.SetPadding(_originalPadding.Left, _originalPadding.Top + insets2.Top, _originalPadding.Right, _originalPadding.Bottom);
		}
	}

	protected override void OnNewIntent(Intent? intent)
	{
		base.OnNewIntent(intent);
		SaveIntentForHandling(intent);
	}

	protected void SaveIntentForHandling(Intent? intent)
	{
		if (ShouldProcessIntent)
		{
			_newIntent = intent;
		}
	}

	protected override void OnResume()
	{
		base.OnResume();
		if (ShouldProcessIntent && _newIntent != null)
		{
			AppIntentHandler.HandleIntent(_newIntent);
			_newIntent = null;
		}
		ICache cache = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<ICache>();
		Task.Run(async delegate
		{
			await cache.Save("CachedNotificationsCount", 0);
		});
		ShortcutBadger.ApplyCount(Application.Context, 0);
		((NotificationManager)Application.Context.GetSystemService("notification")).CancelAll();
		Platform.OnResume(this);
	}

	[SupportedOSPlatform("android23.0")]
	public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
	{
		Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
	}

	public override void OnUserInteraction()
	{
		base.OnUserInteraction();
		this.AnyClick?.Invoke(this, new EventArgs());
	}
}
