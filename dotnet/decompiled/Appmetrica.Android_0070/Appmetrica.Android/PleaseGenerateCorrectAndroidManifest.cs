using Android.App;
using Android.Content;
using Android.OS;

namespace Appmetrica.Android;

[Service(Process = ":AppMetrica")]
public class PleaseGenerateCorrectAndroidManifest : Service
{
	public override IBinder OnBind(Intent? intent)
	{
		return null;
	}
}
