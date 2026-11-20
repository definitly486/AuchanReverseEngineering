using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Graphics;
using AndroidX.Core.View;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Common;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Navigation;
using Auchan.Common.NewYearGame;
using DryIoc;
using VisibilitySwitch;

namespace Auchan.Android.NewYearGame;

internal class NewYearGameFragment : BaseFragment<NewYearGameViewModel>
{
	protected override int LayoutId => 2131493067;

	public NewYearGameFragment(Func<BrokerToken, NewYearGameViewModel> newViewModel)
		: base((Func<Fragment, NewYearGameViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		if (RequireActivity() is BaseActivity baseActivity)
		{
			baseActivity.OnInsetsChanged(OnActivityInsetsChanged).AutoDisposeOnDestroy(this);
		}
	}

	private void OnActivityInsetsChanged(object sender, ChangedActivityInsetsArgs e)
	{
		e.Handled = true;
		UpdateInsets(e.Insets);
	}

	private void UpdateInsets(WindowInsetsCompat insets)
	{
		Insets insets2 = insets.GetInsets(WindowInsetsCompat.Type.SystemBars());
		View?.SetPadding(0, 0, 0, insets2.Bottom);
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		WebView webView = view.RequireViewById<WebView>(2131298826);
		view.RequireViewById<FrameLayout>(2131298079);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		TextView errorTitle = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView errorMessage = constraintLayout.RequireViewById<TextView>(2131297563);
		AppCompatButton appCompatButton = constraintLayout.RequireViewById<AppCompatButton>(2131296325);
		constraintLayout.RequireViewById<Button>(2131298371).Visibility = ViewStates.Gone;
		appCompatButton.Text = base.ViewModel.ErrorButtonText;
		webView.SetWebViewClient(new CustomWebViewClient
		{
			InjectQratorHeaders = false,
			IgnoreError400 = true,
			Loading = (WebView _, string url) => base.ViewModel.Loading(url),
			Finished = delegate(WebView _, string url)
			{
				webView.EvaluateJavascript("window.addEventListener('message', event => { JSPostMessageInterface.OnPostMessage(event.data); });", null);
				base.ViewModel.Finished(url);
			},
			HttpError = delegate
			{
				base.ViewModel.OnError();
			},
			WebViewError = delegate
			{
				base.ViewModel.OnError();
			},
			HttpAuthCredentials = base.ViewModel.GameCredentials
		});
		webView.SetLayerType(LayerType.Hardware, null);
		webView.Settings.JavaScriptEnabled = true;
		webView.AddJavascriptInterface(new JSPostMessageInterface(base.ViewModel.OnMessageReceived), "JSPostMessageInterface");
		webView.Settings.DomStorageEnabled = true;
		webView.Settings.BuiltInZoomControls = true;
		webView.Settings.LoadWithOverviewMode = true;
		webView.Settings.UseWideViewPort = true;
		webView.Settings.MixedContentMode = MixedContentHandling.AlwaysAllow;
		webView.SetWebChromeClient(new WebChromeClient());
		VisibilitySwitch<NewYearGameViewModel.VisualState> viewSwitch = new VisibilitySwitch<NewYearGameViewModel.VisualState>(base.ViewModel.State)
		{
			{
				NewYearGameViewModel.VisualState.Default,
				webView
			},
			{
				NewYearGameViewModel.VisualState.Error,
				constraintLayout
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				errorTitle.Text = base.ViewModel.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				viewSwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(appCompatButton.OnClick(base.ViewModel.OnReload)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.LoadUrlCommand.SafeSubscribe(delegate(string url)
		{
			webView.LoadUrl(url, base.ViewModel.Headers);
		}, ViewLifecycleOwner);
		base.ViewModel.PostMessageCommand.SafeSubscribe(delegate(string m)
		{
			webView.EvaluateJavascript($"window.postMessage('{m}', '{base.ViewModel.GameUrl}');", null);
		}, ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(Close, ViewLifecycleOwner);
		base.ViewModel.OpenCategoryCommand.SafeSubscribe(OpenCategory, ViewLifecycleOwner);
		base.ViewModel.PrepareDelayedNavigationCommand.SafeSubscribe(delegate
		{
			Task.Delay(100).ContinueWith(delegate
			{
				DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<INavigationService>().ReadyForDelayedNavigation();
			}).SafeFireAndForget((Action<Exception>)null, false);
			base.ParentFragmentManager.PopBackStackImmediate();
		}, ViewLifecycleOwner);
		if (RequireActivity() is BaseActivity baseActivity)
		{
			UpdateInsets(baseActivity.WindowInsets);
		}
	}

	private void OpenCategory(BrokerToken parameter)
	{
		if ((RequireActivity().SupportFragmentManager.Fragments.FirstOrDefault() as BottomNavigationHostFragment)?.CurrentContainerFragment?.ChildFragmentManager?.Fragments?.LastOrDefault() is BaseFragment baseFragment)
		{
			Close(Unit.Default);
			baseFragment.NavigateTo<CollectionProductsFragment, BrokerToken>(parameter, null, add: true);
		}
	}

	private void Close(Unit _)
	{
		base.ParentFragmentManager.PopBackStackImmediate();
	}

	public override NavigationPossibilityType OnNavigateFrom()
	{
		return NavigationPossibilityType.Delayed;
	}
}
