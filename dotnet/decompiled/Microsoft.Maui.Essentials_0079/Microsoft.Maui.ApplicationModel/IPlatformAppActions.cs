using Android.Content;

namespace Microsoft.Maui.ApplicationModel;

public interface IPlatformAppActions
{
	void OnResume(Intent? intent);
}
