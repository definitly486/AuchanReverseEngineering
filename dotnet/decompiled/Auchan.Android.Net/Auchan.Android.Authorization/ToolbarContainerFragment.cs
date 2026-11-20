using System;
using System.Reactive;
using System.Reactive.Disposables;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Graphics;
using AndroidX.Core.View;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Common;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.PersonalCabinet.Authorization;
using EBind;
using Java.Interop;

namespace Auchan.Android.Authorization;

internal class ToolbarContainerFragment : BaseBottomSheetDialogFragment, IDialogInterfaceOnKeyListener, IJavaObject, IDisposable, IJavaPeerable, IToolbarContainer, ISignupFragmentContainer
{
	public new const string Tag = "ToolbarContainerFragment";

	private View? _backButton;

	private TextView? _titleLabel;

	private TextView? _closeButton;

	private bool _isBackButtonVisible;

	private Action<Unit>? _onBack;

	protected override int LayoutId => 2131493110;

	public override int Theme => 2131951916;

	protected override bool FullScreen => true;

	private bool HasFragmentsInBackStack => base.ChildFragmentManager.BackStackEntryCount > 0;

	public string? Title
	{
		get
		{
			return _titleLabel.Text;
		}
		set
		{
			_titleLabel.Text = value;
		}
	}

	public string? CloseButtonText
	{
		set
		{
			_closeButton.Text = value ?? string.Empty;
			_closeButton.Visibility = (!string.IsNullOrWhiteSpace(value)).ToVisibility();
		}
	}

	public View CloseButton => _closeButton;

	public Toolbar Toolbar { get; set; }

	public IDisposable CustomBackAction(Action<Unit> action)
	{
		_onBack = action;
		return Disposable.Create(this, delegate(ToolbarContainerFragment r)
		{
			r.Reset();
		});
	}

	private void Reset()
	{
		_isBackButtonVisible = false;
		_onBack = null;
		CheckBackButtonVisibility();
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		int num = base.Arguments?.GetInt("LaunchState") ?? (-1);
		LoginActivityLaunchState loginActivityLaunchState = LoginActivityLaunchState.Auth;
		if (num != -1)
		{
			loginActivityLaunchState = (LoginActivityLaunchState)num;
		}
		Cancelable = false;
		base.ChildFragmentManager.BackStackChanged += new DisposableDelegate<EventHandler>(delegate
		{
			OnBackStackChanged();
		}, delegate(EventHandler eh)
		{
			base.ChildFragmentManager.BackStackChanged -= eh;
		}).AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		if (savedInstanceState == null)
		{
			switch (loginActivityLaunchState)
			{
			case LoginActivityLaunchState.Auth:
				base.ChildFragmentManager.Replace<AuthOrRegisterFragment>(2131297216).Commit();
				break;
			case LoginActivityLaunchState.LoyaltyRolloutCardOptions:
				base.ChildFragmentManager.Replace<SignUpFragment>(2131297216, new SignUpViewModel.Parameter().ToNavBundle()).Commit();
				break;
			case LoginActivityLaunchState.LoyaltyCardBlocked:
				base.ChildFragmentManager.Replace<LoyaltyCardBlockedFragment>(2131297216).Commit();
				break;
			case LoginActivityLaunchState.Onboarding:
				break;
			}
		}
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Toolbar = view.RequireViewById<Toolbar>(2131298669);
		_titleLabel = view.RequireViewById<TextView>(2131298655);
		_backButton = view.RequireViewById<View>(2131296490);
		_closeButton = view.RequireViewById<TextView>(2131296795);
		CheckBackButtonVisibility();
		new CompositeDisposable
		{
			_backButton.OnClick((Action)delegate
			{
				OnBackPressed();
			}),
			_closeButton.OnClick(NavigateToStart)
		}.AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	public override void OnDestroyView()
	{
		base.OnDestroyView();
		_titleLabel = null;
		_backButton = null;
		_closeButton = null;
	}

	public void OnBackStackChanged()
	{
		CheckBackButtonVisibility();
	}

	public bool OnKey(IDialogInterface? dialog, Keycode keyCode, KeyEvent? e)
	{
		if (keyCode == Keycode.Back)
		{
			return OnBackPressed();
		}
		return false;
	}

	private bool OnBackPressed()
	{
		_onBack?.Invoke(Unit.Default);
		if (HasFragmentsInBackStack)
		{
			base.ChildFragmentManager.PopBackStack();
			return true;
		}
		return _onBack != null;
	}

	private void NavigateToStart()
	{
		base.ChildFragmentManager.PopBackStack(null, 1);
		base.ChildFragmentManager.Replace<AuthOrRegisterFragment>(2131297216).Commit();
	}

	private void CheckBackButtonVisibility()
	{
		_backButton.Visibility = (HasFragmentsInBackStack || _isBackButtonVisible).ToVisibility();
	}

	public override Dialog OnCreateDialog(Bundle savedInstanceState)
	{
		BottomSheetDialog obj = (BottomSheetDialog)base.OnCreateDialog(savedInstanceState);
		obj.SetOnKeyListener(this);
		obj.SetCanceledOnTouchOutside(cancel: false);
		return obj;
	}

	public override void OnShow(IDialogInterface dialog)
	{
		base.OnShow(dialog);
		base.Behavior.AddBottomSheetCallback(new LockableBottomSheetCallback(base.Behavior));
	}

	protected override void OnInsetsChanged(WindowInsetsCompat insets)
	{
		Insets sbi = insets.GetInsets(WindowInsetsCompat.Type.SystemBars());
		Container.UpdateLayoutParams(delegate(ViewGroup.MarginLayoutParams lp)
		{
			lp.TopMargin = sbi.Top;
		});
		View view = View.RequireViewById<View>(2131297216);
		view.SetPadding(view.PaddingLeft, view.PaddingTop, view.PaddingRight, sbi.Bottom);
	}

	public IDisposable SetTitleClickAction(Action action)
	{
		return _titleLabel?.OnClick(action) ?? Disposable.Empty;
	}
}
