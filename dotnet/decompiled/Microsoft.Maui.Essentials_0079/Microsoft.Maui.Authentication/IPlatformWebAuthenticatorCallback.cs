using Android.Content;

namespace Microsoft.Maui.Authentication;

public interface IPlatformWebAuthenticatorCallback
{
	bool OnResumeCallback(Intent intent);
}
