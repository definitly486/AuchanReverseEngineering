using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Auchan.Android.Authorization.Managers;
using Auchan.Android.Base;
using Auchan.Android.Ecom.PriceChecker;
using Auchan.Android.Extensions;
using Auchan.Android.Onboardings;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Ecom.Onboardings;
using Auchan.Common.PersonalCabinet.Authorization.Managers;
using DryIoc;

namespace Auchan.Android.Authorization;

[Activity(Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait, LaunchMode = LaunchMode.SingleTask, WindowSoftInputMode = SoftInput.AdjustPan)]
internal class LoginActivity : BaseActivity
{
	public const string LaunchStateParameter = "LaunchState";

	private LoginManager _loginManager;

	protected override int? LayoutId => 2131492893;

	protected override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		if (!Auchan.Android.StartActivity.WasLaunched)
		{
			Intent intent = Intent?.SetClass(ApplicationContext, typeof(StartActivity));
			if (intent == null)
			{
				intent = new Intent(this, typeof(StartActivity));
			}
			FinishAffinity();
			StartActivity(intent);
			return;
		}
		_loginManager = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<ILoginManager>() as LoginManager;
		SupportFragmentManager.RegisterFragmentLifecycleCallbacks(new ScannerFragmentListener(), recursive: true);
		if (savedInstanceState == null)
		{
			LoginActivityLaunchState intExtra = (LoginActivityLaunchState)(Intent ?? new Intent()).GetIntExtra("LaunchState", 0);
			if (intExtra == LoginActivityLaunchState.Onboarding)
			{
				OnboardingsFragment onboardingsFragment = SupportFragmentManager.FragmentFactory.Instantiate<OnboardingsFragment>();
				onboardingsFragment.Arguments = new OnboardingsViewModel.Parameter(ShowAt.BeforeAuth).ToNavBundle();
				onboardingsFragment.Show(SupportFragmentManager, null);
			}
			else
			{
				ToolbarContainerFragment toolbarContainerFragment = SupportFragmentManager.FragmentFactory.Instantiate<ToolbarContainerFragment>();
				Bundle bundle = new Bundle();
				bundle.PutInt("LaunchState", (int)intExtra);
				toolbarContainerFragment.Arguments = bundle;
				toolbarContainerFragment.Show(SupportFragmentManager, "ToolbarContainerFragment");
			}
		}
	}

	public override void OnBackPressed()
	{
	}

	public void ProceedSuccessfulLogin()
	{
		_loginManager.ProceedSuccessfulLogin();
		StartActivity(typeof(MainActivity));
		Finish();
	}

	public static Intent GetLaunchIntent(Context context, LoginActivityLaunchState state)
	{
		Intent intent = new Intent(context, typeof(LoginActivity));
		intent.PutExtra("LaunchState", (int)state);
		return intent;
	}
}
