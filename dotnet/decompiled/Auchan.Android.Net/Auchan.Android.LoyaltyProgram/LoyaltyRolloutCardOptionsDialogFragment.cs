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
using Auchan.Android.Authorization;
using Auchan.Android.Base;
using Auchan.Android.Common;
using Auchan.Android.Extensions;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.PersonalCabinet.Authorization;
using Java.Interop;

namespace Auchan.Android.LoyaltyProgram;

public class LoyaltyRolloutCardOptionsDialogFragment : BaseBottomSheetDialogFragment, IToolbarContainer, IDialogInterfaceOnKeyListener, IJavaObject, IDisposable, IJavaPeerable
{
	private View? _backButton;

	private TextView? _titleLabel;

	private TextView? _closeButton;

	private bool _isBackButtonVisible;

	private Action<Unit>? _onBack;

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

	private bool HasFragmentsInBackStack => base.ChildFragmentManager.BackStackEntryCount > 0;

	public override int Theme => 2131951916;

	protected override bool FullScreen => true;

	protected override int LayoutId => 2131493111;

	public IDisposable CustomBackAction(Action<Unit> action)
	{
		_isBackButtonVisible = true;
		_onBack = action;
		OnBackStackChanged();
		return Disposable.Create(this, delegate(LoyaltyRolloutCardOptionsDialogFragment r)
		{
			r.Reset();
		});
	}

	private void Reset()
	{
		_isBackButtonVisible = false;
		_onBack = null;
		OnBackStackChanged();
	}

	public void SetAdjustResizeOrPan(bool resize)
	{
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		Cancelable = false;
		base.ChildFragmentManager.OnBackStackChanged(OnBackStackChanged).AutoDisposeOnDestroy(this);
		if (savedInstanceState == null)
		{
			SignUpViewModel.Parameter parameter = new SignUpViewModel.Parameter
			{
				ReattachType = LoyaltyCardReattachType.BlockAndReatach
			};
			base.ChildFragmentManager.Replace<LoyaltyRolloutCardOptionsFragment>(2131297216, parameter.ToNavBundle()).Commit();
		}
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Toolbar = view.RequireViewById<Toolbar>(2131298669);
		_titleLabel = view.RequireViewById<TextView>(2131298655);
		_backButton = view.RequireViewById<View>(2131296490);
		_closeButton = view.RequireViewById<TextView>(2131296795);
		_closeButton.Text = "Закрыть";
		new CompositeDisposable
		{
			_backButton.OnClick(NavigateToStart),
			_closeButton.OnClick(NavigateToStart)
		}.AutoDisposeOnDestroy(ViewLifecycleOwner);
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
		if (_onBack != null)
		{
			_onBack(Unit.Default);
			return true;
		}
		if (!HasFragmentsInBackStack)
		{
			return false;
		}
		base.ChildFragmentManager.PopBackStack();
		return true;
	}

	private void NavigateToStart()
	{
		Dismiss();
	}

	public void SetResult(string result)
	{
		Dismiss();
		this.ReturnResult(result);
	}

	public override Dialog OnCreateDialog(Bundle savedInstanceState)
	{
		BottomSheetDialog obj = (BottomSheetDialog)base.OnCreateDialog(savedInstanceState);
		obj.SetCanceledOnTouchOutside(cancel: false);
		return obj;
	}

	public override void OnShow(IDialogInterface dialog)
	{
		base.OnShow(dialog);
		base.Behavior.AddBottomSheetCallback(new LockableBottomSheetCallback(base.Behavior));
	}

	public void OnBackStackChanged()
	{
		_backButton.Visibility = (HasFragmentsInBackStack || _isBackButtonVisible).ToVisibility();
	}
}
