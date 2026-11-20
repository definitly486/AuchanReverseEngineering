using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace Microsoft.Maui.Authentication;

[Activity(ConfigurationChanges = (ConfigChanges.Orientation | ConfigChanges.ScreenSize), Exported = false)]
internal class WebAuthenticatorIntermediateActivity : Activity
{
	private bool launched;

	private Intent actualIntent;

	protected override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		Bundle bundle = savedInstanceState ?? Intent.Extras;
		if (bundle != null)
		{
			launched = bundle.GetBoolean("launched", defaultValue: false);
			actualIntent = bundle.GetParcelable("actual_intent") as Intent;
		}
	}

	protected override void OnResume()
	{
		base.OnResume();
		if (!launched)
		{
			StartActivity(actualIntent);
			launched = true;
		}
		else
		{
			WebAuthenticator.Default.OnResume(Intent);
			Finish();
		}
	}

	protected override void OnNewIntent(Intent intent)
	{
		base.OnNewIntent(intent);
		Intent = intent;
	}

	protected override void OnSaveInstanceState(Bundle outState)
	{
		outState.PutBoolean("launched", launched);
		outState.PutParcelable("actual_intent", actualIntent);
		base.OnSaveInstanceState(outState);
	}

	public static void StartActivity(Activity activity, Intent intent)
	{
		Intent intent2 = new Intent(activity, typeof(WebAuthenticatorIntermediateActivity));
		intent2.PutExtra("actual_intent", intent);
		activity.StartActivity(intent2);
	}
}
