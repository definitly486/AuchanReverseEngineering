using Android.App;
using Android.Content;
using Android.OS;

namespace AndroidX.Browser.CustomTabs;

[Service]
public class KeepAliveService : Service
{
	private static readonly Binder binder = new Binder();

	public override IBinder OnBind(Intent intent)
	{
		return binder;
	}
}
