using System;
using System.Threading.Tasks;
using Android.Content;
using Microsoft.Maui.ApplicationModel;

namespace Microsoft.Maui.Authentication;

internal class WebAuthenticatorImplementation : IWebAuthenticator, IPlatformWebAuthenticatorCallback
{
	private TaskCompletionSource<WebAuthenticatorResult> tcsResponse;

	private Uri currentRedirectUri;

	private WebAuthenticatorOptions currentOptions;

	public bool OnResumeCallback(Intent intent)
	{
		if (tcsResponse?.Task?.IsCompleted ?? true)
		{
			return false;
		}
		if (intent?.Data == null)
		{
			tcsResponse.TrySetCanceled();
			return false;
		}
		try
		{
			Uri uri = new Uri(intent.Data.ToString());
			if (!WebUtils.CanHandleCallback(currentRedirectUri, uri))
			{
				tcsResponse.TrySetException(new InvalidOperationException($"Invalid Redirect URI, detected `{uri}` but expected a URI in the format of `{currentRedirectUri}`"));
				return false;
			}
			tcsResponse?.TrySetResult(new WebAuthenticatorResult(uri, currentOptions?.ResponseDecoder));
			return true;
		}
		catch (Exception exception)
		{
			tcsResponse.TrySetException(exception);
			return false;
		}
	}
}
