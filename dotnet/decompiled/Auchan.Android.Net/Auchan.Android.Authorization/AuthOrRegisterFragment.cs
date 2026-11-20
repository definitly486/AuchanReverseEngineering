using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using Android.Content;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Authorization.Login;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.DeveloperMenu;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.PersonalCabinet.Authorization;
using Google.Android.Material.Button;
using Google.Android.Material.TextField;
using Microsoft.Maui.ApplicationModel;
using VisibilitySwitch;

namespace Auchan.Android.Authorization;

internal class AuthOrRegisterFragment : BaseFragment<AuthOrRegisterViewModel>
{
	private IToolbarContainer? _parent;

	private TextInputEditText? _passwordInput;

	private readonly IInfoMessageService _infoMessageService;

	protected override int LayoutId => 2131493036;

	public AuthOrRegisterFragment(AuthOrRegisterViewModel newViewModel, IInfoMessageService infoMessageService)
		: base((Func<Fragment, AuthOrRegisterViewModel>)((Fragment thisFragment) => newViewModel))
	{
		_infoMessageService = infoMessageService;
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.LoginCommand.SafeSubscribe(OpenSign, this);
		base.ViewModel.NavigateToDevMenuCommand.SafeSubscribe(NavigateToDevMenu, this);
		base.ViewModel.GoToCatalogCommand.SafeSubscribe(OpenNotAuthCatalog, this);
		base.ViewModel.OpenPasswordEnterCommand.SafeSubscribe(delegate
		{
			if (_passwordInput != null)
			{
				_passwordInput.Text = string.Empty;
				_passwordInput.ForceFocusKeyboard();
			}
		}, this);
		base.ViewModel.OpenVkSignUpCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			NavigateTo<VkSignUpFragment, BrokerToken>(p);
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		View view2 = view.RequireViewById<View>(2131296904);
		View view3 = view.RequireViewById<View>(2131298079);
		ImageView imageView = view.RequireViewById<ImageView>(2131296466);
		_passwordInput = view.RequireViewById<TextInputEditText>(2131297845);
		TextView textView = view.RequireViewById<TextView>(2131296470);
		AppCompatButton appCompatButton = view.RequireViewById<AppCompatButton>(2131297477);
		TextView textView2 = view.RequireViewById<TextView>(2131296600);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131298370);
		_parent = (IToolbarContainer)RequireParentFragment();
		_parent.CloseButtonText = "";
		_parent.Title = base.ViewModel.Title;
		textView.Text = base.ViewModel.AuthOrRegisterText;
		appCompatButton.Text = base.ViewModel.ByPhoneNumberButtonText;
		textView2.Text = base.ViewModel.ByVkButtonText;
		materialButton.Text = base.ViewModel.ShowCatalogButton;
		ViewOnKeyListener viewOnKeyListener = new ViewOnKeyListener(OnKeyboardKeyPressed);
		viewOnKeyListener.AutoDisposeOnDestroy(ViewLifecycleOwner);
		_passwordInput.SetOnKeyListener(viewOnKeyListener);
		_passwordInput.OnTextChanged(delegate(object? o, TextChangedEventArgs e)
		{
			base.ViewModel.VerifyPassword(e.Text?.ToString() ?? "");
			if (e.Text != null && e.Text.ToString().Length == 6)
			{
				_passwordInput.Text = string.Empty;
			}
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		VisibilitySwitch<VisualState> vs = new VisibilitySwitch<VisualState>(base.ViewModel.State)
		{
			{
				VisualState.Default,
				view2,
				_parent.Toolbar
			},
			{
				VisualState.InProgress,
				view3
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			vs.SwitchState(base.ViewModel.State);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(imageView.OnClick(base.ViewModel.OnLogoClick), appCompatButton.OnClick(base.ViewModel.SignClicked), materialButton.OnClick(base.ViewModel.GoToCatalog), textView2.OnClick(base.ViewModel.LoginByVkCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		Task.Delay(1000).ContinueWith((Task _) => _parent.CustomBackAction(delegate
		{
			MainThread.BeginInvokeOnMainThread(delegate
			{
				try
				{
					RequireActivity().Finish();
				}
				catch
				{
				}
			});
		}));
	}

	private bool OnKeyboardKeyPressed(View view, Keycode keyCode, KeyEvent keyEvent)
	{
		if (keyCode == Keycode.Enter)
		{
			_passwordInput?.ForceUnfocusKeyboard();
			return true;
		}
		return false;
	}

	public override void OnResume()
	{
		base.OnResume();
		if (_parent != null)
		{
			_parent.Toolbar.Visibility = ViewStates.Visible;
		}
	}

	public override void OnPause()
	{
		base.OnPause();
		_parent?.CustomBackAction(null);
	}

	private void OpenNotAuthCatalog(Unit unit)
	{
		StartActivity(new Intent(Platform.CurrentActivity, typeof(MainNotAuthActivity)));
	}

	private void OpenSign(LoginViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Replace<LoginFragment>(this, parameter.ToNavBundle()).Commit();
	}

	private void NavigateToDevMenu(Unit unit)
	{
		_passwordInput?.ForceUnfocusKeyboard();
		if (_parent != null)
		{
			_parent.Toolbar.Visibility = ViewStates.Gone;
		}
		base.ParentFragmentManager.BeginTransaction().Replace<DevMenuFragment>(this, null, 123).AddToBackStack(null)
			.Commit();
	}
}
