using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.Graphics;
using AndroidX.Core.View;
using AndroidX.Fragment.App;
using Auchan.Android.Base;

namespace Auchan.Android.SafeEntrance;

[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait, LaunchMode = LaunchMode.SingleTask)]
internal class SafeEntranceContainerActivity : BaseActivity, ISafeEntranceFlowHandler
{
	private const string navKey = "SECANavKey";

	private const string navTransientKey = "SECATransientKey";

	private SafeEntranceParameter _navParameter;

	protected override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		SetContentView(2131492900);
		_navParameter = (SafeEntranceParameter)(Intent?.Extras?.GetInt("SECANavKey")).GetValueOrDefault();
		if (_navParameter == SafeEntranceParameter.EnterPinCodePage)
		{
			OnInsetsChanged(delegate(object? o, ChangedActivityInsetsArgs e)
			{
				Insets insets = e.Insets.GetInsets(WindowInsetsCompat.Type.SystemBars());
				e.ActivityView.SetPadding(e.ActivityViewOriginalPadding.Left, e.ActivityViewOriginalPadding.Top + insets.Top, e.ActivityViewOriginalPadding.Right, e.ActivityViewOriginalPadding.Bottom + insets.Bottom);
				e.Handled = true;
			}).AutoDisposeOnDestroy(this);
			NavigateToFragment<EnterPinCodeFragment>();
		}
	}

	public static Intent GetStartSafeEntranceIntet(Context context, SafeEntranceParameter safeEntranceParameter, bool isTransient)
	{
		Intent intent = new Intent(context, typeof(SafeEntranceContainerActivity));
		Bundle bundle = new Bundle();
		bundle.PutInt("SECANavKey", (int)safeEntranceParameter);
		bundle.PutBoolean("SECATransientKey", isTransient);
		intent.PutExtras(bundle);
		return intent;
	}

	private void NavigateToFragment<T>() where T : AndroidX.Fragment.App.Fragment
	{
		SupportFragmentManager.Replace<T>(2131298271).AddToBackStack(null).Commit();
	}

	void ISafeEntranceFlowHandler.Handle()
	{
		StartActivity(typeof(MainActivity));
		Finish();
	}
}
